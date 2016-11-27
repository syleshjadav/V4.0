using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP.Kiosk.Common
{
   public static class HtmlHelpers
    {
        #region "Html Helpers"
        public static string CreateTable(string s)
        {
            return string.Format("<table border='1'>{0}</table>", s);
        }

        public static string CreateTable(string s, string sclass)
        {
            return string.Format("<table class='{0}'>{1}</table>", sclass, s);
        }

        public static string CreateTable(string s, string sclass, string sStyle)
        {
            return string.Format("<table class='{0}' style='{2}' >{1}</table>", sclass, s, sStyle);
        }

        public static string CreateRow(string s)
        {
            return string.Format("<tr>{0}</tr>", s);
        }

        public static string CreateCell(string s)
        {
            return string.Format("<td>{0}</td>", s);
        }

        public static string CreateCell(string s, string sstyle)
        {
            return string.Format("<td style='{0}'>{1}</td>", sstyle, s);
        }

        public static string CreateCell(string s, string sstyle, string sProp)
        {
            return string.Format("<td {2} style='{0}'>{1}</td>", sstyle, s, sProp);
        }

        public static string CreateTableHeader(string s)
        {
            return string.Format("<th>{0}</th>", s);
        }

        public static string CreateTableHeader(string s, string sProp)
        {
            return string.Format("<th {1} >{0}</th>", s, sProp);
        }
        #endregion
    }
}
