using General.Constants;
using UnityEngine;

namespace General
{
    public class AudioManager : Subscriber
    {
        [SerializeField] private AudioSource soundsSource;

        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        [Event(Names.CLICK)]
        private void OnClick()
        {
            soundsSource.Play();
        }
    }
}
