using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.CountDown
{
	// Token: 0x02006F23 RID: 28451
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelGamePlayPrepareCountDownViewParams : ILevelGamePlayPrepareCountDownViewParams
	{
		// Token: 0x1700A44A RID: 42058
		// (get) Token: 0x06044E6C RID: 282220 RVA: 0x011EF4E1 File Offset: 0x011ED6E1
		// (set) Token: 0x06044E6D RID: 282221 RVA: 0x011EF4E9 File Offset: 0x011ED6E9
		public int CountDownNum { get; set; }

		// Token: 0x1700A44B RID: 42059
		// (get) Token: 0x06044E6E RID: 282222 RVA: 0x011EF4F2 File Offset: 0x011ED6F2
		// (set) Token: 0x06044E6F RID: 282223 RVA: 0x011EF4FA File Offset: 0x011ED6FA
		public string TidText { get; set; }

		// Token: 0x1700A44C RID: 42060
		// (get) Token: 0x06044E70 RID: 282224 RVA: 0x011EF503 File Offset: 0x011ED703
		// (set) Token: 0x06044E71 RID: 282225 RVA: 0x011EF50B File Offset: 0x011ED70B
		public ECountDownUiStyle? UiStyle { get; set; }
	}
}
