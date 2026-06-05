using UnityEngine;
using System.Collections;

public class RobotActionController : MonoBehaviour
{
    [Tooltip("Об'єкт, який буде стрибати (контейнер з деталями)")]
    [SerializeField] private Transform _robotContainer;

    [SerializeField] private float _jumpHeight = 1.5f;
    [SerializeField] private float _jumpDuration = 0.5f;

    private bool isAnimating = false;
    private Vector3 originalPosition;

    private void Start()
    {
        if (_robotContainer != null)
        {
            originalPosition = _robotContainer.position;
        }
    }

    public void PerformTestAction()
    {
        if (!isAnimating && _robotContainer != null)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine()
    {
        isAnimating = true;
        float elapsedTime = 0f;

        while (elapsedTime < _jumpDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / _jumpDuration;
            float currentHeight = Mathf.Sin(normalizedTime * Mathf.PI) * _jumpHeight;

            _robotContainer.position = originalPosition + new Vector3(0, currentHeight, 0);
            yield return null;
        }

        _robotContainer.position = originalPosition;
        isAnimating = false;
    }
}