using UnityEngine;

namespace Atomic_Nucleus.Scripts {
    public class FPSCounter : MonoBehaviour {


        public int AverageFPS{ get; private set; }
        public int HighestFPS{ get; private set; }
        public int LowestFPS{ get; private set; }
        public int frameRange = 60;

        private int[] _fpsBuffer;
        private int _fpsBufferIndex;

        private void Update(){
            if (_fpsBuffer == null || _fpsBuffer.Length != frameRange){
                Initialize();
            }
            UpdateBuffer();
            CalculateFPS();
        }

        private void Initialize(){
            if (frameRange <= 0){
                frameRange = 1;
            }

            _fpsBuffer = new int[frameRange];
            _fpsBufferIndex = 0;
        }

        private void UpdateBuffer(){
            _fpsBuffer[_fpsBufferIndex++] = (int) (1f / Time.unscaledDeltaTime);
            if (_fpsBufferIndex >= frameRange){
                _fpsBufferIndex = 0;
            }
        }

        private void CalculateFPS(){
            int sum = 0;
            int highest = 0;
            int lowest = int.MaxValue;
            for (int i = 0; i < frameRange; i++){
                int fps = _fpsBuffer[i];
                sum += fps;
                if (fps > highest){
                    highest = fps;
                }
                if (fps < lowest){
                    lowest = fps;
                }
            }

            AverageFPS = sum / frameRange;
            HighestFPS = highest;
            LowestFPS = lowest;


        }
    }
}
