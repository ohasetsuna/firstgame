using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    void Start()
    {
        // İmleci gizle ve kilitle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Escape tuşuna basıldığında imleci serbest bırak ve görünür yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        // Mouse1 tuşuna (sol tıklama) basıldığında imleci tekrar gizle ve kilitle
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}