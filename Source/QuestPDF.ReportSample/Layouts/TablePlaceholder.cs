using System.Globalization;
using System.Linq;
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
            container
                        .Padding(5)
                        .MinimalBox()
                        .Border(1)
                        .DefaultTextStyle(TextStyle.Default.Size(5))
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().Row(1).Column(1).Element(Block).Text("A");
                            table.Cell().Row(2).Column(2).Element(Block).Text("B");
                            table.Cell().Row(1).Column(3).Element(Block).Text("C");
                            table.Cell().Row(2).Column(4).Element(Block).Text("D");
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