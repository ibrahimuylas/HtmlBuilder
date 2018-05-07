using System;
using System.Text;

namespace HtmlBuilderProject
{
    public class HtmlTableBuilder : HtmlBuilderBase
    {
        StringBuilder TableBuilder;
        private int ColumnNumber = 0;

        public HtmlTableBuilder(int colNum, string cssClass = "", string tableStyle = "")
        {
            ColumnNumber = colNum;
            TableBuilder = new StringBuilder(base.OpenHtmlTag(HtmlTags.table, cssClass, tableStyle));
        }

        public void OpenRow(string cssClass = "", string style = "")
        {
            TableBuilder.Append(base.OpenHtmlTag(HtmlTags.tr, cssClass, style));
        }

        public void CloseRow()
        {
            TableBuilder.Append(base.CloseHtmlTag(HtmlTags.tr));
        }

        public void AppentTd(object value, int colSpan = 0, string cssClass = "", string style = "")
        {
            string spanAtt = colSpan == 0 ? string.Empty : $"colspan={colSpan}";
            TableBuilder.Append(base.GetHtmlTag(HtmlTags.td, value, cssClass, style, spanAtt));
        }

        public void AppentTh(object value, int colSpan = 0, string cssClass = "", string style = "")
        {
            string spanAtt = colSpan == 0 ? string.Empty : $"colSpan=";
            TableBuilder.Append(base.GetHtmlTag(HtmlTags.th, value, cssClass, style, spanAtt));
        }

        public override string ToString()
        {
            return $"{TableBuilder.ToString()} {base.CloseHtmlTag(HtmlTags.table)}";
        }

        internal string GetDefaultTableStyle()
        {
            return "table, th, td { border: 1px solid black; padding:5px; }";
        }
    }
}
