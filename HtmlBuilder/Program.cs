using System;
using System.Net.Http;
using System.Threading;
using System.Text;

namespace HtmlBuilderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlBuilder htmlBuilder = new HtmlBuilder();
            htmlBuilder.AppendStyleToHeader("table, th, td {border: 1px solid black;border-collapse: collapse;}");
            htmlBuilder.AppendStyleToHeader(".testStyle { color: blue; }");
            //htmlBuilder.AppendToHeader(headerStyle);
            htmlBuilder.AppendH1("ibrahim uylaş");

            htmlBuilder.OpenDiv();
            htmlBuilder.AppendParagraph("Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, similique provident? Tempora numquam maxime labore? Et vero, repellendus laboriosam in possimus sit necessitatibus aut, debitis, error ab quos corporis deserunt.    ");
            htmlBuilder.CloseDiv();

            HtmlTableBuilder tableBuilder = new HtmlTableBuilder(2, "border:1px solid;");

            tableBuilder.OpenRow();
            tableBuilder.AppentTh("Name");
            tableBuilder.AppentTh("Surname");
            tableBuilder.CloseRow();

            tableBuilder.OpenRow();
            tableBuilder.AppentTd("Muhammet");
            tableBuilder.AppentTd("Uylas");
            tableBuilder.CloseRow();

            tableBuilder.OpenRow();
            tableBuilder.AppentTd("Simge");
            tableBuilder.AppentTd("Sezgin");
            tableBuilder.CloseRow();

            tableBuilder.OpenRow();
            tableBuilder.AppentTd("Hüsnü");
            tableBuilder.AppentTd("Şen");
            tableBuilder.CloseRow();

            tableBuilder.OpenRow();
            tableBuilder.AppentTd("Muhammet İbrahim Uylaş", 2);
            tableBuilder.CloseRow();

            htmlBuilder.AppendTable(tableBuilder);
            htmlBuilder.AppendTextWithLabelToDiv("Author", "Johnn Wick");
            htmlBuilder.AppendH2("Mark Hernandes", "testStyle");

            string result = htmlBuilder.ToString();

            Console.ReadLine();
        }

    }

}

