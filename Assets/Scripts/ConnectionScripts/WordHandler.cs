using UnityEngine.UIElements;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordHandler : MonoBehaviour
{
    private WordPair savedWordPair;
    private RectTransform linePoint;
    private List<WordHandler> connectedWord = new List<WordHandler>();
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
        if(connectedWord == null || connectedWord.Count == 0)
        {
            return false;
        }
        if(connectedWord.Count == 1)
        {
            return savedWordPair.Equals(connectedWord[0].savedWordPair);
        }
        foreach(WordHandler word in connectedWord)
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
        connectedWord = null;
    }

    public IEnumerator RemoveWordPair(float time)
    {
        yield return new WaitForSeconds(waitTimer);
        StartEndAnimation();
        foreach(WordHandler word in connectedWord)
        {
            word.StartEndAnimation();
        }
        foreach(GameObject line in connectedLine)
        {
            line.SetActive(false);
        }

        yield return new WaitUntil(() => animationEnded == true);
        if(connectedWord != null)
        {
            foreach(WordHandler word in connectedWord)
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
    public WordHandler GetConnectedWord() { return connectedWord[0]; }
    public void SetSavedWordPair(WordPair newPair) { savedWordPair = newPair; }
    public void SetLinePoint(RectTransform point) {linePoint = point;}
    public void SetConnectedWord(WordHandler word) { connectedWord[0] = word; }
    public void AddConnectedWord(WordHandler word) {}
    public void SetConnectedLine(GameObject line) { connectedLine[0] = line; }

    private void OnDestroy() 
    {
        SendMessageUpwards("CheckIfAllPairsDeleted", SendMessageOptions.DontRequireReceiver);    
    }
}
