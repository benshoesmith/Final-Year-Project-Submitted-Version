using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour {

    [SerializeField]
    private Transform equippedItemsPanel;
    [SerializeField]
    private Sprite emptySprite;

    private WeaponManager weaponManager;
    private OffhandManager offhandManager;
    private HelmetManager helmetManager;
    private ChestplateManager chestplateManager;
    private PlatelegsManager platelegsManager;
    private BootsManager bootsManager;

    [SerializeField]
    private Transform totalStatsPanel;
    [SerializeField]
    private Sprite emptySlotSprite;

    [SerializeField]
    private Text attackLevelText;
    [SerializeField]
    private Text defenceLevelText;
    [SerializeField]
    private Text speedLevelText;

    [SerializeField]
    private Text mainHandStatText;
    [SerializeField]
    private Text offHandStatText;
    [SerializeField]
    private Text headStatText;
    [SerializeField]
    private Text bodyStatText;
    [SerializeField]
    private Text legsStatText;
    [SerializeField]
    private Text feetStatText;

    [SerializeField]
    private Image onhandIcon;
    [SerializeField]
    private Text onhandName;

    [SerializeField]
    private Image offhandIcon;
    [SerializeField]
    private Text offhandName;

    [SerializeField]
    private Image headIcon;
    [SerializeField]
    private Text headName;

    [SerializeField]
    private Image bodyIcon;
    [SerializeField]
    private Text bodyName;

    [SerializeField]
    private Image legsIcon;
    [SerializeField]
    private Text legsName;

    [SerializeField]
    private Image feetIcon;
    [SerializeField]
    private Text feetName;

    [SerializeField]
    private Text playerHealthText, playerLevelText;
    [SerializeField]
    private Image healthBarProgress, levelBarProgress;
    [SerializeField]
    private Player player;

    private List<Text> playerStatsText = new List<Text>();
    
	void Start ()
    {
        weaponManager = player.GetComponent<WeaponManager>();
        offhandManager = player.GetComponent<OffhandManager>();
        helmetManager = player.GetComponent<HelmetManager>();
        chestplateManager = player.GetComponent<ChestplateManager>();
        platelegsManager = player.GetComponent<PlatelegsManager>();
        bootsManager = player.GetComponent<BootsManager>();
        // Listener for health changes
        UIManager.OnPlayerHealthEffected += UpdatePlayerHealth;
        UIManager.OnStatsChanged += UpdateStats;
        UIManager.OnWeaponEquipped += UpdateEquippedWeapon;
        UIManager.OnShieldEquipped += UpdateEquippedOffhand;
        UIManager.OnHelmetWorn += UpdateEquippedHead;
        UIManager.OnBodyWorn += UpdateEquippedBody;
        UIManager.OnLegsWorn += UpdateEquippedLegs;
        UIManager.OnFeetWorn += UpdateEquippedFeet;
        UIManager.OnPlayerLevelUp += UpdatePlayerLevel; // Listener for level change. When level up, calls UpdatePlayerLevel
        InitializeStats();
	}

    void UpdatePlayerHealth(int currentHealth, int maxHealth)
    {
        // Set player health number displayed
        this.playerHealthText.text = currentHealth.ToString();
        // Set fill amount of bar based on current health to max health - cast to float to get value between 0 and 1
        this.healthBarProgress.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    void UpdatePlayerLevel()
    {
        // Set player level text UI
        this.playerLevelText.text = player.levelling.level.ToString();
        // Set fill amount of bar based on current experience divided by experience to level
        this.levelBarProgress.fillAmount = (float)player.levelling.currentExperience / (float)player.levelling.experienceToLevel;
    }

    void InitializeStats()
    {
        //Image ohHandImage = playerOnHand.transform.Find("onhandIcon").GetComponent<Image>();
        //ohHandImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + player.GetComponent<WeaponManager>().currentHeldItem.itemSlug);
        //playerOnHand.transform.Find("onhandIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Icons/Items" + player.GetComponent<WeaponManager>().currentHeldItem.itemSlug);
        // Do for all stats
        Debug.Log("Stats initialized");
        UpdateStats();

    }

    void UpdateStats()
    {
        // 
        Debug.Log(player.combatantStats.stats[0].UpdateStatValue().ToString());
        attackLevelText.text = player.combatantStats.stats[0].UpdateStatValue().ToString();
        defenceLevelText.text = player.combatantStats.stats[1].UpdateStatValue().ToString();
        speedLevelText.text = player.combatantStats.stats[2].UpdateStatValue().ToString();
    }

    void UpdateEquippedWeapon(ItemClass item)
    {
        onhandIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
        onhandName.text = item.itemName;
        mainHandStatText.text = "Att: " + item.stats[0].UpdateStatValue().ToString() + " Def: " + item.stats[1].UpdateStatValue().ToString() + " Spd: " + item.stats[2].UpdateStatValue().ToString();
        Debug.Log(item.stats[0].UpdateStatValue().ToString() + "THISIS THE STATS");

        UpdateStats();
    }

    void UpdateEquippedOffhand(ItemClass item)
    {
        offhandIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
        offhandName.text = item.itemName;
        offHandStatText.text = "Att: " + item.stats[0].UpdateStatValue().ToString() + " Def: " + item.stats[1].UpdateStatValue().ToString() + " Spd: " + item.stats[2].UpdateStatValue().ToString();

        UpdateStats();
    }
    void UpdateEquippedHead(ItemClass item)
    {
        headIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
        headName.text = item.itemName;
        headStatText.text = "Att: " + item.stats[0].UpdateStatValue().ToString() + " Def: " + item.stats[1].UpdateStatValue().ToString() + " Spd: " + item.stats[2].UpdateStatValue().ToString();

        UpdateStats();
    }

    void UpdateEquippedBody(ItemClass item)
    {
        bodyIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
        bodyName.text = item.itemName;
        bodyStatText.text = "Att: " + item.stats[0].UpdateStatValue().ToString() + " Def: " + item.stats[1].UpdateStatValue().ToString() + " Spd: " + item.stats[2].UpdateStatValue().ToString();

        UpdateStats();
    }


    void UpdateEquippedLegs(ItemClass item)
    {
        legsIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
        legsName.text = item.itemName;
        legsStatText.text = "Att: " + item.stats[0].UpdateStatValue().ToString() + " Def: " + item.stats[1].UpdateStatValue().ToString() + " Spd: " + item.stats[2].UpdateStatValue().ToString();

        UpdateStats();
    }

    void UpdateEquippedFeet(ItemClass item)
    {
        feetIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.itemSlug);
        feetName.text = item.itemName;
        feetStatText.text = "Att: " + item.stats[0].UpdateStatValue().ToString() + " Def: " + item.stats[1].UpdateStatValue().ToString() + " Spd: " + item.stats[2].UpdateStatValue().ToString();

        UpdateStats();
    }

    public void RemoveItem()
    {
        // Reset text and sprite elements to empty
        onhandName.text = "-";
        onhandIcon.sprite = emptySlotSprite;
        mainHandStatText.text = "-";
        // Call remove weapon in weapon manager
        weaponManager.RemoveWeapon();
    }

    public void RemoveShield()
    {
        offhandName.text = "-";
        offhandIcon.sprite = emptySlotSprite;
        offHandStatText.text = "-";
        offhandManager.RemoveShield();
    }

    public void RemoveHelmet()
    {
        headName.text = "-";
        headIcon.sprite = emptySlotSprite;
        headStatText.text = "-";
        helmetManager.RemoveHelmet();
    }

    public void RemoveBody()
    {
        bodyName.text = "-";
        bodyIcon.sprite = emptySlotSprite;
        bodyStatText.text = "-";
        chestplateManager.RemoveChestplate();
    }

    public void RemoveLegs()
    {
        legsName.text = "-";
        legsIcon.sprite = emptySlotSprite;
        legsStatText.text = "-";
        platelegsManager.RemovePlatelegs();
    }

    public void RemoveFeet()
    {
        feetName.text = "-";
        feetIcon.sprite = emptySlotSprite;
        feetStatText.text = "-";
        bootsManager.RemoveBoots();
    }


}
