using System.Collections.Generic;
using System.Globalization;

namespace ATP.Kiosk.Common
{
    public class GetYears
    {
        public static List<ComboFill> GetYearList()
        {
            var yrStart = System.DateTime.Today.Year - 25;
            var yrCurr = System.DateTime.Today.Year + 1;

            var yrlst = new List<ComboFill>();
            for (var iYearCount = yrCurr; iYearCount > yrStart; iYearCount--)
            {
                yrlst.Add(new ComboFill { Id = iYearCount, Desc = iYearCount.ToString(CultureInfo.InvariantCulture) });
            }

            return yrlst;
        }
    }

}