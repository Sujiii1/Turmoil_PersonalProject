using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{
    public class WorldTimeScript : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;
        [SerializeField] private float _dayLength = 1440f; // �Ϸ� ���� (��)
        private const float slowTime = 8f; // �ð� �帧 õõ��

        private TimeSpan _currentTime;
        private float _minuteLength => _dayLength / WorldTimeConstans.MinutesInDay * slowTime; // �ð��� õõ�� �帣���� ����

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
