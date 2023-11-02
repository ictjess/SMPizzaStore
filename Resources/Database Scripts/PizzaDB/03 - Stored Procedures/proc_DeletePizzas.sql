/****** Object:  StoredProcedure [dbo].[proc_DeletePizzas]    Script Date: 11/2/2023 3:01:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_DeletePizzas]
(
    @id				INT,
	@ModifyBy		VARCHAR(50)
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    UPDATE Pizza
	SET IsActive = 0,
		ModifyBy = @ModifyBy,
		ModifyDate = GETDATE()
	WHERE Id = @id
END
GO

