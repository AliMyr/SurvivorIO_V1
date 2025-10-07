using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private string windowName;

    [Space(10)]
    [SerializeField] private Animator windowAnimator;
    [SerializeField] private string openAnimationName;
    [SerializeField] private string idleAnimationName;
    [SerializeField] private string closeAnimationName;
    [SerializeField] private string hiddenAnimationName;

    public bool IsOpened { get; protected set; } = false;

    protected Animator WindowAnimator
    {
        get
        {
            if (windowAnimator == null)
                windowAnimator = GetComponent<Animator>();

            return windowAnimator;
        }
    }

    public virtual void Initialize() { }

    public void Show(bool isImmediately)
    {
        OpenStart();

        if (WindowAnimator != null && gameObject.activeInHierarchy)
            WindowAnimator.Play(isImmediately ? idleAnimationName : openAnimationName);

        if (isImmediately)
            OpenEnd();
    }

    public void Hide(bool isImmediately)
    {
        bool wasInactive = !gameObject.activeSelf;
        if (wasInactive)
            gameObject.SetActive(true);

        CloseStart();

        if (WindowAnimator != null && gameObject.activeInHierarchy)
            WindowAnimator.Play(isImmediately ? hiddenAnimationName : closeAnimationName);

        if (isImmediately)
            CloseEnd();
        else
        {
            if (wasInactive)
                gameObject.SetActive(false);
        }
    }

    protected virtual void OpenStart()
    {
        gameObject.SetActive(true);
        IsOpened = true;
    }

    protected virtual void OpenEnd() { }

    protected virtual void CloseStart()
    {
        IsOpened = false;
    }

    protected virtual void CloseEnd()
    {
        gameObject.SetActive(false);
    }
}
