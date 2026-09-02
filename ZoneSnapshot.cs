using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E33 RID: 3635
[NullableContext(1)]
[Nullable(0)]
internal struct ZoneSnapshot
{
	// Token: 0x06005636 RID: 22070 RVA: 0x000EC5DC File Offset: 0x000EA7DC
	public ZoneSnapshot()
	{
		this.CenterPosition = Vector.Create();
		this.CameraOffset = Vector.Create();
		this.CameraOffsetAlpha = Vector.Create();
		this.CameraRotation = Rotator.Create();
		this.BoxTransform = Transform.Create();
		this.BoxExtend = Vector.Create();
		this.HasBox = false;
		this.HasBox = false;
	}

	// Token: 0x04001BEC RID: 7148
	public readonly Vector CenterPosition;

	// Token: 0x04001BED RID: 7149
	public readonly Vector CameraOffset;

	// Token: 0x04001BEE RID: 7150
	public readonly Vector CameraOffsetAlpha;

	// Token: 0x04001BEF RID: 7151
	public readonly Rotator CameraRotation;

	// Token: 0x04001BF0 RID: 7152
	public readonly Transform BoxTransform;

	// Token: 0x04001BF1 RID: 7153
	public readonly Vector BoxExtend;

	// Token: 0x04001BF2 RID: 7154
	public bool HasBox;
}
