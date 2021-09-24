using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public class MeshAnim : MonoBehaviour
    {
        [SerializeField]
        SkinnedMeshAction[] parts;

        [SerializeField]
        int startBlendShapeInd, endBlendShapeInd;

        public void initilazeFillet()
        {
            foreach (SkinnedMeshAction x in parts)
            {
                x.initilazeSkinnedMesh(startBlendShapeInd, endBlendShapeInd);
            }
        }

        public void RestartFillet()
        {
            foreach (SkinnedMeshAction x in parts)
            {
                x.RestartSkinnedMesh(startBlendShapeInd, endBlendShapeInd);
            }
        }

        public void UpdateCut(float percent)
        {
            foreach (SkinnedMeshAction x in parts)
            {
                x.UpdateSkinnedMesh(percent, startBlendShapeInd, endBlendShapeInd);
            }
        }
    }
}
