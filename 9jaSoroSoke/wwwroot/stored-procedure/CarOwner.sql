------------------------------------- STORED PROCEDURE to create CarOwner Table -----------------------------------------

if NOT EXISTS(SELECT 1 FROM sysobjects where type='U' and name ='CarOwner')
BEGIN
create table CarOwner(
Id int identity(1,1) NOT NULL ,
ProofOfVehicleOwnerShip varchar(max)Not Null,
PurchaseReciept varchar(max)Not Null,
DateReported datetime null
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
@DateReported datetime 
)
AS

begin
INSERT [dbo].[CarOwner](
ProofOfVehicleOwnerShip,
PurchaseReciept,
DateReported
)
values(

@ProofOfVehicleOwnerShip,
@PurchaseReciept,
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



IF OBJECT_ID('[dbo].[Update_CarOwner_Report_By_Id]') IS nOT NULL
BEGIN
DROP procedure [dbo].Update_CarOwner_Report_By_Id
END
GO
create procedure [dbo].Update_CarOwner_Report_By_Id(
@Id int,
@ProofOfVehicleOwnerShip varchar(max),
@PurchaseReciept varchar(max)
)
AS

Update CarOwner set ProofOfVehicleOwnerShip=@ProofOfVehicleOwnerShip, PurchaseReciept = @PurchaseReciept   where Id=@Id
GO
