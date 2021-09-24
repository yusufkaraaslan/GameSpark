using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yatana
{
    namespace Helper
    {
        public class PopupMessageSystem : MonoBehaviour
        {
            [SerializeField]
            Popups[] popup;

            public void OpenPopup(string popupName, string message, float destroyTime)
            {
                for (int i = 0; i < popup.Length; i++)
                {
                    if (popup[i].popupName == popupName)
                    {
                        popup[i].data.text = message;
                        popup[i].destroyTime = Time.time + destroyTime;
                        popup[i].isOn = true;
                    }
                }
            }

            // Update is called once per frame
            void Update()
            {
                if (popup != null)
                {
                    for (int i = 0; i < popup.Length; i++)
                    {
                        if (popup[i].isOn)
                        {
                            if (Time.time >= popup[i].destroyTime)
                            {
                                popup[i].isOn = false;
                                popup[i].data.text = "";
                            }
                        }
                    }
                }
            }
        }
    }

}