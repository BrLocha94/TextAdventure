
public interface ButtonEditor
{
    void OnButtonClick();

    ButtonEditorType GetButtonEditorType();
}

public enum ButtonEditorType
{
    NODE,
    ACTION,
    INTERACTABLE
}
