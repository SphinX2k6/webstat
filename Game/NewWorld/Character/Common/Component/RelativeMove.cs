using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048F7 RID: 18679
	[NullableContext(2)]
	[Nullable(0)]
	public class RelativeMove
	{
		// Token: 0x0401C063 RID: 114787
		public long BaseMovementEntityId;

		// Token: 0x0401C064 RID: 114788
		public Vector RelativeLocation;

		// Token: 0x0401C065 RID: 114789
		public Rotator RelativeRotation;
	}
}
