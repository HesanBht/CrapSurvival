using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.Timeline;

public class LvlUp_UI : MonoBehaviour
{

    [SerializeField] GameObject lvlUpScreen;


    [SerializeField] TextMeshProUGUI currentLevelTmpro;
    [SerializeField] TextMeshProUGUI attackSpeedTmpro;
    [SerializeField] TextMeshProUGUI attackDamageTmpro;
  //  [SerializeField] TextMeshProUGUI bulletSpeedTmpro;





    [SerializeField] Button IncreseSimpleAttackDamageButton;
    [SerializeField] Button reduceSimpleAttackTimeButton;
    [SerializeField] Button increseSimpleBulletSpeedButton;

    [Space]
    [SerializeField] Color abilityActivatedColor = Color.green;

    [Header("Lightning")]
    [SerializeField] GameObject lightningStrikeAbilityObject;
    [SerializeField] Button lightningStrikeAbilityButton;
    [SerializeField] Image lightningStrikeAbilityBGImage;
    bool lightningStrikeAbilityActivated = false;

    [Header("SroudingChain")]
    [SerializeField] GameObject sroundingChainAbilityObject;
    [SerializeField] Button sroundingChainAbilityButton;
    [SerializeField] Image sroundingChainAbilityBGImage;
    bool sroundingChainAbilityActivated = false;

    [Header("Shapa")]
    [SerializeField] GameObject shapaAbilityObjcet;
    [SerializeField] Button shapaAbilityButton;
    [SerializeField] Image shapaAbilityBGImage;
    bool shapaAbilityActivated = false;


    [Space(10)]
    [SerializeField] SimpleAttackModifierAbility simpleAttackModifierAbility;

    [Space(20)]
    [SerializeField] int lvlReqForShapa = 2;
    [SerializeField] GameObject lockObjectForShapa;
    [SerializeField] TextMeshProUGUI lvlReqTextForShapa;
    [SerializeField] int lvlReqForRazor = 3;
    [SerializeField] GameObject lockObjectForRazor;
    [SerializeField] TextMeshProUGUI lvlReqTextForRazor;
    [SerializeField] int lvlReqForLightning = 4;
    [SerializeField] GameObject lockObjectForLightning;
    [SerializeField] TextMeshProUGUI lvlReqTextForLightning;

    PlayerAttackManager playerAttackManager;
     BulletParent bulletParent;

  [SerializeField]  int currentPlayerLvl = 0;
    // Start is called before the first frame update
    void Start()
    {
        simpleAttackModifierAbility = FindObjectOfType<SimpleAttackModifierAbility>();
        playerAttackManager = FindObjectOfType<PlayerAttackManager>();
        bulletParent = FindObjectOfType<BulletParent>();

        PlayerXp.onLevelup += OnLvlup;

        IncreseSimpleAttackDamageButton.onClick.AddListener(IncreseSimpleAttackDamage);
        reduceSimpleAttackTimeButton.onClick.AddListener(ReduceSimpleAttackTime);


        lightningStrikeAbilityButton.onClick.AddListener(ActivateLightningStikeAbility);
        sroundingChainAbilityButton.onClick.AddListener(ActivateSroundingChainAbility);
        shapaAbilityButton.onClick.AddListener(ActivateShapaAbility);


        lvlReqTextForLightning.text = "Unlocked At Lvl " + lvlReqForLightning;
        lvlReqTextForRazor.text = "Unlocked At Lvl " + lvlReqForRazor;
        lvlReqTextForShapa.text = "Unlocked At Lvl " + lvlReqForShapa;

    }
    private void OnDestroy()
    {
        PlayerXp.onLevelup -= OnLvlup;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnLvlup(int currentLevel)
    {
        PauseGame();
        currentPlayerLvl = currentLevel;
        currentLevelTmpro.text = "Level:" + currentLevel.ToString();
        attackSpeedTmpro.text = "AttackTime: " + playerAttackManager.GetAttackTime().ToString();
        attackDamageTmpro.text = "Bullet Dmg: " + bulletParent.GetDamage().ToString();
        LvlReqLogic();
        lvlUpScreen.SetActive(true);

    }

    void LvlReqLogic()
    {
        if (currentPlayerLvl >= lvlReqForLightning)
        {
            lockObjectForLightning.SetActive(false);
        }
        if (currentPlayerLvl >= lvlReqForShapa)
        {
            lockObjectForShapa.SetActive(false);
        }
        if (currentPlayerLvl >= lvlReqForRazor)
        {
            lockObjectForRazor.SetActive(false);
        }
    }

    void LvlUpDone()
    {
        lvlUpScreen.SetActive(false);
        ResumeGame();
    }

    
    void IncreseSimpleAttackDamage()
    {
        simpleAttackModifierAbility.IncreseDamage();
        LvlUpDone();
    }
    void ReduceSimpleAttackTime()
    {
        simpleAttackModifierAbility.DeacreseAttackTime();
        LvlUpDone();
    }
   


    void ActivateLightningStikeAbility()
    {
        if (lightningStrikeAbilityActivated) return;

        lightningStrikeAbilityActivated = true;
        lightningStrikeAbilityObject.SetActive(true);
        lightningStrikeAbilityBGImage.color = abilityActivatedColor;

        LvlUpDone();
    }

    void ActivateSroundingChainAbility()
    {
        if (sroundingChainAbilityActivated) return;

        sroundingChainAbilityActivated = true;
        sroundingChainAbilityObject.SetActive(true);
        sroundingChainAbilityBGImage.color = abilityActivatedColor;

        LvlUpDone();
    }

    void ActivateShapaAbility()
    {
        if(shapaAbilityActivated) return;


        shapaAbilityActivated = true;
        shapaAbilityObjcet.SetActive(true);
        shapaAbilityBGImage.color = abilityActivatedColor;

        LvlUpDone();
    }

    void PauseGame()
    {
        TimeManager.instance.PauseGame();
    }
    void ResumeGame()
    {
        TimeManager.instance.ResumeGame();
    }
}
