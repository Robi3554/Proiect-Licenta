using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    public Image descriptionImage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public Description(Image descriptionImage, TMP_Text nameText, TMP_Text descriptionText)
    {
        this.descriptionImage = descriptionImage;
        this.nameText = nameText;
        this.descriptionText = descriptionText;
    }

    void Start()
    {
        
    }


}
