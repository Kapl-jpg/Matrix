using Names;
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
        
        [Event(EventNames.Click)]
        private void OnClick()
        {
            soundsSource.Play();
        }
    }
}
