using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.MainSystems
{
    [System.Serializable]
    public class VisualEventProfile
    {
        public string Name;

        [SerializeField] private MoveData moveSet;
        [SerializeField] private AnimData animSet;
        [SerializeField] private FunctionData functionSet;

        public MoveData MoveData { get => moveSet; set => moveSet = value; }
        public AnimData AnimData { get => animSet; set => animSet = value; }
        public FunctionData FunctionData { get => functionSet; set => functionSet = value; }

        public VisualEventData GetVisualEventData()
        {
            VisualEventData data = new VisualEventData();

            data.SetMoveData(new MoveData(moveSet));
            data.SetAnimData(new AnimData(animSet));
            data.SetFunctionData(new FunctionData(functionSet));

            return data;
        }

    }

}

