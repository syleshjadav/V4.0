using ATP.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ATP.Services.Data
{
    public class LookUp
    {

        public List<uspLkpTables_Result> SelLookUpTable(string Token, string tableName)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                //  return entity.uspLkpTables(tableName).ToList();
                return null;
            }

        }

        public List<uspSelLookUpTableByDealerId_Result> SelLookUpTableByDealerId(string tableName, int? dealerId)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspSelLookUpTableByDealerId(tableName, dealerId).ToList();
            }

        }
    }
}
