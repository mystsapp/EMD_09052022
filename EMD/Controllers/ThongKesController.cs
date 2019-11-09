using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EMD.Controllers
{
    public class ThongKesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ThongKesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult TheoNgayBay(string tuNgay, string denNgay)
        {
            DateTime tu = Convert.ToDateTime(tuNgay);
            DateTime den = Convert.ToDateTime(denNgay);
            byte[] fileContents;

            ExcelPackage ExcelApp = new ExcelPackage();
            ExcelWorksheet xlSheet = ExcelApp.Workbook.Worksheets.Add("Report");
            // Định dạng chiều dài cho cột
            xlSheet.Column(1).Width = 10;// STT
            xlSheet.Column(2).Width = 25;// Code doan
            xlSheet.Column(3).Width = 20;// Bat dau
            xlSheet.Column(4).Width = 20;// Ket Thuc
            xlSheet.Column(5).Width = 15;// SL ve dat coc
            xlSheet.Column(6).Width = 20;// Ngay dat coc
            xlSheet.Column(7).Width = 20;// Ngay het han

            xlSheet.Column(8).Width = 10;// So EMD
            xlSheet.Column(9).Width = 20;// Tien dat coc
            xlSheet.Column(10).Width = 10;// Loai BK
            xlSheet.Column(11).Width = 15;// SL ve da xuat
            xlSheet.Column(12).Width = 20;// Tien phat
            xlSheet.Column(13).Width = 10;// PNR
            xlSheet.Column(14).Width = 20;// Hoan coc

            xlSheet.Column(15).Width = 25;// Ghi chu

            xlSheet.Cells[1, 1].Value = "SAIGONTOURIST";
            xlSheet.Cells[2, 1].Value = "PHONG VE MAY BAY";

            if (tu == den)
            {
                xlSheet.Cells[3, 1].Value = "CAC DOAN CO NGAY BAY TU " + tu.ToString("dd/MM/yyyy");
            }
            else
            {
                xlSheet.Cells[3, 1].Value = "CAC DOAN CO NGAY BAY TU " + tu.ToString("dd/MM/yyyy") + " DEN " + den.ToString("dd/MM/yyyy");
            }

            xlSheet.Cells[3, 1].Style.Font.SetFromFont(new Font("Times New Roman", 15, FontStyle.Bold));
            xlSheet.Cells[3, 1, 3, 15].Merge = true;
            setCenterAligment(3, 1, 3, 15, xlSheet);
            // dinh dang tu ngay den ngay
            //if (tungay == denngay)
            //{
            //    fromTo = "Ngày: " + tungay;
            //}
            //else
            //{
            //    fromTo = "Từ ngày: " + tungay + " đến ngày: " + denngay;
            //}

            //xlSheet.Cells[3, 1].Value = fromTo;
            //xlSheet.Cells[3, 1, 3, 7].Merge = true;
            //xlSheet.Cells[3, 1].Style.Font.SetFromFont(new Font("Times New Roman", 14, FontStyle.Bold));
            //setCenterAligment(3, 1, 3, 7, xlSheet);

            // Tạo header
            xlSheet.Cells[5, 1].Value = "STT";
            xlSheet.Cells[5, 2].Value = "Code doan";
            xlSheet.Cells[5, 3].Value = "Bat dau";
            xlSheet.Cells[5, 4].Value = "Ket Thuc";
            xlSheet.Cells[5, 5].Value = "SL ve dat coc";
            xlSheet.Cells[5, 6].Value = "Ngay dat coc";
            xlSheet.Cells[5, 7].Value = "Ngay het han";

            xlSheet.Cells[5, 8].Value = "So EMD";
            xlSheet.Cells[5, 9].Value = "Tien dat coc";
            xlSheet.Cells[5, 10].Value = "Loai BK";
            xlSheet.Cells[5, 11].Value = "SL ve da xuat";
            xlSheet.Cells[5, 12].Value = "Tien phat";
            xlSheet.Cells[5, 13].Value = "PNR";
            xlSheet.Cells[5, 14].Value = "Hoan coc";
            xlSheet.Cells[5, 15].Value = "Ghi chu";

            xlSheet.Cells[5, 1, 5, 15].Style.Font.SetFromFont(new Font("Times New Roman", 12, FontStyle.Bold));

            // do du lieu tu table
            int dong = 5;


            DataTable dt = _unitOfWork.emdRepository.TheoNgayBay_Report(tuNgay, denNgay);


            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dong++;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (String.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            xlSheet.Cells[dong, j + 1].Value = "";
                        }
                        else
                        {
                            if (j == 0)
                                xlSheet.Cells[dong, j + 1].Value = i + 1;
                            else
                            {
                                var a = dt.Rows[i][j];
                                xlSheet.Cells[dong, j + 1].Value = a;
                            }
                        }
                    }
                }
            }
            else
            {
                // SetAlert("No sale.", "warning");
                return Json(new
                {
                    status = false,
                    message = "failure"
                });
            }
            dong++;
            //// Merger cot 4,5 ghi tổng tiền
            //setRightAligment(dong, 3, dong, 3, xlSheet);
            //xlSheet.Cells[dong, 1, dong, 2].Merge = true;
            //xlSheet.Cells[dong, 1].Value = "Tổng tiền: ";

            // Sum tổng tiền

            //xlSheet.Cells[dong, 5].Value = "TC";
            //xlSheet.Cells[dong, 6].Formula = "SUM(F6:F" + (6 + dt.Rows.Count - 1) + ")";
            //xlSheet.Cells[dong, 7].Formula = "SUM(G6:G" + (6 + dt.Rows.Count - 1) + ")";

            // định dạng số

            //NumberFormat(dong, 6, dong, 7, xlSheet);

            setBorder(5, 1, 5 + dt.Rows.Count, 15, xlSheet);
            setFontBold(5, 1, 5, 15, 12, xlSheet);
            setFontSize(6, 1, 6 + dt.Rows.Count, 15, 12, xlSheet);
            // dinh dang giua cho cot stt
            setCenterAligment(6, 1, 6 + dt.Rows.Count, 1, xlSheet);

           // setBorder(dong, 5, dong, 15, xlSheet);
            //setFontBold(dong, 5, dong, 15, 12, xlSheet);

            // dinh dạng ngay thang cho cot ngay di , ngay ve
            DateTimeFormat(6, 3, 6 + dt.Rows.Count, 3, xlSheet);
            DateTimeFormat(6, 4, 6 + dt.Rows.Count, 4, xlSheet);
            DateTimeFormat(6, 6, 6 + dt.Rows.Count, 6, xlSheet);
            DateTimeFormat(6, 7, 6 + dt.Rows.Count, 7, xlSheet);
            DateTimeFormat(6, 14, 6 + dt.Rows.Count, 14, xlSheet);
            // canh giưa cot  ngay di, ngay ve, so khach 
            setCenterAligment(6, 3, 6 + dt.Rows.Count, 3, xlSheet);
            setCenterAligment(6, 4, 6 + dt.Rows.Count, 4, xlSheet);
            // dinh dạng number cot doanh so
            NumberFormat(6, 9, 6 + dt.Rows.Count, 9, xlSheet);
            NumberFormat(6, 12, 6 + dt.Rows.Count, 12, xlSheet);

            //xlSheet.View.FreezePanes(6, 20);

            try
            {
                fileContents = ExcelApp.GetAsByteArray();
                return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "TheoNgayBay_" + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ".xlsx");

            }
            catch (Exception)
            {

                throw;
            }

            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////


        private static void NumberFormat(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                range.Style.Numberformat.Format = "#,#0";
            }
        }
        private static void DateFormat(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.Numberformat.Format = "dd/MM/yyyy";
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }
        private static void DateTimeFormat(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }
        private static void setRightAligment(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
        }
        private static void setCenterAligment(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }
        private static void setFontSize(int fromRow, int fromColumn, int toRow, int toColumn, int fontSize, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.Font.SetFromFont(new Font("Times New Roman", fontSize, FontStyle.Regular));
            }
        }
        private static void setFontBold(int fromRow, int fromColumn, int toRow, int toColumn, int fontSize, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.Font.SetFromFont(new Font("Times New Roman", fontSize, FontStyle.Bold));
            }
        }
        private static void setBorder(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }
        }
        private static void PhantramFormat(int fromRow, int fromColumn, int toRow, int toColumn, ExcelWorksheet sheet)
        {
            using (var range = sheet.Cells[fromRow, fromColumn, toRow, toColumn])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Numberformat.Format = "0 %";
            }
        }

        public double MeasureTextHeight(string text, ExcelFont font, int width)
        {
            if (string.IsNullOrEmpty(text)) return 0.0;
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);

            var pixelWidth = Convert.ToInt32(width * 7.5);  //7.5 pixels per excel column width
            var drawingFont = new Font(font.Name, font.Size);
            var size = graphics.MeasureString(text, drawingFont, pixelWidth);

            //72 DPI and 96 points per inch.  Excel height in points with max of 409 per Excel requirements.
            return Math.Min(Convert.ToDouble(size.Height) * 72 / 96, 409);
        }
    }
}