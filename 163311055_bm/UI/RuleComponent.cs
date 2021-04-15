using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _163311055_bm.Classes;

namespace _163311055_bm
{
    public partial class RuleComponent : UserControl
    {
        #region Constructor

        /// <summary>
        /// The RuleComponent Constructor
        /// </summary>
        public RuleComponent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The RuleComponent in parameter constructor
        /// </summary>
        /// <param name="rule1"></param>
        /// <param name="rule2"></param>
        /// <param name="rule3"></param>
        public RuleComponent(string rule1, string rule2, string rule3) : this()
        {
            this.SuspendLayout();
            label1.Text = rule1;
            label2.Text = rule2;
            label3.Text = rule3;
            this.ResumeLayout();
        }
        /// <summary>
        /// The RuleComponent in parameter get this constructor
        /// </summary>
        /// <param name="rules"></param>
        public RuleComponent(Rules rules) : this()
        {
            TheSetRules(rules);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Listelemede renklendirmeler ayarlanıyor. Gelen fonsiyon türüne göre renk ayarlaması yapılmaktadır.
        /// </summary>
        /// <param name="kural"></param>
        public void TheSetRules(Rules kural)
        {
            this.SuspendLayout();
            label1.Text = kural.ToString(EnumValues.InputValues.Hassaslık);
            label2.Text = kural.ToString(EnumValues.InputValues.Miktar);
            label3.Text = kural.ToString(EnumValues.InputValues.Kirlilik);

            #region Hassaslık ise
            switch (kural.Hassaslık)
            {
                case EnumValues.Hassaslık.sağlam:
                    label1.ForeColor = Color.White;
                    break;
                case EnumValues.Hassaslık.orta:
                    label1.ForeColor = Color.Aqua;
                    break;
                case EnumValues.Hassaslık.hassas:
                    label1.ForeColor = Color.MediumPurple;
                    break;
            }
            #endregion
            #region Miktar ise
            switch (kural.Miktar)
            {
                case EnumValues.Miktar.kucuk:
                    label2.ForeColor = Color.White;
                    break;
                case EnumValues.Miktar.orta:
                    label2.ForeColor = Color.Aqua;
                    break;
                case EnumValues.Miktar.buyuk:
                    label2.ForeColor = Color.MediumPurple;
                    break;
            }
            #endregion
            #region Kirlilik ise
            switch (kural.Kirlilik)
            {
                case EnumValues.Kirlilik.kucuk:
                    label3.ForeColor = Color.White;
                    break;
                case EnumValues.Kirlilik.orta:
                    label3.ForeColor = Color.Aqua;
                    break;
                case EnumValues.Kirlilik.buyuk:
                    label3.ForeColor = Color.MediumPurple;
                    break;
            }
            #endregion

            label5.Text = kural.GetIntersectionX[0].ToString();
            label7.Text = kural.GetIntersectionX[1].ToString();
            label9.Text = kural.GetIntersectionX[2].ToString();

            label5.Text = label5.Text.Length > 5 ? label5.Text.Substring(0, 5) : label5.Text;
            label7.Text = label7.Text.Length > 5 ? label7.Text.Substring(0, 5) : label7.Text;
            label9.Text = label9.Text.Length > 5 ? label9.Text.Substring(0, 5) : label9.Text;

            this.ResumeLayout();
        }

        #endregion
    }
}
