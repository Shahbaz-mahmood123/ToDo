drop table  Users;


CREATE TABLE Users(
	UserID INT PRIMARY KEY,
	Username varchar(50) not null,
	Password varchar(50) not null,
	Email_Address varchar(200) not null
);

CREATE TABLE ToDoLists(
    ListId Int PRIMARY KEY,
    ListName Varchar(50) NOT NULL,
    ActiveList bit,
	CreatedOn DATETIME,
	LastUpdated  DATETIME,
	UserID INT Not null,
	CONSTRAINT fk_group FOREIGN KEY (UserID) 
        REFERENCES Users(UserID)
);

insert into Users( UserID, Username, Password, Email_Address)
values(1, 'test1', 'test','test1@test.com' )

insert into Users( UserID, Username, Password, Email_Address)
values(2, 'test2', 'test','test2@test.com' )

insert into Users( UserID, Username, Password, Email_Address)
values(3, 'test3', 'test','test3@test.com' )