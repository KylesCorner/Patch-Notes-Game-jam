# Asset Creation

## General Workflow

Draw in Inkscape (SVG) → Export as PNG (with transparency) → Import into Unity.

Unity works best with raster images (PNG), but because you’re making assets in Inkscape (vector), you can scale them infinitely before export.

## Canvas & Image Size in Inkscape

This depends on your game resolution and the style you want:

Unity Pixels Per Unit (PPU): By default, Unity assumes 100 pixels = 1 world unit.

Target Resolution: For a modern 2D game, 1080p (1920×1080) is a safe target. But since you’re in first-person driving, assets will often be UI-like overlays (dashboard, steering
wheel, road textures).

## Recommendations:

### UI Elements (dashboard, steering wheel, speedometer, etc.):

- Work on a 1920×1080 canvas in Inkscape.

- Export elements at 2× resolution (e.g. 3840×2160) for crispness.

    - Unity will scale them down smoothly.

### Environment Elements (road textures, buildings, trees, sky):

- Export in power-of-two sizes (512×512, 1024×1024, 2048×2048). Unity likes those for texture
    compression.

- Keep tileable textures (like road or sky gradients) square and seamless.

### Sprites for objects (signs, cars, obstacles):

- Around 256–1024 px per sprite is usually enough.

- Bigger for foreground objects, smaller for background details.
---
