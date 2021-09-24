using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainSystems;

namespace Yatana.MainSystems
{
    //[CreateAssetMenu(fileName = "Visual Event Profile", menuName = "Visual Event Profile", order = 51)]
    [System.Serializable]
    public class VisualEventProfile
    {
        public string Name;

        [SerializeField] private List<MoveData> moveSet;
        [SerializeField] private List<AnimData> animSet;
        [SerializeField] private List<FunctionData> functionSet;

        public List<MoveData> MoveData { get => moveSet; set => moveSet = value; }
        public List<AnimData> AnimData { get => animSet; set => animSet = value; }
        public List<FunctionData> FunctionData { get => functionSet; set => functionSet = value; }
    }

}

