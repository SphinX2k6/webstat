using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052B3 RID: 21171
	[NullableContext(2)]
	[Nullable(0)]
	public class IQtaPromptResource
	{
		// Token: 0x0401F176 RID: 127350
		public List<long> CueIds;

		// Token: 0x0401F177 RID: 127351
		public EffectScreenPlayData_C ScreenEffect1;

		// Token: 0x0401F178 RID: 127352
		public EffectModelPostProcess ScreenEffect2;

		// Token: 0x0401F179 RID: 127353
		public string ScreenEffect2Path;

		// Token: 0x0401F17A RID: 127354
		public UClass CameraShake;

		// Token: 0x0401F17B RID: 127355
		public UKuroForceFeedbackEffect GamepadShake;

		// Token: 0x0401F17C RID: 127356
		public string Audio;
	}
}
