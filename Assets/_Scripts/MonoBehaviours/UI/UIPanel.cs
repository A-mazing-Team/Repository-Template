using UnityEngine;
using System.Threading.Tasks;

public class UIPanel : MonoBehaviour
{
    [SerializeField] protected GameObject _content;

    [SerializeField] private CustomAnimation _showAnimation;
    [SerializeField] private CustomAnimation _hideAnimation;

    [Header("Editor")]
    [SerializeField] private Color _showingColor = new Color(0, 1, 0, 0.1f);
    [SerializeField] private Color _hidenColor = new Color(1, 0, 0, 0.1f);

    public GameObject Content => _content;
    public bool IsShowing => _content != null &&_content.activeInHierarchy;
    public Color ShowingColor => _showingColor;
    public Color HidenColor => _hidenColor;

    public async void Show(float delay, bool animation = true)
    {
        await Task.Delay((int)(delay * 1000));

        Show(animation);
    }
    public async void Hide(float delay, bool animation = true)
    {
        await Task.Delay((int)(delay * 1000));

        Hide(animation);
    }

    public virtual bool TryShow(bool animation = true)
    {
        if (IsShowing) return false;

        Show(animation);
        return true;
    }

    public virtual bool TryHide(bool animation = true)
    {
        if (IsShowing == false) return false;

        Hide(animation);
        return true;
    }

    protected virtual void Show(bool animation = true)
    {
        _content.SetActive(true);
        if (animation && _showAnimation != null) _showAnimation.Play();
    }

    protected virtual void Show()
    {
        _content.SetActive(true);
        if (_showAnimation != null) _showAnimation.Play();
    }

    protected virtual void Hide(bool animation = true)
    {
        if (animation && _hideAnimation != null) _hideAnimation.Play(() => _content.SetActive(false));
        else _content.SetActive(false);
    }
    protected virtual void Hide()
    {
        if (_hideAnimation != null) _hideAnimation.Play(() => _content.SetActive(false));
        else _content.SetActive(false);
    }

    private void OnGUI()
    {
        GUI.backgroundColor = Color.red;
    }
}