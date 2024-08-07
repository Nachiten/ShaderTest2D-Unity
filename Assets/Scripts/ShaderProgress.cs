using UnityEngine;

public class Materials : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool loop = true;
    
    private Material material;
    private float progress;
    
    private static readonly int ProgressFloatKey = Shader.PropertyToID("_Progress");

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (speed == 0f)
            return;
        
        progress += Time.deltaTime * speed;
        
        material.SetFloat(ProgressFloatKey, progress);
        
        if (progress > 1f && loop)
        {
            progress = 0f;
        }
    }
}
