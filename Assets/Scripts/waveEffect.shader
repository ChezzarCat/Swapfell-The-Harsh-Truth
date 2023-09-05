Shader "Hidden/waveEffect"
{
    Properties {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _DistortionStrength ("Distortion Strength", Range(0, 1)) = 0.1
        _DistortionSpeed ("Distortion Speed", Range(0, 5)) = 1.0
    }

    SubShader {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 0

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _DistortionStrength;
            float _DistortionSpeed;

            v2f vert(appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                float time = _Time.y * _DistortionSpeed;
                float distortionStrength = _DistortionStrength;

                // Calculate horizontal distortion using a sine wave pattern
                float horizontalDistortion = distortionStrength * sin(i.uv.y * 4.0 + time);

                float2 uvDistorted = i.uv + float2(horizontalDistortion, 0.0); // Only apply distortion horizontally
                
                // Wrap the UV coordinates within [0, 1] range
                uvDistorted = frac(uvDistorted);

                half4 texColor = tex2D(_MainTex, uvDistorted);
                return texColor;
            }
            ENDCG
        }
    }
}
