using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperDepo_CMM;
using System.Security.Cryptography;

namespace SuperDepo_SL
{
    public class SecurityManager
    {
        #region Singleton UserManager   
   
        private string key;
        
        private SecurityManager()
        {
            key = "a5795af5b04433a434a34fcb78dd89c472ccbcb0";
        }

        static SecurityManager instance = null;

        public static SecurityManager getInstance() 
        {
            if (instance == null)
                instance = new SecurityManager();

            return instance;
        }
        #endregion                        
        
        public string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);
   
            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();
    
            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();
    
            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public string Desencriptar(string textoEncriptado)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =  Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();
    
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public Int32 DigitoHorizontalUsuario(User usr)
        {
            Int32 dh = 0;

            dh = dh + this.converStringToInt32(usr.LastName);
            dh = dh + this.converStringToInt32(usr.Name);
            dh = dh + this.converStringToInt32(usr.UserName);
            dh = dh + this.converStringToInt32(usr.Password);

            return dh;
        }

        public Int32 DigitoHorizontalUProducto(Producto prd)
        {
            Int32 dh = 0;

            dh = dh + this.converStringToInt32(prd.CodigoProducto);
            dh = dh + this.converStringToInt32(prd.Descripcion);
            dh = dh + this.converStringToInt32(prd.Cantidad.ToString());
            dh = dh + this.converStringToInt32(prd.IdTipoProducto.ToString());

            return dh;
        }

        private Int32 converStringToInt32(string Cadena)
        {
            Int32 posIni = 0;
            Int32 dh = 0;

            for (posIni = 0; posIni < Cadena.Length; posIni++)
            {
                String car = Cadena.Substring(posIni, 1);
                dh = dh + Encoding.ASCII.GetBytes(car)[0];
            }

            return dh;
        }
    }
}
