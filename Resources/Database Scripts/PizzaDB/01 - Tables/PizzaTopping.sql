/****** Object:  Table [dbo].[PizzaTopping]    Script Date: 11/2/2023 2:54:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PizzaTopping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PizzaId] [int] NOT NULL,
	[ToppingId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyBy] [varchar](50) NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PizzaTopping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_PizzaId]  DEFAULT ((-1)) FOR [PizzaId]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_ToppingId]  DEFAULT ((-1)) FOR [ToppingId]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_CreateBy]  DEFAULT ('') FOR [CreateBy]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_ModifyBy]  DEFAULT ('') FOR [ModifyBy]
GO

ALTER TABLE [dbo].[PizzaTopping] ADD  CONSTRAINT [DF_PizzaTopping_ModifyDate]  DEFAULT (getdate()) FOR [ModifyDate]
GO

