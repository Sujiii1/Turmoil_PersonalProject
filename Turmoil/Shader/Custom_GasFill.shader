//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/GasFill" {
Properties {
_Fill ("Fill", Range(0, 1)) = 0.5
_TopColor ("TopColor", Color) = (1,0,0,1)
_MiddleColor ("MiddleColor", Color) = (0,1,0,1)
_BottomColor ("BottomColor", Color) = (0,0,1,1)
}
SubShader {
 LOD 100
 Tags { "IGNOREPROJECTOR" = "true" "RenderType" = "Opaque" }
 Pass {
  LOD 100
  Tags { "IGNOREPROJECTOR" = "true" "RenderType" = "Opaque" }
  Stencil {
   Ref 1
   Comp Always
   Pass Replace
   Fail Keep
   ZFail Keep
  }
  GpuProgramID 34864
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