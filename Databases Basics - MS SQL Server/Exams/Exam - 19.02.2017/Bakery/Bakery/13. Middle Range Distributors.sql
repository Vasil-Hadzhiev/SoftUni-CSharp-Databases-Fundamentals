SELECT d.Name AS [DistributorName],
       i.Name AS [IngredientName],
	   p.Name AS [ProductName],
	   AVG(f.Rate) AS [AverageRate]
FROM Distributors AS d
INNER JOIN Ingredients AS i ON i.DistributorId = d.Id
INNER JOIN ProductsIngredients AS pii ON pii.IngredientId = i.Id
INNER JOIN Products AS p ON p.Id = pii.ProductId 
INNER JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY d.Name, i.Name, p.Name
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY [DistributorName],
         [IngredientName],
		 [ProductName]