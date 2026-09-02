using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200652B RID: 25899
	public interface IRealmBetweenLevelData
	{
		// Token: 0x17009E92 RID: 40594
		// (get) Token: 0x06040C62 RID: 265314
		// (set) Token: 0x06040C63 RID: 265315
		int Id { get; set; }

		// Token: 0x17009E93 RID: 40595
		// (get) Token: 0x06040C64 RID: 265316
		// (set) Token: 0x06040C65 RID: 265317
		int Level { get; set; }

		// Token: 0x17009E94 RID: 40596
		// (get) Token: 0x06040C66 RID: 265318
		// (set) Token: 0x06040C67 RID: 265319
		int AccumulateExp { get; set; }

		// Token: 0x17009E95 RID: 40597
		// (get) Token: 0x06040C68 RID: 265320
		// (set) Token: 0x06040C69 RID: 265321
		int TargetExp { get; set; }
	}
}
