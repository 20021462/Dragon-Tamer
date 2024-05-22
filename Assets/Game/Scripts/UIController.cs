using MalbersAnimations.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

    [SerializeField] private Button myRoomButton;
    [SerializeField] private Button adventureButton;
    [SerializeField] private ScrollRect scrollRect;


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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //OnNameChanged(nameVar.Value);
        //OnLevelChanged(levelVar.Value);
        //OnExpChanged(expVar.Value);
        //OnGoldChanged(goldVar.Value);
        nameVar.Value = PlayerPrefs.GetString("name", "Blaze");
        levelVar.Value = PlayerPrefs.GetInt("level", 1);
        expVar.Value = PlayerPrefs.GetInt("exp", 0);
        goldVar.Value = PlayerPrefs.GetInt("gold", 0);
    }

    public void ClickChat()
    {
        chatPanel.SetActive(!chatPanel.activeSelf);
    }

    private void OnNameChanged(string name)
    {
        PlayerPrefs.SetString("name", name);

        nameText.text = name;
        nameChatText.text = name;
    }

    private void OnLevelChanged(int level)
    {
        PlayerPrefs.SetInt("level", level);

        levelText.text = level.ToString();
        nextExp = 480 + (int)(20 * Mathf.Pow(2, level - 1));
    }

    private void OnExpChanged(int exp)
    {
        PlayerPrefs.SetInt("exp", exp);

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

        GameManager.Instance.SendTrigger("item_collected");
    }

    public void OnGoldChanged(int gold)
    {
        PlayerPrefs.SetInt("gold", gold);

        goldText.text = AbbreviationUtility.AbbreviateNumber(gold);
    }

    public void ChangeButton(bool myRoomMode)
    {
        myRoomButton.gameObject.SetActive(!myRoomMode);
        adventureButton.gameObject.SetActive(myRoomMode);
    }

    public void ScrollToBottom()
    {
        scrollRect.verticalNormalizedPosition = 0;
    }
}
