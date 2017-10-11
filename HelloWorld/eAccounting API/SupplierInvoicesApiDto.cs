using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.eAccounting_API
{
    public class SupplierInvoicesApiDto
    {
        public Meta Meta { get; set; }
        public List<SupplierInvoiceApi> SupplierInvoices { get; set; }
    }

    public class Meta
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfResults { get; set; }
        public string ServerTimeUtc { get; set; }
    }

    public class SupplierInvoiceApi
    {
        public string Id { get; set; }
        public string SupplierId { get; set; }
        public string BankAccountId { get; set; }
        public string InvoiceDate { get; set; }
        public string PaymentDate { get; set; }
        public string DueDate { get; set; }
        public string InvoiceNumber { get; set; }
        public double TotalAmount { get; set; }
        public double Vat { get; set; }
        public double VatHigh { get; set; }
        public double VatMedium { get; set; }
        public double VatLow { get; set; }
        public bool IsCreditInvoice { get; set; }
        public string CurrencyCode { get; set; }
        public double CurrencyRate { get; set; }
        public string OcrNumber { get; set; }
        public string Message { get; set; }
        public string PlusGiroNumber { get; set; }
        public string BankGiroNumber { get; set; }
        public List<SupplierInvoiceApi> Rows { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNumber { get; set; }
        public double RemainingAmount { get; set; }
        public double RemainingAmountInvoiceCurrency { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherId { get; set; }
        public string CreatedFromDraftId { get; set; }
        public bool SelfEmployedWithoutFixedAddress { get; set; }
        public List<string> Attachments { get; set; }
    }

    public class SupplierInvoiceRowApi
    {
        public string Id { get; set; }
        public int AccountNumber { get; set; }
        public string VadCodeId { get; set; }
        public string CostCenterItemId1 { get; set; }
        public string CostCenterItemId2 { get; set; }
        public string CostCenterItemId3 { get; set; }
        public double Quantity { get; set; }
        public double Weight { get; set; }
        public string DeliveryDate { get; set; }
        public int HarvestYear { get; set; }
        public double DebetAmount { get; set; }
        public double CreditAmount { get; set; }
        public int LineNumber { get; set; }
        public string ProjectId { get; set; }
        public string TransactionText { get; set; }
    }
}
