using System.Collections;
using CourseworkGame.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CourseworkGame.UI
{
    public class DeathPanelManager : InGamePanelManager
    {
        [SerializeField] private float fadeDuration = 2f;
        
        private void Start()
        {
            GlobalEventManager.OnDeath.AddListener(() =>
            {
                panel.SetActive(true);
                StartCoroutine(FadeScreen());
            });
        }

        private IEnumerator FadeScreen()
        {
            var panelImage = panel.GetComponent<Image>();
            var dif = 1f - panelImage.color.a;

            while (panelImage.color.a < 1f)
            {
                panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, panelImage.color.a + dif / fadeDuration * Time.deltaTime);
                yield return null;
            }
            
            Time.timeScale = 0f;
        }
    }
}
