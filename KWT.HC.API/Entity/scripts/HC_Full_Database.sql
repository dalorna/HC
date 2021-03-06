/****** Object:  Table [dbo].[ActivityNote]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleDayId] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[ActivityOptionId] [int] NULL,
	[Style] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DayHour]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayHour](
	[DayHour] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GraphOption]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GraphOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[OptionType] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HC_User]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HC_User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [nvarchar](500) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Role] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_HC_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logo]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[LogoFile] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[DayZero] [datetime] NOT NULL,
	[CopyId] [int] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleDay]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleDay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[DayDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleTurbine]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleTurbine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[TurbineId] [int] NOT NULL,
 CONSTRAINT [PK_ScheduleTurbine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turbine]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turbine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[TurbineOrder] [int] NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[LineType] [nvarchar](50) NOT NULL,
	[Min] [decimal](18, 2) NULL,
	[Max] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](500) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[LoadIncrements] [SMALLINT] NULL,
 CONSTRAINT [PK_Turbine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurbineLoad]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurbineLoad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TurbineId] [int] NOT NULL,
	[MegaWatt] [decimal](18, 2) NULL,
	[Percentage] [decimal](18, 2) NULL,
	[BTU] [int] NOT NULL,
	[NoLoad] [bit] NOT NULL,
 CONSTRAINT [PK_TurbineWatt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurbineTime]    Script Date: 2/3/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurbineTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleDayId] [int] NOT NULL,
	[Time] [int] NOT NULL,
	[TurbineId] [int] NOT NULL,
	[TurbineLoadId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HC_User] ADD  CONSTRAINT [DF_HC_User_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[HC_User] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HC_User] ADD  DEFAULT ('Admin') FOR [Role]
GO
ALTER TABLE [dbo].[Turbine] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (0)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (1)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (2)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (3)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (4)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (5)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (6)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (7)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (8)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (9)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (10)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (11)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (12)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (13)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (14)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (15)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (16)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (17)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (18)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (19)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (20)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (21)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (22)
GO
INSERT [dbo].[DayHour] ([DayHour]) VALUES (23)
GO
INSERT [dbo].[HC_User] ([Id], [FirstName], [LastName], [Email], [Active], [CreatedBy], [Title], [CreateDate], [Role]) VALUES (N'a09ed909-8812-4f32-1791-08d871283a95', N'Jonathan', N'Campbell', N'johnathan.campbell@kiewit.com', 1, N'67e7012e-a486-4cac-87a4-b16e9f6e416b', N'Start Up Manager', CAST(N'2020-10-15T20:10:54.977' AS DateTime), N'Admin')
GO
INSERT [dbo].[HC_User] ([Id], [FirstName], [LastName], [Email], [Active], [CreatedBy], [Title], [CreateDate], [Role]) VALUES (N'7f6a9866-8d4f-49ea-1792-08d871283a95', N'Alex', N'Khochafian', N'alex.khochafian@kiewit.com', 1, N'67e7012e-a486-4cac-87a4-b16e9f6e416b', N'Commissioning Director', CAST(N'2020-10-15T20:09:39.053' AS DateTime), N'Admin')
GO
INSERT [dbo].[HC_User] ([Id], [FirstName], [LastName], [Email], [Active], [CreatedBy], [Title], [CreateDate], [Role]) VALUES (N'bf092f9e-5d95-45ae-1794-08d871283a95', N'nicole', N'urban', N'nicole.urban@kiewit.com', 1, N'f88c9cec-d768-4a8c-1790-08d871283a95', N'BA', CAST(N'2020-10-16T16:30:59.683' AS DateTime), N'Admin')
GO
INSERT [dbo].[HC_User] ([Id], [FirstName], [LastName], [Email], [Active], [CreatedBy], [Title], [CreateDate], [Role]) VALUES (N'2017c35a-78d8-4724-f2c3-08d89d4062f7', N'Asif', N'Mohammed', N'asif.mohammed@kiewit.com', 1, N'67e7012e-a486-4cac-87a4-b16e9f6e416b', N'BA', CAST(N'2020-12-10T19:18:34.597' AS DateTime), N'Admin')
GO
INSERT [dbo].[HC_User] ([Id], [FirstName], [LastName], [Email], [Active], [CreatedBy], [Title], [CreateDate], [Role]) VALUES (N'67e7012e-a486-4cac-87a4-b16e9f6e416b', N'Jason', N'Rango', N'jason.rango@kiewit.com', 1, N'67e7012e-a486-4cac-87a4-b16e9f6e416b', N'Software Engineer', CAST(N'2020-10-16T12:06:38.947' AS DateTime), N'Admin')
GO
