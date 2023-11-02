/****** Object:  StoredProcedure [dbo].[proc_LoadAddedPizzaToppings]    Script Date: 11/2/2023 3:02:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_LoadAddedPizzaToppings]
(
    @pizzaId	INT
)
AS
BEGIN
    SELECT ToppingId, ToppingName 
	FROM vw_PizzaTopping
	WHERE PizzaId = @pizzaId
		AND IsActive = 1
END
GO

