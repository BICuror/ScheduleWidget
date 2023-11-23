using UnityEngine;

public sealed class UITargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private FollowType _followType;

    private delegate Vector3 GetFollowingPosition();
    private GetFollowingPosition _getFollowingPositionDelegate;

    private void Start()
    {
        switch (_followType)
        {
            case FollowType.X: _getFollowingPositionDelegate = GetFollowingXPosition; break;
            case FollowType.Y: _getFollowingPositionDelegate = GetFollowingYPosition; break;
        }
    }

    private void Update()
    {
        transform.position = _getFollowingPositionDelegate();
    }

    private Vector3 GetFollowingXPosition() 
    {
        return new Vector3(_target.position.x, transform.position.y, transform.position.z);
    }

    private Vector3 GetFollowingYPosition() 
    {
        return new Vector3(transform.position.x, _target.position.y, transform.position.z);
    }


    private enum FollowType
    {
        X,
        Y
    }
}
