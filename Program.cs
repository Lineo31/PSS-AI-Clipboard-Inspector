using System;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        IDataObject data = Clipboard.GetDataObject();

        if (data == null)
        {
            Console.WriteLine("Clipboard vide ou inaccessible.");
            return;
        }

        Console.WriteLine("Formats détectés :");
        Console.WriteLine("------------------");

        foreach (string format in data.GetFormats())
        {
            Console.WriteLine(format);

            try
            {
                object value = data.GetData(format);

                if (value == null)
                {
                    Console.WriteLine("  -> null");
                }
                else
                {
                    Console.WriteLine("  -> Type : " + value.GetType().FullName);
                    Console.WriteLine("  -> Valeur : " + value.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("  -> Erreur lecture : " + ex.Message);
            }

            Console.WriteLine();
        }

        Console.WriteLine("Appuie sur Entrée pour quitter.");
        Console.ReadLine();
    }
}
