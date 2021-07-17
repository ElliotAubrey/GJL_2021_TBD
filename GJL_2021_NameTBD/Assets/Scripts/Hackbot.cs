using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hackbot : MonoBehaviour, IHackBot
{
    [SerializeField] string botType;
    [SerializeField] int targetGroupLayer;
    [SerializeField] HackTerminalBot hackTerminal;
    [SerializeField] TextMeshProUGUI prompt;

    
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
        if(botType == "CrushBot")
        {
            CrushBotController x = GetComponent<CrushBotController>();
            x.canControl = true;
        }
    }

    public int GetLayer()
    {
        return targetGroupLayer;
    }

    public void Complete()
    {
        hackTerminal.Return(true);
    }

    public void Return()
    {
        hackTerminal.Return(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (botType == "StrongBot" && collision.tag == "StrongBotExit")
        {
            hackTerminal.Return(true);
            Destroy(gameObject);
        }
    }
}
