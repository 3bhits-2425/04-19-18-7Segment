using UnityEngine;

public class KnaufDreher : MonoBehaviour
{
    public Transform drehteil; // Das Hauptobjekt, das sich drehen soll
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Wenn die linke Maustaste gedrückt wird -> Drehen starten
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // Prüfen, ob der Knauf getroffen wurde
                {
                    isDragging = true;
                    lastMousePosition = Input.mousePosition;
                }
            }
        }

        // Falls der Spieler den Knauf hält, berechnen wir die Drehung
        if (isDragging)
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            float rotationAmount = deltaMouse.x * 0.5f; // Skaliere die Mausbewegung zur Rotation
            drehteil.Rotate(0, 0, -rotationAmount); // Rotation um die Z-Achse
            lastMousePosition = Input.mousePosition;
        }

        // Wenn die Maustaste losgelassen wird -> Drehen stoppen
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
