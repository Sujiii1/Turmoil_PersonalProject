using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace WorldTime
{
    [RequireComponent(typeof(TMP_Text))]
    public class WorldTimeDisPlay : MonoBehaviour
    {
        [SerializeField] private WorldTimeScript _worldTime;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _worldTime.WorldTimeChanged += OnWolrdTimeChanged;
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= OnWolrdTimeChanged;
        }

        private void OnWolrdTimeChanged(object sender, TimeSpan newTime)
        {
            if (newTime.Hours >= 11)
            {
                Debug.Log("Hours 3");
                SceneManager.LoadScene("4. ResultScene");
            }

            // _text.SetText(newTime.ToString(@"hh\:mm"));
            _text.SetText($" {newTime.Hours +1} / {newTime.Minutes} ");

            //_text.SetText(newTime.Minutes.ToString(@"hh"));
        }    
    }
}


