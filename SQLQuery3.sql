create database Mctrans
use Mctrans
create table Mc_Price(
	   Id int primary key,
       Auction nvarchar(50),
       State_City nvarchar(50),
       USA_Port nvarchar(50),
	   Price nvarchar(50)
)

go
CREATE PROCEDURE sp_insert
       -- Add the parameters for the stored procedure here
       @Id int,
       @Auction nvarchar(50),
       @State_City nvarchar(50),
       @USA_Port nvarchar(50),
	   @Price nvarchar(50)
AS
BEGIN
       -- SET NOCOUNT ON added to prevent extra result sets from
       -- interfering with SELECT statements.
       SET NOCOUNT ON;

    -- Insert statements for procedure here
       INSERT INTO Mc_Price
              (Id, Auction, State_City, USA_Port, Price)
       VALUES
              (@Id, @Auction, @State_City, @USA_Port, @Price)
END