using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace cangku
{
   class daochuEXCEL
    {
        public  static  void ExportExcel(string fileName, DataGridView myDGV)
        //导出函数有两个参数，一个为保存文件名，另一个为当前显示数据的datagridview
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();//建立保存对话框
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消 
            Microsoft.Office.Interop.Excel.Application xlApp
         = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
            //写入标题，headertext为标题属性
            for (int i = 0; i < myDGV.ColumnCount; i++)
            { worksheet.Cells[2, i + 1] = myDGV.Columns[i].HeaderText; }
            //写入数值
            worksheet.Cells[1, 1] = fileName;
            //写入导出数据的表格名称
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 3, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Cells[myDGV.Rows.Count + 4, 2] = "导出数据时间：";//显示导出时间   
            worksheet.Cells[myDGV.Rows.Count + 4, 3] = Convert.ToString(DateTime.Now);
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                { workbook.Saved = true; workbook.SaveCopyAs(saveFileName); }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            MessageBox.Show(fileName + "的简明资料保存成功", "提示", MessageBoxButtons.OK);
        }
    }
}
