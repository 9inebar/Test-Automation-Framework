using System.ComponentModel;

namespace Epam.TestAutomation.Core.Enums;

public enum BrowserType
{
    [Description("Chrome")]
    Chrome,
    [Description("Safari")]
    Safari,
    [Description("Undefined")]
    Undefined
}