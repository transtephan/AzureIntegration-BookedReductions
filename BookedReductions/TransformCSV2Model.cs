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


                    

                        


                }
            }
        }
        private static BookedReductionsModel GetHEAObj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            model.VMSHeader = new VMSHeader(

                strArr[0], strArr[1], TryParseExtension.TryParseInt32(strArr[2], BookedReductionKLConstants.intDefault), 
                strArr[3], TryParseExtension.TryParseInt32(strArr[4], BookedReductionKLConstants.intDefault), strArr[5],
                TryParseExtension.TryParseInt32(strArr[6], BookedReductionKLConstants.intDefault), strArr[7],
                strArr[8], strArr[9]);
                
            return model;
                
        }
        private static BookedReductionsModel GetHEA2Obj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            if (model.Header2 == null)
            {
                model.Header2 = new Header2();
            }
            model.Header2.H2 = new H2(strArr[0], strArr[1]);
            return model;
        }
        private static BookedReductionsModel GetHObj(string item, BookedReductionsModel model)
        {
            string[] strArr = item.Split(';');
            if (model.Header2 == null)
            {
                model.Header2 = new Header2();
            }
            if (model.Header2.ReductionHeader == null)
            {
                model.Header2.ReductionHeader = new List<Reductionheader>();
            }

        }

    }
}
