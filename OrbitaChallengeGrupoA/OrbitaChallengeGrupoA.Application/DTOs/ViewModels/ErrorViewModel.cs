using System;
using System.Net;

namespace OrbitaChallengeGrupoA.Application.DTOs.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(HttpStatusCode codeStatus, Exception ex)
        {
            CodeStatus = codeStatus;
            Type = ex.GetType().Name;
            Message = ex.Message;              
        }
        
        public HttpStatusCode CodeStatus { get; set; }
        public string Type { get; set; }        
        public string Message { get; set; }                    
    }
}
