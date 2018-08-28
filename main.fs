#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

void main() {
    vec2 st = gl_FragCoord.xy/u_resolution;
    gl_FragColor = vec4(0.0,0.0,0.0,1.0);
    // gl_FragColor = vec4(u_mouse.x * 0.001, u_mouse.y * 0.001, abs(sin(u_time)), 1.0);
    // gl_FragColor = vec4(abs(sin(u_time)), abs(cos(u_time)), abs(sin(u_time)), 1.0);
}