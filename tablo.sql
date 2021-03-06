USE [HospitalGuideDB1]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppointmentDays]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_AppointmentDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppointmentHours]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Time] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AppointmentHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cities]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Routerlink] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clinics]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clinics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clinics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CommentTime] [datetime2](7) NULL,
	[HospitalId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlagUrl] [nvarchar](max) NULL,
	[Flagimage] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Routerlink] [nvarchar](max) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[HospitalClinicId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HospitalClinics]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalClinics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClinicId] [int] NOT NULL,
	[HospitalId] [int] NOT NULL,
 CONSTRAINT [PK_HospitalClinics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hospitals]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospitals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Harita] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hospitals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Randevular]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Randevular](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HourId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Randevular] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rates]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HospitalId] [int] NOT NULL,
	[Star1] [int] NULL,
	[Star2] [int] NULL,
	[Star3] [int] NULL,
	[Star4] [int] NULL,
	[Star5] [int] NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 20.01.2019 21:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Citizenship] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[PassId] [nvarchar](max) NULL,
	[Passwordencoder] [varbinary](max) NULL,
	[Passwordhash] [varbinary](max) NULL,
	[Phone] [int] NOT NULL,
	[Surname] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AppointmentDays]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentDays_Doctors_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppointmentDays] CHECK CONSTRAINT [FK_AppointmentDays_Doctors_DoctorId]
GO
ALTER TABLE [dbo].[AppointmentHours]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentHours_AppointmentDays_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[AppointmentDays] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppointmentHours] CHECK CONSTRAINT [FK_AppointmentHours_AppointmentDays_DayId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Hospitals_HospitalId] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Hospitals_HospitalId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_UserInfo_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_UserInfo_UserId]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_HospitalClinics_HospitalClinicId] FOREIGN KEY([HospitalClinicId])
REFERENCES [dbo].[HospitalClinics] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_HospitalClinics_HospitalClinicId]
GO
ALTER TABLE [dbo].[HospitalClinics]  WITH CHECK ADD  CONSTRAINT [FK_HospitalClinics_Clinics_ClinicId] FOREIGN KEY([ClinicId])
REFERENCES [dbo].[Clinics] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalClinics] CHECK CONSTRAINT [FK_HospitalClinics_Clinics_ClinicId]
GO
ALTER TABLE [dbo].[HospitalClinics]  WITH CHECK ADD  CONSTRAINT [FK_HospitalClinics_Hospitals_HospitalId] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalClinics] CHECK CONSTRAINT [FK_HospitalClinics_Hospitals_HospitalId]
GO
ALTER TABLE [dbo].[Randevular]  WITH CHECK ADD  CONSTRAINT [FK_Randevular_AppointmentHours_HourId] FOREIGN KEY([HourId])
REFERENCES [dbo].[AppointmentHours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Randevular] CHECK CONSTRAINT [FK_Randevular_AppointmentHours_HourId]
GO
ALTER TABLE [dbo].[Randevular]  WITH CHECK ADD  CONSTRAINT [FK_Randevular_UserInfo_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Randevular] CHECK CONSTRAINT [FK_Randevular_UserInfo_UserId]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Hospitals_HospitalId] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Hospitals_HospitalId]
GO
