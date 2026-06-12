using MudBlazor;

namespace EduPanel.Components.Shared.Overview.Models;

/// <summary>
/// A single action tile shown in the Quick Actions hub (right column) of the
/// shared post-login <c>WelcomeOverview</c> view. Supply either a
/// <see cref="Href"/> for navigation or an <see cref="OnClick"/> callback.
/// </summary>
public class QuickAction
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public string Icon { get; set; } = Icons.Material.Filled.Bolt;

    /// <summary>Route to navigate to when the tile is clicked. Ignored when <see cref="OnClick"/> is set.</summary>
    public string? Href { get; set; }

    /// <summary>Custom handler invoked when the tile is clicked. Takes precedence over <see cref="Href"/>.</summary>
    public Func<Task>? OnClick { get; set; }

    /// <summary>Theme color used to tint the tile's icon.</summary>
    public Color Color { get; set; } = Color.Primary;
}
