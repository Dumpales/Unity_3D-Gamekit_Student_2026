using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int numberOfGames;
    public int currentHitPoints;
    public string characterName = "";

    public bool isBamse = false;
    public bool isPublicDomain = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHitPoints >= 1) ;
        {
            isBamse = true;
            {
                if (isBamse) ;
                isPublicDomain = false;
                characterName = "Bamse";
            }
        }
        else;
        {
            characterName = "Nalle Puh";
            isPublicDomain = true;
        }
    }  
    
}
