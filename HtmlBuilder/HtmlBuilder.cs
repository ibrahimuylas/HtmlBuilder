using System;
using System.Text;

namespace HtmlBuilderProject
{
    public class HtmlBuilder : HtmlBuilderBase
    {

        StringBuilder HeadBuilder;
        StringBuilder BodyBuilder;
        StringBuilder StyleBuilder;

        public HtmlBuilder()
        {
            HeadBuilder = new StringBuilder();
            BodyBuilder = new StringBuilder();
            StyleBuilder = new StringBuilder(GetDefaultStyle());
        }

        public void AppendStyleToHeader(string style)
        {
            StyleBuilder.Append($" {style} ");
        }

        public void AppendToHeader(object value)
        {
            if (value != null)
                HeadBuilder.Append(value.ToString());
        }

        public void AppendH1(object value, string cssClass = "", string style = "")
        {
            BodyBuilder.Append(base.GetHtmlTag(HtmlTags.h1, value, cssClass, style));
        }

        public void AppendH2(object value, string cssClass = "", string style = "")
        {
            BodyBuilder.Append(base.GetHtmlTag(HtmlTags.h2, value, cssClass, style));
        }

        public void AppendParagraph(object value, string cssClass = "", string style = "")
        {
            BodyBuilder.Append(base.GetHtmlTag(HtmlTags.p, value, cssClass, style));
        }

        public void AppendTextWithLabelToDiv(string label, object value, string cssClass = "textWithLabelDefault", string styleDiv = "")
        {
            OpenDiv(cssClass, styleDiv);
            BodyBuilder.Append($"<label>{label}: </label>{value}");
            CloseDiv();
        }

        public void AppendTable(HtmlTableBuilder tableBuilder, bool useDefaultStyle = true)
        {
            if (useDefaultStyle)
                StyleBuilder.Append(tableBuilder.GetDefaultTableStyle());
            BodyBuilder.Append(tableBuilder.ToString());
        }

        public void OpenDiv(string cssClass = "", string style = "")
        {
            BodyBuilder.Append(base.OpenHtmlTag(HtmlTags.div, cssClass, style));
        }

        public void CloseDiv()
        {
            BodyBuilder.Append(base.CloseHtmlTag(HtmlTags.div));
        }

        private string GetDefaultStyle()
        {
            return "body form { padding: 15px; } " +
                   ".textWithLabelDefault { padding: 5px 0 5px 0; } " +
                   ".textWithLabelDefault label { font-weight: bold; } ";
        }

        private string GetHead()
        {
            return $"<head>{HeadBuilder.ToString() + GetHeaderStyle() }</head>";
        }

        private string GetHeaderStyle()
        {
            return $"<style>{StyleBuilder.ToString()}</style>";
        }

        private string GetBody()
        {
            return $"<body><form>{BodyBuilder.ToString()}</form></body>";
        }

        public override string ToString()
        {
            return $"<html>{GetHead() + GetBody() }</html>";
        }

    }
}