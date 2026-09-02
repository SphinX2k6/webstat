using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A16 RID: 27158
	public class ActionSetSeqCameraTransform : ActionParams
	{
		// Token: 0x040257E8 RID: 153576
		[Nullable(2)]
		public Transform Transform;

		// Token: 0x040257E9 RID: 153577
		public float? Fov;

		// Token: 0x040257EA RID: 153578
		public float? Aperture;

		// Token: 0x040257EB RID: 153579
		public float? FocalLength;

		// Token: 0x040257EC RID: 153580
		public float? FocusDistance;
	}
}
