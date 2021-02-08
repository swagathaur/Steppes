using UnityEngine;
using _Steppes.Source.Scripts.Input;
using Input = UnityEngine.Input;

public class InputController : MonoBehaviour
{
    public Button[] _buttons;
    public Trigger[] _triggers;

    private void Update()
    {
        foreach (Button button in _buttons)
        {
            button.Update();
        }
        foreach (Trigger trigger in _triggers)
        {
            trigger.Update();
        }
    }
}
