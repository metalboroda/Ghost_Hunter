using Characters;
using UnityEngine;

namespace Utils
{
    public class GhostDestroyer : MonoBehaviour
    {
        private void Update()
        {
            Shoot();
        }

        private static void Shoot()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (Camera.main == null) return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
            {
                if (hit.transform == null) return;
                var ghostMovement = hit.transform.GetComponent<Ghost>();
                ghostMovement.GhostDeath();
            }
        }
    }
}