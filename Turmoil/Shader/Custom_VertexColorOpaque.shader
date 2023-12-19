//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/VertexColorOpaque" {
Properties {
}
SubShader {
 Tags { "PreviewType" = "Plane" "QUEUE" = "Geometry" "RenderType" = "Opaque" }
 Pass {
  Tags { "PreviewType" = "Plane" "QUEUE" = "Geometry" "RenderType" = "Opaque" }
  Cull Off
  GpuProgramID 49516
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