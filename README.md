<img src="https://github.com/2239356Benadict/Assignment1/blob/main/swansea-university-2017.en.png" width="85" height="50">

# ChemVR 

 MSc VR group assignment for development of a VR Training application.

### **Description**
<p align="justify">



### **Features**

##### **OnBoardig**
![alt text](https://github.com/2239356Benadict/Assignment1/blob/main/ChemVR_OnBoarding.png)


# Unity Settings

Project made with Unity 2021.3.17f

Changes from default Unity project with Android build target:  

Packages:  
Installed XR Plug-in Management. Quest 2 
Installed Oculus XR Plugin  
Installed XR Interaction Toolkit version 2.3.0 pre.1  

URP Samples imported (includes useful blob shadow shader)  

Quality Settings:  
Custom Quality profiles  for Quest 2  
Vsync disabled  
Anisotropic Textures set to Per Texture.  
Shadowmask Mode set to Shadowmask  
LOD Bias set to 0.7  
Skin Weights set to 2 Bones  

Player Settings:  
Auto Graphics API disabled, set to OpenGL ES 3.0  
Texture Compression format set to ATSC  
Minimum API Level set to Android 10.0 (API Level 29)  
Lightmap encoding set to High Quality  
HDR Cubemap encoding set to High Quality  
Use Incremental GC enabled 
Scripting Backend set to IL2CPP  
IL2CPP Code generation set to Faster (smaller) builds *Change this to Faster runtime for release build  
Target Architecture set to Arm64  
Active Input Handling set to Both  
Optimize Mesh Data enabled   

Physics Settings:  
Reuse Collision Callbacks enabled  
Default Max Angular Speed set to 7  

Time Settings:  
Maximum Allowed Timestep set to 0.0138 (for 72 Hz)  

URP Renderer Settings:  
Shadows – Transparent Receive Shadows disabled   

URP Pipeline asset settings for Quest 2: (minor differences for Quest 1 and Quest Pro)  
Disable Terrain Holes  
Main Light – Cast Shadows disabled  
Additional Lights set to Per Pixel  

Notes:  
Adjust URP shadow settings according to the needs of your game/app.   
For release builds enable Low Overhead Mode under Oculus XR Plug-in Management options.  
