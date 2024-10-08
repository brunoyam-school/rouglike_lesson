﻿using System.Collections;
using GameCore.Pool;
using TMPro;
using UnityEngine;

namespace GameCore.UI
{
    public class DamageTextSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool _textPool;
        private readonly WaitForSeconds _wait = new WaitForSeconds(0.05f);

        public void Activate(Transform target, int damage)
        {
            GameObject damageText = _textPool.GetFromPool();
            damageText.transform.SetParent(transform);
            damageText.transform.position = target.position + GetNewRandomPosition();
            if (damageText.TryGetComponent(out TextMeshPro TMP))
            {
                TMP.text = damage.ToString();
                TMP.fontSize = Mathf.Clamp(damage, 2f, 15f);
                TMP.gameObject.SetActive(true);
                StartCoroutine(FadeAnimation(TMP, damageText));
            }
        }
        private Vector3 GetNewRandomPosition() => 
            new(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

        private IEnumerator FadeAnimation(TextMeshPro text, GameObject targetEffect)
        {
            Color color = text.color;
            color.a = 1f;
            for (float f = 1f; f >= - 0.05f; f-= 0.05f)
            {
                text.color = color;
                color.a = f;
                yield return _wait;
            }
            targetEffect.SetActive(false);
        }
    }
}