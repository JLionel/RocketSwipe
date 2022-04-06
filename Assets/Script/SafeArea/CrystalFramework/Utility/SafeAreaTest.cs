using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace Crystal
{
    public class SafeAreaTest : MonoBehaviour
    {
        void Awake ()
        {
            if (!Application.isEditor)
                Destroy (this);
            
            ToggleSafeArea ();
        }
        

        /// <summary>
        /// Toggle the safe area simulation device.
        /// </summary>
        void ToggleSafeArea ()
        {
            SafeArea.Sim = SafeArea.SimDevice.Honor_10;
        }
    }
}
