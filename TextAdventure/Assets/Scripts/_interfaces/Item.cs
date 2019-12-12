using System.Collections.Generic;

public interface Item
{
    string GetDescription();

    string ExecuteAction(ActionType action);

    List<ActionType> GetUsabilities();
}
