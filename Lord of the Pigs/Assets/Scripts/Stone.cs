using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Stone : MonoBehaviour, IExplodable
{
    [SerializeField] private bool _isThisStoneHideFinish;
    [SerializeField] private FinishPlace _finishGoPrefab;
    

    public void GetBombEffect()
    {
        if (_isThisStoneHideFinish)
        {
            var finish = Instantiate(_finishGoPrefab);
            finish.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}