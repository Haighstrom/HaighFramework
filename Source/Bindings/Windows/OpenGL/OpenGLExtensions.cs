using System.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using HaighFramework.WinAPI;

namespace HaighFramework.OpenGL;

[SuppressUnmanagedCodeSecurity]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "OpenGL functions have dumb naming conventions but I'm keeping these APIs pure.")]
public static partial class OpenGL32
{
    // ***CLEANED UP ABOVE THIS LINE***

    /// <summary>
    /// This needs to be called after an OpenGL4 render context has been created and before any of these functions are called
    /// </summary>
    public static void LoadOpenGL3Extensions()
    {
        GL.GetProcAddress("glActiveTexture", out _glActiveTexture);
        GL.GetProcAddress("glAttachShader", out _glAttachShader);
        GL.GetProcAddress("glBindBuffer", out _glBindBuffer);
        GL.GetProcAddress("glBindFramebuffer", out _glBindFramebuffer);
        GL.GetProcAddress("glBindSampler", out _glBindSampler);
        GL.GetProcAddress("glBlendFuncSeparate", out glBlendFuncSeparate);
        GL.GetProcAddress("glBufferData", out _glBufferData);
        GL.GetProcAddress("glCompileShader", out _glCompileShader);
        GL.GetProcAddress("glCreateProgram", out _glCreateProgram);
        GL.GetProcAddress("glCreateShader", out _glCreateShader);
        GL.GetProcAddress("glDebugMessageCallback", out _glDebugMessageCallback);
        GL.GetProcAddress("glDebugMessageControl", out _glDebugMessageControl);
        GL.GetProcAddress("glDeleteBuffers", out _glDeleteBuffers);
        GL.GetProcAddress("glDeleteFramebuffers", out _glDeleteFramebuffers);
        GL.GetProcAddress("glDeleteProgram", out _glDeleteProgram);
        GL.GetProcAddress("glDeleteShader", out _glDeleteShader);
        GL.GetProcAddress("glDetachShader", out _glDetachShader);
        GL.GetProcAddress("glDisableVertexAttribArray", out _glDisableVertexAttribArray);
        GL.GetProcAddress("glEnableVertexAttribArray", out _glEnableVertexAttribArray);
        GL.GetProcAddress("glFramebufferTexture2D", out _glFramebufferTexture2D);
        GL.GetProcAddress("glGenBuffers", out _glGenBuffers);
        GL.GetProcAddress("glGenFramebuffers", out _glGenFramebuffers);
        GL.GetProcAddress("glGetAttribLocation", out _glGetAttribLocation);
        GL.GetProcAddress("glGetProgramInfoLog", out _glGetProgramInfoLog);
        GL.GetProcAddress("glGetShaderInfoLog", out _glGetShaderInfoLog);
        GL.GetProcAddress("glGetShaderiv", out _glGetShaderiv);
        GL.GetProcAddress("glGetUniformLocation", out _glGetUniformLocation);
        GL.GetProcAddress("glLinkProgram", out _glLinkProgram);
        GL.GetProcAddress("glShaderSource", out _glShaderSource);
        GL.GetProcAddress("glTexImage2DMultisample", out _glTexImage2DMultisample);
        GL.GetProcAddress("glTexStorage2D", out _glTexStorage2D);
        GL.GetProcAddress("glUniform1f", out _glUniform1f);
        GL.GetProcAddress("glUniform1i", out _glUniform1i);
        GL.GetProcAddress("glUniform2f", out glUniform2f);
        GL.GetProcAddress("glUniform3f", out _glUniform3f);
        GL.GetProcAddress("glUniform4f", out _glUniform4f);
        GL.GetProcAddress("glUniformMatrix3fv", out _glUniformMatrix3fv);
        GL.GetProcAddress("glUniformMatrix4fv", out _glUniformMatrix4fv);
        GL.GetProcAddress("glUseProgram", out _glUseProgram);
        GL.GetProcAddress("glValidateProgram", out _glValidateProgram);
        GL.GetProcAddress("glVertexAttribPointer", out _glVertexAttribPointer);
    }

    private delegate void DEL_glActiveTexture(int unit);
    private static DEL_glActiveTexture _glActiveTexture;
    /// <summary>
    /// glActiveTexture
    /// </summary>
    public static void ActiveTexture(TextureUnit unit)
    {
        _glActiveTexture((int)unit);
    }
    

    private delegate void DEL_glAttachShader(uint program, int shader);
    private static DEL_glAttachShader _glAttachShader;
    /// <summary>
    /// glAttachShader
    /// </summary>
    public static void AttachShader(uint program, int shader)
    {
        _glAttachShader(program, shader);
    }
    

    private delegate void DEL_glBindBuffer(int target, uint buffer);
    private static DEL_glBindBuffer _glBindBuffer;
    /// <summary>
    /// glBindBuffer
    /// </summary>
    public static void BindBuffer(BufferTarget target, uint buffer)
    {
        _glBindBuffer((int)target, buffer);
    }
    

    private delegate void DEL_glBindFramebuffer(int target, uint frameBuffer);
    private static DEL_glBindFramebuffer _glBindFramebuffer;
    /// <summary>
    /// glBindFramebuffer
    /// </summary>
    public static void BindFramebuffer(FramebufferTarget target, uint frameBuffer)
    {
        _glBindFramebuffer((int)target, frameBuffer);
    }
    

    private delegate void DEL_glBindSampler(int unit, int sampler);
    private static DEL_glBindSampler _glBindSampler;
    /// <summary>
    /// glBindSampler
    /// </summary>
    public static void BindSampler(TextureUnit unit, int sampler)
    {
        _glBindSampler((int)unit, sampler);
    }
    

    private delegate void DEL_glBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);
    private static DEL_glBlendFuncSeparate glBlendFuncSeparate;

    public static void BlendFuncSeperate(BLEND_SCALE_FACTOR srcRGB, BLEND_SCALE_FACTOR dstRGB, BLEND_SCALE_FACTOR srcAlpha, BLEND_SCALE_FACTOR dstAlpha)
    {
        glBlendFuncSeparate((int)srcRGB, (int)dstRGB, (int)srcAlpha, (int)dstAlpha);
    }
    

    private delegate void DEL_glBufferData(int target, IntPtr size, IntPtr data, int usage);
    private static DEL_glBufferData _glBufferData;
    /// <summary>
    /// glBufferData
    /// </summary>
    public static void BufferData<T>(BufferTarget target, int size, T[] data, BufferUsageHint usage) where T : struct
    {
        GCHandle pinnedArray = GCHandle.Alloc(data, GCHandleType.Pinned);

        IntPtr pointer = pinnedArray.AddrOfPinnedObject();

        _glBufferData((int)target, (IntPtr)size, pointer, (int)usage);

        pinnedArray.Free();
    }
    

    private delegate void DEL_glCompileShader(int program);
    private static DEL_glCompileShader _glCompileShader;
    /// <summary>
    /// glCompileShader
    /// </summary>
    public static void CompileShader(int program)
    {
        _glCompileShader(program);
    }
    

    private delegate uint DEL_glCreateProgram();
    private static DEL_glCreateProgram _glCreateProgram;
    /// <summary>
    /// glCreateProgram
    /// </summary>
    public static uint CreateProgram()
    {
        return _glCreateProgram();
    }
    

    private delegate int DEL_glCreateShader(int shaderType);
    private static DEL_glCreateShader _glCreateShader;
    /// <summary>
    /// glCreateShader
    /// </summary>
    public static int CreateShader(ShaderType shaderType)
    {
        return _glCreateShader((int)shaderType);
    }
    

    private delegate void DEL_glDebugMessageCallback(IntPtr callback, IntPtr userParam);
    private static DEL_glDebugMessageCallback _glDebugMessageCallback;
    public static void DebugMessageCallback(DebugMessageDelegate callbackFunction)
    {
        _glDebugMessageCallback(Marshal.GetFunctionPointerForDelegate(callbackFunction), IntPtr.Zero);
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DebugMessageDelegate(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam);
    

    private delegate void DEL_glDebugMessageControl(int source, int type, int severity, int count, uint[] ids, bool enabled);
    private static DEL_glDebugMessageControl _glDebugMessageControl;

    public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled)
    {
        _glDebugMessageControl((int)source, (int)type, (int)severity, count, ids, enabled);
    }

    public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, bool enabled)
    {
        DebugMessageControl(source, type, severity, 0, null, enabled);
    }
    

    private delegate void DEL_glDeleteBuffers(int n, uint[] buffers);
    private static DEL_glDeleteBuffers _glDeleteBuffers;
    /// <summary>
    /// glDeleteBuffers
    /// </summary>
    public static void DeleteBuffers(uint[] buffers)
    {
        int n = buffers.Length;

        _glDeleteBuffers(n, buffers);
    }
    /// <summary>
    /// glDeleteBuffers
    /// </summary>
    public static void DeleteBuffer(uint buffer)
    {
        uint[] buffers = { buffer };

        _glDeleteBuffers(1, buffers);
    }
    

    private delegate void DEL_glDeleteFramebuffers(int n, uint[] framebuffers);
    private static DEL_glDeleteFramebuffers _glDeleteFramebuffers;
    /// <summary>
    /// glDeleteFramebuffers
    /// </summary>
    public static void DeleteFramebuffers(uint[] framebuffers)
    {
        int n = framebuffers.Length;

        _glDeleteFramebuffers(n, framebuffers);
    }
    /// <summary>
    /// glDeleteFramebuffers
    /// </summary>
    public static void DeleteFramebuffer(uint framebuffer)
    {
        uint[] framebuffers = { framebuffer };

        _glDeleteFramebuffers(1, framebuffers);
    }
    

    private delegate void DEL_glDeleteShader(int shader);
    private static DEL_glDeleteShader _glDeleteShader;
    /// <summary>
    /// glDeleteShader
    /// </summary>
    public static void DeleteShader(int shader)
    {
        _glDeleteShader(shader);
    }
    

    private delegate void DEL_glDeleteProgram(uint program);
    private static DEL_glDeleteProgram _glDeleteProgram;
    /// <summary>
    /// glDeleteProgram
    /// </summary>
    public static void DeleteProgram(uint program)
    {
        _glDeleteProgram(program);
    }
    

    private delegate void DEL_glDetachShader(uint program, int shader);
    private static DEL_glDetachShader _glDetachShader;
    /// <summary>
    /// glDetachShader
    /// </summary>
    public static void DetachShader(uint program, int shader)
    {
        _glDetachShader(program, shader);
    }
    

    private delegate void DEL_glDisableVertexAttribArray(uint index);
    private static DEL_glDisableVertexAttribArray _glDisableVertexAttribArray;
    /// <summary>
    /// glDisableVertexAttribArray
    /// </summary>
    public static void DisableVertexAttribArray(int index)
    {
        _glDisableVertexAttribArray((uint)index);
    }
    

    private delegate void DEL_glEnableVertexAttribArray(uint index);
    private static DEL_glEnableVertexAttribArray _glEnableVertexAttribArray;
    /// <summary>
    /// glEnableVertexAttribArray
    /// </summary>
    public static void EnableVertexAttribArray(int index)
    {
        _glEnableVertexAttribArray((uint)index);
    }
    

    private delegate void DEL_glFramebufferTexture2D(int target, int attachment, int texTarget, uint texture, int level);
    private static DEL_glFramebufferTexture2D _glFramebufferTexture2D;
    /// <summary>
    /// glFramebufferTexture2D
    /// </summary>
    public static void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TEXTURE_TARGET texTarget, uint texture, int level)
    {
        _glFramebufferTexture2D((int)target, (int)attachment, (int)texTarget, texture, level);
    }
    

    private delegate void DEL_glGenBuffers(int n, uint[] buffers);
    private static DEL_glGenBuffers _glGenBuffers;
    /// <summary>
    /// glGenBuffers
    /// </summary>
    public static uint[] GenBuffers(int n)
    {
        uint[] buffers = new uint[n];

        _glGenBuffers(n, buffers);

        return buffers;
    }
    /// <summary>
    /// glGenBuffers
    /// </summary>
    public static uint GenBuffer()
    {
        uint[] buffers = new uint[1];

        _glGenBuffers(1, buffers);

        return buffers[0];
    }
    

    private delegate void DEL_glGenFrameBuffers(int n, uint[] buffers);
    private static DEL_glGenFrameBuffers _glGenFramebuffers;

    public static uint[] GenFramebuffers(int n)
    {
        uint[] buffers = new uint[n];

        _glGenFramebuffers(1, buffers);

        return buffers;
    }
    public static uint GenFramebuffer()
    {
        uint[] buffers = new uint[1];

        _glGenFramebuffers(1, buffers);

        return buffers[0];
    }
    

    private delegate int DEL_glGetAttribLocation(uint programObj, string name);
    private static DEL_glGetAttribLocation _glGetAttribLocation;
    /// <summary>
    /// glGetAttribLocation
    /// </summary>
    public static int GetAttribLocation(uint program, string name)
    {
        return _glGetAttribLocation(program, name);
    }
    

    private unsafe delegate void DEL_glGetProgramInfoLog(uint program, int bufSize, out int length, StringBuilder infoLog);
    private static DEL_glGetProgramInfoLog _glGetProgramInfoLog;
    /// <summary>
    /// glGetProgramInfoLog
    /// </summary>
    public static string GetProgramInfoLog(uint program)
    {
        StringBuilder stringPtr = new(255);
        int count;
        _glGetProgramInfoLog(program, 255, out count, stringPtr);

        return stringPtr.ToString();
    }
    

    private unsafe delegate void DEL_glGetShaderiv(uint shader, int pname, int* @params);
    private static DEL_glGetShaderiv _glGetShaderiv;
    /// <summary>
    /// glGetShaderiv
    /// </summary>
    public static int GetShader(uint shader, ShaderParameter pname)
    {
        unsafe
        {
            int i;
            _glGetShaderiv(shader, (int)pname, &i);
            return i;
        }
    }
    

    private unsafe delegate void DEL_glGetShaderInfoLog(uint shader, int bufSize, out int length, StringBuilder infoLog);
    private static DEL_glGetShaderInfoLog _glGetShaderInfoLog;
    /// <summary>
    /// glGetShaderInfoLog
    /// </summary>
    public static string GetShaderInfoLog(int shader)
    {
        StringBuilder stringPtr = new(255);
        int count;
        _glGetShaderInfoLog((uint)shader, 255, out count, stringPtr);

        return stringPtr.ToString();
    }
    

    private delegate int DEL_glGetUniformLocation(uint program, string name);
    private static DEL_glGetUniformLocation _glGetUniformLocation;
    /// <summary>
    /// glGetUniformLocation
    /// </summary>
    public static int GetUniformLocation(uint program, string name)
    {
        return _glGetUniformLocation(program, name);
    }
    

    private delegate void DEL_glLinkProgram(uint program);
    private static DEL_glLinkProgram _glLinkProgram;
    /// <summary>
    /// glLinkProgram
    /// </summary>
    public static void LinkProgram(uint program)
    {
        _glLinkProgram(program);
    }
    

    private delegate int DEL_glShaderSource(int shader, int count, string[] strings, int[] lengths);
    private static DEL_glShaderSource _glShaderSource;
    /// <summary>
    /// glShaderSource
    /// </summary>
    public static int ShaderSource(int shader, string source)
    {
        string[] strings = new string[1] { source };

        return _glShaderSource(shader, 1, strings, null);
    }
    

    private delegate int DEL_glTexImage2DMultisample(int target, int samples, int internalformat, int width, int height, bool fixedsamplelocations);
    private static DEL_glTexImage2DMultisample _glTexImage2DMultisample;
    /// <summary>
    /// glTexImage2DMultisample
    /// </summary>
    public static void TexImage2DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalFormat, int width, int height, bool fixedSampleLocations)
    {
        _glTexImage2DMultisample((int)target, samples, (int)internalFormat, width, height, fixedSampleLocations);
    }
    /// <summary>
    /// glTexImage2DMultisample
    /// </summary>
    public static void TexImage2DMultisample(TextureTargetMultisample target, MSAA_Samples samples, PixelInternalFormat internalFormat, int width, int height, bool fixedSampleLocations) => TexImage2DMultisample(target, (int)samples, internalFormat, width, height, fixedSampleLocations);
    

    private delegate void DEL_glTexStorage2D(uint target, int levels, int internalFormat, int width, int height);
    private static DEL_glTexStorage2D _glTexStorage2D;

    public static void TexStorage2D(TEXTURE_TARGET target, int levels, TexInternalFormat internalFormat, int width, int height)
    {
        _glTexStorage2D((uint)target, levels, (int)internalFormat, width, height);
    }
    

    private delegate void DEL_glUniform1f(int location, float v0);
    private static DEL_glUniform1f _glUniform1f;

    private delegate void DEL_glUniform1i(int location, int v0);
    private static DEL_glUniform1i _glUniform1i;

    /// <summary>
    /// glUniform1f
    /// </summary>
    public static void Uniform(int location, float value)
    {
        _glUniform1f(location, value);
    }
    /// <summary>
    /// glUniform1i
    /// </summary>
    public static void Uniform(int location, int value)
    {
        _glUniform1i(location, value);
    }
    

    public delegate void DEL_glUniform2f(int location, float v0, float v1);
    public static DEL_glUniform2f? glUniform2f;

    private delegate void DEL_glUniform2i(int location, int v0, int v1);
    private static DEL_glUniform2i _glUniform2i;
    

    private delegate void DEL_glUniform3f(int location, float v0, float v1, float v2);
    private static DEL_glUniform3f _glUniform3f;

    private delegate void DEL_glUniform3i(int location, int v0, int v1, int v2);
    private static DEL_glUniform3i _glUniform3i;
    

    private delegate void DEL_glUniform4f(int location, float v0, float v1, float v2, float v3);
    private static DEL_glUniform4f _glUniform4f;

    private delegate void DEL_glUniform4i(int location, int v0, int v1, int v2, int v3);
    private static DEL_glUniform4i _glUniform4i;

    /// <summary>
    /// glUniform4f
    /// </summary>
    public static void glUniform4f(int location, float v0, float v1, float v2, float v3)
    {
        _glUniform4f(location, v0, v1, v2, v3);
    }
    

    private unsafe delegate void DEL_glUniformMatrix3fv(int location, int count, bool transpose, float* value);
    private static DEL_glUniformMatrix3fv _glUniformMatrix3fv;
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix3(int location, int count, bool transpose, float[] values)
    {
        unsafe
        {
            fixed (float* valuePointer = values)
            {
                _glUniformMatrix3fv(location, count, transpose, valuePointer);
            }
        }
    }
    /// <summary>
    /// glUniformMatrix3fv
    /// </summary>
    public static void UniformMatrix3(int location, float[] values) => UniformMatrix3(location, 1, false, values);
    

    private unsafe delegate void DEL_glUniformMatrix4fv(int location, int count, bool transpose, float* value);
    private static DEL_glUniformMatrix4fv _glUniformMatrix4fv;
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix4(int location, int count, bool transpose, float[] values)
    {
        unsafe
        {
            fixed (float* valuePointer = values)
            {
                _glUniformMatrix4fv(location, count, transpose, valuePointer);
            }
        }
    }
    /// <summary>
    /// glUniformMatrix4fv
    /// </summary>
    public static void UniformMatrix4(int location, float[] values) => UniformMatrix4(location, 1, false, values);
    

    private delegate void DEL_glUseProgram(uint program);
    private static DEL_glUseProgram _glUseProgram;
    /// <summary>
    /// glUseProgram
    /// </summary>
    public static void UseProgram(uint program)
    {
        _glUseProgram(program);
    }
    

    private delegate void DEL_glValidateProgram(uint program);
    private static DEL_glValidateProgram _glValidateProgram;
    /// <summary>
    /// glValidateProgram
    /// </summary>
    public static void ValidateProgram(uint program)
    {
        _glValidateProgram(program);
    }
    

    private delegate void DEL_glVertexAttribPointer(uint index, int size, int type, bool normalized, int stride, IntPtr pointer);
    private static DEL_glVertexAttribPointer _glVertexAttribPointer;
    /// <summary>
    /// glVertexAttribPointer
    /// </summary>
    public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalised, int stride, int offset)
    {
        _glVertexAttribPointer((uint)index, size, (int)type, normalised, stride, new IntPtr(offset));
    }
    
    
}