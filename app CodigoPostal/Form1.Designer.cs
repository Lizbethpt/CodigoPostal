namespace app_CodigoPostal
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.lstvDatos = new System.Windows.Forms.ListView();
            this.btnGuardarconInterop = new System.Windows.Forms.Button();
            this.btnGuardarconOpenxml = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnGraficar = new System.Windows.Forms.Button();
            this.BtnabrirArbol = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(12, 12);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click_1);
            // 
            // lstvDatos
            // 
            this.lstvDatos.HideSelection = false;
            this.lstvDatos.Location = new System.Drawing.Point(12, 41);
            this.lstvDatos.Name = "lstvDatos";
            this.lstvDatos.Size = new System.Drawing.Size(418, 366);
            this.lstvDatos.TabIndex = 1;
            this.lstvDatos.UseCompatibleStateImageBehavior = false;
            // 
            // btnGuardarconInterop
            // 
            this.btnGuardarconInterop.Location = new System.Drawing.Point(112, 12);
            this.btnGuardarconInterop.Name = "btnGuardarconInterop";
            this.btnGuardarconInterop.Size = new System.Drawing.Size(116, 23);
            this.btnGuardarconInterop.TabIndex = 3;
            this.btnGuardarconInterop.Text = "Guardar con Interop";
            this.btnGuardarconInterop.UseVisualStyleBackColor = true;
            this.btnGuardarconInterop.Click += new System.EventHandler(this.btnGuardarconInterop_Click);
            // 
            // btnGuardarconOpenxml
            // 
            this.btnGuardarconOpenxml.Location = new System.Drawing.Point(247, 12);
            this.btnGuardarconOpenxml.Name = "btnGuardarconOpenxml";
            this.btnGuardarconOpenxml.Size = new System.Drawing.Size(137, 23);
            this.btnGuardarconOpenxml.TabIndex = 4;
            this.btnGuardarconOpenxml.Text = "Guardar con OpenXml";
            this.btnGuardarconOpenxml.UseVisualStyleBackColor = true;
            this.btnGuardarconOpenxml.Click += new System.EventHandler(this.btnGuardarconOpenxml_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(854, 495);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(436, 262);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(390, 225);
            this.treeView1.TabIndex = 6;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IntervalOffset = 1D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(436, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(320, 244);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // BtnGraficar
            // 
            this.BtnGraficar.Location = new System.Drawing.Point(762, 12);
            this.BtnGraficar.Name = "BtnGraficar";
            this.BtnGraficar.Size = new System.Drawing.Size(93, 23);
            this.BtnGraficar.TabIndex = 8;
            this.BtnGraficar.Text = "Graficar";
            this.BtnGraficar.UseVisualStyleBackColor = true;
            this.BtnGraficar.Click += new System.EventHandler(this.BtnGraficar_Click);
            // 
            // BtnabrirArbol
            // 
            this.BtnabrirArbol.Location = new System.Drawing.Point(832, 412);
            this.BtnabrirArbol.Name = "BtnabrirArbol";
            this.BtnabrirArbol.Size = new System.Drawing.Size(93, 23);
            this.BtnabrirArbol.TabIndex = 9;
            this.BtnabrirArbol.Text = "Abrir Arbol";
            this.BtnabrirArbol.UseVisualStyleBackColor = true;
            this.BtnabrirArbol.Click += new System.EventHandler(this.BtnabrirArbol_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(762, 61);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(93, 23);
            this.BtnLimpiar.TabIndex = 10;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 530);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnabrirArbol);
            this.Controls.Add(this.BtnGraficar);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardarconOpenxml);
            this.Controls.Add(this.btnGuardarconInterop);
            this.Controls.Add(this.lstvDatos);
            this.Controls.Add(this.btnAbrir);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.ListView lstvDatos;
        private System.Windows.Forms.Button btnGuardarconInterop;
        private System.Windows.Forms.Button btnGuardarconOpenxml;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button BtnGraficar;
        private System.Windows.Forms.Button BtnabrirArbol;
        private System.Windows.Forms.Button BtnLimpiar;
    }
}

