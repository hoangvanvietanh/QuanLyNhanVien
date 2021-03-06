USE [GiaDinhUniversity]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](100) NULL,
	[Password] [nchar](100) NULL,
	[Role] [nchar](10) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[FullName] [nvarchar](150) NULL,
	[BirthDate] [date] NULL,
	[Address] [nvarchar](150) NULL,
	[Ward] [nvarchar](10) NULL,
	[District] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[PhoneNumber] [nchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Status] [nvarchar](100) NULL,
	[HireDate] [date] NULL,
	[PositionId] [int] NULL,
	[AccountId] [int] NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceID] [int] NOT NULL,
	[ResourceName] [nvarchar](50) NULL,
	[Color] [int] NULL,
	[Image] [image] NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[AllDay] [bit] NULL,
	[Subject] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
	[ResourceID] [int] NULL,
	[ResourceIDs] [nvarchar](max) NULL,
	[ReminderInfo] [nvarchar](max) NULL,
	[RecurrenceInfo] [nvarchar](max) NULL,
	[TimeZoneId] [nvarchar](max) NULL,
	[ApprovalStatus] [nvarchar](100) NULL,
	[AccountId] [int] NULL,
	[DepartmentsList] [nvarchar](200) NULL,
	[PositionList] [nvarchar](200) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleDepartment]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleDepartment](
	[idSchedule] [int] NOT NULL,
	[idDepartment] [int] NOT NULL,
 CONSTRAINT [PK_ScheduleDepartment_1] PRIMARY KEY CLUSTERED 
(
	[idSchedule] ASC,
	[idDepartment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchedulePosition]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchedulePosition](
	[idSchedule] [int] NOT NULL,
	[idPosition] [int] NOT NULL,
 CONSTRAINT [PK_SchedulePosition_1] PRIMARY KEY CLUSTERED 
(
	[idSchedule] ASC,
	[idPosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Accounts]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Position]
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK_Position_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK_Position_Departments]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Appointme__Accou__35BCFE0A] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Appointme__Accou__35BCFE0A]
GO
ALTER TABLE [dbo].[ScheduleDepartment]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDepartment_Departments] FOREIGN KEY([idDepartment])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[ScheduleDepartment] CHECK CONSTRAINT [FK_ScheduleDepartment_Departments]
GO
ALTER TABLE [dbo].[ScheduleDepartment]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDepartment_Schedule] FOREIGN KEY([idSchedule])
REFERENCES [dbo].[Schedule] ([UniqueID])
GO
ALTER TABLE [dbo].[ScheduleDepartment] CHECK CONSTRAINT [FK_ScheduleDepartment_Schedule]
GO
ALTER TABLE [dbo].[SchedulePosition]  WITH CHECK ADD  CONSTRAINT [FK_SchedulePosition_Position] FOREIGN KEY([idPosition])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[SchedulePosition] CHECK CONSTRAINT [FK_SchedulePosition_Position]
GO
ALTER TABLE [dbo].[SchedulePosition]  WITH CHECK ADD  CONSTRAINT [FK_SchedulePosition_Schedule] FOREIGN KEY([idSchedule])
REFERENCES [dbo].[Schedule] ([UniqueID])
GO
ALTER TABLE [dbo].[SchedulePosition] CHECK CONSTRAINT [FK_SchedulePosition_Schedule]
GO
/****** Object:  StoredProcedure [dbo].[getAccountById]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAccountById]
	@id int
as
select * from Accounts where AccountId = @id;
GO
/****** Object:  StoredProcedure [dbo].[getAccountByUserName]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getAccountByUserName]
	@UserName nchar(100)
as
select * from Accounts where TRIM(UserName) like TRIM(@UserName);
GO
/****** Object:  StoredProcedure [dbo].[getAllInfoEmployee]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllInfoEmployee]
	@EmployeeId int
as
select FullName,Email,BirthDate,Address,Ward,District,City,PhoneNumber,Image,PositionName,DepartmentName, UserName,Password,Role from Employees
inner join Accounts on Employees.AccountId = Accounts.AccountId
inner join Position on Position.PositionId = Employees.EmployeeId
inner join Departments on Position.PositionId =  Departments.DepartmentId
where Employees.EmployeeId = @EmployeeId
GO
/****** Object:  StoredProcedure [dbo].[getAllInfoEmployeeNoParam]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllInfoEmployeeNoParam]
	
as
select FullName,Email,BirthDate,Address,Ward,District,City,PhoneNumber,Image,PositionName,DepartmentName, UserName,Password,Role from Employees
inner join Accounts on Employees.AccountId = Accounts.AccountId
inner join Position on Position.PositionId = Employees.EmployeeId
inner join Departments on Position.PositionId =  Departments.DepartmentId
GO
/****** Object:  StoredProcedure [dbo].[getAllSchedule]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getAllSchedule]
as
select * from Schedule
GO
/****** Object:  StoredProcedure [dbo].[getEmployeeByAccountId]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getEmployeeByAccountId]
	@AccountId int
as
select * from Employees where AccountId = @AccountId;
GO
/****** Object:  StoredProcedure [dbo].[getEmployeesByPosition]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getEmployeesByPosition]
	@PositionId int
as
select * from Employees where PositionId = @PositionId;
GO
/****** Object:  StoredProcedure [dbo].[getLastIdUniqueSchedule]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getLastIdUniqueSchedule]
as
SELECT TOP 1 Schedule.UniqueID FROM Schedule ORDER BY Schedule.UniqueID DESC
GO
/****** Object:  StoredProcedure [dbo].[getScheduleDepartmentByScheduleId]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getScheduleDepartmentByScheduleId]
	@idSchedule int
as
select * from ScheduleDepartment where ScheduleDepartment.idSchedule = @idSchedule
GO
/****** Object:  StoredProcedure [dbo].[p_selectAllEmployee]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[p_selectAllEmployee]
as
select AccountId,EmployeeId,FullName,FirstName,LastName,BirthDate,Address,Ward,District,City,PhoneNumber,Email,Status,HireDate,PositionName,DepartmentName,Image from Employees
inner join Position on Employees.PositionId = Position.PositionId
inner join Departments on Position.DepartmentId = Departments.DepartmentId
GO
/****** Object:  StoredProcedure [dbo].[p_selectEmployeeByAccountId]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[p_selectEmployeeByAccountId]
 @AccountId int
as
select FullName,Email,BirthDate,Address,Ward,District,City,PhoneNumber,Image,PositionName,DepartmentName, UserName,Password,Role,Accounts.AccountId, Employees.EmployeeId from Employees
inner join Accounts on Employees.AccountId = Accounts.AccountId
inner join Position on Position.PositionId = Employees.EmployeeId
inner join Departments on Position.PositionId =  Departments.DepartmentId
where Employees.AccountId = 1
GO
/****** Object:  StoredProcedure [dbo].[p_selectSchedulePersonal]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[p_selectSchedulePersonal]
@AccountId int
as
select * from Schedule where AccountId = @AccountId
return
GO
/****** Object:  StoredProcedure [dbo].[userLogin]    Script Date: 8/1/2020 8:30:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[userLogin]
	@UserName nchar(100),
	@Password nchar(100) 
as
select * from Accounts where TRIM(UserName) like TRIM(@UserName) and TRIM(Password) like TRIM(@Password);
GO

/****Bổ sung procedure****/

create procedure getLastedScheduleByAccountID
@AccountId int
as
SELECT TOP 1 * FROM Schedule
where
AccountId = @AccountId
order by Schedule.UniqueID  desc