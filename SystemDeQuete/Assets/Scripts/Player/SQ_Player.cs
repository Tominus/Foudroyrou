using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class SQ_Player : MonoBehaviour
{
    public event Action<SQ_Quest> OnQuestEarned = null;

    [SerializeField] bool haveQuest = false, canMove = false;
    [SerializeField] int questID = 0;
    [SerializeField] SQ_Quest currentQuest;
    [SerializeField] SQ_LanguageID languageID = SQ_LanguageID.Francais;

    NavMeshAgent agent = null;
    Vector3 startPosition = Vector3.zero;

    public bool IsValid => agent;

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        MoveToQuestPosition();
    }
    private void OnDestroy()
    {
        OnQuestEarned = null;
    }

    void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        if (!IsValid) return;
        GetQuest();
    }

    void MoveToQuestPosition()
    {
        if (!canMove) return;
        Vector3 _destination = haveQuest ? currentQuest.Position : startPosition;
        agent.destination = _destination;
        CheckQuestDistance(_destination);
    }
    void CheckQuestDistance(Vector3 _destination)
    {
        if (Vector3.Distance(_destination, transform.position) < 1f)
        {
            if (haveQuest)
                FinishQuest();
            else
                GetQuest();
        }
    }

    void GetQuest()
    {
        questID = Random.Range(1, 3);
        StartCoroutine(SQ_ConnectAPI.GetQuest<SQ_Quest>(questID, languageID, GetValidQuest, GetInvalidQuest));
        canMove = false;
    }
    void GetValidQuest(SQ_Quest _quest)
    {
        currentQuest = _quest;
        currentQuest.Init();
        OnQuestEarned?.Invoke(currentQuest);
        haveQuest = true;
        canMove = true;
    }
    void GetInvalidQuest()
    {
        haveQuest = false;
        Debug.LogError("Quest is invalid");
    }

    void FinishQuest()
    {
        FinishQuestCompleted(true); //TODO DELETE
        //StartCoroutine(SQ_ConnectAPI.AskForEndQuest(questID, languageID, FinishQuestCompleted, FinishQuestInvalid));
        //canMove = false;
    }
    void FinishQuestCompleted(bool _state)
    {
        haveQuest = false;
        canMove = true;
    }
    void FinishQuestInvalid()
    {
        haveQuest = true;
        Debug.LogError("FinishQuest is invalid");
    }
}