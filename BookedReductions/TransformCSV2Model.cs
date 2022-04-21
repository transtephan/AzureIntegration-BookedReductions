using AzureIntegration_BookedReductions.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureIntegration_BookedReductions.Extensions;
using AzureIntegration_BookedReductions.Constants;

namespace AzureIntegration_BookedReductions
{
    public static class TransformCSV2Model
    {
        public static BookedReductionsModel ConvertCSVStrToModel(string items, ILogger log)
        {
            List<string> result = items.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            BookedReductionsModel model = new BookedReductionsModel();
            model.version = BookedReductionKLConstants.version;
            foreach (var item in result)
            {
                var RecordType = item.Split(';')[0];
                switch (RecordType)
                {
                    case "HEA":
                        model = GetHEAObj(item, model);
                        break;
                    case "HEA2":
                        model = GetHEA2Obj(item, model);
                        break;
                    case "H":
                        model = GetHObj(item, model);
                        break;
                    case "D":
                        model = GetDObj(item, model);
                        break;
                }
            }
            return model;
        }
        private static BookedReductionsModel GetHEAObj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            model.VMSHeader = new VMSHeader(

                strArr[0], 
                strArr[1], 
                TryParseExtension.TryParseInt32(strArr[2], BookedReductionKLConstants.intDefault), 
                strArr[3], 
                TryParseExtension.TryParseInt32(strArr[4], BookedReductionKLConstants.intDefault), 
                strArr[5],
                TryParseExtension.TryParseInt32(strArr[6], BookedReductionKLConstants.intDefault), 
                strArr[7],
                strArr[8], 
                strArr[9]);
                
            return model;
                
        }
        private static BookedReductionsModel GetHEA2Obj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            model.Header2 = new Header2(
                strArr[0], 
                strArr[1]);

            return model;
        }

        private static BookedReductionsModel GetHObj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            if(model.H2 == null)
                model.H2 = new H2();

            if (model.H2.ReductionHeader == null)
                model.H2.ReductionHeader = new List<ReductionHeader>();

            var info = new ReductionHeader(
                strArr[0], 
                strArr[1], 
                strArr[2], 
                strArr[3], 
                strArr[4], 
                strArr[5],
                strArr[6], 
                strArr[7], 
                strArr[8], 
                strArr[9]);

            model.H2.ReductionHeader.Add(info);
            return model;
        }
        
        private static BookedReductionsModel GetDObj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            if (model.H2 == null)
                model.H2 = new H2();

            if (model.H2.Details == null)
                model.H2.Details = new List<Details>();
            var info = new Details(
                strArr[0],
                strArr[1],
                strArr[2],
                strArr[3],
                strArr[4],
                strArr[5],
                TryParseExtension.TryParseInt32(strArr[6], BookedReductionKLConstants.intDefault),
                strArr[7],
                strArr[8],
                strArr[9],
                strArr[10],
                strArr[11],
                strArr[12],
                strArr[13],
                TryParseExtension.TryParseInt32(strArr[14], BookedReductionKLConstants.intDefault),
                strArr[15],
                strArr[16],
                strArr[17],
                strArr[18]);

            model.H2.Details.Add(info);
            return model;
        }
    }
}
