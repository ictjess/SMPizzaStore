/****** Object:  StoredProcedure [dbo].[proc_LoadToppingsById]    Script Date: 11/2/2023 3:04:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_LoadToppingsById]
(
	@Id		INT
)	
AS
	SELECT TOP 100 id, Name, IsActive, CreateBy, CreateDate, ModifyBy, ModifyDate
	FROM Topping
	WHERE Id = @Id
GO

