using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform Player;
    [SerializeField] GameObject targetPrefab;
    public List<GameObject> targets = new List<GameObject>();
    public static TargetManager GetTargetManager;
    public bool rebuild = false;
    // Start is called before the first frame update
    void Start()
    {
        GetTargetManager = this;
        BuildTargetList();
    }

    // Update is called once per frame
    void Update()
    {
        if (rebuild)
        {
            RebuildTargets();
            rebuild = false;
        }
    }
    void BuildTargetList()
    {
        for (int x = 0; x < 12; x++)
        {
            for (int y = 0; y > -10; y--)
            {
                GameObject target =Instantiate(targetPrefab, new Vector2(x - 5.5f, y + 4.5f), Quaternion.identity);
                target.GetComponent<Target>().player = Player;
                target.transform.localScale = new Vector3(1, 1, 1);
                targets.Add(target);
                
            }
        }
        RebuildTargets();
    }

    public void RebuildTargets()
    {
        foreach (var target in targets)
        {
            target.SetActive(true);

            target.GetComponent<Target>().ColliderSwitch(false);
        }
        foreach (var target in targets)
        {
            target.GetComponent<Target>().Sweep();
        }
        foreach (var target in targets)
        {
            Target targetScript = target.GetComponent<Target>();
            if (targetScript.targetFrame == TargetFrame.Available)
            {
                target.SetActive(false);
            }
            else
            {
                target.GetComponent<Target>().ColliderSwitch(true);
            }
            
        }
    }
}
