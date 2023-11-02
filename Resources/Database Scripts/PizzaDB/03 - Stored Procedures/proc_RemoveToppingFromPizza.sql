/****** Object:  StoredProcedure [dbo].[proc_RemoveToppingFromPizza]    Script Date: 11/2/2023 3:04:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[proc_RemoveToppingFromPizza]
(
    @pizzaId		INT,
	@toppingId		INT,
	@modifyBy		VARCHAR(50)
)
AS
BEGIN
    UPDATE PizzaTopping 
	SET IsActive = 0
	WHERE PizzaId = @pizzaId
		AND ToppingId = @toppingId
END
GO

