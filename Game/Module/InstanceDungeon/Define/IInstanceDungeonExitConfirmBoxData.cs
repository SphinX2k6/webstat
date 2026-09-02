using System;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C1C RID: 23580
	public interface IInstanceDungeonExitConfirmBoxData
	{
		// Token: 0x170097C8 RID: 38856
		// (get) Token: 0x0603B9EA RID: 244202
		// (set) Token: 0x0603B9EB RID: 244203
		EInstanceDungeonExitConfirmBoxParseRule ParseRuleType { get; set; }

		// Token: 0x170097C9 RID: 38857
		// (get) Token: 0x0603B9EC RID: 244204
		// (set) Token: 0x0603B9ED RID: 244205
		int? UnfinishedBoxId { get; set; }

		// Token: 0x170097CA RID: 38858
		// (get) Token: 0x0603B9EE RID: 244206
		// (set) Token: 0x0603B9EF RID: 244207
		int? FinishBoxId { get; set; }

		// Token: 0x170097CB RID: 38859
		// (get) Token: 0x0603B9F0 RID: 244208
		// (set) Token: 0x0603B9F1 RID: 244209
		int? UnfinishedTelBoxId { get; set; }

		// Token: 0x170097CC RID: 38860
		// (get) Token: 0x0603B9F2 RID: 244210
		// (set) Token: 0x0603B9F3 RID: 244211
		int? FinishTelBoxId { get; set; }
	}
}
