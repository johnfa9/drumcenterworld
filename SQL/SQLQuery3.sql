CREATE PROCEDURE dbo.InsertCustomer
  @JoinDate Date,
  @BillingMethod NCHAR (50),
  @Identity int OUT
AS
INSERT INTO Customer (JoinDate, BillingMethod) VALUES(@JoinDate, @BillingMethod);
SET @Identity = SCOPE_IDENTITY()