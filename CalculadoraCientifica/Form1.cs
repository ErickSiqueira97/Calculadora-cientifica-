using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraCientifica
{
    public partial class CalculadoraC : Form
    {
        public CalculadoraC()
        {
            InitializeComponent();
        }

        bool vaiMudar = false, fechaParenteses = false, fe = false, hyp = false;
        string deg = "deg";
        Panel pnHis, pnMem;
        Label lbl1His, lbl2His, lbl1Mem;
        int nHis = 1, nMem = 1;
        Label[] lb1His = new Label[0], lb2His = new Label[0], lb1Mem = new Label[0];

       

        private void PnCliqueMem(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            string a = panel.Name.Remove(0, 2);
            lbl1Mem = lb1Mem[int.Parse(a) - 1];

            lblResultado.Text = lbl1Mem.Text;

            vaiMudar = false;
            fechaParenteses = false;
        }

        private void PnFoco(object sender, EventArgs e)
        {
            Panel pn = sender as Panel;
            pn.BackColor = Color.Silver;
        }

        private void PnForaFoco(object sender, EventArgs e)
        {
            Panel pn = sender as Panel;
            pn.BackColor = Color.Transparent;
        }

        private void PnCliqueHis(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            string a = panel.Name.Remove(0, 2);
            lbl1His = lb1His[int.Parse(a) - 1];
            lbl2His = lb2His[int.Parse(a) - 1];

            lblResultado.Text = lbl2His.Text;
            lblConta.Text = lbl1His.Text.Remove(lbl1His.Text.Length - 2, 2);

            vaiMudar = false;
            fechaParenteses = false;
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btNum_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (lblResultado.Text == "0" || vaiMudar)
            {
                lblResultado.Text = "";
                vaiMudar = false;
            }
            lblResultado.Text += bt.Text;
        }

        private void btOpe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string aux;
            if (fe)
                aux = double.Parse(lblResultado.Text).ToString("0.###E+0");
            else
                aux = lblResultado.Text;
            if (fe)
                lblResultado.Text = Evaluate(lblConta.Text + lblResultado.Text).ToString("0.###E+0");
            else
                lblResultado.Text = Evaluate(lblConta.Text + lblResultado.Text).ToString();
            if (fechaParenteses)
                lblConta.Text += " " + btn.Text + " ";
            else
                lblConta.Text += aux + " " + btn.Text + " ";
            vaiMudar = true;
        }


        private double Evaluate(string expression)
        {
            expression = expression.Replace(",", ".");
            expression = expression.Replace("÷", "/");
            expression = expression.Replace("x", "*");
            
     try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);
                return double.Parse((string)row["expression"]);
            }
            catch
            {
                return double.Parse("0");
            }
        }

        private void btCE_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
        }

        private void btC_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            lblConta.Text = "";
        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = lblResultado.Text.Substring(0, lblResultado.Text.Length - 1);
        }

        private void btVirgula_Click(object sender, EventArgs e)
        {
            if (!lblResultado.Text.Contains(','))
            {
                lblResultado.Text += ",";
            }
        }

        private void btMaisMenos_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (double.Parse(lblResultado.Text) * -1).ToString();
        }

        private void btIgual_Click(object sender, EventArgs e)
        {
            string conta = lblConta.Text + lblResultado.Text;
            double resultado = Evaluate(conta);
            if (fe)
                lblResultado.Text = resultado.ToString("0.###E+0");
            else
                lblResultado.Text = resultado.ToString();
          
            lblConta.Text = "";
            vaiMudar = true;
        }

        private void CalculadoraC_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btxQuadrado_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.Pow(double.Parse(lblResultado.Text), 2).ToString();
            vaiMudar = true;
        }


        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void btxy_Click(object sender, EventArgs e)
        {
            string aux = lblResultado.Text;
            lblResultado.Text = Evaluate(lblConta.Text + lblResultado.Text).ToString();
            lblConta.Text += aux + " ^ ";
            vaiMudar = true;


            //verificar porque não calcula.
        }

        private void btSin_Click(object sender, EventArgs e)
        {

            if (hyp)
                lblResultado.Text = Math.Sinh(double.Parse(lblResultado.Text)).ToString();
            else
                lblResultado.Text = Math.Sin(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;

        }

        private void btCos_Click(object sender, EventArgs e)
        {
            if (hyp)
                lblResultado.Text = Math.Cosh(double.Parse(lblResultado.Text)).ToString();
            else
                lblResultado.Text = Math.Cos(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btTan_Click(object sender, EventArgs e)
        {
            if (hyp)
                lblResultado.Text = Math.Tanh(double.Parse(lblResultado.Text)).ToString();
            else
                lblResultado.Text = Math.Tan(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btxCubo_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.Pow(double.Parse(lblResultado.Text), 3).ToString();
            vaiMudar = true;
        }

        private void btRaizyx_Click(object sender, EventArgs e)
        {
            string aux = lblResultado.Text;
            lblResultado.Text = Evaluate(lblConta.Text + lblResultado.Text).ToString();
            lblConta.Text += aux + " yroot ";
            vaiMudar = true;
        }

        private void btSin1_Click(object sender, EventArgs e)
        {
            if (hyp)
                lblResultado.Text = Math.Pow(Math.Sinh(double.Parse(lblResultado.Text)), -1).ToString();
            else
                lblResultado.Text = Math.Asin(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btCos1_Click(object sender, EventArgs e)
        {
            if (hyp)
                lblResultado.Text = Math.Pow(Math.Cosh(double.Parse(lblResultado.Text)), -1).ToString();
            else
                lblResultado.Text = Math.Acos(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btRaiz_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.Sqrt(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void bt10Elevado_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.Pow(10, double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btLog_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.Log(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btExp_Click(object sender, EventArgs e)
        {
            string resultado = lblResultado.Text;
            if (resultado.Contains(','))
                lblResultado.Text = resultado + "E+";
            else
                lblResultado.Text = resultado + ",E+";
        }

        private void btMod_Click(object sender, EventArgs e)
        {
            string aux = lblResultado.Text;
            lblResultado.Text = Evaluate(lblConta.Text + lblResultado.Text).ToString();
            lblConta.Text += aux + " Mod ";
            vaiMudar = true;
        }

        private void btx1_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (1 / double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btex_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.Pow(Math.E, double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (Math.Log(double.Parse(lblResultado.Text)) / Math.Log(Math.E)).ToString();
            vaiMudar = true;
        }

        private void btDms_Click(object sender, EventArgs e)
        {
            lblResultado.Text = DecimalToMinutes(lblResultado.Text);
            vaiMudar = true;
        }

        private void btPi_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Math.PI.ToString();
            vaiMudar = true;
        }

        private void btDeg_Click(object sender, EventArgs e)
        {
            lblResultado.Text = DecimalToDegree(lblResultado.Text);
            vaiMudar = true;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExclamacao_Click(object sender, EventArgs e)
        {
            double num = double.Parse(lblResultado.Text);
            double fatorial = 1;
            for (double i = num; i > 0; i--)
            {
                fatorial *= i;
            }
            lblResultado.Text = fatorial.ToString();
            vaiMudar = true;
        }

        private void btParenD_Click(object sender, EventArgs e)
        {
            lblConta.Text += " ( ";
            vaiMudar = true;
        }

        private void btFMenosE_Click(object sender, EventArgs e)
        {
            if (fe)
            {
                fe = false;
                btFMenosE.FlatAppearance.BorderSize = 0;
                lblResultado.Text = double.Parse(lblResultado.Text).ToString();
            }
            else
            {
                fe = true;
                btFMenosE.FlatAppearance.BorderColor = Color.Red;
                btFMenosE.FlatAppearance.BorderSize = 3;
                lblResultado.Text = double.Parse(lblResultado.Text).ToString("0.###E+0");
            }
        }

        private void btHYP_Click(object sender, EventArgs e)
        {
            if (hyp)
            {
                hyp = false;
                btHYP.FlatAppearance.BorderSize = 0;
            }
            else
            {
                hyp = true;
                btHYP.FlatAppearance.BorderColor = Color.Red;
                btHYP.FlatAppearance.BorderSize = 3;
            }
        }

        private void btTan1_Click(object sender, EventArgs e)
        {
            if (hyp)
                lblResultado.Text = Math.Pow(Math.Tanh(double.Parse(lblResultado.Text)), -1).ToString();
            else
                lblResultado.Text = Math.Atan(double.Parse(lblResultado.Text)).ToString();
            vaiMudar = true;
        }

        private void btDegDois_Click(object sender, EventArgs e)
        {
            if (deg == "deg")
            {
                btDegDois.Text = "RAD";
                deg = "rad";
            }
            else if (deg == "rad")
            {
                btDegDois.Text = "GRAD";
                deg = "grad";
            }
            else
            {
                btDegDois.Text = "DEG";
                deg = "deg";

            }
        }

            private void btParenE_Click(object sender, EventArgs e)
        {
            string aux = lblResultado.Text;
            lblConta.Text += aux + " ) ";
            vaiMudar = true;
            fechaParenteses = true;
        }
        private string DecimalToDegree(string dec)
        {
            double decimal_degrees = double.Parse(dec);
            int cont = int.Parse(((decimal_degrees - Math.Floor(decimal_degrees)) / 0.6).ToString().Split(',')[0]);
            string degree = (cont + Math.Floor(decimal_degrees)).ToString() + "," + ((decimal_degrees - Math.Floor(decimal_degrees)) / 0.6).ToString().Split(',')[1];
            return degree;
        }
        private string DecimalToMinutes(string dec)
        {
            double decimal_degrees = double.Parse(dec);
            int cont = int.Parse(((decimal_degrees - Math.Floor(decimal_degrees)) * 0.6).ToString().Split(',')[0]);
            string degree = (cont + Math.Floor(decimal_degrees)).ToString() + "," + ((decimal_degrees - Math.Floor(decimal_degrees)) / 0.6).ToString().Split(',')[1];
            return degree;
        }
    }
}
    
 


   
