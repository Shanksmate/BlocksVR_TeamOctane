using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace _Course_Library.Scripts.Actions
{
    /// <summary>
    /// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects
    /// Should be placed on a ray interactor
    /// </summary>
    [RequireComponent(typeof(XRRayInteractor))]
    public class ToggleRay : MonoBehaviour
    {
        [Tooltip("Switch even if an object is selected")]
        public bool forceToggle = false;

        [Tooltip("The direct interactor that's switched to")]
        public XRDirectInteractor directInteractor = null;

        private XRRayInteractor _rayInteractor = null;
        private bool _isSwitched = false;

        private void Awake()
        {
            _rayInteractor = GetComponent<XRRayInteractor>();
            SwitchInteractors(false); // moved to here
        }

        private void Start()
        {
            //SwitchInteractors(false);
        }

        public void ActivateRay()
        {
            if (!TouchingObject() || forceToggle)
                SwitchInteractors(true);
        }

        public void DeactivateRay()
        {
            if (_isSwitched)
                SwitchInteractors(false);
        }

        private bool TouchingObject()
        {
            List<XRBaseInteractable> targets = new List<XRBaseInteractable>();
#pragma warning disable CS0618
            directInteractor.GetValidTargets(targets);
#pragma warning restore CS0618
            return (targets.Count > 0);
        }

        private void SwitchInteractors(bool value)
        {
            _isSwitched = value;
            _rayInteractor.enabled = value;
            directInteractor.enabled = !value;
        }
    }
}
