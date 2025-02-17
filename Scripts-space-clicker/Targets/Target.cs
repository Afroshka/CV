using System;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    private TargetLoader targetLoader;

    [Header("Target Properties")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject rewardObj;
    [HideInInspector] public double currentHealth;
    private double maxHealth = 100;

    private TextMeshProUGUI currentHealthText;
    private TextMeshProUGUI maxHealthText;

    private uint targetLevel; 
    public new string name;

    private void Awake()
    {
        gameObject.name = name;
        InitializeCard();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("LastTarget", int.Parse(gameObject.name));
        targetLoader = FindObjectOfType<TargetLoader>();
        FindHealthTextsAndAttachToPanel();
        UpdateHealthBar();
    }

    public void TakeDamage(double value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            targetLoader.SpawnTargetDestroyedPanel(name);
            DestroyTarget();
            targetLoader.SpawnNextTarget(GetNextTarget(), NextTargetPosition());
        }
        UpdateHealthBar();
    }

    private void DestroyTarget()
    {
        SpawnReward();
        Destroy(gameObject);
    }

    private void UpdateHealthBar()
    {
        float healthPercent = Convert.ToSingle((currentHealth / maxHealth) * 100);
        healthBar.maxValue = 100; 
        healthBar.value = healthPercent;
        currentHealthText.text = "" + ((BigInteger)currentHealth).ToString("N0");
    }

    private void InitializeCard()
    {
        targetLevel = uint.Parse(name);

        for (uint i = 0; i < targetLevel; i++)
        {
            maxHealth *= 2;
        }
        if (currentHealth == 0)
        {
            currentHealth = maxHealth;
        }
    }

    private void FindHealthTextsAndAttachToPanel()
    {
        maxHealthText = GameObject.Find("MaxHealthText").GetComponent<TextMeshProUGUI>();
        currentHealthText = GameObject.Find("CurrentHealthText").GetComponent<TextMeshProUGUI>();

        while (maxHealthText == null || currentHealthText == null)
        {
            Debug.Log("error finding texts. Trying again");
            maxHealthText = GameObject.Find("MaxHealthText").GetComponent<TextMeshProUGUI>();
            currentHealthText = GameObject.Find("CurrentHealthText").GetComponent<TextMeshProUGUI>();
        }
        Debug.Log("Health Texts Succesfully found");

        maxHealthText.text = "" + ((BigInteger)maxHealth).ToString("N0");
        currentHealthText.text = "" + ((BigInteger)currentHealth).ToString("N0");
    }
    private void SpawnReward()
    {
        UnityEngine.Vector3 rewardSpawnPos = new (transform.position.x, 5, transform.position.z);
        Instantiate(rewardObj, rewardSpawnPos, UnityEngine.Quaternion.identity);
    }

    private UnityEngine.Vector3 NextTargetPosition()
    {
        UnityEngine.Vector3 nextPos = new(transform.position.x, transform.position.y + 5, transform.position.z + 30);
        return nextPos;
    }

    private GameObject GetNextTarget()
    {
        int targetNumber = int.Parse(gameObject.name) + 1;
        GameObject nextTarget = Resources.Load<GameObject>(targetNumber.ToString());
        return nextTarget;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("healthOnExit", currentHealth.ToString());
        PlayerPrefs.Save();
    }

    //private void CheckTargets()
    //{
    //    int targets = FindObjectsOfType<Target>().Length;
    //    if (targets > 2)
    //    {
    //        Destroy(gameObject);
    //        Debug.Log("destroyed");
    //    }
    //    Debug.Log(targets);
    //}
}
