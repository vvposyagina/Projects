using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDD
{
    public partial class MainPage : Form
    {
        Graphics graphics;
        Point LocationLastPictureBox = new Point(100, 120);
        int countOfStep;
        Bdd final;
        Tree fullTree = null;
        Bitmap finallyBitmap;
        bool permissionOnDrawing;
        public MainPage()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }
        private void tsmSemanticTree_Click(object sender, EventArgs e)
        {
            pBuildOnTheFormula.Visible = false;
            pBuildBySemanticTree.Visible = true;
            pWelcome.Visible = false;
        }
        private void tsmFormule_Click(object sender, EventArgs e)
        {
            pBuildBySemanticTree.Visible = false;
            pBuildOnTheFormula.Visible = true;
            pWelcome.Visible = false;
        }
        //построение по дереву
        private void bBuildBDD_Click(object sender, EventArgs e)
        {
            int countOfVar;            
            bNextStepTree.Visible = false;
            Int32.TryParse(lbCountOfVar.Text, out countOfVar);
            string[] listVar = tbSequenceVar.Text.Split(',');
            string listVal = tbFunction.Text;
            bool[] values = null;
            string[] listOrder = tbOrderVar.Text.Split(',');
            pForDrawingBDD.Controls.Clear();
            LocationLastPictureBox = new Point(10, 50);
            string function = "";
            if (CheckValueFunc(listVal))
            {
                values = Tree.StringConvertToBool(listVal);
            }
            else
            {
                MessageBox.Show("Некорректно указано значение функции");
            }
            if(listOrder[0] != "")
            {
                if(listOrder.Length != listVar.Length)
                {
                    MessageBox.Show("Количество переменных и количество их имен не совпадают");
                }
                else
                {
                    bool flag = false;
                    for(int i = 0; i < listVar.Length; i++)
                    {
                        flag = false;
                        for(int j = 0; j < listOrder.Length; j++)
                        {
                            if(listVar[i] == listOrder[j])
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            MessageBox.Show("Не совпадение имен переменных при указании порядка переменных");
                            break;
                        }
                    }
                    if(flag)
                    {
                        if (CheckValueFunc(listVal))
                        {
                            values = Tree.ChangeOrderVar(listVar, listOrder, Tree.StringConvertToBool(listVal));
                            listVar = listOrder;
                            Label info = new Label();
                            info.Text = "f(" + tbOrderVar.Text + ") = (" + BufBoolConvertToString(values) + ")";
                            function = info.Text;
                            info.Font = new Font("Times New Roman", 20, System.Drawing.FontStyle.Regular);
                            info.Parent = pForDrawingBDD;
                            info.Location = new Point(25, 35);
                            info.AutoSize = true;
                        }
                        else
                        {
                            MessageBox.Show("Некорректно указано значение функции");
                        }
                    }
                }
            }
            if (listVar.Length != countOfVar)
            {
                MessageBox.Show("Количество переменных и количество их имен не совпадают");
            }
            else
            {
                if (listVal.Length != Math.Pow(2, countOfVar))
                {
                    MessageBox.Show("Некорректное количество значений функции");
                }
                else
                {
                    if (CheckValueFunc(listVal))
                    {
                        fullTree = new Tree(countOfVar, listVar, values);
                        if (!fullTree.CreateTree())
                        {
                            MessageBox.Show("Некорректно указано количество переменных");
                        }
                        else
                        {
                            fullTree.buildNewTree += BuildTree;
                            fullTree.refresh += RefreshTree;
                            fullTree.IsConst += DrawConst;
                            Label info = new Label();
                            info.Text = "f(" + tbSequenceVar.Text + ") = (" + tbFunction.Text + ")";
                            info.Font = new Font("Times New Roman", 20, System.Drawing.FontStyle.Regular);
                            info.Parent = pForDrawingBDD;
                            info.Location = new Point(25, 10);
                            info.AutoSize = true;
                            if (function == "")
                            {
                                fullTree.Function = info.Text;
                            }
                            else
                            {
                                fullTree.Function = function;
                            }
                            fullTree.BuildBDD();
                            bSaveResult.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректно указано значение функции");
                    }
                }
            }
        }  
        public void RefreshTree()
        {
            Bitmap bmp = fullTree.DrawNextTree();
            PictureBox pb = new PictureBox();
            pb.Image = bmp;
            pb.Width = bmp.Width;
            pb.Height = bmp.Height;
            pb.Parent = pForDrawingBDD;
            pb.Location = LocationLastPictureBox;
            LocationLastPictureBox.Y += pb.Height;
            finallyBitmap = bmp;
        }
        public void BuildTree()
        {
            Bitmap bmp = fullTree.DrawFirstTree();
            PictureBox pb = new PictureBox();
            pb.Image = bmp;
            pb.Width = bmp.Width;
            pb.Height = bmp.Height;
            pb.Parent = pForDrawingBDD;
            pb.Location = LocationLastPictureBox;
            LocationLastPictureBox.Y += pb.Height;
        }
        public void DrawConst()
        {
            Bitmap bmp = fullTree.DrawConst();
            PictureBox pb = new PictureBox();
            pb.Image = bmp;
            pb.Width = bmp.Width;
            pb.Height = bmp.Height;
            pb.Parent = pForDrawingBDD;
            pb.Location = LocationLastPictureBox;
            LocationLastPictureBox.Y += pb.Height;
        }
        private void bPhasedImplementTree_Click(object sender, EventArgs e)
        {
            bSaveResult.Visible = false;
            int countOfVar;
            Int32.TryParse(lbCountOfVar.Text, out countOfVar);
            string[] listVar = tbSequenceVar.Text.Split(',');
            string listVal = tbFunction.Text;
            bool[] values = Tree.StringConvertToBool(listVal);
            string[] listOrder = tbOrderVar.Text.Split(',');
            pForDrawingBDD.Controls.Clear();
            LocationLastPictureBox = new Point(10, 50);
            string function = "";
            countOfStep = 1;
            if (listOrder[0] != "")
            {
                if (listOrder.Length != listVar.Length)
                {
                    MessageBox.Show("Количество переменных и количество их имен не совпадают");
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < listVar.Length; i++)
                    {
                        flag = false;
                        for (int j = 0; j < listOrder.Length; j++)
                        {
                            if (listVar[i] == listOrder[j])
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            MessageBox.Show("Не совпадение имен переменных при указании порядка переменных");
                            break;
                        }
                    }
                    if (flag)
                    {
                        values = Tree.ChangeOrderVar(listVar, listOrder, Tree.StringConvertToBool(listVal));
                        listVar = listOrder;
                        Label info = new Label();
                        info.Text = "f(" + tbOrderVar.Text + ") = (" + BufBoolConvertToString(values) + ")";
                        function = info.Text;
                        info.Font = new Font("Times New Roman", 20, System.Drawing.FontStyle.Regular);
                        info.Parent = pForDrawingBDD;
                        info.Location = new Point(25, 35);
                        info.AutoSize = true;
                    }
                }
            }
            if (listVar.Length != countOfVar)
            {
                MessageBox.Show("Количество переменных и количество их имен не совпадают");
            }
            else
            {
                if (listVal.Length != Math.Pow(2, countOfVar))
                {
                    MessageBox.Show("Некорректное количество значений функции");
                }
                else
                {
                    fullTree = new Tree(countOfVar, listVar, values);
                    if (!fullTree.CreateTree())
                    {
                        MessageBox.Show("Некорректно указано количество переменных");
                    }
                    else
                    {
                        bNextStepTree.Visible = true;
                        fullTree.buildNewTree += BuildTree;
                        fullTree.refresh += RefreshTree;
                        fullTree.IsConst += DrawConst;
                        Label info = new Label();
                        info.Text = "f(" + tbSequenceVar.Text + ") = (" + tbFunction.Text + ")";
                        info.Font = new Font("Times New Roman", 20, System.Drawing.FontStyle.Regular);
                        info.Parent = pForDrawingBDD;
                        info.Location = new Point(25, 10);
                        info.AutoSize = true;
                        if (function == "")
                        {
                            fullTree.Function = info.Text;
                        }
                        else
                        {
                            fullTree.Function = function;
                        }
                        permissionOnDrawing = fullTree.BuildBDDOneStep();
                    }
                }
            }
        }
        private void bNextStepTree_Click(object sender, EventArgs e)
        {
            if(permissionOnDrawing)
            {
                permissionOnDrawing = fullTree.BuildBDDOneStep();
            }
            else
            {
                MessageBox.Show("Построение BDD окончено");
                bSaveResult.Visible = true;
            }
        } 
        //построние по формуле
        private void bBuildBDDOnTheFormula_Click(object sender, EventArgs e)
        {
            rbFirstMethod.Visible = false;
            rbSecondMethod.Visible = false;
            string expression = ConvertUserStringToProgramString(tbForFromula.Text);
            string[] listOrder = tbSeqVarInFormula.Text.Split(',');
            bNextStep.Visible = false;
            bool flag = false;
            if (listOrder[0] == "")
            {
                if (rbFirstMethod.Checked)
                {
                    listOrder = Bdd.GetOptimalOrderByCount(expression);
                    flag = true;
                }
                else if (rbSecondMethod.Checked)
                {
                    listOrder = Bdd.GetOptimalOrderByDistance(expression);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Введите порядок переменных или выберите автоматический подбор");
                }
            }
            else
            {
                if (CheckCoincidenceOfVariablesAndFormula(listOrder, expression))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Некорректно введен порядок переменных");
                }
            }
            if (flag)
            {
                pForDrawingBDD.Controls.Clear();
                LocationLastPictureBox = new Point(10, 50);
                final = new Bdd();
                final = final.BuildBddOnFormula(expression, listOrder);

                Label formula = new Label();
                formula.Text = "f(" + GetStringByStringBuf(listOrder) + ") = " + tbForFromula.Text;
                formula.Font = new Font("Times New Roman", 28, System.Drawing.FontStyle.Bold);
                formula.Parent = pForDrawingBDD;
                formula.Location = new Point(20, 20);
                formula.AutoSize = true;

                for (int i = 1; i <= final.ListBddInProcess.Count; i++)
                {
                    if (final.ListBddInProcess.ContainsKey(i))
                    {
                        Bitmap bmpLeft = final.DrawBDD(final.ListBddInProcess[i].Item1);
                        PictureBox pbLeft = new PictureBox();
                        pbLeft.Image = bmpLeft;
                        pbLeft.Width = bmpLeft.Width;
                        pbLeft.Height = bmpLeft.Height;
                        pbLeft.Parent = pForDrawingBDD;
                        pbLeft.Location = LocationLastPictureBox;
                        LocationLastPictureBox.X += (pbLeft.Width + 15);
                        LocationLastPictureBox.Y += 50;

                        Point pointForStep = new Point(LocationLastPictureBox.X + pbLeft.Width, LocationLastPictureBox.Y);

                        Label op = new Label();
                        op.Text = GetSymbolByOperation(final.ListBddInProcess[i].Item4);
                        op.Font = new Font("Times New Roman", 36, System.Drawing.FontStyle.Bold);
                        op.Parent = pForDrawingBDD;
                        op.Location = LocationLastPictureBox;
                        op.AutoSize = true;
                        LocationLastPictureBox.X += 25;
                        LocationLastPictureBox.Y -= 50;
                        if (final.ListBddInProcess[i].Item2 != null)
                        {
                            Bitmap bmpRight = final.DrawBDD(final.ListBddInProcess[i].Item2);
                            PictureBox pbRight = new PictureBox();
                            pbRight.Image = bmpRight;
                            pbRight.Width = bmpRight.Width;
                            pbRight.Height = bmpRight.Height;
                            pbRight.Parent = pForDrawingBDD;
                            pbRight.Location = LocationLastPictureBox;
                            LocationLastPictureBox.Y += Math.Max(pbLeft.Height, pbRight.Height);
                            pointForStep.X += (pbRight.Width);
                        }
                        else
                        {
                            LocationLastPictureBox.Y += pbLeft.Height;
                        }
                        
                        Label eq = new Label();
                        eq.Text = "=";
                        eq.Font = new Font("Times New Roman", 36, System.Drawing.FontStyle.Bold);
                        eq.Parent = pForDrawingBDD;
                        eq.Location = new Point(200, LocationLastPictureBox.Y);
                        eq.AutoSize = true;
                        LocationLastPictureBox.X -= (pbLeft.Width + 40);
                        LocationLastPictureBox.Y += 50;

                        Label step = new Label();
                        step.Text = "Шаг №" + i;
                        step.Font = new Font("Times New Roman", 28, System.Drawing.FontStyle.Bold);
                        step.Parent = pForDrawingBDD;
                        step.Location = pointForStep;
                        step.AutoSize = true;

                        Bitmap bmpAnswer = final.DrawBDD(final.ListBddInProcess[i].Item3);
                        PictureBox pbAnswer = new PictureBox();
                        pbAnswer.Image = bmpAnswer;
                        pbAnswer.Width = bmpAnswer.Width;
                        pbAnswer.Height = bmpAnswer.Height;
                        pbAnswer.Parent = pForDrawingBDD;
                        //pbAnswer.BorderStyle = BorderStyle.FixedSingle;
                        pbAnswer.Location = LocationLastPictureBox;
                        LocationLastPictureBox.Y += pbAnswer.Height;

                        finallyBitmap = bmpAnswer;
                    }
                }
                bSaveBmpByFormula.Visible = true;
            }
        }
        private void bPhasedImplementation_Click(object sender, EventArgs e)
        {
            rbFirstMethod.Visible = false;
            rbSecondMethod.Visible = false;
            bNextStep.Visible = true;
            bSaveBmpByFormula.Visible = false;
            string expression = ConvertUserStringToProgramString(tbForFromula.Text);
            string[] listOrder = tbSeqVarInFormula.Text.Split(',');
            bool flag = false;
            countOfStep = 1;
            if (listOrder[0] == "")
            {
                if (rbFirstMethod.Checked)
                {
                    listOrder = Bdd.GetOptimalOrderByCount(expression);
                    flag = true;
                }
                else if (rbSecondMethod.Checked)
                {
                    listOrder = Bdd.GetOptimalOrderByDistance(expression);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Введите порядок переменных или выберите автоматический подбор");
                }
            }
            else
            {
                if (CheckCoincidenceOfVariablesAndFormula(listOrder, expression))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Некорректно введен порядок переменных");
                }
            }
            if (flag)
            {
                pForDrawingBDD.Controls.Clear();
                LocationLastPictureBox = new Point(10, 50);
                final = new Bdd();
                final = final.BuildBddOnFormula(expression, listOrder);
                bNextStep.Enabled = true;

                Label formula = new Label();
                formula.Text = "f(" + GetStringByStringBuf(listOrder) + ") = " + tbForFromula.Text;
                formula.Font = new Font("Times New Roman", 28, System.Drawing.FontStyle.Bold);
                formula.Parent = pForDrawingBDD;
                formula.Location = new Point(20, 20);
                formula.AutoSize = true;
            }
        }
        private void bNextStep_Click(object sender, EventArgs e)
        {
            if (countOfStep <= final.ListBddInProcess.Count)
            {
                if (final.ListBddInProcess.ContainsKey(countOfStep))
                {
                    Bitmap bmpLeft = final.DrawBDD(final.ListBddInProcess[countOfStep].Item1);
                    PictureBox pbLeft = new PictureBox();
                    pbLeft.Image = bmpLeft;
                    pbLeft.Width = bmpLeft.Width;
                    pbLeft.Height = bmpLeft.Height;
                    pbLeft.Parent = pForDrawingBDD;
                    pbLeft.Location = LocationLastPictureBox;
                    LocationLastPictureBox.X += (pbLeft.Width + 15);
                    LocationLastPictureBox.Y += 50;

                    Point pointForStep = new Point(LocationLastPictureBox.X + pbLeft.Width, LocationLastPictureBox.Y);

                    Label op = new Label();
                    op.Text = GetSymbolByOperation(final.ListBddInProcess[countOfStep].Item4);
                    op.Font = new Font("Times New Roman", 36 , System.Drawing.FontStyle.Bold);
                    op.Parent = pForDrawingBDD;
                    op.Location = LocationLastPictureBox;
                    op.AutoSize = true;
                    LocationLastPictureBox.X += 25;
                    LocationLastPictureBox.Y -= 50;
                    if (final.ListBddInProcess[countOfStep].Item2 != null)
                    {
                        Bitmap bmpRight = final.DrawBDD(final.ListBddInProcess[countOfStep].Item2);
                        PictureBox pbRight = new PictureBox();
                        pbRight.Image = bmpRight;
                        pbRight.Width = bmpRight.Width;
                        pbRight.Height = bmpRight.Height;
                        pbRight.Parent = pForDrawingBDD;
                        pbRight.Location = LocationLastPictureBox;
                        LocationLastPictureBox.Y += Math.Max(pbLeft.Height, pbRight.Height);
                        pointForStep.X += (pbRight.Width + 50);
                    }
                    else
                    {
                        LocationLastPictureBox.Y += pbLeft.Height;
                    }
                    Label eq = new Label();
                    eq.Text = "=";
                    eq.Font = new Font("Times New Roman", 36, System.Drawing.FontStyle.Bold);
                    eq.Parent = pForDrawingBDD;
                    eq.Location = new Point(200, LocationLastPictureBox.Y);
                    eq.AutoSize = true;
                    LocationLastPictureBox.X -= (pbLeft.Width + 40);
                    LocationLastPictureBox.Y += 50;

                    Label step = new Label();
                    step.Text = "Шаг №" + countOfStep;
                    step.Font = new Font("Times New Roman", 28, System.Drawing.FontStyle.Bold);
                    step.Parent = pForDrawingBDD;
                    step.Location = pointForStep;
                    step.AutoSize = true;

                    Bitmap bmpAnswer = final.DrawBDD(final.ListBddInProcess[countOfStep].Item3);
                    PictureBox pbAnswer = new PictureBox();
                    pbAnswer.Image = bmpAnswer;
                    pbAnswer.Width = bmpAnswer.Width;
                    pbAnswer.Height = bmpAnswer.Height;
                    pbAnswer.Parent = pForDrawingBDD;
                    //pbAnswer.BorderStyle = BorderStyle.FixedSingle;
                    pbAnswer.Location = LocationLastPictureBox;
                    LocationLastPictureBox.Y += pbAnswer.Height;
                    countOfStep++;
                    finallyBitmap = bmpAnswer;
                    if (countOfStep == final.ListBddInProcess.Count)
                    {
                        bSaveBmpByFormula.Visible = true;
                        MessageBox.Show("Построение BDD окончено");
                    }
                }
            }
            else
            {
                MessageBox.Show("Построение BDD окончено");
            }
        }
        //вспомогательные фукнции
        public string ConvertUserStringToProgramString(string input)
        {
            string output = string.Empty;
            for(int i = 0 ; i < input.Length; i++)
            {
                if(input[i] == '/')
                { 
                    output += '*';
                    i++;
                    continue;
                }

                if(input[i] == '\\')
                { 
                    output += '+';
                    i++;
                    continue;
                }
                if (input[i] == '+')
                {
                    output += '%';
                    continue;
                }
                if (input[i] == '-')
                {
                    output += '>';
                    i++;
                    continue;
                }
                output += input[i];
            } return output;
        }                
        private void bConjunction_Click(object sender, EventArgs e)
        {
            tbForFromula.Text += "/\\";
        }
        private void bDisjunction_Click(object sender, EventArgs e)
        {
            tbForFromula.Text += "\\/";
        }
        private void bInverse_Click(object sender, EventArgs e)
        {
            tbForFromula.Text += "!";
        }
        private void bImplication_Click(object sender, EventArgs e)
        {
            tbForFromula.Text += "->";
        }
        private void bEquivalence_Click(object sender, EventArgs e)
        {
            tbForFromula.Text += "~";
        }
        private void bAdditionByModule2_Click(object sender, EventArgs e)
        {
            tbForFromula.Text += "+";
        }      
        private void bAutomaticOrder_Click(object sender, EventArgs e)
        {
            rbFirstMethod.Visible = true;
            rbSecondMethod.Visible = true;
        }
        private string BufBoolConvertToString(bool[] buf)
        {
            string answer = "";
            for(int i= 0; i < buf.Length; i++)
            {
                if (buf[i])
                {
                    answer += "1";
                }
                else
                {
                    answer += "0";
                }
            }
            return answer;
        }        
        public string GetSymbolByOperation(operation op)
        {
            switch (op)
            {
                case operation.RBL: return "(";
                case operation.RBR: return ")";
                case operation.EQ: return "~";
                case operation.IM: return "->";
                case operation.XOR: return "+";
                case operation.OR: return "\\/";
                case operation.AND: return "/\\";
                case operation.NOT: return "!";                
            }
            return "";
        }
        public string GetStringByStringBuf(string[] buf)
        {
            string result = "";
            for(int i = 0; i < buf.Length; i++)
            {
                if (i != buf.Length - 1)
                {
                    result = result + buf[i] + ",";
                }
                else
                {
                    result = result + buf[i];
                }
            }
            return result;
        }       
        private static bool IsDelimeter(char c)
        {
            return c == ' ';
        }
        private static bool IsOperator(char a)
        {
            return a == '+' || a == '*' || a == '!' || a == '~' || a == '%' || a == '>' || a == ')' || a == '(';
        }
        public bool CheckCoincidenceOfVariablesAndFormula(string[] variables, string formula)
        {
            List<string> varFromFormula = new List<string>();
            for (int i = 0; i < formula.Length; i++)
            {                
                string operand = "";
                while (i < formula.Length && !IsDelimeter(formula[i]) && !IsOperator(formula[i]))
                {
                    operand += formula[i++];
                }
                if (!varFromFormula.Contains(operand) && operand != "")
                {
                    varFromFormula.Add(operand);
                }                
            }
            if(variables.Length != varFromFormula.Count)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < variables.Length; i++)
                {
                    if(!varFromFormula.Contains(variables[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void bSaveResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveBmp = new SaveFileDialog();
            if (saveBmp.ShowDialog(this) == DialogResult.OK)
            {
                finallyBitmap.Save(saveBmp.FileName);
            }
        }
        private void bSaveBmpByFormula_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveBmp = new SaveFileDialog();
            if (saveBmp.ShowDialog(this) == DialogResult.OK)
            {
                finallyBitmap.Save(saveBmp.FileName);
            }
        }
        public bool CheckValueFunc(string func)
        {
            for(int i = 0; i < func.Length; i++)
            {
                if(func[i] != '0' && func[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
