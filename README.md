<img src="https://github.com/2239356Benadict/Assignment1/blob/main/swansea-university-2017.en.png" width="85" height="50"> 

# ChemVR    :     <img src="https://github.com/2239356Benadict/Assignment1/blob/main/ChemVR-logos_transparent.png" width="85" height="85">                                                     

MSc VR group assignment for development of a VR Training application.

### **Description**
<p align="justify">
Solvent removal is an essential process across a broad range of applications in the pharmaceutical, chemical, and biotechnology industries. An evaporator is an industrial process designed to concentrate feed liquors such as fruit juice, milk products, aqueous salt solutions etc. In this experiment the manual single effect evaporator uses steam as the heating media and water as the process fluid. The purpose of the experiment is to study the effects of varying the process parameters on the evaporator performance.
Evaporators do not always operate at atmospheric pressure. The evaporator capacity (or the rate of evaporation) is dependent upon the temperature driving force, that is, the temperature difference between the steam and the boiling point of the evaporator feed liquor. Increasing the temperature difference increases the evaporator capacity. Therefore, for a given duty, heat transfer would be reduced and hence the equipment will cost less. By adding a condenser and vacuum pump, the pressure in the evaporator can be made less than atmospheric. As a result, the liquor will boil at a lower temperature and hence, the temperature difference is increased. In industry vacuum operation is common and is of particular benefit with heat sensitive products, such as fruit juice or milk, which either decompose or react when heated to their normal (atmospheric) boiling temperature (Note: Do not confuse “reduced operating pressure” with “reduced steam pressure”).
In this VR application we have tried to recreate the experiment in the Virtual Reality environment so that students can repeatedly experiment and understand the procedures.<br>
  
### **Features**

##### **OnBoardig**
<p align="justify">
An onboarding process allows users, both experienced and new, to become acquainted with a VR application before engaging in real activities.
  
![alt text](https://github.com/2239356Benadict/Assignment1/blob/main/ChemVR_OnBoarding.png)


##### **Safety Room**
<p align="justify">
Before entering the laboratory, the user puts on the necessary safety equipment. This enables the user to form a habit of doing the same in the real world.
  
![alt text](https://github.com/2239356Benadict/Assignment1/blob/main/safetyroom.png)



##### **Laboratory Room**
<p align="justify">
In the laboratory scene, the user conducts the experiment and observes the outcomes. Once the user finishes the process user can do the quiz.
  
![alt text](https://github.com/2239356Benadict/Assignment1/blob/main/lab.png)

 
### Video
  Click the image to play video
  [<img src="https://github.com/2239356Benadict/Assignment1/blob/main/MicrosoftTeams-image%20(11).png" width="1000" height="" />](https://www.youtube.com/watch?v=jChVhQzAMCA)
  
### Credits
  1. VR Keys: The Campfire Union
  2. Quick Outline: Chris Nolet
  3. Modern Laboratory: AndragorInc
  
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
