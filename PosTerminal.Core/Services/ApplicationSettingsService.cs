using System;
using System.IO;
using Newtonsoft.Json;
using PosTerminal.Core.Converters;
using PosTerminal.Core.Models;

namespace PosTerminal.Core.Services
{
    public interface IApplicationSettingsService
    {
        public ApplicationSettings Get();
    }
    
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        private readonly IConverter _converter;
        
        private readonly string _path;
        private readonly object _locker = new object();
        private ApplicationSettings? _settings;
        
        public ApplicationSettingsService(IConverter converter)
        {
            _converter = converter;
            _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData", "ApplicationSettings.json");
        }

        public ApplicationSettings Get()
        {
            lock (_locker)
            {
                if (_settings != null)
                {
                    return _settings;
                }
                
                var json = File.ReadAllText(_path);

                var settings = _converter.Deserialize<ApplicationSettings>(json);

                _settings = settings ?? throw new Exception("");
                
                return settings;
            }
        }
    }
}