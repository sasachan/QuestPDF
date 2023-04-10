using System.Linq;
using QuestPDF.Examples;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDF.ReportSample.Layouts
{
    public class TablePlaceholder : IComponent
    {
        public static bool Solid { get; set; } = false;

        public void Compose(IContainer container)
        {
            var items = Enumerable.Range(0, 5).Select(x => new OrderItem()).ToList();
            container
                        .Padding(5)
                        .MinimalBox()
                        .Border(1)
                        .DefaultTextStyle(TextStyle.Default.Size(5))
                        .Decoration(decoration =>
                        {
                            decoration
                            .Content()
                                .Dynamic(new OrdersTable(items));
                        });
        }

        // this method uses a higher order function to define a custom and dynamic style
        static IContainer Block(IContainer container)
        {
            return container
                .Border(1)
                .Background(Colors.Grey.Lighten3)
                .ShowOnce()
                .MinWidth(10)
                .MinHeight(10)
                .Padding(5)
                .AlignCenter()
                .AlignMiddle();
        }
    }
}