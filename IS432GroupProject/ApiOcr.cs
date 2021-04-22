
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;


namespace IS432GroupProject
{
    public class ApiOCR
    {
        // Replace <Subscription Key> with your valid subscription key.  
        const string subscriptionKey = "c7189cb667d249c4bd40d9434df78257";

        // You must use the same region in your REST call as you used to  
        // get your subscription keys. The paid subscription keys you will get  
        // it from microsoft azure portal.  
        // Free trial subscription keys are generated in the westcentralus region.  
        // If you use a free trial subscription key, you shouldn't need to change  
        // this region.  
        const string endPoint =
            "https://eastus.api.cognitive.microsoft.com/";

        
                public string contentString { get; private set; }

        public HttpResponseMessage response { get; private set; }
        public string JsonParse { get => JToken.Parse(contentString).ToString(); }

        public ApiOCR()
        {
            //constructor
            contentString = string.Empty;
        }



        public async Task<string> MakeOCRRequest(string v)
        {
            string imageFilePath =  v ;
            var errors = new List<string>();
            string extractedResult = "";
            ExtractImage responeData = new ExtractImage();

            try
            {
                HttpClient client = new HttpClient();

                // Request headers.  
                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", subscriptionKey);

                // Request parameters.  
                string requestParameters = "language=unk&detectOrientation=true";

                // Assemble the URI for the REST API Call.  
               // string uri = endPoint + "?" + requestParameters;

                string uriBase = endPoint + "vision/v2.1/ocr";

                string uri = uriBase + "?" + requestParameters;

                HttpResponseMessage response;

                // Request body. Posts a locally stored JPEG image.  
                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".  
                    // The other content types you can use are "application/json"  
                    // and "multipart/form-data".  
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    // Make the REST API call.  
                    response = await client.PostAsync(uri, content);
                }

                // Get the JSON response.  
                string result = await response.Content.ReadAsStringAsync();

                string jresult = JToken.Parse(result).ToString();
                 

                //If it is success it will execute further process.  
                if (response.IsSuccessStatusCode)
                {
                    // The JSON response mapped into respective view model.  
                    responeData = JsonConvert.DeserializeObject<ExtractImage>(result,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Include,
                            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                            {
                                errors.Add(earg.ErrorContext.Member.ToString());
                                earg.ErrorContext.Handled = true;
                            }
                        }
                    );

                    var linesCount = responeData.regions[0].lines.Count;
                    for (int i = 0; i < linesCount; i++)
                    {
                        var wordsCount = responeData.regions[0].lines[i].words.Count;
                        for (int j = 0; j < wordsCount; j++)
                        {
                            //Appending all the lines content into one.  
                            extractedResult += responeData.regions[0].lines[i].words[j].text + " ";
                        }
                        extractedResult += Environment.NewLine;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
            return extractedResult;
        }  
  
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}