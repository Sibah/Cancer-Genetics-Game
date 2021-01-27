using UnityEngine.UIElements;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordHandler : MonoBehaviour
{
    private WordPair savedWordPair;
    private RectTransform linePoint;
    private List<WordHandler> connectedWords = new List<WordHandler>();
    private List<GameObject> connectedLine = new List<GameObject>();
    public float waitTimer = 1f;
    public bool onRightSide { get{ return transform.parent.name.Equals("RightSide"); } set{}}
    public bool animationEnded = false;
    public string wordText
    {
        set
        {
            GetComponentInChildren<UnityEngine.UI.Text>().text = value;
        }
    }

    public void SendPositionData()
    {
        SendMessageUpwards("DrawLine", this, SendMessageOptions.RequireReceiver);
    }

    public bool CheckIfConnectedToCorrectPair()
    {
        if(connectedWords == null || connectedWords.Count == 0)
        {
            return false;
        }
        if(connectedWords.Count == 1)
        {
            return savedWordPair.Equals(connectedWords[0].savedWordPair);
        }
        foreach(WordHandler word in connectedWords)
        {
            if(!savedWordPair.Equals(word.savedWordPair))
            {
                return false;
            }
        }
        return true;
    }

    public void ResetConnection()
    {
        connectedWords = null;
    }

    public IEnumerator RemoveWordPair(float time)
    {
        yield return new WaitForSeconds(waitTimer);
        StartEndAnimation();
        foreach(WordHandler word in connectedWords)
        {
            word.StartEndAnimation();
        }
        foreach(GameObject line in connectedLine)
        {
            line.SetActive(false);
        }

        yield return new WaitUntil(() => animationEnded == true);
        if(connectedWords != null)
        {
            foreach(WordHandler word in connectedWords)
            {
                Destroy(word.gameObject);
            }
        }
        foreach(GameObject line in connectedLine)
        {
            Destroy(line);
        }
        Destroy(gameObject);
    }

    // Given to Animation event
    public void SetAnimationEndedTrue()
    {
        animationEnded = true;
        GetComponent<Animator>().runtimeAnimatorController.animationClips[0].events = System.Array.Empty<AnimationEvent>();
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

    public void WronglyConnected()
    {
        Animator animator = GetComponent<Animator>();
        AnimationEvent e = new AnimationEvent();
        e.functionName = "SetIsWrongSelectionToFalse";
        e.time = animator.runtimeAnimatorController.animationClips[3].length;
        animator.runtimeAnimatorController.animationClips[3].AddEvent(e);
    }

    public void SetIsWrongSelectionToFalse()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isWrongSelection", false);
        animator.runtimeAnimatorController.animationClips[0].events = System.Array.Empty<AnimationEvent>();
    }

    public bool CheckIfFullyConnected()
    {
        return savedWordPair.connectionCount-1 == connectedWords.Count;
    }

    public WordPair GetSavedWordPair() { return savedWordPair; }
    public Vector3 GetLinePointPosition() { return linePoint.position; }
    public List<WordHandler> GetConnectedWords() { return connectedWords; }
    public void SetSavedWordPair(WordPair newPair) { savedWordPair = newPair; }
    public void SetLinePoint(RectTransform point) {linePoint = point;}
    public void SetconnectedWords(WordHandler word) { connectedWords[0] = word; }
    public void AddconnectedWords(WordHandler word) {}
    public void SetConnectedLine(GameObject line) { connectedLine[0] = line; }

    private void OnDestroy() 
    {
        SendMessageUpwards("CheckIfAllPairsDeleted", SendMessageOptions.DontRequireReceiver);    
    }
}
