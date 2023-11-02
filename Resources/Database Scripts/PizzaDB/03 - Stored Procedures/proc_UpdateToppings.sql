/****** Object:  StoredProcedure [dbo].[proc_UpdateToppings]    Script Date: 11/2/2023 3:05:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_UpdateToppings]
(
    @id				INT,
	@Name			VARCHAR(50),
	@ModifyBy		VARCHAR(50)
)
AS
BEGIN
	DECLARE @count AS INT
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	-- CHECK IF RECORD ALREADY EXIST IN THE DATABASE
	SELECT @count = count(id) 
	FROM Topping
	WHERE name = @Name
		AND id <> @id

	IF (@count > 0)
	BEGIN
		RAISERROR('Record already exist.',16,1)
		RETURN
	END

    UPDATE Topping
	SET Name = @Name,
		ModifyBy = @ModifyBy,
		ModifyDate = GETDATE()
	WHERE Id = @id
END
GO

