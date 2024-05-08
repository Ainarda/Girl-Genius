using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_line : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;
    [SerializeField]
    private GameObject currentLine;

    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private EdgeCollider2D edgeCollider;
    [SerializeField]
    private List<Vector2> fingerPosition;

    [SerializeField]
    private bool IsLoop = false;

    [SerializeField]
    private List<GameObject> activatePoint;

    [SerializeField]
    private float lineSize = 0.25f;
    private Observer observer;

    private bool canDraw = true;
    // Start is called before the first frame update
    void Start()
    {
        observer = GameObject.FindGameObjectWithTag("Observer").GetComponent<Observer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canDraw)
        {
            if (activatePoint != null)
                foreach (var pair in activatePoint)
                    pair.GetComponent<TargetPoint>().CanActivate();
            CreateLine();
        }
        if (Input.GetMouseButton(0) && canDraw)
        {
            Vector2 tmpFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tmpFingerPos, fingerPosition[fingerPosition.Count-1])>0.1f)
            {
                UpdateLine(tmpFingerPos);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (IsLoop)
            {
                canDraw = false;
                if (Vector2.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(lineRenderer.positionCount-1))<1.0f)
                {
                    Debug.LogWarning("RightCoord");
                    observer.CompleteScene();
                }
                else
                {
                    //TMP
                    observer.gameObject.GetComponent<LoadSceneUI>().LoadLoseUI();
                }
            }
            else
                StartCoroutine(WaitForCheck());     
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.transform.parent = this.transform;
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(lineSize, lineSize);
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPosition.Clear();
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPosition[0]);
        lineRenderer.SetPosition(1, fingerPosition[1]);
        edgeCollider.points = fingerPosition.ToArray();
    }

    private void UpdateLine(Vector2 newFingerPos)
    {
        fingerPosition.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, newFingerPos);
        edgeCollider.points = fingerPosition.ToArray();
    }

    private IEnumerator WaitForCheck()
    {
        yield return new WaitForSeconds(1);
        observer.ActivateAction();
        yield return new WaitForSeconds(5);
        observer.CompleteScene();
        canDraw = false;
    }
}
