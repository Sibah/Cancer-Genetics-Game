using UnityEngine.UIElements;
using UnityEngine;
using System.Collections;

public class WordHandler : MonoBehaviour
{
    private WordPair savedWordPair;
    private RectTransform linePoint;
    private WordHandler connectedWord;
    private GameObject connectedLine;
    public float waitTimer = 1f;
    public bool onRightSide { get{ return transform.parent.name.Equals("RightSide"); } set{}}
    public bool animationEnded = false;

    public void SendPositionData()
    {
        SendMessageUpwards("DrawLine", this, SendMessageOptions.RequireReceiver);
    }

    public bool CheckIfConnectedToCorrectPair()
    {
        if(connectedWord == null)
        {
            return false;
        }
        return savedWordPair.Equals(connectedWord.savedWordPair);
    }

    public void ResetConnection()
    {
        connectedWord = null;
    }

    public IEnumerator RemoveWordPair(float time)
    {
        yield return new WaitForSeconds(waitTimer);
        StartEndAnimation();
        connectedWord.StartEndAnimation();
        connectedLine.SetActive(false);

        yield return new WaitUntil(() => animationEnded == true);
        if(connectedWord != null)
        {
            Destroy(connectedWord.gameObject);
        }
        if(connectedLine != null)
        {
            Destroy(connectedLine);
        }
        Destroy(gameObject);
    }

    // Given to Animation event
    public void SetAnimationEndedTrue()
    {
        animationEnded = true;
    }
    
    public void SelectWord(bool selected)
    {
        GetComponent<Animator>().SetBool("isSelected", selected);
    }

    public void StartEndAnimation()
    {
        Animator animator = GetComponent<Animator>();
        AnimationEvent e = new AnimationEvent();
        e.functionName = "SetAnimationEndedTrue";
        e.time = animator.runtimeAnimatorController.animationClips[0].length;
        animator.runtimeAnimatorController.animationClips[0].AddEvent(e);
        animator.SetBool("isConnected", true);
    }

    public WordPair GetSavedWordPair() { return savedWordPair; }
    public Vector3 GetLinePointPosition() { return linePoint.position; }
    public WordHandler GetConnectedWord() { return connectedWord; }
    public void SetSavedWordPair(WordPair newPair) { savedWordPair = newPair; }
    public void SetLinePoint(RectTransform point) {linePoint = point;}
    public void SetConnectedWord(WordHandler word) { connectedWord = word; }
    public void SetConnectedLine(GameObject line) { connectedLine = line; }

    private void OnDestroy() 
    {
        SendMessageUpwards("CheckIfAllPairsDeleted", SendMessageOptions.DontRequireReceiver);    
    }
}
