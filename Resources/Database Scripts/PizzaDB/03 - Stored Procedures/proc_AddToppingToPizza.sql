/****** Object:  StoredProcedure [dbo].[proc_AddToppingToPizza]    Script Date: 11/2/2023 2:59:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_AddToppingToPizza]
(
    @pizzaId		INT,
	@toppingId		INT,
	@createBy		VARCHAR(50)
)
AS
BEGIN

	UPDATE PizzaTopping 
	SET IsActive = 0
	WHERE PizzaId = @pizzaId
		AND ToppingId = @toppingId

    INSERT INTO PizzaTopping (PizzaId, ToppingId, CreateBy)
	VALUES (@pizzaId, @toppingId, @createBy)
END
GO

