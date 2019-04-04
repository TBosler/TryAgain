Shader "Unlit/WorldspaceBlend"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	// Add a texture field for our overlay image.
	_Overlay("Overlay", 2D) = "white" {}
	_Color("Tint", Color) = (1,1,1,1)
	}
		SubShader
	{
		// Duplicate normal sprite shader behaviours.
		// (I skipped implementing pixel snap / split alpha though)
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 uv : TEXCOORD0;
				float2 overlayUV : TEXCOORD1;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			fixed4 _Color;

			// Allow sampling from the overlay image.
			sampler2D _Overlay;
			float4 _Overlay_ST;


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.color = v.color * _Color;

				// Compute what part of the overlay image we should sample.
				float2 worldPos = mul(unity_ObjectToWorld, v.vertex).xy;
				o.overlayUV = (worldPos - _Overlay_ST.zw) / _Overlay_ST.xy;

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * i.color;

			// Sample our overlay image.
			fixed4 overlay = tex2D(_Overlay, i.overlayUV);
			// Blend it with our base image.
			fixed4 output = lerp(col, overlay, overlay.a);
			output.a = col.a;
			// Convert to pre-multiplied alpha, as used by sprite shaders.
			output.rgb *= output.a;

			return output;
		}
		ENDCG
	}
	}
}