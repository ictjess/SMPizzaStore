/****** Object:  Table [dbo].[Pizza]    Script Date: 11/2/2023 2:49:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pizza](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Pizza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pizza] ADD  CONSTRAINT [DF_Pizza_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[Pizza] ADD  CONSTRAINT [DF_Pizza_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Pizza] ADD  CONSTRAINT [DF_Pizza_CreateBy]  DEFAULT ('') FOR [CreateBy]
GO

ALTER TABLE [dbo].[Pizza] ADD  CONSTRAINT [DF_Pizza_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Pizza] ADD  CONSTRAINT [DF_Pizza_ModifyBy]  DEFAULT ('') FOR [ModifyBy]
GO

