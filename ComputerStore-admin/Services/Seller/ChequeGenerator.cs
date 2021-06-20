using ComputerStoreAdmin.Models.Seller;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace ComputerStoreAdmin.Services.Seller
{
    public static class ChequeGenerator
    {
        private const double DefaultDisplayce = 25;
        private const double DefaultSize = 20;
        private const double xDisplace = 20;
        private const double EndOfPage = 60;

        public static void CreateCheque(Cheque cheque)
        {
            double yDisplace = DefaultDisplayce;
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Times New Roman", 20, XFontStyle.Bold);

            gfx.AddText("ЗАКАЗ № " + cheque.ChequeID, xDisplace, yDisplace, DefaultSize, xDisplace, XStringFormats.TopRight, headerFont);
            yDisplace += 25;
            gfx.AddText("Комплектация \"" + cheque.Complectation + "\"", xDisplace, yDisplace, font: headerFont);
            yDisplace += 25;
            gfx.AddText("Дата заказа: " + cheque.Date.ToLongDateString() + " " + cheque.Date.ToLongTimeString(), xDisplace, yDisplace);
            yDisplace += 25;
            gfx.DrawLine(XPens.Black, new XPoint(0, yDisplace), new XPoint(page.Width, yDisplace));
            yDisplace += 25;
            gfx.AddText("Детали", xDisplace, yDisplace, font: headerFont);
            yDisplace += 25;


            foreach (var curItem in cheque.ItemList())
            {
                yDisplace += 25;
                if (yDisplace >= page.Height - EndOfPage) {
                    yDisplace = 20;
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                }
                gfx.AddText(curItem.ID.ToString(), xDisplace, yDisplace);
                gfx.AddText(curItem.Name, xDisplace + 40, yDisplace);
            }

            yDisplace += 2 * DefaultDisplayce;
            if (yDisplace >= page.Height - EndOfPage) {
                yDisplace = DefaultDisplayce;
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
            }
            else
                gfx.DrawLine(XPens.Black, new XPoint(0, yDisplace), new XPoint(page.Width, yDisplace));
            
            yDisplace += DefaultDisplayce;
            if (yDisplace >= page.Height - EndOfPage) {
                yDisplace = 20;
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
            }

            gfx.AddText("Услуги", xDisplace, yDisplace, font: headerFont);
            yDisplace += DefaultDisplayce;

            if (yDisplace >= page.Height - EndOfPage) {
                yDisplace = 20;
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
            }

            foreach (string curAddition in cheque.ServicesList)
            {
                yDisplace += DefaultDisplayce;
                if (yDisplace >= page.Height - EndOfPage) {
                    yDisplace = 20;
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                }
                gfx.AddText(curAddition, xDisplace, yDisplace);
            }

            yDisplace += DefaultDisplayce;
            if (yDisplace >= page.Height - EndOfPage) {
                yDisplace = 20;
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
            }
            gfx.AddText("Итоговая сумма: " + string.Format("{0:C}", cheque.Price), xDisplace, page.Height - 40, DefaultSize, xDisplace, XStringFormats.CenterRight, headerFont);

            document.Save("wwwroot/cheque/" + cheque.ChequeID + ".pdf");
        }

        private static void AddText(
            this XGraphics gfx,
            string text,
            double xDisplace = xDisplace,
            double yDisplace = 0,
            double height = DefaultSize,
            double xEndDisplace = 0,
            XStringFormat format = null,
            XFont font = null,
            XBrush brush = null)
        {
            if (font == null)
                font = new XFont("Times New Roman", 16, XFontStyle.Regular);
            if (format == null)
                format = XStringFormats.TopLeft;
            if (brush == null)
                brush = XBrushes.Black;
            gfx.DrawString(text, font, brush, new XRect(xDisplace, yDisplace, gfx.PageSize.Width - xDisplace - xEndDisplace, height), format);
        }
    }
}
