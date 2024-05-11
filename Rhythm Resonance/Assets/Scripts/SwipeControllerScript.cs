using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SwipeControllerScript : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;

    [SerializeField] float tweenTime;
    //[SerializeField] LeanTweenType tweenType;

    [SerializeField] Button previousBtn, nextBtn;
    Graphic graphic;
    Button button;
    public AnimationCurve animationCurve;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        UpdateArrowButton();
        Graphic graphic = GetComponent<Graphic>();
        Button button = GetComponentInParent<Button>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Next();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Previous();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadSceneForCurrentPage();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LaunchScreen");
        }
    }

    public void LoadSceneForCurrentPage()
    {
        string sceneName = "Level" + currentPage;
        SceneManager.LoadScene(sceneName);
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
        else if (currentPage == maxPage)
        {
            currentPage = 1;
            targetPos -= (maxPage - 1) * pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep; ;
            MovePage();
        }
        else if (currentPage == 1)
        {
            currentPage = maxPage;
            targetPos += (maxPage - 1) * pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        //levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(animationCurve);
        UpdateArrowButton();
    }

    void UpdateArrowButton()
    {
        nextBtn.interactable = true;
        previousBtn.interactable = true;
        //if (currentPage == 1) previousBtn.interactable = false;
        //else if (currentPage == maxPage) nextBtn.interactable = false;
    }
}
