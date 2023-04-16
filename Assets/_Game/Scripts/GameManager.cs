using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRush.Manager
{
    public class GameManager : MonoBehaviour
    {
        public enum GameStat
        {
            Start,
            Play,
            Restart,
            Finish,
            Failed
        }
        public GameStat gameStat;

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void SetGameStatPlay()
        {
            gameStat = GameStat.Play;
        }
    }
}