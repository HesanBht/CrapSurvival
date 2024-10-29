using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShapaAbility : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        shapaSpeed = playerConfigHolder.shapaSpeed;
        lifeTime = playerConfigHolder.shapaLifeTime;
        shapaDamage = playerConfigHolder.shapaDamage;
        abilityCD = playerConfigHolder.shapaAbilityCD;
        shapaButton = playerConfigHolder.shapaButton;
    }
    #endregion


    [Header("Deployable Properties")]
    [SerializeField] bool isShapaDeployedObject = false;
    [SerializeField] GameObject shapaDeployableObject;
    [SerializeField] float shapaSpeed = 3f;
    [SerializeField] float lifeTime = 4f;
    [SerializeField] int shapaDamage = 100;

    bool lifeTimeTimerIniciated = false;

    [Header("Ability Properties")]
    [SerializeField] float abilityCD = 5f;
    [SerializeField] KeyCode shapaButton = KeyCode.Space;

    bool isOnCD = false;




    List<GameObject> enemiesToDamage = new List<GameObject>();
    int enemiesListIndex = 0;

    PlayerInputManager playerInputManager;
    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        if (!isShapaDeployedObject)
            playerInputManager = FindObjectOfType<PlayerInputManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Deployed();

        if (Input.GetKeyDown(shapaButton))
            DoAbility();

    }

    #region Deployable
    void Deployed()
    {
        if (isShapaDeployedObject)
        {
            transform.Translate(Vector3.up * shapaSpeed * Time.deltaTime, Space.Self);

            if (!lifeTimeTimerIniciated) StartCoroutine(LifeTimeTimer());
        }

    }
    IEnumerator LifeTimeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    void DoDamage()
    {
        for (int x = enemiesListIndex; x < enemiesToDamage.Count; x++, enemiesListIndex++)
        {
            enemiesToDamage[x].GetComponent<EnemyHealth>().ReduceHealth(shapaDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Tag_Enemy>() == null) return;


        if (enemiesToDamage.Contains(collision.gameObject)) return;

        enemiesToDamage.Add(collision.gameObject);
        DoDamage();

    }
    #endregion

    #region AbilityObject
    public void DoAbility()
    {
        if (isShapaDeployedObject) return;
        if (isOnCD) return;
        StartCoroutine(AbilityCDRoutine());
        GameObject shapaDeployableInstance = Instantiate(shapaDeployableObject, CalculateSpawnPose(), CalculateSpawnRotation());
        shapaDeployableInstance.SetActive(true);
    }
    IEnumerator AbilityCDRoutine()
    {
        isOnCD = true;
        yield return new WaitForSeconds(abilityCD);
        isOnCD = false;
    }
    Quaternion CalculateSpawnRotation()
    {
        Vector2 movingDir = playerInputManager.GetMoveVectorNormalized();
        float zavia = Mathf.Atan2(movingDir.x, -movingDir.y) * Mathf.Rad2Deg; // *-1 is for fliping the direction
        return Quaternion.Euler(0, 0, zavia);
    }
    Vector2 CalculateSpawnPose()
    {
        Vector2 movingDir = playerInputManager.GetMoveVectorNormalized();
        Vector2 spawnPose = transform.TransformPoint(movingDir * new Vector2(-1, -1));
        return spawnPose;

    }
    #endregion

}
