using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Utilisez du Caching ! Optimisation !!
    private Transform myTransform;

    public Controller playerController;
    public Transform[] views;

    // public float transitionSpeed;

    // transitionSmooth correspond plus à votre problème, la valeur représente
    // la durée en seconde pour que la caméra passe d'un état à un autre.
    // (lisez la doc de Vector3.SmoothDamp)
    [Header("Parameters"), Range(0.001f, 2f)]
    public float transitionSmooth = 0.2f;
    // Rotation de la caméra en degré par seconde, à ajuster à travers l'inspector !
    [Range(45f, 3600f)]
    public float transitionRotationSpeed = 360f;

    // Va être modifié chaque frame
    private Vector3 cameraReference = Vector3.zero;
    private Vector3 targetCameraRotation = Vector3.zero;

    // Notre coroutine
    private IEnumerator moveCameraToView = null;

    private bool stopUpdate = false;



    // Mouse mouvements
    public float speedV = 2.0f;
    private float pitch = 0.0f;
    public float speedH = 2.0f;
    private float yaw = 0.0f;

    private void Start()
    {
    }

    void Awake()
    {
        myTransform = transform;
        MoveCameraToView(views[0]);
    }

    void Update()
    {
        if (stopUpdate)
            return;

        // Rotation with mouse : movements of camera
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // Créer un nouveau vecteur en mémoire chaque frame, c'est pas cool...
        // Mieux vaut completement changé la technique de suivi de la souris...
        // Au pire on peut utiliser Vector3.Set pour pas rédéfinir un vector
        // en mémoire à chaque frame...

        // myTransform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        targetCameraRotation.Set(pitch, yaw, 0.0f);
        myTransform.eulerAngles = targetCameraRotation;


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stopUpdate = true;
            MoveCameraToView(views[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && playerController.weaponEquiped)
        {
            stopUpdate = true;
            MoveCameraToView(views[1]);
        }
    }

    private void MoveCameraToView(Transform currentView)
    {
        if (moveCameraToView != null)
            StopCoroutine(moveCameraToView);
        moveCameraToView = MoveCameraToViewCoroutine(currentView);
        StartCoroutine(moveCameraToView);
    }

    private IEnumerator MoveCameraToViewCoroutine(Transform currentView)
    {
        Vector3 targetPosition = currentView.position;
        Quaternion targetRotation = currentView.rotation;
        float dist = 0f;
        float total = Vector3.Distance(myTransform.position, targetPosition);

        while (dist > 0.1f)
        {
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, dist / total);
            myTransform.position = Vector3.SmoothDamp(myTransform.position, targetPosition, ref cameraReference, transitionSmooth);

            dist = Vector3.Distance(myTransform.position, targetPosition);

            yield return null;
        }

        myTransform.rotation = targetRotation;
        myTransform.position = targetPosition;
        stopUpdate = false;
    }





    // Je la laisse là mais s'il y avait ce problème de tremblote,
    // c'est parce que Update et LateUpdate faisez pas la même chose
    // la caméra savez pas où aller !
    /*private void OldUnusedLateUpdate()
    {
        // Même si ici c'est une utilisation dérivée de Lerp, c'est pas recommandé, lisez bien la doc de Lerp !
        // myTransform.position = Vector3.Lerp(myTransform.position, currentView.position, Time.deltaTime * transitionSpeed);
        // SmoothDamp passe smoothly d'une position à une autre en 'transitionSmooth' seconde !
        myTransform.position = Vector3.SmoothDamp(myTransform.position, currentView.position, ref cameraReference, transitionSmooth);*/

        // Les eulerAngles c'est du caca, faut rarement les utiliser, et incrémenter
        // ses valeurs !
        // Aussi 'currentView' est déjà un Transform, pas besoin d'y réaccèder avec '.transform'
        // on optimise tout ça !
        /* Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(myTransform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(myTransform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(myTransform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            ); */
        // myTransform.eulerAngles = currentAngle;

        /*myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, currentView.rotation, transitionRotationSpeed * Time.deltaTime);
    }*/
}
