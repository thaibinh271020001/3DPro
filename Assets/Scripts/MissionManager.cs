using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public GameFlow gameFlow;
    public int requiredKill;
    public TMP_Text missionText;
    int remainingkills;
    public Gate gate;
    public GameObject exitGate;

    public Transform exitDoor;
    public Transform playerFoot;

    private int currentKill=-1;
    private bool isPlayerExit;

    private void Start()
    {
        remainingkills = requiredKill+1;
        StartCoroutine(VerifyMissions());
    }
    private void Update()
    {
        missionText.text = $"Kill {remainingkills} Zombie";
        if(remainingkills == 0)
        {
            missionText.text = $"Find exit door";
        }
    }
    private IEnumerator VerifyMissions()
    {
        yield return VerifyZombieKill();
        yield return VeviryPlayerExit();
        //gameFlow.OnMissionCompleted();
    }

    private IEnumerator VerifyZombieKill()
    {
        OnZombieKilled();
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }

    private IEnumerator VeviryPlayerExit()
    {
        gate.onPlayedEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        gate.onPlayedEnter.RemoveListener(OnPlayerExit);
    }
    public void OnZombieKilled() { 
        currentKill++;
        remainingkills--;
        if (remainingkills == 0)
        {
            exitGate.SetActive(true);
        }
    }

    private void OnPlayerExit()
    {
        isPlayerExit = true;
    }

    private bool IsPlayerExit()
    {
        float distance = Vector3.Distance(playerFoot.position, exitDoor.position);
        return distance < 1f;
    }
}
