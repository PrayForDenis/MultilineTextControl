using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHunspell;
using DocsVision.BackOffice.WinForms.Design.PropertyControls;
using DocsVision.Platform.ObjectModel;

namespace MultilineTextControl
{
    public partial class MultilineControl: System.Windows.Forms.UserControl, IPropertyControl
    {
        private readonly Hunspell _spellChecker;

        public MultilineControl()
        {
            this.InitializeComponent();
            _spellChecker = new Hunspell("ru_RU.aff", "ru_RU.dic");
        }

        #region Реализация интерфейса IPropertyControl

        public ObjectContext ObjectContext { get; set; }
        public bool AllowEdit { get; set; }
        public object ControlValue { get; set; }
        public string ToolTip { get; set; }
        public bool ShowBorder { get; set; }
        public bool Signed { get; set; }

        public event EventHandler ControlValueChanged;

        public void Commit() { }

        public object GetDefaultControlValue()
        {
            return null;
        }

        public object GetValueCopy()
        {
            return this.ControlValue;
        }

        #endregion

        private void checkButton_Click(object sender, EventArgs e)
        {
            textBox.BackColor = Color.White;

            if (string.IsNullOrEmpty(textBox.Text))
                return;

            if (!ValidateControl()) {
                ControlValue = null;
                ControlValueChanged?.Invoke(this, e);
                Commit();
                return;
            }

            ControlValue = textBox.Text;
            ControlValueChanged?.Invoke(this, e);
            Commit();
        }

        private bool ValidateControl()
        {
            string[] words = textBox.Text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!_spellChecker.Spell(words[i]))
                {
                    textBox.BackColor = Color.Red;
                    MessageBox.Show("Найдена ошибка в слове: " + words[i]);
                    return false;
                }
            }

            return true;
        }
    }
}
