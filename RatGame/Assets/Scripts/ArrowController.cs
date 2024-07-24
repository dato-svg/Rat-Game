using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Image leftImage;
    [SerializeField] private Image rightImage;

    public void LeftButtonClick()
    {
        
        var leftImageColor = leftImage.color;
        leftImageColor.a = 0.2f;
        leftImage.color = leftImageColor;

        var rightImageColor = rightImage.color;
        rightImageColor.a = 1f;
        rightImage.color = rightImageColor; 
    }

    public void RightButtonClick()
    {
        
        var leftImageColor = leftImage.color;
        leftImageColor.a = 1f;
        leftImage.color = leftImageColor; 

       
        var rightImageColor = rightImage.color;
        rightImageColor.a = 0.2f;
        rightImage.color = rightImageColor; 
    }
}