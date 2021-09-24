using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public class SkinnedMeshAction : MonoBehaviour
    {
        [SerializeField]
        SkinnedMeshRenderer skinmesh;
        Mesh skinnedMesh;

        int blendCount;
        float totatlSlider;
        float currSlider;

        public void initilazeSkinnedMesh(int startBlendShapeInd, int endBlendShapeInd)
        {
            skinnedMesh = skinmesh.sharedMesh;
            blendCount = skinnedMesh.blendShapeCount;

            RestartSkinnedMesh(startBlendShapeInd, endBlendShapeInd);
        }

        public void RestartSkinnedMesh(int startBlendShapeInd, int endBlendShapeInd)
        {
            currSlider = 0;


            for (int i = startBlendShapeInd; i <= endBlendShapeInd; ++i)
            {
                //Debug.LogError(transform.name);
                skinmesh.SetBlendShapeWeight(i, 0);
            }

        }

        public void UpdateSkinnedMesh(float percent, int startBlendShapeInd, int endBlendShapeInd)
        {
            if (startBlendShapeInd > endBlendShapeInd || endBlendShapeInd >= blendCount)
            {
                Debug.LogError("verilen blend shape indexi sınırların dışında.");
            }
            else
            {
                totatlSlider = (1 + endBlendShapeInd - startBlendShapeInd) * 100;
                currSlider = totatlSlider * percent;
                float val = currSlider;

                for (int i = startBlendShapeInd; i <= endBlendShapeInd && val > 0; ++i)
                {
                    if (val >= 100)
                    {
                        skinmesh.SetBlendShapeWeight(i, 100);
                    }
                    else
                    {
                        skinmesh.SetBlendShapeWeight(i, val);
                    }

                    val -= 100;
                }
            }
        }


    }
}