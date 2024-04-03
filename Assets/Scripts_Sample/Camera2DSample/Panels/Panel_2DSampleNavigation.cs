using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MortiseFrame.Vista.Sample {

    public class Panel_2DSampleNavigation : MonoBehaviour {

        [SerializeField] Button btn_enableDeadZone;
        [SerializeField] Button btn_disableDeadZone;
        [SerializeField] Button btn_enableSoftZone;
        [SerializeField] Button btn_disableSoftZone;
        [SerializeField] Button btn_followDriver;
        [SerializeField] Button btn_moveToNextTarget;

        public Action action_enableDeadZone;
        public Action action_disableDeadZone;
        public Action action_enableSoftZone;
        public Action action_disableSoftZone;
        public Action action_followDriver;
        public Action action_moveToNextTarget;

        void Start() {
            btn_disableDeadZone.onClick.AddListener(() => {
                action_disableDeadZone?.Invoke();
            });
            btn_enableDeadZone.onClick.AddListener(() => {
                action_enableDeadZone?.Invoke();
            });
            btn_disableSoftZone.onClick.AddListener(() => {
                action_disableSoftZone?.Invoke();
            });
            btn_enableSoftZone.onClick.AddListener(() => {
                action_enableSoftZone?.Invoke();
            });
            btn_followDriver.onClick.AddListener(() => {
                action_followDriver?.Invoke();
            });
            btn_moveToNextTarget.onClick.AddListener(() => {
                action_moveToNextTarget?.Invoke();
            });
        }

        void OnDestroy() {
            btn_disableDeadZone.onClick.RemoveAllListeners();
            btn_enableDeadZone.onClick.RemoveAllListeners();
            btn_disableSoftZone.onClick.RemoveAllListeners();
            btn_enableSoftZone.onClick.RemoveAllListeners();
            btn_followDriver.onClick.RemoveAllListeners();
            btn_moveToNextTarget.onClick.RemoveAllListeners();
            action_disableDeadZone = null;
            action_enableDeadZone = null;
            action_disableSoftZone = null;
            action_enableSoftZone = null;
            action_followDriver = null;
            action_moveToNextTarget = null;
        }

    }

}