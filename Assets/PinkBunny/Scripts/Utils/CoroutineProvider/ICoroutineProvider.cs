using System.Collections;
using UnityEngine;

namespace Laphed.CoroutineProvider
{
    public interface ICoroutineProvider
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine coroutine);
    }
}