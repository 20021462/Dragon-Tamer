using MalbersAnimations.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject chatPanel;

    [Header("Variable Asset")]
    [SerializeField] private StringReference nameVar;
    [SerializeField] private IntReference levelVar;
    [SerializeField] private IntReference expVar;
    [SerializeField] private IntReference goldVar;

    [Header("UI Component")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI nameChatText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider expSlider;

    private int nextExp;

    private void OnEnable()
    {
        nameVar.Variable.OnValueChanged += OnNameChanged;
        levelVar.Variable.OnValueChanged += OnLevelChanged;
        expVar.Variable.OnValueChanged += OnExpChanged;
        goldVar.Variable.OnValueChanged += OnGoldChanged;
    }

    private void OnDisable()
    {
        nameVar.Variable.OnValueChanged -= OnNameChanged;
        levelVar.Variable.OnValueChanged -= OnLevelChanged;
        expVar.Variable.OnValueChanged -= OnExpChanged;
        goldVar.Variable.OnValueChanged -= OnGoldChanged;
    }

    private void Start()
    {
        OnNameChanged(nameVar.Value);
        OnLevelChanged(levelVar.Value);
        OnExpChanged(expVar.Value);
        OnGoldChanged(goldVar.Value);
    }

    public void ClickChat()
    {
        chatPanel.SetActive(!chatPanel.activeSelf);
    }

    private void OnNameChanged(string name)
    {
        nameText.text = name;
        nameChatText.text = name;
    }

    private void OnLevelChanged(int level)
    {
        levelText.text = level.ToString();
        nextExp = 480 + (int)(20 * Mathf.Pow(2, level - 1));
    }

    private void OnExpChanged(int exp)
    {
        string text = AbbreviationUtility.AbbreviateNumber(exp);
        text += "/" + AbbreviationUtility.AbbreviateNumber(nextExp);
        expText.text = text;

        float levelPercent = (float)exp / nextExp;
        expSlider.value = levelPercent;

        if (exp >= nextExp)
        {
            levelVar.Value++;
            expVar.Value = exp - nextExp;
        }
    }

    public void OnGoldChanged(int gold)
    {
        goldText.text = AbbreviationUtility.AbbreviateNumber(gold);
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadSceneAsync("Playground", LoadSceneMode.Single);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync("MyRoom", LoadSceneMode.Single);
    }
}
