using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Game.Scripts.MapBuilder
{
    public class WalkableAreaBuilder : MonoBehaviour
    {
        [SerializeField] private List<NavMeshSurface> _navMeshSurfaces;

        private void BuildNavMeshes()
        {
            foreach (var surface in _navMeshSurfaces)
            {
                surface.BuildNavMesh();
            }
        }
    }
}