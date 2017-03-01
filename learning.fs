#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

#define PI 3.14159265359
#define WIDTH 0.05
#define DEBUG false

float plot( vec2 st, float pct ) {
    return  smoothstep( pct+WIDTH, pct, st.y ) -
            smoothstep( pct, pct-WIDTH, st.y );
}

void main() {
    vec2 st = gl_FragCoord.xy / u_resolution;

    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 0.5 ) - 0.05; // kynd 0,0
    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 1.0 ) - 0.05; // kynd 0,1
    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 1.5 ) - 0.05; // kynd 0,2
    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 2.0 ) - 0.05; // kynd 0,3
    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 2.5 ) - 0.05; // kynd 0,4
    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 3.0 ) - 0.05; // kynd 0,5
    // float y = 1.0 - pow( abs( st.x - .5 ) * 2.0, 3.5 ) - 0.05; // kynd 0,6

    // float y = pow( cos( PI * ( st.x - .5 ) ), 0.5 ); // kynd 1,0
    // float y = pow( cos( PI * ( st.x - .5 ) ), 1.0 ); // kynd 1,1
    // float y = pow( cos( PI * ( st.x - .5 ) ), 1.5 ); // kynd 1,2
    // float y = pow( cos( PI * ( st.x - .5 ) ), 2.0 ); // kynd 1,3
    // float y = pow( cos( PI * ( st.x - .5 ) ), 2.5 ); // kynd 1,4
    // float y = pow( cos( PI * ( st.x - .5 ) ), 3.0 ); // kynd 1,5
    // float y = pow( cos( PI * ( st.x - .5 ) ), 3.5 ); // kynd 1,6


    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 0.5 ); // kynd 2,0
    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 1.0 ); // kynd 2,1
    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 1.5 ); // kynd 2,2
    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 2.0 ); // kynd 2,3
    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 2.5 ); // kynd 2,4
    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 3.0 ); // kynd 2,5
    // float y = 1.0 - pow( abs( sin( PI * ( st.x - .5 ) / 1.0 ) ), 3.5 ); // kynd 2,6

    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 0.5 ); // kynd 3,0
    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 1.0 ); // kynd 3,1
    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 1.5 ); // kynd 3,2
    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 2.0 ); // kynd 3,3
    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 2.5 ); // kynd 3,4
    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 3.0 ); // kynd 3,5
    // float y =  pow( min( cos( PI * ( st.x - .5) ), 1.05 - abs( ( st.x - .5 ) ) ), 3.5 ); // kynd 3,6

    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 0.5 ); // kynd 4,0
    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 1.0 ); // kynd 4,0
    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 1.5 ); // kynd 4,0
    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 2.0 ); // kynd 4,0
    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 2.5 ); // kynd 4,0
    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 3.0 ); // kynd 4,0
    // float y = 1.0 - pow( max( 0.0, abs( st.x - .5 ) * 2.0 - .25 ), 3.5 ); // kynd 4,0

    float y = pow( cos( st.x - .5 ), 30.0 ) - .05; // ship

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