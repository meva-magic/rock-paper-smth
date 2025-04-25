using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum State { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class DuelSystem : MonoBehaviour
{
    public State state;

    private Unit enemyUnit;
    private Unit playerUnit;

    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    public Transform enemyPos;
    public Transform playerPos;

    public DuelUI enemyUI;
    public DuelUI playerUI;

    [SerializeField] private Text dialogueText;

    private void Start()
    {
        playerUI.SetHP(playerUnit.currentHP);
        enemyUI.SetHP(enemyUnit.currentHP);

        state = State.START;
        StartCoroutine(SetupDuel());
    }

    IEnumerator SetupDuel()
    {
        GameObject enemyObj = Instantiate(enemyPrefab, enemyPos);
        enemyUnit = enemyObj.GetComponent<Unit>();

        GameObject playerObj = Instantiate(playerPrefab, playerPos);
        playerUnit = playerObj.GetComponent<Unit>();

        dialogueText.text = "Молчаливый " + enemyUnit.unitName + " преградил тебе путь...";

        playerUI.SetUI(playerUnit);
        enemyUI.SetUI(enemyUnit);

        yield return new WaitForSeconds(3f);

        state = State.PLAYERTURN;

        PlayerTurn();
    }

    private void PlayerTurn()
    {
        dialogueText.text = "выбери карту";
    }

    public void OnCardButton()
    {
        if(state != State.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    private IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.unitDamage);

        enemyUI.SetHP(enemyUnit.currentHP);
        dialogueText.text = "ты ранил " + enemyUnit.unitName;

        yield return new WaitForSeconds(3f);

        if(isDead)
            {state = State.WON;
            EndDuel();}

        else
            {state = State.ENEMYTURN;
            StartCoroutine(EnemyTurn());}
    }

    private IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " атакует";

        yield return new WaitForSeconds(1.5f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.unitDamage);

        playerUI.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1.5f);

        if(isDead)
        {
            state = State.LOST;
            EndDuel();
        }

        else
        {
            state = State.PLAYERTURN;
            PlayerTurn();
        }
    }

    private void EndDuel()
    {
        if(state == State.WON)
        {
            dialogueText.text = "ты победил " + enemyUnit.unitName;
        }

        else if(state == State.LOST)
        {
            dialogueText.text = "ты был побежден";
        }
    }
}
