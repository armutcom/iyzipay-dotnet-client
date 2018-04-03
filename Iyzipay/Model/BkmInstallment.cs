using System;
using System.Collections.Generic;

namespace Armut.Iyzipay.Model
{
    public class BkmInstallment : RequestStringConvertible
    {
        public long? BankId { get; set; }
        public List<BkmInstallmentPrice> InstallmentPrices { get; set; }

        public String ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .Append("bankId", BankId)
                .AppendList("installmentPrices", InstallmentPrices)
                .GetRequestString();
        }
    }
}
