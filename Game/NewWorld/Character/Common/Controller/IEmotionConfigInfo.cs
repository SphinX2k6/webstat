using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048ED RID: 18669
	[NullableContext(1)]
	[Nullable(0)]
	public class IEmotionConfigInfo : IEmotionBubbleConfig
	{
		// Token: 0x0401C037 RID: 114743
		public string EmotionName = string.Empty;

		// Token: 0x0401C038 RID: 114744
		public List<int> TagList = new List<int>();
	}
}
