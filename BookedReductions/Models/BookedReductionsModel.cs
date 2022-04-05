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
        public Vmsheader VMSHeader { get; set; }
        [Required]
        public Header2 Header2 { get; set; }
    }
    public class Vmsheader
    {
        public string type { get; set; }
        public string[] required { get; set; }
        public Properties1 properties { get; set; }
    }

    public class Properties1
    {
        public Recordtype RecordType { get; set; }
        public Integrationobjectname IntegrationObjectName { get; set; }
        public Fileversion FileVersion { get; set; }
        public Vmsinstancecode VMSInstanceCode { get; set; }
        public Planningmarketcode PlanningMarketCode { get; set; }
        public Maincompanycode MainCompanyCode { get; set; }
        public Sequencenumber SequenceNumber { get; set; }
        public Vmstransactionid VMSTransactionID { get; set; }
        public Transactiondate TransactionDate { get; set; }
        public Transactiontime TransactionTime { get; set; }
    }

    public class Recordtype
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Integrationobjectname
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Fileversion
    {
        public string type { get; set; }
    }

    public class Vmsinstancecode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Planningmarketcode
    {
        public string type { get; set; }
    }

    public class Maincompanycode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Sequencenumber
    {
        public string type { get; set; }
    }

    public class Vmstransactionid
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Transactiondate
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Transactiontime
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Header2
    {
        public string type { get; set; }
        public string[] required { get; set; }
        public Properties2 properties { get; set; }
    }

    public class Properties2
    {
        public Reductionheader ReductionHeader { get; set; }
        public Details Details { get; set; }
    }

    public class Reductionheader
    {
        public string type { get; set; }
        public string[] required { get; set; }
        public Properties3 properties { get; set; }
    }

    public class Properties3
    {
        public Recordtype1 RecordType { get; set; }
        public Borenumber BoreNumber { get; set; }
        public Modulecode ModuleCode { get; set; }
        public Location Location { get; set; }
        public Fiscalcompany FiscalCompany { get; set; }
        public Fiscalcurrency FiscalCurrency { get; set; }
        public EOP EOP { get; set; }
        public Bookedreductioncreationdate BookedReductionCreationDate { get; set; }
        public Bookedreductionsentdate BookedReductionSentDate { get; set; }
        public Orgmodulecode OrgModuleCode { get; set; }
    }

    public class Recordtype1
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Borenumber
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Modulecode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Location
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Fiscalcompany
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Fiscalcurrency
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class EOP
    {
        public string type { get; set; }
    }

    public class Bookedreductioncreationdate
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Bookedreductionsentdate
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Orgmodulecode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Details
    {
        public string type { get; set; }
        public string[] required { get; set; }
        public Properties4 properties { get; set; }
    }

    public class Properties4
    {
        public Recordtype2 RecordType { get; set; }
        public Ordernumber OrderNumber { get; set; }
        public Season Season { get; set; }
        public Seasonyear SeasonYear { get; set; }
        public Department Department { get; set; }
        public Index Index { get; set; }
        public Colourid ColourId { get; set; }
        public Reducedpieces ReducedPieces { get; set; }
        public Newpriceinfiscalcurrency NewPriceInFiscalCurrency { get; set; }
        public Oldpriceinfiscalcurrency OldPriceInFiscalCurrency { get; set; }
        public Totalpriceinfiscalcurrency TotalPriceInFiscalCurrency { get; set; }
        public Noteposition NotePosition { get; set; }
        public Ibmsizecode IBMSizeCode { get; set; }
        public Sizescalecode SizeScaleCode { get; set; }
        public Sdssizecode SDSSizeCode { get; set; }
        public Corporatebrandid CorporateBrandId { get; set; }
        public Productid ProductId { get; set; }
        public Articleid ArticleId { get; set; }
        public Pricetagproductnumber PriceTagProductNumber { get; set; }
        public Pricetagarticlenumber PriceTagArticleNumber { get; set; }
    }

    public class Recordtype2
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Ordernumber
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Season
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Seasonyear
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Department
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Index
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Colourid
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Reducedpieces
    {
        public string type { get; set; }
    }

    public class Newpriceinfiscalcurrency
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Oldpriceinfiscalcurrency
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Totalpriceinfiscalcurrency
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Noteposition
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Ibmsizecode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Sizescalecode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Sdssizecode
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Corporatebrandid
    {
        public string type { get; set; }
    }

    public class Productid
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Articleid
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Pricetagproductnumber
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

    public class Pricetagarticlenumber
    {
        public string type { get; set; }
        public string pattern { get; set; }
    }

}
