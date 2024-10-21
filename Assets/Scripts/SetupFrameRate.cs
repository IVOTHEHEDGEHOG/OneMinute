using UnityEngine;

namespace RecycleRio.Utils
{
    public class SetupFrameRate : MonoBehaviour
    {
        void Update() => Application.targetFrameRate = 60;
    }
}
