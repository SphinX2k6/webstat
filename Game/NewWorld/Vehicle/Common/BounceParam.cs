using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Common
{
	// Token: 0x020047D4 RID: 18388
	public class BounceParam
	{
		// Token: 0x0401B534 RID: 111924
		public int? SkillId;

		// Token: 0x0401B535 RID: 111925
		[Nullable(2)]
		public string CurvePath;

		// Token: 0x0401B536 RID: 111926
		public float? Time;

		// Token: 0x0401B537 RID: 111927
		public float? Height;

		// Token: 0x0401B538 RID: 111928
		public bool? UseLocalUp;

		// Token: 0x0401B539 RID: 111929
		public bool? NotClearDownVelocity;
	}
}
