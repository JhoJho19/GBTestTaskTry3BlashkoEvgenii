using Gameplay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GideController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI howToMoveText;
    [SerializeField] TextMeshProUGUI howToJumpText;
    [SerializeField] GameObject prohiprohibited;

    private void OnEnable()
    {
        howToMoveText.gameObject.SetActive(true);
        howToJumpText.gameObject.SetActive(true);
        prohiprohibited.SetActive(true);

        BallController ballController = FindObjectOfType<BallController>();
        if (ballController != null)
            ballController.OnMovementStart.AddListener(GideOff);
    }

    private void GideOff() 
    {
        StartCoroutine(WaitOneSecondAndOffTheGide());
    }

    IEnumerator WaitOneSecondAndOffTheGide()
    {
        yield return new WaitForSeconds(1f);
        howToMoveText.gameObject.SetActive(false);
        howToJumpText.gameObject.SetActive(false);
    }
}
