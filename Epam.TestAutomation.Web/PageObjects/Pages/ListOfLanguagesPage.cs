using Epam.TestAutomation.Core.BasePage;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class ListOfLanguagesPage : BasePage
{
    public override string Url => "https://www.epam.com/";
    
    public List<string> listOfLanguages = new List<string> { "Global (English)", "Česká Republika (Čeština)", "Czech Republic (English)", "DACH (Deutsch)", "Hungary (English)", "India (English)", "日本 (日本語)","Polska (Polski)","СНГ (Русский)", "Україна (Українська)", "中国 (中文)"};
}