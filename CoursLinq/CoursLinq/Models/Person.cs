using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursLinq.Models
{
    /// <summary>
    ///     Représente une personne.
    /// </summary>
    public class Person
    {
        #region Properties

        /// <summary>
        ///     Obtient ou définit le prénom de la personne.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Obtient ou définit le nom de famille de la personne.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Obtient ou définit la date de naissance de la personne.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        ///     Obtient le nom complet de la personne.
        /// </summary>
        public string FullName => this.FirstName + " " + this.LastName;

        /// <summary>
        ///     Obtient ou définit l'adresse email de la personne.
        /// </summary>
        public string EMailAddress { get; set; }

        #endregion
    }
}
