namespace Tkalcic_Projekt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.StartPage = new System.Windows.Forms.TabPage();
            this.CompareAlts = new System.Windows.Forms.Button();
            this.CompareNodes = new System.Windows.Forms.Button();
            this.DeleteAlt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Altname = new System.Windows.Forms.TextBox();
            this.Alternatives = new System.Windows.Forms.ListBox();
            this.DeleteNode = new System.Windows.Forms.Button();
            this.AddNode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Nodename = new System.Windows.Forms.TextBox();
            this.Nodes = new System.Windows.Forms.TreeView();
            this.NodePage = new System.Windows.Forms.TabPage();
            this.NextNode = new System.Windows.Forms.Button();
            this.Test = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AltPage = new System.Windows.Forms.TabPage();
            this.NextAlt = new System.Windows.Forms.Button();
            this.CalcAlt = new System.Windows.Forms.Button();
            this.altGridView = new System.Windows.Forms.DataGridView();
            this.FinishTab = new System.Windows.Forms.TabPage();
            this.FinalCalc = new System.Windows.Forms.Button();
            this.Finish = new System.Windows.Forms.Button();
            this.finalGridView = new System.Windows.Forms.DataGridView();
            this.TestSaveChild = new System.Windows.Forms.Button();
            this.TestSaveParents = new System.Windows.Forms.Button();
            this.NextFinal = new System.Windows.Forms.Button();
            this.ResultChart = new System.Windows.Forms.Button();
            this.FinalResult = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.StartPage.SuspendLayout();
            this.NodePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.AltPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.altGridView)).BeginInit();
            this.FinishTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.StartPage);
            this.tabControl1.Controls.Add(this.NodePage);
            this.tabControl1.Controls.Add(this.AltPage);
            this.tabControl1.Controls.Add(this.FinishTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(994, 625);
            this.tabControl1.TabIndex = 0;
            // 
            // StartPage
            // 
            this.StartPage.Controls.Add(this.CompareAlts);
            this.StartPage.Controls.Add(this.CompareNodes);
            this.StartPage.Controls.Add(this.DeleteAlt);
            this.StartPage.Controls.Add(this.label2);
            this.StartPage.Controls.Add(this.Add);
            this.StartPage.Controls.Add(this.Altname);
            this.StartPage.Controls.Add(this.Alternatives);
            this.StartPage.Controls.Add(this.DeleteNode);
            this.StartPage.Controls.Add(this.AddNode);
            this.StartPage.Controls.Add(this.label1);
            this.StartPage.Controls.Add(this.Nodename);
            this.StartPage.Controls.Add(this.Nodes);
            this.StartPage.Location = new System.Drawing.Point(4, 22);
            this.StartPage.Name = "StartPage";
            this.StartPage.Padding = new System.Windows.Forms.Padding(3);
            this.StartPage.Size = new System.Drawing.Size(986, 599);
            this.StartPage.TabIndex = 0;
            this.StartPage.Text = "Start";
            this.StartPage.UseVisualStyleBackColor = true;
            // 
            // CompareAlts
            // 
            this.CompareAlts.Location = new System.Drawing.Point(650, 568);
            this.CompareAlts.Name = "CompareAlts";
            this.CompareAlts.Size = new System.Drawing.Size(119, 23);
            this.CompareAlts.TabIndex = 11;
            this.CompareAlts.Text = "Compare Alts";
            this.CompareAlts.UseVisualStyleBackColor = true;
            this.CompareAlts.Click += new System.EventHandler(this.CompareAlts_Click);
            // 
            // CompareNodes
            // 
            this.CompareNodes.Location = new System.Drawing.Point(261, 568);
            this.CompareNodes.Name = "CompareNodes";
            this.CompareNodes.Size = new System.Drawing.Size(119, 23);
            this.CompareNodes.TabIndex = 10;
            this.CompareNodes.Text = "Compare nodes";
            this.CompareNodes.UseVisualStyleBackColor = true;
            this.CompareNodes.Click += new System.EventHandler(this.CompareNodes_Click);
            // 
            // DeleteAlt
            // 
            this.DeleteAlt.Location = new System.Drawing.Point(694, 54);
            this.DeleteAlt.Name = "DeleteAlt";
            this.DeleteAlt.Size = new System.Drawing.Size(75, 23);
            this.DeleteAlt.TabIndex = 9;
            this.DeleteAlt.Text = "Delete";
            this.DeleteAlt.UseVisualStyleBackColor = true;
            this.DeleteAlt.Click += new System.EventHandler(this.DeleteAlt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(532, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Add an alternative";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(694, 25);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 7;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Altname
            // 
            this.Altname.Location = new System.Drawing.Point(535, 28);
            this.Altname.Name = "Altname";
            this.Altname.Size = new System.Drawing.Size(153, 20);
            this.Altname.TabIndex = 6;
            // 
            // Alternatives
            // 
            this.Alternatives.Dock = System.Windows.Forms.DockStyle.Right;
            this.Alternatives.FormattingEnabled = true;
            this.Alternatives.Location = new System.Drawing.Point(794, 3);
            this.Alternatives.Name = "Alternatives";
            this.Alternatives.Size = new System.Drawing.Size(189, 593);
            this.Alternatives.TabIndex = 5;
            // 
            // DeleteNode
            // 
            this.DeleteNode.Location = new System.Drawing.Point(417, 53);
            this.DeleteNode.Name = "DeleteNode";
            this.DeleteNode.Size = new System.Drawing.Size(75, 23);
            this.DeleteNode.TabIndex = 4;
            this.DeleteNode.Text = "Delete";
            this.DeleteNode.UseVisualStyleBackColor = true;
            this.DeleteNode.Click += new System.EventHandler(this.DeleteNode_Click);
            // 
            // AddNode
            // 
            this.AddNode.Location = new System.Drawing.Point(417, 24);
            this.AddNode.Name = "AddNode";
            this.AddNode.Size = new System.Drawing.Size(75, 23);
            this.AddNode.TabIndex = 3;
            this.AddNode.Text = "Add";
            this.AddNode.UseVisualStyleBackColor = true;
            this.AddNode.Click += new System.EventHandler(this.AddNode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add a node";
            // 
            // Nodename
            // 
            this.Nodename.Location = new System.Drawing.Point(258, 26);
            this.Nodename.Name = "Nodename";
            this.Nodename.Size = new System.Drawing.Size(153, 20);
            this.Nodename.TabIndex = 1;
            // 
            // Nodes
            // 
            this.Nodes.Dock = System.Windows.Forms.DockStyle.Left;
            this.Nodes.Location = new System.Drawing.Point(3, 3);
            this.Nodes.Name = "Nodes";
            this.Nodes.Size = new System.Drawing.Size(249, 593);
            this.Nodes.TabIndex = 0;
            // 
            // NodePage
            // 
            this.NodePage.Controls.Add(this.NextNode);
            this.NodePage.Controls.Add(this.Test);
            this.NodePage.Controls.Add(this.dataGridView1);
            this.NodePage.Location = new System.Drawing.Point(4, 22);
            this.NodePage.Name = "NodePage";
            this.NodePage.Padding = new System.Windows.Forms.Padding(3);
            this.NodePage.Size = new System.Drawing.Size(986, 599);
            this.NodePage.TabIndex = 1;
            this.NodePage.Text = "Nodes";
            this.NodePage.UseVisualStyleBackColor = true;
            // 
            // NextNode
            // 
            this.NextNode.Location = new System.Drawing.Point(812, 550);
            this.NextNode.Name = "NextNode";
            this.NextNode.Size = new System.Drawing.Size(75, 23);
            this.NextNode.TabIndex = 2;
            this.NextNode.Text = "Next";
            this.NextNode.UseVisualStyleBackColor = true;
            this.NextNode.Click += new System.EventHandler(this.NextNode_Click);
            // 
            // Test
            // 
            this.Test.Location = new System.Drawing.Point(893, 550);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(75, 23);
            this.Test.TabIndex = 1;
            this.Test.Text = "Calculate";
            this.Test.UseVisualStyleBackColor = true;
            this.Test.Click += new System.EventHandler(this.Test_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(970, 538);
            this.dataGridView1.TabIndex = 0;
            // 
            // AltPage
            // 
            this.AltPage.Controls.Add(this.NextAlt);
            this.AltPage.Controls.Add(this.CalcAlt);
            this.AltPage.Controls.Add(this.altGridView);
            this.AltPage.Location = new System.Drawing.Point(4, 22);
            this.AltPage.Name = "AltPage";
            this.AltPage.Size = new System.Drawing.Size(986, 599);
            this.AltPage.TabIndex = 0;
            this.AltPage.Text = "Alternatives";
            // 
            // NextAlt
            // 
            this.NextAlt.Location = new System.Drawing.Point(804, 553);
            this.NextAlt.Name = "NextAlt";
            this.NextAlt.Size = new System.Drawing.Size(75, 23);
            this.NextAlt.TabIndex = 3;
            this.NextAlt.Text = "Next";
            this.NextAlt.UseVisualStyleBackColor = true;
            this.NextAlt.Click += new System.EventHandler(this.NextAlt_Click);
            // 
            // CalcAlt
            // 
            this.CalcAlt.Location = new System.Drawing.Point(885, 553);
            this.CalcAlt.Name = "CalcAlt";
            this.CalcAlt.Size = new System.Drawing.Size(75, 23);
            this.CalcAlt.TabIndex = 2;
            this.CalcAlt.Text = "Calculate";
            this.CalcAlt.UseVisualStyleBackColor = true;
            this.CalcAlt.Click += new System.EventHandler(this.CalcAlt_Click);
            // 
            // altGridView
            // 
            this.altGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.altGridView.Location = new System.Drawing.Point(8, 9);
            this.altGridView.Name = "altGridView";
            this.altGridView.Size = new System.Drawing.Size(970, 538);
            this.altGridView.TabIndex = 1;
            // 
            // FinishTab
            // 
            this.FinishTab.Controls.Add(this.FinalResult);
            this.FinishTab.Controls.Add(this.ResultChart);
            this.FinishTab.Controls.Add(this.NextFinal);
            this.FinishTab.Controls.Add(this.FinalCalc);
            this.FinishTab.Controls.Add(this.Finish);
            this.FinishTab.Controls.Add(this.finalGridView);
            this.FinishTab.Controls.Add(this.TestSaveChild);
            this.FinishTab.Controls.Add(this.TestSaveParents);
            this.FinishTab.Location = new System.Drawing.Point(4, 22);
            this.FinishTab.Name = "FinishTab";
            this.FinishTab.Size = new System.Drawing.Size(986, 599);
            this.FinishTab.TabIndex = 2;
            this.FinishTab.Text = "Finish";
            this.FinishTab.UseVisualStyleBackColor = true;
            // 
            // FinalCalc
            // 
            this.FinalCalc.Location = new System.Drawing.Point(822, 556);
            this.FinalCalc.Name = "FinalCalc";
            this.FinalCalc.Size = new System.Drawing.Size(75, 23);
            this.FinalCalc.TabIndex = 4;
            this.FinalCalc.Text = "Calculate";
            this.FinalCalc.UseVisualStyleBackColor = true;
            this.FinalCalc.Click += new System.EventHandler(this.FinalCalc_Click);
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(903, 556);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(75, 23);
            this.Finish.TabIndex = 3;
            this.Finish.Text = "Finish";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // finalGridView
            // 
            this.finalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finalGridView.Location = new System.Drawing.Point(8, 35);
            this.finalGridView.Name = "finalGridView";
            this.finalGridView.Size = new System.Drawing.Size(970, 515);
            this.finalGridView.TabIndex = 2;
            // 
            // TestSaveChild
            // 
            this.TestSaveChild.Location = new System.Drawing.Point(903, 3);
            this.TestSaveChild.Name = "TestSaveChild";
            this.TestSaveChild.Size = new System.Drawing.Size(75, 23);
            this.TestSaveChild.TabIndex = 1;
            this.TestSaveChild.Text = "Test C";
            this.TestSaveChild.UseVisualStyleBackColor = true;
            this.TestSaveChild.Click += new System.EventHandler(this.TestSaveChild_Click);
            // 
            // TestSaveParents
            // 
            this.TestSaveParents.Location = new System.Drawing.Point(826, 3);
            this.TestSaveParents.Name = "TestSaveParents";
            this.TestSaveParents.Size = new System.Drawing.Size(75, 23);
            this.TestSaveParents.TabIndex = 0;
            this.TestSaveParents.Text = "Test P";
            this.TestSaveParents.UseVisualStyleBackColor = true;
            this.TestSaveParents.Click += new System.EventHandler(this.TestSaveParents_Click);
            // 
            // NextFinal
            // 
            this.NextFinal.Location = new System.Drawing.Point(741, 556);
            this.NextFinal.Name = "NextFinal";
            this.NextFinal.Size = new System.Drawing.Size(75, 23);
            this.NextFinal.TabIndex = 5;
            this.NextFinal.Text = "Next";
            this.NextFinal.UseVisualStyleBackColor = true;
            this.NextFinal.Click += new System.EventHandler(this.NextFinal_Click);
            // 
            // ResultChart
            // 
            this.ResultChart.Location = new System.Drawing.Point(660, 556);
            this.ResultChart.Name = "ResultChart";
            this.ResultChart.Size = new System.Drawing.Size(75, 23);
            this.ResultChart.TabIndex = 6;
            this.ResultChart.Text = "Results";
            this.ResultChart.UseVisualStyleBackColor = true;
            this.ResultChart.Click += new System.EventHandler(this.ResultChart_Click);
            // 
            // FinalResult
            // 
            this.FinalResult.AutoSize = true;
            this.FinalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalResult.Location = new System.Drawing.Point(8, 556);
            this.FinalResult.Name = "FinalResult";
            this.FinalResult.Size = new System.Drawing.Size(77, 24);
            this.FinalResult.TabIndex = 7;
            this.FinalResult.Text = "Best is:";
            this.FinalResult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 625);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Decision Feniks";
            this.tabControl1.ResumeLayout(false);
            this.StartPage.ResumeLayout(false);
            this.StartPage.PerformLayout();
            this.NodePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.AltPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.altGridView)).EndInit();
            this.FinishTab.ResumeLayout(false);
            this.FinishTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage StartPage;
        private System.Windows.Forms.TreeView Nodes;
        private System.Windows.Forms.TabPage NodePage;
        private System.Windows.Forms.Button DeleteNode;
        private System.Windows.Forms.Button AddNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nodename;
        private System.Windows.Forms.Button DeleteAlt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox Altname;
        private System.Windows.Forms.ListBox Alternatives;
        private System.Windows.Forms.Button Test;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CompareAlts;
        private System.Windows.Forms.Button CompareNodes;
        private System.Windows.Forms.TabPage AltPage;
        private System.Windows.Forms.Button CalcAlt;
        private System.Windows.Forms.DataGridView altGridView;
        private System.Windows.Forms.Button NextNode;
        private System.Windows.Forms.Button NextAlt;
        private System.Windows.Forms.TabPage FinishTab;
        private System.Windows.Forms.Button TestSaveChild;
        private System.Windows.Forms.Button TestSaveParents;
        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.DataGridView finalGridView;
        private System.Windows.Forms.Button FinalCalc;
        private System.Windows.Forms.Button NextFinal;
        private System.Windows.Forms.Button ResultChart;
        private System.Windows.Forms.Label FinalResult;
    }
}

