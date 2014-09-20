using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAgencia.Account
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogIn(object sender, EventArgs e)
        {

            //UsuarioServiceClient pxUsuario = new UsuarioServiceClient();
            //SGAA_Usuario usu = pxUsuario.SelectById("");  

            if (IsValid)
            {
               string user = "jmallqui";
                // Validar la contraseña del usuario
                //var manager = new UserManager();
                //ApplicationUser user = manager.Find(UserName.Text, Password.Text);

               string clave = "1";
                if (txtUser.Text == user)
                {
                    if (clave == txtPassword.Text)
                    {
                        HttpContext.Current.Session["User"] = user;
                        //HttpContext.Current.Session["IdPersonal"] = user.Id_Perfil;
                        //HttpContext.Current.Session["NameFull"] = String.Format("{0}", user.ApeNom);

                        Response.Redirect(ResolveUrl("~/Default.aspx"));
                    }


                }
                else
                {
                    txtFailure.Text = "Invalido el usuario o contraseña";
                    txtFailure.Visible = true;
                }
            }
        }
    }
}