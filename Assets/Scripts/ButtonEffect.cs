using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float scaleAmount = 1.1f;
    public float speed = 0.1f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //AudioManager.Instance.Play(GameSound.ButtonClick);
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale * scaleAmount));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale));
    }

    private System.Collections.IEnumerator ScaleTo(Vector3 target)
    {
        float t = 0f;
        Vector3 start = transform.localScale;

        while (t < 1f)
        {
            t += Time.deltaTime / speed;
            transform.localScale = Vector3.Lerp(start, target, t);
            yield return null;
        }
    }
}
