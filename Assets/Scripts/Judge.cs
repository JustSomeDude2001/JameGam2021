using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Judge : MonoBehaviour
{
    TextMeshProUGUI selfText;

    private void Start() {
        selfText = GetComponent<TextMeshProUGUI>();
        string res = "";
        if (GameState.enacted[GameState.getDecisionIndex("Acquire Hat Of Santa")]) {
            res += "You succesfully recovered the magical hat of Santa.\n";
            res += "With it's magic you were able to deliver all the " + ((int)GameState.getResource("Gifts")).ToString() + " gifts from your stockpile, adding the same amount of points to your score.";
            GameState.score += ((int)GameState.getResource("Gifts"));
        } else {
            res += "You never recovered Santa's hat.\n";
            res += "The Christmas council will order your execution for the atrocities against elfkind.";
        }
        selfText.text = res;
    }
}
