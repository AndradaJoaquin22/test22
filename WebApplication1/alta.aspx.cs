using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.IO;

namespace WebApplication1
{
    public partial class alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "datos";
                    cmd.Connection = conn;
                    conn.Open();
                    GvDatos.DataSource = cmd.ExecuteReader();
                    GvDatos.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s;
            try
            {
                s = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);

                conexion.Open();
                SqlCommand comando = new SqlCommand("insert into libros(nombre,genero,autor,cantidad,precio) values('" + this.TextBox1.Text + "','" + this.TextBox2.Text + "','" + this.TextBox3.Text + "','"+this.TextBox5.Text+"','"+this.TextBox6.Text+"')", conexion);
                comando.ExecuteNonQuery();
                this.Label4.Text = "estado: Se registró el libro";
                conexion.Close();
            }
            catch (SqlException ex)
            {
                this.Label4.Text = ex.Message;
            }

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            String s;
            try
            {
                s = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);


                SqlCommand cmd = new SqlCommand("eliminarlibro", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_libro", SqlDbType.Int);
                cmd.Parameters["@id_libro"].Value = TextBox4.Text;


                conexion.Open();


                int cant = cmd.ExecuteNonQuery();

                if (cant == 1)
                {

                    this.Label4.Text = "Se borro el libro";

                }
                else
                {

                    this.Label4.Text = "No existe un libro con dicho id";


                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                this.Label4.Text = ex.Message;
            }
            }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String s;
            try
            {
                s = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);

                SqlCommand cmd = new SqlCommand("actualiza", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_libro", SqlDbType.Int);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                cmd.Parameters.Add("@genero", SqlDbType.VarChar);
                cmd.Parameters.Add("@autor", SqlDbType.VarChar);
                cmd.Parameters.Add("@cantidad",SqlDbType.Int);
                cmd.Parameters.Add("@precio", SqlDbType.Float);

                cmd.Parameters["@id_libro"].Value = TextBox4.Text;
                cmd.Parameters["@nombre"].Value = TextBox1.Text;
                cmd.Parameters["@genero"].Value = TextBox2.Text;
                cmd.Parameters["@autor"].Value = TextBox3.Text;
                cmd.Parameters["@cantidad"].Value = TextBox5.Text;
                cmd.Parameters["@precio"].Value = TextBox6.Text;

                conexion.Open();
                int cant = cmd.ExecuteNonQuery();

                if (cant == 1)
                {

                    Label5.Text = "Usuario actualizado...";

                }
                else
                {
                    Label5.Text = "no encontrado..";

                    conexion.Close();
                }
            }catch (SqlException ex)
            {
                this.Label4.Text = ex.Message;
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String s;
            try
            {
                s = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);

                DataTable dt = new DataTable();
                String strSql;
                strSql = "busca";
                SqlDataAdapter da = new SqlDataAdapter(strSql, conexion);
                conexion.Open();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@id_libro", SqlDbType.Int).Value = TextBox4.Text;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["nombre"].ToString();
                    TextBox2.Text = dt.Rows[0]["genero"].ToString();
                    TextBox3.Text = dt.Rows[0]["autor"].ToString();
                }
                else
                {
                    Label4.Text = "Usuario no encontrado";

                }
            }
            catch (SqlException ex)
            {
                this.Label4.Text = ex.Message;
            }
        }
    }
}