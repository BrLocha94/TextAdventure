using System.Collections.Generic;

public interface Item
{
    string GetDescription();

    List<ActionType> GetUsabilities();
}
