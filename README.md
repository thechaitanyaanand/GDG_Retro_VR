Here's the **complete** document converted to Markdown in one place — cleaned and ready to copy into a `README.md`:

# 🌆 VR Retro-Cyber Environment
*An immersive virtual reality experience set in a nostalgic cyberpunk world*

Step into a retro-futuristic world where neon lights dance across vintage CRT monitors and secrets await discovery. This Unity VR experience combines atmospheric design with interactive gameplay, challenging players to uncover a hidden secret through creative exploration and precision shooting.

**🎮 Core Gameplay:** Use the hints placed in the enviorenment to get to the final location, then Use your Meta Quest controllers to shoot projectiles at vintage CRT monitors, triggering a cascade of floating orbs. Find the correct orb among 15 glowing spheres to unlock the secret key and complete your mission.

[![Watch the demo](https://img.youtube.com/vi/m_M_mJ-Z1FA/hqdefault.jpg)](https://youtu.be/m_M_mJ-Z1FA)



## ✨ Features

### 🎨 **Immersive Retro-Cyber Aesthetics**
- Vintage CRT monitor arrays with authentic glow effects
- Neon lighting and particle systems
- Atmospheric cyberpunk environment design
- Floating geometric shapes with smooth animations

### 🔫 **Interactive VR Mechanics**
- Physics-based projectile shooting system
- Meta Quest controller integration with haptic feedback
- Precise collision detection and visual feedback
- Intuitive trigger-based controls

### 🎲 **Dynamic Gameplay Elements**
- Randomized key orb placement for replayability
- 15 floating orbs with smooth wobbling animations
- Particle effects and audio feedback
- Progressive game flow with clear objectives

### 🎯 **Secret Discovery System**
- Hidden secret key reveal mechanism
- Creative visual storytelling through environmental interaction
- Victory conditions with satisfying completion feedback

## 🛠️ Technical Implementation

### **Core Scripts**
| Script | Purpose |
|--------|---------|
| `SimpleVRShooter.cs` | Handles Meta Quest controller input and projectile firing |
| `GameManagerSimple.cs` | Manages game flow, orb spawning, and win conditions |
| `DestroyableTarget.cs` | Controls CRT monitor destruction and triggers |
| `FloatingOrb.cs` | Manages orb behavior, animations, and collision detection |
| `Projectile.cs` | Physics-based projectile with enhanced collision detection |

### **Key Features**
- **Collision System**: Advanced physics-based collision detection with backup raycast systems
- **Animation System**: Smooth floating and rotation animations for environmental objects
- **Audio System**: Integrated sound effects for shooting, impacts, and victories
- **Particle Systems**: Visual effects for destruction and atmospheric enhancement

## 🚀 Installation & Setup

### **Prerequisites**
- Unity 2022.3 LTS or newer
- Meta XR SDK
- Meta Building Blocks package
- Meta Quest 2/Pro/3 headset

### **Setup Instructions**

1. **Clone the Repository**
   ```bash
   git clone https://github.com/thechaitanyaanand/vr-retro-cyber-environment.git
   cd vr-retro-cyber-environment


2. **Open in Unity**

   * Launch Unity Hub
   * Click "Open Project"
   * Navigate to the cloned folder and select it

3. **Configure VR Settings**

   * Ensure Meta XR SDK is imported
   * Verify Building Blocks are properly installed
   * Check that VR support is enabled in Project Settings

4. **Scene Setup**

   * Open the main scene
   * Ensure all script references are properly assigned in the Inspector
   * Verify Meta Quest controllers are detected

## 🎮 How to Play

1. **🥽 Put on your Meta Quest headset** and start the application
2. **🎯 Locate CRT Monitor 7** in the retro-cyber environment
3. **🔫 Use the right controller trigger** to shoot projectiles at the monitor
4. **💥 Destroy the monitor** to trigger the orb spawning sequence
5. **🌟 Hunt for the key orb** among 15 floating spheres
6. **🗝️ Find the correct orb** to reveal the secret key and win!

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── SimpleVRShooter.cs      # VR controller input handling
│   ├── GameManagerSimple.cs    # Game flow management
│   ├── DestroyableTarget.cs    # Target destruction logic
│   ├── FloatingOrb.cs          # Orb behavior and animation
│   └── Projectile.cs           # Projectile physics and collision
├── Prefabs/
│   ├── Projectile.prefab       # Physics-enabled projectile
│   ├── FloatingOrb.prefab      # Animated orb with collision
│   └── CRTMonitor.prefab       # Interactive CRT monitor
├── Materials/
│   ├── NeonGlow.mat            # Glowing neon materials
│   ├── LaserBeam.mat           # Projectile trail material
│   └── CyberGrid.mat           # Retro grid textures
└── Scenes/
    └── MainScene.unity         # Primary VR environment
```

## ⚙️ Configuration

### **GameManager Settings**

* `numberOfOrbs`: Number of orbs to spawn (default: 15)
* `spawnRadius`: Orb spawn area radius (default: 5m)
* `orbSpawnHeight`: Height above ground for orb placement

### **Shooter Settings**

* `projectileSpeed`: Velocity of fired projectiles (default: 20 m/s)
* `raycastDistance`: Maximum shooting range (default: 100m)

### **Orb Animation Settings**

* `floatSpeed`: Speed of up/down wobbling motion
* `floatHeight`: Amplitude of floating animation
* `rotationSpeed`: Rotation speed around Y-axis

## 🎨 Customization

### **Adding Visual Effects**

1. Create particle systems for enhanced atmosphere
2. Modify materials for different neon color schemes
3. Add post-processing effects for cyberpunk aesthetics

### **Gameplay Modifications**

1. Adjust orb count in `GameManagerSimple`
2. Modify spawn patterns and areas
3. Add multiple secret keys or objectives

## 🐛 Troubleshooting

### **Common Issues**

**Projectiles not colliding with monitors:**

* Verify both objects have non-trigger colliders
* Check Rigidbody collision detection is set to "Continuous"
* Ensure objects are on compatible physics layers

**VR controllers not responding:**

* Confirm Meta XR SDK is properly installed
* Check Building Blocks setup in Camera Rig
* Verify controller tracking in Meta Quest settings

**Orbs not spawning:**

* Check GameManager references are assigned
* Verify CRT monitor has DestroyableTarget script
* Ensure `isCRTMonitor7` is checked on correct monitor

## 📋 Requirements

* **Unity Version**: 2022.3 LTS or newer
* **VR Headset**: Meta Quest 2, Pro, or 3
* **Development OS**: Windows 10/11, macOS, or Linux
* **Storage**: \~2GB free space
* **Meta Developer Account**: Required for Quest deployment

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request


