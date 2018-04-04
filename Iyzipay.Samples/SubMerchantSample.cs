using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class SubMerchantSample : Sample
    {
        [Test]
        public async Task Should_Create_Personal_Sub_Merchant()
        {
            CreateSubMerchantRequest request = new CreateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantExternalId = "B49224",
                SubMerchantType = SubMerchantType.PERSONAL.ToString(),
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ContactName = "John",
                ContactSurname = "Doe",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000000",
                Name = "John's market",
                Iban = "TR180006200119000006672315",
                IdentityNumber = "31300864726",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.CreateAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }

        [Test]
        public async Task Should_Create_Private_Sub_Merchant()
        {
            CreateSubMerchantRequest request = new CreateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantExternalId = "S49222",
                SubMerchantType = SubMerchantType.PRIVATE_COMPANY.ToString(),
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                TaxOffice = "Tax office",
                LegalCompanyTitle = "John Doe inc",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000000",
                Name = "John's market",
                Iban = "TR180006200119000006672315",
                IdentityNumber = "31300864726",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.CreateAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }

        [Test]
        public async Task Should_Create_Limited_Company_Sub_Merchant()
        {
            CreateSubMerchantRequest request = new CreateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantExternalId = "AS49224",
                SubMerchantType = SubMerchantType.LIMITED_OR_JOINT_STOCK_COMPANY.ToString(),
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                TaxOffice = "Tax office",
                TaxNumber = "9261877",
                LegalCompanyTitle = "XYZ inc",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000000",
                Name = "John's market",
                Iban = "TR180006200119000006672315",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.CreateAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }

        [Test]
        public async Task Should_Update_Personal_Sub_Merchant()
        {
            UpdateSubMerchantRequest request = new UpdateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantKey = "sub merchant key",
                Iban = "TR630006200027700006678204",
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ContactName = "Jane",
                ContactSurname = "Doe",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000000",
                Name = "Jane's market",
                IdentityNumber = "31300864726",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.UpdateAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }

        [Test]
        public async Task Should_Update_Private_Sub_Merchant()
        {
            UpdateSubMerchantRequest request = new UpdateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantKey = "sub merchant key",
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                TaxOffice = "Tax office",
                LegalCompanyTitle = "Jane Doe inc",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000000",
                Name = "Jane's market",
                Iban = "TR180006200119000006672315",
                IdentityNumber = "31300864726",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.UpdateAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }

        [Test]
        public async Task Should_Update_Limited_Company_Sub_Merchant()
        {
            UpdateSubMerchantRequest request = new UpdateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantKey = "sub merchant key",
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                TaxOffice = "Tax office",
                TaxNumber = "9261877",
                LegalCompanyTitle = "ABC inc",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000000",
                Name = "Jane's market",
                Iban = "TR180006200119000006672315",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.UpdateAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }

        [Test]
        public async Task Should_Retrieve_Sub_Merchant()
        {
            RetrieveSubMerchantRequest request = new RetrieveSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantExternalId = "AS49224"
            };

            SubMerchant subMerchant = await SubMerchant.RetrieveAsync(request, Options);

            PrintResponse(subMerchant);

            Assert.AreEqual(Status.SUCCESS.ToString(), subMerchant.Status);
            Assert.AreEqual(Locale.TR.ToString(), subMerchant.Locale);
            Assert.AreEqual("123456789", subMerchant.ConversationId);
            Assert.IsNotNull(subMerchant.SystemTime);
            Assert.IsNull(subMerchant.ErrorCode);
            Assert.IsNull(subMerchant.ErrorMessage);
            Assert.IsNull(subMerchant.ErrorGroup);
        }
    }
}
