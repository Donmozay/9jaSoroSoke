------------------------------------- STORED PROCEDURE to create CarOwner Table -----------------------------------------

if NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='CarOwner')
BEGIN
create table CarOwner(
Id int identity(1,1) NOT NULL ,
ProofOfVehicleOwnerShip varchar(max)Not Null,
PurchaseReciept varchar(max)Not Null,
FirstName varchar(50)Not Null,
LastName varchar(50)Not Null,
PurchaseLocation varchar(200)Not Null,
NameOfFuelingStation varchar(250)Not Null,
PhoneNumber varchar(15)Not Null,
DateReported datetime null,
DatePurchased date not null
)
end






--------------------------------------- STORED PROCEDURE TO  insert CarOwner table -----------------------------------------
if object_id('[dbo].[usp_Insert_CarOwner]') IS NOT NULL
BEGIN
drop procedure [dbo].usp_Insert_CarOwner
end
go
create procedure usp_Insert_CarOwner(
@ProofOfVehicleOwnerShip varchar(max),
@PurchaseReciept varchar(max),
@FirstName varchar(50),
@LastName varchar(50),
@PurchaseLocation varchar(200),
@NameOfFuelingStation varchar(250),
@PhoneNumber varchar(15),
@DatePurchased date ,
@DateReported datetime 
)
AS

begin
INSERT [dbo].[CarOwner](
ProofOfVehicleOwnerShip,
PurchaseReciept,
FirstName,
LastName,
PurchaseLocation,
NameOfFuelingStation,
PhoneNumber,
DatePurchased,
DateReported
)
values(

@ProofOfVehicleOwnerShip,
@PurchaseReciept,
@FirstName,
@LastName,
@PurchaseLocation,
@NameOfFuelingStation,
@PhoneNumber,
@DatePurchased,
@DateReported
)
end
GO
--SET @Id = SCOPE_IDENTITY()
--SELECT @Id


-------------------------------------- STORED PROCEDURE TO  GET All CarOwner Reports -----------------------------------------



if object_id('[dbo].[usp_Get_CarOnwers_Reports') IS NOT NULL
BEGIN
drop procedure [dbo].usp_Get_CarOnwers_Reports
end
go
CREATE procedure [dbo].usp_Get_CarOnwers_Reports
AS

select * from  [dbo].[CarOwner]
ORDER BY CarOwner.Id desc

GO


-------------------------------------- STORED PROCEDURE TO  GET  CarOwner Reports By Id-----------------------------------------



if object_id('[dbo].[usp_Get_CarOnwer_Reports_By_Id') IS NOT NULL
BEGIN
drop procedure [dbo].usp_Get_CarOnwer_Reports_By_Id
end
go
CREATE procedure [dbo].usp_Get_CarOnwer_Reports_By_Id
(@Id int)
AS

select * from  [dbo].[CarOwner]
where CarOwner.Id = @Id

GO

