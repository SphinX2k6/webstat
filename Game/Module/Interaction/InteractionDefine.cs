using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B94 RID: 23444
	public class InteractionDefine
	{
		// Token: 0x040216AC RID: 136876
		public const int LERP_TIME = 500;

		// Token: 0x040216AD RID: 136877
		public const int AUTO_PICKUP_TIME_INTERVAL = 300;

		// Token: 0x040216AE RID: 136878
		public static readonly FName autoPickUpTag = new FName("AutoPickUp");

		// Token: 0x040216AF RID: 136879
		[Nullable(1)]
		public const string BASE_QUALITY_COLOR = "c7c7c7";

		// Token: 0x040216B0 RID: 136880
		public const int INTERACT_GUIDE_MAX_TEXT_WIDTH = 760;
	}
}
