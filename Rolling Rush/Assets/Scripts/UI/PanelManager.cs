using UnityEngine;

namespace RollingRush.UI
{
    public class PanelManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject storePanel;
        [SerializeField] private GameObject levelSelectPanel;

        private GameObject _currentPanel;
        private PanelState _currentState;

        private void Start()
        {
            _currentState = PanelState.MainMenu;
            _currentPanel = mainMenuPanel;
            _currentPanel.SetActive(true);
        }

        private void ChangeState(PanelState newState)
        {
            if (_currentState == newState) return;
            _currentPanel.SetActive(false);
            _currentState = newState;

            _currentPanel = _currentState switch
            {
                PanelState.MainMenu => mainMenuPanel,
                PanelState.Settings => settingsPanel,
                PanelState.Store => storePanel,
                PanelState.LevelSelect => levelSelectPanel,
                _ => mainMenuPanel
            };

            _currentPanel.SetActive(true);
        }

        public void ChangeToMainMenuPanel()
        {
            ChangeState(PanelState.MainMenu);
        }
    
        public void ChangeToSettingsPanel()
        {
            ChangeState(PanelState.Settings);
        }
    
        public void ChangeToStorePanel()
        {
            ChangeState(PanelState.Store);
            storePanel.GetComponent<StorePanelManager>().SetCoinsText();
            storePanel.GetComponent<StorePanelManager>().SetStarsText();
        }
    
        public void ChangeToLevelSelectPanel()
        {
            ChangeState(PanelState.LevelSelect);
        }

        private enum PanelState
        {
            MainMenu,
            Settings,
            Store,
            LevelSelect
        }
    }
}