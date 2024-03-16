using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionText;

    [SerializeField] private TextMeshProUGUI _massageText;

    [SerializeField] private GameObject _panel;

    [SerializeField] private GameObject _buttonPrefab;

    [SerializeField] private UnityEvent OnRenderQuestionAndOptions;

    [SerializeField] private UnityEvent OnRenderMassage;


    private List<Button> _renderButtonsScript = new List<Button>();

    public void QuestionAndOptionsDisplay(Level level)
    {
        _questionText.text = level.Question;
        DestroyChilds();

        level.Options.Shuffle();
        Option[] options = level.Options;

        for (int i = 0; i < options.Length; i++)
        {
            var button = Instantiate(_buttonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            button.transform.SetParent(_panel.transform, false);
            button.SetActive(true);
            button.transform.localScale = Vector3.one;

            var Text = button.GetComponentInChildren<TextMeshProUGUI>();

            var option = options[i];
            Text.text = option.Value;
            var buttonScript = button.GetComponent<Button>();
            _renderButtonsScript.Add(buttonScript);

            buttonScript.onClick.AddListener(delegate
            {
                MassageDisplay(button,option);
                _renderButtonsScript.ForEach((x) => x.onClick.RemoveAllListeners());
            });
        }

        OnRenderQuestionAndOptions.Invoke();
    }

    private void MassageDisplay(GameObject button, Option option)
    {
        var imageButton = button.GetComponent<Image>();
        _massageText.text = option.Message;
        if (option.Truthful)
        {
            _massageText.color = Color.green;
            imageButton.color = Color.green;
        }
        else
        {
            _massageText.color = Color.red;
            imageButton.color = Color.red;
        }
        OnRenderMassage.Invoke();
    }

    private void DestroyChilds()
    {
        _renderButtonsScript.ForEach(x => Destroy(x.gameObject));
        _renderButtonsScript.Clear();   
    }
}
