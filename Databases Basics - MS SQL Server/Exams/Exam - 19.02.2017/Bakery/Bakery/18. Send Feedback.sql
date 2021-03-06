CREATE PROC usp_SendFeedback @CustomerId INT, @ProductId INT, @Rate DECIMAL(4, 2),
	                         @Description NVARCHAR(255) AS
BEGIN
BEGIN TRANSACTION
	INSERT INTO Feedbacks (CustomerId, ProductId, Rate, [Description]) VALUES
	(@CustomerId, @ProductId, @Rate, @Description)

	DECLARE @FeedbackCount INT = 
	(
		SELECT COUNT(f.Id)
		FROM Feedbacks AS f
		WHERE ProductId = @productId AND CustomerId = @customerId
	
	)
	IF @FeedbackCount > 3
	BEGIN
		ROLLBACK
		RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)		
	END
	ELSE
		COMMIT
END