using System.Collections.Generic;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Util;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class CreateBkmInitializeRequestBuilder : BaseRequestBuilder<CreateBkmInitializeRequest>
    {
        private string _basketId = RandomGenerator.RandomId;
        private string _paymentGroup = Model.PaymentGroup.LISTING.ToString();
        private Buyer _buyer = BuyerBuilder.Create().Build();
        private Address _shippingAddress = AddressBuilder.Create().Build();
        private Address _billingAddress = AddressBuilder.Create().Build();
        private List<BasketItem> _basketItems = BasketItemBuilder.Create().BuildDefaultBasketItems();
        private string _callbackUrl;
        private string _paymentSource;
        private string _price;

        private CreateBkmInitializeRequestBuilder()
        {
        }

        public static CreateBkmInitializeRequestBuilder Create()
        {
            return new CreateBkmInitializeRequestBuilder();
        }

        public CreateBkmInitializeRequestBuilder Price(string price)
        {
            _price = price;
            return this;
        }

        public CreateBkmInitializeRequestBuilder BasketId(string basketId)
        {
            _basketId = basketId;
            return this;
        }

        public CreateBkmInitializeRequestBuilder PaymentGroup(string paymentGroup)
        {
            _paymentGroup = paymentGroup;
            return this;
        }

        public CreateBkmInitializeRequestBuilder PaymentSource(string paymentSource)
        {
            _paymentSource = paymentSource;
            return this;
        }

        public CreateBkmInitializeRequestBuilder Buyer(Buyer buyer)
        {
            _buyer = buyer;
            return this;
        }

        public CreateBkmInitializeRequestBuilder ShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public CreateBkmInitializeRequestBuilder BillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public CreateBkmInitializeRequestBuilder BasketItems(List<BasketItem> basketItems)
        {
            _basketItems = basketItems;
            return this;
        }

        public CreateBkmInitializeRequestBuilder CallbackUrl(string callbackUrl)
        {
            _callbackUrl = callbackUrl;
            return this;
        }

        public override CreateBkmInitializeRequest Build()
        {
            CreateBkmInitializeRequest createBkmInitializeRequest = new CreateBkmInitializeRequest
            {
                Locale = Locale,
                ConversationId = ConversationId,
                Price = _price,
                BasketId = _basketId,
                PaymentGroup = _paymentGroup,
                PaymentSource = _paymentSource,
                Buyer = _buyer,
                ShippingAddress = _shippingAddress,
                BillingAddress = _billingAddress,
                BasketItems = _basketItems,
                CallbackUrl = _callbackUrl
            };
            return createBkmInitializeRequest;
        }
    }
}
