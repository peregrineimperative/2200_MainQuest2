using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestSO", menuName = "QuestSO")]
public class QuestSO : ScriptableObject
{
    [SerializeField] public List<QuestFlagSO> prerequisiteFlags;
    [SerializeField] public List<QuestFlagSO> completionFlags;
    [SerializeField] public QuestFlagSO rewardFlag;
}
