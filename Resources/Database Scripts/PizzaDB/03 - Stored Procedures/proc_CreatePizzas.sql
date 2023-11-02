/****** Object:  StoredProcedure [dbo].[proc_CreatePizzas]    Script Date: 11/2/2023 3:00:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_CreatePizzas]
(
    @Name			VARCHAR(50),
	@CreateBy		VARCHAR(50)
)
AS
BEGIN

	DECLARE @count AS INT
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	-- CHECK IF RECORD ALREADY EXIST IN THE DATABASE
	SELECT @count = count(id) 
	FROM Pizza
	WHERE name = @name
	
	IF (@count > 0)
	BEGIN
		RAISERROR('Record already exist.',16,1)
		RETURN
	END

    INSERT INTO Pizza (Name, CreateBy)
	VALUES (@Name, @CreateBy)
END
GO

