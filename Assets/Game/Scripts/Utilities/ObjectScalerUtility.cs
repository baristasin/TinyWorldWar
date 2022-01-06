using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Utilities
{
    public class ObjectScalerUtility : MonoBehaviour
    {
        [SerializeField] private List<Transform> _objects;

        [Button]
        public void ScaleAllObjects()
        {
            foreach (var obj in _objects)
            {
                obj.transform.localScale = new Vector3(obj.transform.localScale.x / 40f, obj.transform.localScale.y / 40f, obj.transform.localScale.z / 40f);
            }
        }
    }
}