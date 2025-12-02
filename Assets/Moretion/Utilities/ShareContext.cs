using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShareContext : MonoBehaviour
{
    public static ShareContext Instance;

    private SynchronizationContext m_context;

    private void Awake()
	{
        Instance = this;
        m_context = SynchronizationContext.Current;
    }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SynchronizationContext GetSharedSynchronizationContext()
	{
        return m_context;
    }

	public void OnApplicationQuit()
	{
        if (m_context != null)
        {
            m_context = null;
        }
    }

	public void OnDestroy()
	{
        if (m_context != null)
        {
            m_context = null;
        }
    }
}
