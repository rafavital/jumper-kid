using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool IsInLayerMask(this GameObject gameObject, LayerMask layerMask) => layerMask == (layerMask | (1 << gameObject.layer));
}
