#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

#define WIDTH 0.05
#define DEBUG false

float plot( vec2 st, float pct ) {
    return  smoothstep( pct+WIDTH, pct, st.y ) -
            smoothstep( pct, pct-WIDTH, st.y );
}

void main() {
    vec2 st = gl_FragCoord.xy / u_resolution;

    float y = smoothstep(0.0, 1.0, st.x);

    vec3 color = vec3(y);

    float pct = plot(st, y);
    if(DEBUG)
    {
        vec3 green = vec3(0.0, 1.0, 0.0);
        vec3 red = vec3(1.0, 0.0, 0.0);
        vec3 blue = vec3(0.0, 0.0, 1.0);
        if(pct > 0.5 && pct < 0.6) color = (1.0 - pct) * color + pct * green;
        else if(pct > 0.6 && pct < 1.0) color = (1.0 - pct) * color + pct * red;
        else if(pct > 1.0 || pct <= 0.5) color = (1.0 - pct) * color + pct * blue;
        else if(pct == 1.0) color = (1.0 - pct) * color + pct * vec3(1.0);
    }
    else
    {
        color = ( 1.0 - pct ) * color + pct * vec3( 0.0, 1.0, 0.0 );
    }

    gl_FragColor = vec4( color, 1.0 );
}