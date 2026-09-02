using System;
using System.Text.Json.Serialization;

// Token: 0x02000021 RID: 33
[JsonPolymorphic(TypeDiscriminatorPropertyName = "MarkerType")]
[JsonDerivedType(typeof(AkMarkerCbLabelSoundTrackEffect), "SoundTrackingEffectNotify")]
public class AkMarkerCbLabel
{
}
