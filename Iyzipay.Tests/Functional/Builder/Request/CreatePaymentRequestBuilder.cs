using System.Collections.Generic;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class CreatePaymentRequestBuilder : BaseRequestBuilder<CreatePaymentRequest>
    {
        private string _price = "1";
        private string _paidPrice = "1.1";
        private int _installment = 1;
        private string _paymentChannel = Model.PaymentChannel.WEB.ToString();
        private string _basketId = "B67832";
        private string _paymentGroup;
        private Buyer _buyer = BuyerBuilder.Create().Build();
        private Address _shippingAddress = AddressBuilder.Create().Build();
        private Address _billingAddress = AddressBuilder.Create().Build();
        private List<BasketItem> _basketItems;
        private string _currency = Model.Currency.TRY.ToString();
        private PaymentCard _paymentCard = PaymentCardBuilder.Create().BuildWithCardCredentials().Build();
        private string _paymentSource;
        private string _callbackUrl;
        private string _posOrderId;
        private string _connectorName;

        private CreatePaymentRequestBuilder()
        {
        }

        public static CreatePaymentRequestBuilder Create()
        {
            return new CreatePaymentRequestBuilder();
        }

        public new CreatePaymentRequestBuilder Locale(string locale)
        {
            base.Locale = locale;
            return this;
        }

        public new CreatePaymentRequestBuilder ConversationId(string conversationId)
        {
            base.ConversationId = conversationId;
            return this;
        }

        public CreatePaymentRequestBuilder Price(string price)
        {
            _price = price;
            return this;
        }

        public CreatePaymentRequestBuilder PaidPrice(string paidPrice)
        {
            _paidPrice = paidPrice;
            return this;
        }

        public CreatePaymentRequestBuilder Installment(int installment)
        {
            _installment = installment;
            return this;
        }

        public CreatePaymentRequestBuilder PaymentChannel(string paymentChannel)
        {
            _paymentChannel = paymentChannel;
            return this;
        }

        public CreatePaymentRequestBuilder BasketId(string basketId)
        {
            _basketId = basketId;
            return this;
        }

        public CreatePaymentRequestBuilder PaymentGroup(string paymentGroup)
        {
            _paymentGroup = paymentGroup;
            return this;
        }

        public CreatePaymentRequestBuilder PaymentCard(PaymentCard paymentCard)
        {
            _paymentCard = paymentCard;
            return this;
        }

        public CreatePaymentRequestBuilder Buyer(Buyer buyer)
        {
            _buyer = buyer;
            return this;
        }

        public CreatePaymentRequestBuilder ShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public CreatePaymentRequestBuilder BillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public CreatePaymentRequestBuilder BasketItems(List<BasketItem> basketItems)
        {
            _basketItems = basketItems;
            return this;
        }

        public CreatePaymentRequestBuilder PaymentSource(string paymentSource)
        {
            _paymentSource = paymentSource;
            return this;
        }

        public CreatePaymentRequestBuilder CallbackUrl(string callbackUrl)
        {
            _callbackUrl = callbackUrl;
            return this;
        }

        public CreatePaymentRequestBuilder PosOrderId(string posOrderId)
        {
            _posOrderId = posOrderId;
            return this;
        }

        public CreatePaymentRequestBuilder ConnectorName(string connectorName)
        {
            _connectorName = connectorName;
            return this;
        }

        public CreatePaymentRequestBuilder Currency(string currency)
        {
            _currency = currency;
            return this;
        }

        public override CreatePaymentRequest Build()
        {
            CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest
            {
                Locale = base.Locale,
                ConversationId = base.ConversationId,
                Price = _price,
                PaidPrice = _paidPrice,
                Installment = _installment,
                PaymentChannel = _paymentChannel,
                BasketId = _basketId,
                PaymentGroup = _paymentGroup,
                PaymentCard = _paymentCard,
                Buyer = _buyer,
                ShippingAddress = _shippingAddress,
                BillingAddress = _billingAddress,
                BasketItems = _basketItems,
                PaymentSource = _paymentSource,
                CallbackUrl = _callbackUrl,
                PosOrderId = _posOrderId,
                ConnectorName = _connectorName,
                Currency = _currency
            };
            return createPaymentRequest;
        }

        public CreatePaymentRequestBuilder MarketplacePayment(string subMerchantKey)
        {
            _basketItems = BasketItemBuilder.Create().BuildBasketItemsWithSubMerchantKey(subMerchantKey);
            _paymentGroup = Model.PaymentGroup.PRODUCT.ToString();
            return this;
        }

        public CreatePaymentRequestBuilder MarketplacePaymentWithSamePrice(string subMerchantKey)
        {
            _basketItems = BasketItemBuilder.Create().BuildBasketItemsWithSubmetchantKeyAndSamePrice(subMerchantKey);
            _paymentGroup = Model.PaymentGroup.PRODUCT.ToString();
            return this;
        }

        public CreatePaymentRequestBuilder MarketplacePayment(string subMerchantKey, string price, string subMerchantPrice)
        {
            _basketItems = BasketItemBuilder.Create().BuildBasketItem(subMerchantKey, price, subMerchantPrice);
            _paymentGroup = Model.PaymentGroup.PRODUCT.ToString();
            return this;
        }

        public CreatePaymentRequestBuilder StandardListingPayment()
        {
            _basketItems = BasketItemBuilder.Create().BuildDefaultBasketItems();
            _paymentGroup = Model.PaymentGroup.LISTING.ToString();
            return this;
        }
    }
}
