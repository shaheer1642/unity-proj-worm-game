using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterCollision : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public TMP_Text scoreRef;
    public TMP_Text livesRef;
    public GameObject changeLevelCube;
    private ChangeLevel ChangeLevelScript;

    private void Start()
    {
        ChangeLevelScript = changeLevelCube.GetComponent<ChangeLevel>();
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null) return;

        Debug.Log("OnControllerColliderHit" + body.gameObject.tag);
        
        if (body.gameObject.tag == "GoldCoin") {
            score += 10;
            scoreRef.text = "Score: " + score;
            Destroy(body.gameObject);
        }

        if (body.gameObject.tag == "SilverCoin") {
            score += 5;
            scoreRef.text = "Score: " + score;
            Destroy(body.gameObject);
        }

        if (body.gameObject.tag == "EnemyCoin") {
            lives -= 1;
            livesRef.text = "Lives: " + lives;
            Destroy(body.gameObject);
            if (lives == 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
        completeLevel();
    }

    void completeLevel() {
        if (score >= ChangeLevelScript.changeLevelScore) {
            changeCubeColor();
        }
    }

    void changeCubeColor() {
       var cubeRenderer = changeLevelCube.GetComponent<Renderer>();
       cubeRenderer.material.SetColor("_Color", Color.green);
    }
}
