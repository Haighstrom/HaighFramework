using System.Runtime.InteropServices;

namespace HaighFramework.Input;

public class InputManager : IInputManager
{
    private readonly IInputManager _api;
    private bool _disposed;

    public InputManager()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            _api = new Windows.WinAPIInputManager();
        else
            throw new PlatformNotSupportedException();
    }

    public MouseState MouseState => _api.MouseState;

    public KeyboardState KeyboardState => _api.KeyboardState;

    protected virtual void Dispose(bool disposedCorrectly)
    {
        if (!_disposed)
        {
            if (disposedCorrectly)
            {
                _api.Dispose();
            }
            else
                Log.Warning($"Did not dispose {nameof(InputManager)} correctly.");

            _disposed = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposedCorrectly: true);
        GC.SuppressFinalize(this);
    }
}