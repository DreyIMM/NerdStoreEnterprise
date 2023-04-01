﻿using NSE.WebApp.MVC.Extensions;
using System.Net.Http;

namespace NSE.WebApp.MVC.Services
{
    public abstract class Services
    {

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpResquestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }


    }
}
