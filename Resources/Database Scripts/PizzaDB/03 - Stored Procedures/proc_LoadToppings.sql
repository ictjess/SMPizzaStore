/****** Object:  StoredProcedure [dbo].[proc_LoadToppings]    Script Date: 11/2/2023 3:04:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_LoadToppings]
	
AS
	SELECT TOP 100 id, Name, IsActive, CreateBy, CreateDate, ModifyBy, ModifyDate
	FROM Topping
	WHERE IsActive = 1
RETURN 0
GO

