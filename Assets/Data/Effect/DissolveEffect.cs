using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : EffectAbstract
{
    [SerializeField] public float dissolveDuration = 1.0f;

    protected int dissolveAmountID = Shader.PropertyToID("_DissolveAmount");

    public void StartDissolve()
    {
        Debug.Log("Start Dissolve Effect");
        StartCoroutine(DissolveCoroutine());
    }
    protected IEnumerator DissolveCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            float dissolveAmount = Mathf.Lerp(0, 1.1f, (elapsedTime / dissolveDuration));
            dissolveMaterial.SetFloat(dissolveAmountID, dissolveAmount);
            yield return null;
        }
        Debug.Log("Done Dissolve Effect");
    }
}
