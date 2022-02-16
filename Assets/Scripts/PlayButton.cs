using System;
using PlayerCreator.Specialization;
using PlayerCreator.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _warningView;
    [SerializeField] private StatsChanger _statsChanger;
    [SerializeField] private SpecializationChanger _specializationChanger;

    public void some()
    {
        PlayerPrefs.DeleteAll();
    }
        
    public void StartAndSave()
    {
        PlayerPrefs.SetInt("firstSave", 1);
        if (PlayerPrefs.GetInt("firstSave") == 1)
        {
            PlayerPrefs.SetInt("FreeStats", _statsChanger.FreeStats);
            if (_statsChanger.FreeStats == 0)
            {
                PlayerPrefs.SetInt("ClassType", _specializationChanger.CurrentIndex);

                SceneManager.LoadScene("//namescene//");
            }
            else
            {
                _warningView.SetActive(true);
            }
        }
    }
}