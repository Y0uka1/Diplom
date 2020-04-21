using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugParty : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        ICharacterStats[] team = new ICharacterStats[4] { new Artorias_Character(), new Artorias_Character(), new Artorias_Character(), new Artorias_Character() };
        MainManager.playersTeam.team = team;
        SceneManager.LoadScene("SampleScene");

    }
}
