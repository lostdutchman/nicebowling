﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExpand : MonoBehaviour {

    public void expand(float sizeIncrease)
    {
        transform.localScale += new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
    }

    public void contract(float sizeDecrease)
    {
        transform.localScale -= new Vector3(sizeDecrease, sizeDecrease, sizeDecrease);
    }

}