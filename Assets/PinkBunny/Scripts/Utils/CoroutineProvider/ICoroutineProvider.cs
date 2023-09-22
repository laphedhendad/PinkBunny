using System.Collections;
using UnityEngine;

namespace Laphed.Utils.CoroutineProvider
{
    public interface ICoroutineProvider
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine coroutine);
    }
}