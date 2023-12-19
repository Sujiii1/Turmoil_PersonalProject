//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Turmoil/ForegroundShader" {
Properties {
_LevelHeight ("LevelHeight", Range(-50, 0)) = -25
_LevelWidth ("LevelHalfWidth", Range(0, 100)) = 60
_LineThickness ("lineThickness", Range(0, 2)) = 0.33
_DashSize ("DashSize", Range(0, 10)) = 1.3
_DashColor ("DashColor", Color) = (1,1,1,1)
}
SubShader {
 LOD 100
 Tags { "PreviewType" = "Plane" "QUEUE" = "Geometry" "RenderType" = "Opaque" }
 Pass {
  LOD 100
  Tags { "PreviewType" = "Plane" "QUEUE" = "Geometry" "RenderType" = "Opaque" }
  Cull Off
  GpuProgramID 44198
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
}