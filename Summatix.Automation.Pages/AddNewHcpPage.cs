using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Summatix.Automation.Core;
using Summatix.Automation.Pages.Common;
using Summatix.Automation.Configuration;
using System.Data;

namespace Summatix.Automation.Pages
{
    public class AddNewHcpPage : BasePage
    {

        private IWebDriver webDriver;
        By name = By.Id("hcp-name");
        By street = By.Id("street");
        By suburb = By.Id("suburb");
        By country = By.CssSelector("input[data-auto='CountryInput']");
        By postcode = By.Id("post-code");
        By phone = By.Id("phone");
        By timezones = By.Id("timezones");
        By businessnumber = By.Id("business-number");
        By email = By.Id("billing - email");
        By confirmemail = By.Id("confirm-billing-email");
        By descr = By.Id("description");
        By hcpfirstname = By.Id("hcp-admin-first-name");
        By hcplastname = By.Id("hcp-admin-last-name");
        By hcpemail = By.Id("hcp-admin-email");
        By addteamem = By.Id("add-team-member-details-button");
        By usersdiv = By.CssSelector("div[formarrayname='users']");
        By teammemberdiv = By.CssSelector("div[class='row form-group']");
        By tmfname = By.Id("hcp-team-member-first-name0");
        By tmlname = By.Id("hcp-team-member-last-name0");
        By tmrole = By.Id("hcp-team-member-role0");
        By tmemail = By.Id("hcp-team-member-email0");
        By tmMedical = By.Id("HcpTeamMemberMedicalLicenseNumber0");

        public AddNewHcpPage(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public void FillHcpdetails(DataSet templatename)
        {
            
            seleniumactions.TypeText(name, templatename.Tables[0].Rows[0][1].ToString());
            seleniumactions.TypeText(street, templatename.Tables[0].Rows[1][1].ToString());
            seleniumactions.TypeText(suburb, templatename.Tables[0].Rows[2][1].ToString());
            seleniumactions.selectdropdown(country, templatename.Tables[0].Rows[3][1].ToString());
            seleniumactions.TypeText(postcode, templatename.Tables[0].Rows[5][1].ToString());
            seleniumactions.TypeText(phone, templatename.Tables[0].Rows[6][1].ToString());
            //seleniumactions.TypeText(name, templatename.Tables[0].Rows[1][1].ToString());
            //seleniumactions.TypeText(name, templatename.Tables[0].Rows[1][1].ToString());
            //seleniumactions.TypeText(name, templatename.Tables[0].Rows[1][1].ToString());

        }
    }
}
