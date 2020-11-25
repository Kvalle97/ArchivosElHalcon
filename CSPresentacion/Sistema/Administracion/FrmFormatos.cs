using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Properties;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.CodeParser;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario de formatos
    /// </summary>
    public partial class FrmFormatos : XtraForm
    {
        //private readonly ServicioFormatos servicio = new ServicioFormatos();
        
        HTMLSyntaxHighlightService s;
        /// <summary>
        /// Contructor
        /// </summary>
        public FrmFormatos()
        {
            InitializeComponent();

            s=  new HTMLSyntaxHighlightService(richEditControl1);
            richEditControl1.ReplaceService<ISyntaxHighlightService>(s);

            using (IRichEditDocumentServer server = richEditControl1.CreateDocumentServer())
            {
                server.Text = "some HTML text";
                richEditControl1.Text = server.HtmlText;
            }

            richEditControl1.Document.DefaultCharacterProperties.FontName = "Consolas";
            richEditControl1.Document.DefaultCharacterProperties.FontSize = 9;

            richEditControl1.LoadDocument(File.OpenRead("C:\\HalconLogs\\prueba.html"), DocumentFormat.PlainText);
            //richEditControl1.ForceSyntaxHighlight();

            richEditControl1.Document.Sections[0].Page.Width = 10000;

            lookUpEdit1.Properties.DataSource = s.TokensMapping;
            lookUpEdit1.Properties.DisplayMember = "Key";
            lookUpEdit1.Properties.ValueMember = "Key";
        }

        private void EnviarCorreo()
        {
            //try
            //{
            //    MailMessage correo = new MailMessage();
            //    SmtpClient servidor = new SmtpClient("192.168.0.9");

            //    servidor.Port = 25;

            //    correo.From = new MailAddress("admin@elhalcon.com.ni");

            //    correo.To.Add("agaitan@elhalcon.com.ni");
            //    correo.Subject = "Cumpleañeros";
            //    //correo.CC.Add("informatica@elhalcon.com.ni");

            //    string cuerpo = servicio.ObtenerFormato();

            //    correo.Body = cuerpo;
            //    correo.IsBodyHtml = true;

            //    servidor.Credentials = new NetworkCredential("admin@elhalcon.com.ni", "e8ad1bHjr");
            //    servidor.EnableSsl = false;

            //    servidor.SendAsync(correo, null);

            //    servidor.SendCompleted += (s, args) =>
            //    {
            //        alertControl.Show(this, "Correo enviado con exito", "Se envió el correo al destinatario",
            //            Resources.adjuntar);
            //    };
            //}
            //catch (Exception ex)
            //{
            //    UIHelper.MostrarError(ex);
            //}
        }

        private void MostrarFelicitacion()
        {
            //string nombreDelArchivo = Path.GetTempPath() + "Felicidades.html";

            //File.WriteAllText(nombreDelArchivo,servicio.ObtenerFormato());

            //System.Diagnostics.Process.Start(nombreDelArchivo);

            ////webBrowser1.DocumentText = servicio.ObtenerFormato();
        }

        private void FrmFormatos_Load(object sender, EventArgs e)
        {
            MostrarFelicitacion();
        }

        public class HTMLSyntaxHighlightService : ISyntaxHighlightService
        {
            readonly RichEditControl syntaxEditor;

            public Dictionary<TokenCategory, SyntaxHighlightProperties> TokensMapping =
                new Dictionary<TokenCategory, SyntaxHighlightProperties>();

            SyntaxHighlightProperties textProperties;

            void AddTokensMapping(TokenCategory category, Color foreColor)
            {
                SyntaxHighlightProperties tokenProperties = new SyntaxHighlightProperties {ForeColor = foreColor};
                TokensMapping.Add(category, tokenProperties);
            }

            SyntaxHighlightProperties GetTokensMapping(TokenCategory category)
            {
                if (TokensMapping.ContainsKey(category)) return TokensMapping[category];
                else return textProperties;
            }

            public HTMLSyntaxHighlightService(RichEditControl syntaxEditor)
            {
                this.syntaxEditor = syntaxEditor;
            }

            void HighlightSyntax(TokenCollection tokens)
            {
                if (TokensMapping.Count == 0)
                {
                    AddTokensMapping(TokenCategory.HtmlAttributeName, ColorTranslator.FromHtml("#795da3"));
                    AddTokensMapping(TokenCategory.HtmlAttributeValue, Color.Yellow);
                    AddTokensMapping(TokenCategory.HtmlComment, Color.Green);
                    AddTokensMapping(TokenCategory.HtmlElementName, Color.Brown);
                    AddTokensMapping(TokenCategory.HtmlEntity, Color.Green);
                    AddTokensMapping(TokenCategory.HtmlOperator, ColorTranslator.FromHtml("#333"));
                    AddTokensMapping(TokenCategory.HtmlServerSideScript, Color.Gray);
                    AddTokensMapping(TokenCategory.HtmlString, Color.Black);
                    AddTokensMapping(TokenCategory.HtmlTagDelimiter, ColorTranslator.FromHtml("#183691"));
                    AddTokensMapping(TokenCategory.CssComment, Color.Green);
                    AddTokensMapping(TokenCategory.CssKeyword, Color.Red);
                    AddTokensMapping(TokenCategory.CssPropertyName, Color.Red);
                    AddTokensMapping(TokenCategory.CssPropertyValue, Color.Blue);
                    AddTokensMapping(TokenCategory.CssSelector, Color.Brown);
                    AddTokensMapping(TokenCategory.CssStringValue, ColorTranslator.FromHtml("#183691"));

                    textProperties = new SyntaxHighlightProperties {ForeColor = Color.Black};
                }

                if (tokens == null || tokens.Count == 0)
                    return;

                Document document = syntaxEditor.Document;
                List<SyntaxHighlightToken> syntaxTokens = new List<SyntaxHighlightToken>(tokens.Count);
                foreach (Token token in tokens)
                {
                    HighlightCategorizedToken((CategorizedToken) token, syntaxTokens);
                }

                document.ApplySyntaxHighlight(syntaxTokens);
            }

            void HighlightCategorizedToken(CategorizedToken token, List<SyntaxHighlightToken> syntaxTokens)
            {
                Color backColor = syntaxEditor.ActiveView.BackColor;
                TokenCategory category = token.Category;
                syntaxTokens.Add(SetTokenColor(token, GetTokensMapping(category), backColor));
            }

            SyntaxHighlightToken SetTokenColor(Token token, SyntaxHighlightProperties foreColor, Color backColor)
            {
                if (syntaxEditor.Document.Paragraphs.Count < token.Range.Start.Line)
                    return null;
                int paragraphStart =
                    DocumentHelper.GetParagraphStart(syntaxEditor.Document.Paragraphs[token.Range.Start.Line - 1]);
                int tokenStart = paragraphStart + token.Range.Start.Offset - 1;
                if (token.Range.End.Line != token.Range.Start.Line)
                    paragraphStart =
                        DocumentHelper.GetParagraphStart(syntaxEditor.Document.Paragraphs[token.Range.End.Line - 1]);

                int tokenEnd = paragraphStart + token.Range.End.Offset - 1;

                return new SyntaxHighlightToken(tokenStart, tokenEnd - tokenStart, foreColor);
            }

            #region #ISyntaxHighlightServiceMembers

            public void Execute()
            {
                string newText = syntaxEditor.Text;
                // Use DevExpress.CodeParser to parse text into tokens.
                ITokenCategoryHelper tokenHelper = TokenCategoryHelperFactory.CreateHelper(ParserLanguageID.Html);
                TokenCollection highlightTokens;
                highlightTokens = tokenHelper.GetTokens(newText);
                HighlightSyntax(highlightTokens);
            }

            public void ForceExecute()
            {
                Execute();
            }

            #endregion #ISyntaxHighlightServiceMembers
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            s.TokensMapping[(TokenCategory) lookUpEdit1.EditValue].ForeColor = colorPickEdit1.Color;
            
            var txt = richEditControl1.Text;
            richEditControl1.Text = string.Empty;
            richEditControl1.Text = txt;
        }
    }
}