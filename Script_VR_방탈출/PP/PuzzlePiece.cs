using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceID; // 조각의 고유 ID

    private void OnMouseDown()
    {
        // 부모 오브젝트의 컴포넌트를 찾기 위해 자신의 트랜스폼을 가져옴
        Transform parent = transform.parent;

        // 부모 오브젝트가 null이 아니고 PuzzleGameManager 컴포넌트를 가지고 있다면 처리
        if (parent != null)
        {
            PuzzleGameManager puzzleGameManager = parent.GetComponent<PuzzleGameManager>();
            if (puzzleGameManager != null)
            {
                puzzleGameManager.CollectPiece(pieceID);
                Destroy(gameObject);
            }
        }
    }
}
