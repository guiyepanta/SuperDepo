using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public class Numero : TextBox
    {

        public event EventHandler ValorChanged;

        #region Miembros privados

        private string mstrSeparadorDecimal;

        private int mintPosicionesDecimales = 2;

        private int mintPosicionesEnteras = 10;

        private string mstrValorAnterior = "";

        private bool mbooOnTextChanged = false;

        #endregion

        #region Constructor

        public Numero()
        {
            mInicializar();
        }

        #endregion

        #region Propiedades publicas

        public int PosicionesDecimales
        {
            get { return mintPosicionesDecimales; }
            set { mintPosicionesDecimales = value; }
        }

        public int PosicionesEnteras
        {
            get { return mintPosicionesEnteras; }
            set { mintPosicionesEnteras = value; }
        }

        public string Valor
        {   
            get { return (this.Text == "")?"":this.Text; }
            set 
            { 
                this.Text = value; 
            }
        }

        #endregion

        #region Overrides

        void Numero_Enter(object sender, EventArgs e)
        {
            if (this.Text == "")
                Valor = "";
            else if (this.Text != "")
            {
                this.SelectionStart = 0;
                this.SelectionLength = this.Text.Length;                
            }            
        }

        void Numero_click(object sender, EventArgs e)
        {
            
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;                       
        } 

        void Numero_Leave(object sender, EventArgs e)
        {
            if( this.Text == "" )
                Valor = "";
        }

        void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selec = "";
            if( mIsNumber(e.KeyChar) )
            {
                if( this.Text.IndexOf(mstrSeparadorDecimal) != -1 )
                {
                    e.Handled = true;
                    int lintSepPos = this.Text.IndexOf(mstrSeparadorDecimal);
                    if( this.Text.Length <= lintSepPos + mintPosicionesDecimales )
                    {
                        this.Text += e.KeyChar.ToString();
                        MoverAlFinal();
                    }
                }
                else
                {
                    e.Handled = true;
                    if( this.Text.Length < mintPosicionesEnteras )
                    {
                        if (this.SelectedText != "")
                            this.Text="";
                        this.Text += e.KeyChar.ToString();                        
                        MoverAlFinal();
                    }
                }
            }
            else if( ( e.KeyChar == '.' ) || ( e.KeyChar == ',' ) )
            {
                e.Handled = true;
                if( mintPosicionesDecimales != 0 )
                {
                    if( this.Text.IndexOf(mstrSeparadorDecimal) == -1 )
                    {
                        if( this.Text.Length == 0 )
                            this.Text += "";
                        this.Text += mstrSeparadorDecimal;
                        MoverAlFinal();
                    }
                }
            }
            else if( e.KeyChar == Convert.ToChar(8) )
            {
                // No hacer nada
            }
            else if( e.KeyChar == Convert.ToChar(9) || e.KeyChar == Convert.ToChar(13) )
            {
                if( mbooOnTextChanged )
                    OnValorChanged();
            }
            else
            {
                e.Handled = true;
            }
            MoverAlFinal();
        }

        #endregion

        #region Metodos publicos

        public void Limpiar()
        {
            this.Text = "";
        }

        #endregion

        #region Metodos privados

        private bool mIsNumber(char pChar)
        {
            return ( pChar == '1' ) ||
                ( pChar == '2' ) ||
                ( pChar == '3' ) ||
                ( pChar == '4' ) ||
                ( pChar == '5' ) ||
                ( pChar == '6' ) ||
                ( pChar == '7' ) ||
                ( pChar == '8' ) ||
                ( pChar == '9' ) ||
                ( pChar == '0' );
        }

        private void MoverAlFinal()
        {
            this.SelectionStart = this.Text.Length;
        }

        private void mInicializar()
        {
            this.KeyPress += new KeyPressEventHandler(Numero_KeyPress);
            this.Enter += new EventHandler(Numero_Enter);
            this.Leave += new EventHandler(Numero_Leave);
            this.Click += new EventHandler(Numero_click);
            this.TextAlign = HorizontalAlignment.Right;
            Valor = "";
            mstrSeparadorDecimal = ",";
            PosicionesDecimales = 0;
        }

        #endregion

        #region Manejo de eventos

        private void this_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            mbooOnTextChanged = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            mbooOnTextChanged = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if( mbooOnTextChanged )
                OnValorChanged();
        }

        public void OnValorChanged()
        {
            if( ValorChanged != null )
            {
                mbooOnTextChanged = false;
                ValorChanged(this, new EventArgs());
            }
        }      
        
        #endregion

    }
}
