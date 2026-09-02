using System;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C1D RID: 23581
	public class InstanceDungeonExitConfirmBoxData : IInstanceDungeonExitConfirmBoxData
	{
		// Token: 0x170097CD RID: 38861
		// (get) Token: 0x0603B9F4 RID: 244212 RVA: 0x00F1BA5C File Offset: 0x00F19C5C
		// (set) Token: 0x0603B9F5 RID: 244213 RVA: 0x00F1BA64 File Offset: 0x00F19C64
		public EInstanceDungeonExitConfirmBoxParseRule ParseRuleType { get; set; }

		// Token: 0x170097CE RID: 38862
		// (get) Token: 0x0603B9F6 RID: 244214 RVA: 0x00F1BA6D File Offset: 0x00F19C6D
		// (set) Token: 0x0603B9F7 RID: 244215 RVA: 0x00F1BA75 File Offset: 0x00F19C75
		public int? UnfinishedBoxId { get; set; }

		// Token: 0x170097CF RID: 38863
		// (get) Token: 0x0603B9F8 RID: 244216 RVA: 0x00F1BA7E File Offset: 0x00F19C7E
		// (set) Token: 0x0603B9F9 RID: 244217 RVA: 0x00F1BA86 File Offset: 0x00F19C86
		public int? FinishBoxId { get; set; }

		// Token: 0x170097D0 RID: 38864
		// (get) Token: 0x0603B9FA RID: 244218 RVA: 0x00F1BA8F File Offset: 0x00F19C8F
		// (set) Token: 0x0603B9FB RID: 244219 RVA: 0x00F1BA97 File Offset: 0x00F19C97
		public int? UnfinishedTelBoxId { get; set; }

		// Token: 0x170097D1 RID: 38865
		// (get) Token: 0x0603B9FC RID: 244220 RVA: 0x00F1BAA0 File Offset: 0x00F19CA0
		// (set) Token: 0x0603B9FD RID: 244221 RVA: 0x00F1BAA8 File Offset: 0x00F19CA8
		public int? FinishTelBoxId { get; set; }
	}
}
