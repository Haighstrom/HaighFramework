using System.Security;
using System.Runtime.InteropServices;
using static System.Formats.Asn1.AsnWriter;
using System;

namespace HaighFramework.OpenGL;

#region Enums

/// <summary>
/// The alpha comparison function used in <see cref="OpenGL32.glAlphaFunc"/>
/// </summary>
public enum ALPHA_COMPARISON_FUNCTION : int
{
    /// <summary>
    /// Never passes.
    /// </summary>
    GL_NEVER = 0x0200,

    /// <summary>
    /// Passes if the incoming alpha value is less than the reference value.
    /// </summary>
    GL_LESS = 0x0201,

    /// <summary>
    /// Passes if the incoming alpha value is equal to the reference value.
    /// </summary>
    GL_EQUAL = 0x0202,

    /// <summary>
    /// Passes if the incoming alpha value is less than or equal to the reference value.
    /// </summary>
    GL_LEQUAL = 0x0203,

    /// <summary>
    /// Passes if the incoming alpha value is greater than the reference value.
    /// </summary>
    GL_GREATER = 0x0204,

    /// <summary>
    /// Passes if the incoming alpha value is not equal to the reference value.
    /// </summary>
    GL_NOTEQUAL = 0x0205,

    /// <summary>
    /// Passes if the incoming alpha value is greater than or equal to the reference value.
    /// </summary>
    GL_GEQUAL = 0x0206,

    /// <summary>
    /// Always passes (initial value).
    /// </summary>
    GL_ALWAYS = 0x0207,
}

/// <summary>
/// Specifies how colour blending calculations are performed. The color specified by glBlendColor is referred to as (Rc,Gc,Bc,Ac). They are understood to have integer values between 0 and (kR,kG,kB,kA), where kc=2mc−1 and(mR, mG, mB, mA) is the number of red, green, blue, and alpha bitplanes. Source and destination scale factors are referred to as (sR, sG, sB, sA) and (dR, dG, dB, dA). The scale factors described in the table, denoted (fR, fG, fB, fA), represent either source or destination factors. All scale factors have range[0, 1].
/// </summary>
public enum BLEND_SCALE_FACTOR : int
{
    /// <summary>
    /// Maps (0,0,0,0)
    /// </summary>
    GL_ZERO = 0,

    /// <summary>
    /// (1,1,1,1)
    /// </summary>
    GL_ONE = 1,

    /// <summary>
    /// (R? / kR , G? / kG , B? / kB , A? / kA )
    /// </summary>
    GL_SRC_COLOR = 0x0300,

    /// <summary>
    /// (1,1,1,1) - (R? / kR , G? / kG , B? / kB , A? / kA )
    /// </summary>
    GL_ONE_MINUS_SRC_COLOR = 0x0301,

    /// <summary>
    /// (Rd / kR , Gd / kG , Bd / kB , Ad / kA )
    /// </summary>
    GL_DST_COLOR = 0x0306,

    /// <summary>
    /// (1,1,1,1) - (Rd / kR , Gd / kG , Bd / kB , Ad / kA )
    /// </summary>
    GL_ONE_MINUS_DST_COLOR = 0x0307,

    /// <summary>
    /// (A? / kA , A? / kA , A? / kA , A? / kA )
    /// </summary>
    GL_SRC_ALPHA = 0x0302,

    /// <summary>
    /// (1,1,1,1) - (A? / kA , A? / kA , A? / kA , A? / kA )
    /// </summary>
    GL_ONE_MINUS_SRC_ALPHA = 0x0303,

    /// <summary>
    /// (Ad / kA , Ad / kA , Ad / kA , Ad / kA )
    /// </summary>
    GL_DST_ALPHA = 0x0304,

    /// <summary>
    /// (1,1,1,1) - (Ad / kA , Ad / kA , Ad / kA , Ad / kA )
    /// </summary>
    GL_ONE_MINUS_DST_ALPHA = 0x0305,

    /// <summary>
    /// (Rc,Gc,Bc,Ac)
    /// </summary>
    GL_CONSTANT_COLOR = 0x8001,

    /// <summary>
    /// (1,1,1,1)−(Rc,Gc,Bc,Ac)
    /// </summary>
    GL_ONE_MINUS_CONSTANT_COLOR = 0x8002,

    /// <summary>
    /// (Ac,Ac,Ac,Ac)
    /// </summary>
    GL_CONSTANT_ALPHA = 0x8003,

    /// <summary>
    /// (1,1,1,1)−(Ac,Ac,Ac,Ac)
    /// </summary>
    GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004,

    /// <summary>
    /// (i, i, i, 1), i = min (A? , kA - Ad ) / kA
    /// </summary>
    GL_SRC_ALPHA_SATURATE = 0x0308,

    /// <summary>
    /// (Rs1 / kR, Gs1 / kG, Bs1 / kB, As1 / kA)
    /// </summary>
    GL_SRC1_COLOR = 0x88F9,

    /// <summary>
    /// (1,1,1,1) − (Rs1 / kR, Gs1 / kG, Bs1 / kB, As1 / kA)
    /// </summary>
    GL_ONE_MINUS_SRC1_COLOR = 0x88FA,

    /// <summary>
    /// (As1 / kA, As1 / kA,As1 / kA, As1 / kA)
    /// </summary>
    GL_SRC1_ALPHA = 0x8589,

    /// <summary>
    /// (1,1,1,1) − (As1 / kA, As1 / kA, As1 / kA, As1 / kA)
    /// </summary>
    GL_ONE_MINUS_SRC1_ALPHA = 0x88FB,
}

/// <summary>
/// The buffer mask to clear in <see cref="OpenGL32.glClear"/>
/// </summary>
[Flags]
public enum BUFFER_MASK : uint
{
    /// <summary>
    /// Indicates the buffers currently enabled for color writing.
    /// </summary>
    GL_COLOR_BUFFER_BIT = 0x00004000,

    /// <summary>
    /// Indicates the depth buffer.
    /// </summary>
    GL_DEPTH_BUFFER_BIT = 0x00000100,

    /// <summary>
    /// Indicates the accumulation buffer.
    /// </summary>
    GL_ACCUM_BUFFER_BIT = 0x00000200,

    /// <summary>
    /// Indicates the stencil buffer.
    /// </summary>
    GL_STENCIL_BUFFER_BIT = 0x00000400,
}

/// <summary>
/// Specifies the string to retrieve in <see cref="OpenGL32.glGetString"/>
/// </summary>
public enum GETSTRING_NAME : uint
{
    /// <summary>
    /// Returns the company responsible for this GL implementation. This name does not change from release to release.
    /// </summary>
    GL_VENDOR = 0x1F00,

    /// <summary>
    /// Returns the name of the renderer. This name is typically specific to a particular configuration of a hardware platform. It does not change from release to release.
    /// </summary>
    GL_RENDERER = 0x1F01,

    /// <summary>
    /// Returns a version or release number.
    /// </summary>
    GL_VERSION = 0x1F02,

    /// <summary>
    /// Returns a version or release number for the shading language.
    /// </summary>
    GL_SHADING_LANGUAGE_VERSION = 0x8B8C,

    /// <summary>
    /// For glGetStringi only, returns the extension string supported by the implementation at index.
    /// </summary>
    GL_EXTENSIONS = 0x1F03,
}

/// <summary>
/// The face of polygons to apply certain functions to
/// </summary>
public enum POLYGON_FACE : int
{
    /// <summary>
    /// front-facing polygons
    /// </summary>
    GL_FRONT = 0x0404,

    /// <summary>
    /// back-facing polygons
    /// </summary>
    GL_BACK = 0x0405,

    /// <summary>
    /// front- and back-facing polygons
    /// </summary>
    GL_FRONT_AND_BACK = 0x0408,
}

/// <summary>
/// The mode for use with <see cref="OpenGL32.glPolygonMode"/>
/// </summary>
public enum POLYGON_MODE : int
{
    /// <summary>
    /// Polygon vertices that are marked as the start of a boundary edge are drawn as points. Point attributes such as GL_POINT_SIZE and GL_POINT_SMOOTH control the rasterization of the points. Polygon rasterization attributes other than GL_POLYGON_MODE have no effect.
    /// </summary>
    GL_POINT = 0x1B00,
    /// <summary>
    /// Boundary edges of the polygon are drawn as line segments. They are treated as connected line segments for line stippling; the line stipple counter and pattern are not reset between segments (see glLineStipple). Line attributes such as GL_LINE_WIDTH and GL_LINE_SMOOTH control the rasterization of the lines. Polygon rasterization attributes other than GL_POLYGON_MODE have no effect.
    /// </summary>
    GL_LINE = 0x1B01,
    /// <summary>
    /// The interior of the polygon is filled. Polygon attributes such as GL_POLYGON_STIPPLE and GL_POLYGON_SMOOTH control the rasterization of the polygon.
    /// </summary>
    GL_FILL = 0x1B02,
}

/// <summary>
/// Flat and smooth shading are specified by <see cref="OpenGL32.glShadeModel"/> with mode set to GL_FLAT and GL_SMOOTH, respectively.
/// </summary>
public enum SHADE_TECHNIQUE : int
{
    /// <summary>
    /// Flat shading selects the computed color of just one vertex and assigns it to all the pixel fragments generated by rasterizing a single primitive.
    /// </summary>
    GL_FLAT = 0x1D00,

    /// <summary>
    /// Smooth shading, the default, causes the computed colors of vertices to be interpolated as the primitive is rasterized, typically assigning different colors to each resulting pixel fragment. 
    /// </summary>
    GL_SMOOTH = 0x1D01,
}

//----Enums Name and Values Updated, and Fully Commented Above This Line ----

public enum DEBUG_SEVERITY : int
{
    GL_DEBUG_SEVERITY_LOW = 0x9148,

    GL_DEBUG_SEVERITY_MEDIUM = 0x9147,

    GL_DEBUG_SEVERITY_HIGH = 0x9146,

    GL_DEBUG_SEVERITY_NOTIFICATION = 0x826B,

    GL_DONT_CARE = 0x1100,
}

public enum DEBUG_SOURCE : int
{
    GL_DEBUG_SOURCE_API = 0x8246,

    GL_DEBUG_SOURCE_WINDOW_SYSTEM = 0x8247,

    GL_DEBUG_SOURCE_SHADER_COMPILER = 8248,

    GL_DEBUG_SOURCE_THIRD_PARTY = 0x8249,

    GL_DEBUG_SOURCE_APPLICATION = 0x824A,

    GL_DEBUG_SOURCE_OTHER = 0x824B,

    GL_DONT_CARE = 0x1100,
}

public enum DEBUG_TYPE : int
{
    GL_DEBUG_TYPE_ERROR = 0x824C,

    GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR = 0x824D,

    GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR = 0x824E,

    GL_DEBUG_TYPE_PORTABILITY = 0x824F,

    GL_DEBUG_TYPE_PEFORMANCE = 0x8250,

    GL_DEBUG_TYPE_MARKER = 0x824B,

    GL_DEBUG_TYPE_PUSH_GROUP = 0x8269,

    GL_DEBUG_TYPE_POP_GROUP = 0x826A,

    GL_DEBUG_TYPE_OTHER = 0x8251,

    GL_DONT_CARE = 0x1100,
}

public enum PIXEL_STORE_MODE : int
{
    GL_UNPACK_SWAP_BYTES = 0x0CF0,
    GL_UNPACK_LSB_FIRST = 0x0CF1,
    GL_UNPACK_ROW_LENGTH = 0x0CF2,
    GL_UNPACK_ROW_LENGTH_EXT = 0x0CF2,
    GL_UNPACK_SKIP_ROWS = 0x0CF3,
    GL_UNPACK_SKIP_ROWS_EXT = 0x0CF3,
    GL_UNPACK_SKIP_PIXELS = 0x0CF4,
    GL_UNPACK_SKIP_PIXELS_EXT = 0x0CF4,
    GL_UNPACK_ALIGNMENT = 0x0CF5,
    GL_PACK_SWAP_BYTES = 0x0D00,
    GL_PACK_LSB_FIRST = 0x0D01,
    GL_PACK_ROW_LENGTH = 0x0D02,
    GL_PACK_SKIP_ROWS = 0x0D03,
    GL_PACK_SKIP_PIXELS = 0x0D04,
    GL_PACK_ALIGNMENT = 0x0D05,
    GL_PACK_SKIP_IMAGES = 0x806B,
    GL_PACK_SKIP_IMAGES_EXT = 0x806B,
    GL_PACK_IMAGE_HEIGHT = 0x806C,
    GL_PACK_IMAGE_HEIGHT_EXT = 0x806C,
    GL_UNPACK_SKIP_IMAGES = 0x806D,
    GL_UNPACK_SKIP_IMAGES_EXT = 0x806D,
    GL_UNPACK_IMAGE_HEIGHT = 0x806E,
    GL_UNPACK_IMAGE_HEIGHT_EXT = 0x806E,
    GL_PACK_SKIP_VOLUMES_SGIS = 0x8130,
    GL_PACK_IMAGE_DEPTH_SGIS = 0x8131,
    GL_UNPACK_SKIP_VOLUMES_SGIS = 0x8132,
    GL_UNPACK_IMAGE_DEPTH_SGIS = 0x8133,
    GL_PIXEL_TILE_WIDTH_SGIX = 0x8140,
    GL_PIXEL_TILE_HEIGHT_SGIX = 0x8141,
    GL_PIXEL_TILE_GRID_WIDTH_SGIX = 0x8142,
    GL_PIXEL_TILE_GRID_HEIGHT_SGIX = 0x8143,
    GL_PIXEL_TILE_GRID_DEPTH_SGIX = 0x8144,
    GL_PIXEL_TILE_CACHE_SIZE_SGIX = 0x8145,
    GL_PACK_RESAMPLE_SGIX = 0x842C,
    GL_UNPACK_RESAMPLE_SGIX = 0x842D,
    GL_PACK_SUBSAMPLE_RATE_SGIX = 0x85A0,
    GL_UNPACK_SUBSAMPLE_RATE_SGIX = 0x85A1,
    GL_PACK_RESAMPLE_OML = 0x8984,
    GL_UNPACK_RESAMPLE_OML = 0x8985,
    GL_UNPACK_COMPRESSED_BLOCK_WIDTH = 0x9127,
    GL_UNPACK_COMPRESSED_BLOCK_HEIGHT = 0x9128,
    GL_UNPACK_COMPRESSED_BLOCK_DEPTH = 0x9129,
    GL_UNPACK_COMPRESSED_BLOCK_SIZE = 0x912A,
    GL_PACK_COMPRESSED_BLOCK_WIDTH = 0x912B,
    GL_PACK_COMPRESSED_BLOCK_HEIGHT = 0x912C,
    GL_PACK_COMPRESSED_BLOCK_DEPTH = 0x912D,
    GL_PACK_COMPRESSED_BLOCK_SIZE = 0x912E
}

public enum PRIMITIVE_TYPE : int
{
    //todo: complete this. Look at other functions for docs? 
    //https://registry.khronos.org/OpenGL-Refpages/gl2.1/xhtml/glBegin.xml
    //https://registry.khronos.org/OpenGL-Refpages/gl4/html/glDrawArrays.xhtml

    /// <summary>
    /// Treats each vertex as a single point. Vertex n defines point n. N points are drawn.
    /// </summary>
    GL_POINTS = 0,

    /// <summary>
    /// Treats each pair of vertices as an independent line segment. Vertices 2 ⁢ n - 1 and 2 ⁢ n define line n. N 2 lines are drawn.
    /// </summary>
    GL_LINES = 1,

    /// <summary>
    /// Draws a connected group of line segments from the first vertex to the last. Vertices n and n + 1 define line n. N - 1 lines are drawn.
    /// </summary>
    GL_LINE_STRIP = 3,

    /// <summary>
    /// Draws a connected group of line segments from the first vertex to the last, then back to the first. Vertices n and n + 1 define line n. The last line, however, is defined by vertices N and 1 . N lines are drawn.
    /// </summary>
    GL_LINE_LOOP = 2,

    /// <summary>
    /// Treats each triplet of vertices as an independent triangle. Vertices 3 ⁢ n - 2 , 3 ⁢ n - 1 , and 3 ⁢ n define triangle n. N 3 triangles are drawn.
    /// </summary>
    GL_TRIANGLES = 4,

    /// <summary>
    /// Draws a connected group of triangles. One triangle is defined for each vertex presented after the first two vertices. For odd n, vertices n, n + 1 , and n + 2 define triangle n. For even n, vertices n + 1 , n, and n + 2 define triangle n. N - 2 triangles are drawn.
    /// </summary>
    GL_TRIANGLE_STRIP = 5,

    /// <summary>
    /// Draws a connected group of triangles. One triangle is defined for each vertex presented after the first two vertices. Vertices 1 , n + 1 , and n + 2 define triangle n. N - 2 triangles are drawn.
    /// </summary>
    GL_TRIANGLE_FAN = 6,

    /// <summary>
    /// Treats each group of four vertices as an independent quadrilateral. Vertices 4 ⁢ n - 3 , 4 ⁢ n - 2 , 4 ⁢ n - 1 , and 4 ⁢ n define quadrilateral n. N 4 quadrilaterals are drawn.
    /// </summary>
    GL_QUADS = 7,

    /// <summary>
    /// Draws a connected group of quadrilaterals. One quadrilateral is defined for each pair of vertices presented after the first pair. Vertices 2 ⁢ n - 1 , 2 ⁢ n , 2 ⁢ n + 2 , and 2 ⁢ n + 1 define quadrilateral n. N 2 - 1 quadrilaterals are drawn. Note that the order in which vertices are used to construct a quadrilateral from strip data is different from that used with independent data.
    /// </summary>
    GL_QUAD_STRIP = 8,

    /// <summary>
    /// Draws a single, convex polygon. Vertices 1 through N define this polygon.
    /// </summary>
    GL_POLYGON = 9,

    /// <summary>
    /// 
    /// </summary>
    GL_LINE_STRIP_ADJACENCY = 11,

    /// <summary>
    /// 
    /// </summary>
    GL_LINES_ADJACENCY = 10,

    /// <summary>
    /// 
    /// </summary>
    GL_TRIANGLE_STRIP_ADJACENCY = 13,

    /// <summary>
    /// 
    /// </summary>
    GL_TRIANGLES_ADJACENCY = 12,

    /// <summary>
    /// 
    /// </summary>
    GL_PATCHES = 14,
}

/// <summary>
/// 
/// </summary>
public enum TEXTURE_TARGET : int
{
    /// <summary>
    /// one-dimensional texture
    /// </summary>
    GL_TEXTURE_1D = 0x0DE0,

    /// <summary>
    /// two-dimensional texture
    /// </summary>
    GL_TEXTURE_2D = 0x0DE1,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_1D = 0x8063,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_1D_EXT = 0x8063,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_2D = 0x8064,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_2D_EXT = 0x8064,

    /// <summary>
    /// three-dimensional texture
    /// </summary>
    GL_TEXTURE_3D = 0x806F,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_3D_EXT = 0x806F,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_3D_OES = 0x806F,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_3D = 0x8070,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_3D_EXT = 0x8070,

    /// <summary>
    /// 
    /// </summary>
    GL_DETAIL_TEXTURE_2D_SGIS = 0x8095,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_4D_SGIS = 0x8134,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_4D_SGIS = 0x8135,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_MIN_LOD = 0x813A,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_MIN_LOD_SGIS = 0x813A,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_MAX_LOD = 0x813B,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_MAX_LOD_SGIS = 0x813B,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_BASE_LEVEL = 0x813C,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_BASE_LEVEL_SGIS = 0x813C,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_MAX_LEVEL = 0x813D,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_MAX_LEVEL_SGIS = 0x813D,

    /// <summary>
    /// rectangle texture
    /// </summary>
    GL_TEXTURE_RECTANGLE = 0x84F5,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_RECTANGLE_ARB = 0x84F5,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_RECTANGLE_NV = 0x84F5,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_RECTANGLE = 0x84F7,

    /// <summary>
    /// cube-mapped texture
    /// </summary>
    GL_TEXTURE_CUBE_MAP = 0x8513,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_BINDING_CUBE_MAP = 0x8514,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519,

    /// <summary>
    /// 
    /// </summary>
    GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_CUBE_MAP = 0x851B,

    /// <summary>
    /// one-dimensional array texture
    /// </summary>
    GL_TEXTURE_1D_ARRAY = 0x8C18,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19,

    /// <summary>
    /// two-dimensional array texture
    /// </summary>
    GL_TEXTURE_2D_ARRAY = 0x8C1A,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_2D_ARRAY = 0x8C1B,

    /// <summary>
    /// buffer texture
    /// </summary>
    GL_TEXTURE_BUFFER = 0x8C2A,

    /// <summary>
    /// cube-mapped array texture
    /// </summary>
    GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009,

    /// <summary>
    /// 
    /// </summary>
    GL_PROXY_TEXTURE_CUBE_MAP_ARRAY = 0x900B,

    /// <summary>
    /// two-dimensional multisampled texture, use with glTexImage2DMultisample 
    /// </summary>
    GL_TEXTURE_2D_MULTISAMPLE = 0x9100,

    /// <summary>
    /// Use with glTexImage2DMultisample 
    /// </summary>
    GL_PROXY_TEXTURE_2D_MULTISAMPLE = 0x9101,

    /// <summary>
    /// Use with glTexImage3DMultisample
    /// </summary>
    GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102,

    /// <summary>
    /// Use with glTexImage3DMultisample
    /// </summary>
    GL_PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9103
}

public enum GETSHADER_FLAG : int
{
    GL_SHADER_TYPE = 0x8B4F,

    GL_DELETE_STATUS = 0x8B80,

    GL_COMPILE_STATUS = 0x8B81,

    GL_INFO_LOG_LENGTH = 0x8B84,

    GL_SHADER_SOURCE_LENGTH = 0x8B88,
}

//----Enums Name and Values Updated, still requires more complete commenting above this line ----

public enum SHADER_TYPE : int
{
    FragmentShader = 0x8B30,
    VertexShader = 0x8B31,
    GeometryShader = 0x8DD9,
    TessEvaluationShader = 0x8E87,
    TessControlShader = 0x8E88,
    ComputeShader = 0x91B9,
}

public enum TexInternalFormat : int
{
    /// <summary>
    /// GL_RGBA8
    /// </summary>
    RGBA8 = 0x8058,
    /// <summary>
    /// GL_RGBA16
    /// </summary>
    RGBA16 = 0x805B,
    /// <summary>
    /// GL_R8
    /// </summary>
    R8 = 0x8229,
    /// <summary>
    /// GL_R16
    /// </summary>
    R16 = 0x822A,
    /// <summary>
    /// GL_RG8
    /// </summary>
    RG8 = 0x822B,
    /// <summary>
    /// GL_RG16
    /// </summary>
    RG16 = 0x822C,
    /// <summary>
    /// GL_R16F
    /// </summary>
    R16F = 0x822D,
    /// <summary>
    /// GL_R32F
    /// </summary>
    R32F = 0x822E,
    /// <summary>
    /// GL_RG16F
    /// </summary>
    RG16F = 0x822F,
    /// <summary>
    /// GL_RG32F
    /// </summary>
    RG32F = 0x8230,
    /// <summary>
    /// GL_R8I
    /// </summary>
    R8I = 0x8231,
    /// <summary>
    /// GL_R8UI
    /// </summary>
    R8UI = 0x8232,
    /// <summary>
    /// GL_R16I
    /// </summary>
    R16I = 0x8233,
    /// <summary>
    /// GL_R16UI
    /// </summary>
    R16UI = 0x8234,
    /// <summary>
    /// GL_R32I
    /// </summary>
    R32I = 0x8235,
    /// <summary>
    /// GL_R32UI
    /// </summary>
    R32UI = 0x8236,
    /// <summary>
    /// GL_RG8I
    /// </summary>
    RG8I = 0x8237,
    /// <summary>
    /// GL_RG8UI
    /// </summary>
    RG8UI = 0x8238,
    /// <summary>
    /// GL_RG16I
    /// </summary>
    RG16I = 0x8239,
    /// <summary>
    /// GL_RG16UI
    /// </summary>
    RG16UI = 0x823A,
    /// <summary>
    /// GL_RG32I
    /// </summary>
    RG32I = 0x823B,
    /// <summary>
    /// GL_RG32UI
    /// </summary>
    RG32UI = 0x823C,
    /// <summary>
    /// GL_RGBA32F
    /// </summary>
    RGBA32F = 0x8814,
    /// <summary>
    /// GL_RGBA16F
    /// </summary>
    RGBA16F = 0x881A,
    /// <summary>
    /// GL_RGBA32UI
    /// </summary>
    RGBA32UI = 0x8D70,
    /// <summary>
    /// GL_RGBA16UI
    /// </summary>
    RGBA16UI = 0x8D76,
    /// <summary>
    /// GL_RGBA8UI
    /// </summary>
    RGBA8UI = 0x8D7C,
    /// <summary>
    /// GL_RGBA32I
    /// </summary>
    RGBA32I = 0x8D82,
    /// <summary>
    /// GL_RGBA16I
    /// </summary>
    RGBA16I = 0x8D88,
    /// <summary>
    /// GL_RGBA8I
    /// </summary>
    RGBA8I = 0x8D8E
}

public enum TextureParameter : int
{
    /// <summary>
    /// GL_REPEAT: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    Repeat = 0x2901,
    /// <summary>
    /// GL_CLAMP_TO_BORDER: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    ClampToBorder = 0x812D,
    /// <summary>
    /// GL_CLAMP_TO_BORDER_ARB: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    ClampToBorderARB = 0x812D,
    /// <summary>
    /// GL_CLAMP_TO_BORDER_NV: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    ClampToBorderNV = 0x812D,
    /// <summary>
    /// GL_CLAMP_TO_BORDER_SGIS: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    ClampToBorderSGIS = 0x812D,
    /// <summary>
    /// GL_CLAMP_TO_EDGE: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    ClampToEdge = 0x812F,
    /// <summary>
    /// GL_CLAMP_TO_EDGE_SGIS: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    CLampToEdgeSGIS = 0x812F,
    /// <summary>
    /// GL_MIRRORED_REPEAT: Used with TextureParameterName TextureWrapS / TextureWrapT
    /// </summary>
    MirroredRepeat = 0x8370,


    /// <summary>
    /// GL_NEAREST: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    Nearest = 0x2600,
    /// <summary>
    /// GL_LINEAR: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    Linear = 0x2601,
    /// <summary>
    /// GL_LINEAR_DETAIL_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    LinearDetailSGIS = 0x8097,
    /// <summary>
    /// GL_LINEAR_DETAIL_ALPHA_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    LineaerDetailAlphaSGIS = 0x8098,
    /// <summary>
    /// GL_LINEAR_DETAIL_COLOR_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    LinearDetailColourSGIS = 0x8099,
    /// <summary>
    /// GL_LINEAR_SHARPEN_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    LinearSharpenSGIS = 0x80AD,
    /// <summary>
    /// GL_LINEAR_SHARPEN_ALPHA_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    LinearSharpenAlphaSGIS = 0x80AE,
    /// <summary>
    /// GL_LINEAR_SHARPEN_COLOR_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    LinearSharpenColourSGIS = 0x80AF,
    /// <summary>
    /// GL_FILTER4_SGIS: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    Filter4SGIS = 0x8146,
    /// <summary>
    /// GL_PIXEL_TEX_GEN_Q_CEILING_SGIX: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    PixelTexGenQCeilingSGIX = 0x8184,
    /// <summary>
    /// GL_PIXEL_TEX_GEN_Q_ROUND_SGIX: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    PixelTexGenQRoundSGIX = 0x8185,
    /// <summary>
    /// GL_PIXEL_TEX_GEN_Q_FLOOR_SGIX: Used with TextureParameterName TextureMagFilter / TextureMinFilter
    /// </summary>
    PixelTexGenQFloorSGIX = 0x8186,
    /// <summary>
    /// Original was GL_NEAREST_MIPMAP_NEAREST = 0x2700
    /// </summary>
    NearestMipmapNearest = 0x2700,
    /// <summary>
    /// Original was GL_LINEAR_MIPMAP_NEAREST = 0x2701
    /// </summary>
    LinearMipmapNearest = 0x2701,
    /// <summary>
    /// Original was GL_NEAREST_MIPMAP_LINEAR = 0x2702
    /// </summary>
    NearestMipmapLinear = 0x2702,
    /// <summary>
    /// Original was GL_LINEAR_MIPMAP_LINEAR = 0x2703
    /// </summary>
    LinearMipmapLinear = 0x2703,
    /// <summary>
    /// Original was GL_LINEAR_CLIPMAP_LINEAR_SGIX = 0x8170
    /// </summary>
    LinearClipmapLinearSGIX = 0x8170,
    /// <summary>
    /// Original was GL_NEAREST_CLIPMAP_NEAREST_SGIX = 0x844D
    /// </summary>
    NearestClipmapNearestSGIX = 0x844D,
    /// <summary>
    /// Original was GL_NEAREST_CLIPMAP_LINEAR_SGIX = 0x844E
    /// </summary>
    NearestClipmapLinearSGIX = 0x844E,
    /// <summary>
    /// Original was GL_LINEAR_CLIPMAP_NEAREST_SGIX = 0x844F
    /// </summary>
    LinearClipmapNearestSGIX = 0x844F,

}

public enum TextureParameterName : int
{
    /// <summary>
    /// Original was GL_TEXTURE_BORDER_COLOR = 0x1004
    /// </summary>
    TextureBorderColor = 0x1004,
    /// <summary>
    /// Original was GL_TEXTURE_MAG_FILTER = 0x2800
    /// </summary>
    TextureMagFilter = 0x2800,
    /// <summary>
    /// Original was GL_TEXTURE_MIN_FILTER = 0x2801
    /// </summary>
    TextureMinFilter = 0x2801,
    /// <summary>
    /// Original was GL_TEXTURE_WRAP_S = 0x2802
    /// </summary>
    TextureWrapS = 0x2802,
    /// <summary>
    /// Original was GL_TEXTURE_WRAP_T = 0x2803
    /// </summary>
    TextureWrapT = 0x2803,
    /// <summary>
    /// Original was GL_TEXTURE_PRIORITY = 0x8066
    /// </summary>
    TexturePriority = 0x8066,
    /// <summary>
    /// Original was GL_TEXTURE_PRIORITY_EXT = 0x8066
    /// </summary>
    TexturePriorityExt = 0x8066,
    /// <summary>
    /// Original was GL_TEXTURE_DEPTH = 0x8071
    /// </summary>
    TextureDepth = 0x8071,
    /// <summary>
    /// Original was GL_TEXTURE_WRAP_R = 0x8072
    /// </summary>
    TextureWrapR = 0x8072,
    /// <summary>
    /// Original was GL_TEXTURE_WRAP_R_EXT = 0x8072
    /// </summary>
    TextureWrapRExt = 0x8072,
    /// <summary>
    /// Original was GL_TEXTURE_WRAP_R_OES = 0x8072
    /// </summary>
    TextureWrapROes = 0x8072,
    /// <summary>
    /// Original was GL_DETAIL_TEXTURE_LEVEL_SGIS = 0x809A
    /// </summary>
    DetailTextureLevelSgis = 0x809A,
    /// <summary>
    /// Original was GL_DETAIL_TEXTURE_MODE_SGIS = 0x809B
    /// </summary>
    DetailTextureModeSgis = 0x809B,
    /// <summary>
    /// Original was GL_SHADOW_AMBIENT_SGIX = 0x80BF
    /// </summary>
    ShadowAmbientSgix = 0x80BF,
    /// <summary>
    /// Original was GL_TEXTURE_COMPARE_FAIL_VALUE = 0x80BF
    /// </summary>
    TextureCompareFailValue = 0x80BF,
    /// <summary>
    /// Original was GL_DUAL_TEXTURE_SELECT_SGIS = 0x8124
    /// </summary>
    DualTextureSelectSgis = 0x8124,
    /// <summary>
    /// Original was GL_QUAD_TEXTURE_SELECT_SGIS = 0x8125
    /// </summary>
    QuadTextureSelectSgis = 0x8125,
    /// <summary>
    /// Original was GL_CLAMP_TO_BORDER = 0x812D
    /// </summary>
    ClampToBorder = 0x812D,
    /// <summary>
    /// Original was GL_CLAMP_TO_EDGE = 0x812F
    /// </summary>
    ClampToEdge = 0x812F,
    /// <summary>
    /// Original was GL_TEXTURE_WRAP_Q_SGIS = 0x8137
    /// </summary>
    TextureWrapQSgis = 0x8137,
    /// <summary>
    /// Original was GL_TEXTURE_MIN_LOD = 0x813A
    /// </summary>
    TextureMinLod = 0x813A,
    /// <summary>
    /// Original was GL_TEXTURE_MAX_LOD = 0x813B
    /// </summary>
    TextureMaxLod = 0x813B,
    /// <summary>
    /// Original was GL_TEXTURE_BASE_LEVEL = 0x813C
    /// </summary>
    TextureBaseLevel = 0x813C,
    /// <summary>
    /// Original was GL_TEXTURE_MAX_LEVEL = 0x813D
    /// </summary>
    TextureMaxLevel = 0x813D,
    /// <summary>
    /// Original was GL_TEXTURE_CLIPMAP_CENTER_SGIX = 0x8171
    /// </summary>
    TextureClipmapCenterSgix = 0x8171,
    /// <summary>
    /// Original was GL_TEXTURE_CLIPMAP_FRAME_SGIX = 0x8172
    /// </summary>
    TextureClipmapFrameSgix = 0x8172,
    /// <summary>
    /// Original was GL_TEXTURE_CLIPMAP_OFFSET_SGIX = 0x8173
    /// </summary>
    TextureClipmapOffsetSgix = 0x8173,
    /// <summary>
    /// Original was GL_TEXTURE_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8174
    /// </summary>
    TextureClipmapVirtualDepthSgix = 0x8174,
    /// <summary>
    /// Original was GL_TEXTURE_CLIPMAP_LOD_OFFSET_SGIX = 0x8175
    /// </summary>
    TextureClipmapLodOffsetSgix = 0x8175,
    /// <summary>
    /// Original was GL_TEXTURE_CLIPMAP_DEPTH_SGIX = 0x8176
    /// </summary>
    TextureClipmapDepthSgix = 0x8176,
    /// <summary>
    /// Original was GL_POST_TEXTURE_FILTER_BIAS_SGIX = 0x8179
    /// </summary>
    PostTextureFilterBiasSgix = 0x8179,
    /// <summary>
    /// Original was GL_POST_TEXTURE_FILTER_SCALE_SGIX = 0x817A
    /// </summary>
    PostTextureFilterScaleSgix = 0x817A,
    /// <summary>
    /// Original was GL_TEXTURE_LOD_BIAS_S_SGIX = 0x818E
    /// </summary>
    TextureLodBiasSSgix = 0x818E,
    /// <summary>
    /// Original was GL_TEXTURE_LOD_BIAS_T_SGIX = 0x818F
    /// </summary>
    TextureLodBiasTSgix = 0x818F,
    /// <summary>
    /// Original was GL_TEXTURE_LOD_BIAS_R_SGIX = 0x8190
    /// </summary>
    TextureLodBiasRSgix = 0x8190,
    /// <summary>
    /// Original was GL_GENERATE_MIPMAP = 0x8191
    /// </summary>
    GenerateMipmap = 0x8191,
    /// <summary>
    /// Original was GL_GENERATE_MIPMAP_SGIS = 0x8191
    /// </summary>
    GenerateMipmapSgis = 0x8191,
    /// <summary>
    /// Original was GL_TEXTURE_COMPARE_SGIX = 0x819A
    /// </summary>
    TextureCompareSgix = 0x819A,
    /// <summary>
    /// Original was GL_TEXTURE_MAX_CLAMP_S_SGIX = 0x8369
    /// </summary>
    TextureMaxClampSSgix = 0x8369,
    /// <summary>
    /// Original was GL_TEXTURE_MAX_CLAMP_T_SGIX = 0x836A
    /// </summary>
    TextureMaxClampTSgix = 0x836A,
    /// <summary>
    /// Original was GL_TEXTURE_MAX_CLAMP_R_SGIX = 0x836B
    /// </summary>
    TextureMaxClampRSgix = 0x836B,
    /// <summary>
    /// Original was GL_TEXTURE_LOD_BIAS = 0x8501
    /// </summary>
    TextureLodBias = 0x8501,
    /// <summary>
    /// Original was GL_DEPTH_TEXTURE_MODE = 0x884B
    /// </summary>
    DepthTextureMode = 0x884B,
    /// <summary>
    /// Original was GL_TEXTURE_COMPARE_MODE = 0x884C
    /// </summary>
    TextureCompareMode = 0x884C,
    /// <summary>
    /// Original was GL_TEXTURE_COMPARE_FUNC = 0x884D
    /// </summary>
    TextureCompareFunc = 0x884D,
    /// <summary>
    /// Original was GL_TEXTURE_SWIZZLE_R = 0x8E42
    /// </summary>
    TextureSwizzleR = 0x8E42,
    /// <summary>
    /// Original was GL_TEXTURE_SWIZZLE_G = 0x8E43
    /// </summary>
    TextureSwizzleG = 0x8E43,
    /// <summary>
    /// Original was GL_TEXTURE_SWIZZLE_B = 0x8E44
    /// </summary>
    TextureSwizzleB = 0x8E44,
    /// <summary>
    /// Original was GL_TEXTURE_SWIZZLE_A = 0x8E45
    /// </summary>
    TextureSwizzleA = 0x8E45,
    /// <summary>
    /// Original was GL_TEXTURE_SWIZZLE_RGBA = 0x8E46
    /// </summary>
    TextureSwizzleRgba = 0x8E46,
}

public enum TextureTargetMultisample : int
{
    /// <summary>
    /// GL_TEXTURE_2D_MULTISAMPLE
    /// </summary>
    Texture2DMultisample = 0x9100,
    /// <summary>
    /// GL_PROXY_TEXTURE_2D_MULTISAMPLE
    /// </summary>
    ProxyTexture2DMultisample = 0x9101,
    /// <summary>
    /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY
    /// </summary>
    Texture2DMultisampleArray = 0x9102,
    /// <summary>
    /// GL_PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY
    /// </summary>
    ProxyTexture2DMultisampleArray = 0x9103,
}

public enum TEXTURE_UNIT
{
    GL_TEXTURE0 = 33984,

    GL_TEXTURE1 = 33985,

    GL_TEXTURE2 = 33986,

    GL_TEXTURE3 = 33987,

    GL_TEXTURE4 = 33988,

    GL_TEXTURE5 = 33989,

    GL_TEXTURE6 = 33990,

    GL_TEXTURE7 = 33991,

    GL_TEXTURE8 = 33992,

    GL_TEXTURE9 = 33993,

    GL_TEXTURE10 = 33994,

    GL_TEXTURE11 = 33995,

    GL_TEXTURE12 = 33996,

    GL_TEXTURE13 = 33997,

    GL_TEXTURE14 = 33998,

    GL_TEXTURE15 = 33999,

    GL_TEXTURE16 = 34000,

    GL_TEXTURE17 = 34001,

    GL_TEXTURE18 = 34002,

    GL_TEXTURE19 = 34003,

    GL_TEXTURE20 = 34004,

    GL_TEXTURE21 = 34005,

    GL_TEXTURE22 = 34006,

    GL_TEXTURE23 = 34007,

    GL_TEXTURE24 = 34008,

    GL_TEXTURE25 = 34009,

    GL_TEXTURE26 = 34010,

    GL_TEXTURE27 = 34011,

    GL_TEXTURE28 = 34012,

    GL_TEXTURE29 = 34013,

    GL_TEXTURE30 = 34014,

    GL_TEXTURE31 = 34015,
}

[Flags]
public enum STATEARRAY : uint
{
    /// <summary>
    /// GL_VERTEX_ARRAY
    /// </summary>
    VertexArray = 0x8074,
    /// <summary>
    /// GL_NORMAL_ARRAY
    /// </summary>
    NormalArray = 0x8075,
    /// <summary>
    /// GL_COLOR_ARRAY
    /// </summary>
    ColourArray = 0x8076,
    /// <summary>
    /// GL_INDEX_ARRAY
    /// </summary>
    IndexArray = 0x8077,
    /// <summary>
    /// GL_TEXTURE_COORD_ARRAY
    /// </summary>
    TextureCoordArray = 0x8078,
    /// <summary>
    /// GL_EDGE_FLAG_ARRAY
    /// </summary>
    EdgeFlagArray = 0x8079,
    /// <summary>
    /// GL_VERTEX_ARRAY_SIZE
    /// </summary>
    VertexArraySize = 0x807A,
    /// <summary>
    /// GL_VERTEX_ARRAY_TYPE
    /// </summary>
    VertexArrayType = 0x807B,
    /// <summary>
    /// GL_VERTEX_ARRAY_STRIDE
    /// </summary>
    VertexArrayStride = 0x807C,
    /// <summary>
    /// GL_NORMAL_ARRAY_TYPE
    /// </summary>
    NormalArrayType = 0x807E,
    /// <summary>
    /// GL_NORMAL_ARRAY_STRIDE
    /// </summary>
    NormalArrayStride = 0x807F,
    /// <summary>
    /// GL_COLOR_ARRAY_SIZE
    /// </summary>
    ColourArraySize = 0x8081,
    /// <summary>
    /// GL_COLOR_ARRAY_TYPE
    /// </summary>
    ColourArrayType = 0x8082,
    /// <summary>
    /// GL_COLOR_ARRAY_STRIDE
    /// </summary>
    ColourArrayStride = 0x8083,
    /// <summary>
    /// GL_INDEX_ARRAY_TYPE
    /// </summary>
    IndexArrayType = 0x8085,
    /// <summary>
    /// GL_INDEX_ARRAY_STRIDE
    /// </summary>
    IndexArrayStride = 0x8086,
    /// <summary>
    /// GL_TEXTURE_COORD_ARRAY_SIZE
    /// </summary>
    TextureCoordArraySize = 0x8088,
    /// <summary>
    /// GL_TEXTURE_COORD_ARRAY_TYPE
    /// </summary>
    TextureCoordArrayType = 0x8089,
    /// <summary>
    /// GL_TEXTURE_COORD_ARRAY_STRIDE
    /// </summary>
    TextureCoordArrayStride = 0x808A,
    /// <summary>
    /// GL_EDGE_FLAG_ARRAY_STRIDE
    /// </summary>
    EdgeFlagArrayStride = 0x808C,
    /// <summary>
    /// GL_VERTEX_ARRAY_POINTER
    /// </summary>
    VertexArrayPointer = 0x808E,
    /// <summary>
    /// GL_NORMAL_ARRAY_POINTER
    /// </summary>
    NormalArrayPointer = 0x808F,
    /// <summary>
    /// GL_COLOR_ARRAY_POINTER
    /// </summary>
    ColourArrayPointer = 0x8090,
    /// <summary>
    /// GL_INDEX_ARRAY_POINTER
    /// </summary>
    IndexArrayPointer = 0x8091,
    /// <summary>
    /// GL_TEXTURE_COORD_ARRAY_POINTER
    /// </summary>
    TextureCoordArrayPointer = 0x8092,
    /// <summary>
    /// GL_EDGE_FLAG_ARRAY_POINTER
    /// </summary>
    EdgeFlagArrayPointer = 0x8093,
    /// <summary>
    /// GL_V2F
    /// </summary>
    V2F = 0x2A20,
    /// <summary>
    /// GL_V3F
    /// </summary>
    V3F = 0x2A21,
    /// <summary>
    /// GL_C4UB_V2F
    /// </summary>
    C4UB_V2F = 0x2A22,
    /// <summary>
    /// GL_C4UB_V3F
    /// </summary>
    C4UB_V3F = 0x2A23,
    /// <summary>
    /// GL_C3F_V3F
    /// </summary>
    C3F_V3F = 0x2A24,
    /// <summary>
    /// GL_N3F_V3F
    /// </summary>
    N3F_V3F = 0x2A25,
    /// <summary>
    /// GL_C4F_N3F_V3F
    /// </summary>
    C4F_N3F_V3F = 0x2A26,
    /// <summary>
    /// GL_T2F_V3F
    /// </summary>
    T2F_V3F = 0x2A27,
    /// <summary>
    /// GL_T4F_V4F
    /// </summary>
    T4F_V4F = 0x2A28,
    /// <summary>
    /// GL_T2F_C4UB_V3F
    /// </summary>
    T2F_C4UB_V3F = 0x2A29,
    /// <summary>
    /// GL_T2F_C3F_V3F
    /// </summary>
    T2F_C3F_V3F = 0x2A2A,
    /// <summary>
    /// GL_T2F_N3F_V3F
    /// </summary>
    T2F_N3F_V3F = 0x2A2B,
    /// <summary>
    /// GL_T2F_C4F_N3F_V3F
    /// </summary>
    T2F_C4F_N3F_V3F = 0x2A2C,
    /// <summary>
    /// GL_T4F_C4F_N3F_V4F
    /// </summary>
    T4F_C4F_N3F_V4F = 0x2A2D,
}

public enum VertexAttribPointerType : int
{
    Byte = 5120,
    UnsignedByte = 5121,
    Short = 5122,
    UnsignedShort = 5123,
    Int = 5124,
    UnsignedInt = 5125,
    Float = 5126,
    Double = 5130,
    HalfFloat = 5131,
    Fixed = 5132,
    UnsignedInt2101010Rev = 33640,
    Int2101010Rev = 36255,
}

public enum VSyncMode : int
{
    On = 1,
    Off = 0,
    Adaptive = -1
}

//todo: force the relevant function to take this enum (tricky because it's an array of ints, and half need to stay ints)
public enum ArbCreateContext
{
    CoreProfileBit = 0x0001,
    CompatibilityProfileBit = 0x0002,
    DebugBit = 0x0001,
    ForwardCompatibleBit = 0x0002,
    MajorVersion = 0x2091,
    MinorVersion = 0x2092,
    LayerPlane = 0x2093,
    ContextFlags = 0x2094,
    ErrorInvalidVersion = 0x2095,
    ProfileMask = 0x9126,
}

public enum BUFFER_TARGET : int
{
    /// <summary>
    /// Original was GL_ARRAY_BUFFER = 0x8892
    /// </summary>
    ArrayBuffer = 0x8892,
    /// <summary>
    /// Original was GL_ELEMENT_ARRAY_BUFFER = 0x8893
    /// </summary>
    ElementArrayBuffer = 0x8893,
    /// <summary>
    /// Original was GL_PIXEL_PACK_BUFFER = 0x88EB
    /// </summary>
    PixelPackBuffer = 0x88EB,
    /// <summary>
    /// Original was GL_PIXEL_UNPACK_BUFFER = 0x88EC
    /// </summary>
    PixelUnpackBuffer = 0x88EC,
    /// <summary>
    /// Original was GL_UNIFORM_BUFFER = 0x8A11
    /// </summary>
    UniformBuffer = 0x8A11,
    /// <summary>
    /// Original was GL_TEXTURE_BUFFER = 0x8C2A
    /// </summary>
    TextureBuffer = 0x8C2A,
    /// <summary>
    /// Original was GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E
    /// </summary>
    TransformFeedbackBuffer = 0x8C8E,
    /// <summary>
    /// Original was GL_COPY_READ_BUFFER = 0x8F36
    /// </summary>
    CopyReadBuffer = 0x8F36,
    /// <summary>
    /// Original was GL_COPY_WRITE_BUFFER = 0x8F37
    /// </summary>
    CopyWriteBuffer = 0x8F37,
    /// <summary>
    /// Original was GL_DRAW_INDIRECT_BUFFER = 0x8F3F
    /// </summary>
    DrawIndirectBuffer = 0x8F3F,
    /// <summary>
    /// Original was GL_SHADER_STORAGE_BUFFER = 0x90D2
    /// </summary>
    ShaderStorageBuffer = 0x90D2,
    /// <summary>
    /// Original was GL_DISPATCH_INDIRECT_BUFFER = 0x90EE
    /// </summary>
    DispatchIndirectBuffer = 0x90EE,
    /// <summary>
    /// Original was GL_QUERY_BUFFER = 0x9192
    /// </summary>
    QueryBuffer = 0x9192,
    /// <summary>
    /// Original was GL_ATOMIC_COUNTER_BUFFER = 0x92C0
    /// </summary>
    AtomicCounterBuffer = 0x92C0,
}

public enum USAGE_PATTERN : int
{
    /// <summary>
    /// Original was GL_STREAM_DRAW = 0x88E0
    /// </summary>
    StreamDraw = 0x88E0,
    /// <summary>
    /// Original was GL_STREAM_READ = 0x88E1
    /// </summary>
    StreamRead = 0x88E1,
    /// <summary>
    /// Original was GL_STREAM_COPY = 0x88E2
    /// </summary>
    StreamCopy = 0x88E2,
    /// <summary>
    /// Original was GL_STATIC_DRAW = 0x88E4
    /// </summary>
    StaticDraw = 0x88E4,
    /// <summary>
    /// Original was GL_STATIC_READ = 0x88E5
    /// </summary>
    StaticRead = 0x88E5,
    /// <summary>
    /// Original was GL_STATIC_COPY = 0x88E6
    /// </summary>
    StaticCopy = 0x88E6,
    /// <summary>
    /// Original was GL_DYNAMIC_DRAW = 0x88E8
    /// </summary>
    DynamicDraw = 0x88E8,
    /// <summary>
    /// Original was GL_DYNAMIC_READ = 0x88E9
    /// </summary>
    DynamicRead = 0x88E9,
    /// <summary>
    /// Original was GL_DYNAMIC_COPY = 0x88EA
    /// </summary>
    DynamicCopy = 0x88EA,
}

[Flags]
public enum DataType : uint
{
    /// <summary>
    /// Original was GL_BYTE = 0x1400
    /// </summary>
    Byte = 0x1400,
    /// <summary>
    /// Original was GL_UNSIGNED_BYTE = 0x1401
    /// </summary>
    UnsignedByte = 0x1401,
    /// <summary>
    /// Original was GL_SHORT = 0x1402
    /// </summary>
    Short = 0x1402,
    /// <summary>
    /// Original was GL_UNSIGNED_SHORT = 0x1403
    /// </summary>
    UnsignedShort = 0x1403,
    /// <summary>
    /// Original was GL_INT = 0x1404
    /// </summary>
    Int = 0x1404,
    /// <summary>
    /// Original was GL_UNSIGNED_INT = 0x1405
    /// </summary>
    UnsignedInt = 0x1405,
    /// <summary>
    /// Original was GL_FLOAT = 0x1406
    /// </summary>
    Float = 0x1406,
    /// <summary>
    /// Original was GL_2_BYTES = 0x1407
    /// </summary>
    TwoBytes = 0x1407,
    /// <summary>
    /// Original was GL_3_BYTES = 0x1408
    /// </summary>
    ThreeBytes = 0x1408,
    /// <summary>
    /// Original was GL_4_BYTES = 0x1409
    /// </summary>
    FourBytes = 0x1409,
    /// <summary>
    /// Original was GL_DOUBLE = 0x140A
    /// </summary>
    Double = 0x140A
}

public enum GLCAP : int
{
    /// <summary>
    /// Original was GL_POINT_SMOOTH = 0x0B10
    /// </summary>
    PointSmooth = 0x0B10,
    /// <summary>
    /// Original was GL_LINE_SMOOTH = 0x0B20
    /// </summary>
    LineSmooth = 0x0B20,
    /// <summary>
    /// Original was GL_LINE_STIPPLE = 0x0B24
    /// </summary>
    LineStipple = 0x0B24,
    /// <summary>
    /// Original was GL_POLYGON_SMOOTH = 0x0B41
    /// </summary>
    PolygonSmooth = 0x0B41,
    /// <summary>
    /// Original was GL_POLYGON_STIPPLE = 0x0B42
    /// </summary>
    PolygonStipple = 0x0B42,
    /// <summary>
    /// Original was GL_CULL_FACE = 0x0B44
    /// </summary>
    CullFace = 0x0B44,
    /// <summary>
    /// Original was GL_LIGHTING = 0x0B50
    /// </summary>
    Lighting = 0x0B50,
    /// <summary>
    /// Original was GL_COLOR_MATERIAL = 0x0B57
    /// </summary>
    ColorMaterial = 0x0B57,
    /// <summary>
    /// Original was GL_FOG = 0x0B60
    /// </summary>
    Fog = 0x0B60,
    /// <summary>
    /// Original was GL_DEPTH_TEST = 0x0B71
    /// </summary>
    DepthTest = 0x0B71,
    /// <summary>
    /// Original was GL_STENCIL_TEST = 0x0B90
    /// </summary>
    StencilTest = 0x0B90,
    /// <summary>
    /// Original was GL_NORMALIZE = 0x0BA1
    /// </summary>
    Normalize = 0x0BA1,
    /// <summary>
    /// Original was GL_ALPHA_TEST = 0x0BC0
    /// </summary>
    AlphaTest = 0x0BC0,
    /// <summary>
    /// Original was GL_DITHER = 0x0BD0
    /// </summary>
    Dither = 0x0BD0,
    /// <summary>
    /// Original was GL_BLEND = 0x0BE2
    /// </summary>
    Blend = 0x0BE2,
    /// <summary>
    /// Original was GL_INDEX_LOGIC_OP = 0x0BF1
    /// </summary>
    IndexLogicOp = 0x0BF1,
    /// <summary>
    /// Original was GL_COLOR_LOGIC_OP = 0x0BF2
    /// </summary>
    ColorLogicOp = 0x0BF2,
    /// <summary>
    /// Original was GL_SCISSOR_TEST = 0x0C11
    /// </summary>
    ScissorTest = 0x0C11,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_S = 0x0C60
    /// </summary>
    TextureGenS = 0x0C60,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_T = 0x0C61
    /// </summary>
    TextureGenT = 0x0C61,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_R = 0x0C62
    /// </summary>
    TextureGenR = 0x0C62,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_Q = 0x0C63
    /// </summary>
    TextureGenQ = 0x0C63,
    /// <summary>
    /// Original was GL_AUTO_NORMAL = 0x0D80
    /// </summary>
    AutoNormal = 0x0D80,
    /// <summary>
    /// Original was GL_MAP1_COLOR_4 = 0x0D90
    /// </summary>
    Map1Color4 = 0x0D90,
    /// <summary>
    /// Original was GL_MAP1_INDEX = 0x0D91
    /// </summary>
    Map1Index = 0x0D91,
    /// <summary>
    /// Original was GL_MAP1_NORMAL = 0x0D92
    /// </summary>
    Map1Normal = 0x0D92,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_1 = 0x0D93
    /// </summary>
    Map1TextureCoord1 = 0x0D93,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_2 = 0x0D94
    /// </summary>
    Map1TextureCoord2 = 0x0D94,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_3 = 0x0D95
    /// </summary>
    Map1TextureCoord3 = 0x0D95,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_4 = 0x0D96
    /// </summary>
    Map1TextureCoord4 = 0x0D96,
    /// <summary>
    /// Original was GL_MAP1_VERTEX_3 = 0x0D97
    /// </summary>
    Map1Vertex3 = 0x0D97,
    /// <summary>
    /// Original was GL_MAP1_VERTEX_4 = 0x0D98
    /// </summary>
    Map1Vertex4 = 0x0D98,
    /// <summary>
    /// Original was GL_MAP2_COLOR_4 = 0x0DB0
    /// </summary>
    Map2Color4 = 0x0DB0,
    /// <summary>
    /// Original was GL_MAP2_INDEX = 0x0DB1
    /// </summary>
    Map2Index = 0x0DB1,
    /// <summary>
    /// Original was GL_MAP2_NORMAL = 0x0DB2
    /// </summary>
    Map2Normal = 0x0DB2,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_1 = 0x0DB3
    /// </summary>
    Map2TextureCoord1 = 0x0DB3,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_2 = 0x0DB4
    /// </summary>
    Map2TextureCoord2 = 0x0DB4,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_3 = 0x0DB5
    /// </summary>
    Map2TextureCoord3 = 0x0DB5,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_4 = 0x0DB6
    /// </summary>
    Map2TextureCoord4 = 0x0DB6,
    /// <summary>
    /// Original was GL_MAP2_VERTEX_3 = 0x0DB7
    /// </summary>
    Map2Vertex3 = 0x0DB7,
    /// <summary>
    /// Original was GL_MAP2_VERTEX_4 = 0x0DB8
    /// </summary>
    Map2Vertex4 = 0x0DB8,
    /// <summary>
    /// Original was GL_TEXTURE_1D = 0x0DE0
    /// </summary>
    Texture1D = 0x0DE0,
    /// <summary>
    /// Original was GL_TEXTURE_2D = 0x0DE1
    /// </summary>
    Texture2D = 0x0DE1,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_POINT = 0x2A01
    /// </summary>
    PolygonOffsetPoint = 0x2A01,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_LINE = 0x2A02
    /// </summary>
    PolygonOffsetLine = 0x2A02,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE0 = 0x3000
    /// </summary>
    ClipDistance0 = 0x3000,
    /// <summary>
    /// Original was GL_CLIP_PLANE0 = 0x3000
    /// </summary>
    ClipPlane0 = 0x3000,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE1 = 0x3001
    /// </summary>
    ClipDistance1 = 0x3001,
    /// <summary>
    /// Original was GL_CLIP_PLANE1 = 0x3001
    /// </summary>
    ClipPlane1 = 0x3001,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE2 = 0x3002
    /// </summary>
    ClipDistance2 = 0x3002,
    /// <summary>
    /// Original was GL_CLIP_PLANE2 = 0x3002
    /// </summary>
    ClipPlane2 = 0x3002,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE3 = 0x3003
    /// </summary>
    ClipDistance3 = 0x3003,
    /// <summary>
    /// Original was GL_CLIP_PLANE3 = 0x3003
    /// </summary>
    ClipPlane3 = 0x3003,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE4 = 0x3004
    /// </summary>
    ClipDistance4 = 0x3004,
    /// <summary>
    /// Original was GL_CLIP_PLANE4 = 0x3004
    /// </summary>
    ClipPlane4 = 0x3004,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE5 = 0x3005
    /// </summary>
    ClipDistance5 = 0x3005,
    /// <summary>
    /// Original was GL_CLIP_PLANE5 = 0x3005
    /// </summary>
    ClipPlane5 = 0x3005,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE6 = 0x3006
    /// </summary>
    ClipDistance6 = 0x3006,
    /// <summary>
    /// Original was GL_CLIP_DISTANCE7 = 0x3007
    /// </summary>
    ClipDistance7 = 0x3007,
    /// <summary>
    /// Original was GL_LIGHT0 = 0x4000
    /// </summary>
    Light0 = 0x4000,
    /// <summary>
    /// Original was GL_LIGHT1 = 0x4001
    /// </summary>
    Light1 = 0x4001,
    /// <summary>
    /// Original was GL_LIGHT2 = 0x4002
    /// </summary>
    Light2 = 0x4002,
    /// <summary>
    /// Original was GL_LIGHT3 = 0x4003
    /// </summary>
    Light3 = 0x4003,
    /// <summary>
    /// Original was GL_LIGHT4 = 0x4004
    /// </summary>
    Light4 = 0x4004,
    /// <summary>
    /// Original was GL_LIGHT5 = 0x4005
    /// </summary>
    Light5 = 0x4005,
    /// <summary>
    /// Original was GL_LIGHT6 = 0x4006
    /// </summary>
    Light6 = 0x4006,
    /// <summary>
    /// Original was GL_LIGHT7 = 0x4007
    /// </summary>
    Light7 = 0x4007,
    /// <summary>
    /// Original was GL_CONVOLUTION_1D = 0x8010
    /// </summary>
    Convolution1D = 0x8010,
    /// <summary>
    /// Original was GL_CONVOLUTION_1D_EXT = 0x8010
    /// </summary>
    Convolution1DExt = 0x8010,
    /// <summary>
    /// Original was GL_CONVOLUTION_2D = 0x8011
    /// </summary>
    Convolution2D = 0x8011,
    /// <summary>
    /// Original was GL_CONVOLUTION_2D_EXT = 0x8011
    /// </summary>
    Convolution2DExt = 0x8011,
    /// <summary>
    /// Original was GL_SEPARABLE_2D = 0x8012
    /// </summary>
    Separable2D = 0x8012,
    /// <summary>
    /// Original was GL_SEPARABLE_2D_EXT = 0x8012
    /// </summary>
    Separable2DExt = 0x8012,
    /// <summary>
    /// Original was GL_HISTOGRAM = 0x8024
    /// </summary>
    Histogram = 0x8024,
    /// <summary>
    /// Original was GL_HISTOGRAM_EXT = 0x8024
    /// </summary>
    HistogramExt = 0x8024,
    /// <summary>
    /// Original was GL_MINMAX_EXT = 0x802E
    /// </summary>
    MinmaxExt = 0x802E,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_FILL = 0x8037
    /// </summary>
    PolygonOffsetFill = 0x8037,
    /// <summary>
    /// Original was GL_RESCALE_NORMAL = 0x803A
    /// </summary>
    RescaleNormal = 0x803A,
    /// <summary>
    /// Original was GL_RESCALE_NORMAL_EXT = 0x803A
    /// </summary>
    RescaleNormalExt = 0x803A,
    /// <summary>
    /// Original was GL_TEXTURE_3D_EXT = 0x806F
    /// </summary>
    Texture3DExt = 0x806F,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY = 0x8074
    /// </summary>
    VertexArray = 0x8074,
    /// <summary>
    /// Original was GL_NORMAL_ARRAY = 0x8075
    /// </summary>
    NormalArray = 0x8075,
    /// <summary>
    /// Original was GL_COLOR_ARRAY = 0x8076
    /// </summary>
    ColorArray = 0x8076,
    /// <summary>
    /// Original was GL_INDEX_ARRAY = 0x8077
    /// </summary>
    IndexArray = 0x8077,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY = 0x8078
    /// </summary>
    TextureCoordArray = 0x8078,
    /// <summary>
    /// Original was GL_EDGE_FLAG_ARRAY = 0x8079
    /// </summary>
    EdgeFlagArray = 0x8079,
    /// <summary>
    /// Original was GL_INTERLACE_SGIX = 0x8094
    /// </summary>
    InterlaceSgix = 0x8094,
    /// <summary>
    /// Original was GL_MULTISAMPLE = 0x809D
    /// </summary>
    Multisample = 0x809D,
    /// <summary>
    /// Original was GL_MULTISAMPLE_SGIS = 0x809D
    /// </summary>
    MultisampleSgis = 0x809D,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E
    /// </summary>
    SampleAlphaToCoverage = 0x809E,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_MASK_SGIS = 0x809E
    /// </summary>
    SampleAlphaToMaskSgis = 0x809E,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_ONE = 0x809F
    /// </summary>
    SampleAlphaToOne = 0x809F,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_ONE_SGIS = 0x809F
    /// </summary>
    SampleAlphaToOneSgis = 0x809F,
    /// <summary>
    /// Original was GL_SAMPLE_COVERAGE = 0x80A0
    /// </summary>
    SampleCoverage = 0x80A0,
    /// <summary>
    /// Original was GL_SAMPLE_MASK_SGIS = 0x80A0
    /// </summary>
    SampleMaskSgis = 0x80A0,
    /// <summary>
    /// Original was GL_TEXTURE_COLOR_TABLE_SGI = 0x80BC
    /// </summary>
    TextureColorTableSgi = 0x80BC,
    /// <summary>
    /// Original was GL_COLOR_TABLE = 0x80D0
    /// </summary>
    ColorTable = 0x80D0,
    /// <summary>
    /// Original was GL_COLOR_TABLE_SGI = 0x80D0
    /// </summary>
    ColorTableSgi = 0x80D0,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_COLOR_TABLE = 0x80D1
    /// </summary>
    PostConvolutionColorTable = 0x80D1,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1
    /// </summary>
    PostConvolutionColorTableSgi = 0x80D1,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D2
    /// </summary>
    PostColorMatrixColorTable = 0x80D2,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2
    /// </summary>
    PostColorMatrixColorTableSgi = 0x80D2,
    /// <summary>
    /// Original was GL_TEXTURE_4D_SGIS = 0x8134
    /// </summary>
    Texture4DSgis = 0x8134,
    /// <summary>
    /// Original was GL_PIXEL_TEX_GEN_SGIX = 0x8139
    /// </summary>
    PixelTexGenSgix = 0x8139,
    /// <summary>
    /// Original was GL_SPRITE_SGIX = 0x8148
    /// </summary>
    SpriteSgix = 0x8148,
    /// <summary>
    /// Original was GL_REFERENCE_PLANE_SGIX = 0x817D
    /// </summary>
    ReferencePlaneSgix = 0x817D,
    /// <summary>
    /// Original was GL_IR_INSTRUMENT1_SGIX = 0x817F
    /// </summary>
    IrInstrument1Sgix = 0x817F,
    /// <summary>
    /// Original was GL_CALLIGRAPHIC_FRAGMENT_SGIX = 0x8183
    /// </summary>
    CalligraphicFragmentSgix = 0x8183,
    /// <summary>
    /// Original was GL_FRAMEZOOM_SGIX = 0x818B
    /// </summary>
    FramezoomSgix = 0x818B,
    /// <summary>
    /// Original was GL_FOG_OFFSET_SGIX = 0x8198
    /// </summary>
    FogOffsetSgix = 0x8198,
    /// <summary>
    /// Original was GL_SHARED_TEXTURE_PALETTE_EXT = 0x81FB
    /// </summary>
    SharedTexturePaletteExt = 0x81FB,
    /// <summary>
    /// Original was GL_DEBUG_OUTPUT_SYNCHRONOUS = 0x8242
    /// </summary>
    DebugOutputSynchronous = 0x8242,
    /// <summary>
    /// Original was GL_ASYNC_HISTOGRAM_SGIX = 0x832C
    /// </summary>
    AsyncHistogramSgix = 0x832C,
    /// <summary>
    /// Original was GL_PIXEL_TEXTURE_SGIS = 0x8353
    /// </summary>
    PixelTextureSgis = 0x8353,
    /// <summary>
    /// Original was GL_ASYNC_TEX_IMAGE_SGIX = 0x835C
    /// </summary>
    AsyncTexImageSgix = 0x835C,
    /// <summary>
    /// Original was GL_ASYNC_DRAW_PIXELS_SGIX = 0x835D
    /// </summary>
    AsyncDrawPixelsSgix = 0x835D,
    /// <summary>
    /// Original was GL_ASYNC_READ_PIXELS_SGIX = 0x835E
    /// </summary>
    AsyncReadPixelsSgix = 0x835E,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHTING_SGIX = 0x8400
    /// </summary>
    FragmentLightingSgix = 0x8400,
    /// <summary>
    /// Original was GL_FRAGMENT_COLOR_MATERIAL_SGIX = 0x8401
    /// </summary>
    FragmentColorMaterialSgix = 0x8401,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT0_SGIX = 0x840C
    /// </summary>
    FragmentLight0Sgix = 0x840C,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT1_SGIX = 0x840D
    /// </summary>
    FragmentLight1Sgix = 0x840D,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT2_SGIX = 0x840E
    /// </summary>
    FragmentLight2Sgix = 0x840E,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT3_SGIX = 0x840F
    /// </summary>
    FragmentLight3Sgix = 0x840F,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT4_SGIX = 0x8410
    /// </summary>
    FragmentLight4Sgix = 0x8410,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT5_SGIX = 0x8411
    /// </summary>
    FragmentLight5Sgix = 0x8411,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT6_SGIX = 0x8412
    /// </summary>
    FragmentLight6Sgix = 0x8412,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT7_SGIX = 0x8413
    /// </summary>
    FragmentLight7Sgix = 0x8413,
    /// <summary>
    /// Original was GL_FOG_COORD_ARRAY = 0x8457
    /// </summary>
    FogCoordArray = 0x8457,
    /// <summary>
    /// Original was GL_COLOR_SUM = 0x8458
    /// </summary>
    ColorSum = 0x8458,
    /// <summary>
    /// Original was GL_SECONDARY_COLOR_ARRAY = 0x845E
    /// </summary>
    SecondaryColorArray = 0x845E,
    /// <summary>
    /// Original was GL_TEXTURE_RECTANGLE = 0x84F5
    /// </summary>
    TextureRectangle = 0x84F5,
    /// <summary>
    /// Original was GL_TEXTURE_CUBE_MAP = 0x8513
    /// </summary>
    TextureCubeMap = 0x8513,
    /// <summary>
    /// Original was GL_PROGRAM_POINT_SIZE = 0x8642
    /// </summary>
    ProgramPointSize = 0x8642,
    /// <summary>
    /// Original was GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642
    /// </summary>
    VertexProgramPointSize = 0x8642,
    /// <summary>
    /// Original was GL_VERTEX_PROGRAM_TWO_SIDE = 0x8643
    /// </summary>
    VertexProgramTwoSide = 0x8643,
    /// <summary>
    /// Original was GL_DEPTH_CLAMP = 0x864F
    /// </summary>
    DepthClamp = 0x864F,
    /// <summary>
    /// Original was GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F
    /// </summary>
    TextureCubeMapSeamless = 0x884F,
    /// <summary>
    /// Original was GL_POINT_SPRITE = 0x8861
    /// </summary>
    PointSprite = 0x8861,
    /// <summary>
    /// Original was GL_SAMPLE_SHADING = 0x8C36
    /// </summary>
    SampleShading = 0x8C36,
    /// <summary>
    /// Original was GL_RASTERIZER_DISCARD = 0x8C89
    /// </summary>
    RasterizerDiscard = 0x8C89,
    /// <summary>
    /// Original was GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69
    /// </summary>
    PrimitiveRestartFixedIndex = 0x8D69,
    /// <summary>
    /// Original was GL_FRAMEBUFFER_SRGB = 0x8DB9
    /// </summary>
    FramebufferSrgb = 0x8DB9,
    /// <summary>
    /// Original was GL_SAMPLE_MASK = 0x8E51
    /// </summary>
    SampleMask = 0x8E51,
    /// <summary>
    /// Original was GL_PRIMITIVE_RESTART = 0x8F9D
    /// </summary>
    PrimitiveRestart = 0x8F9D,
    /// <summary>
    /// Original was GL_DEBUG_OUTPUT = 0x92E0
    /// </summary>
    DebugOutput = 0x92E0,
}

public enum FRAMEBUFFER_ATTACHMENT_POINT : int
{
    /// <summary>
    /// Original was GL_FRONT_LEFT = 0x0400
    /// </summary>
    FrontLeft = 0x0400,
    /// <summary>
    /// Original was GL_FRONT_RIGHT = 0x0401
    /// </summary>
    FrontRight = 0x0401,
    /// <summary>
    /// Original was GL_BACK_LEFT = 0x0402
    /// </summary>
    BackLeft = 0x0402,
    /// <summary>
    /// Original was GL_BACK_RIGHT = 0x0403
    /// </summary>
    BackRight = 0x0403,
    /// <summary>
    /// Original was GL_AUX0 = 0x0409
    /// </summary>
    Aux0 = 0x0409,
    /// <summary>
    /// Original was GL_AUX1 = 0x040A
    /// </summary>
    Aux1 = 0x040A,
    /// <summary>
    /// Original was GL_AUX2 = 0x040B
    /// </summary>
    Aux2 = 0x040B,
    /// <summary>
    /// Original was GL_AUX3 = 0x040C
    /// </summary>
    Aux3 = 0x040C,
    /// <summary>
    /// Original was GL_COLOR = 0x1800
    /// </summary>
    Colour = 0x1800,
    /// <summary>
    /// Original was GL_DEPTH = 0x1801
    /// </summary>
    Depth = 0x1801,
    /// <summary>
    /// Original was GL_STENCIL = 0x1802
    /// </summary>
    Stencil = 0x1802,
    /// <summary>
    /// Original was GL_DEPTH_STENCIL_ATTACHMENT = 0x821A
    /// </summary>
    DepthStencilAttachment = 0x821A,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT0 = 0x8CE0
    /// </summary>
    ColourAttachment0 = 0x8CE0,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT0_EXT = 0x8CE0
    /// </summary>
    ColourAttachment0Ext = 0x8CE0,
    /// <summary>
    /// Original was  GL_COLOR_ATTACHMENT1 = 0x8CE1
    /// </summary>
    ColourAttachment1 = 0x8CE1,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT1_EXT = 0x8CE1
    /// </summary>
    ColourAttachment1Ext = 0x8CE1,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT2 = 0x8CE2
    /// </summary>
    ColourAttachment2 = 0x8CE2,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT2_EXT = 0x8CE2
    /// </summary>
    ColourAttachment2Ext = 0x8CE2,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT3 = 0x8CE3
    /// </summary>
    ColourAttachment3 = 0x8CE3,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT3_EXT = 0x8CE3
    /// </summary>
    ColourAttachment3Ext = 0x8CE3,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT4 = 0x8CE4
    /// </summary>
    ColourAttachment4 = 0x8CE4,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT4_EXT = 0x8CE4
    /// </summary>
    ColourAttachment4Ext = 0x8CE4,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT5 = 0x8CE5
    /// </summary>
    ColourAttachment5 = 0x8CE5,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT5_EXT = 0x8CE5
    /// </summary>
    ColourAttachment5Ext = 0x8CE5,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT6 = 0x8CE6
    /// </summary>
    ColourAttachment6 = 0x8CE6,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT6_EXT = 0x8CE6
    /// </summary>
    ColourAttachment6Ext = 0x8CE6,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT7 = 0x8CE7
    /// </summary>
    ColourAttachment7 = 0x8CE7,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT7_EXT = 0x8CE7
    /// </summary>
    ColourAttachment7Ext = 0x8CE7,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT8 = 0x8CE8
    /// </summary>
    ColourAttachment8 = 0x8CE8,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT8_EXT = 0x8CE8
    /// </summary>
    ColourAttachment8Ext = 0x8CE8,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT9 = 0x8CE9
    /// </summary>
    ColourAttachment9 = 0x8CE9,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT9_EXT = 0x8CE9
    /// </summary>
    ColourAttachment9Ext = 0x8CE9,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT10 = 0x8CEA
    /// </summary>
    ColourAttachment10 = 0x8CEA,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT10_EXT = 0x8CEA
    /// </summary>
    ColourAttachment10Ext = 0x8CEA,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT11 = 0x8CEB
    /// </summary>
    ColourAttachment11 = 0x8CEB,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT11_EXT = 0x8CEB
    /// </summary>
    ColourAttachment11Ext = 0x8CEB,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT12 = 0x8CEC
    /// </summary>
    ColourAttachment12 = 0x8CEC,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT12_EXT = 0x8CEC
    /// </summary>
    ColourAttachment12Ext = 0x8CEC,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT13 = 0x8CED
    /// </summary>
    ColourAttachment13 = 0x8CED,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT13_EXT = 0x8CED
    /// </summary>
    ColourAttachment13Ext = 0x8CED,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT14 = 0x8CEE
    /// </summary>
    ColourAttachment14 = 0x8CEE,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT14_EXT = 0x8CEE
    /// </summary>
    ColourAttachment14Ext = 0x8CEE,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT15 = 0x8CEF
    /// </summary>
    ColourAttachment15 = 0x8CEF,
    /// <summary>
    /// Original was GL_COLOR_ATTACHMENT15_EXT = 0x8CEF
    /// </summary>
    ColourAttachment15Ext = 0x8CEF,
    /// <summary>
    /// Original was GL_DEPTH_ATTACHMENT = 0x8D00
    /// </summary>
    DepthAttachment = 0x8D00,
    /// <summary>
    /// Original was GL_DEPTH_ATTACHMENT_EXT = 0x8D00
    /// </summary>
    DepthAttachmentExt = 0x8D00,
    /// <summary>
    /// Original was GL_STENCIL_ATTACHMENT = 0x8D20
    /// </summary>
    StencilAttachment = 0x8D20,
    /// <summary>
    /// Original was GL_STENCIL_ATTACHMENT_EXT = 0x8D20
    /// </summary>
    StencilAttachmentExt = 0x8D20
}

public enum FRAMEBUFFER_TARGET : int
{
    /// <summary>
    /// Original was GL_READ_FRAMEBUFFER = 0x8CA8
    /// </summary>
    ReadFramebuffer = 0x8CA8,
    /// <summary>
    /// Original was GL_DRAW_FRAMEBUFFER = 0x8CA9
    /// </summary>
    DrawFramebuffer = 0x8CA9,
    /// <summary>
    /// Original was GL_FRAMEBUFFER = 0x8D40
    /// </summary>
    Framebuffer = 0x8D40,
    /// <summary>
    /// Original was GL_FRAMEBUFFER_EXT = 0x8D40
    /// </summary>
    FramebufferExt = 0x8D40,
}

public enum FRONTFACEMODE : int
{
    /// <summary>
    /// Original was GL_CW = 0x0900
    /// </summary>
    Cw = 0x0900,
    /// <summary>
    /// Original was GL_CCW = 0x0901
    /// </summary>
    Ccw = 0x0901,
}

public enum GLGET : int
{
    /// <summary>
    /// Original was GL_CURRENT_COLOR = 0x0B00
    /// </summary>
    CurrentColor = 0x0B00,
    /// <summary>
    /// Original was GL_CURRENT_INDEX = 0x0B01
    /// </summary>
    CurrentIndex = 0x0B01,
    /// <summary>
    /// Original was GL_CURRENT_NORMAL = 0x0B02
    /// </summary>
    CurrentNormal = 0x0B02,
    /// <summary>
    /// Original was GL_CURRENT_TEXTURE_COORDS = 0x0B03
    /// </summary>
    CurrentTextureCoords = 0x0B03,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_COLOR = 0x0B04
    /// </summary>
    CurrentRasterColor = 0x0B04,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_INDEX = 0x0B05
    /// </summary>
    CurrentRasterIndex = 0x0B05,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06
    /// </summary>
    CurrentRasterTextureCoords = 0x0B06,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_POSITION = 0x0B07
    /// </summary>
    CurrentRasterPosition = 0x0B07,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_POSITION_VALID = 0x0B08
    /// </summary>
    CurrentRasterPositionValid = 0x0B08,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_DISTANCE = 0x0B09
    /// </summary>
    CurrentRasterDistance = 0x0B09,
    /// <summary>
    /// Original was GL_POINT_SMOOTH = 0x0B10
    /// </summary>
    PointSmooth = 0x0B10,
    /// <summary>
    /// Original was GL_POINT_SIZE = 0x0B11
    /// </summary>
    PointSize = 0x0B11,
    /// <summary>
    /// Original was GL_POINT_SIZE_RANGE = 0x0B12
    /// </summary>
    PointSizeRange = 0x0B12,
    /// <summary>
    /// Original was GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12
    /// </summary>
    SmoothPointSizeRange = 0x0B12,
    /// <summary>
    /// Original was GL_POINT_SIZE_GRANULARITY = 0x0B13
    /// </summary>
    PointSizeGranularity = 0x0B13,
    /// <summary>
    /// Original was GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13
    /// </summary>
    SmoothPointSizeGranularity = 0x0B13,
    /// <summary>
    /// Original was GL_LINE_SMOOTH = 0x0B20
    /// </summary>
    LineSmooth = 0x0B20,
    /// <summary>
    /// Original was GL_LINE_WIDTH = 0x0B21
    /// </summary>
    LineWidth = 0x0B21,
    /// <summary>
    /// Original was GL_LINE_WIDTH_RANGE = 0x0B22
    /// </summary>
    LineWidthRange = 0x0B22,
    /// <summary>
    /// Original was GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22
    /// </summary>
    SmoothLineWidthRange = 0x0B22,
    /// <summary>
    /// Original was GL_LINE_WIDTH_GRANULARITY = 0x0B23
    /// </summary>
    LineWidthGranularity = 0x0B23,
    /// <summary>
    /// Original was GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23
    /// </summary>
    SmoothLineWidthGranularity = 0x0B23,
    /// <summary>
    /// Original was GL_LINE_STIPPLE = 0x0B24
    /// </summary>
    LineStipple = 0x0B24,
    /// <summary>
    /// Original was GL_LINE_STIPPLE_PATTERN = 0x0B25
    /// </summary>
    LineStipplePattern = 0x0B25,
    /// <summary>
    /// Original was GL_LINE_STIPPLE_REPEAT = 0x0B26
    /// </summary>
    LineStippleRepeat = 0x0B26,
    /// <summary>
    /// Original was GL_LIST_MODE = 0x0B30
    /// </summary>
    ListMode = 0x0B30,
    /// <summary>
    /// Original was GL_MAX_LIST_NESTING = 0x0B31
    /// </summary>
    MaxListNesting = 0x0B31,
    /// <summary>
    /// Original was GL_LIST_BASE = 0x0B32
    /// </summary>
    ListBase = 0x0B32,
    /// <summary>
    /// Original was GL_LIST_INDEX = 0x0B33
    /// </summary>
    ListIndex = 0x0B33,
    /// <summary>
    /// Original was GL_POLYGON_MODE = 0x0B40
    /// </summary>
    PolygonMode = 0x0B40,
    /// <summary>
    /// Original was GL_POLYGON_SMOOTH = 0x0B41
    /// </summary>
    PolygonSmooth = 0x0B41,
    /// <summary>
    /// Original was GL_POLYGON_STIPPLE = 0x0B42
    /// </summary>
    PolygonStipple = 0x0B42,
    /// <summary>
    /// Original was GL_EDGE_FLAG = 0x0B43
    /// </summary>
    EdgeFlag = 0x0B43,
    /// <summary>
    /// Original was GL_CULL_FACE = 0x0B44
    /// </summary>
    CullFace = 0x0B44,
    /// <summary>
    /// Original was GL_CULL_FACE_MODE = 0x0B45
    /// </summary>
    CullFaceMode = 0x0B45,
    /// <summary>
    /// Original was GL_FRONT_FACE = 0x0B46
    /// </summary>
    FrontFace = 0x0B46,
    /// <summary>
    /// Original was GL_LIGHTING = 0x0B50
    /// </summary>
    Lighting = 0x0B50,
    /// <summary>
    /// Original was GL_LIGHT_MODEL_LOCAL_VIEWER = 0x0B51
    /// </summary>
    LightModelLocalViewer = 0x0B51,
    /// <summary>
    /// Original was GL_LIGHT_MODEL_TWO_SIDE = 0x0B52
    /// </summary>
    LightModelTwoSide = 0x0B52,
    /// <summary>
    /// Original was GL_LIGHT_MODEL_AMBIENT = 0x0B53
    /// </summary>
    LightModelAmbient = 0x0B53,
    /// <summary>
    /// Original was GL_SHADE_MODEL = 0x0B54
    /// </summary>
    ShadeModel = 0x0B54,
    /// <summary>
    /// Original was GL_COLOR_MATERIAL_FACE = 0x0B55
    /// </summary>
    ColorMaterialFace = 0x0B55,
    /// <summary>
    /// Original was GL_COLOR_MATERIAL_PARAMETER = 0x0B56
    /// </summary>
    ColorMaterialParameter = 0x0B56,
    /// <summary>
    /// Original was GL_COLOR_MATERIAL = 0x0B57
    /// </summary>
    ColorMaterial = 0x0B57,
    /// <summary>
    /// Original was GL_FOG = 0x0B60
    /// </summary>
    Fog = 0x0B60,
    /// <summary>
    /// Original was GL_FOG_INDEX = 0x0B61
    /// </summary>
    FogIndex = 0x0B61,
    /// <summary>
    /// Original was GL_FOG_DENSITY = 0x0B62
    /// </summary>
    FogDensity = 0x0B62,
    /// <summary>
    /// Original was GL_FOG_START = 0x0B63
    /// </summary>
    FogStart = 0x0B63,
    /// <summary>
    /// Original was GL_FOG_END = 0x0B64
    /// </summary>
    FogEnd = 0x0B64,
    /// <summary>
    /// Original was GL_FOG_MODE = 0x0B65
    /// </summary>
    FogMode = 0x0B65,
    /// <summary>
    /// Original was GL_FOG_COLOR = 0x0B66
    /// </summary>
    FogColor = 0x0B66,
    /// <summary>
    /// Original was GL_DEPTH_RANGE = 0x0B70
    /// </summary>
    DepthRange = 0x0B70,
    /// <summary>
    /// Original was GL_DEPTH_TEST = 0x0B71
    /// </summary>
    DepthTest = 0x0B71,
    /// <summary>
    /// Original was GL_DEPTH_WRITEMASK = 0x0B72
    /// </summary>
    DepthWritemask = 0x0B72,
    /// <summary>
    /// Original was GL_DEPTH_CLEAR_VALUE = 0x0B73
    /// </summary>
    DepthClearValue = 0x0B73,
    /// <summary>
    /// Original was GL_DEPTH_FUNC = 0x0B74
    /// </summary>
    DepthFunc = 0x0B74,
    /// <summary>
    /// Original was GL_ACCUM_CLEAR_VALUE = 0x0B80
    /// </summary>
    AccumClearValue = 0x0B80,
    /// <summary>
    /// Original was GL_STENCIL_TEST = 0x0B90
    /// </summary>
    StencilTest = 0x0B90,
    /// <summary>
    /// Original was GL_STENCIL_CLEAR_VALUE = 0x0B91
    /// </summary>
    StencilClearValue = 0x0B91,
    /// <summary>
    /// Original was GL_STENCIL_FUNC = 0x0B92
    /// </summary>
    StencilFunc = 0x0B92,
    /// <summary>
    /// Original was GL_STENCIL_VALUE_MASK = 0x0B93
    /// </summary>
    StencilValueMask = 0x0B93,
    /// <summary>
    /// Original was GL_STENCIL_FAIL = 0x0B94
    /// </summary>
    StencilFail = 0x0B94,
    /// <summary>
    /// Original was GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95
    /// </summary>
    StencilPassDepthFail = 0x0B95,
    /// <summary>
    /// Original was GL_STENCIL_PASS_DEPTH_PASS = 0x0B96
    /// </summary>
    StencilPassDepthPass = 0x0B96,
    /// <summary>
    /// Original was GL_STENCIL_REF = 0x0B97
    /// </summary>
    StencilRef = 0x0B97,
    /// <summary>
    /// Original was GL_STENCIL_WRITEMASK = 0x0B98
    /// </summary>
    StencilWritemask = 0x0B98,
    /// <summary>
    /// Original was GL_MATRIX_MODE = 0x0BA0
    /// </summary>
    MatrixMode = 0x0BA0,
    /// <summary>
    /// Original was GL_NORMALIZE = 0x0BA1
    /// </summary>
    Normalize = 0x0BA1,
    /// <summary>
    /// Original was GL_VIEWPORT = 0x0BA2
    /// </summary>
    Viewport = 0x0BA2,
    /// <summary>
    /// Original was GL_MODELVIEW0_STACK_DEPTH_EXT = 0x0BA3
    /// </summary>
    Modelview0StackDepthExt = 0x0BA3,
    /// <summary>
    /// Original was GL_MODELVIEW_STACK_DEPTH = 0x0BA3
    /// </summary>
    ModelviewStackDepth = 0x0BA3,
    /// <summary>
    /// Original was GL_PROJECTION_STACK_DEPTH = 0x0BA4
    /// </summary>
    ProjectionStackDepth = 0x0BA4,
    /// <summary>
    /// Original was GL_TEXTURE_STACK_DEPTH = 0x0BA5
    /// </summary>
    TextureStackDepth = 0x0BA5,
    /// <summary>
    /// Original was GL_MODELVIEW0_MATRIX_EXT = 0x0BA6
    /// </summary>
    Modelview0MatrixExt = 0x0BA6,
    /// <summary>
    /// Original was GL_MODELVIEW_MATRIX = 0x0BA6
    /// </summary>
    ModelviewMatrix = 0x0BA6,
    /// <summary>
    /// Original was GL_PROJECTION_MATRIX = 0x0BA7
    /// </summary>
    ProjectionMatrix = 0x0BA7,
    /// <summary>
    /// Original was GL_TEXTURE_MATRIX = 0x0BA8
    /// </summary>
    TextureMatrix = 0x0BA8,
    /// <summary>
    /// Original was GL_ATTRIB_STACK_DEPTH = 0x0BB0
    /// </summary>
    AttribStackDepth = 0x0BB0,
    /// <summary>
    /// Original was GL_CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1
    /// </summary>
    ClientAttribStackDepth = 0x0BB1,
    /// <summary>
    /// Original was GL_ALPHA_TEST = 0x0BC0
    /// </summary>
    AlphaTest = 0x0BC0,
    /// <summary>
    /// Original was GL_ALPHA_TEST_QCOM = 0x0BC0
    /// </summary>
    AlphaTestQcom = 0x0BC0,
    /// <summary>
    /// Original was GL_ALPHA_TEST_FUNC = 0x0BC1
    /// </summary>
    AlphaTestFunc = 0x0BC1,
    /// <summary>
    /// Original was GL_ALPHA_TEST_FUNC_QCOM = 0x0BC1
    /// </summary>
    AlphaTestFuncQcom = 0x0BC1,
    /// <summary>
    /// Original was GL_ALPHA_TEST_REF = 0x0BC2
    /// </summary>
    AlphaTestRef = 0x0BC2,
    /// <summary>
    /// Original was GL_ALPHA_TEST_REF_QCOM = 0x0BC2
    /// </summary>
    AlphaTestRefQcom = 0x0BC2,
    /// <summary>
    /// Original was GL_DITHER = 0x0BD0
    /// </summary>
    Dither = 0x0BD0,
    /// <summary>
    /// Original was GL_BLEND_DST = 0x0BE0
    /// </summary>
    BlendDst = 0x0BE0,
    /// <summary>
    /// Original was GL_BLEND_SRC = 0x0BE1
    /// </summary>
    BlendSrc = 0x0BE1,
    /// <summary>
    /// Original was GL_BLEND = 0x0BE2
    /// </summary>
    Blend = 0x0BE2,
    /// <summary>
    /// Original was GL_LOGIC_OP_MODE = 0x0BF0
    /// </summary>
    LogicOpMode = 0x0BF0,
    /// <summary>
    /// Original was GL_INDEX_LOGIC_OP = 0x0BF1
    /// </summary>
    IndexLogicOp = 0x0BF1,
    /// <summary>
    /// Original was GL_LOGIC_OP = 0x0BF1
    /// </summary>
    LogicOp = 0x0BF1,
    /// <summary>
    /// Original was GL_COLOR_LOGIC_OP = 0x0BF2
    /// </summary>
    ColorLogicOp = 0x0BF2,
    /// <summary>
    /// Original was GL_AUX_BUFFERS = 0x0C00
    /// </summary>
    AuxBuffers = 0x0C00,
    /// <summary>
    /// Original was GL_DRAW_BUFFER = 0x0C01
    /// </summary>
    DrawBuffer = 0x0C01,
    /// <summary>
    /// Original was GL_DRAW_BUFFER_EXT = 0x0C01
    /// </summary>
    DrawBufferExt = 0x0C01,
    /// <summary>
    /// Original was GL_READ_BUFFER = 0x0C02
    /// </summary>
    ReadBuffer = 0x0C02,
    /// <summary>
    /// Original was GL_READ_BUFFER_EXT = 0x0C02
    /// </summary>
    ReadBufferExt = 0x0C02,
    /// <summary>
    /// Original was GL_READ_BUFFER_NV = 0x0C02
    /// </summary>
    ReadBufferNv = 0x0C02,
    /// <summary>
    /// Original was GL_SCISSOR_BOX = 0x0C10
    /// </summary>
    ScissorBox = 0x0C10,
    /// <summary>
    /// Original was GL_SCISSOR_TEST = 0x0C11
    /// </summary>
    ScissorTest = 0x0C11,
    /// <summary>
    /// Original was GL_INDEX_CLEAR_VALUE = 0x0C20
    /// </summary>
    IndexClearValue = 0x0C20,
    /// <summary>
    /// Original was GL_INDEX_WRITEMASK = 0x0C21
    /// </summary>
    IndexWritemask = 0x0C21,
    /// <summary>
    /// Original was GL_COLOR_CLEAR_VALUE = 0x0C22
    /// </summary>
    ColorClearValue = 0x0C22,
    /// <summary>
    /// Original was GL_COLOR_WRITEMASK = 0x0C23
    /// </summary>
    ColorWritemask = 0x0C23,
    /// <summary>
    /// Original was GL_INDEX_MODE = 0x0C30
    /// </summary>
    IndexMode = 0x0C30,
    /// <summary>
    /// Original was GL_RGBA_MODE = 0x0C31
    /// </summary>
    RgbaMode = 0x0C31,
    /// <summary>
    /// Original was GL_DOUBLEBUFFER = 0x0C32
    /// </summary>
    Doublebuffer = 0x0C32,
    /// <summary>
    /// Original was GL_STEREO = 0x0C33
    /// </summary>
    Stereo = 0x0C33,
    /// <summary>
    /// Original was GL_RENDER_MODE = 0x0C40
    /// </summary>
    RenderMode = 0x0C40,
    /// <summary>
    /// Original was GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50
    /// </summary>
    PerspectiveCorrectionHint = 0x0C50,
    /// <summary>
    /// Original was GL_POINT_SMOOTH_HINT = 0x0C51
    /// </summary>
    PointSmoothHint = 0x0C51,
    /// <summary>
    /// Original was GL_LINE_SMOOTH_HINT = 0x0C52
    /// </summary>
    LineSmoothHint = 0x0C52,
    /// <summary>
    /// Original was GL_POLYGON_SMOOTH_HINT = 0x0C53
    /// </summary>
    PolygonSmoothHint = 0x0C53,
    /// <summary>
    /// Original was GL_FOG_HINT = 0x0C54
    /// </summary>
    FogHint = 0x0C54,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_S = 0x0C60
    /// </summary>
    TextureGenS = 0x0C60,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_T = 0x0C61
    /// </summary>
    TextureGenT = 0x0C61,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_R = 0x0C62
    /// </summary>
    TextureGenR = 0x0C62,
    /// <summary>
    /// Original was GL_TEXTURE_GEN_Q = 0x0C63
    /// </summary>
    TextureGenQ = 0x0C63,
    /// <summary>
    /// Original was GL_PIXEL_MAP_I_TO_I_SIZE = 0x0CB0
    /// </summary>
    PixelMapIToISize = 0x0CB0,
    /// <summary>
    /// Original was GL_PIXEL_MAP_S_TO_S_SIZE = 0x0CB1
    /// </summary>
    PixelMapSToSSize = 0x0CB1,
    /// <summary>
    /// Original was GL_PIXEL_MAP_I_TO_R_SIZE = 0x0CB2
    /// </summary>
    PixelMapIToRSize = 0x0CB2,
    /// <summary>
    /// Original was GL_PIXEL_MAP_I_TO_G_SIZE = 0x0CB3
    /// </summary>
    PixelMapIToGSize = 0x0CB3,
    /// <summary>
    /// Original was GL_PIXEL_MAP_I_TO_B_SIZE = 0x0CB4
    /// </summary>
    PixelMapIToBSize = 0x0CB4,
    /// <summary>
    /// Original was GL_PIXEL_MAP_I_TO_A_SIZE = 0x0CB5
    /// </summary>
    PixelMapIToASize = 0x0CB5,
    /// <summary>
    /// Original was GL_PIXEL_MAP_R_TO_R_SIZE = 0x0CB6
    /// </summary>
    PixelMapRToRSize = 0x0CB6,
    /// <summary>
    /// Original was GL_PIXEL_MAP_G_TO_G_SIZE = 0x0CB7
    /// </summary>
    PixelMapGToGSize = 0x0CB7,
    /// <summary>
    /// Original was GL_PIXEL_MAP_B_TO_B_SIZE = 0x0CB8
    /// </summary>
    PixelMapBToBSize = 0x0CB8,
    /// <summary>
    /// Original was GL_PIXEL_MAP_A_TO_A_SIZE = 0x0CB9
    /// </summary>
    PixelMapAToASize = 0x0CB9,
    /// <summary>
    /// Original was GL_UNPACK_SWAP_BYTES = 0x0CF0
    /// </summary>
    UnpackSwapBytes = 0x0CF0,
    /// <summary>
    /// Original was GL_UNPACK_LSB_FIRST = 0x0CF1
    /// </summary>
    UnpackLsbFirst = 0x0CF1,
    /// <summary>
    /// Original was GL_UNPACK_ROW_LENGTH = 0x0CF2
    /// </summary>
    UnpackRowLength = 0x0CF2,
    /// <summary>
    /// Original was GL_UNPACK_SKIP_ROWS = 0x0CF3
    /// </summary>
    UnpackSkipRows = 0x0CF3,
    /// <summary>
    /// Original was GL_UNPACK_SKIP_PIXELS = 0x0CF4
    /// </summary>
    UnpackSkipPixels = 0x0CF4,
    /// <summary>
    /// Original was GL_UNPACK_ALIGNMENT = 0x0CF5
    /// </summary>
    UnpackAlignment = 0x0CF5,
    /// <summary>
    /// Original was GL_PACK_SWAP_BYTES = 0x0D00
    /// </summary>
    PackSwapBytes = 0x0D00,
    /// <summary>
    /// Original was GL_PACK_LSB_FIRST = 0x0D01
    /// </summary>
    PackLsbFirst = 0x0D01,
    /// <summary>
    /// Original was GL_PACK_ROW_LENGTH = 0x0D02
    /// </summary>
    PackRowLength = 0x0D02,
    /// <summary>
    /// Original was GL_PACK_SKIP_ROWS = 0x0D03
    /// </summary>
    PackSkipRows = 0x0D03,
    /// <summary>
    /// Original was GL_PACK_SKIP_PIXELS = 0x0D04
    /// </summary>
    PackSkipPixels = 0x0D04,
    /// <summary>
    /// Original was GL_PACK_ALIGNMENT = 0x0D05
    /// </summary>
    PackAlignment = 0x0D05,
    /// <summary>
    /// Original was GL_MAP_COLOR = 0x0D10
    /// </summary>
    MapColor = 0x0D10,
    /// <summary>
    /// Original was GL_MAP_STENCIL = 0x0D11
    /// </summary>
    MapStencil = 0x0D11,
    /// <summary>
    /// Original was GL_INDEX_SHIFT = 0x0D12
    /// </summary>
    IndexShift = 0x0D12,
    /// <summary>
    /// Original was GL_INDEX_OFFSET = 0x0D13
    /// </summary>
    IndexOffset = 0x0D13,
    /// <summary>
    /// Original was GL_RED_SCALE = 0x0D14
    /// </summary>
    RedScale = 0x0D14,
    /// <summary>
    /// Original was GL_RED_BIAS = 0x0D15
    /// </summary>
    RedBias = 0x0D15,
    /// <summary>
    /// Original was GL_ZOOM_X = 0x0D16
    /// </summary>
    ZoomX = 0x0D16,
    /// <summary>
    /// Original was GL_ZOOM_Y = 0x0D17
    /// </summary>
    ZoomY = 0x0D17,
    /// <summary>
    /// Original was GL_GREEN_SCALE = 0x0D18
    /// </summary>
    GreenScale = 0x0D18,
    /// <summary>
    /// Original was GL_GREEN_BIAS = 0x0D19
    /// </summary>
    GreenBias = 0x0D19,
    /// <summary>
    /// Original was GL_BLUE_SCALE = 0x0D1A
    /// </summary>
    BlueScale = 0x0D1A,
    /// <summary>
    /// Original was GL_BLUE_BIAS = 0x0D1B
    /// </summary>
    BlueBias = 0x0D1B,
    /// <summary>
    /// Original was GL_ALPHA_SCALE = 0x0D1C
    /// </summary>
    AlphaScale = 0x0D1C,
    /// <summary>
    /// Original was GL_ALPHA_BIAS = 0x0D1D
    /// </summary>
    AlphaBias = 0x0D1D,
    /// <summary>
    /// Original was GL_DEPTH_SCALE = 0x0D1E
    /// </summary>
    DepthScale = 0x0D1E,
    /// <summary>
    /// Original was GL_DEPTH_BIAS = 0x0D1F
    /// </summary>
    DepthBias = 0x0D1F,
    /// <summary>
    /// Original was GL_MAX_EVAL_ORDER = 0x0D30
    /// </summary>
    MaxEvalOrder = 0x0D30,
    /// <summary>
    /// Original was GL_MAX_LIGHTS = 0x0D31
    /// </summary>
    MaxLights = 0x0D31,
    /// <summary>
    /// Original was GL_MAX_CLIP_DISTANCES = 0x0D32
    /// </summary>
    MaxClipDistances = 0x0D32,
    /// <summary>
    /// Original was GL_MAX_CLIP_PLANES = 0x0D32
    /// </summary>
    MaxClipPlanes = 0x0D32,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_SIZE = 0x0D33
    /// </summary>
    MaxTextureSize = 0x0D33,
    /// <summary>
    /// Original was GL_MAX_PIXEL_MAP_TABLE = 0x0D34
    /// </summary>
    MaxPixelMapTable = 0x0D34,
    /// <summary>
    /// Original was GL_MAX_ATTRIB_STACK_DEPTH = 0x0D35
    /// </summary>
    MaxAttribStackDepth = 0x0D35,
    /// <summary>
    /// Original was GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36
    /// </summary>
    MaxModelviewStackDepth = 0x0D36,
    /// <summary>
    /// Original was GL_MAX_NAME_STACK_DEPTH = 0x0D37
    /// </summary>
    MaxNameStackDepth = 0x0D37,
    /// <summary>
    /// Original was GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38
    /// </summary>
    MaxProjectionStackDepth = 0x0D38,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_STACK_DEPTH = 0x0D39
    /// </summary>
    MaxTextureStackDepth = 0x0D39,
    /// <summary>
    /// Original was GL_MAX_VIEWPORT_DIMS = 0x0D3A
    /// </summary>
    MaxViewportDims = 0x0D3A,
    /// <summary>
    /// Original was GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B
    /// </summary>
    MaxClientAttribStackDepth = 0x0D3B,
    /// <summary>
    /// Original was GL_SUBPIXEL_BITS = 0x0D50
    /// </summary>
    SubpixelBits = 0x0D50,
    /// <summary>
    /// Original was GL_INDEX_BITS = 0x0D51
    /// </summary>
    IndexBits = 0x0D51,
    /// <summary>
    /// Original was GL_RED_BITS = 0x0D52
    /// </summary>
    RedBits = 0x0D52,
    /// <summary>
    /// Original was GL_GREEN_BITS = 0x0D53
    /// </summary>
    GreenBits = 0x0D53,
    /// <summary>
    /// Original was GL_BLUE_BITS = 0x0D54
    /// </summary>
    BlueBits = 0x0D54,
    /// <summary>
    /// Original was GL_ALPHA_BITS = 0x0D55
    /// </summary>
    AlphaBits = 0x0D55,
    /// <summary>
    /// Original was GL_DEPTH_BITS = 0x0D56
    /// </summary>
    DepthBits = 0x0D56,
    /// <summary>
    /// Original was GL_STENCIL_BITS = 0x0D57
    /// </summary>
    StencilBits = 0x0D57,
    /// <summary>
    /// Original was GL_ACCUM_RED_BITS = 0x0D58
    /// </summary>
    AccumRedBits = 0x0D58,
    /// <summary>
    /// Original was GL_ACCUM_GREEN_BITS = 0x0D59
    /// </summary>
    AccumGreenBits = 0x0D59,
    /// <summary>
    /// Original was GL_ACCUM_BLUE_BITS = 0x0D5A
    /// </summary>
    AccumBlueBits = 0x0D5A,
    /// <summary>
    /// Original was GL_ACCUM_ALPHA_BITS = 0x0D5B
    /// </summary>
    AccumAlphaBits = 0x0D5B,
    /// <summary>
    /// Original was GL_NAME_STACK_DEPTH = 0x0D70
    /// </summary>
    NameStackDepth = 0x0D70,
    /// <summary>
    /// Original was GL_AUTO_NORMAL = 0x0D80
    /// </summary>
    AutoNormal = 0x0D80,
    /// <summary>
    /// Original was GL_MAP1_COLOR_4 = 0x0D90
    /// </summary>
    Map1Color4 = 0x0D90,
    /// <summary>
    /// Original was GL_MAP1_INDEX = 0x0D91
    /// </summary>
    Map1Index = 0x0D91,
    /// <summary>
    /// Original was GL_MAP1_NORMAL = 0x0D92
    /// </summary>
    Map1Normal = 0x0D92,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_1 = 0x0D93
    /// </summary>
    Map1TextureCoord1 = 0x0D93,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_2 = 0x0D94
    /// </summary>
    Map1TextureCoord2 = 0x0D94,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_3 = 0x0D95
    /// </summary>
    Map1TextureCoord3 = 0x0D95,
    /// <summary>
    /// Original was GL_MAP1_TEXTURE_COORD_4 = 0x0D96
    /// </summary>
    Map1TextureCoord4 = 0x0D96,
    /// <summary>
    /// Original was GL_MAP1_VERTEX_3 = 0x0D97
    /// </summary>
    Map1Vertex3 = 0x0D97,
    /// <summary>
    /// Original was GL_MAP1_VERTEX_4 = 0x0D98
    /// </summary>
    Map1Vertex4 = 0x0D98,
    /// <summary>
    /// Original was GL_MAP2_COLOR_4 = 0x0DB0
    /// </summary>
    Map2Color4 = 0x0DB0,
    /// <summary>
    /// Original was GL_MAP2_INDEX = 0x0DB1
    /// </summary>
    Map2Index = 0x0DB1,
    /// <summary>
    /// Original was GL_MAP2_NORMAL = 0x0DB2
    /// </summary>
    Map2Normal = 0x0DB2,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_1 = 0x0DB3
    /// </summary>
    Map2TextureCoord1 = 0x0DB3,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_2 = 0x0DB4
    /// </summary>
    Map2TextureCoord2 = 0x0DB4,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_3 = 0x0DB5
    /// </summary>
    Map2TextureCoord3 = 0x0DB5,
    /// <summary>
    /// Original was GL_MAP2_TEXTURE_COORD_4 = 0x0DB6
    /// </summary>
    Map2TextureCoord4 = 0x0DB6,
    /// <summary>
    /// Original was GL_MAP2_VERTEX_3 = 0x0DB7
    /// </summary>
    Map2Vertex3 = 0x0DB7,
    /// <summary>
    /// Original was GL_MAP2_VERTEX_4 = 0x0DB8
    /// </summary>
    Map2Vertex4 = 0x0DB8,
    /// <summary>
    /// Original was GL_MAP1_GRID_DOMAIN = 0x0DD0
    /// </summary>
    Map1GridDomain = 0x0DD0,
    /// <summary>
    /// Original was GL_MAP1_GRID_SEGMENTS = 0x0DD1
    /// </summary>
    Map1GridSegments = 0x0DD1,
    /// <summary>
    /// Original was GL_MAP2_GRID_DOMAIN = 0x0DD2
    /// </summary>
    Map2GridDomain = 0x0DD2,
    /// <summary>
    /// Original was GL_MAP2_GRID_SEGMENTS = 0x0DD3
    /// </summary>
    Map2GridSegments = 0x0DD3,
    /// <summary>
    /// Original was GL_TEXTURE_1D = 0x0DE0
    /// </summary>
    Texture1D = 0x0DE0,
    /// <summary>
    /// Original was GL_TEXTURE_2D = 0x0DE1
    /// </summary>
    Texture2D = 0x0DE1,
    /// <summary>
    /// Original was GL_FEEDBACK_BUFFER_SIZE = 0x0DF1
    /// </summary>
    FeedbackBufferSize = 0x0DF1,
    /// <summary>
    /// Original was GL_FEEDBACK_BUFFER_TYPE = 0x0DF2
    /// </summary>
    FeedbackBufferType = 0x0DF2,
    /// <summary>
    /// Original was GL_SELECTION_BUFFER_SIZE = 0x0DF4
    /// </summary>
    SelectionBufferSize = 0x0DF4,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_UNITS = 0x2A00
    /// </summary>
    PolygonOffsetUnits = 0x2A00,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_POINT = 0x2A01
    /// </summary>
    PolygonOffsetPoint = 0x2A01,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_LINE = 0x2A02
    /// </summary>
    PolygonOffsetLine = 0x2A02,
    /// <summary>
    /// Original was GL_CLIP_PLANE0 = 0x3000
    /// </summary>
    ClipPlane0 = 0x3000,
    /// <summary>
    /// Original was GL_CLIP_PLANE1 = 0x3001
    /// </summary>
    ClipPlane1 = 0x3001,
    /// <summary>
    /// Original was GL_CLIP_PLANE2 = 0x3002
    /// </summary>
    ClipPlane2 = 0x3002,
    /// <summary>
    /// Original was GL_CLIP_PLANE3 = 0x3003
    /// </summary>
    ClipPlane3 = 0x3003,
    /// <summary>
    /// Original was GL_CLIP_PLANE4 = 0x3004
    /// </summary>
    ClipPlane4 = 0x3004,
    /// <summary>
    /// Original was GL_CLIP_PLANE5 = 0x3005
    /// </summary>
    ClipPlane5 = 0x3005,
    /// <summary>
    /// Original was GL_LIGHT0 = 0x4000
    /// </summary>
    Light0 = 0x4000,
    /// <summary>
    /// Original was GL_LIGHT1 = 0x4001
    /// </summary>
    Light1 = 0x4001,
    /// <summary>
    /// Original was GL_LIGHT2 = 0x4002
    /// </summary>
    Light2 = 0x4002,
    /// <summary>
    /// Original was GL_LIGHT3 = 0x4003
    /// </summary>
    Light3 = 0x4003,
    /// <summary>
    /// Original was GL_LIGHT4 = 0x4004
    /// </summary>
    Light4 = 0x4004,
    /// <summary>
    /// Original was GL_LIGHT5 = 0x4005
    /// </summary>
    Light5 = 0x4005,
    /// <summary>
    /// Original was GL_LIGHT6 = 0x4006
    /// </summary>
    Light6 = 0x4006,
    /// <summary>
    /// Original was GL_LIGHT7 = 0x4007
    /// </summary>
    Light7 = 0x4007,
    /// <summary>
    /// Original was GL_BLEND_COLOR_EXT = 0x8005
    /// </summary>
    BlendColorExt = 0x8005,
    /// <summary>
    /// Original was GL_BLEND_EQUATION_EXT = 0x8009
    /// </summary>
    BlendEquationExt = 0x8009,
    /// <summary>
    /// Original was GL_BLEND_EQUATION_RGB = 0x8009
    /// </summary>
    BlendEquationRgb = 0x8009,
    /// <summary>
    /// Original was GL_PACK_CMYK_HINT_EXT = 0x800E
    /// </summary>
    PackCmykHintExt = 0x800E,
    /// <summary>
    /// Original was GL_UNPACK_CMYK_HINT_EXT = 0x800F
    /// </summary>
    UnpackCmykHintExt = 0x800F,
    /// <summary>
    /// Original was GL_CONVOLUTION_1D_EXT = 0x8010
    /// </summary>
    Convolution1DExt = 0x8010,
    /// <summary>
    /// Original was GL_CONVOLUTION_2D_EXT = 0x8011
    /// </summary>
    Convolution2DExt = 0x8011,
    /// <summary>
    /// Original was GL_SEPARABLE_2D_EXT = 0x8012
    /// </summary>
    Separable2DExt = 0x8012,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_RED_SCALE_EXT = 0x801C
    /// </summary>
    PostConvolutionRedScaleExt = 0x801C,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_GREEN_SCALE_EXT = 0x801D
    /// </summary>
    PostConvolutionGreenScaleExt = 0x801D,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_BLUE_SCALE_EXT = 0x801E
    /// </summary>
    PostConvolutionBlueScaleExt = 0x801E,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_ALPHA_SCALE_EXT = 0x801F
    /// </summary>
    PostConvolutionAlphaScaleExt = 0x801F,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_RED_BIAS_EXT = 0x8020
    /// </summary>
    PostConvolutionRedBiasExt = 0x8020,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_GREEN_BIAS_EXT = 0x8021
    /// </summary>
    PostConvolutionGreenBiasExt = 0x8021,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_BLUE_BIAS_EXT = 0x8022
    /// </summary>
    PostConvolutionBlueBiasExt = 0x8022,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_ALPHA_BIAS_EXT = 0x8023
    /// </summary>
    PostConvolutionAlphaBiasExt = 0x8023,
    /// <summary>
    /// Original was GL_HISTOGRAM_EXT = 0x8024
    /// </summary>
    HistogramExt = 0x8024,
    /// <summary>
    /// Original was GL_MINMAX_EXT = 0x802E
    /// </summary>
    MinmaxExt = 0x802E,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_FILL = 0x8037
    /// </summary>
    PolygonOffsetFill = 0x8037,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_FACTOR = 0x8038
    /// </summary>
    PolygonOffsetFactor = 0x8038,
    /// <summary>
    /// Original was GL_POLYGON_OFFSET_BIAS_EXT = 0x8039
    /// </summary>
    PolygonOffsetBiasExt = 0x8039,
    /// <summary>
    /// Original was GL_RESCALE_NORMAL_EXT = 0x803A
    /// </summary>
    RescaleNormalExt = 0x803A,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_1D = 0x8068
    /// </summary>
    TextureBinding1D = 0x8068,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_2D = 0x8069
    /// </summary>
    TextureBinding2D = 0x8069,
    /// <summary>
    /// Original was GL_TEXTURE_3D_BINDING_EXT = 0x806A
    /// </summary>
    Texture3DBindingExt = 0x806A,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_3D = 0x806A
    /// </summary>
    TextureBinding3D = 0x806A,
    /// <summary>
    /// Original was GL_PACK_SKIP_IMAGES_EXT = 0x806B
    /// </summary>
    PackSkipImagesExt = 0x806B,
    /// <summary>
    /// Original was GL_PACK_IMAGE_HEIGHT_EXT = 0x806C
    /// </summary>
    PackImageHeightExt = 0x806C,
    /// <summary>
    /// Original was GL_UNPACK_SKIP_IMAGES_EXT = 0x806D
    /// </summary>
    UnpackSkipImagesExt = 0x806D,
    /// <summary>
    /// Original was GL_UNPACK_IMAGE_HEIGHT_EXT = 0x806E
    /// </summary>
    UnpackImageHeightExt = 0x806E,
    /// <summary>
    /// Original was GL_TEXTURE_3D_EXT = 0x806F
    /// </summary>
    Texture3DExt = 0x806F,
    /// <summary>
    /// Original was GL_MAX_3D_TEXTURE_SIZE = 0x8073
    /// </summary>
    Max3DTextureSize = 0x8073,
    /// <summary>
    /// Original was GL_MAX_3D_TEXTURE_SIZE_EXT = 0x8073
    /// </summary>
    Max3DTextureSizeExt = 0x8073,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY = 0x8074
    /// </summary>
    VertexArray = 0x8074,
    /// <summary>
    /// Original was GL_NORMAL_ARRAY = 0x8075
    /// </summary>
    NormalArray = 0x8075,
    /// <summary>
    /// Original was GL_COLOR_ARRAY = 0x8076
    /// </summary>
    ColorArray = 0x8076,
    /// <summary>
    /// Original was GL_INDEX_ARRAY = 0x8077
    /// </summary>
    IndexArray = 0x8077,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY = 0x8078
    /// </summary>
    TextureCoordArray = 0x8078,
    /// <summary>
    /// Original was GL_EDGE_FLAG_ARRAY = 0x8079
    /// </summary>
    EdgeFlagArray = 0x8079,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY_SIZE = 0x807A
    /// </summary>
    VertexArraySize = 0x807A,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY_TYPE = 0x807B
    /// </summary>
    VertexArrayType = 0x807B,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY_STRIDE = 0x807C
    /// </summary>
    VertexArrayStride = 0x807C,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY_COUNT_EXT = 0x807D
    /// </summary>
    VertexArrayCountExt = 0x807D,
    /// <summary>
    /// Original was GL_NORMAL_ARRAY_TYPE = 0x807E
    /// </summary>
    NormalArrayType = 0x807E,
    /// <summary>
    /// Original was GL_NORMAL_ARRAY_STRIDE = 0x807F
    /// </summary>
    NormalArrayStride = 0x807F,
    /// <summary>
    /// Original was GL_NORMAL_ARRAY_COUNT_EXT = 0x8080
    /// </summary>
    NormalArrayCountExt = 0x8080,
    /// <summary>
    /// Original was GL_COLOR_ARRAY_SIZE = 0x8081
    /// </summary>
    ColorArraySize = 0x8081,
    /// <summary>
    /// Original was GL_COLOR_ARRAY_TYPE = 0x8082
    /// </summary>
    ColorArrayType = 0x8082,
    /// <summary>
    /// Original was GL_COLOR_ARRAY_STRIDE = 0x8083
    /// </summary>
    ColorArrayStride = 0x8083,
    /// <summary>
    /// Original was GL_COLOR_ARRAY_COUNT_EXT = 0x8084
    /// </summary>
    ColorArrayCountExt = 0x8084,
    /// <summary>
    /// Original was GL_INDEX_ARRAY_TYPE = 0x8085
    /// </summary>
    IndexArrayType = 0x8085,
    /// <summary>
    /// Original was GL_INDEX_ARRAY_STRIDE = 0x8086
    /// </summary>
    IndexArrayStride = 0x8086,
    /// <summary>
    /// Original was GL_INDEX_ARRAY_COUNT_EXT = 0x8087
    /// </summary>
    IndexArrayCountExt = 0x8087,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088
    /// </summary>
    TextureCoordArraySize = 0x8088,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089
    /// </summary>
    TextureCoordArrayType = 0x8089,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A
    /// </summary>
    TextureCoordArrayStride = 0x808A,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808B
    /// </summary>
    TextureCoordArrayCountExt = 0x808B,
    /// <summary>
    /// Original was GL_EDGE_FLAG_ARRAY_STRIDE = 0x808C
    /// </summary>
    EdgeFlagArrayStride = 0x808C,
    /// <summary>
    /// Original was GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808D
    /// </summary>
    EdgeFlagArrayCountExt = 0x808D,
    /// <summary>
    /// Original was GL_INTERLACE_SGIX = 0x8094
    /// </summary>
    InterlaceSgix = 0x8094,
    /// <summary>
    /// Original was GL_DETAIL_TEXTURE_2D_BINDING_SGIS = 0x8096
    /// </summary>
    DetailTexture2DBindingSgis = 0x8096,
    /// <summary>
    /// Original was GL_MULTISAMPLE = 0x809D
    /// </summary>
    Multisample = 0x809D,
    /// <summary>
    /// Original was GL_MULTISAMPLE_SGIS = 0x809D
    /// </summary>
    MultisampleSgis = 0x809D,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E
    /// </summary>
    SampleAlphaToCoverage = 0x809E,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_MASK_SGIS = 0x809E
    /// </summary>
    SampleAlphaToMaskSgis = 0x809E,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_ONE = 0x809F
    /// </summary>
    SampleAlphaToOne = 0x809F,
    /// <summary>
    /// Original was GL_SAMPLE_ALPHA_TO_ONE_SGIS = 0x809F
    /// </summary>
    SampleAlphaToOneSgis = 0x809F,
    /// <summary>
    /// Original was GL_SAMPLE_COVERAGE = 0x80A0
    /// </summary>
    SampleCoverage = 0x80A0,
    /// <summary>
    /// Original was GL_SAMPLE_MASK_SGIS = 0x80A0
    /// </summary>
    SampleMaskSgis = 0x80A0,
    /// <summary>
    /// Original was GL_SAMPLE_BUFFERS = 0x80A8
    /// </summary>
    SampleBuffers = 0x80A8,
    /// <summary>
    /// Original was GL_SAMPLE_BUFFERS_SGIS = 0x80A8
    /// </summary>
    SampleBuffersSgis = 0x80A8,
    /// <summary>
    /// Original was GL_SAMPLES = 0x80A9
    /// </summary>
    Samples = 0x80A9,
    /// <summary>
    /// Original was GL_SAMPLES_SGIS = 0x80A9
    /// </summary>
    SamplesSgis = 0x80A9,
    /// <summary>
    /// Original was GL_SAMPLE_COVERAGE_VALUE = 0x80AA
    /// </summary>
    SampleCoverageValue = 0x80AA,
    /// <summary>
    /// Original was GL_SAMPLE_MASK_VALUE_SGIS = 0x80AA
    /// </summary>
    SampleMaskValueSgis = 0x80AA,
    /// <summary>
    /// Original was GL_SAMPLE_COVERAGE_INVERT = 0x80AB
    /// </summary>
    SampleCoverageInvert = 0x80AB,
    /// <summary>
    /// Original was GL_SAMPLE_MASK_INVERT_SGIS = 0x80AB
    /// </summary>
    SampleMaskInvertSgis = 0x80AB,
    /// <summary>
    /// Original was GL_SAMPLE_PATTERN_SGIS = 0x80AC
    /// </summary>
    SamplePatternSgis = 0x80AC,
    /// <summary>
    /// Original was GL_COLOR_MATRIX_SGI = 0x80B1
    /// </summary>
    ColorMatrixSgi = 0x80B1,
    /// <summary>
    /// Original was GL_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B2
    /// </summary>
    ColorMatrixStackDepthSgi = 0x80B2,
    /// <summary>
    /// Original was GL_MAX_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B3
    /// </summary>
    MaxColorMatrixStackDepthSgi = 0x80B3,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_RED_SCALE_SGI = 0x80B4
    /// </summary>
    PostColorMatrixRedScaleSgi = 0x80B4,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_GREEN_SCALE_SGI = 0x80B5
    /// </summary>
    PostColorMatrixGreenScaleSgi = 0x80B5,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_BLUE_SCALE_SGI = 0x80B6
    /// </summary>
    PostColorMatrixBlueScaleSgi = 0x80B6,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_ALPHA_SCALE_SGI = 0x80B7
    /// </summary>
    PostColorMatrixAlphaScaleSgi = 0x80B7,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_RED_BIAS_SGI = 0x80B8
    /// </summary>
    PostColorMatrixRedBiasSgi = 0x80B8,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_GREEN_BIAS_SGI = 0x80B9
    /// </summary>
    PostColorMatrixGreenBiasSgi = 0x80B9,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_BLUE_BIAS_SGI = 0x80BA
    /// </summary>
    PostColorMatrixBlueBiasSgi = 0x80BA,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_ALPHA_BIAS_SGI = 0x80BB
    /// </summary>
    PostColorMatrixAlphaBiasSgi = 0x80BB,
    /// <summary>
    /// Original was GL_TEXTURE_COLOR_TABLE_SGI = 0x80BC
    /// </summary>
    TextureColorTableSgi = 0x80BC,
    /// <summary>
    /// Original was GL_BLEND_DST_RGB = 0x80C8
    /// </summary>
    BlendDstRgb = 0x80C8,
    /// <summary>
    /// Original was GL_BLEND_SRC_RGB = 0x80C9
    /// </summary>
    BlendSrcRgb = 0x80C9,
    /// <summary>
    /// Original was GL_BLEND_DST_ALPHA = 0x80CA
    /// </summary>
    BlendDstAlpha = 0x80CA,
    /// <summary>
    /// Original was GL_BLEND_SRC_ALPHA = 0x80CB
    /// </summary>
    BlendSrcAlpha = 0x80CB,
    /// <summary>
    /// Original was GL_COLOR_TABLE_SGI = 0x80D0
    /// </summary>
    ColorTableSgi = 0x80D0,
    /// <summary>
    /// Original was GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1
    /// </summary>
    PostConvolutionColorTableSgi = 0x80D1,
    /// <summary>
    /// Original was GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2
    /// </summary>
    PostColorMatrixColorTableSgi = 0x80D2,
    /// <summary>
    /// Original was GL_MAX_ELEMENTS_VERTICES = 0x80E8
    /// </summary>
    MaxElementsVertices = 0x80E8,
    /// <summary>
    /// Original was GL_MAX_ELEMENTS_INDICES = 0x80E9
    /// </summary>
    MaxElementsIndices = 0x80E9,
    /// <summary>
    /// Original was GL_POINT_SIZE_MIN = 0x8126
    /// </summary>
    PointSizeMin = 0x8126,
    /// <summary>
    /// Original was GL_POINT_SIZE_MIN_SGIS = 0x8126
    /// </summary>
    PointSizeMinSgis = 0x8126,
    /// <summary>
    /// Original was GL_POINT_SIZE_MAX = 0x8127
    /// </summary>
    PointSizeMax = 0x8127,
    /// <summary>
    /// Original was GL_POINT_SIZE_MAX_SGIS = 0x8127
    /// </summary>
    PointSizeMaxSgis = 0x8127,
    /// <summary>
    /// Original was GL_POINT_FADE_THRESHOLD_SIZE = 0x8128
    /// </summary>
    PointFadeThresholdSize = 0x8128,
    /// <summary>
    /// Original was GL_POINT_FADE_THRESHOLD_SIZE_SGIS = 0x8128
    /// </summary>
    PointFadeThresholdSizeSgis = 0x8128,
    /// <summary>
    /// Original was GL_DISTANCE_ATTENUATION_SGIS = 0x8129
    /// </summary>
    DistanceAttenuationSgis = 0x8129,
    /// <summary>
    /// Original was GL_POINT_DISTANCE_ATTENUATION = 0x8129
    /// </summary>
    PointDistanceAttenuation = 0x8129,
    /// <summary>
    /// Original was GL_FOG_FUNC_POINTS_SGIS = 0x812B
    /// </summary>
    FogFuncPointsSgis = 0x812B,
    /// <summary>
    /// Original was GL_MAX_FOG_FUNC_POINTS_SGIS = 0x812C
    /// </summary>
    MaxFogFuncPointsSgis = 0x812C,
    /// <summary>
    /// Original was GL_PACK_SKIP_VOLUMES_SGIS = 0x8130
    /// </summary>
    PackSkipVolumesSgis = 0x8130,
    /// <summary>
    /// Original was GL_PACK_IMAGE_DEPTH_SGIS = 0x8131
    /// </summary>
    PackImageDepthSgis = 0x8131,
    /// <summary>
    /// Original was GL_UNPACK_SKIP_VOLUMES_SGIS = 0x8132
    /// </summary>
    UnpackSkipVolumesSgis = 0x8132,
    /// <summary>
    /// Original was GL_UNPACK_IMAGE_DEPTH_SGIS = 0x8133
    /// </summary>
    UnpackImageDepthSgis = 0x8133,
    /// <summary>
    /// Original was GL_TEXTURE_4D_SGIS = 0x8134
    /// </summary>
    Texture4DSgis = 0x8134,
    /// <summary>
    /// Original was GL_MAX_4D_TEXTURE_SIZE_SGIS = 0x8138
    /// </summary>
    Max4DTextureSizeSgis = 0x8138,
    /// <summary>
    /// Original was GL_PIXEL_TEX_GEN_SGIX = 0x8139
    /// </summary>
    PixelTexGenSgix = 0x8139,
    /// <summary>
    /// Original was GL_PIXEL_TILE_BEST_ALIGNMENT_SGIX = 0x813E
    /// </summary>
    PixelTileBestAlignmentSgix = 0x813E,
    /// <summary>
    /// Original was GL_PIXEL_TILE_CACHE_INCREMENT_SGIX = 0x813F
    /// </summary>
    PixelTileCacheIncrementSgix = 0x813F,
    /// <summary>
    /// Original was GL_PIXEL_TILE_WIDTH_SGIX = 0x8140
    /// </summary>
    PixelTileWidthSgix = 0x8140,
    /// <summary>
    /// Original was GL_PIXEL_TILE_HEIGHT_SGIX = 0x8141
    /// </summary>
    PixelTileHeightSgix = 0x8141,
    /// <summary>
    /// Original was GL_PIXEL_TILE_GRID_WIDTH_SGIX = 0x8142
    /// </summary>
    PixelTileGridWidthSgix = 0x8142,
    /// <summary>
    /// Original was GL_PIXEL_TILE_GRID_HEIGHT_SGIX = 0x8143
    /// </summary>
    PixelTileGridHeightSgix = 0x8143,
    /// <summary>
    /// Original was GL_PIXEL_TILE_GRID_DEPTH_SGIX = 0x8144
    /// </summary>
    PixelTileGridDepthSgix = 0x8144,
    /// <summary>
    /// Original was GL_PIXEL_TILE_CACHE_SIZE_SGIX = 0x8145
    /// </summary>
    PixelTileCacheSizeSgix = 0x8145,
    /// <summary>
    /// Original was GL_SPRITE_SGIX = 0x8148
    /// </summary>
    SpriteSgix = 0x8148,
    /// <summary>
    /// Original was GL_SPRITE_MODE_SGIX = 0x8149
    /// </summary>
    SpriteModeSgix = 0x8149,
    /// <summary>
    /// Original was GL_SPRITE_AXIS_SGIX = 0x814A
    /// </summary>
    SpriteAxisSgix = 0x814A,
    /// <summary>
    /// Original was GL_SPRITE_TRANSLATION_SGIX = 0x814B
    /// </summary>
    SpriteTranslationSgix = 0x814B,
    /// <summary>
    /// Original was GL_TEXTURE_4D_BINDING_SGIS = 0x814F
    /// </summary>
    Texture4DBindingSgis = 0x814F,
    /// <summary>
    /// Original was GL_MAX_CLIPMAP_DEPTH_SGIX = 0x8177
    /// </summary>
    MaxClipmapDepthSgix = 0x8177,
    /// <summary>
    /// Original was GL_MAX_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8178
    /// </summary>
    MaxClipmapVirtualDepthSgix = 0x8178,
    /// <summary>
    /// Original was GL_POST_TEXTURE_FILTER_BIAS_RANGE_SGIX = 0x817B
    /// </summary>
    PostTextureFilterBiasRangeSgix = 0x817B,
    /// <summary>
    /// Original was GL_POST_TEXTURE_FILTER_SCALE_RANGE_SGIX = 0x817C
    /// </summary>
    PostTextureFilterScaleRangeSgix = 0x817C,
    /// <summary>
    /// Original was GL_REFERENCE_PLANE_SGIX = 0x817D
    /// </summary>
    ReferencePlaneSgix = 0x817D,
    /// <summary>
    /// Original was GL_REFERENCE_PLANE_EQUATION_SGIX = 0x817E
    /// </summary>
    ReferencePlaneEquationSgix = 0x817E,
    /// <summary>
    /// Original was GL_IR_INSTRUMENT1_SGIX = 0x817F
    /// </summary>
    IrInstrument1Sgix = 0x817F,
    /// <summary>
    /// Original was GL_INSTRUMENT_MEASUREMENTS_SGIX = 0x8181
    /// </summary>
    InstrumentMeasurementsSgix = 0x8181,
    /// <summary>
    /// Original was GL_CALLIGRAPHIC_FRAGMENT_SGIX = 0x8183
    /// </summary>
    CalligraphicFragmentSgix = 0x8183,
    /// <summary>
    /// Original was GL_FRAMEZOOM_SGIX = 0x818B
    /// </summary>
    FramezoomSgix = 0x818B,
    /// <summary>
    /// Original was GL_FRAMEZOOM_FACTOR_SGIX = 0x818C
    /// </summary>
    FramezoomFactorSgix = 0x818C,
    /// <summary>
    /// Original was GL_MAX_FRAMEZOOM_FACTOR_SGIX = 0x818D
    /// </summary>
    MaxFramezoomFactorSgix = 0x818D,
    /// <summary>
    /// Original was GL_GENERATE_MIPMAP_HINT = 0x8192
    /// </summary>
    GenerateMipmapHint = 0x8192,
    /// <summary>
    /// Original was GL_GENERATE_MIPMAP_HINT_SGIS = 0x8192
    /// </summary>
    GenerateMipmapHintSgis = 0x8192,
    /// <summary>
    /// Original was GL_DEFORMATIONS_MASK_SGIX = 0x8196
    /// </summary>
    DeformationsMaskSgix = 0x8196,
    /// <summary>
    /// Original was GL_FOG_OFFSET_SGIX = 0x8198
    /// </summary>
    FogOffsetSgix = 0x8198,
    /// <summary>
    /// Original was GL_FOG_OFFSET_VALUE_SGIX = 0x8199
    /// </summary>
    FogOffsetValueSgix = 0x8199,
    /// <summary>
    /// Original was GL_LIGHT_MODEL_COLOR_CONTROL = 0x81F8
    /// </summary>
    LightModelColorControl = 0x81F8,
    /// <summary>
    /// Original was GL_SHARED_TEXTURE_PALETTE_EXT = 0x81FB
    /// </summary>
    SharedTexturePaletteExt = 0x81FB,
    /// <summary>
    /// Original was GL_MAJOR_VERSION = 0x821B
    /// </summary>
    MajorVersion = 0x821B,
    /// <summary>
    /// Original was GL_MINOR_VERSION = 0x821C
    /// </summary>
    MinorVersion = 0x821C,
    /// <summary>
    /// Original was GL_NUM_EXTENSIONS = 0x821D
    /// </summary>
    NumExtensions = 0x821D,
    /// <summary>
    /// Original was GL_CONTEXT_FLAGS = 0x821E
    /// </summary>
    ContextFlags = 0x821E,
    /// <summary>
    /// Original was GL_PROGRAM_PIPELINE_BINDING = 0x825A
    /// </summary>
    ProgramPipelineBinding = 0x825A,
    /// <summary>
    /// Original was GL_MAX_VIEWPORTS = 0x825B
    /// </summary>
    MaxViewports = 0x825B,
    /// <summary>
    /// Original was GL_VIEWPORT_SUBPIXEL_BITS = 0x825C
    /// </summary>
    ViewportSubpixelBits = 0x825C,
    /// <summary>
    /// Original was GL_VIEWPORT_BOUNDS_RANGE = 0x825D
    /// </summary>
    ViewportBoundsRange = 0x825D,
    /// <summary>
    /// Original was GL_LAYER_PROVOKING_VERTEX = 0x825E
    /// </summary>
    LayerProvokingVertex = 0x825E,
    /// <summary>
    /// Original was GL_VIEWPORT_INDEX_PROVOKING_VERTEX = 0x825F
    /// </summary>
    ViewportIndexProvokingVertex = 0x825F,
    /// <summary>
    /// Original was GL_CONVOLUTION_HINT_SGIX = 0x8316
    /// </summary>
    ConvolutionHintSgix = 0x8316,
    /// <summary>
    /// Original was GL_ASYNC_MARKER_SGIX = 0x8329
    /// </summary>
    AsyncMarkerSgix = 0x8329,
    /// <summary>
    /// Original was GL_PIXEL_TEX_GEN_MODE_SGIX = 0x832B
    /// </summary>
    PixelTexGenModeSgix = 0x832B,
    /// <summary>
    /// Original was GL_ASYNC_HISTOGRAM_SGIX = 0x832C
    /// </summary>
    AsyncHistogramSgix = 0x832C,
    /// <summary>
    /// Original was GL_MAX_ASYNC_HISTOGRAM_SGIX = 0x832D
    /// </summary>
    MaxAsyncHistogramSgix = 0x832D,
    /// <summary>
    /// Original was GL_PIXEL_TEXTURE_SGIS = 0x8353
    /// </summary>
    PixelTextureSgis = 0x8353,
    /// <summary>
    /// Original was GL_ASYNC_TEX_IMAGE_SGIX = 0x835C
    /// </summary>
    AsyncTexImageSgix = 0x835C,
    /// <summary>
    /// Original was GL_ASYNC_DRAW_PIXELS_SGIX = 0x835D
    /// </summary>
    AsyncDrawPixelsSgix = 0x835D,
    /// <summary>
    /// Original was GL_ASYNC_READ_PIXELS_SGIX = 0x835E
    /// </summary>
    AsyncReadPixelsSgix = 0x835E,
    /// <summary>
    /// Original was GL_MAX_ASYNC_TEX_IMAGE_SGIX = 0x835F
    /// </summary>
    MaxAsyncTexImageSgix = 0x835F,
    /// <summary>
    /// Original was GL_MAX_ASYNC_DRAW_PIXELS_SGIX = 0x8360
    /// </summary>
    MaxAsyncDrawPixelsSgix = 0x8360,
    /// <summary>
    /// Original was GL_MAX_ASYNC_READ_PIXELS_SGIX = 0x8361
    /// </summary>
    MaxAsyncReadPixelsSgix = 0x8361,
    /// <summary>
    /// Original was GL_VERTEX_PRECLIP_SGIX = 0x83EE
    /// </summary>
    VertexPreclipSgix = 0x83EE,
    /// <summary>
    /// Original was GL_VERTEX_PRECLIP_HINT_SGIX = 0x83EF
    /// </summary>
    VertexPreclipHintSgix = 0x83EF,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHTING_SGIX = 0x8400
    /// </summary>
    FragmentLightingSgix = 0x8400,
    /// <summary>
    /// Original was GL_FRAGMENT_COLOR_MATERIAL_SGIX = 0x8401
    /// </summary>
    FragmentColorMaterialSgix = 0x8401,
    /// <summary>
    /// Original was GL_FRAGMENT_COLOR_MATERIAL_FACE_SGIX = 0x8402
    /// </summary>
    FragmentColorMaterialFaceSgix = 0x8402,
    /// <summary>
    /// Original was GL_FRAGMENT_COLOR_MATERIAL_PARAMETER_SGIX = 0x8403
    /// </summary>
    FragmentColorMaterialParameterSgix = 0x8403,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_LIGHTS_SGIX = 0x8404
    /// </summary>
    MaxFragmentLightsSgix = 0x8404,
    /// <summary>
    /// Original was GL_MAX_ACTIVE_LIGHTS_SGIX = 0x8405
    /// </summary>
    MaxActiveLightsSgix = 0x8405,
    /// <summary>
    /// Original was GL_LIGHT_ENV_MODE_SGIX = 0x8407
    /// </summary>
    LightEnvModeSgix = 0x8407,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT_MODEL_LOCAL_VIEWER_SGIX = 0x8408
    /// </summary>
    FragmentLightModelLocalViewerSgix = 0x8408,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT_MODEL_TWO_SIDE_SGIX = 0x8409
    /// </summary>
    FragmentLightModelTwoSideSgix = 0x8409,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT_MODEL_AMBIENT_SGIX = 0x840A
    /// </summary>
    FragmentLightModelAmbientSgix = 0x840A,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT_MODEL_NORMAL_INTERPOLATION_SGIX = 0x840B
    /// </summary>
    FragmentLightModelNormalInterpolationSgix = 0x840B,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT0_SGIX = 0x840C
    /// </summary>
    FragmentLight0Sgix = 0x840C,
    /// <summary>
    /// Original was GL_PACK_RESAMPLE_SGIX = 0x842C
    /// </summary>
    PackResampleSgix = 0x842C,
    /// <summary>
    /// Original was GL_UNPACK_RESAMPLE_SGIX = 0x842D
    /// </summary>
    UnpackResampleSgix = 0x842D,
    /// <summary>
    /// Original was GL_CURRENT_FOG_COORD = 0x8453
    /// </summary>
    CurrentFogCoord = 0x8453,
    /// <summary>
    /// Original was GL_FOG_COORD_ARRAY_TYPE = 0x8454
    /// </summary>
    FogCoordArrayType = 0x8454,
    /// <summary>
    /// Original was GL_FOG_COORD_ARRAY_STRIDE = 0x8455
    /// </summary>
    FogCoordArrayStride = 0x8455,
    /// <summary>
    /// Original was GL_COLOR_SUM = 0x8458
    /// </summary>
    ColorSum = 0x8458,
    /// <summary>
    /// Original was GL_CURRENT_SECONDARY_COLOR = 0x8459
    /// </summary>
    CurrentSecondaryColor = 0x8459,
    /// <summary>
    /// Original was GL_SECONDARY_COLOR_ARRAY_SIZE = 0x845A
    /// </summary>
    SecondaryColorArraySize = 0x845A,
    /// <summary>
    /// Original was GL_SECONDARY_COLOR_ARRAY_TYPE = 0x845B
    /// </summary>
    SecondaryColorArrayType = 0x845B,
    /// <summary>
    /// Original was GL_SECONDARY_COLOR_ARRAY_STRIDE = 0x845C
    /// </summary>
    SecondaryColorArrayStride = 0x845C,
    /// <summary>
    /// Original was GL_CURRENT_RASTER_SECONDARY_COLOR = 0x845F
    /// </summary>
    CurrentRasterSecondaryColor = 0x845F,
    /// <summary>
    /// Original was GL_ALIASED_POINT_SIZE_RANGE = 0x846D
    /// </summary>
    AliasedPointSizeRange = 0x846D,
    /// <summary>
    /// Original was GL_ALIASED_LINE_WIDTH_RANGE = 0x846E
    /// </summary>
    AliasedLineWidthRange = 0x846E,
    /// <summary>
    /// Original was GL_ACTIVE_TEXTURE = 0x84E0
    /// </summary>
    ActiveTexture = 0x84E0,
    /// <summary>
    /// Original was GL_CLIENT_ACTIVE_TEXTURE = 0x84E1
    /// </summary>
    ClientActiveTexture = 0x84E1,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_UNITS = 0x84E2
    /// </summary>
    MaxTextureUnits = 0x84E2,
    /// <summary>
    /// Original was GL_TRANSPOSE_MODELVIEW_MATRIX = 0x84E3
    /// </summary>
    TransposeModelviewMatrix = 0x84E3,
    /// <summary>
    /// Original was GL_TRANSPOSE_PROJECTION_MATRIX = 0x84E4
    /// </summary>
    TransposeProjectionMatrix = 0x84E4,
    /// <summary>
    /// Original was GL_TRANSPOSE_TEXTURE_MATRIX = 0x84E5
    /// </summary>
    TransposeTextureMatrix = 0x84E5,
    /// <summary>
    /// Original was GL_TRANSPOSE_COLOR_MATRIX = 0x84E6
    /// </summary>
    TransposeColorMatrix = 0x84E6,
    /// <summary>
    /// Original was GL_MAX_RENDERBUFFER_SIZE = 0x84E8
    /// </summary>
    MaxRenderbufferSize = 0x84E8,
    /// <summary>
    /// Original was GL_MAX_RENDERBUFFER_SIZE_EXT = 0x84E8
    /// </summary>
    MaxRenderbufferSizeExt = 0x84E8,
    /// <summary>
    /// Original was GL_TEXTURE_COMPRESSION_HINT = 0x84EF
    /// </summary>
    TextureCompressionHint = 0x84EF,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_RECTANGLE = 0x84F6
    /// </summary>
    TextureBindingRectangle = 0x84F6,
    /// <summary>
    /// Original was GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8
    /// </summary>
    MaxRectangleTextureSize = 0x84F8,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_LOD_BIAS = 0x84FD
    /// </summary>
    MaxTextureLodBias = 0x84FD,
    /// <summary>
    /// Original was GL_TEXTURE_CUBE_MAP = 0x8513
    /// </summary>
    TextureCubeMap = 0x8513,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_CUBE_MAP = 0x8514
    /// </summary>
    TextureBindingCubeMap = 0x8514,
    /// <summary>
    /// Original was GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C
    /// </summary>
    MaxCubeMapTextureSize = 0x851C,
    /// <summary>
    /// Original was GL_PACK_SUBSAMPLE_RATE_SGIX = 0x85A0
    /// </summary>
    PackSubsampleRateSgix = 0x85A0,
    /// <summary>
    /// Original was GL_UNPACK_SUBSAMPLE_RATE_SGIX = 0x85A1
    /// </summary>
    UnpackSubsampleRateSgix = 0x85A1,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY_BINDING = 0x85B5
    /// </summary>
    VertexArrayBinding = 0x85B5,
    /// <summary>
    /// Original was GL_PROGRAM_POINT_SIZE = 0x8642
    /// </summary>
    ProgramPointSize = 0x8642,
    /// <summary>
    /// Original was GL_DEPTH_CLAMP = 0x864F
    /// </summary>
    DepthClamp = 0x864F,
    /// <summary>
    /// Original was GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2
    /// </summary>
    NumCompressedTextureFormats = 0x86A2,
    /// <summary>
    /// Original was GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3
    /// </summary>
    CompressedTextureFormats = 0x86A3,
    /// <summary>
    /// Original was GL_NUM_PROGRAM_BINARY_FORMATS = 0x87FE
    /// </summary>
    NumProgramBinaryFormats = 0x87FE,
    /// <summary>
    /// Original was GL_PROGRAM_BINARY_FORMATS = 0x87FF
    /// </summary>
    ProgramBinaryFormats = 0x87FF,
    /// <summary>
    /// Original was GL_STENCIL_BACK_FUNC = 0x8800
    /// </summary>
    StencilBackFunc = 0x8800,
    /// <summary>
    /// Original was GL_STENCIL_BACK_FAIL = 0x8801
    /// </summary>
    StencilBackFail = 0x8801,
    /// <summary>
    /// Original was GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802
    /// </summary>
    StencilBackPassDepthFail = 0x8802,
    /// <summary>
    /// Original was GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803
    /// </summary>
    StencilBackPassDepthPass = 0x8803,
    /// <summary>
    /// Original was GL_RGBA_FLOAT_MODE = 0x8820
    /// </summary>
    RgbaFloatMode = 0x8820,
    /// <summary>
    /// Original was GL_MAX_DRAW_BUFFERS = 0x8824
    /// </summary>
    MaxDrawBuffers = 0x8824,
    /// <summary>
    /// Original was GL_DRAW_BUFFER0 = 0x8825
    /// </summary>
    DrawBuffer0 = 0x8825,
    /// <summary>
    /// Original was GL_DRAW_BUFFER1 = 0x8826
    /// </summary>
    DrawBuffer1 = 0x8826,
    /// <summary>
    /// Original was GL_DRAW_BUFFER2 = 0x8827
    /// </summary>
    DrawBuffer2 = 0x8827,
    /// <summary>
    /// Original was GL_DRAW_BUFFER3 = 0x8828
    /// </summary>
    DrawBuffer3 = 0x8828,
    /// <summary>
    /// Original was GL_DRAW_BUFFER4 = 0x8829
    /// </summary>
    DrawBuffer4 = 0x8829,
    /// <summary>
    /// Original was GL_DRAW_BUFFER5 = 0x882A
    /// </summary>
    DrawBuffer5 = 0x882A,
    /// <summary>
    /// Original was GL_DRAW_BUFFER6 = 0x882B
    /// </summary>
    DrawBuffer6 = 0x882B,
    /// <summary>
    /// Original was GL_DRAW_BUFFER7 = 0x882C
    /// </summary>
    DrawBuffer7 = 0x882C,
    /// <summary>
    /// Original was GL_DRAW_BUFFER8 = 0x882D
    /// </summary>
    DrawBuffer8 = 0x882D,
    /// <summary>
    /// Original was GL_DRAW_BUFFER9 = 0x882E
    /// </summary>
    DrawBuffer9 = 0x882E,
    /// <summary>
    /// Original was GL_DRAW_BUFFER10 = 0x882F
    /// </summary>
    DrawBuffer10 = 0x882F,
    /// <summary>
    /// Original was GL_DRAW_BUFFER11 = 0x8830
    /// </summary>
    DrawBuffer11 = 0x8830,
    /// <summary>
    /// Original was GL_DRAW_BUFFER12 = 0x8831
    /// </summary>
    DrawBuffer12 = 0x8831,
    /// <summary>
    /// Original was GL_DRAW_BUFFER13 = 0x8832
    /// </summary>
    DrawBuffer13 = 0x8832,
    /// <summary>
    /// Original was GL_DRAW_BUFFER14 = 0x8833
    /// </summary>
    DrawBuffer14 = 0x8833,
    /// <summary>
    /// Original was GL_DRAW_BUFFER15 = 0x8834
    /// </summary>
    DrawBuffer15 = 0x8834,
    /// <summary>
    /// Original was GL_BLEND_EQUATION_ALPHA = 0x883D
    /// </summary>
    BlendEquationAlpha = 0x883D,
    /// <summary>
    /// Original was GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F
    /// </summary>
    TextureCubeMapSeamless = 0x884F,
    /// <summary>
    /// Original was GL_POINT_SPRITE = 0x8861
    /// </summary>
    PointSprite = 0x8861,
    /// <summary>
    /// Original was GL_MAX_VERTEX_ATTRIBS = 0x8869
    /// </summary>
    MaxVertexAttribs = 0x8869,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_INPUT_COMPONENTS = 0x886C
    /// </summary>
    MaxTessControlInputComponents = 0x886C,
    /// <summary>
    /// Original was GL_MAX_TESS_EVALUATION_INPUT_COMPONENTS = 0x886D
    /// </summary>
    MaxTessEvaluationInputComponents = 0x886D,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_COORDS = 0x8871
    /// </summary>
    MaxTextureCoords = 0x8871,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872
    /// </summary>
    MaxTextureImageUnits = 0x8872,
    /// <summary>
    /// Original was GL_ARRAY_BUFFER_BINDING = 0x8894
    /// </summary>
    ArrayBufferBinding = 0x8894,
    /// <summary>
    /// Original was GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895
    /// </summary>
    ElementArrayBufferBinding = 0x8895,
    /// <summary>
    /// Original was GL_VERTEX_ARRAY_BUFFER_BINDING = 0x8896
    /// </summary>
    VertexArrayBufferBinding = 0x8896,
    /// <summary>
    /// Original was GL_NORMAL_ARRAY_BUFFER_BINDING = 0x8897
    /// </summary>
    NormalArrayBufferBinding = 0x8897,
    /// <summary>
    /// Original was GL_COLOR_ARRAY_BUFFER_BINDING = 0x8898
    /// </summary>
    ColorArrayBufferBinding = 0x8898,
    /// <summary>
    /// Original was GL_INDEX_ARRAY_BUFFER_BINDING = 0x8899
    /// </summary>
    IndexArrayBufferBinding = 0x8899,
    /// <summary>
    /// Original was GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING = 0x889A
    /// </summary>
    TextureCoordArrayBufferBinding = 0x889A,
    /// <summary>
    /// Original was GL_EDGE_FLAG_ARRAY_BUFFER_BINDING = 0x889B
    /// </summary>
    EdgeFlagArrayBufferBinding = 0x889B,
    /// <summary>
    /// Original was GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING = 0x889C
    /// </summary>
    SecondaryColorArrayBufferBinding = 0x889C,
    /// <summary>
    /// Original was GL_FOG_COORD_ARRAY_BUFFER_BINDING = 0x889D
    /// </summary>
    FogCoordArrayBufferBinding = 0x889D,
    /// <summary>
    /// Original was GL_WEIGHT_ARRAY_BUFFER_BINDING = 0x889E
    /// </summary>
    WeightArrayBufferBinding = 0x889E,
    /// <summary>
    /// Original was GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F
    /// </summary>
    VertexAttribArrayBufferBinding = 0x889F,
    /// <summary>
    /// Original was GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED
    /// </summary>
    PixelPackBufferBinding = 0x88ED,
    /// <summary>
    /// Original was GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF
    /// </summary>
    PixelUnpackBufferBinding = 0x88EF,
    /// <summary>
    /// Original was GL_MAX_DUAL_SOURCE_DRAW_BUFFERS = 0x88FC
    /// </summary>
    MaxDualSourceDrawBuffers = 0x88FC,
    /// <summary>
    /// Original was GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF
    /// </summary>
    MaxArrayTextureLayers = 0x88FF,
    /// <summary>
    /// Original was GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904
    /// </summary>
    MinProgramTexelOffset = 0x8904,
    /// <summary>
    /// Original was GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905
    /// </summary>
    MaxProgramTexelOffset = 0x8905,
    /// <summary>
    /// Original was GL_SAMPLER_BINDING = 0x8919
    /// </summary>
    SamplerBinding = 0x8919,
    /// <summary>
    /// Original was GL_CLAMP_VERTEX_COLOR = 0x891A
    /// </summary>
    ClampVertexColor = 0x891A,
    /// <summary>
    /// Original was GL_CLAMP_FRAGMENT_COLOR = 0x891B
    /// </summary>
    ClampFragmentColor = 0x891B,
    /// <summary>
    /// Original was GL_CLAMP_READ_COLOR = 0x891C
    /// </summary>
    ClampReadColor = 0x891C,
    /// <summary>
    /// Original was GL_MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B
    /// </summary>
    MaxVertexUniformBlocks = 0x8A2B,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C
    /// </summary>
    MaxGeometryUniformBlocks = 0x8A2C,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D
    /// </summary>
    MaxFragmentUniformBlocks = 0x8A2D,
    /// <summary>
    /// Original was GL_MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E
    /// </summary>
    MaxCombinedUniformBlocks = 0x8A2E,
    /// <summary>
    /// Original was GL_MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F
    /// </summary>
    MaxUniformBufferBindings = 0x8A2F,
    /// <summary>
    /// Original was GL_MAX_UNIFORM_BLOCK_SIZE = 0x8A30
    /// </summary>
    MaxUniformBlockSize = 0x8A30,
    /// <summary>
    /// Original was GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31
    /// </summary>
    MaxCombinedVertexUniformComponents = 0x8A31,
    /// <summary>
    /// Original was GL_MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32
    /// </summary>
    MaxCombinedGeometryUniformComponents = 0x8A32,
    /// <summary>
    /// Original was GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33
    /// </summary>
    MaxCombinedFragmentUniformComponents = 0x8A33,
    /// <summary>
    /// Original was GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34
    /// </summary>
    UniformBufferOffsetAlignment = 0x8A34,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49
    /// </summary>
    MaxFragmentUniformComponents = 0x8B49,
    /// <summary>
    /// Original was GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A
    /// </summary>
    MaxVertexUniformComponents = 0x8B4A,
    /// <summary>
    /// Original was GL_MAX_VARYING_COMPONENTS = 0x8B4B
    /// </summary>
    MaxVaryingComponents = 0x8B4B,
    /// <summary>
    /// Original was GL_MAX_VARYING_FLOATS = 0x8B4B
    /// </summary>
    MaxVaryingFloats = 0x8B4B,
    /// <summary>
    /// Original was GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C
    /// </summary>
    MaxVertexTextureImageUnits = 0x8B4C,
    /// <summary>
    /// Original was GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D
    /// </summary>
    MaxCombinedTextureImageUnits = 0x8B4D,
    /// <summary>
    /// Original was GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B
    /// </summary>
    FragmentShaderDerivativeHint = 0x8B8B,
    /// <summary>
    /// Original was GL_CURRENT_PROGRAM = 0x8B8D
    /// </summary>
    CurrentProgram = 0x8B8D,
    /// <summary>
    /// Original was GL_IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A
    /// </summary>
    ImplementationColorReadType = 0x8B9A,
    /// <summary>
    /// Original was GL_IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B
    /// </summary>
    ImplementationColorReadFormat = 0x8B9B,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C
    /// </summary>
    TextureBinding1DArray = 0x8C1C,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D
    /// </summary>
    TextureBinding2DArray = 0x8C1D,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29
    /// </summary>
    MaxGeometryTextureImageUnits = 0x8C29,
    /// <summary>
    /// Original was GL_TEXTURE_BUFFER = 0x8C2A
    /// </summary>
    TextureBuffer = 0x8C2A,
    /// <summary>
    /// Original was GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B
    /// </summary>
    MaxTextureBufferSize = 0x8C2B,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_BUFFER = 0x8C2C
    /// </summary>
    TextureBindingBuffer = 0x8C2C,
    /// <summary>
    /// Original was GL_TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D
    /// </summary>
    TextureBufferDataStoreBinding = 0x8C2D,
    /// <summary>
    /// Original was GL_SAMPLE_SHADING = 0x8C36
    /// </summary>
    SampleShading = 0x8C36,
    /// <summary>
    /// Original was GL_MIN_SAMPLE_SHADING_VALUE = 0x8C37
    /// </summary>
    MinSampleShadingValue = 0x8C37,
    /// <summary>
    /// Original was GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80
    /// </summary>
    MaxTransformFeedbackSeparateComponents = 0x8C80,
    /// <summary>
    /// Original was GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A
    /// </summary>
    MaxTransformFeedbackInterleavedComponents = 0x8C8A,
    /// <summary>
    /// Original was GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B
    /// </summary>
    MaxTransformFeedbackSeparateAttribs = 0x8C8B,
    /// <summary>
    /// Original was GL_STENCIL_BACK_REF = 0x8CA3
    /// </summary>
    StencilBackRef = 0x8CA3,
    /// <summary>
    /// Original was GL_STENCIL_BACK_VALUE_MASK = 0x8CA4
    /// </summary>
    StencilBackValueMask = 0x8CA4,
    /// <summary>
    /// Original was GL_STENCIL_BACK_WRITEMASK = 0x8CA5
    /// </summary>
    StencilBackWritemask = 0x8CA5,
    /// <summary>
    /// Original was GL_DRAW_FRAMEBUFFER_BINDING = 0x8CA6
    /// </summary>
    DrawFramebufferBinding = 0x8CA6,
    /// <summary>
    /// Original was GL_FRAMEBUFFER_BINDING = 0x8CA6
    /// </summary>
    FramebufferBinding = 0x8CA6,
    /// <summary>
    /// Original was GL_FRAMEBUFFER_BINDING_EXT = 0x8CA6
    /// </summary>
    FramebufferBindingExt = 0x8CA6,
    /// <summary>
    /// Original was GL_RENDERBUFFER_BINDING = 0x8CA7
    /// </summary>
    RenderbufferBinding = 0x8CA7,
    /// <summary>
    /// Original was GL_RENDERBUFFER_BINDING_EXT = 0x8CA7
    /// </summary>
    RenderbufferBindingExt = 0x8CA7,
    /// <summary>
    /// Original was GL_READ_FRAMEBUFFER_BINDING = 0x8CAA
    /// </summary>
    ReadFramebufferBinding = 0x8CAA,
    /// <summary>
    /// Original was GL_MAX_COLOR_ATTACHMENTS = 0x8CDF
    /// </summary>
    MaxColorAttachments = 0x8CDF,
    /// <summary>
    /// Original was GL_MAX_COLOR_ATTACHMENTS_EXT = 0x8CDF
    /// </summary>
    MaxColorAttachmentsExt = 0x8CDF,
    /// <summary>
    /// Original was GL_MAX_SAMPLES = 0x8D57
    /// </summary>
    MaxSamples = 0x8D57,
    /// <summary>
    /// Original was GL_FRAMEBUFFER_SRGB = 0x8DB9
    /// </summary>
    FramebufferSrgb = 0x8DB9,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_VARYING_COMPONENTS = 0x8DDD
    /// </summary>
    MaxGeometryVaryingComponents = 0x8DDD,
    /// <summary>
    /// Original was GL_MAX_VERTEX_VARYING_COMPONENTS = 0x8DDE
    /// </summary>
    MaxVertexVaryingComponents = 0x8DDE,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF
    /// </summary>
    MaxGeometryUniformComponents = 0x8DDF,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0
    /// </summary>
    MaxGeometryOutputVertices = 0x8DE0,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1
    /// </summary>
    MaxGeometryTotalOutputComponents = 0x8DE1,
    /// <summary>
    /// Original was GL_MAX_SUBROUTINES = 0x8DE7
    /// </summary>
    MaxSubroutines = 0x8DE7,
    /// <summary>
    /// Original was GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS = 0x8DE8
    /// </summary>
    MaxSubroutineUniformLocations = 0x8DE8,
    /// <summary>
    /// Original was GL_SHADER_BINARY_FORMATS = 0x8DF8
    /// </summary>
    ShaderBinaryFormats = 0x8DF8,
    /// <summary>
    /// Original was GL_NUM_SHADER_BINARY_FORMATS = 0x8DF9
    /// </summary>
    NumShaderBinaryFormats = 0x8DF9,
    /// <summary>
    /// Original was GL_SHADER_COMPILER = 0x8DFA
    /// </summary>
    ShaderCompiler = 0x8DFA,
    /// <summary>
    /// Original was GL_MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB
    /// </summary>
    MaxVertexUniformVectors = 0x8DFB,
    /// <summary>
    /// Original was GL_MAX_VARYING_VECTORS = 0x8DFC
    /// </summary>
    MaxVaryingVectors = 0x8DFC,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD
    /// </summary>
    MaxFragmentUniformVectors = 0x8DFD,
    /// <summary>
    /// Original was GL_MAX_COMBINED_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E1E
    /// </summary>
    MaxCombinedTessControlUniformComponents = 0x8E1E,
    /// <summary>
    /// Original was GL_MAX_COMBINED_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E1F
    /// </summary>
    MaxCombinedTessEvaluationUniformComponents = 0x8E1F,
    /// <summary>
    /// Original was GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED = 0x8E23
    /// </summary>
    TransformFeedbackBufferPaused = 0x8E23,
    /// <summary>
    /// Original was GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE = 0x8E24
    /// </summary>
    TransformFeedbackBufferActive = 0x8E24,
    /// <summary>
    /// Original was GL_TRANSFORM_FEEDBACK_BINDING = 0x8E25
    /// </summary>
    TransformFeedbackBinding = 0x8E25,
    /// <summary>
    /// Original was GL_TIMESTAMP = 0x8E28
    /// </summary>
    Timestamp = 0x8E28,
    /// <summary>
    /// Original was GL_QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = 0x8E4C
    /// </summary>
    QuadsFollowProvokingVertexConvention = 0x8E4C,
    /// <summary>
    /// Original was GL_PROVOKING_VERTEX = 0x8E4F
    /// </summary>
    ProvokingVertex = 0x8E4F,
    /// <summary>
    /// Original was GL_SAMPLE_MASK = 0x8E51
    /// </summary>
    SampleMask = 0x8E51,
    /// <summary>
    /// Original was GL_MAX_SAMPLE_MASK_WORDS = 0x8E59
    /// </summary>
    MaxSampleMaskWords = 0x8E59,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_SHADER_INVOCATIONS = 0x8E5A
    /// </summary>
    MaxGeometryShaderInvocations = 0x8E5A,
    /// <summary>
    /// Original was GL_MIN_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5B
    /// </summary>
    MinFragmentInterpolationOffset = 0x8E5B,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5C
    /// </summary>
    MaxFragmentInterpolationOffset = 0x8E5C,
    /// <summary>
    /// Original was GL_FRAGMENT_INTERPOLATION_OFFSET_BITS = 0x8E5D
    /// </summary>
    FragmentInterpolationOffsetBits = 0x8E5D,
    /// <summary>
    /// Original was GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5E
    /// </summary>
    MinProgramTextureGatherOffset = 0x8E5E,
    /// <summary>
    /// Original was GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5F
    /// </summary>
    MaxProgramTextureGatherOffset = 0x8E5F,
    /// <summary>
    /// Original was GL_MAX_TRANSFORM_FEEDBACK_BUFFERS = 0x8E70
    /// </summary>
    MaxTransformFeedbackBuffers = 0x8E70,
    /// <summary>
    /// Original was GL_MAX_VERTEX_STREAMS = 0x8E71
    /// </summary>
    MaxVertexStreams = 0x8E71,
    /// <summary>
    /// Original was GL_PATCH_VERTICES = 0x8E72
    /// </summary>
    PatchVertices = 0x8E72,
    /// <summary>
    /// Original was GL_PATCH_DEFAULT_INNER_LEVEL = 0x8E73
    /// </summary>
    PatchDefaultInnerLevel = 0x8E73,
    /// <summary>
    /// Original was GL_PATCH_DEFAULT_OUTER_LEVEL = 0x8E74
    /// </summary>
    PatchDefaultOuterLevel = 0x8E74,
    /// <summary>
    /// Original was GL_MAX_PATCH_VERTICES = 0x8E7D
    /// </summary>
    MaxPatchVertices = 0x8E7D,
    /// <summary>
    /// Original was GL_MAX_TESS_GEN_LEVEL = 0x8E7E
    /// </summary>
    MaxTessGenLevel = 0x8E7E,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E7F
    /// </summary>
    MaxTessControlUniformComponents = 0x8E7F,
    /// <summary>
    /// Original was GL_MAX_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E80
    /// </summary>
    MaxTessEvaluationUniformComponents = 0x8E80,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_TEXTURE_IMAGE_UNITS = 0x8E81
    /// </summary>
    MaxTessControlTextureImageUnits = 0x8E81,
    /// <summary>
    /// Original was GL_MAX_TESS_EVALUATION_TEXTURE_IMAGE_UNITS = 0x8E82
    /// </summary>
    MaxTessEvaluationTextureImageUnits = 0x8E82,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_OUTPUT_COMPONENTS = 0x8E83
    /// </summary>
    MaxTessControlOutputComponents = 0x8E83,
    /// <summary>
    /// Original was GL_MAX_TESS_PATCH_COMPONENTS = 0x8E84
    /// </summary>
    MaxTessPatchComponents = 0x8E84,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_TOTAL_OUTPUT_COMPONENTS = 0x8E85
    /// </summary>
    MaxTessControlTotalOutputComponents = 0x8E85,
    /// <summary>
    /// Original was GL_MAX_TESS_EVALUATION_OUTPUT_COMPONENTS = 0x8E86
    /// </summary>
    MaxTessEvaluationOutputComponents = 0x8E86,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_UNIFORM_BLOCKS = 0x8E89
    /// </summary>
    MaxTessControlUniformBlocks = 0x8E89,
    /// <summary>
    /// Original was GL_MAX_TESS_EVALUATION_UNIFORM_BLOCKS = 0x8E8A
    /// </summary>
    MaxTessEvaluationUniformBlocks = 0x8E8A,
    /// <summary>
    /// Original was GL_DRAW_INDIRECT_BUFFER_BINDING = 0x8F43
    /// </summary>
    DrawIndirectBufferBinding = 0x8F43,
    /// <summary>
    /// Original was GL_MAX_VERTEX_IMAGE_UNIFORMS = 0x90CA
    /// </summary>
    MaxVertexImageUniforms = 0x90CA,
    /// <summary>
    /// Original was GL_MAX_TESS_CONTROL_IMAGE_UNIFORMS = 0x90CB
    /// </summary>
    MaxTessControlImageUniforms = 0x90CB,
    /// <summary>
    /// Original was GL_MAX_TESS_EVALUATION_IMAGE_UNIFORMS = 0x90CC
    /// </summary>
    MaxTessEvaluationImageUniforms = 0x90CC,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_IMAGE_UNIFORMS = 0x90CD
    /// </summary>
    MaxGeometryImageUniforms = 0x90CD,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_IMAGE_UNIFORMS = 0x90CE
    /// </summary>
    MaxFragmentImageUniforms = 0x90CE,
    /// <summary>
    /// Original was GL_MAX_COMBINED_IMAGE_UNIFORMS = 0x90CF
    /// </summary>
    MaxCombinedImageUniforms = 0x90CF,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_2D_MULTISAMPLE = 0x9104
    /// </summary>
    TextureBinding2DMultisample = 0x9104,
    /// <summary>
    /// Original was GL_TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = 0x9105
    /// </summary>
    TextureBinding2DMultisampleArray = 0x9105,
    /// <summary>
    /// Original was GL_MAX_COLOR_TEXTURE_SAMPLES = 0x910E
    /// </summary>
    MaxColorTextureSamples = 0x910E,
    /// <summary>
    /// Original was GL_MAX_DEPTH_TEXTURE_SAMPLES = 0x910F
    /// </summary>
    MaxDepthTextureSamples = 0x910F,
    /// <summary>
    /// Original was GL_MAX_INTEGER_SAMPLES = 0x9110
    /// </summary>
    MaxIntegerSamples = 0x9110,
    /// <summary>
    /// Original was GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122
    /// </summary>
    MaxVertexOutputComponents = 0x9122,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123
    /// </summary>
    MaxGeometryInputComponents = 0x9123,
    /// <summary>
    /// Original was GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124
    /// </summary>
    MaxGeometryOutputComponents = 0x9124,
    /// <summary>
    /// Original was GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125
    /// </summary>
    MaxFragmentInputComponents = 0x9125,
    /// <summary>
    /// Original was GL_MAX_COMPUTE_IMAGE_UNIFORMS = 0x91BD
    /// </summary>
    MaxComputeImageUniforms = 0x91BD,
}

public enum LightName : int
{
    /// <summary>
    /// Original was GL_LIGHT0 = 0x4000
    /// </summary>
    Light0 = 0x4000,
    /// <summary>
    /// Original was GL_LIGHT1 = 0x4001
    /// </summary>
    Light1 = 0x4001,
    /// <summary>
    /// Original was GL_LIGHT2 = 0x4002
    /// </summary>
    Light2 = 0x4002,
    /// <summary>
    /// Original was GL_LIGHT3 = 0x4003
    /// </summary>
    Light3 = 0x4003,
    /// <summary>
    /// Original was GL_LIGHT4 = 0x4004
    /// </summary>
    Light4 = 0x4004,
    /// <summary>
    /// Original was GL_LIGHT5 = 0x4005
    /// </summary>
    Light5 = 0x4005,
    /// <summary>
    /// Original was GL_LIGHT6 = 0x4006
    /// </summary>
    Light6 = 0x4006,
    /// <summary>
    /// Original was GL_LIGHT7 = 0x4007
    /// </summary>
    Light7 = 0x4007,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT0_SGIX = 0x840C
    /// </summary>
    FragmentLight0Sgix = 0x840C,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT1_SGIX = 0x840D
    /// </summary>
    FragmentLight1Sgix = 0x840D,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT2_SGIX = 0x840E
    /// </summary>
    FragmentLight2Sgix = 0x840E,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT3_SGIX = 0x840F
    /// </summary>
    FragmentLight3Sgix = 0x840F,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT4_SGIX = 0x8410
    /// </summary>
    FragmentLight4Sgix = 0x8410,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT5_SGIX = 0x8411
    /// </summary>
    FragmentLight5Sgix = 0x8411,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT6_SGIX = 0x8412
    /// </summary>
    FragmentLight6Sgix = 0x8412,
    /// <summary>
    /// Original was GL_FRAGMENT_LIGHT7_SGIX = 0x8413
    /// </summary>
    FragmentLight7Sgix = 0x8413,
}

public enum LightParameter : int
{
    /// <summary>
    /// Original was GL_AMBIENT = 0x1200
    /// </summary>
    Ambient = 0x1200,
    /// <summary>
    /// Original was GL_DIFFUSE = 0x1201
    /// </summary>
    Diffuse = 0x1201,
    /// <summary>
    /// Original was GL_SPECULAR = 0x1202
    /// </summary>
    Specular = 0x1202,
    /// <summary>
    /// Original was GL_POSITION = 0x1203
    /// </summary>
    Position = 0x1203,
    /// <summary>
    /// Original was GL_SPOT_DIRECTION = 0x1204
    /// </summary>
    SpotDirection = 0x1204,
    /// <summary>
    /// Original was GL_SPOT_EXPONENT = 0x1205
    /// </summary>
    SpotExponent = 0x1205,
    /// <summary>
    /// Original was GL_SPOT_CUTOFF = 0x1206
    /// </summary>
    SpotCutoff = 0x1206,
    /// <summary>
    /// Original was GL_CONSTANT_ATTENUATION = 0x1207
    /// </summary>
    ConstantAttenuation = 0x1207,
    /// <summary>
    /// Original was GL_LINEAR_ATTENUATION = 0x1208
    /// </summary>
    LinearAttenuation = 0x1208,
    /// <summary>
    /// Original was GL_QUADRATIC_ATTENUATION = 0x1209
    /// </summary>
    QuadraticAttenuation = 0x1209,
}

public enum MaterialParameter : int
{
    /// <summary>
    /// Original was GL_AMBIENT = 0x1200
    /// </summary>
    Ambient = 0x1200,
    /// <summary>
    /// Original was GL_DIFFUSE = 0x1201
    /// </summary>
    Diffuse = 0x1201,
    /// <summary>
    /// Original was GL_SPECULAR = 0x1202
    /// </summary>
    Specular = 0x1202,
    /// <summary>
    /// Original was GL_EMISSION = 0x1600
    /// </summary>
    Emission = 0x1600,
    /// <summary>
    /// Original was GL_SHININESS = 0x1601
    /// </summary>
    Shininess = 0x1601,
    /// <summary>
    /// Original was GL_AMBIENT_AND_DIFFUSE = 0x1602
    /// </summary>
    AmbientAndDiffuse = 0x1602,
    /// <summary>
    /// Original was GL_COLOR_INDEXES = 0x1603
    /// </summary>
    ColorIndexes = 0x1603,
}

public enum MatrixMode : int
{
    /// <summary>
    /// Original was MODELVIEW = 0x1700
    /// </summary>
    ModelView = 0x1700,
    /// <summary>
    /// Original was PROJECTION = 0x1701
    /// </summary>
    Projection = 0x1701,
    /// <summary>
    /// Original was TEXTURE = 0x1702
    /// </summary>
    Texture = 0x1702,
}

public enum MSAA_Samples
{
    Disabled = 0,
    x2 = 2,
    x4 = 4,
    x8 = 8,
    x16 = 16
}

public enum OpenGLErrorCode : uint
{
    NO_ERROR = 0,
    INVALID_ENUM = 1280,
    INVALID_VALUE = 1281,
    INVALID_OPERATION = 1282,
    STACK_OVERFLOW = 1283,
    STACK_UNDERFLOW = 1284,
    OUT_OF_MEMORY = 1285,
    INVALID_FRAMEBUFFER_OPERATION = 1286,
    CONTEXT_LOST = 1287,
    TABLE_TOO_LARGE = 32817
}

public enum TEXTURE_FORMAT : int
{
    GL_DEPTH_COMPONENT = 0x1902,

    GL_ALPHA = 0x1906,

    GL_RGB = 0x1907,

    GL_RGBA = 0x1908,

    GL_LUMINANCE = 0x1909,

    GL_LUMINANCE_ALPHA = 0x190A,

    GL_R3_G3_B2 = 0x2A10,

    GL_ALPHA4 = 0x803B,

    GL_ALPHA8 = 0x803C,

    GL_ALPHA12 = 0x803D,

    GL_ALPHA16 = 0x803E,

    GL_LUMINANCE4 = 0x803F,

    GL_LUMINANCE8 = 0x8040,

    GL_LUMINANCE12 = 0x8041,

    GL_LUMINANCE16 = 0x8042,

    GL_LUMINANCE4_ALPHA4 = 0x8043,

    GL_LUMINANCE6_ALPHA2 = 0x8044,

    GL_LUMINANCE8_ALPHA8 = 0x8045,

    GL_LUMINANCE12_ALPHA4 = 0x8046,

    GL_LUMINANCE12_ALPHA12 = 0x8047,

    GL_LUMINANCE16_ALPHA16 = 0x8048,

    GL_INTENSITY = 0x8049,

    GL_INTENSITY4 = 0x804A,

    GL_INTENSITY8 = 0x804B,

    GL_INTENSITY12 = 0x804C,

    GL_INTENSITY16 = 0x804D,

    GL_RGB2_EXT = 0x804E,

    GL_RGB4 = 0x804F,

    GL_RGB5 = 0x8050,

    GL_RGB8 = 0x8051,

    GL_RGB10 = 0x8052,

    GL_RGB12 = 0x8053,

    GL_RGB16 = 0x8054,

    GL_RGBA2 = 0x8055,

    GL_RGBA4 = 0x8056,

    GL_RGB5_A1 = 0x8057,

    GL_RGBA8 = 0x8058,

    GL_RGB10_A2 = 0x8059,

    GL_RGBA12 = 0x805A,

    GL_RGBA16 = 0x805B,

    GL_DUAL_ALPHA4_SGIS = 0x8110,

    GL_DUAL_ALPHA8_SGIS = 0x8111,

    GL_DUAL_ALPHA12_SGIS = 0x8112,

    GL_DUAL_ALPHA16_SGIS = 0x8113,

    GL_DUAL_LUMINANCE4_SGIS = 0x8114,

    GL_DUAL_LUMINANCE8_SGIS = 0x8115,

    GL_DUAL_LUMINANCE12_SGIS = 0x8116,

    GL_DUAL_LUMINANCE16_SGIS = 0x8117,

    GL_DUAL_INTENSITY4_SGIS = 0x8118,

    GL_DUAL_INTENSITY8_SGIS = 0x8119,

    GL_DUAL_INTENSITY12_SGIS = 0x811A,

    GL_DUAL_INTENSITY16_SGIS = 0x811B,

    GL_DUAL_LUMINANCE_ALPHA4_SGIS = 0x811C,

    GL_DUAL_LUMINANCE_ALPHA8_SGIS = 0x811D,

    GL_QUAD_ALPHA4_SGIS = 0x811E,

    GL_QUAD_ALPHA8_SGIS = 0x811F,

    GL_QUAD_LUMINANCE4_SGIS = 0x8120,

    GL_QUAD_LUMINANCE8_SGIS = 0x8121,

    GL_QUAD_INTENSITY4_SGIS = 0x8122,

    GL_QUAD_INTENSITY8_SGIS = 0x8123,

    GL_DEPTH_COMPONENT16 = 0x81a5,

    GL_DEPTH_COMPONENT16_SGIX = 0x81A5,

    GL_DEPTH_COMPONENT24 = 0x81a6,

    GL_DEPTH_COMPONENT24_SGIX = 0x81A6,

    GL_DEPTH_COMPONENT32 = 0x81a7,

    GL_DEPTH_COMPONENT32_SGIX = 0x81A7,

    GL_COMPRESSED_RED = 0x8225,

    GL_COMPRESSED_RG = 0x8226,

    GL_R8 = 0x8229,

    GL_R16 = 0x822A,

    GL_RG8 = 0x822B,

    GL_RG16 = 0x822C,

    GL_R16F = 0x822D,

    GL_R32F = 0x822E,

    GL_RG16F = 0x822F,

    GL_RG32F = 0x8230,

    GL_R8I = 0x8231,

    GL_R8UI = 0x8232,

    GL_R16I = 0x8233,

    GL_R16UI = 0x8234,

    GL_R32I = 0x8235,

    GL_R32UI = 0x8236,

    GL_RG8I = 0x8237,

    GL_RG8UI = 0x8238,

    GL_RG16I = 0x8239,

    GL_RG16UI = 0x823A,

    GL_RG32I = 0x823B,

    GL_RG32UI = 0x823C,

    GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0,

    GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1,

    GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2,

    GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3,

    GL_RGB_ICC_SGIX = 0x8460,

    GL_RGBA_ICC_SGIX = 0x8461,

    GL_ALPHA_ICC_SGIX = 0x8462,

    GL_LUMINANCE_ICC_SGIX = 0x8463,

    GL_INTENSITY_ICC_SGIX = 0x8464,

    GL_LUMINANCE_ALPHA_ICC_SGIX = 0x8465,

    GL_R5_G6_B5_ICC_SGIX = 0x8466,

    GL_R5_G6_B5_A8_ICC_SGIX = 0x8467,

    GL_ALPHA16_ICC_SGIX = 0x8468,

    GL_LUMINANCE16_ICC_SGIX = 0x8469,

    GL_INTENSITY16_ICC_SGIX = 0x846A,

    GL_LUMINANCE16_ALPHA8_ICC_SGIX = 0x846B,

    GL_COMPRESSED_ALPHA = 0x84E9,

    GL_COMPRESSED_LUMINANCE = 0x84EA,

    GL_COMPRESSED_LUMINANCE_ALPHA = 0x84EB,

    GL_COMPRESSED_INTENSITY = 0x84EC,

    GL_COMPRESSED_RGB = 0x84ED,

    GL_COMPRESSED_RGBA = 0x84EE,

    GL_DEPTH_STENCIL = 0x84F9,

    GL_RGBA32F = 0x8814,

    GL_RGB32F = 0x8815,

    GL_RGBA16F = 0x881A,

    GL_RGB16F = 0x881B,

    GL_DEPTH24_STENCIL8 = 0x88F0,

    GL_R11F_G11F_B10F = 0x8C3A,

    GL_RGB9_E5 = 0x8C3D,

    GL_SRGB = 0x8C40,

    GL_SRGB8 = 0x8C41,

    GL_SRGB_ALPHA = 0x8C42,

    GL_SRGB8_ALPHA8 = 0x8C43,

    GL_SLUMINANCE_ALPHA = 0x8C44,

    GL_SLUMINANCE8_ALPHA8 = 0x8C45,

    GL_SLUMINANCE = 0x8C46,

    GL_SLUMINANCE8 = 0x8C47,

    GL_COMPRESSED_SRGB = 0x8C48,

    GL_COMPRESSED_SRGB_ALPHA = 0x8C49,

    GL_COMPRESSED_SLUMINANCE = 0x8C4A,

    GL_COMPRESSED_SLUMINANCE_ALPHA = 0x8C4B,

    GL_COMPRESSED_SRGB_S3TC_DXT1_EXT = 0x8C4C,

    GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = 0x8C4D,

    GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = 0x8C4E,

    GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = 0x8C4F,

    GL_DEPTH_COMPONENT32F = 0x8CAC,

    GL_DEPTH32F_STENCIL8 = 0x8CAD,

    GL_RGBA32UI = 0x8D70,

    GL_RGB32UI = 0x8D71,

    GL_RGBA16UI = 0x8D76,

    GL_RGB16UI = 0x8D77,

    GL_RGBA8UI = 0x8D7C,

    GL_RGB8UI = 0x8D7D,

    GL_RGBA32I = 0x8D82,

    GL_RGB32I = 0x8D83,

    GL_RGBA16I = 0x8D88,

    GL_RGB16I = 0x8D89,

    GL_RGBA8I = 0x8D8E,

    GL_RGB8I = 0x8D8F,

    GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD,

    GL_COMPRESSED_RED_RGTC1 = 0x8DBB,

    GL_COMPRESSED_SIGNED_RED_RGTC1 = 0x8DBC,

    GL_COMPRESSED_RG_RGTC2 = 0x8DBD,

    GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE,

    GL_COMPRESSED_RGBA_BPTC_UNORM = 0x8E8C,

    GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT = 0x8E8E,

    GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT = 0x8E8F,

    GL_R8_SNORM = 0x8F94,

    GL_RG8_SNORM = 0x8F95,

    GL_RGB8_SNORM = 0x8F96,

    GL_RGBA8_SNORM = 0x8F97,

    GL_R16_SNORM = 0x8F98,

    GL_RG16_SNORM = 0x8F99,

    GL_RGB16_SNORM = 0x8F9A,

    GL_RGBA16_SNORM = 0x8F9B,

    GL_RGB10_A2UI = 0x906F,

    GL_ONE = 1,

    GL_TWO = 2,

    GL_THREE = 3,

    GL_FOUR = 4,
}

public enum PixelFormat : int
{
    ColorIndex = 0X1900,
    StencilIndex = 0X1901,
    DepthComponent = 0X1902,
    Red = 0X1903,
    Green = 0X1904,
    Blue = 0X1905,
    Alpha = 0X1906,
    Rgb = 0X1907,
    Rgba = 0X1908,
    Luminance = 0X1909,
    LuminanceAlpha = 0X190a,
    AbgrExt = 0X8000,
    CmykExt = 0X800c,
    CmykaExt = 0X800D,
    Bgr = 0X80e0,
    Bgra = 0X80e1,
    Ycrcb422Sgix = 0X81bb,
    Ycrcb444Sgix = 0X81bc,
    Rg = 0X8227,
    RgInteger = 0X8228,
    DepthStencil = 0X84f9,
    RedInteger = 0X8d94,
    GreenInteger = 0X8d95,
    BlueInteger = 0X8d96,
    AlphaInteger = 0X8d97,
    RgbInteger = 0X8d98,
    RgbaInteger = 0X8d99,
    BgrInteger = 0X8d9a,
    BgraInteger = 0X8d9b,
}

public enum PixelType : int
{
    Byte = 0X1400,
    UnsignedByte = 0X1401,
    Short = 0X1402,
    UnsignedShort = 0X1403,
    Int = 0X1404,
    UnsignedInt = 0X1405,
    Float = 0X1406,
    HalfFloat = 0X140b,
    Bitmap = 0X1a00,
    UnsignedByte332 = 0X8032,
    UnsignedByte332Ext = 0X8032,
    UnsignedShort4444 = 0X8033,
    UnsignedShort4444Ext = 0X8033,
    UnsignedShort5551 = 0X8034,
    UnsignedShort5551Ext = 0X8034,
    UnsignedInt8888 = 0X8035,
    UnsignedInt8888Ext = 0X8035,
    UnsignedInt1010102 = 0X8036,
    UnsignedInt1010102Ext = 0X8036,
    UnsignedByte233Reversed = 0X8362,
    UnsignedShort565 = 0X8363,
    UnsignedShort565Reversed = 0X8364,
    UnsignedShort4444Reversed = 0X8365,
    UnsignedShort1555Reversed = 0X8366,
    UnsignedInt8888Reversed = 0X8367,
    UnsignedInt2101010Reversed = 0X8368,
    UnsignedInt248 = 0X84fa,
    UnsignedInt10F11F11FRev = 0X8c3b,
    UnsignedInt5999Rev = 0X8c3e,
    Float32UnsignedInt248Rev = 0X8Dad,
}
#endregion

[SuppressUnmanagedCodeSecurity]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "OpenGL functions have dumb naming conventions but I'm keeping these APIs pure.")]
public static partial class OpenGL32
{
    private const string Library = "Opengl32.dll";

    /// <summary>
    /// Specify the alpha test function. Alpha testing is performed only in RGBA mode.
    /// </summary>
    /// <param name="func">Specifies the alpha comparison function. Symbolic constants GL_NEVER, GL_LESS, GL_EQUAL, GL_LEQUAL, GL_GREATER, GL_NOTEQUAL, GL_GEQUAL, and GL_ALWAYS are accepted. The initial value is GL_ALWAYS.</param>
    /// <param name="ref">Specifies the reference value that incoming alpha values are compared to. This value is clamped to the range 0 1 , where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.</param>
    [DllImport(Library)]
    public static extern void glAlphaFunc(ALPHA_COMPARISON_FUNCTION func, float @ref);

    /// <summary>
    /// Delimit the vertices of a primitive or a group of like primitives
    /// </summary>
    /// <param name="mode">Specifies the primitive or primitives that will be created from vertices presented between glBegin and the subsequent glEnd. Ten symbolic constants are accepted: GL_POINTS, GL_LINES, GL_LINE_STRIP, GL_LINE_LOOP, GL_TRIANGLES, GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN, GL_QUADS, GL_QUAD_STRIP, and GL_POLYGON.</param>
    [DllImport(Library)]
    public static extern void glBegin(int mode);

    /// <summary>
    /// Bind a named texture to a texturing target
    /// </summary>
    /// <param name="target">Specifies the target to which the texture is bound. Must be one of GL_TEXTURE_1D, GL_TEXTURE_2D, GL_TEXTURE_3D, GL_TEXTURE_1D_ARRAY, GL_TEXTURE_2D_ARRAY, GL_TEXTURE_RECTANGLE, GL_TEXTURE_CUBE_MAP, GL_TEXTURE_CUBE_MAP_ARRAY, GL_TEXTURE_BUFFER, GL_TEXTURE_2D_MULTISAMPLE or GL_TEXTURE_2D_MULTISAMPLE_ARRAY.</param>
    /// <param name="texture">Specifies the name of a texture.</param>
    [DllImport(Library)]
    public static extern void glBindTexture(TEXTURE_TARGET target, int texture);

    /// <summary>
    /// Specify pixel arithmetic
    /// </summary>
    /// <param name="sfactor">Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.</param>
    /// <param name="dfactor">Specifies how the red, green, blue, and alpha destination blending factors are computed. The following symbolic constants are accepted: GL_ZERO, GL_ONE, GL_SRC_COLOR, GL_ONE_MINUS_SRC_COLOR, GL_DST_COLOR, GL_ONE_MINUS_DST_COLOR, GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA, GL_DST_ALPHA, GL_ONE_MINUS_DST_ALPHA. GL_CONSTANT_COLOR, GL_ONE_MINUS_CONSTANT_COLOR, GL_CONSTANT_ALPHA, and GL_ONE_MINUS_CONSTANT_ALPHA. The initial value is GL_ZERO.</param>
    [DllImport(Library)]
    public static extern void glBlendFunc(BLEND_SCALE_FACTOR sfactor, BLEND_SCALE_FACTOR dfactor);

    /// <summary>
    /// Clear buffers to preset values
    /// </summary>
    /// <param name="mask">Bitwise OR of masks that indicate the buffers to be cleared. The three masks are GL_COLOR_BUFFER_BIT, GL_DEPTH_BUFFER_BIT, and GL_STENCIL_BUFFER_BIT.</param>
    [DllImport(Library)]
    public static extern void glClear(BUFFER_MASK mask);

    /// <summary>
    /// Specify clear values for the color buffers. Specify the red, green, blue, and alpha values used when the color buffers are cleared. The initial values are all 0.
    /// </summary>
    /// <param name="red">Specify the red value [0-1].</param>
    /// <param name="green">Specify the green value [0-1].</param>
    /// <param name="blue">Specify the blue value [0-1].</param>
    /// <param name="alpha">Specify the alpha value [0-1].</param>
    [DllImport(Library)]
    public static extern void glClearColor(float red, float green, float blue, float alpha);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color. [0,1]</param>
    /// <param name="green">The new green value for the current color. [0,1]</param>
    /// <param name="blue">The new blue value for the current color. [0,1]</param>
    /// <remarks>The current alpha value is set to 1.0 (full intensity) implicitly.</remarks>
    [DllImport(Library)]
    public static extern void glColor3f(float red, float green, float blue);

    /// <summary>
    /// Sets the current color.
    /// </summary>
    /// <param name="red">The new red value for the current color. [0,1]</param>
    /// <param name="green">The new green value for the current color. [0,1]</param>
    /// <param name="blue">The new blue value for the current color. [0,1]</param>
    /// <param name="alpha">The new alpha value for the current color. [0,1]</param>
    [DllImport(Library)]
    public static extern void glColor4f(float red, float green, float blue, float alpha);

    /// <summary>
    /// Delete named textures.
    /// </summary>
    /// <param name="n">Specifies the number of textures to be deleted.</param>
    /// <param name="textures">Specifies an array of textures to be deleted.</param>
    [DllImport(Library)]
    public static extern void glDeleteTextures(int n, int[] textures);

    /// <summary>
    /// Enable or disable writing into the depth buffer. If flag is GL_FALSE, depth buffer writing is disabled. Otherwise, it is enabled. Initially, depth buffer writing is enabled.
    /// </summary>
    /// <param name="flag">Specifies whether the depth buffer is enabled for writing. If flag is GL_FALSE, depth buffer writing is disabled. Otherwise, it is enabled.</param>
    [DllImport(Library)]
    public static extern void glDepthMask(bool flag);

    /// <summary>
    /// The glEnable and glDisable functions enable or disable OpenGL capabilities.
    /// </summary>
    /// <param name="cap">A symbolic constant indicating an OpenGL capability. For discussion of the values cap can take, see the following Remarks section.</param>
    [DllImport(Library)]
    public static extern void glDisable(GLCAP cap);

    /// <summary>
    /// The glEnableClientState and glDisableClientState functions enable and disable arrays respectively.
    /// </summary>
    /// <param name="array">A symbolic constant for the array you want to enable or disable. </param>
    [DllImport(Library)]
    public static extern void glDisableClientState(STATEARRAY array);

    /// <summary>
    /// Render primitives from array data.
    /// </summary>
    /// <param name="mode">Specifies what kind of primitives to render.</param>
    /// <param name="first">Specifies the starting index in the enabled arrays.</param>
    /// <param name="count">Specifies the number of indices to be rendered.</param>
    [DllImport(Library)]
    public static extern void glDrawArrays(PRIMITIVE_TYPE mode, int first, int count);

    /// <summary>
    /// glEnable and glDisable enable and disable various capabilities. Use glIsEnabled or glGet to determine the current setting of any capability. The initial value for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is GL_FALSE. The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
    /// </summary>
    /// <param name="cap">Specifies a symbolic constant indicating a GL capability.</param>
    [DllImport(Library)]
    public static extern void glEnable(GLCAP cap);

    /// <summary>
    /// glEnableClientState and glDisableClientState enable or disable individual client-side capabilities. By default, all client-side capabilities are disabled. Both glEnableClientState and glDisableClientState take a single argument, cap, which can assume one of the following values:
    /// </summary>
    /// <param name="array">Specifies the capability to disable.</param>
    [DllImport(Library)]
    public static extern void glEnableClientState(STATEARRAY array);

    /// <summary>
    /// The glBegin and glEnd functions delimit the vertices of a primitive or a group of like primitives.
    /// </summary>
    [DllImport(Library)]
    public static extern void glEnd();

    /// <summary>
    /// glFlush — force execution of GL commands. Different GL implementations buffer commands in several different locations, including network buffers and the graphics accelerator itself. glFlush empties all of these buffers, causing all issued commands to be executed as quickly as they are accepted by the actual rendering engine. Though this execution may not be completed in any particular time period, it does complete in finite time.
    /// </summary>
    [DllImport(Library)]
    public static extern void glFlush();

    /// <summary>
    /// define front- and back-facing polygons
    /// </summary>
    /// <param name="mode">Specifies the orientation of front-facing polygons. GL_CW and GL_CCW are accepted. The initial value is GL_CCW.</param>
    [DllImport(Library)]
    public static extern void glFrontFace(FRONTFACEMODE mode);

    /// <summary>
    /// The glGetBooleanv function returns the value or values of a selected parameter.
    /// </summary>
    /// <param name="pname">The parameter value to be returned.</param>
    /// <param name="data">Returns the value or values of the specified parameter.</param>
    [DllImport(Library)]
    public static extern void glGetBooleanv(GLGET pname, [Out] out bool[] data);

    /// <summary>
    /// Return error information. Each detectable error is assigned a numeric code and symbolic name. When an error occurs, the error flag is set to the appropriate error code value. No other errors are recorded until glGetError is called, the error code is returned, and the flag is reset to GL_NO_ERROR. If a call to glGetError returns GL_NO_ERROR, there has been no detectable error since the last call to glGetError, or since the GL was initialized.
    /// </summary>
    /// <returns>Returns the value of the error flag. </returns>
    [DllImport(Library)]
    public static extern OpenGLErrorCode glGetError();

    /// <summary>
    /// return the value or values of a selected parameter
    /// </summary>
    /// <param name="pname">Specifies the parameter value to be returned for non-indexed versions of glGet.</param>
    /// <param name="result">Returns the value or values of the specified parameter.</param>
    [DllImport(Library)]
    public static extern void glGetIntegerv(GLGET pname, out int result);

    /// <summary>
    /// Return the value or values of a selected parameter
    /// </summary>
    /// <param name="pname">Specifies the parameter value to be returned for non-indexed versions of glGet</param>
    /// <param name="result">Returns the values of the specified parameter.</param>
    [DllImport(Library)]
    public static extern void glGetIntegerv(int pname, int[] result);

    /// <summary>
    /// Returns a pointer to a static string describing some aspect of the current GL connection.
    /// </summary>
    /// <param name="name">Specifies a symbolic constant</param>
    /// <returns>Returns a pointer to a static string describing some aspect of the current GL connection</returns>
    [DllImport(Library, CharSet = CharSet.Unicode)]
    public unsafe static extern sbyte* glGetString(GETSTRING_NAME name);

    /// <summary>
    /// return a texture image
    /// </summary>
    /// <param name="target">Specifies the target to which the texture is bound for glGetTexImage and glGetnTexImage functions.</param>
    /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
    /// <param name="format">Specifies a pixel format for the returned data.</param>
    /// <param name="type">Specifies a pixel type for the returned data.</param>
    /// <param name="pixels">Returns the texture image. Should be a pointer to an array of the type specified by type.</param>
    [DllImport(Library)]
    public static extern void glGetTexImage(TEXTURE_TARGET target, int level, PixelFormat format, PixelType type, IntPtr pixels);

    /// <summary>
    /// returns n texture names in textures. There is no guarantee that the names form a contiguous set of integers; however, it is guaranteed that none of the returned names was in use immediately before the call to glGenTextures. The generated textures have no dimensionality; they assume the dimensionality of the texture target to which they are first bound(see glBindTexture). Texture names returned by a call to glGenTextures are not returned by subsequent calls, unless they are first deleted with glDeleteTextures.
    /// </summary>
    /// <param name="n">Specifies the number of texture names to be generated.</param>
    /// <param name="textures">Specifies an array in which the generated texture names are stored.</param>
    [DllImport(Library)]
    public static extern void glGenTextures(int n, int[] textures);

    /// <summary>
    /// returns GL_TRUE if cap is an enabled capability and returns GL_FALSE otherwise. Boolean states that are indexed may be tested with glIsEnabledi. For glIsEnabledi, index specifies the index of the capability to test. index must be between zero and the count of indexed capabilities for cap. Initially all capabilities except GL_DITHER are disabled; GL_DITHER is initially enabled.
    /// </summary>
    /// <param name="cap">Specifies a symbolic constant indicating a GL capability.</param>
    /// <returns>returns GL_TRUE if cap is an enabled capability and returns GL_FALSE otherwise</returns>
    [DllImport(Library)]
    public static extern bool glIsEnabled(GLCAP cap); //marshalasbool?

    /// <summary>
    /// returns light source parameter values.
    /// </summary>
    /// <param name="light">The identifier of a light. The number of possible lights depends on the implementation, but at least eight lights are supported. They are identified by symbolic names of the form GL_LIGHTi where i is a value: 0 to GL_MAX_LIGHTS - 1.</param>
    /// <param name="pname">A light source parameter for light.</param>
    /// <param name="params">Specifies the value that parameter pname of light source light will be set to.</param>
    /// <remarks>The glLightfv function sets the value or values of individual light source parameters. The light parameter names the light and is a symbolic name of the form GL_LIGHTi, where 0 = i less than GL_MAX_LIGHTS. The pname parameter specifies one of the light source parameters, again by symbolic name.The params parameter is either a single value or a pointer to an array that contains the new values. Lighting calculation is enabled and disabled using glEnable and glDisable with argument GL_LIGHTING.When lighting is enabled, light sources that are enabled contribute to the lighting calculation.Light source i is enabled and disabled using glEnable and glDisable with argument GL_LIGHTi. It is always the case that GL_LIGHTi = GL_LIGHT0 + i.</remarks>
    [DllImport(Library)]
    public static extern void glLightfv(LightName light, LightParameter pname, float[] @params);

    /// <summary>
    /// specify the width of rasterized lines
    /// </summary>
    /// <param name="width">Specifies the width of rasterized lines. The initial value is 1.</param>
    [DllImport(Library)]
    public static extern void glLineWidth(float width);

    /// <summary>
    /// replace the current matrix with the identity matrix
    /// </summary>
    [DllImport(Library)]
    public static extern void glLoadIdentity();

    /// <summary>
    /// The glMaterialfv function specifies material parameters for the lighting model.
    /// </summary>
    /// <param name="face">The face or faces that are being updated. Must be one of the following: GL_FRONT, GL_BACK, or GL_FRONT and GL_BACK.</param>
    /// <param name="pname">The material parameter of the face or faces being updated.</param>
    /// <param name="params">The value to which parameter GL_SHININESS will be set.</param>
    [DllImport(Library)]
    public static extern void glMaterialfv(POLYGON_FACE face, MaterialParameter pname, float[] @params);

    /// <summary>
    /// specify which matrix is the current matrix
    /// </summary>
    /// <param name="mode">Specifies which matrix stack is the target for subsequent matrix operations.</param>
    [DllImport(Library)]
    public static extern void glMatrixMode(MatrixMode mode);

    /// <summary>
    /// Sets the current normal vector.
    /// </summary>
    /// <param name="nx">Specifies the x-coordinate for the new current normal vector.</param>
    /// <param name="ny">Specifies the y-coordinate for the new current normal vector.</param>
    /// <param name="nz">Specifies the z-coordinate for the new current normal vector.</param>
    [DllImport(Library)]
    public static extern void glNormal3f(float nx, float ny, float nz);

    /// <summary>
    /// glOrtho describes a transformation that produces a parallel projection. The current matrix (see glMatrixMode) is multiplied by the orthographic matrix and the result replaces the current matrix.
    /// </summary>
    /// <param name="left">Specify the coordinates for the left and right vertical clipping planes.</param>
    /// <param name="right">Specify the coordinates for the left and right vertical clipping planes.</param>
    /// <param name="bottom">Specify the coordinates for the bottom and top horizontal clipping planes.</param>
    /// <param name="top">Specify the coordinates for the bottom and top horizontal clipping planes.</param>
    /// <param name="zNear">Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be behind the viewer.</param>
    /// <param name="zFar">Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be behind the viewer.</param>
    [DllImport(Library)]
    public static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);

    /// <summary>
    /// glReadPixels and glReadnPixels return pixel data from the frame buffer, starting with the pixel whose lower left corner is at location (x, y), into client memory starting at location data.
    /// </summary>
    /// <param name="x">Specify the window coordinates of the first pixel that is read from the frame buffer. This location is the lower left corner of a rectangular block of pixels.</param>
    /// <param name="y">Specify the window coordinates of the first pixel that is read from the frame buffer. This location is the lower left corner of a rectangular block of pixels.</param>
    /// <param name="width">Specify the dimensions of the pixel rectangle. width and height of one correspond to a single pixel.</param>
    /// <param name="height">Specify the dimensions of the pixel rectangle. width and height of one correspond to a single pixel.</param>
    /// <param name="format">Specifies the format of the pixel data.</param>
    /// <param name="type">Specifies the data type of the pixel data.</param>
    /// <param name="data">Returns the pixel data.</param>
    [DllImport(Library)]
    public static extern void glReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, [Out] IntPtr data);

    /// <summary>
    /// glPixelStorei sets pixel storage modes that affect the operation of subsequent glReadPixels as well as the unpacking of texture patterns (see glTexImage2D and glTexSubImage2D).
    /// </summary>
    /// <param name="pname">a symbolic constant indicating the parameter to be set</param>
    /// <param name="param">the new value</param>
    [DllImport(Library)]
    public static extern void glPixelStorei(PIXEL_STORE_MODE pname, int param);

    /// <summary>
    /// glPointSize specifies the rasterized diameter of points
    /// </summary>
    /// <param name="size">The size in pixels</param>
    /// <remarks>If point size mode is disabled (see glEnable with parameter GL_PROGRAM_POINT_SIZE), this value will be used to rasterize points. Otherwise, the value written to the shading language built-in variable gl_PointSize will be used.</remarks>
    [DllImport(Library)]
    public static extern void glPointSize(float size);

    /// <summary>
    /// glPolygonMode controls the interpretation of polygons for rasterization.
    /// </summary>
    /// <param name="face">Specifies the polygons that mode applies to.</param>
    /// <param name="mode">Specifies how polygons will be rasterized.</param>
    [DllImport(Library)]
    public static extern void glPolygonMode(POLYGON_FACE face, POLYGON_MODE mode);

    /// <summary>
    /// glPopMatrix pops the current matrix stack, replacing the current matrix with the one below it on the stack.
    /// </summary>
    [DllImport(Library)]
    public static extern void glPopMatrix();

    /// <summary>
    /// glPushMatrix pushes the current matrix stack down by one, duplicating the current matrix. That is, after a glPushMatrix call, the matrix on top of the stack is identical to the one below it.
    /// </summary>
    [DllImport(Library)]
    public static extern void glPushMatrix();

    /// <summary>
    /// multiply the current matrix by a rotation matrix
    /// </summary>
    /// <param name="angle">Specifies the angle of rotation, in degrees.</param>
    /// <param name="x">Specify the x, y, and z coordinates of a vector, respectively.</param>
    /// <param name="y">Specify the x, y, and z coordinates of a vector, respectively.</param>
    /// <param name="z">Specify the x, y, and z coordinates of a vector, respectively.</param>
    [DllImport(Library)]
    public static extern void glRotatef(float angle, float x, float y, float z);

    /// <summary>
    /// The glScaled and glScalef functions multiply the current matrix by a general scaling matrix.
    /// </summary>
    /// <param name="x">Scale factors along the x axis.</param>
    /// <param name="y">Scale factors along the y axis.</param>
    /// <param name="z">Scale factors along the z axis.</param>
    [DllImport(Library)]
    public static extern void glScalef(float x, float y, float z);

    /// <summary>
    /// Select flat or smooth shading
    /// </summary>
    /// <param name="mode">Specifies a symbolic value representing a shading technique.</param>
    [DllImport(Library)]
    public static extern void glShadeModel(SHADE_TECHNIQUE mode);

    /// <summary>
    /// set the current texture coordinates
    /// </summary>
    /// <param name="s">Specify s texture coordinate.</param>
    /// <param name="t">Specify t texture coordinate.</param>
    [DllImport(Library)]
    public static extern void glTexCoord2f(float s, float t);

    /// <summary>
    /// specify a one-dimensional texture image
    /// </summary>
    /// <param name="target">Specifies the target texture.</param>
    /// <param name="level">Specifies the level-of-detail number.</param>
    /// <param name="internalformat">Specifies the number of color components in the texture.</param>
    /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide. The height of the 1D texture image is 1.</param>
    /// <param name="border">This value must be 0.</param>
    /// <param name="format">Specifies the format of the pixel data.</param>
    /// <param name="type">Specifies the data type of the pixel data.</param>
    /// <param name="data">Specifies a pointer to the image data in memory.</param>
    [DllImport(Library)]
    public static extern void glTexImage1D(TEXTURE_TARGET target, int level, TEXTURE_FORMAT internalFormat, int width, int border, PixelFormat format, PixelType type, IntPtr data);

    /// <summary>
    /// specify a two-dimensional texture image
    /// </summary>
    /// <param name="target">Specifies the target texture.</param>
    /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
    /// <param name="internalformat">Specifies the number of color components in the texture.</param>
    /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
    /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, in the case of the GL_TEXTURE_1D_ARRAY and GL_PROXY_TEXTURE_1D_ARRAY targets. All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
    /// <param name="border">This value must be 0.</param>
    /// <param name="format">Specifies the format of the pixel data.</param>
    /// <param name="type">Specifies the data type of the pixel data.</param>
    /// <param name="data">Specifies a pointer to the image data in memory.</param>
    [DllImport(Library)]
    public static extern void glTexImage2D(TEXTURE_TARGET target, int level, TEXTURE_FORMAT internalFormat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr data);

    /// <summary>
    /// specify a two-dimensional texture subimage
    /// </summary>
    /// <param name="target">Specifies the target to which the texture is bound for glTexSubImage2D.</param>
    /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
    /// <param name="xoffset">Specifies a texel offset in the x direction within the texture array.</param>
    /// <param name="yoffset">Specifies a texel offset in the y direction within the texture array.</param>
    /// <param name="width">Specifies the width of the texture subimage.</param>
    /// <param name="height">Specifies the height of the texture subimage.</param>
    /// <param name="format">Specifies the format of the pixel data.</param>
    /// <param name="type">Specifies the data type of the pixel data.</param>
    /// <param name="pixels">Specifies a pointer to the image data in memory.</param>
    [DllImport(Library)]
    public static extern void glTexSubImage2D(TEXTURE_TARGET target, int level, int xOffset, int yOffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels);

    /// <summary>
    /// set texture parameters
    /// </summary>
    /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
    /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
    /// <param name="param">Specifies the value of pname.</param>
    [DllImport(Library)]
    public static extern void glTexParameteri(TEXTURE_TARGET target, TextureParameterName pname, TextureParameter param);

    /// <summary>
    /// multiply the current matrix by a translation matrix
    /// </summary>
    /// <param name="x">Specify the x, y, and z coordinates of a translation vector.</param>
    /// <param name="y">Specify the x, y, and z coordinates of a translation vector.</param>
    /// <param name="z">Specify the x, y, and z coordinates of a translation vector.</param>
    [DllImport(Library)]
    public static extern void glTranslatef(float x, float y, float z);

    /// <summary>
    /// The glVertex function commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices. The current color, normal, and texture coordinates are associated with the vertex when glVertex is called. When only x and y are specified, z defaults to 0.0 and w defaults to 1.0. When x, y, and z are specified, w defaults to 1.0. Invoking glVertex outside of a glBegin/glEnd pair results in undefined behavior.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    [DllImport(Library)]
    public static extern void glVertex2f(float x, float y);

    /// <summary>
    /// The glVertex function commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices. The current color, normal, and texture coordinates are associated with the vertex when glVertex is called. When only x and y are specified, z defaults to 0.0 and w defaults to 1.0. When x, y, and z are specified, w defaults to 1.0. Invoking glVertex outside of a glBegin/glEnd pair results in undefined behavior.
    /// </summary>
    /// <param name="x">Specifies the x-coordinate of a vertex.</param>
    /// <param name="y">Specifies the y-coordinate of a vertex.</param>
    /// <param name="z">Specifies the z-coordinate of a vertex.</param>
    [DllImport(Library)]
    public static extern void glVertex3f(float x, float y, float z);

    /// <summary>
    /// glVertexPointer specifies the location and data format of an array of vertex coordinates to use when rendering
    /// </summary>
    /// <param name="size">Specifies the number of coordinates per vertex. Must be 2, 3, or 4. The initial value is 4.</param>
    /// <param name="type">Specifies the data type of each coordinate in the array. Symbolic constants GL_SHORT, GL_INT, GL_FLOAT, or GL_DOUBLE are accepted. The initial value is GL_FLOAT.</param>
    /// <param name="stride">Specifies the byte offset between consecutive vertices. If stride is 0, the vertices are understood to be tightly packed in the array. The initial value is 0.</param>
    /// <param name="pointer">Specifies a pointer to the first coordinate of the first vertex in the array. The initial value is 0.</param>
    [DllImport(Library)]
    public static extern void glVertexPointer(int size, DataType type, int stride, float[] pointer);

    /// <summary>
    /// Specifies the affine transformation of x and y from normalized device coordinates to window coordinates.
    /// </summary>
    /// <param name="x">Specify the lower left corner of the viewport rectangle, in pixels. The initial value is (0,0).</param>
    /// <param name="y">Specify the lower left corner of the viewport rectangle, in pixels. The initial value is (0,0).</param>
    /// <param name="width">Specify the width and height of the viewport. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
    /// <param name="height">Specify the width and height of the viewport. When a GL context is first attached to a window, width and height are set to the dimensions of that window.</param>
    [DllImport(Library)]
    public static extern void glViewport(int x, int y, int width, int height);

    /// <summary>
    /// The wglCreateContext function creates a new OpenGL rendering context, which is suitable for drawing on the device referenced by hdc. The rendering context has the same pixel format as the device context.
    /// </summary>
    /// <param name="unnamedParam1">Handle to a device context for which the function creates a suitable OpenGL rendering context.</param>
    /// <returns>If the function succeeds, the return value is a valid handle to an OpenGL rendering context. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr wglCreateContext(IntPtr unnamedParam1);

    /// <summary>
    /// The wglDeleteContext function deletes a specified OpenGL rendering context.
    /// </summary>
    /// <param name="unnamedParam1">Handle to an OpenGL rendering context that the function will delete.</param>
    /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool wglDeleteContext(IntPtr unnamedParam1);

    /// <summary>
    /// The wglGetCurrentContext function obtains a handle to the current OpenGL rendering context of the calling thread.
    /// </summary>
    /// <returns>If the calling thread has a current OpenGL rendering context, wglGetCurrentContext returns a handle to that rendering context. Otherwise, the return value is NULL.</returns>
    [DllImport(Library)]
    public static extern IntPtr wglGetCurrentContext();

    /// <summary>
    /// The wglGetProcAddress function returns the address of an OpenGL extension function for use with the current OpenGL rendering context.
    /// </summary>
    /// <param name="unnamedParam1">Points to a null-terminated string that is the name of the extension function. The name of the extension function must be identical to a corresponding function implemented by OpenGL.</param>
    /// <returns>When the function succeeds, the return value is the address of the extension function. When no current rendering context exists or the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern IntPtr wglGetProcAddress(string unnamedParam1);

    /// <summary>
    /// The wglMakeCurrent function makes a specified OpenGL rendering context the calling thread's current rendering context. All subsequent OpenGL calls made by the thread are drawn on the device identified by hdc. You can also use wglMakeCurrent to change the calling thread's current rendering context so it's no longer current.
    /// </summary>
    /// <param name="unnamedParam1">Handle to a device context. Subsequent OpenGL calls made by the calling thread are drawn on the device identified by hdc.</param>
    /// <param name="unnamedParam2">Handle to an OpenGL rendering context that the function sets as the calling thread's rendering context. If hglrc is NULL, the function makes the calling thread's current rendering context no longer current, and releases the device context that is used by the rendering context. In this case, hdc is ignored.</param>
    /// <returns>When the wglMakeCurrent function succeeds, the return value is TRUE; otherwise the return value is FALSE. To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool wglMakeCurrent(IntPtr unnamedParam1, IntPtr unnamedParam2);

    /// <summary>
    /// The wglShareLists function enables multiple OpenGL rendering contexts to share a single display-list space.
    /// </summary>
    /// <param name="unnamedParam1">Specifies the OpenGL rendering context with which to share display lists.</param>
    /// <param name="unnamedParam2">Specifies the OpenGL rendering context to share display lists with hglrc1. The hglrc2 parameter should not contain any existing display lists when wglShareLists is called.</param>
    /// <returns>When the function succeeds, the return value is TRUE. When the function fails, the return value is FALSE and the display lists are not shared.To get extended error information, call GetLastError.</returns>
    [DllImport(Library, SetLastError = true)]
    public static extern bool wglShareLists(IntPtr unnamedParam1, IntPtr unnamedParam2);
}