using System.Collections;
using System.Collections .Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Transform player;
    [SerializeField] private float Yoffset;
    [SerializeField] private bool is_player;
    
    void Start()
    {
        dialogText = dialogText.GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void StartText(List<string> phrases)
    {
        StartCoroutine(GoingText(phrases));
    }

    private IEnumerator GoingText(List<string> phrases)
    {
        dialogPanel.SetActive(true);
        foreach (var phrase in phrases)
        {
            dialogText.text = "";
            foreach (var letter in phrase)
            {
                dialogText.text += letter.ToString();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);
        }

        dialogText.text = "";
        dialogPanel.SetActive(false);
    }

    
    private void Update()
    {
        if (is_player)
        {
            transform.position = new Vector3(player.position.x, player.position.y + Yoffset, player.position.z);
        }
    }
}