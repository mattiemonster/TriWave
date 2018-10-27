using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeOutArea : MonoBehaviour
{
    public Image backgroundImage;

    public Color startColour;
    public Color endColour;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision!");
        if (col.gameObject.tag == "Player")
        {
            backgroundImage.DOColor(endColour, 0.2f);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            backgroundImage.DOColor(startColour, 0.2f);
        }
    }
}
