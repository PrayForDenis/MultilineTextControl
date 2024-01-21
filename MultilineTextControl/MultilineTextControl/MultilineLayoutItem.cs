using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.WinForms.Design.LayoutItems;
using DocsVision.Platform.Data.Metadata.CardModel;
using System.Windows.Forms;

namespace MultilineTextControl
{
    public class MultilineLayoutItem : FixedLayoutControlItem<MultilineControl>
    {
        public override string ItemTypeName
        {
            get
            {
                return "Собственный многострочный текст";
            }
        }

        public override System.Drawing.Image CustomizationImage
        {
            get
            {
                return MultilineTextControl.Properties.Resources.ButtonIcon.ToBitmap();
            }
        }

        public override LayoutsPropertyType PropertyType
        {
            get { return LayoutsPropertyType.String; }
        }

        public override FieldType[] GetSupportedFieldTypes()
        {
            return new FieldType[]
            {
                FieldType.Text
            };
        }
    }
}
