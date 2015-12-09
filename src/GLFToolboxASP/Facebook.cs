using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("GLFToolboxASP.images.facebook_bred.png", "img/png")]
[assembly: WebResource("GLFToolboxASP.facebook_bred.png", "img/png")]
[assembly: TagPrefix("GLFToolboxASP", "Facebook")]
namespace GLFToolboxASP
{
    [ToolboxData("<{0}:FacebookButton runat=\"server\"> </{0}:FacebookButton>")]
    public class FacebookButton : CompositeControl
    {
        ImageButton imageButton;

        protected override void CreateChildControls()
        {
            //Create button
            imageButton = new ImageButton();
            imageButton.ID = "facebookImageButton";
            imageButton.Width = Unit.Pixel(200);
            imageButton.Height = Unit.Pixel(37);
            imageButton.Click += new ImageClickEventHandler(imageButton_Click);
            imageButton.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "GLFToolboxASP.images.facebook_bred.png");

            //Add child controls to CustomCalendar control
            this.Controls.Add(imageButton);
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
            //Render the button
            imageButton.RenderControl(writer);
        }
    }
}
