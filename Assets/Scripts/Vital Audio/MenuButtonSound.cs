using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VT.Audio
{
    public class MenuButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        [SerializeField] private AudioObject clickSound;
        [SerializeField] private AudioObject hoverSound;
        private Button m_button;

        private void Awake()
        {
            m_button = GetComponent<Button>();
        }

        public void Click()
        {
            if (!m_button.interactable || !clickSound)
                return;
            
            AudioManager.PlaySound(clickSound);
        }

        public void Hover()
        {
            if (!m_button.interactable || !hoverSound)
                return;
            
            AudioManager.PlaySound(hoverSound);
        }

        public void OnPointerEnter(PointerEventData eventData) => Hover();
        public void OnPointerClick(PointerEventData eventData) => Click();
    }
}