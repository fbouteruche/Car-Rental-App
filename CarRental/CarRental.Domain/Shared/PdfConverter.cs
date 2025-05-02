using CarRental.Domain.RentalModule;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.Shared
{
    public class PdfConverter
    {
        private string fontFamily;
        private double textFontSize;
        private double titleFontSize;

        public PdfConverter(double textFontSize, double titleFontSize)
        {
            fontFamily = "Verdana";
            this.textFontSize = textFontSize;   //default: 10
            this.titleFontSize = titleFontSize;     //default: 18
        }

        public double TextFontSize { get => textFontSize; set => textFontSize = value; }
        public string FontFamily { get => fontFamily; set => fontFamily = value; }
        public double TitleFontSize { get => titleFontSize; set => titleFontSize = value; }

        public void ConvertRentalToPdf(Rental rental)
        {
            string filePath = $@"..\..\..\Receipts\receipt{rental.Id}.pdf";
            string title = $"Vehicle Rental Receipt - Rental {rental.Id}";

            List<string> lines = new List<string>
            {
                $"• Rental Details:",
                $"      - Selected insurance: {rental.TipoDeSeguro}",
                $"      - Selected plan: {rental.TipoDoPlano}",
                $"      - Rental date: {rental.DataDeSaida.Date.ToString("dd/MM/yyyy")}",
                $"      - Expected return date: {rental.DataPrevistaDeChegada.Date.ToString("dd/MM/yyyy")}",
                $"      - Initial rental price: R${rental.PrecoLocacao}",
                $"• Contracting Customer:",
                $"      - Name: {rental.ClienteContratante.Name}",
                $"      - Unique ID: {rental.ClienteContratante.UniqueId}",
                $"      - Email: {rental.ClienteContratante.Email}",
                $"• Driver Customer:",
                $"      - Name: {rental.ClienteCondutor.Name}",
                $"      - Unique ID: {rental.ClienteCondutor.UniqueId}",
                $"      - Email: {rental.ClienteCondutor.Email}",
                $"      - Driver's License: {rental.ClienteCondutor.DriverLicense}",
                $"• Rented Vehicle:",
                $"      - Model: {rental.Veiculo.model}",
                $"      - Brand: {rental.Veiculo.brand}",
                $"      - License Plate: {rental.Veiculo.licensePlate}",
                $"      - Year: {rental.Veiculo.year}",
                $"      - Color: {rental.Veiculo.color}",
                $"      - Number of doors: {rental.Veiculo.numberOfDoors}",
                $"      - Current mileage: {rental.Veiculo.mileage} km"
            };

            GeneratePdf(filePath, title, lines);
        }

        private void GeneratePdf(string fileName, string titleText, List<string> textLines) 
        {
            double lineXPosition = 70;
            double lineYPosition = 15;
            XFont titleFont = new XFont(fontFamily, titleFontSize, XFontStyle.Bold);
            XFont textFont = new XFont(fontFamily, textFontSize, XFontStyle.Regular);

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = titleText;
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            // Title and header
            graph.DrawString(titleText, titleFont, XBrushes.Black, new XRect(lineXPosition * 0.60, lineYPosition, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            lineYPosition += titleFontSize * 0.5;
            graph.DrawString("___________________________________________________________", titleFont, XBrushes.Black, new XRect(0, lineYPosition, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            lineYPosition += titleFontSize * 2;

            // Lines
            foreach (string line in textLines)
            {
                graph.DrawString(line, textFont, XBrushes.Black, new XRect(lineXPosition, lineYPosition, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                lineYPosition += textFontSize * 2;
            }

            pdf.Save(fileName);
            Process.Start(fileName);
        }
    }
}
