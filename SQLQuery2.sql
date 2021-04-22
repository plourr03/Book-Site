CREATE PROCEDURE GetAllAdmins
 
AS
BEGIN
    select s.UserName From AspNetUsers s, AspNetUserRoles d where d.UserId =s.id
    
    
END;
