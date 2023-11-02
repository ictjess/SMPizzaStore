/****** Object:  StoredProcedure [dbo].[proc_LoadPizzas]    Script Date: 11/2/2023 3:03:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_LoadPizzas]
	
AS
	SELECT TOP 100 id, Name, IsActive, CreateBy, CreateDate, ModifyBy, ModifyDate
	FROM Pizza
	WHERE IsActive = 1
RETURN 0
GO

