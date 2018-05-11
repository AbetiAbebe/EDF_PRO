create database ESDproject
go

USE ESDproject
go

CREATE TABLE [ACTIVITIES] (
  [Project_ID] int,
  [Activity_ID] int,
  [Predicted_Start] datetime,
  [Actual_Start] datetime,
  [Predicted_Completion] datetime,
  [Actual_Completion] datetime,
  [Estimated_Cost] decimal(6,3),
  [Actual_Cost] decimal(6,3),
  PRIMARY KEY ([Project_ID], [Activity_ID])
);

INSERT INTO [ACTIVITIES] ([Project_ID], [Activity_ID], [Estimated_Cost], [Actual_Cost])
VALUES (1,1, 120.25,120.36);

CREATE TABLE [STAFF] (
  [Staff_ID] int,
  [Staff_Name] varchar(50),
  [Staff_Type] char(20),
  [Staff_Contact] varchar(50),
  [work_hours_per_week] int,
  [Contract _permantent] char(4),
  [salary_per_hour] decimal(6,3),
  PRIMARY KEY ([Staff_ID])
);

CREATE TABLE [PROJECT] (
  [Project_ID] int,
  [Project _name] varchar(50),
  [Client_ID] int,
  [Project_Details] varchar(100),
  [Predicted_Launch] datetime,
  [Actual _Launch] datetime,
  [Predicted_Completion] datetime,
  [Actual_Completion] datetime,
  [Estimated_Cost] decimal(10,2),
  [Actual_Cost] decimal(10,2),
  [Price] decimal(10,2),
  PRIMARY KEY ([Project_ID])
);

CREATE INDEX [FK] ON  [PROJECT] ([Client_ID]);

CREATE TABLE [TASKS] (
  [Project_ID] int,
  [Task_ID] int,
  [Staff_ID] int,
  [Predicted Start] datetime,
  [Actual_Start] datetime,
  [Predicted_Completion] datetime,
  [Actual_Completion] datetime,
  [Estimated_Cost] decimal(6,3),
  [Actual_Cost] decimal(6,3),
  PRIMARY KEY ([Project_ID], [Task_ID])
);

CREATE TABLE [CLIENTS] (
  [Client_ID] int,
  [Client_Name] varchar(25),
  [Client Email] varchar(50),
  [Client_contact_number] char(20),
  PRIMARY KEY ([Client_ID])
);

CREATE TABLE [Dependences] (
  [Dependences_ID] int,
  [Activity ID] int,
  [Task_ID] int,
  [Dependencies_Task] int,
  [Dependenciey_Activity] int,
  PRIMARY KEY ([Dependences_ID])
);

CREATE INDEX [FK] ON  [Dependences] ([Activity ID], [Task_ID]);


