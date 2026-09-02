using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200708C RID: 28812
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraSpecificLocLocation : CameraSpecificLockTarget
	{
		// Token: 0x06045D34 RID: 286004 RVA: 0x01247F87 File Offset: 0x01246187
		public CameraSpecificLocLocation(Vector location, int priority, int id) : base(ECameraSpecificLockType.Location, id, priority)
		{
		}

		// Token: 0x1700A5A1 RID: 42401
		// (get) Token: 0x06045D35 RID: 286005 RVA: 0x01247F99 File Offset: 0x01246199
		public Vector Location { get; } = location;
	}
}
