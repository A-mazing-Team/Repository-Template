using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingTeam.UI.Tools
{
    public static class UITools
    {
        public static bool IsPointerOverUI
        {
            get
            {
                var eventData = new PointerEventData(EventSystem.current);
                eventData.position = Input.mousePosition;
                var results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);

                return results.Count > 0;
            }
        }

        public static string ToMoneyFormat<T>(this T Value)
        {
            return ShrinkWorker(Convert.ToInt64(Value));
        }

        public static string ShrinkWorker(long Value)
        {
            if (Value >= 10000000000000000000D)
            {
                return (Value / 1000000000000000000D).ToString("0.#Qi");
            }
            if (Value >= 1000000000000000000D)
            {
                return (Value / 1000000000000000000D).ToString("0.##Qi");
            }
            if (Value >= 10000000000000000)
            {
                return (Value / 1000000000000000D).ToString("0.#Qa");
            }
            if (Value >= 1000000000000000)
            {
                return (Value / 1000000000000000D).ToString("0.##Qa");
            }
            if (Value >= 10000000000000)
            {
                return (Value / 1000000000000D).ToString("0.#T");
            }
            if (Value >= 1000000000000)
            {
                return (Value / 1000000000000D).ToString("0.##T");
            }
            if (Value >= 10000000000)
            {
                return (Value / 1000000000D).ToString("0.#B");
            }
            if (Value >= 1000000000)
            {
                return (Value / 1000000000D).ToString("0.##B");
            }

            if (Value >= 100000000)
            {
                return (Value / 1000000D).ToString("0.#M");
            }
            if (Value >= 1000000)
            {
                return (Value / 1000000D).ToString("0.##M");
            }
            if (Value >= 100000)
            {
                return (Value / 1000D).ToString("0.#K");
            }
            if (Value >= 1000)
            {
                return (Value / 1000D).ToString("0.##K");
            }

            return Value.ToString("#,0");
        }
    }
}