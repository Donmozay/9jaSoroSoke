------------------------------------- STORED PROCEDURE to create CompanyOwner Table -----------------------------------------

if NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='CompanyOwner')
BEGIN
create table CompanyOwner(
Id int identity(1,1) NOT NULL ,
PurchaseReciept varchar(max)Not Null,
CompanyName varchar(150)Not Null,
CompanyAddress varchar(250)Not Null,
FuelDepotName varchar(150)Not Null,
FuelDepotAddress varchar(250)Not Null,
CompanyPhoneNumber varchar(15)Not Null,
DateReported datetime null,
DatePurchased date not null
)
end






--------------------------------------- STORED PROCEDURE TO  insert CompanyOwner table -----------------------------------------
if object_id('[dbo].[usp_Insert_CompanyOwner_Report]') IS NOT NULL
BEGIN
drop procedure [dbo].usp_Insert_CompanyOwner_Report
end
go
create procedure usp_Insert_CompanyOwner_Report(
@PurchaseReciept varchar(max),
@CompanyName varchar(150),
@CompanyAddress varchar(250),
@FuelDepotName varchar(150),
@FuelDepotAddress varchar(250),
@CompanyPhoneNumber varchar(15),
@DatePurchased date ,
@DateReported datetime 
)
AS

begin
INSERT [dbo].[CompanyOwner](
PurchaseReciept,
CompanyName,
CompanyAddress,
FuelDepotName,
FuelDepotAddress,
CompanyPhoneNumber,
DatePurchased,
DateReported
)
values(
@PurchaseReciept,
@CompanyName,
@CompanyAddress,
@FuelDepotName,
@FuelDepotAddress,
@CompanyPhoneNumber,
@DatePurchased,
@DateReported
)
end
GO
--SET @Id = SCOPE_IDENTITY()
--SELECT @Id


-------------------------------------- STORED PROCEDURE TO  GET All CompanyOwners Reports -----------------------------------------



if object_id('[dbo].[usp_Get_CompanyOnwers_Reports') IS NOT NULL
BEGIN
drop procedure [dbo].usp_Get_CompanyOnwers_Reports
end
go
CREATE procedure [dbo].usp_Get_CompanyOnwers_Reports
AS

select * from  [dbo].[CompanyOwner]
ORDER BY CompanyOwner.Id desc

GO


-------------------------------------- STORED PROCEDURE TO  GET  CompanyOwner Reports By Id-----------------------------------------



if object_id('[dbo].[usp_Get_CompanyOnwer_Reports_By_Id') IS NOT NULL
BEGIN
drop procedure [dbo].usp_Get_CompanyOnwer_Reports_By_Id
end
go
CREATE procedure [dbo].usp_Get_CompanyOnwer_Reports_By_Id
(@Id int)
AS

select * from  [dbo].[CompanyOwner]
where CompanyOwner.Id = @Id

GO

