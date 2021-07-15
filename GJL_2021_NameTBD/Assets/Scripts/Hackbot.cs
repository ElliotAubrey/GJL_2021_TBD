using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackbot : MonoBehaviour, IHackBot
{
    [SerializeField] string botType;
    [SerializeField] int targetGroupLayer;
    [SerializeField] HackTerminal hackTerminal;

    
    public string GetBotType()
    {
        return botType;
    }

    public void React()
    {
        if(botType == "StrongBot")
        {
            StrongBotController x = GetComponent<StrongBotController>();
            x.canControl = true;
        }
    }

    public int GetLayer()
    {
        return targetGroupLayer;
    }

    public void Complete()
    {
        hackTerminal.Return();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (botType == "StrongBot" && collision.tag == "StrongBotExit")
        {
            hackTerminal.Return();
            Destroy(gameObject);
        }
    }
}
