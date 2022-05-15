using UnityEngine;

[RequireComponent(typeof(Beast))]
public abstract class BeastBehaviour : MonoBehaviour
{
    public Beast beast { get; private set; }
    public float duration; 

    private void Awake()
    {
        this.beast = GetComponent<Beast>();
        this.enabled = false;
    }

    public virtual void Enable(float duration)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);

    }
    public void Enable()
    {
        Enable(this.duration);
    }
    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke();

    }
}
