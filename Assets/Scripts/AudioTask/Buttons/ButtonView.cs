using UnityEngine;
using UnityEngine.UI;

namespace AudioTask.Buttons
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable() =>
            _button.onClick.AddListener(OnClicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClicked);

        protected virtual void OnClicked()
        { }
    }
}