using MaterialSkin;
using MaterialSkin.Controls;

namespace MathematicalPackage_Smoothing.Design
{
    class FormDesigner : MaterialForm
    {
        public FormDesigner()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange200, Primary.Orange300, Primary.BlueGrey500, Accent.LightBlue200, TextShade.BLACK);
        }
    }
}
