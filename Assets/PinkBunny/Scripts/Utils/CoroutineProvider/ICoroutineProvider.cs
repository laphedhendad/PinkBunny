using System.Collections;
using UnityEngine;

namespace Laphed.CoroutinesProvider
{
    public interface ICoroutineProvider
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine coroutine);
    }
}