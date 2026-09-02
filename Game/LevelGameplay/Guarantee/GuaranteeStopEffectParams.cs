using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E68 RID: 28264
	[NullableContext(2)]
	[Nullable(0)]
	public class GuaranteeStopEffectParams : ActionParams, IGuaranteeStopEffectParams
	{
		// Token: 0x1700A394 RID: 41876
		// (get) Token: 0x06044964 RID: 280932 RVA: 0x011D4C64 File Offset: 0x011D2E64
		// (set) Token: 0x06044965 RID: 280933 RVA: 0x011D4C6C File Offset: 0x011D2E6C
		public int? EffectId { get; set; }

		// Token: 0x1700A395 RID: 41877
		// (get) Token: 0x06044966 RID: 280934 RVA: 0x011D4C75 File Offset: 0x011D2E75
		// (set) Token: 0x06044967 RID: 280935 RVA: 0x011D4C7D File Offset: 0x011D2E7D
		public int? ScreenEffectHandle { get; set; }

		// Token: 0x1700A396 RID: 41878
		// (get) Token: 0x06044968 RID: 280936 RVA: 0x011D4C86 File Offset: 0x011D2E86
		// (set) Token: 0x06044969 RID: 280937 RVA: 0x011D4C8E File Offset: 0x011D2E8E
		public string Mp4Name { get; set; }
	}
}
