using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mobile Controller
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour
{
    //Movimiento
    public float idleType;  //Alternador de IDLES
    public float sprint;    //Selector de Sprint
    public bool jump;       //Saltar

    //Bebida
    public bool kneeling;   //Agacharse para coger lata
    public bool grab;       //Estirar mano
    public bool drinking;   //Beber
    public bool hold;       //Agarrar

    //Animaciones
    Animator anim;
    public float Countdown; //Cuenta atras para barrer


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        idleType = 1.0f;        //Idle Inicial
    }
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            anim.SetFloat("Vert", CrossPlatformInputManager.GetAxis("Vertical"));
            anim.SetFloat("Hor", CrossPlatformInputManager.GetAxis("Horizontal"));

            if (CrossPlatformInputManager.GetButton("Left"))
            {
                anim.SetFloat("Rotation", -1);
            }
            else if (CrossPlatformInputManager.GetButton("Right"))
            {
                anim.SetFloat("Rotation", 1);
            }
            else
            {
                anim.SetFloat("Rotation", 0);
            }
            if (CrossPlatformInputManager.GetButton("Shift"))    //Correr
            {
                sprint = 1;
            }
            else
            {                                       //Version por defecto

                sprint = 0;
            }
        }
        else
        {
            //Sincronizamos valores con el animator
            anim.SetFloat("Vert", Input.GetAxis("Vertical"));
            anim.SetFloat("Hor", Input.GetAxis("Horizontal"));


            if (Input.GetKey("q"))
            {
                anim.SetFloat("Rotation", -1);
            }
            else if (Input.GetKey("e"))
            {
                anim.SetFloat("Rotation", 1);
            }
            else
            {
                anim.SetFloat("Rotation", 0);
            }
            if (Input.GetKey(KeyCode.LeftShift))    //Correr
            {
                sprint = 1;
            }
            else
            {                                       //Version por defecto

                sprint = 0;
            }
        }

        if (anim.GetFloat("Hor") != 0)
        {
            anim.SetBool("Moving", true);
        }
        else if (anim.GetFloat("Vert") != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("PickUp", false);
            anim.SetBool("Moving", false);

        }

        //Se asignan las variables a animator

        anim.SetFloat("Sprint", sprint);

        //Coordinamos la posicion Idle
        setIdle();

        

        

		

    }
    void setIdle()  //Configura el idle
    {
        if ((anim.GetFloat("Vert") >= 0.5 && anim.GetFloat("Vert") <= 0.8) ||(anim.GetFloat("Hor") >= 0.5 && anim.GetFloat("Hor") <= 0.8))   //Para simular la aleatoriedad de las poses
        {                                                                                                                                                           //estaticas usamos el momento de transicion
            //Debug.Log("hello");                                                                                                                                   //entre quieto y en movimiento para 

			idleType = ((float) Random.Range(0, 1));                                                                                                         //asignar la pose que se desea (0,0.5,1)
            
        }
        if (anim.GetFloat("Vert") == 0 && anim.GetFloat("Hor") == 0)             //Si esta quieto comienza a cont
        {
            Countdown += Time.deltaTime;
        }
        else
        {
            Countdown = 0;                                                                  //Si se mueve se resetea el contador
        }
        anim.SetFloat("idleType", idleType);
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("pieces"))
		{
			Destroy (other.gameObject);
			anim.SetBool ("PickUp",true);
		}
	}
	/*
    void OnAnimatorIK()
    {
        if (grab)           //Si quiere coger la escoba
        {
            if (Can != null)
            {
                anim.SetLookAtWeight(1);        //Mira a la escoba
                anim.SetLookAtPosition(Can.position);
            }
            if (rightHandObj != null)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);    //Estira la mano derecha
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
            }
        }else if (hold)
        {
            
        }
        else
        {
            anim.SetLookAtWeight(0);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        }
    }*/

}