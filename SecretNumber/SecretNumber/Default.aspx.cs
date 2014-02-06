using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecretNumber.Model;

namespace SecretNumber
{
    public partial class Default : System.Web.UI.Page
    {
        protected Secret Sess // sessions variabel
        {
            get { return (Secret)Session["Sess"]; }
            set { Session["Sess"] = value; }
        }

        Secret secret;

        protected void Page_Start(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                secret = new Secret();
                secret.Initalize();
                Sess = secret;
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            secret = Sess;

            var answer = secret.MakeGuess(int.Parse(InputField.Text)); // in med gissade talet i makeguess och spara resultatet i answer
            string answerText = OutputString(answer);

            foreach (int guess in secret.PreviousGuesses)
            {
                GuessHolder.Text += ("[" + guess + "] ");
            }

            if (secret.Number.HasValue) // slut på gissningar eller rätt svar så returnerar Number det hemliga talet
            {
                WinText.Text = (answerText + secret.Count + " försök! Det hemliga talet var: [" + secret.Number + "]").ToString();
                
                InputField.Enabled = false;
                Send.Enabled = false;
                GetNewNumber.Visible = true; 
                GetNewNumber.Focus();
            }
            else
            {
                WinText.Text = answerText;
            }
        }

        private string OutputString(Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.Low:
                    return "För lågt";

                case Outcome.High:
                    return "för högt";

                case Outcome.Correct:
                    return "Grattis du klarade det på: ";

                case Outcome.NoMoreGuesses:
                    return "Misslyckat! Du har haft dina: ";

                case Outcome.PreviousGuess:
                    return "Du har redan gissat på det här nummret. Prova igen";

                default:
                    return "Obefintligt";
            }
        }

        protected void GetNewNumber_Click(object sender, EventArgs e)
        {            
            secret = Sess;
            secret.Initalize();
        }
    }
}