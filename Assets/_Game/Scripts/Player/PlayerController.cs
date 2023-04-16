using AtmRush.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRush.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }

        [Header("Move Referance")]
        [SerializeField] private Transform _transToMove;
        [SerializeField] private float _minX, _maxX;
        private Vector3 _firstPos, _endPos, newPos;
        private float _posX;

        [Header("Forward Move")]
        [SerializeField] private float _forwardMoveSpeed;

        [Header("Character")]
        [SerializeField] private Animator _characterAnim;

        [Header("Score")]
        [SerializeField] private TMPro.TextMeshPro _moneyCountText;
        private int _moneyAmount;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (GameManager.Instance.gameStat == GameManager.GameStat.Play)
            {
                PlayerMovement();
                CharacterSetAnim("Run", true);
            }

            if (GameManager.Instance.gameStat == GameManager.GameStat.Finish)
            {
                CharacterSetAnim("Run", false);
            }
        }



        private void PlayerMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _firstPos = Input.mousePosition;
                _posX = _transToMove.localPosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                _endPos = Input.mousePosition;
                newPos.x = ((_endPos.x - _firstPos.x) / (Screen.width / 30f)) + _posX;
                newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);
                _transToMove.localPosition = new Vector3(newPos.x, _transToMove.localPosition.y, _transToMove.localPosition.z);
                Valuables.ValuableController.Instance.MoveMoneyElement();
            }

            if (Input.GetMouseButtonUp(0))
            {
                Valuables.ValuableController.Instance.MoveOrigin();
            }

            transform.position += Vector3.forward * _forwardMoveSpeed * Time.deltaTime;

        }

        private void CharacterSetAnim(string animName, bool animBool)
        {
            _characterAnim.SetBool(animName, animBool);
        }

        public void ValuableCounterChanging(int value)
        {
            _moneyAmount += value;
            _moneyCountText.text = _moneyAmount.ToString();

        }
    }
}