namespace perceptronXor
{
    class PerceptronXOR
    {
        static void Main(string[] args)
        {
            // Definir las entradas y las salidas esperadas
            double[,] entradas = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            int[] salidasEsperadas = { 0, 1, 1, 0 };

            // Inicializar los pesos aleatoriamente
            double[] pesos = { 0.2, 0.3, -0.1 };

            // Definir la tasa de aprendizaje y el número máximo de iteraciones
            double tasaAprendizaje = 0.1;
            int maxIteraciones = 1000;

            // Entrenamiento del perceptrón
            for (int i = 0; i < maxIteraciones; i++)
            {
                for (int j = 0; j < entradas.GetLength(0); j++)
                {
                    // Propagación hacia adelante
                    double entradaExtendida = pesos[0] + pesos[1] * entradas[j, 0] + pesos[2] * entradas[j, 1];
                    int salida = entradaExtendida > 0 ? 1 : 0;
                    int error = salidasEsperadas[j] - salida;

                    // Actualizar los pesos
                    pesos[0] += tasaAprendizaje * error;
                    pesos[1] += tasaAprendizaje * error * entradas[j, 0];
                    pesos[2] += tasaAprendizaje * error * entradas[j, 1];
                }
            }

            // Probar el perceptrón
            Console.WriteLine("Entradas  Salidas Esperadas  Salidas Obtenidas");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < entradas.GetLength(0); i++)
            {
                double entradaExtendida = pesos[0] + pesos[1] * entradas[i, 0] + pesos[2] * entradas[i, 1];
                int salida = entradaExtendida > 0 ? 1 : 0;

                Console.WriteLine($"{entradas[i, 0]} {entradas[i, 1],4}           {salidasEsperadas[i],11}         {salida,11}");
            }
        }
    }

}
