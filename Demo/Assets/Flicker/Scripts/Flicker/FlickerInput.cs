using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Flicker
{
    [RequireComponent((typeof(PlayerInput)))]
    [AddComponentMenu("Flicker/Flick Input")]
    public class FlickerInput : MonoBehaviour
    {
        public bool alwaysActive;
        static bool active;
        public bool allowHalfCoords;

        [Header("Custom listeners (optional)")]
        [Space]
        public UnityEvent<FlickData> onFlickCompleted;

        string _shortCode;
        string _pattern;
        List<Vector2> _values = new List<Vector2>();
        List<float> _magnitudes = new List<float>();
        List<Move> _moves = new List<Move>();

        const float EdgeValue = 0.75f;
        readonly WaitForSeconds _timeout = new WaitForSeconds(0.05f);

        void Awake()
        {
            AssignListeners();
        }

        void AssignListeners()
        {
            FlickerListener[] flickerListeners = FindObjectsOfType<FlickerListener>();
            foreach (FlickerListener flickerListener in flickerListeners)
            {
                flickerListener.LinkToInput(this);
            }
        }

        public static void SetActive(bool value)
        {
            active = value;
        }
        public void OnActive(InputAction.CallbackContext context)
        {
            active = context.ReadValueAsButton();
        }

        public void OnFlick(InputAction.CallbackContext context)
        {
            if (!active && !alwaysActive) return;
            StopAllCoroutines();
            var value = context.ReadValue<Vector2>();
            if (_values.Count == 0 && value.magnitude >= 0.9f) _values.Add(value);
            else if (_values.Count > 0 && Vector2.Distance(value, _values[_values.Count - 1]) > 0.3f && value.magnitude != 0f)
            {
                _values.Add(value);
            }
            else if (value.magnitude <= 0.0f)
            {
                StartCoroutine(EndTimeout());
            }
        }

        IEnumerator EndTimeout()
        {
            yield return _timeout;
            TryCast();
        }

        void TryCast()
        {
            CreateMagnitudesList();
            CreateMoves();
            Clear();
        }

        void Clear()
        {
            _moves = new List<Move>();
            _values = new List<Vector2>();
            _magnitudes = new List<float>();
            active = true;
            _pattern = null;
            _shortCode = null;
        }

        void CreateMagnitudesList()
        {
            foreach (Vector2 value in _values)
            {
                _magnitudes.Add(value.magnitude);
            }
        }

        void CreateMoves() {
            Move movement = null;

            for (int i = 0; i < _magnitudes.Count; i++)
            {
                float magnitude = _magnitudes[i];

                if (movement == null && magnitude >= EdgeValue)
                {
                    movement = new Move(_values[i]);
                    continue;
                }

                if (movement == null) continue;

                if (_magnitudes[i - 1] >= EdgeValue && magnitude >= EdgeValue && movement.type == Move.Type.FF)
                {
                    movement.type = Move.Type.S;

                    if (Vector2.SignedAngle(_values[i], _values[i - 1]) < 0f) movement.dir = Move.Dir.C;

                    continue;
                }

                if (magnitude >= EdgeValue && movement.type == Move.Type.FF)
                {
                    NewMove(i, ref movement);
                    continue;
                }

                if (magnitude < EdgeValue && movement.type == Move.Type.S && Vector2.Distance(movement.end, _values[i - 1]) > 0.8f) NewMove(i - 1, ref movement);
            }

            if (_moves.Count == 0 && movement is {type: Move.Type.S})
                NewMove(_magnitudes.Count - 1, ref movement);
            if (_moves.Count > 0)
            {
                onFlickCompleted?.Invoke(new FlickData(_shortCode, _pattern));
            }
        }

        void NewMove(int index, ref Move movement)
        {
            movement.end = _values[index];
            float[] rawCoords = new float[] {movement.start.x, movement.start.y, movement.end.x, movement.end.y};

            _moves.Add(movement);
            _shortCode += movement.type == Move.Type.S
                ? movement.type.ToString() + movement.dir.ToString()
                : movement.type.ToString();
            _pattern += movement.type == Move.Type.S ? movement.type.ToString() + movement.dir.ToString() : movement.type.ToString();
            _pattern += allowHalfCoords ? HalfCoordsToString(rawCoords) : CoordsToString(rawCoords);
            movement = new Move(_values[index]);
        }

        string CoordsToString(float[] coords)
        {
            string s = "";
            foreach (float coord in coords)
            {
                if (coord < -0.5f)
                    s += "4";
                if (coord >= -0.5f && coord <= 0.5f)
                    s += "0";
                if (coord > 0.5f)
                    s += "1";
            }
            return s;
        }

        string HalfCoordsToString(float[] coords)
        {
            string s = "";
            foreach (float coord in coords)
            {
                if (coord <= -0.80f)
                {
                    s += "4";
                }

                if (coord < -0.20f && coord > -0.80f)
                {
                    s += "3";
                }

                if (coord >= -0.20f && coord <= 0.20f)
                {
                    s += "0";
                }

                if (coord > 0.20f && coord < 0.80f)
                {
                    s += "2";
                }

                if (coord >= 0.80f)
                    s += "1";
            }
            return s;
        }
    }
}
