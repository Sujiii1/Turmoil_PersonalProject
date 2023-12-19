//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/ThermalExpasionShader" {
Properties {
_MainTex ("Texture", 2D) = "white" { }
_textureOffset ("TextureOffset", Float) = 0
edgeColor ("edgeColor", Color) = (0,0,0,0)
centerColor ("centerColor", Color) = (0,0,0,0)
waveColor ("waveColor", Color) = (0,0,0,0)
waveEdgeAlpha ("waveEdgeAlpha", Float) = 0.65
waveAlpha ("waveAlpha", Float) = 0.15
}
SubShader {
 Tags { "QUEUE" = "Transparent" "RenderType" = "Transparent" }
 Pass {
  Tags { "QUEUE" = "Transparent" "RenderType" = "Transparent" }
  Blend One OneMinusSrcAlpha, One OneMinusSrcAlpha
  ZWrite Off
  Cull Off
  GpuProgramID 49229
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