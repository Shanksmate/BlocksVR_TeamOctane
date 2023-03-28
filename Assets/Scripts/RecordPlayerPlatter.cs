using UnityEngine;

namespace _Course_Library.Scripts
{
    public class RecordPlayerPlatter : MonoBehaviour
    {
        [SerializeField] private Transform platter;
        public Vector3 speed;

        // Update is called once per frame
        void Update()
        {
            platter.Rotate(speed * Time.deltaTime);
        }
    }
}
