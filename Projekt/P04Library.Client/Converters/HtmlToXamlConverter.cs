using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace P04Library.Client.Converters
{
    public class HtmlToXamlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string htmlText = value as string;
            if (!string.IsNullOrEmpty(htmlText))
            {
                var flowDocument = new FlowDocument();
                var paragraph = new Paragraph();
                var inline = (Inline) XamlReader.Parse("<Span xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" + htmlText + "</Span>");
                paragraph.Inlines.Add(inline);
                flowDocument.Blocks.Add(paragraph);
                return flowDocument;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
