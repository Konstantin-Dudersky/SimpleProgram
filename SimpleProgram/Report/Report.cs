using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf;

namespace SimpleProgram.Report
{
    public class Report
    {
        public Func<DateTime, DateTime, Task<string>> BodyAsync;
        public Func<DateTime, DateTime, string> Body;

        public async void BuildHtml(DateTime begin, DateTime end)
        {
            var html = new StringBuilder();
            html.AppendLine(
            @"
            <html>
                <head>
                    <link href='C:\Users\Konstantin\RiderProjects\publish\wwwroot\lib\foundation-sites\css/app.css' rel='stylesheet'/>
                </head>
                <body>
            "
            );
            
            
            var body = "";
            if (Body != null)
            {
                body = Body(begin, end);
            }
            else if (BodyAsync != null)
            {
                body = await BodyAsync(begin, end);
            }

            html.AppendLine(body);

            html.AppendLine(@"
                </body>
                </html>
            ");

            var stream = new FileStream("test.pdf", FileMode.Create);
//            Console.WriteLine(html.ToString());
            HtmlConverter.ConvertToPdf(html.ToString(), stream);
        }
    }
}