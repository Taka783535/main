Shader "Unlit/TestButterflyShader"
{
    Properties
    {

        [NoScaleOffset]_MainTex ("Texture", 2D) = "white" {}
        [HDR]_MainColor("MainColor",Color)=(1,1,1,1)
        _FlapSpeed("Flap Speed",Range(0,80))=10
        _FlapIntensity("Flap Intensity",Range(0,2))=1  
         
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            

            #include "UnityCG.cginc"

            struct appdata
            {
                //テクスチャの貼り付け用
                float4 uv : TEXCOORD0;
                //個々のパーティクルの中心座標
                float4 center:TEXCOORD1;
                float4 vertex:POSITION;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _FlapSpeed;
            float _FlapIntensity;
            

            v2f vert (appdata v)
            {
                v2f o;

                //パーティクルの座標を生成器の相対座標から各パーティクル中心点からの相対座標に変更
                float4 localposition=v.vertex-v.center;
                float flap=sin(_Time.w*_FlapSpeed);

                //v.vertex.y += flap;

                //羽根の回転行列を作成。signメソッドは左右の羽根の羽ばたきを同期させるため。
                float s = sin(flap * sign(localposition.x));
                float c=cos(flap*sign(localposition.x));
                half2x2 rotation=half2x2(c,-s,s,c);
                
                //羽根を回転
                localposition.xy=mul(rotation,localposition.xy);

                //再び生成器からの相対座標に戻して座標を確定
                v.vertex=localposition+v.center;
                o.vertex =UnityObjectToClipPos(v.vertex);

                o.uv = v.uv;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                
                return col;
                
            }
            ENDCG
        }
    }
}
