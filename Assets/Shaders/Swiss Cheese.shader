Shader "Unlit/Swiss Cheese"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Speed("Speed", Float) = 1.0
		_Zoom("Zoom", Float) = 4.0
		_Transparency("Transparency", Range(0.0, 0.5)) = 0.25
	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 100

			Cull Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float _Speed;
				float _Zoom;
				float _Transparency;
				float4 _TintColor;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				// --- Start ShaderToy Code ---


				// Pseudo-randomness
				float2 N22(float2 p) {
					float3 a = frac(p.xyx * float3(123.45, 234.34, 345.65));
					a += dot(a, a + 34.45);
					return frac(float2(a.x * a.y, a.y * a.z));
				}

				// --- Unity code ---

				fixed4 frag(v2f i) : SV_Target
				{

					// --- End Unity code ---


						// Zooms out so it goes from -1.0 to 1.0
						float2 uv = _Zoom * i.uv;

						float m = 0.0;

						float time = _Time.y * _Speed;
						float cellIndex = 0.0;

						// Initialize minDist at a large distance
						float minDist = 100.0;

						float3 color = float3(0.0, 0.0, 0.0);

						// Multiply uv
						uv *= 2.0;

						// Make grid
						float2 gridUv = frac(uv) - 0.5;

						// Determine grid cell
						float2 id = floor(uv);

						float2 cellId = float2(0.0, 0.0);

						for (float y = -1.0; y <= 1.0; y++) {
							for (float x = -1.0; x <= 1.0; x++) {
								float2 offset = float2(x, y);
								float2 n = N22(float2(id + offset));
								float2 p = offset + sin(n * time) * 0.5;

								p -= gridUv;
								// Euclidian distance
								float eDist = length(p);

								// Manhattan distance
								float mDist = abs(p.x) + abs(p.y);

								// Interpolate between distances
								float dist = eDist;

								if (dist < minDist) {
									minDist = dist;
									cellId = id + offset;
								}
							}

							color = float3(minDist, minDist, minDist);
							color.rg = cellId * 0.01;
							//color.b * 1.5;

							if (color.r < 0.5 && color.g < 0.5 && color.b < 0.5) {
								_Transparency = 0.0;
							}
							else {
								_Transparency = 1.0;
							}
						}


						// Output to screen
						return float4(color, _Transparency);
					}


					// --- End ShaderToy code ---

					ENDCG
				}
		}
}
