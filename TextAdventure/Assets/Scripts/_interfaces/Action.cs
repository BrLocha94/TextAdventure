
public interface Action
{
    Results Randomize();

    Results Execute();

    ActionType GetActionType();
}

public enum Results
{
    OUTSTANDING,
    SUCESS,
    FAIL,
    CATASTROFIC
}

public enum ActionType
{
    CLOSE,
    CUT,
    INSPECT,
    OPEN,
    PIC,
    THROW
}