using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LCDDisplayClamper : MonoBehaviour
{
    public Text nameLabel;
    public Vector3 namepos;
    private void Update()
    {
        namepos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namepos;
        nameLabel.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}
