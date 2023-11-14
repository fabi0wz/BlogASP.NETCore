CREATE DATABASE Teste;

Use Teste;

CREATE TABLE Images
(
    Images_Id INT PRIMARY KEY,
    Posts_Id INT,
    Image_Path NVARCHAR(MAX)
);

CREATE TABLE Countries
(
    Country_Id INT PRIMARY KEY,
    Country_Name NVARCHAR(255)
);

--CREATE TABLE UserRoles
--(
    -- Define your UserRoles table here
--);

CREATE TABLE Users
(
    User_Id INT PRIMARY KEY IDENTITY,
    -- Define your Users table here
    Description NVARCHAR(MAX),
    Profile_Picture_Path NVARCHAR(MAX)
);

CREATE TABLE Posts
(
    Post_Id INT PRIMARY KEY,
    Name NVARCHAR(255),
    Country_Id INT,
    CreatedAt DATETIME,
    UpdatedAt DATETIME,
    Title NVARCHAR(255),
    Body NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    Images_Id INT NULL, -- Images_Id can be NULL
    CreatedBy INT,      -- Foreign key to Users table
    UpdatedBy INT,      -- Foreign key to Users table
    FOREIGN KEY (Country_Id) REFERENCES Countries(Country_Id),
    FOREIGN KEY (Images_Id) REFERENCES Images(Images_Id),
    FOREIGN KEY (CreatedBy) REFERENCES Users(User_Id),
    FOREIGN KEY (UpdatedBy) REFERENCES Users(User_Id)
);

CREATE TABLE Posts_Users_Likes
(
    Like_Id INT PRIMARY KEY,
    User_Id INT,
    Post_Id INT,
    FOREIGN KEY (User_Id) REFERENCES Users(User_Id),
    FOREIGN KEY (Post_Id) REFERENCES Posts(Post_Id)
);

CREATE TABLE Posts_Users_Views
(
    View_Id INT PRIMARY KEY,
    User_Id INT,
    Post_Id INT,
    FOREIGN KEY (User_Id) REFERENCES Users(User_Id),
    FOREIGN KEY (Post_Id) REFERENCES Posts(Post_Id)
);

CREATE TABLE Posts_Users_Comments
(
    Comment_Id INT PRIMARY KEY,
    User_Id INT,
    Post_Id INT,
    Parent_Comment_Id INT,
    Comment_Body NVARCHAR(MAX),
    FOREIGN KEY (User_Id) REFERENCES Users(User_Id),
    FOREIGN KEY (Post_Id) REFERENCES Posts(Post_Id),
    FOREIGN KEY (Parent_Comment_Id) REFERENCES Posts_Users_Comments(Comment_Id)
);
