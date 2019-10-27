using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameUI
{
    public class DotLoader : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI loaderText = null;

        [SerializeField] string defaultText = "Cargando";
        public float _time = 0;
        public void Start()
        {
            if (loaderText != null) loaderText.text = defaultText;
        }

        private void Update()
        {
            _time += Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (_time > 4)
            {
                _time = 0;
            }
            loaderText.text = string.Concat(defaultText, new string('.', (int)_time));

        }
    }
}
