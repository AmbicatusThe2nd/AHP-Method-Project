using LiveCharts;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tkalcic_Projekt.Data;
using Tkalcic_Projekt.Models;

namespace Tkalcic_Projekt
{
    public partial class Form1 : Form
    {
        public int CurrentNumberOfNodes;
        public int CurrentNumberOfAlts;
        public ParentNode CurrentParentNode;
        public ChildNode CurrentChildNode;
        public int CurrentParentIndex = 0;
        public int CurrentChildIndex = 0;
        public Queue QueueNodes = new Queue();
        public Queue QueueLeafs = new Queue();
        public Queue<ParentNode> QueueFinal;
        public List<int> DepthOfTree = new List<int>();
        public int MaxDepth;
        public bool Again = true;
        //public int DepthCounter = 1;

        public Form1()
        {
            InitializeComponent();
            Alternatives.DataSource = Datacontext.Alternitives;
            dataGridView1.AllowUserToAddRows = false;
            altGridView.AllowUserToAddRows = false;
            finalGridView.AllowUserToAddRows = false;
        }

        private void GetNodesIn(TreeNodeCollection treeNode, int DepthCounter) // Recursion for parent nodes
        {
            DepthCounter++;
            foreach (TreeNode node in treeNode)
            {
                if (node.Nodes.Count > 0)
                {
                    Datacontext.parents.Add(new ParentNode
                    {
                        Name = node.Text
                    });
                    Datacontext.Depths.Add(new ParentNode
                    {
                        Name = node.Text
                    }, DepthCounter);
                    Datacontext.TreeNodes.Add(node.Nodes);
                    QueueNodes.Enqueue(node.Nodes);

                    GetNodesIn(node.Nodes, DepthCounter);
                }
                DepthOfTree.Add(DepthCounter);
            }
        }

        private void GetLeafsIn(TreeNodeCollection treeNode) // Recursion for leaf nodes
        {
            foreach (TreeNode node in treeNode)
            {
                if (node.Nodes.Count > 0)
                {
                    GetLeafsIn(node.Nodes);
                }
                else
                {
                    Datacontext.children.Add(new ChildNode
                    {
                        Name = node.Text
                    });
                    QueueLeafs.Enqueue(node);
                }
            }
        }

        private void GetthetableNodes(TreeNodeCollection treeNodes) // Creating a table for comparing the nodes
        {
            CurrentNumberOfNodes = treeNodes.Count;
            int onceMore = 0;
            var numberOfColumns = treeNodes.Count * 2 + 1;
            dataGridView1.ColumnCount = numberOfColumns;
            dataGridView1.RowCount = treeNodes.Count;
            dataGridView1.TopLeftHeaderCell.Value = CurrentParentNode.Name;
        OnceAgain:
            onceMore++;
            for (int j = 0; j < treeNodes.Count; j++)
            {
                if (onceMore == 1)
                {
                    dataGridView1.Columns[j].Name = treeNodes[j].Text;
                    dataGridView1.Rows[j].HeaderCell.Value = treeNodes[j].Text;
                }
                else
                {
                    var index = j + (treeNodes.Count - j) + j;
                    dataGridView1.Columns[index].Name = treeNodes[j].Text + " Usefulness";
                }
                if (onceMore < 2 && j == treeNodes.Count - 1)
                {
                    goto OnceAgain;
                }

                if (j == treeNodes.Count - 1)
                {
                    dataGridView1.Columns[numberOfColumns - 1].Name = "Weights";
                }
            }

            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                for (int column = 0; column < dataGridView1.ColumnCount; column++)
                {

                    if (row == column)
                    {
                        dataGridView1[row, column].Value = 1;
                        dataGridView1[row, column].ReadOnly = true;
                    }
                }
            }
        }

        private void GettheTableAlts(BindingList<Alternative> Alternatives, TreeNode treeNode) // Creating a table for comparing the Alternatives
        {
            CurrentNumberOfAlts = Alternatives.Count;
            int onceMore = 0;
            var numberOfColumns = Alternatives.Count * 2 + 1;
            //var row = new Object[activeNode.Nodes.Count];
            altGridView.ColumnCount = numberOfColumns;
            altGridView.RowCount = Alternatives.Count;
            altGridView.TopLeftHeaderCell.Value = treeNode.Text;
        OnceAgain:
            onceMore++;
            for (int j = 0; j < Alternatives.Count; j++)
            {
                if (onceMore == 1)
                {
                    altGridView.Columns[j].Name = Alternatives[j].Name;
                    altGridView.Rows[j].HeaderCell.Value = Alternatives[j].Name;
                }
                else
                {
                    var index = j + (Alternatives.Count - j) + j;
                    altGridView.Columns[index].Name = Alternatives[j].Name + " Usefulness";
                }
                if (onceMore < 2 && j == Alternatives.Count - 1)
                {
                    goto OnceAgain;
                }

                if (j == Alternatives.Count - 1)
                {
                    altGridView.Columns[numberOfColumns - 1].Name = "Usefulness";
                }
            }

            for (int row = 0; row < altGridView.RowCount; row++)
            {
                for (int column = 0; column < altGridView.ColumnCount; column++)
                {
                    if (row == column)
                    {
                        altGridView[row, column].Value = 1;
                        altGridView[row, column].ReadOnly = true;
                    }
                }
            }
        }

        private Dictionary<int, double> GetColumnSumsNode() // Suming columns for Node comparission with storing their Index
        {
            var Sums = new Dictionary<int, double>();
            double Sum = 0;
            int indexOfColumn = 0;
            for (var column = 0; column < dataGridView1.ColumnCount; column++)
            {
                if (column < CurrentNumberOfNodes)
                {
                    for (var row = 0; row < dataGridView1.RowCount; row++)
                    {

                        Sum += Convert.ToDouble(dataGridView1[column, row].Value);
                        indexOfColumn = dataGridView1[column, row].ColumnIndex;
                    }
                    Sums.Add(indexOfColumn, Sum);
                    Sum = 0;
                }
            }
            return Sums;
        }

        private Dictionary<int, double> GetColumnSumsAlts() // Suming columns for Alternativs comparission with storing their Index
        {
            var Sums = new Dictionary<int, double>();
            double Sum = 0;
            int indexOfColumn = 0;
            for (var column = 0; column < altGridView.ColumnCount; column++)
            {
                if (column < CurrentNumberOfAlts)
                {
                    for (var row = 0; row < altGridView.RowCount; row++)
                    {

                        Sum += Convert.ToDouble(altGridView[column, row].Value);
                        indexOfColumn = altGridView[column, row].ColumnIndex;
                    }
                    Sums.Add(indexOfColumn, Sum);
                    Sum = 0;
                }
            }
            return Sums;
        }

        private void CalculateTheUseNode(Dictionary<int, double> Sums) // Claculating the use of Nodes
        {
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                for (int column = 0; column < dataGridView1.ColumnCount; column++)
                {
                    if (column >= CurrentNumberOfNodes)
                    {
                        break;
                    }
                    var result = Math.Round(Convert.ToDouble(dataGridView1[column, row].Value) / Sums.FirstOrDefault(x => x.Key == column).Value, 2);
                    dataGridView1[column + CurrentNumberOfNodes, row].Value = result;
                }
            }
        }

        private void CalculateTheUseAlts(Dictionary<int, double> Sums) // Claculating the use of Alternatives
        {
            for (int row = 0; row < altGridView.RowCount; row++)
            {
                for (int column = 0; column < altGridView.ColumnCount; column++)
                {
                    if (column >= CurrentNumberOfAlts)
                    {
                        break;
                    }
                    var result = Math.Round(Convert.ToDouble(altGridView[column, row].Value) / Sums.FirstOrDefault(x => x.Key == column).Value, 2);
                    altGridView[column + CurrentNumberOfAlts, row].Value = result;
                }
            }
        }

        private void CalculateTheWeightsNode() // Calculating the Weights of the Nodes
        {
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                var childNode = string.Empty;
                double SummingRows = 0;
                double CountingRows = 0;
                int columnCounter = 0;
                for (int column = CurrentNumberOfNodes; column < dataGridView1.ColumnCount; column++)
                {
                    if (columnCounter == 0)
                    {
                        childNode = Convert.ToString(dataGridView1.Rows[row].HeaderCell.Value);
                    }
                    if (column == dataGridView1.ColumnCount - 1)
                    {
                        var result = SummingRows / CountingRows;
                        CurrentParentNode.WeightValues.Add(childNode, result);
                        dataGridView1[column, row].Value = Math.Round(result, 2);
                    }
                    CountingRows++;
                    SummingRows += Convert.ToDouble(dataGridView1[column, row].Value);
                }
            }
            Datacontext.parents[CurrentParentIndex] = CurrentParentNode;
        }

        private void CalculateTheWeightsAlts() // Calculating the Usefulness of the Alternatives
        {
            for (int row = 0; row < altGridView.RowCount; row++)
            {
                var Alternative = new Alternative();
                double SummingRows = 0;
                double CountingRows = 0;
                int columnCounter = 0;
                for (int column = CurrentNumberOfAlts; column < altGridView.ColumnCount; column++)
                {
                    if (columnCounter == 0)
                    {
                        Alternative = Datacontext.Alternitives.Where(x => x.Name == Convert.ToString(altGridView.Rows[row].HeaderCell.Value)).FirstOrDefault();
                    }
                    if (column == altGridView.ColumnCount - 1)
                    {
                        var result = SummingRows / CountingRows;
                        CurrentChildNode.UsefulValues.Add(Alternative, result);
                        altGridView[column, row].Value = result;
                    }
                    CountingRows++;
                    SummingRows += Convert.ToDouble(altGridView[column, row].Value);
                }
            }
            Datacontext.children[CurrentChildIndex] = CurrentChildNode;
        }

        private void GetFinalTable(BindingList<Alternative> Alts, List<ChildNode> children, ParentNode Parent) // Method of getting the final Matirix
        {
            finalGridView.ColumnCount = Alts.Count + 1;
            finalGridView.RowCount = children.Count + 1;
            for (int i = 0; i < finalGridView.ColumnCount; i++)
            {
                if (i == finalGridView.ColumnCount - 1)
                {
                    finalGridView.Columns[i].HeaderCell.Value = "Weights";
                    break;
                }
                finalGridView.Columns[i].HeaderCell.Value = Alts[i].Name;
            }

            for (int i = 0; i < finalGridView.RowCount; i++)
            {
                if (i == finalGridView.RowCount - 1)
                {
                    finalGridView.Rows[i].HeaderCell.Value = Parent.Name;
                    break;
                }
                finalGridView.Rows[i].HeaderCell.Value = children[i].Name;
                var listOfValues = children[i].UsefulValues.Values.ToList();
                for (int j = 0; j < finalGridView.ColumnCount; j++)
                {
                    if (j == finalGridView.ColumnCount - 1)
                    {
                        var listOfWeights = Parent.WeightValues.Values.ToList();
                        finalGridView[j, i].Value = listOfWeights[i];
                        break;
                    }
                    finalGridView[j, i].Value = listOfValues[j];
                }
            }
        }



        private IEnumerable<ParentNode> GetFromThatLevel(int Level)
        {
            var listOfThisLevel = Datacontext.Depths.Where(x => x.Value == Level)
                .Select(x => x.Key).ToList();
            var realList = from first in Datacontext.parents
                           join second in listOfThisLevel
                           on first.Name equals second.Name
                           select first;

            return realList;
        }

        private List<ChildNode> GetTheChildren(ParentNode Weights)
        {
            var listOfChilds = new List<ChildNode>();
            foreach (var child in Data.Datacontext.children)
            {
                foreach (var secondChild in Weights.WeightValues)
                {
                    if (child.Name == secondChild.Key)
                    {
                        listOfChilds.Add(child);
                    }
                }

            }
            return listOfChilds;
        }


        private Dictionary<Alternative, double> GetTheFinalValues(List<ParentNode> Weights, List<ChildNode> children)
        {
            return new Dictionary<Alternative, double>(); // Dummy return
        }

        private void AddNode_Click(object sender, EventArgs e)
        {
            var nodeChilds = Nodes.GetNodeCount(true);
            if (!String.IsNullOrEmpty(Nodename.Text))
            {
                if (nodeChilds < 1)
                {
                    Nodes.Nodes.Add(Nodename.Text);
                }
                else
                    if (nodeChilds >= 1 && Nodes.SelectedNode == null)
                {
                    MessageBox.Show("Please select node you want to add a child to");
                }
                else
                {
                    Nodes.SelectedNode.Nodes.Add(Nodename.Text);
                }
            }
            else
            {
                MessageBox.Show("Please name the node you wish to add");
            }

            Nodename.Text = string.Empty;
        }

        private void DeleteNode_Click(object sender, EventArgs e)
        {
            if (Nodes.SelectedNode != null)
            {
                Nodes.SelectedNode.Remove();
            }
            else
            {
                MessageBox.Show("Please select the node you want to delete");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Altname.Text))
            {
                var alternative = new Alternative
                {
                    Name = Altname.Text
                };
                Datacontext.Alternitives.Add(alternative);
            }
            else
            {
                MessageBox.Show("Please name the alternative you wish to add");
            }
            Altname.Text = string.Empty;
        }

        private void Test_Click(object sender, EventArgs e)
        {
            /*
            // Testing the recursion
            GetNodesIn(Nodes.Nodes);
            foreach(var data in Datacontext.TreeNodes)
            {
                MessageBox.Show(data.Count.ToString());
            }
            */
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please first comfirm the the viewtree");
                return;
            }

            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                for (int column = 0; column < dataGridView1.ColumnCount; column++)
                {
                    if (dataGridView1[column, row].ReadOnly || dataGridView1[column, row].Value == null)
                    {
                        continue;
                    }
                    else
                    {
                        dataGridView1[row, column].Value = Math.Round(1 / Convert.ToDouble(dataGridView1[column, row].Value), 2);
                        dataGridView1[row, column].ReadOnly = true;
                    }

                }
            }
            var Sums = GetColumnSumsNode();
            CalculateTheUseNode(Sums);
            CalculateTheWeightsNode();

            /* // Testing the sums
            foreach (var data in Sums)
            {
                MessageBox.Show(data.Value.ToString());
            }
            */
        }

        private void CompareNodes_Click(object sender, EventArgs e)
        {
            GetNodesIn(Nodes.Nodes, 0);
            var firstNode = QueueNodes.Dequeue() as TreeNodeCollection;
            CurrentParentNode = Datacontext.parents[CurrentParentIndex];
            GetthetableNodes(firstNode);
            //GetthetableNodes(Datacontext.TreeNodes[0]);
        }

        private void DeleteAlt_Click(object sender, EventArgs e)
        {
            if (Alternatives.SelectedItem == null)
            {
                MessageBox.Show("Please first select an alternative to delete it");
            }
            else
            {
                var alt = Alternatives.SelectedItem as Alternative;
                Datacontext.Alternitives.Remove(alt);
            }
        }

        private void CompareAlts_Click(object sender, EventArgs e)
        {
            if (Datacontext.Alternitives.Count <= 1)
            {
                MessageBox.Show("You at least need two alternitives in order for the program to work");
            }
            else
            {
                GetLeafsIn(Nodes.Nodes);
                var leaf = QueueLeafs.Dequeue() as TreeNode;
                CurrentChildNode = Datacontext.children[CurrentChildIndex];
                GettheTableAlts(Datacontext.Alternitives, leaf);
                // MessageBox.Show(QueueLeafs.Count.ToString());
            }
        }

        private void CalcAlt_Click(object sender, EventArgs e)
        {
            // TO DO: Implimentation
            if (altGridView.Rows.Count == 0)
            {
                MessageBox.Show("Please first comfrim the the viewtree");
                return;
            }

            for (int row = 0; row < altGridView.RowCount; row++)
            {
                for (int column = 0; column < altGridView.ColumnCount; column++)
                {
                    if (altGridView[column, row].ReadOnly || altGridView[column, row].Value == null)
                    {
                        continue;
                    }
                    else
                    {
                        altGridView[row, column].Value = Math.Round(1 / Convert.ToDouble(altGridView[column, row].Value), 2);
                        altGridView[row, column].ReadOnly = true;
                    }
                }
            }

            var Sums = GetColumnSumsAlts();
            CalculateTheUseAlts(Sums);
            CalculateTheWeightsAlts();
        }

        private void NextNode_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentParentIndex++;
                var nextNode = QueueNodes.Dequeue() as TreeNodeCollection;
                CurrentParentNode = Datacontext.parents[CurrentParentIndex];
                //dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                GetthetableNodes(nextNode);
            }
            catch
            {
                MessageBox.Show("Either you reached the end of the queue or you have not entered anything in the Tree");
            }
        }

        private void NextAlt_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentChildIndex++;
                var leaf = QueueLeafs.Dequeue() as TreeNode;
                CurrentChildNode = Datacontext.children[CurrentChildIndex];
                altGridView.Rows.Clear();
                altGridView.Columns.Clear();
                GettheTableAlts(Datacontext.Alternitives, leaf);
            }
            catch
            {
                MessageBox.Show("The queue has ended");
            }
        }

        private void TestSaveParents_Click(object sender, EventArgs e)
        {

            foreach (var parent in Datacontext.parents)
            {
                foreach (var Weight in parent.WeightValues)
                {
                    MessageBox.Show("Node: " + Weight.Key + " Value: " + Weight.Value);
                }
            }

            var max = DepthOfTree.Max(x => x);
            MessageBox.Show(max.ToString());
        }

        private void TestSaveChild_Click(object sender, EventArgs e)
        {
            foreach (var leaf in Datacontext.children)
            {
                foreach (var Use in leaf.UsefulValues)
                {
                    MessageBox.Show("Leaf: " + leaf.Name + " Alternative: " + Use.Key + " Value: " + Use.Value);
                }
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            MaxDepth = Datacontext.Depths.Max(x => x.Value);
            var listOfWeights = GetFromThatLevel(MaxDepth).ToList();
            QueueFinal = new Queue<ParentNode>(listOfWeights);
            var currentParent = QueueFinal.Dequeue();
            var listOfChildren = GetTheChildren(currentParent);
            GetFinalTable(Datacontext.Alternitives, listOfChildren, currentParent);
            /*
            foreach(var list in pridobljenList)
            {
                foreach(var node in list.WeightValues)
                {
                    MessageBox.Show(node.Key);
                }
            }
            */
            /*
            foreach(var list in listOfChildren)
            {
                foreach(var child in list.UsefulValues)
                {
                    MessageBox.Show(list.Name + child.Key.Name);
                }
            }
            */

        }

        private void FinalCalc_Click(object sender, EventArgs e)
        {
            var forNext = new List<double>();
            for (int i = 0; i < finalGridView.ColumnCount; i++)
            {

                var resultList = new List<double>();
                for (int j = 0; j < finalGridView.RowCount; j++)
                {
                    if (j == finalGridView.RowCount - 1)
                    {
                        break;
                    }
                    if (double.TryParse(Convert.ToString(finalGridView[i, j].Value), out double numberOne)
                        && double.TryParse(Convert.ToString(finalGridView[finalGridView.ColumnCount - 1, j].Value), out double numberTwo))
                    {
                        resultList.Add(numberOne * numberTwo);
                    }
                }
                if (i == finalGridView.ColumnCount - 1)
                {
                    break;
                }
                var result = Math.Round(resultList.Sum(x => x), 2);
                finalGridView[i, finalGridView.RowCount - 1].Value = result;
                forNext.Add(result);
            }
            var newChild = new ChildNode { Name = Convert.ToString(finalGridView.Rows[finalGridView.RowCount - 1].HeaderCell.Value) };
            for (int i = 0; i < forNext.Count; i++)
            {
                newChild.UsefulValues.Add(Datacontext.Alternitives[i], forNext[i]);
            }
            Datacontext.children.Add(newChild);
        }

        private void NextFinal_Click(object sender, EventArgs e)
        {
            FinalResult.Visible = false;
            finalGridView.Rows.Clear();
            finalGridView.Columns.Clear();
            if (MaxDepth != 1)
            {
                // Hopefully final impimentation
                if (QueueFinal.Count != 0)
                {
                    var currentParent = QueueFinal.Dequeue();
                    var listOfChildren = GetTheChildren(currentParent);
                    GetFinalTable(Datacontext.Alternitives, listOfChildren, currentParent);
                }
                else
                {
                    MaxDepth--;
                    var listOfWeights = GetFromThatLevel(MaxDepth).ToList();
                    QueueFinal = new Queue<ParentNode>(listOfWeights);
                    var currentParent = QueueFinal.Dequeue();
                    var listOfChildren = GetTheChildren(currentParent);
                    GetFinalTable(Datacontext.Alternitives, listOfChildren, currentParent);
                }
            }
            else
            {
                // When we get the best alternative
            }
        }

        private void ResultChart_Click(object sender, EventArgs e)
        {
            var valid = finalGridView[finalGridView.ColumnCount - 1, finalGridView.RowCount - 1].Value;

            var listOfValues = new ChartValues<double>(); // This is for chart
            var anotherListofValues = new List<double>(); // This is for the final score
            var listOfLabels = Datacontext.Alternitives.Select(x => x.Name).ToList();

            for (int i = 0; i < finalGridView.ColumnCount - 1; i++)
            {
                if (double.TryParse(Convert.ToString(finalGridView[i, finalGridView.RowCount - 1].Value), out double number))
                {
                    listOfValues.Add(number);
                    anotherListofValues.Add(number);
                }
            }
            var maxValue = anotherListofValues.Max(x => x);
            var indexOf = anotherListofValues.IndexOf(maxValue);
            FinalResult.Text += listOfLabels[indexOf];
            FinalResult.Visible = true;
            var results = new Results(listOfValues, listOfLabels);
            results.ShowDialog();
            var dialogResult = MessageBox.Show("Do you wish for CSV export", "Question", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var stringBuilder = new StringBuilder();
                var headers = finalGridView.Columns.Cast<DataGridViewColumn>();
                stringBuilder.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                for(int i=0; i < finalGridView.RowCount; i++)
                {
                    var cells = finalGridView.Rows[i].Cells.Cast<DataGridViewCell>();
                    stringBuilder.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());
                }
            }
        }
    }
}
