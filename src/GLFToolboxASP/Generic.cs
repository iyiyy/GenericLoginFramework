using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("GLFToolboxASP.images.generic_bred.png", "img/png")]
[assembly: TagPrefix("GLFToolboxASP", "Generic")]
namespace GLFToolboxASP
{
    [ToolboxData("<{0}:GenericLogin runat=\"server\"> </{0}:GenericLogin>")]
    public class GenericLogin : CompositeControl
    {
        ImageButton imageButton;
        TextBox usernameTxtbx;
        TextBox passwordTxtbx;
        Label usernameLbl;
        Label passwordLbl;
        Label breakLbl;

        protected override void CreateChildControls()
        {
            //Create button
            imageButton = new ImageButton();
            imageButton.ID = "GenericImageButton";
            imageButton.Width = Unit.Pixel(200);
            imageButton.Height = Unit.Pixel(37);
            imageButton.Click += new ImageClickEventHandler(imageButton_Click);
            imageButton.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "GLFToolboxASP.images.generic_bred.png");

            //Create username textbox
            usernameTxtbx = new TextBox();
            usernameTxtbx.ID = "UsernameTextbox";
            usernameTxtbx.Width = Unit.Pixel(200);
            usernameTxtbx.Height = Unit.Pixel(25);

            //Create password textbox
            passwordTxtbx = new TextBox();
            passwordTxtbx.ID = "UsernameTextbox";
            passwordTxtbx.Width = Unit.Pixel(200);
            passwordTxtbx.Height = Unit.Pixel(25);

            //Create labels
            usernameLbl = new Label();
            usernameLbl.Text = "Username<br />";
            passwordLbl = new Label();
            passwordLbl.Text = "<br />Password<br />";
            breakLbl = new Label();
            breakLbl.Text = "<br /><br />";

            this.Controls.Add(imageButton);
            this.Controls.Add(usernameTxtbx);
            this.Controls.Add(passwordTxtbx);
            this.Controls.Add(usernameLbl);
            this.Controls.Add(passwordLbl);
            this.Controls.Add(breakLbl);
        }

        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("http://www.google.com");
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //Render the controls
            usernameLbl.RenderControl(writer);
            usernameTxtbx.RenderControl(writer);
            passwordLbl.RenderControl(writer);
            passwordTxtbx.RenderControl(writer);
            breakLbl.RenderControl(writer);
            imageButton.RenderControl(writer);
        }
    }
}
