using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float Fuerza; //establece un float editable al inspecionar el objeto con el script
    [SerializeField] private Transform ComprobarSuelo; //posicion del comprobante de suelo
    [SerializeField] private LayerMask Suelo;  // referencia a la capa del suelo
    [SerializeField] private LayerMask obstaculo;
    [SerializeField] private float radio; //rango del comprobante de suelo
    [SerializeField] private GameObject PantallaGameOver;
    [SerializeField] private TMP_Text TextoPuntaje;
    [SerializeField] private TMP_Text TextoHiscore;

    private int puntaje;
    private int Hiscore;
    private float tiempo;
    private Rigidbody2D cuerpo;
    private Animator AnimadorPersonaje;

    void Start()
    {
        Time.timeScale = 1f;
        cuerpo = GetComponent<Rigidbody2D>();
        AnimadorPersonaje = GetComponent<Animator>();
    }

    void Update()
    {
        bool TocandoSuelo = Physics2D.OverlapCircle(ComprobarSuelo.position, radio, Suelo); // comprueba si el radio del comprobante del suelo colisiona con un objeto cuya capa sea suelo
        AnimadorPersonaje.SetBool("TocandoSuelo", TocandoSuelo); //vincula el booleano del script y el del animador

        bool TocaObstaculo = Physics2D.OverlapCircle(ComprobarSuelo.position, radio, obstaculo);

       if (Input.GetKeyDown(KeyCode.Space))
       {
        if (TocandoSuelo)
        {
            cuerpo.AddForce(Vector2.up * Fuerza); //empuja con la fuerza establecida el objeto hacia arriba
        }       
       }
       if (TocaObstaculo)
        {
            PantallaGameOver.SetActive(true);
            AnimadorPersonaje.SetTrigger("Perder");
            Time.timeScale = 0f;
        }

        ActualizarPuntaje();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ComprobarSuelo.position, radio);
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void ActualizarPuntaje()
    {
        int PuntosPorSegundo = 10;

        tiempo += Time.deltaTime;
        puntaje = (int)tiempo * PuntosPorSegundo; //int sirve aqui para mantener el puntaje en numeros enteros
        TextoPuntaje.text = string.Format("{0:00000}", puntaje);
        TextoHiscore.text = string.Format("{0:00000}", Hiscore);

        Hiscore = PlayerPrefs.GetInt("Puntaje Guardado", 0);

        if (puntaje > Hiscore)
        {
            Hiscore = puntaje;
            PlayerPrefs.SetInt("Puntaje Guardado", Hiscore);
        }
    }

}
