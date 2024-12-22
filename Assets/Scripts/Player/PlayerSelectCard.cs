using Levels;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerSelectCard : MonoBehaviour
    {
        [SerializeField] private ParticleSystem winFX;
        
        private Camera _camera;

        [Inject] private LevelsRestarter _restarter;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
                return;

            if (_restarter.Restarting)
                return;
            
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (!hit || !hit.collider.CompareTag("Card"))
                return;

            var card = hit.collider.GetComponent<Card>();

            if (!card.CheckRightCard())
                return;
            
            winFX.transform.position = card.transform.position;
            winFX.Play();
        }
    }
}