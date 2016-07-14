using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WFP_CONNECT_DB
{
    public class Customer : IDataErrorInfo
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Doc { get; set; }
        public string Status { get; set; }
        public string FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Domicilio { get; set; }

        bool invalid_email = false;

        #region IDataErrorInfo Members

        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Nombre")
                {
                    //Valido si el campo está vacío
                    if (string.IsNullOrEmpty(Nombre))
                        result = "Por favor ingrese el Nombre";
                    else
                    {
                        Regex regex = new Regex(@"^[a-zA-Z ]*$");
                        if (regex.IsMatch(Nombre) == false)
                        {
                            result = "Por favor ingrese solo letras";
                        }
                    }
                }
                if (columnName == "Apellido")
                {
                    //Valido si el campo está vacío
                    if (string.IsNullOrEmpty(Apellido))
                        result = "Por favor ingrese el Apellido";
                    else
                    {
                        //Valido que solo se ingresen letras
                        Regex regex = new Regex(@"^[a-zA-Z ]*$");
                        if (regex.IsMatch(Apellido) == false)
                        {
                            result = "Por favor ingrese solo letras";
                        }
                    }
                }
                if (columnName == "Doc")
                {
                    //Valido si el campo está vacío
                    if (string.IsNullOrEmpty(Doc))
                    {
                        result = "Por favor ingrese el Documento";
                    }
                    else
                    {
                        //Valido que solo se ingresen números o números delimitados por puntos
                        Regex regex = new Regex(@"^[0-9.]+$");
                        if (regex.IsMatch(Doc) == false)
                        {
                            result = "Campo alfanumérico, por favor utilice delimitador '.' ";
                        }
                    }
                }

                if (columnName == "Email")
                {
                    //Valido si el campo está vacío
                    if (string.IsNullOrEmpty(Email))
                        result = "Por favor ingrese el Email";
                    else
                    {
                        //Valido si el formato de correo es correcto a través de la función IsValidEmail
                        if (IsValidEmail(Email) == false)
                            result = "Por favor ingrese un Email válido";
                    }
                }
                if (columnName == "FechaNacimiento")
                {
                    //Valido si el campo está vacío
                    if (string.IsNullOrEmpty(FechaNacimiento))
                        result = "Por favor ingrese la Fecha de Nacimiento";
                }
                if (columnName == "Domicilio")
                {
                    if (string.IsNullOrEmpty(Domicilio))
                        result = "Por favor ingrese el Domicilio";
                    else
                    { 
                        //Valido si el campo está vacío
                        Regex regex = new Regex(@"^[a-zA-Z][\w ]*$");
                        if (regex.IsMatch(Domicilio) == false)
                        {
                            result = "Ingreso alfanumerico";
                        }
                    }
                }

                return result;
            }
        }

        #endregion

        public bool IsValidEmail(string strIn)
        {
            invalid_email = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid_email)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid_email = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}