using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RefExpTextBox
{
    //данный комментарий лишь для проверки правильности работы git хаба
    // а это новый коммент для проверки гит бакэта блеа
    [ToolboxBitmap(typeof(RefExpTextBox))]
    public partial class RefExpTextBox: TextBox
    {
        public RefExpTextBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }


        private Color m_AlertColor = Color.Red;
       // private Boolean m_Valid = true;
        private Regex m_RegularExpression = new Regex("");
        private string m_s;

        [Description("Valid"), Category("MyProp")] 
        Boolean Valid
        {
            get
            {
                if (this.Text == "")
                    return true;
                if (m_RegularExpression.ToString() == "")
                    return true;
                return m_RegularExpression.IsMatch(this.Text);
            }
            /*set
            {
                m_Valid = value;
            }*/
        }

        [Description("Regular Expression"), Category("MyProp")] 
        public string RegularExpression
        {
            get 
            {
                return m_s;
            }
            set 
            {
                try
                {
                    m_s = value;
                    m_RegularExpression = new Regex(value);
                }
                catch
                {
                    m_s = value;
                    m_RegularExpression = new Regex("");
                }
            }
        }

        [Description("Alerted color"), Category("MyProp")]    
        public Color AlertColor
        {
            get
            {
                return m_AlertColor;
            }
            set
            {
                m_AlertColor = value;
                Invalidate();
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (Valid == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
           
            //base.OnValidating(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (Valid == true)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = m_AlertColor;
            }
           // base.OnTextChanged(e);
        }
    
    }
}





