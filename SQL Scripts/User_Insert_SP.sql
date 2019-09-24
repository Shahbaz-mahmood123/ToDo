use ToDo
GO

/****** Object:  StoredProcedure [dbo].[USER_INSERT]    Script Date: 24/09/2019 10:33:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



----------------------------------------------------------------------   
-- Description: Inserts users details upon registration and returns user id   
----------------------------------------------------------------------   
-- Shahbaz: 24/09/19
----------------------------------------------------------------------   

alter PROCEDURE [dbo].[USER_INSERT]
    (
        @AV_PASSWORD NVARCHAR(255) ,
        @AV_USERNAME NVARCHAR(150) ,
        @AV_EMAILADDRESS NVARCHAR(255),
		@AV_USERID INT
		
    )
AS
    BEGIN
        INSERT INTO Users (   [Password] ,
                              UserName ,
                              [Email Address], 
							  userid
                          )
        VALUES ( 
                 @AV_PASSWORD ,
                 @AV_USERNAME ,
                 @AV_EMAILADDRESS,
				 @Av_Userid 
               );

        DECLARE @UserId INT;
        SET @UserId = SCOPE_IDENTITY();

        -- SELECT THE INSERTED RECORD   
        SELECT U.UserId 
        FROM   Users U
        WHERE  U.UserId = @UserId;

        RETURN @UserId;
    END;
GO


