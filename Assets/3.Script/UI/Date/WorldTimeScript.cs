using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{
    public class WorldTimeScript : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;
        [SerializeField] private float _dayLength = 1440f; // 하루 길이 (초)
        private const float slowTime = 8f; // 시간 흐름 천천히

        private TimeSpan _currentTime;
        private float _minuteLength => _dayLength / WorldTimeConstans.MinutesInDay * slowTime; // 시간이 천천히 흐르도록 변경

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            _currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, _currentTime);
            yield return new WaitForSeconds(_minuteLength);
            if (_currentTime.Minutes > 29)
            {
                while (_currentTime.Minutes < 59)
                {
                    _currentTime += TimeSpan.FromMinutes(1);
                }
            }
            StartCoroutine(AddMinute());
        }
    }
}
