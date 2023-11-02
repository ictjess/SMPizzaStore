/****** Object:  Table [dbo].[Topping]    Script Date: 11/2/2023 2:55:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Topping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK__Topping__3214EC07F30C1EA3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Topping] ADD  CONSTRAINT [DF__Topping__Name__5CD6CB2B]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[Topping] ADD  CONSTRAINT [DF__Topping__IsActiv__5DCAEF64]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Topping] ADD  CONSTRAINT [DF__Topping__CreateB__5EBF139D]  DEFAULT ('') FOR [CreateBy]
GO

ALTER TABLE [dbo].[Topping] ADD  CONSTRAINT [DF__Topping__CreateD__5FB337D6]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Topping] ADD  CONSTRAINT [DF__Topping__ModifyB__60A75C0F]  DEFAULT ('') FOR [ModifyBy]
GO

