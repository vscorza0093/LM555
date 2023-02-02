using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotClamper : MonoBehaviour
{
    public Text nameLabel;
    public Button buttonSlot;
    public Vector3 namepos;
    private void Update()
    {
        namepos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namepos;
        buttonSlot.transform.position = namepos;
    }
}
