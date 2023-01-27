using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeLevel : MonoBehaviour
{
    public GameObject Character;
    private CharacterCollision CharacterCollisionScript;
    public TMP_Text changeLevelTextRef;
    public int changeLevelScore = 20;

    private void Start()
    {
        CharacterCollisionScript = Character.GetComponent<CharacterCollision>();
    }

    void Update() {
        int remainingPoints = changeLevelScore - CharacterCollisionScript.score;
        if (remainingPoints > 0) 
            changeLevelTextRef.text = "Score " + remainingPoints + " more points to unlock next level";
        else 
            changeLevelTextRef.text = "You have unlocked the next level!";
    }

    private void OnCollisionEnter(Collision col) {
        Debug.Log("collided with " + col.gameObject.name);
        if (col.gameObject.tag == "Character") {
            if (CharacterCollisionScript.score >= changeLevelScore) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
