using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Point
{
	// Token: 0x02006E51 RID: 28241
	public class ItemInspectPoint
	{
		// Token: 0x0402629B RID: 156315
		public bool IsActive;

		// Token: 0x0402629C RID: 156316
		public bool IsValid;

		// Token: 0x0402629D RID: 156317
		public bool IsChecked;

		// Token: 0x0402629E RID: 156318
		public int TagId;

		// Token: 0x0402629F RID: 156319
		public bool CancelTrace;

		// Token: 0x040262A0 RID: 156320
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IInteractEffect> EffectConfigs;

		// Token: 0x040262A1 RID: 156321
		public float ProtectTime;

		// Token: 0x040262A2 RID: 156322
		[Nullable(2)]
		public IInteractPointInteraction InteractionConfig;
	}
}
