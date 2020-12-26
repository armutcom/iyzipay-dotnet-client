# Iyzipay Client Library for .Net Framework and .Net Core

Unofficial Iyzipay client library that is maintained by [Armut.com](https://armut.com/), a fork of the [iyzipay-dotnet](https://github.com/iyzico/iyzipay-dotnet)

Supports .NET Framework, .NET Core 1.1, .NET Core 2.0 runtimes, .NET Core 2.1 runtimes

You can sign up for an iyzico account at https://iyzico.com

## Builds status
| Build server                | Platform      | Build status                                                                                                                                                        | 
|-----------------------------|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Azure Pipelines             | Ubuntu        | [![Build status](https://dev.azure.com/armutcom/iyzipay-dotnet-client/_apis/build/status/iyzipay-dotnet-client%20-%20Ubuntu)](https://dev.azure.com/armutcom/iyzipay-dotnet-client/_build/latest?definitionId=4) | |
| Azure Pipelines             | MacOs         | [![Build status](https://dev.azure.com/armutcom/iyzipay-dotnet-client/_apis/build/status/iyzipay-dotnet-client%20-%20MacOs)](https://dev.azure.com/armutcom/iyzipay-dotnet-client/_build/latest?definitionId=5) | |
| Azure Pipelines             | Windows       | [![Build status](https://dev.azure.com/armutcom/iyzipay-dotnet-client/_apis/build/status/iyzipay-dotnet-client%20-%20Windows)](https://dev.azure.com/armutcom/iyzipay-dotnet-client/_build/latest?definitionId=6) | |

## Installation
[![NuGet](https://img.shields.io/nuget/v/Armut.Iyzipay.svg)](https://www.nuget.org/packages/Armut.Iyzipay)

To install Armut.Iyzipay, run the following command in the Package Manager Console

```
Install-Package Armut.Iyzipay
```
 
# Relation To Official Iyzipay

This client library is a fork of [iyzipay-dotnet](https://github.com/iyzico/iyzipay-dotnet). The following improvements have been made:

- Unit tests in [iyipay-java](https://github.com/iyzico/iyzipay-java) library have been adapted to C#.
- Supported .NET Core 1.1 and .NET Core 2.0 by converting the client library to .NET Standard.
- Async support provided.
- Instead of creating a new 'HttpClient' in each request, the shared 'HttpClient' has been used.
- Refactoring done according to C# coding standards.

Because armut.com is already using iyzico, armut.com will keep the Armut.Iyzipay project up to date and maintain it.

# Usage

```csharp
var options = new Options
{
	ApiKey = "your api key",
	SecretKey = "your secret key",
	BaseUrl = "https://sandbox-api.iyzipay.com"
};
		
var request = new CreatePaymentRequest
{
	Locale = Locale.TR.ToString(),
	ConversationId = "123456789",
	Price = "1",
	PaidPrice = "1.2",
	Currency = Currency.TRY.ToString(),
	Installment = 1,
	BasketId = "B67832",
	PaymentChannel = PaymentChannel.WEB.ToString(),
	PaymentGroup = PaymentGroup.PRODUCT.ToString()
};

var paymentCard = new PaymentCard
{
	CardHolderName = "John Doe",
	CardNumber = "5528790000000008",
	ExpireMonth = "12",
	ExpireYear = "2030",
	Cvc = "123",
	RegisterCard = 0
};

request.PaymentCard = paymentCard;

var buyer = new Buyer
{
	Id = "BY789",
	Name = "John",
	Surname = "Doe",
	GsmNumber = "+905350000000",
	Email = "email@email.com",
	IdentityNumber = "74300864791",
	LastLoginDate = "2015-10-05 12:43:35",
	RegistrationDate = "2013-04-21 15:12:09",
	RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
	Ip = "85.34.78.112",
	City = "Istanbul",
	Country = "Turkey",
	ZipCode = "34732"
};

request.Buyer = buyer;

var shippingAddress = new Address
{
	ContactName = "Jane Doe",
	City = "Istanbul",
	Country = "Turkey",
	Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
	ZipCode = "34742"
};

request.ShippingAddress = shippingAddress;

var billingAddress = new Address
{
	ContactName = "Jane Doe",
	City = "Istanbul",
	Country = "Turkey",
	Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
	ZipCode = "34742"
};

request.BillingAddress = billingAddress;

var firstBasketItem = new BasketItem
{
	Id = "BI101",
	Name = "Binocular",
	Category1 = "Collectibles",
	Category2 = "Accessories",
	ItemType = BasketItemType.PHYSICAL.ToString(),
	Price = "0.3"
};

var secondBasketItem = new BasketItem
{
	Id = "BI102",
	Name = "Game code",
	Category1 = "Game",
	Category2 = "Online Game Items",
	ItemType = BasketItemType.VIRTUAL.ToString(),
	Price = "0.5"
};

var thirdBasketItem = new BasketItem
{
	Id = "BI103",
	Name = "Usb",
	Category1 = "Electronics",
	Category2 = "Usb / Cable",
	ItemType = BasketItemType.PHYSICAL.ToString(),
	Price = "0.2"
};

var basketItems = new List<BasketItem>
{
	firstBasketItem,
	secondBasketItem,
	thirdBasketItem
};

request.BasketItems = basketItems;

Payment payment = await Payment.CreateAsync(request, options);
```
See other samples under Iyzipay.Samples project.

# Testing

You can run particular sample by passing your credential info to "Iyzipay.Samples/Sample.cs"

You can execute `dotnet test ./Iyzipay.Tests -c Release` project in order to run unit tests. Or use one of the `build.sh`, `build.cmd` or `build.ps1`

### Mock test cards

Test cards that can be used to simulate a *successful* payment:

Card Number      | Bank                       | Card Type
-----------      | ----                       | ---------
5890040000000016 | Akbank                     | Master Card (Debit)  
5526080000000006 | Akbank                     | Master Card (Credit)  
4766620000000001 | Denizbank                  | Visa (Debit)  
4603450000000000 | Denizbank                  | Visa (Credit)
4729150000000005 | Denizbank Bonus            | Visa (Credit)  
4987490000000002 | Finansbank                 | Visa (Debit)  
5311570000000005 | Finansbank                 | Master Card (Credit)  
9792020000000001 | Finansbank                 | Troy (Debit)  
9792030000000000 | Finansbank                 | Troy (Credit)  
5170410000000004 | Garanti Bankası            | Master Card (Debit)  
5400360000000003 | Garanti Bankası            | Master Card (Credit)  
374427000000003  | Garanti Bankası            | American Express  
4475050000000003 | Halkbank                   | Visa (Debit)  
5528790000000008 | Halkbank                   | Master Card (Credit)  
4059030000000009 | HSBC Bank                  | Visa (Debit)  
5504720000000003 | HSBC Bank                  | Master Card (Credit)  
5892830000000000 | Türkiye İş Bankası         | Master Card (Debit)  
4543590000000006 | Türkiye İş Bankası         | Visa (Credit)  
4910050000000006 | Vakıfbank                  | Visa (Debit)  
4157920000000002 | Vakıfbank                  | Visa (Credit)  
5168880000000002 | Yapı ve Kredi Bankası      | Master Card (Debit)  
5451030000000000 | Yapı ve Kredi Bankası      | Master Card (Credit)  

*Cross border* test cards:

Card Number      | Country
-----------      | -------
4054180000000007 | Non-Turkish (Debit)
5400010000000004 | Non-Turkish (Credit)  
6221060000000004 | Iran  

Test cards to get specific *error* codes:

Card Number       | Description
-----------       | -----------
5406670000000009  | Success but cannot be cancelled, refund or post auth
4111111111111129  | Not sufficient funds
4129111111111111  | Do not honour
4128111111111112  | Invalid transaction
4127111111111113  | Lost card
4126111111111114  | Stolen card
4125111111111115  | Expired card
4124111111111116  | Invalid cvc2
4123111111111117  | Not permitted to card holder
4122111111111118  | Not permitted to terminal
4121111111111119  | Fraud suspect
4120111111111110  | Pickup card
4130111111111118  | General error
4131111111111117  | Success but mdStatus is 0
4141111111111115  | Success but mdStatus is 4
4151111111111112  | 3dsecure initialize failed
