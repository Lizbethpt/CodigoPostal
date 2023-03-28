﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace app_CodigoPostal
{
    public partial class Form1 : Form
    {
        bool maximizado;
        public Form1()
        {
            InitializeComponent();
            lstvDatos.View = View.Details;
            maximizado = false;
        }
        private void btnAbrir_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            lstvDatos.Clear();
            string rutaArchivo = dialogo.FileName;
            StreamReader sr = new StreamReader(rutaArchivo, Encoding.GetEncoding(1252));
            string columnas = sr.ReadLine();
            string[] columna = columnas.Split('|');
            for (int i = 0; i < columna.Length; i++)
            {
                lstvDatos.Columns.Add(columna[i]);
            }
            string renglon;
            while ((renglon = sr.ReadLine()) != null)
            {
                string[] datos = renglon.Split('|');
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(datos[0]);
                for (int i = 1; i < datos.Length; i++)
                {
                    item.SubItems.Add(datos[i]);
                }
                lstvDatos.Items.Add(item);
            }
            sr.Close();
        }
        private void btnGuardarconInterop_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Crea una instancia de la aplicación Excel
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                // Crea un nuevo libro de Excel
                var workbook = excelApp.Workbooks.Add();
                // Crea una hoja de Excel
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                // Exporta el contenido del ListView a la hoja de Excel
                for (int i = 0; i < lstvDatos.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = lstvDatos.Columns[i].Text;
                }
                for (int i = 0; i < lstvDatos.Items.Count; i++)
                {
                    for (int j = 0; j < lstvDatos.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = lstvDatos.Items[i].SubItems[j].Text;
                    }
                }
                // Guarda el archivo de Excel
                workbook.SaveAs(saveFileDialog.FileName);
                // Cierra el archivo y la aplicación Excel
                workbook.Close();
                excelApp.Quit();
            }
        }
        private void btnGuardarconOpenxml_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (.xlsx)|.xlsx|All files (.)|.";
            if (sfd.ShowDialog() != DialogResult.OK)
            { return; }
            if (sfd.FileName != "")
            {
                SpreadsheetDocument document = SpreadsheetDocument.Create(sfd.FileName, SpreadsheetDocumentType.Workbook);
                // Agregar una hoja de trabajo
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(new SheetData());
                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "ListView" };
                sheets.Append(sheet);
                // Obtener la colección de celdas
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                // Recorrer las columnas y filas de la ListView
                for (int i = 0; i < lstvDatos.Columns.Count; i++)
                {
                    // Crear una fila para los encabezados
                    if (i == 0)
                    {
                        Row row = new Row() { RowIndex = 1 };
                        sheetData.Append(row);
                    }
                    // Obtener el encabezado de la columna
                    string headerText = lstvDatos.Columns[i].Text;
                    // Crear una celda para el encabezado
                    Cell headerCell = new Cell()
                    {
                        CellReference = GetColumnName(i + 1) + "1",
                        DataType = CellValues.String,
                        CellValue = new CellValue(headerText)
                    };
                    // Agregar la celda al final de la fila
                    Row headerRow = (Row)sheetData.ChildElements.GetItem(0);
                    headerRow.AppendChild(headerCell);
                    // Recorrer las filas de la columna
                    for (int j = 0; j < lstvDatos.Items.Count; j++)
                    {
                        // Crear una fila para los datos
                        if (i == 0)
                        {
                            Row row = new Row() { RowIndex = (uint)(j + 2) };
                            sheetData.Append(row);
                        }
                        // Obtener el valor del dato
                        string dataText = lstvDatos.Items[j].SubItems[i].Text;
                        // Crear una celda para el dato
                        Cell dataCell = new Cell()
                        {
                            CellReference = GetColumnName(i + 1) + (j + 2),
                            DataType = CellValues.String,
                            CellValue = new CellValue(dataText)
                        };
                        // Agregar la celda al final de la fila
                        Row dataRow = (Row)sheetData.ChildElements.GetItem(j + 1);
                        dataRow.AppendChild(dataCell);
                    }
                }
                // Guardar y cerrar el documento
                workbookPart.Workbook.Save();
                document.Close();
                Process.Start(sfd.FileName);
            }
        }
        // Método auxiliar para obtener el nombre de la columna según su índice
        private string GetColumnName(int index)
        {
            int dividend = index;
            string columnName = String.Empty;
            int modulo;
            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            StreamReader sr = new StreamReader(dialogo.FileName, Encoding.GetEncoding(1252));
            string renglon;
            string x = "";
            int y = 0;
            while ((renglon = sr.ReadLine()) != null)
            {
                string[] datos = renglon.Split('|');
                if (x != datos[0] && x != "")
                {
                    chart1.Series[0].Points.AddXY(x, y);
                    y = 0;
                }
                x = datos[0];
                y++;
            }
            chart1.Series[0].Points.AddXY(x, y);
        }
        private void LlenarArbol(StreamReader sr)
        {
            string renglon;
            string x = "";
            TreeNode ciudad = new TreeNode();
            TreeNode estado = new TreeNode();
            TreeNode codigoPostal = new TreeNode();
            TreeNode colonia = new TreeNode();
            while ((renglon = sr.ReadLine()) != null)
            {
                string[] datos = renglon.Split('|');
                if (colonia.Text != datos[1] && x != "")
                {
                    if (codigoPostal.Text != datos[0] && ciudad.Text != "")
                    {
                        if (ciudad.Text != datos[5] && ciudad.Text != "")
                        {
                            if (estado.Text != datos[4] && estado.Text != "")
                            {
                                treeView1.Nodes.Add(estado.Text);
                                estado = new TreeNode();

                            }
                        }
                        estado.Text = datos[5];
                        estado.Nodes.Add(ciudad);
                        ciudad = new TreeNode();
                    }
                    ciudad.Text = datos[1];
                    codigoPostal.Nodes.Add(ciudad);
                    codigoPostal = new TreeNode();
                }
                codigoPostal.Text = datos[5];
                codigoPostal.Nodes.Add(codigoPostal);
                colonia.Text = datos[0];

            }
        }
        private void BtnabrirArbol_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            filltree(ofd.FileName);

        }
      
        private void chart1_Click(object sender, EventArgs e)
        {
            if (maximizado)
            {
                chart1.Location = new System.Drawing.Point(436, 12);
                chart1.Height =240; chart1.Width = 320;
            }
            else
            {
                chart1.Location = new System.Drawing.Point(0, 0);
                chart1.Height = this.Height; chart1.Width = this.Width;
            }
            maximizado = !maximizado;
        }
        private void filltree(string filename)
        {
            Dictionary<string, List<string>> cpColonias = new Dictionary<string, List<string>>();
            string[] lineas = File.ReadAllLines(filename);
            foreach (string linea in lineas)
            {
                string[] campos = linea.Split('|');
                string estado = campos[4];
                string ciudad = campos[5];
                string cp = campos[0];
                string colonia = campos[1];
                if (!cpColonias.ContainsKey(cp))
                {
                    cpColonias.Add(cp, new List<string>());
                }
                cpColonias[cp].Add(colonia);
                TreeNode estadoNode = null;
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Text == estado)
                    {
                        estadoNode = node;
                        break;
                    }
                }
                if (estadoNode == null)
                {
                    estadoNode = new TreeNode(estado);
                    treeView1.Nodes.Add(estadoNode);
                }
                TreeNode ciudadNode = null;
                foreach (TreeNode node in estadoNode.Nodes)
                {
                    if (node.Text == ciudad)
                    {
                        ciudadNode = node;
                        break;
                    }
                }
                if (ciudadNode == null)
                {
                    ciudadNode = new TreeNode(ciudad);
                    estadoNode.Nodes.Add(ciudadNode);
                }
                TreeNode cpNode = null;
                foreach (TreeNode node in ciudadNode.Nodes)
                {
                    if (node.Text == cp)
                    {
                        cpNode = node;
                        break;
                    }
                }
                if (cpNode == null)
                {
                    cpNode = new TreeNode(cp);
                    ciudadNode.Nodes.Add(cpNode);
                }
                TreeNode coloniaNode = null;
                foreach (TreeNode node in cpNode.Nodes)
                {
                    if (node.Text == colonia)
                    {
                        coloniaNode = node;
                        break;
                    }
                }
                if (coloniaNode == null)
                {
                    coloniaNode = new TreeNode(colonia);
                    cpNode.Nodes.Add(coloniaNode);
                }
            }
        }
        private void BtnLimpiar_Click_1(object sender, EventArgs e)
           {
            chart1.Series.Clear();
           }
    }

}










