using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SQ_GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title = null, description = null, reward = null;

    public bool IsValid => title && description && reward;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        if (!IsValid) return;
        SQ_Player _player = SQ_World.Instance?.Player;
        if (!_player) return;
        _player.OnQuestEarned += UpdateQuest;
    }
    void UpdateQuest(SQ_Quest _quest)
    {
        title.text = _quest.Title;
        description.text = _quest.Description;
        reward.text = _quest.Reward;
    }
}