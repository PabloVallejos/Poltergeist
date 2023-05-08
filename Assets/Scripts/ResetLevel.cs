using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    public void Change(string i)
    {
        SceneManager.LoadScene(i);
    }
    
}
