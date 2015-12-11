using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenericLoginFramework;

[assembly: WebResource("GLFToolboxASP.images.google_bred.png", "img/png")]
[assembly: TagPrefix("GLFToolboxASP", "Google")]
namespace GLFToolboxASP
{
    [ToolboxData("<{0}:GoogleButton runat=\"server\"> </{0}:GoogleButton>")]
    public class GoogleButton : CompositeControl
    {
        ImageButton imageButton;

        protected override void CreateChildControls()
        {
            //Create button
            imageButton = new ImageButton();
            imageButton.ID = "GoogleImageButton";
            imageButton.Width = Unit.Pixel(200);
            imageButton.Height = Unit.Pixel(37);
            imageButton.Click += new ImageClickEventHandler(imageButton_Click);
            imageButton.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "GLFToolboxASP.images.google_bred.png");

            //Add child controls to Custom control
            this.Controls.Add(imageButton);
        }

        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect(@GenericLoginFramework.Providers.GoogleProvider.Instance.FullyQualifiedLoginEndpoint());
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //Render the button
            imageButton.RenderControl(writer);
        }
    }
}
