using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

namespace Eidetic.URack.VFX
{
    [AddComponentMenu("VFX/Property Binders/URack/PointCloud Binder")]
    [VFXBinder("URack/PointCloud Binder")]
    public class RenderTextureBinder : VFXBinderBase
    {

        [VFXPropertyBinding("UnityEngine.Texture2D"), FormerlySerializedAs("Texture")]
        public ExposedProperty TextureProperty = "ImageA";

        public RenderTexture RenderTexture;

        public override void UpdateBinding(VisualEffect visualEffect)
        {
            visualEffect.SetTexture(TextureProperty, RenderTexture);
        }

        public override bool IsValid(VisualEffect component) => component.HasTexture(TextureProperty);
    }
}