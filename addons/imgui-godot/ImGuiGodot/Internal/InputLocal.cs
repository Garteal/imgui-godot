#if GODOT_PC
using Godot;
using ImGuiNET;

namespace ImGuiGodot.Internal;

internal sealed class InputLocal : Input
{
    protected override void UpdateMousePos(ImGuiIOPtr io)
    {
        // do not use global mouse position
    }

    protected override bool HandleEvent(InputEvent evt)
    {
        // no support for SubViewport widgets

        if (evt is InputEventMouseMotion mm)
        {
            var io = ImGui.GetIO();
            var mousePos = mm.Position;
            io.AddMousePosEvent(mousePos.X, mousePos.Y);
            mm.Dispose();
            return io.WantCaptureMouse;
        }
        return base.HandleEvent(evt);
    }
}
#endif
