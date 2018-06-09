using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Sincronizamos valores con el animator
        anim.SetFloat("Vert", Input.GetAxis("Vertical"));   
        anim.SetFloat("Hor", Input.GetAxis("Horizontal"));

		if (Input.GetAxis ("Horizontal") != 0) {
			anim.SetBool ("Moving", true);
		} else if (Input.GetAxis ("Vertical") != 0) {
			anim.SetBool ("Moving", true);
		} else {
			anim.SetBool ("Moving", false);
		}

		if (Input.GetKey("q")) {
			anim.SetFloat("Rotation", -1);
		} else if (Input.GetKey("e")) {
			anim.SetFloat("Rotation", 1);
		} else {
			anim.SetFloat("Rotation", 0);
		}


        //Coordinamos la posicion Idle
        setIdle();

        //Gestor de animaciones
        if (Input.GetKey(KeyCode.LeftShift))    //Correr
        {
            sprint = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space))   //Saltar
        {
            jump = true;
        }
        else
        {                                       //Version por defecto
            jump = false;
            sprint = 0;
            kneeling = false;
        }


        

		//Se asignan las variables a animator

        
        anim.SetBool("Jump", jump);
        anim.SetFloat("Sprint", sprint);

    }
    void setIdle()  //Configura el idle
    {
        if ((Input.GetAxis("Vertical") >= 0.5 && Input.GetAxis("Vertical") <= 0.8) ||( Input.GetAxis("Horizontal") >= 0.5 && Input.GetAxis("Horizontal") <= 0.8))   //Para simular la aleatoriedad de las poses
        {                                                                                                                                                           //estaticas usamos el momento de transicion
            //Debug.Log("hello");                                                                                                                                   //entre quieto y en movimiento para 

			idleType = ((float) Random.Range(0, 1));                                                                                                         //asignar la pose que se desea (0,0.5,1)
            
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)             //Si esta quieto comienza a cont
        {
            Countdown += Time.deltaTime;
        }
        else
        {
            Countdown = 0;                                                                  //Si se mueve se resetea el contador
        }
        anim.SetFloat("idleType", idleType);
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