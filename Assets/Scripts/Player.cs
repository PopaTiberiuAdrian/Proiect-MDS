using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;

    }

    [SerializeField] float speed;
    [SerializeField] MouseInput MouseControl;

    private MoveController m_moveController;
    public MoveController MoveController
    {
        get
        {
            if (m_moveController == null)
                m_moveController = GetComponent<MoveController>();
            return m_moveController;
        }

    }
    InputController playerInput;
	void Awake () {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);
    }
}
