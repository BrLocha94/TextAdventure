
public interface Interacteble
{
    string Interact();

    Trigger HasEventAssociated();

    InteractebleType GetInteractableType();

    string GetCharacterName();
}

public enum InteractebleType
{
    CHARACTER,
    OBJECT
}
