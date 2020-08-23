﻿using UnityEngine;
using UnityEngine.UI;

namespace Atomic_Nucleus.Scripts {
    [RequireComponent(typeof(FPSCounter))]
    public class FPSDisplay : MonoBehaviour
    {

        public Text fpsLabel;
        public Text highestLabel;
        public Text lowestLabel;

    
    
        [System.Serializable]
        private struct FPSColor {
#pragma warning disable 649
            public Color color;
            public int minimumFPS;
#pragma warning restore 649
        }

        [SerializeField] 
        private FPSColor[] _coloring = null;
    
        private FPSCounter _fpsCounter;
    
        static readonly string[] StringsFrom00To99 = {
            "00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
            "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
            "20", "21", "22", "23", "24", "25", "26", "27", "28", "29",
            "30", "31", "32", "33", "34", "35", "36", "37", "38", "39",
            "40", "41", "42", "43", "44", "45", "46", "47", "48", "49",
            "50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
            "60", "61", "62", "63", "64", "65", "66", "67", "68", "69",
            "70", "71", "72", "73", "74", "75", "76", "77", "78", "79",
            "80", "81", "82", "83", "84", "85", "86", "87", "88", "89",
            "90", "91", "92", "93", "94", "95", "96", "97", "98", "99",
            "100", "101", "102", "103", "104", "105", "106", "107", "108", "109",
            "110", "111", "112", "113", "114", "115", "116", "117", "118", "119",
            "120"
        };

        private void Awake(){
            _fpsCounter = GetComponent<FPSCounter>();
        }

        private void Update(){
            Display(highestLabel, _fpsCounter.HighestFPS);
            Display(fpsLabel, _fpsCounter.AverageFPS);
            Display(lowestLabel, _fpsCounter.LowestFPS);
        }

        private void Display(Text label, int fps){
            label.text = StringsFrom00To99[Mathf.Clamp(fps, 0, 120)];
            for (int i = 0; i < _coloring.Length; i++) {
                if (fps < _coloring[i].minimumFPS){
                    continue;
                }
                label.color = _coloring[i].color;
                break;
            }
        }
    }
}
