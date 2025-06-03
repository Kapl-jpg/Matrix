using System.Collections;
using TMPro;
using UnityEngine;

namespace Map
{
    public class LockMap : MonoBehaviour
    {
        [SerializeField] private TMP_Text lockMessage;
        [SerializeField] private GameObject unclickableMask;

        [SerializeField] private float lockMessageTime;

        public void ShowMessage()
        {
            StartCoroutine(ShowLockMessage());
        }

        private IEnumerator ShowLockMessage()
        {
            lockMessage.gameObject.SetActive(true);
            lockMessage.text = $"Дом заперт";
            yield return new WaitForSeconds(lockMessageTime);
            lockMessage.gameObject.SetActive(false);
        }
    }
}