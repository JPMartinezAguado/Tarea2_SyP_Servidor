using System.Diagnostics.Eventing.Reader;
using System.IO.Pipes;

namespace Tarea2_SyP_Servidor
{
    public partial class Form1 : Form
    {
        //Campos de clase accesibles desde todos los métodos de la misma
        private NamedPipeServerStream servidorPipe;
        private StreamWriter sw;
        private int tiempoEspera = 15;

        public Form1()
        {
            InitializeComponent();
        }

        //Evento de boton que simplemnte llmaa al metodo qeu arranca el servidor y lo pone a la espera
        private async void arrancar_Click(object sender, EventArgs e)
        {
            await arranque();

        }

        /// <summary>
        /// tarea principal de arranque del servidor. en el se inicia el pipe que comunicara con el cliente, se mostraran los textos de instrucciones
        /// del programa y se arranca el StreamWriter que enviara informacion a traves del pipe iniciado
        /// </summary>
        /// <returns>la tarea de inicio y envio de datos por el pipe</returns>
        private async Task arranque()
        {
            servidorPipe = new NamedPipeServerStream("servidor", PipeDirection.Out);

            textBox1.Text = "Buenos dias. Es usted el gran Oraculo que todo lo sabe. En cuanto se conecte un cliente al servicio comenzamos ;)";

            //Se dconfigura el servidor para ponerse a la escucha de forma asincrona para que no bloquee la interfaz mientras espera por respuestas
            await servidorPipe.WaitForConnectionAsync();

            //instrucciones que se iran pintando el los cuadros de texto del servidor, con unos pequeños delays entre cada uno para que la presentacion no sea tan brusca
            textBox1.Text += "Se ha conectado un cliente. Es hora de poner en marcha la máquina de la magia ;). Primero presiona \"Crear prediccion\" y a continuacion copia de una en una" +
               "las instrucciones indicadas abajo en azul, dando un tiempo al receptor para que las vaya cumopliendo.\r\n ";
            textBox2.ForeColor = Color.Blue;
            textBox2.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox2.Text += "1. Bienvenid@, soy el gran Oraculo, voy a demostrarle mis grandes habilidades de predicción " +
             "Piensa en un numero de al menos 6, 7 u 8 cifras. Ponmelo dificil!! :)Presiona \"capturar hora\" para que quede constancia. " +
                "Mas adelante entenderás porqué es importante ;)\r\n";
            textBox2.Text += "\r\n";
            Task.Delay(500).Wait();
            textBox2.Text += "2. Vas a realizar una serie de operaciones con dicho numero.Si quieres usar la calculadora o el notepad del sistema, haz clic " +
                "en los botones correspondientes que tienes a tu disposicion.(Tranquil@, no voy a espiar los procesos :). No tengo tantas habilidades todavia, y no seria divertido)\r\n";
            textBox2.Text += "\r\n";
            Task.Delay(500).Wait();
            textBox2.Text += "3. Ahora suma todos los digitos del numero que has elegido y restale el resultado de esa suma al número.    " +
                "(Por ejemplo, si has elegido 12345678, sumas 1+2+...+8 = x, y restas 12345678 - x)     " +
                "Eso de dará un numero de varias cifras\r\n";
            textBox2.Text += "\r\n";
            Task.Delay(500).Wait();
            textBox2.Text += "5. Ahora solo tienes que ir sumando los digitos de este numero, hasta que tengas un numero de un solo digito\r\n";
            textBox2.Text += "\r\n";
            Task.Delay(500).Wait();
            textBox2.Text += "6. ¿Lo tienes?......Pues ahora haz clic en \"comporbar predicción\", lee lo que pone, y fijate en la fecha de creacion del archivo....\r\n" +
                " Magia???? ;)\r\n";

            //inicio del flujo de datos que se enviara al pipe
            sw = new StreamWriter(servidorPipe)
            {
                AutoFlush = true
            };
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// evento resultante de clickar el boton de enviar del formulario. En el se definen los datos que se cargarán al flujo de datos del pipe, 
        /// y se enviaran por el mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void enviar_Click(object sender, EventArgs e)
        {
            //nos aseguramos que el pipe existe y está debidamente conectado 
            if (servidorPipe.IsConnected && servidorPipe != null)
            { 
                // definimos variable local que recoge el string que contiene el cuadro de texto del formulario destinado al envio de informacion al cliente
                //y comprobamos que no es erroneo ni está vacio
                string mensaje = mensajeEnvio.Text;
                if (!string.IsNullOrEmpty(mensaje))
                {
                    //de forma asincrona, rellenamos el flujo con el string recogido
                    await Task.Run(() => sw.WriteLine(mensaje));
                    
                    //indocamos que el mensaje se envió correctamente e iniciamos un timer para darle tiempoi al cliente de leer y realizar la instruccion
                    textBox1.BackColor = Color.LightGreen;
                    textBox1.Text = "instruccion enviada con exito: \r\n" + mensaje;
                    mensajeEnvio.Clear();
                    configurarTimer();
                    
                }
                else
                {
                    //si el cuadro del formulario esta vacio
                    textBox1.BackColor= Color.LightSalmon;
                    textBox1.Text = "No has enviado ninguna instruccion";
                }
            }
            else
            {
                //si el pipe no esta funcionanod debidamente
                textBox1.BackColor = Color.LightSalmon;
                textBox1.Text = "el lciente no esta conecatado";
            }

        }

        /// <summary>
        /// evento de boton de formulario que genera un archivo de texto, rellenado ocn un texto definido en el metodo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generarArchivo_Click(object sender, EventArgs e)
        {
            //se guarda en una carpeta publica predefinida del sistema Windows, para evitar problemas de acceso por falta de permisos o inexistencia de la misma
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            string filepath = Path.Combine(folderPath, "prediccion.txt");
            string contenido = "El numero que estas pensando, al que has llegado con todas las operaciones hechas es el 9.\r\n" +
                "Y para que veas que no copié ni espié tus notas o calculadora, fijate en la fecha de creación de este archivo:" +
                DateTime.Now.ToString();
            File.WriteAllText(filepath, contenido);
        }

        private void mensajeEnvio_TextChanged(object sender, EventArgs e)
        {

        }

        //metodo para salir del programa, equivalente a la X del sistema, pero que da la sensacion de ser menos brusco
        private void Apagar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //metodo que controla el timer que incorpora el formulario, y que reduce el tiempo desde el valor definido en 
        //la variable de clase tiempoEspera hasta 0, y da un mensaje al terminar, a traves de una label
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(tiempoEspera> 0)
            {
                label1.BackColor = Color.Yellow;
                label1.Text = "Quedan " + tiempoEspera + " segundos para enviar la siguiente instruccion";
                tiempoEspera--;
            }
            else 
            {
                timer1.Stop();
                label1.BackColor = Color.PaleGreen;
                label1.Text = "Ya puedes enviar la siguiente instruccion";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        //metodo que maneja el timer, indicando el intervalo de tiempo del Tick en milisegundos, se casigna el metodo timer1.tick como manejador del evento Tick
        //y se arranca el timer
        private void configurarTimer()
        {
            timer1.Interval = 1000; 
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
    }
}