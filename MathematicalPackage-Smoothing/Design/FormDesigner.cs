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
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepPurple200, Primary.DeepPurple300, Primary.DeepPurple500, Accent.DeepPurple700, TextShade.BLACK);
        }
    }
}
