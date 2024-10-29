using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugTextInfo : MonoBehaviour
{
    [SerializeField] KeyCode enbaleKey = KeyCode.BackQuote;

    [SerializeField] GameObject overLayObject;

    [SerializeField] TextMeshProUGUI dmgText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI maxHpText;

    [SerializeField] Button addXpButton;
    [SerializeField] Button deleteSaveButton;

    BulletParent bulletParentSc;
    PlayerHealth playerHealthSc;
    PlayerXp playerXp;
    // Start is called before the first frame update
    void Start()
    {
        bulletParentSc = FindObjectOfType<BulletParent>();
        playerHealthSc = FindObjectOfType<PlayerHealth>();
        playerXp = FindObjectOfType<PlayerXp>();

        addXpButton.onClick.AddListener(AddXp);
        deleteSaveButton.onClick.AddListener(DeleteSave);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(enbaleKey))
            overLayObject.SetActive(!overLayObject.activeSelf);

        if (overLayObject.activeSelf)
            UpdateTexts();

    }

    void UpdateTexts()
    {
        dmgText.text = "Dmg: " + bulletParentSc.GetDamage().ToString();
        hpText.text = "Hp: " + playerHealthSc.GetHealth().ToString();
        maxHpText.text = "MHp: " + playerHealthSc?.GetMaxHealth().ToString();
    }

    void AddXp()
    {
        playerXp.DebugerAddXp(100);
    }

    void DeleteSave()
    {
        SaveSystem.DeleteSave();
    }
}
