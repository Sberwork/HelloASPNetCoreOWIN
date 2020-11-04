using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HelloASPNetCoreOWIN
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(pipeline =>
            {
                pipeline(next => SendResponseAsync);
            });
        }
        public Task SendResponseAsync(IDictionary<string, object> environment)
        {
            // ���������� �����
            string responseText = "Hello Sber's SENAT Team";
            // �������� ��� � ������ ������
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

            // �������� ����� ������
            var responseStream = (Stream)environment["owin.ResponseBody"];
            // �������� ������
            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}