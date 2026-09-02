using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E2A RID: 28202
	[NullableContext(1)]
	[Nullable(0)]
	internal class TurnAndPlayMontageParam : ActionParams
	{
		// Token: 0x1700A36A RID: 41834
		// (get) Token: 0x06044739 RID: 280377 RVA: 0x011C89E9 File Offset: 0x011C6BE9
		// (set) Token: 0x0604473A RID: 280378 RVA: 0x011C89F1 File Offset: 0x011C6BF1
		public int EntityId { get; set; }

		// Token: 0x1700A36B RID: 41835
		// (get) Token: 0x0604473B RID: 280379 RVA: 0x011C89FA File Offset: 0x011C6BFA
		// (set) Token: 0x0604473C RID: 280380 RVA: 0x011C8A02 File Offset: 0x011C6C02
		public IVector Pos { get; set; }

		// Token: 0x1700A36C RID: 41836
		// (get) Token: 0x0604473D RID: 280381 RVA: 0x011C8A0B File Offset: 0x011C6C0B
		// (set) Token: 0x0604473E RID: 280382 RVA: 0x011C8A13 File Offset: 0x011C6C13
		public int MontageId { get; set; }

		// Token: 0x1700A36D RID: 41837
		// (get) Token: 0x0604473F RID: 280383 RVA: 0x011C8A1C File Offset: 0x011C6C1C
		// (set) Token: 0x06044740 RID: 280384 RVA: 0x011C8A24 File Offset: 0x011C6C24
		public bool? IsAbpMontage { get; set; }

		// Token: 0x1700A36E RID: 41838
		// (get) Token: 0x06044741 RID: 280385 RVA: 0x011C8A2D File Offset: 0x011C6C2D
		// (set) Token: 0x06044742 RID: 280386 RVA: 0x011C8A35 File Offset: 0x011C6C35
		public float LoopDuration { get; set; }

		// Token: 0x1700A36F RID: 41839
		// (get) Token: 0x06044743 RID: 280387 RVA: 0x011C8A3E File Offset: 0x011C6C3E
		// (set) Token: 0x06044744 RID: 280388 RVA: 0x011C8A46 File Offset: 0x011C6C46
		public int RepeatTimes { get; set; }
	}
}
