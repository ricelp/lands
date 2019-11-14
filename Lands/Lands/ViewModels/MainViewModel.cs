
namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Models;

    public  class MainViewModel
    {
        #region Properties
        public List<Land> LandsList
        {
            get;
            set;
        }

        //public TokenResponse Token
        //{
        //    get;
        //    set;
        //}
        #endregion
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;
        }

        public LandViewModel Land
        {
            get;
            set;
        }

        //public EmpleadosViewModel Empleados
        //{
        //    get;
        //    set;
        //}

        //public EmpleadoViewModel Empleado
        //{
        //    get;
        //    set;
        //}

        //public EmpleadoViewModel Borders
        //{
        //    get;
        //    set;
        //}

        //public EmpleadoViewModel Currencies
        //{
        //    get;
        //    set;
        //}

        //public EmpleadoViewModel Languages
        //{
        //    get;
        //    set;
        //}

        //public EmpleadoViewModel Translations
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
