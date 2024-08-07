using UnityEngine;

public class ShaderProgress : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool loop = true;
    [SerializeField] private bool bounce;
    
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
        
        if (progress is > 1f or < 0f && loop)
        {
            if (bounce)
            {
                speed *= -1;

                progress = progress > 1f ? 1f : 0f;
            }
            else
                progress = 0f;
        }
    }
}
