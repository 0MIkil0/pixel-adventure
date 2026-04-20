using System;
using System.Collections;
using UnityEngine;

public class FailingPlatform : MonoBehaviour
{
    private static readonly int IsFailing = Animator.StringToHash("isFailing");
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator.SetBool(IsFailing, false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(platformOff());
        }
    }

    IEnumerator platformOff()
    {
        yield return new WaitForSeconds(2f);
        _animator.SetBool(IsFailing, true);
        _boxCollider2D.enabled = false;
        yield return new WaitForSeconds(5f);
        _animator.SetBool(IsFailing, false);
        _boxCollider2D.enabled = true;
    }
}
 