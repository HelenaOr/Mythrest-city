Shader "N3K/Outline"
{
	Properties
	{
		_Color("MainColor",Color) = (0,0,1.0,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color",Color) = (0,0,0,1)
	}

	CGINCLUDE
	#include "UnityCG.cginc"
	struct appdata{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};
	struct v2f{
		float4 pos : POSITION;
		float3 normal : NORMAL;
	};

	float _OutlineWidth;
	float4 _OutlineColor;


	v2f vert(appdata v){
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		return o;
	}

	ENDCG
	SubShader
	{

		Tags{"Queue" = "Transparent"}


		Pass{
			ZWrite On
			Material{
				Diffuse[_Color]
				Ambient[_Color]
			}
			Lighting On
			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}
			SetTexture[_MainTex]{
				Combine previous * primary DOUBLE
			}
		}

		
	}
}
