/****** Object:  StoredProcedure [dbo].[proc_LoadPizzasById]    Script Date: 11/2/2023 3:03:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[proc_LoadPizzasById]
(
	@Id		INT
)	
AS
	SELECT TOP 100 id, Name, IsActive, CreateBy, CreateDate, ModifyBy, ModifyDate
	FROM Pizza
	WHERE Id = @Id
GO

