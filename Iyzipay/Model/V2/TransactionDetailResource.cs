using System.Collections.Generic;

namespace Armut.Iyzipay.Model.V2
{
    public class TransactionDetailResource : IyzipayResourceV2
    {
        public List<TransactionDetailItem> Tranactions { get; set; }
    }
}
