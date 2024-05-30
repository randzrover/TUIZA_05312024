namespace Application.Items.Command.CreateItem;

public sealed record CreateItemRequest(string Name, string Description, string Category, string URL);
