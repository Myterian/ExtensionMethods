using Flax.Build;

public class ExtensionMethodsEditorTarget : GameProjectEditorTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for editor
        Modules.Add(nameof(ExtensionMethods));
    }
}
