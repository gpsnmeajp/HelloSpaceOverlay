/*
* HelloSpaceOverlay by gpsnmeajp
* https://github.com/gpsnmeajp/HelloSpaceOverlay
* https://sabowl.sakura.ne.jp/gpsnmeajp/
*
* These codes are licensed under CC0.
* http://creativecommons.org/publicdomain/zero/1.0/deed.ja
*/
Shader "Unlit/StereoRender"
{
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_MainTex1("Texture", 2D) = "white" {}
		_MainTex2("Texture", 2D) = "white" {}
	}

	SubShader{
			Tags{ "RenderType" = "Opaque" }
			Pass{
				CGPROGRAM
				#pragma vertex vertexFunction
				#pragma fragment fragmentFunction
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				float4    _MainTex_ST;
				sampler2D _MainTex1;
				float4    _MainTex1_ST;
				sampler2D _MainTex2;
				float4    _MainTex2_ST;

				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f {
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				v2f vertexFunction(appdata IN) {
					v2f OUT;
					OUT.position = UnityObjectToClipPos(IN.vertex);
					OUT.uv = float2(IN.uv.x, IN.uv.y);
					return OUT;
				}

				fixed4 fragmentFunction(v2f IN) : SV_TARGET{
					float4 now;
					float2 uv = float2(IN.uv.x*2, IN.uv.y);

					now = tex2D(_MainTex1, uv);
					if (IN.uv.x > 0.5)
					{
						now = tex2D(_MainTex2, float2(uv.x - 1.0, uv.y));
					}
					return now;
				}
			ENDCG
		}
	}
}