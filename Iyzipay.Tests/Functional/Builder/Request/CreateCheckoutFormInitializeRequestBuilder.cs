using System.Collections.Generic;
using System.Linq;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Util;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class CreateCheckoutFormInitializeRequestBuilder : BaseRequestBuilder<CreateCheckoutFormInitializeRequest>
    {
        private string _basketId = RandomGenerator.RandomId;
        private string _paymentGroup = Model.PaymentGroup.LISTING.ToString();
        private string _currency = Model.Currency.TRY.ToString();
        private Buyer _buyer = BuyerBuilder.Create().Build();
        private Address _shippingAddress = AddressBuilder.Create().Build();
        private Address _billingAddress = AddressBuilder.Create().Build();
        private List<int> _enabledInstallments = new List<int>() {2, 3, 6, 9};
        private IEnumerable<BasketItem> _basketItems;
        private string _callbackUrl;
        private int _forceThreeDs;
        private string _cardUserKey;
        private string _posOrderId;
        private string _paymentSource;
        private string _price;
        private string _paidPrice;

        private CreateCheckoutFormInitializeRequestBuilder()
        {
        }

        public static CreateCheckoutFormInitializeRequestBuilder Create()
        {
            return new CreateCheckoutFormInitializeRequestBuilder();
        }

        public CreateCheckoutFormInitializeRequestBuilder Price(string price)
        {
            _price = price;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder PaidPrice(string paidPrice)
        {
            _paidPrice = paidPrice;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder BasketId(string basketId)
        {
            _basketId = basketId;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder PaymentGroup(string paymentGroup)
        {
            _paymentGroup = paymentGroup;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder PaymentSource(string paymentSource)
        {
            _paymentSource = paymentSource;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder Currency(string currency)
        {
            _currency = currency;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder Buyer(Buyer buyer)
        {
            _buyer = buyer;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder ShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder BillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder BasketItems(IEnumerable<BasketItem> basketItems)
        {
            _basketItems = basketItems;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder CallbackUrl(string callbackUrl)
        {
            _callbackUrl = callbackUrl;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder ForceThreeDs(int forceThreeDs)
        {
            _forceThreeDs = forceThreeDs;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder CardUserKey(string cardUserKey)
        {
            _cardUserKey = cardUserKey;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder PosOrderId(string posOrderId)
        {
            _posOrderId = posOrderId;
            return this;
        }

        public CreateCheckoutFormInitializeRequestBuilder EnabledInstallments(List<int> enabledInstallments)
        {
            _enabledInstallments = enabledInstallments;
            return this;
        }

        public override CreateCheckoutFormInitializeRequest Build()
        {
            CreateCheckoutFormInitializeRequest createCheckoutFormInitializeRequest =
                new CreateCheckoutFormInitializeRequest
                {
                    Locale = Locale,
                    ConversationId = ConversationId,
                    Price = _price,
                    PaidPrice = _paidPrice,
                    BasketId = _basketId,
                    PaymentGroup = _paymentGroup,
                    PaymentSource = _paymentSource,
                    Currency = _currency,
                    Buyer = _buyer,
                    ShippingAddress = _shippingAddress,
                    BillingAddress = _billingAddress,
                    BasketItems = _basketItems.ToList(),
                    CallbackUrl = _callbackUrl,
                    ForceThreeDS = _forceThreeDs,
                    CardUserKey = _cardUserKey,
                    PosOrderId = _posOrderId,
                    EnabledInstallments = _enabledInstallments
                };
            return createCheckoutFormInitializeRequest;
        }
    }
}
