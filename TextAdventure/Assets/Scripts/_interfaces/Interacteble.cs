
public interface Interacteble
{
    string Interact();

    Trigger HasEventAssociated();

    InteractebleType GetInteractableType();
}

public enum InteractebleType
{
    CHARACTER,
    OBJECT
}
