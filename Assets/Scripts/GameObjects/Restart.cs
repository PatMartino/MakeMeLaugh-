using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameObjects
{
    public class Restart : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(0); 
        }

    
    }
}
