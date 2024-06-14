using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickZone : MonoBehaviour
{
    public TMP_Text mainMoneyValue;
    public TMP_Text priceAuCtxt;
    public TMP_Text aucDesc;
    public Button upgradeAuCButton;

    public TMP_Text priceClicktxt;
    public TMP_Text clickDesc;
    public Button upgradeClickButton;

    public TMP_Text priceTreetxt;
    public Button buyTreeButton;
    public GameObject[] trees;
    public GameObject TreeMoney;

    public TMP_Text priceStonetxt;
    public Button buyStoneButton;
    public GameObject[] stones;
    public GameObject StoneMoney;

    public TMP_Text priceSheeptxt;
    public Button buySheepButton;
    public GameObject[] sheeps;
    public GameObject SheepMoney;

    public TMP_Text priceCloudtxt;
    public Button buyCloudButton;
    public GameObject[] clouds;
    public GameObject CloudMoney;

    private int moneyValue = 0;

    [SerializeField] private int value = 15;
    [SerializeField] private float valueMultiplier = 2f;
    private int aucDescValue = 0;
    private bool isUpgrading = false;

    [SerializeField] private int valueClick = 100;
    [SerializeField] private int clickIncrement = 1;
    [SerializeField] private float clickMultiplier = 2f;

    [SerializeField] private int valueTree = 150;
    [SerializeField] private int treeIndex = 0;
    [SerializeField] private int treeIncrement = 150;

    [SerializeField] private int valueStone = 500;
    [SerializeField] private int stoneIndex = 0;
    [SerializeField] private int stoneIncrement = 300;
    [SerializeField] private int stoneMoneyIncrement = 10;

    [SerializeField] private int valueSheep = 1000;
    [SerializeField] private int sheepIndex = 0;
    [SerializeField] private int sheepIncrement = 600;
    [SerializeField] private int sheepMoneyIncrement = 15;

    [SerializeField] private int valueCloud = 3000;
    [SerializeField] private int cloudIndex = 0;
    [SerializeField] private int cloudIncrement = 1200;
    [SerializeField] private int cloudMoneyIncrement = 25;

    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip upgradeSound;
    [SerializeField] private AudioClip buyTree;
    [SerializeField] private AudioClip buyStone;
    [SerializeField] private AudioClip buyCloud;
    [SerializeField] private AudioClip buySheep;
    private AudioSource audioSource;

    public Transform worldTransform;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        mainMoneyValue.text = moneyValue.ToString();
        priceAuCtxt.text = value.ToString();
        aucDesc.text = "+0/s";
        upgradeAuCButton.onClick.AddListener(OnUpgradeAuCButtonClick);

        priceClicktxt.text = valueClick.ToString();
        clickDesc.text = "1 per Click";
        upgradeClickButton.onClick.AddListener(OnUpgradeClick);

        priceTreetxt.text = valueTree.ToString();
        buyTreeButton.onClick.AddListener(OnBuyTreeButtonClick);

        priceStonetxt.text = valueStone.ToString();
        buyStoneButton.onClick.AddListener(OnBuyStoneButtonClick);

        priceSheeptxt.text = valueSheep.ToString();
        buySheepButton.onClick.AddListener(OnBuySheepButtonClick);

        priceCloudtxt.text = valueCloud.ToString();
        buyCloudButton.onClick.AddListener(OnBuyCloudButtonClick);
    }

    void OnMouseDown()
    {
        moneyValue += clickIncrement;
        mainMoneyValue.text = moneyValue.ToString();
        PlaySound(clickSound);

        StartCoroutine(ShakeWorld());
    }

    void OnUpgradeAuCButtonClick()
    {
        if (moneyValue >= value)
        {
            moneyValue -= value;
            mainMoneyValue.text = moneyValue.ToString();

            value = Mathf.RoundToInt(value * valueMultiplier);
            priceAuCtxt.text = value.ToString();

            if (!isUpgrading)
            {
                isUpgrading = true;
                aucDescValue = 1;
                InvokeRepeating("IncreaseMoneyValue", 1f, 1f);
            }
            else
            {
                aucDescValue++;
            }

            aucDesc.text = $"+{aucDescValue}/s";
            PlaySound(upgradeSound);
        }
    }

    void IncreaseMoneyValue()
    {
        moneyValue += aucDescValue;
        mainMoneyValue.text = moneyValue.ToString();
    }

    void OnUpgradeClick()
    {
        if (moneyValue >= valueClick)
        {
            moneyValue -= valueClick;
            mainMoneyValue.text = moneyValue.ToString();

            valueClick = Mathf.RoundToInt(valueClick * clickMultiplier);
            priceClicktxt.text = valueClick.ToString();

            clickIncrement++;
            clickDesc.text = $"{clickIncrement} per Click";
            PlaySound(upgradeSound);
        }
    }

    void OnBuyTreeButtonClick()
    {
        if (moneyValue >= valueTree && treeIndex < trees.Length)
        {
            moneyValue -= valueTree;
            mainMoneyValue.text = moneyValue.ToString();

            trees[treeIndex].SetActive(true);
            treeIndex++;

            valueTree += treeIncrement;
            priceTreetxt.text = valueTree.ToString();

            if (treeIndex == 1)
            {
                InvokeRepeating("IncreaseTreeMoneyValue", 1f, 1f);
            }

            if (treeIndex >= trees.Length)
            {
                buyTreeButton.gameObject.SetActive(false);
                priceTreetxt.gameObject.SetActive(false);
                TreeMoney.gameObject.SetActive(false);
            }
            PlaySound(buyTree);
        }
    }

    void IncreaseTreeMoneyValue()
    {
        moneyValue += treeIndex * 5;
        mainMoneyValue.text = moneyValue.ToString();
    }

    void OnBuyStoneButtonClick()
    {
        if (moneyValue >= valueStone && stoneIndex < stones.Length)
        {
            moneyValue -= valueStone;
            mainMoneyValue.text = moneyValue.ToString();

            stones[stoneIndex].SetActive(true);
            stoneIndex++;

            valueStone += stoneIncrement;
            priceStonetxt.text = valueStone.ToString();

            if (stoneIndex == 1)
            {
                InvokeRepeating("IncreaseStoneMoneyValue", 1f, 1f);
            }

            if (stoneIndex >= stones.Length)
            {
                buyStoneButton.gameObject.SetActive(false);
                priceStonetxt.gameObject.SetActive(false);
                StoneMoney.gameObject.SetActive(false);
            }
            PlaySound(buyStone);
        }
    }

    void IncreaseStoneMoneyValue()
    {
        moneyValue += stoneIndex * stoneMoneyIncrement;
        mainMoneyValue.text = moneyValue.ToString();
    }

    void OnBuySheepButtonClick()
    {
        if (moneyValue >= valueSheep && sheepIndex < sheeps.Length)
        {
            moneyValue -= valueSheep;
            mainMoneyValue.text = moneyValue.ToString();

            sheeps[sheepIndex].SetActive(true);
            sheepIndex++;

            valueSheep += sheepIncrement;
            priceSheeptxt.text = valueSheep.ToString();

            if (sheepIndex == 1)
            {
                InvokeRepeating("IncreaseSheepMoneyValue", 1f, 1f);
            }

            if (sheepIndex >= sheeps.Length)
            {
                buySheepButton.gameObject.SetActive(false);
                priceSheeptxt.gameObject.SetActive(false);
                SheepMoney.gameObject.SetActive(false);
            }
            PlaySound(buySheep);
        }
    }

    void IncreaseSheepMoneyValue()
    {
        moneyValue += sheepIndex * sheepMoneyIncrement;
        mainMoneyValue.text = moneyValue.ToString();
    }

    void OnBuyCloudButtonClick()
    {
        if (moneyValue >= valueCloud && cloudIndex < clouds.Length)
        {
            moneyValue -= valueCloud;
            mainMoneyValue.text = moneyValue.ToString();

            clouds[cloudIndex].SetActive(true);
            cloudIndex++;

            valueCloud += cloudIncrement;
            priceCloudtxt.text = valueCloud.ToString();

            if (cloudIndex == 1)
            {
                InvokeRepeating("IncreaseCloudMoneyValue", 1f, 1f);
            }

            if (cloudIndex >= clouds.Length)
            {
                buyCloudButton.gameObject.SetActive(false);
                priceCloudtxt.gameObject.SetActive(false);
                CloudMoney.gameObject.SetActive(false);
            }
            PlaySound(buyCloud);
        }
    }

    void IncreaseCloudMoneyValue()
    {
        moneyValue += cloudIndex * cloudMoneyIncrement;
        mainMoneyValue.text = moneyValue.ToString();
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    IEnumerator ShakeWorld()
    {
        Vector3 originalPosition = worldTransform.position;
        float elapsed = 0.0f;
        float duration = 0.5f;
        float magnitude = 1f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            worldTransform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        worldTransform.position = originalPosition;
    }
}