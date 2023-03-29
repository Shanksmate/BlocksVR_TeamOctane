using UnityEngine;

namespace _Course_Library.Scripts
{
    public class ReticleRotation : MonoBehaviour
    {
        [SerializeField] private Transform reticle;
        public Vector3 speed;
        
        void Update()
        {
            reticle.Rotate(speed* Time.deltaTime);
        }
    }
}
