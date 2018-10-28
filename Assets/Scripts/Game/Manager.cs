using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Texture2D cursorTexture;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(16, 16), CursorMode.Auto);
    }

    public void NormalCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void GameCursor()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(16, 16), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting game. Source: escape key");
            Application.Quit();
        }
    }
}
