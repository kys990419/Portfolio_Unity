using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    public static PuzzleGameManager Instance; // 싱글톤 인스턴스

    public int totalPieces; // 조각의 총 개수
    private int collectedPieces; // 수집된 조각의 개수

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CollectPiece(int pieceID)
    {
        collectedPieces++;
        Debug.Log("Piece Collected: " + pieceID);

        if (collectedPieces == totalPieces)
        {
            CompletePuzzle();
        }
    }

    private void CompletePuzzle()
    {
        Debug.Log("Puzzle Completed!");
        // 퍼즐이 완성되었을 때의 동작을 작성
    }
}
