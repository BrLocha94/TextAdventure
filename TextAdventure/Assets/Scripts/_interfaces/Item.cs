using System.Collections.Generic;

public interface Item
{
    string GetDescription();

    string ExecuteAction(string action);

    List<Action> GetUsabilities();

    bool CheckAction(string type);
}
