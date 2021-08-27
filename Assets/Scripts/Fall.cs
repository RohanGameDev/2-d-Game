using UnityEngine.SceneManagement;
using UnityEngine;

public class Fall : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
