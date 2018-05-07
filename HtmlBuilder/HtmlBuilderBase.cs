using System;
namespace HtmlBuilderProject
{
    public enum HtmlTags
    {
        h1,
        h2,
        p,
        div,
        table,
        tr,
        th,
        td
    }

    public class HtmlBuilderBase
    {
        public string GetClassNameAttribute(string cssClass)
        {
            return string.IsNullOrEmpty(cssClass) ? cssClass : $" class='{cssClass}'";
        }

        public string GetStyleAttribute(string style)
        {
            return string.IsNullOrEmpty(style) ? style : $" style='{style}'";
        }

        public string GetHtmlTag(HtmlTags tag, object value, string cssClass, string style, string otherAttributes = "")
        {
            return $"<{tag.ToString()} {GetClassNameAttribute(cssClass)} {GetStyleAttribute(style)} {otherAttributes}>{value}</{tag.ToString()}>";
        }

        public string OpenHtmlTag(HtmlTags tag, string cssClass, string style)
        {
            return $"<{tag.ToString()} {GetClassNameAttribute(cssClass)} {GetStyleAttribute(style)}>";
        }

        public string CloseHtmlTag(HtmlTags tag)
        {
            return $"</{tag.ToString()}>";
        }
    }
}
