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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void llBuildingOnTree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pForTree.Visible = true;
            pFoFormula.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pChangeOrder.Visible = false;
            pPhasedTree.Visible = false;
            pSyntax2.Visible = false;
            pSaving1.Visible = false;
            pMethods.Visible = false;
        }
        private void llBuildingOnFormula_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pFoFormula.Visible = true;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pPhasedTree.Visible = false;
            pChangeOrder.Visible = false;
            pSyntax2.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llAboutBDD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pBDD.Visible = true;
            pSyntax2.Visible = false;
            pFoFormula.Visible = false;
            pPhasedTree.Visible = false;
            pChangeOrder.Visible = false;
            pFuncAndVar.Visible = false;
            pForTree.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llInputFuncAndVar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = true;
            pChangeOrder.Visible = false;
            pPhasedTree.Visible = false;
            pSyntax2.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llChangeOrderInTree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pChangeOrder.Visible = true;
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pPhasedTree.Visible = false;
            pSyntax2.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llPhasedOutputTree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pPhasedTree.Visible = true;
            pChangeOrder.Visible = false;
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pSyntax2.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llSyntax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pSyntax2.Visible = true;
            pPhasedTree.Visible = false;
            pChangeOrder.Visible = false;
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llPhasedOutputFormula_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pPhasedTree.Visible = true;
            pChangeOrder.Visible = false;
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pSyntax2.Visible = false;
            pMethods.Visible = false;
            pSaving1.Visible = false;
        }

        private void llAutomaticOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pMethods.Visible = true;
            pPhasedTree.Visible = false;
            pChangeOrder.Visible = false;
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pSyntax2.Visible = false;
            pSaving1.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pSaving1.Visible = true;
            pMethods.Visible = false;
            pPhasedTree.Visible = false;
            pChangeOrder.Visible = false;
            pFoFormula.Visible = false;
            pForTree.Visible = false;
            pBDD.Visible = false;
            pFuncAndVar.Visible = false;
            pSyntax2.Visible = false;
        }


    }
}
