/****** Object:  View [dbo].[vw_PizzaTopping]    Script Date: 11/2/2023 2:57:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_PizzaTopping]
AS
SELECT        dbo.PizzaTopping.Id, dbo.PizzaTopping.PizzaId, dbo.Pizza.Name AS PizzaName, dbo.Pizza.IsActive AS PizzaIsActive, dbo.PizzaTopping.ToppingId, dbo.Topping.Name AS ToppingName, 
                         dbo.Topping.IsActive AS ToppingIsActive, dbo.PizzaTopping.IsActive, dbo.PizzaTopping.CreateBy, dbo.PizzaTopping.CreateDate, dbo.PizzaTopping.ModifyBy, dbo.PizzaTopping.ModifyDate
FROM            dbo.Topping INNER JOIN
                         dbo.PizzaTopping ON dbo.Topping.Id = dbo.PizzaTopping.ToppingId INNER JOIN
                         dbo.Pizza ON dbo.PizzaTopping.PizzaId = dbo.Pizza.Id
WHERE        (dbo.Pizza.IsActive = 1) AND (dbo.Topping.IsActive = 1) AND (dbo.PizzaTopping.IsActive = 1)
GO

