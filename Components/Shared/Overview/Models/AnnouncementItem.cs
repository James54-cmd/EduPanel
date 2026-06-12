namespace EduPanel.Components.Shared.Overview.Models;

/// <summary>
/// A single announcement / company update shown in the left column of the
/// shared post-login <c>WelcomeOverview</c> view.
/// </summary>
public class AnnouncementItem
{
    /// <summary>Short category label, e.g. "Important", "New Feature", "Reminder".</summary>
    public string Badge { get; set; } = "";

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    /// <summary>Human-readable date, e.g. "October 24, 2026".</summary>
    public string Date { get; set; } = "";
}
