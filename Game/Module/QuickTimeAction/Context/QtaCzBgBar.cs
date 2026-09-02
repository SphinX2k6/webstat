using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052BD RID: 21181
	[NullableContext(1)]
	[Nullable(0)]
	public class QtaCzBgBar
	{
		// Token: 0x06036252 RID: 221778 RVA: 0x00DA3248 File Offset: 0x00DA1448
		public void InitByConfig(SQtaCustomizationParam_BgBar cfg)
		{
			this.CzProgress.InitByConfig(cfg.Progress, EQtaCustomization_ProgressResetType.停止);
			this.Anchor = new FLinearColor?(cfg.Anchor);
			this.Angle = cfg.Angle;
		}

		// Token: 0x0401F1B2 RID: 127410
		public QtaCzProgress CzProgress = new QtaCzProgress();

		// Token: 0x0401F1B3 RID: 127411
		public FLinearColor? Anchor;

		// Token: 0x0401F1B4 RID: 127412
		public float Angle;
	}
}
