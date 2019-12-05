
public interface ButtonEditor
{
    void OnButtonClick();

    void Delete();

    ButtonEditorType GetButtonEditorType();
}

public enum ButtonEditorType
{
    NODE,
    ACTION,
    INTERACTABLE
}
