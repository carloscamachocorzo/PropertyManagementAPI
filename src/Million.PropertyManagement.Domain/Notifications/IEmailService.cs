namespace Million.PropertyManagement.Domain.Notifications
{
    /// <summary>
    /// Define el contrato para un servicio de envío de correos electrónicos.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Envía un correo electrónico utilizando los parámetros de configuración SMTP definidos en la aplicación.
        /// </summary>
        Task SendEmailAsync(string to, string subject, string body);
    }
}
