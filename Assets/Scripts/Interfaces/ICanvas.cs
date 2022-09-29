using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanvas
{
    public void AttachAsChild(GameObject obj,string layer="UI");
}
