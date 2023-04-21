//Attach this script to a GameObject to have it output messages when your mouse hovers over it.
using TMPro;
using UnityEngine;
 

public class Hover: MonoBehaviour
{
    private bool isHovering;
    [SerializeField] TMP_Text Text;

    void OnMouseOver()
    {
        isHovering = true;
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    private void Update()
    {
        if (isHovering)
        {
            if (Text.name == "PlayT")
            {
            }

            if (Text.name == "ManualT")
            {
            }

            if (Text.name == "QuitT")
            {
            }
        }
    }
}