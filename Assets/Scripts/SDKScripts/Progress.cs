using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int LevelUnlock = 1;
    public float VolumeValue = 0.5f;
    public string LanguageCode;
    public bool IsTutorial = true;
}


namespace Agava.YandexGames
{
    public class Progress : MonoBehaviour
    {
        public PlayerInfo Info;

        public static Progress Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else
                Destroy(gameObject);

            if (Info.LevelUnlock <= 0)
            {
                Info.LevelUnlock = 1;
                Info.IsTutorial = true;
            }

        }

        public void Save()
        {
            var jsonString = JsonUtility.ToJson(Info);
            PlayerAccount.SetCloudSaveData(jsonString);
        }

        public void GetCloudInfo(string value)
        {
            Info = JsonUtility.FromJson<PlayerInfo>(value);
            TrySetStartLanguage();
        }

        private void TrySetStartLanguage()
        {
            if (Info.LanguageCode == null)
            {
                Info.LanguageCode = YandexGamesSdk.Environment.i18n.lang;
            }
        }
    }
}