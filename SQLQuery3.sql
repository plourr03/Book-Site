CREATE PROCEDURE AddAdmin
@roleID nvarchar (3),
 @UserName NVARCHAR (128)
AS
BEGIN
    DECLARE @UserID NVARCHAR (128)

    SELECT @UserId = Id From AspNetUsers where @UserName =UserName
    
    insert into AspNetUserRoles(UserId, RoleId) values( @UserID,@roleID)
END;