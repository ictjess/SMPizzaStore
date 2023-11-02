/****** Object:  StoredProcedure [dbo].[proc_LoadAvailablePizzaToppings]    Script Date: 11/2/2023 3:02:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_LoadAvailablePizzaToppings]
(
    @pizzaId	INT
)
AS
BEGIN
    SELECT Id, Name
	FROM Topping
	WHERE Id NOT IN (
		SELECT ToppingId 
		FROM PizzaTopping
		WHERE PizzaId = @pizzaId
			AND IsActive = 1
		)
	AND IsActive = 1
END
GO

