using UnityEngine.UIElements;
using UnityEngine;

public class WordHandler : MonoBehaviour
{
    private WordPair savedWordPair;
    private RectTransform linePoint;
    private WordHandler connectedWord;
    public bool onRightSide { get{ return transform.parent.name.Equals("RightSide"); } set{}}

    public void SendPositionData()
    {
        SendMessageUpwards("HandleNewPositionData", this, SendMessageOptions.RequireReceiver);
    }

    public bool CheckIfConnectedToCorrectPair()
    {
        if(connectedWord == null)
        {
            return false;
        }
        return savedWordPair.Equals(connectedWord.savedWordPair);
    }

    public WordPair GetSavedWordPair() { return savedWordPair; }
    public Vector3 GetLinePointPosition() { return linePoint.position; }
    public WordHandler GetConnectedWord() { return connectedWord; }
    public void SetSavedWordPair(WordPair newPair) { savedWordPair = newPair; }
    public void SetLinePoint(RectTransform point) {linePoint = point;}
    public void SetConnectedWord(WordHandler word) { connectedWord = word; }
}
