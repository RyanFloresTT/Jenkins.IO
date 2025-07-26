using Unity.Netcode;
using UnityEngine;

namespace HelloWorld {
    public class HelloWorldPlayer : NetworkBehaviour {
        public NetworkVariable<Vector2> position = new();

        public float moveSpeed = 5f;
        Camera playerCamera;

        void Start() {
            playerCamera = GetComponentInChildren<Camera>(true);
            playerCamera.gameObject.SetActive(IsOwner);
        }

        void Update() {
            if (!IsOwner) return;

            HandleInput();

            transform.position = position.Value;
        }

        void HandleInput() {
            Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input == Vector2.zero) return;
            Vector2 newPosition = position.Value + input * (moveSpeed * Time.deltaTime);
            SubmitPositionRequestRpc(newPosition);
        }

        [Rpc(SendTo.Server)]
        void SubmitPositionRequestRpc(Vector2 newPosition, RpcParams rpcParams = default) {
            // Server validates and applies position
            position.Value = newPosition;
        }
    }
}