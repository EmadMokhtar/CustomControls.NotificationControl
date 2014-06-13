using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CustomControls.NotificationControl
{
    [DefaultProperty("Message")]
    [ToolboxData(@"<{0}:NotificationControl ID=""Notificaiton"" runat=server></{0}:NotificationControl>")]
    [ToolboxBitmap(typeof(ResourceFinder), "CustomControls.NotificationControl.bmp")]
    public class NotificationControl : Control
    {

        #region Constants
        private const string JqueryResoruceName = "CustomControls.NotificationControl.Scripts.jquery-1.4.2.min.js";
        private const string JnotifyResoruceName = "CustomControls.NotificationControl.Scripts.jquery.jnotify.min.js";
        private const string StyleResourceName = "CustomControls.NotificationControl.Styles.jquery.jnotify.css";
        private const string NotificationScript = "$( function () {{ if(typeof $.jnotify === 'function') {{ $.jnotify('{0}', '{1}', {2}); }} }} );";
        private const string StickyNotificationScript = "$( function () {{ if(typeof $.jnotify === 'function') {{ $.jnotify('{0}', '{1}', true); }} }} );";
        #endregion

        #region Properties

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue(2000)]
        [Localizable(true)]
        [Description("The time to show each notification default: 2000 (in milliseconds) ")]
        public int Delay { get; set; }

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The message to display when notification appears.")]
        public string Message { get; set; }

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The notification type.")]
        public NotificationType Type { get; set; }

        [Bindable(false)]
        [Category("Behaviour")]
        [DefaultValue(true)]
        [Localizable(true)]
        [Description("Embded jQuery")]
        public bool EmbededjQuery { get; set; }

        #endregion

        #region Events

        protected override void OnPreRender(EventArgs e)
        {
            //Check for ScriptManager contorl
            if (ScriptManager.GetCurrent(Page) == null)
                throw new HttpException("A ScriptManager control must exist on the current page");

            //Register jQuery accodring to user settings 
            if (EmbededjQuery)
                ScriptManager.RegisterClientScriptResource(Page, typeof(NotificationControl), JqueryResoruceName);

            ScriptManager.RegisterClientScriptResource(Page, typeof(NotificationControl), JnotifyResoruceName);

            base.OnPreRender(e);

            //Register CSS file
            var cssSource = new HtmlLink { Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), StyleResourceName) };
            cssSource.Attributes["rel"] = "stylesheet";
            cssSource.Attributes["type"] = "text/css";
            Page.Header.Controls.Add(cssSource);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Shows Notiication.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="delay">The delay.</param>
        public void Show(string message, int delay = 2000)
        {
            var script = string.Format(NotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                ParseNotificationType(Type),
                delay);

            RegisterScript(script);
        }

        /// <summary>
        /// Shows the notification.
        /// </summary>
        public void Show()
        {
            var script = string.Format(NotificationScript,
                HttpUtility.JavaScriptStringEncode(Message),
                ParseNotificationType(Type),
                Delay);

            RegisterScript(script);
        }

        /// <summary>
        /// Show information notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="delay">The delay.</param>
        public void ShowInfo(string message, int delay = 2000)
        {
            var script = string.Format(NotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                string.Empty,
                delay);

            RegisterScript(script);
        }

        /// <summary>
        /// Show error notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="delay">The delay.</param>
        public void ShowError(string message, int delay = 2000)
        {
            var script = string.Format(NotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                "error",
                delay);

            RegisterScript(script);
        }

        /// <summary>
        /// Show wraning notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="delay">The delay.</param>
        public void ShowWraning(string message, int delay = 2000)
        {
            var script = string.Format(NotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                "warning",
                delay);

            RegisterScript(script);
        }

        public void ShowStickyInfo(string message)
        {
            var script = string.Format(StickyNotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                string.Empty);

            RegisterScript(script);
        }

        public void ShowStickyWarning(string message)
        {
            var script = string.Format(StickyNotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                "warning");

            RegisterScript(script);
        }

        public void ShowStickyError(string message)
        {

            var script = string.Format(StickyNotificationScript,
                HttpUtility.JavaScriptStringEncode(message),
                "error");

            RegisterScript(script);
        }

        private void RegisterScript(string script)
        {
            var scriptKey = Guid.NewGuid().ToString();

            ScriptManager.RegisterStartupScript(Page, this.GetType(), scriptKey,
                script,
                addScriptTags: true);
        }

        private string ParseNotificationType(NotificationType type)
        {
            return Enum.GetName(typeof(NotificationType), type).ToLower();
        }
        #endregion

    }
}
