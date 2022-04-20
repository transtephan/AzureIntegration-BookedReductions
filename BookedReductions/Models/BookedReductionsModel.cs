using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureIntegration_BookedReductions.Models
{

    public class BookedReductionsModel
    {
        [Required]
        public string version { get; set; }
        [Required]
        public VMSHeader VMSHeader { get; set; }
        [Required]
        public Header2 Header2 { get; set; }
        [Required]
        public H2 H2 { get; set; }
       
    }


    public class VMSHeader
    {
        public VMSHeader(
            string _recordType,
            string _integrationObjectName,
            int _fileVersion,
            string _vmsInstanceCode,
            int _planningMarketCode,
            string _mainCompanyCode,
            int _sequenceNumber,
            string _vmsTransactionId,
            string _transactionDate,
            string _transactionTime)
        {
            RecordType = _recordType;
            IntegrationObjectName = _integrationObjectName;
            FileVersion = _fileVersion;
            VMSInstanceCode = _vmsInstanceCode;
            PlanningMarketCode = _planningMarketCode;
            MainCompanyCode = _mainCompanyCode;
            SequenceNumber = _sequenceNumber;
            VMSTransactionId = _vmsTransactionId;
            TransactionDate = _transactionDate;
            TransactionTime = _transactionTime;
        }
        [Required]
        public string RecordType { get; set; }
        [Required]
        public string IntegrationObjectName { get; set; }
        [Required]
        public int FileVersion { get; set; }
        [Required]
        public string VMSInstanceCode { get; set; }
        [Required]
        public int PlanningMarketCode { get; set; }
        [Required]
        public string MainCompanyCode { get; set; }
        [Required]
        public int SequenceNumber { get; set; }
        [Required]
        public string VMSTransactionId { get; set; }
        [Required]
        public string TransactionDate { get; set; }
        [Required]
        public string TransactionTime { get; set; }
    }
    public class Header2
    {
        public Header2(
            string _recordType,
            string _pmCurrencyCode)
        {
            RecordType = _recordType;
            PMCurrencyCode = _pmCurrencyCode;
        }
        [Required]
        public string RecordType { get; set; }
        [Required]
        public string PMCurrencyCode { get; set; }
    };

    public class H2
    {
        public List<ReductionHeader> ReductionHeader { get; set; }
        public List<Details> Details { get; set; }
    }
    public class ReductionHeader
    {
        public ReductionHeader(
            string _recordType,
            string _boreNumber,
            string _moduleCode,
            string _location,
            string _fiscalComapny,
            string _fiscalCurrency,
            string _eop,
            string _bookedReductionCreationDate,
            string _bookedReductionSentDate,
            string _orgModuleCode
            )
        {
            RecordType = _recordType;
            BoreNumber = _boreNumber;
            ModuleCode = _moduleCode;
            Location = _location;
            FiscalCompany = _fiscalComapny;
            FiscalCurrency = _fiscalCurrency;
            EOP = _eop;
            BookedReductionCreationDate = _bookedReductionCreationDate;
            BookedReductionSentDate = _bookedReductionSentDate;
            OrgModuleCode = _orgModuleCode;
        }
        [Required]
        public string RecordType { get; set; }
        [Required]
        public string BoreNumber { get; set; }
        [Required]
        public string ModuleCode { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string FiscalCompany { get; set; }
        [Required]
        public string FiscalCurrency { get; set; }
        [Required]
        public string EOP { get; set; }
        [Required]
        public string BookedReductionCreationDate { get; set; }
        [Required]
        public string BookedReductionSentDate { get; set; }
        [Required]
        public string OrgModuleCode { get; set; }
    }

    public class Details
    {
        public Details(
            string _recordType,
            string _orderNumber,
            string _season,
            string _department,
            string _index,
            string _colourId,
            int _reducedPieces,
            string _newPriceInFiscalCurrency,
            string _oldPriceInFiscalCurrency,
            string _totalPriceInFiscalCurrency,
            string _notePosition,
            string _ibmSizeCode,
            string _sizeScaleCode,
            string _sdsSizeCode,
            int _corporateBrandId,
            string _productId,
            string _articleId,
            string _priceTagProductNumber,
            string _priceTagArticleNumber
            )
        {
            RecordType = _recordType;
            OrderNumber = _orderNumber;
            Season = _season;
            Department = _department;
            Index = _index;
            ColourId = _colourId;
            ReducedPieces = _reducedPieces;
            NewPriceInFiscalCurrency = _newPriceInFiscalCurrency;
            OldPriceInFiscalCurrency = _oldPriceInFiscalCurrency;
            TotalPriceInFiscalCurrency = _totalPriceInFiscalCurrency;
            NotePosition = _notePosition;
            IBMSizeCode = _ibmSizeCode;
            SizeScaleCode = _sizeScaleCode;
            SDSSizeCode = _sdsSizeCode;
            CorporateBrandId = _corporateBrandId;
            ProductId = _productId;
            ArticleId = _articleId;
            PriceTagProductNumber = _priceTagProductNumber;
            PriceTagArticleNumber = _priceTagArticleNumber;
        }
        [Required]
        public string RecordType { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public string Season { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Index { get; set; }
        [Required]
        public string ColourId { get; set; }
        [Required]
        public int ReducedPieces { get; set; }
        [Required]
        public string NewPriceInFiscalCurrency { get; set; }
        [Required]
        public string OldPriceInFiscalCurrency { get; set; }
        [Required]
        public string TotalPriceInFiscalCurrency { get; set; }
        [Required]
        public string NotePosition { get; set; }
        [Required]
        public string IBMSizeCode { get; set; }
        [Required]
        public string SizeScaleCode { get; set; }
        [Required]
        public string SDSSizeCode { get; set; }
        [Required]
        public int CorporateBrandId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public string ArticleId { get; set; }
        [Required]
        public string PriceTagProductNumber { get; set; }
        [Required]
        public string PriceTagArticleNumber { get; set; }
    }
}

    

