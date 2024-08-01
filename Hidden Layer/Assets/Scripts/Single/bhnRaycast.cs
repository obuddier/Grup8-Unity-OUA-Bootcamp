using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bhnRaycast : MonoBehaviour
{
    [Header("Raycast Zýmbýrtýlarý")]
    [SerializeField] private float rayLength = 5f;
    private Camera cam;

     

    private NoteController noteController;
    //private NoteController readableItem;

    [Header("Crosshair")]
    [SerializeField] private Image crossHair;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Physics.Raycast(cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
        {
           var readableItem = hit.collider.GetComponent<NoteController>();
            
            if (readableItem != null)
            {
                noteController = readableItem;
                HighlightCrosshair(true);
            }

            else
            {
                ClearNote();
            }
        }

        else
        {
            ClearNote();
        }

        if (noteController != null)
        {
            if(Input.GetKeyDown(interactKey))
            {
                noteController.ShowNote();
            }
        }

    }

    void ClearNote()
    {
        if (noteController != null)
        {
            HighlightCrosshair(false);
            noteController=null;
        }
    }
    void HighlightCrosshair(bool on)
    {
        if (on)
        {
            crossHair.color = Color.red;
        }
        else { crossHair.color = Color.white; }
    }
}
