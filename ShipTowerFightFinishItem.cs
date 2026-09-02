using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029B5 RID: 10677
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerFightFinishItem : GridProxyAbstract<ShipTowerFightFinishItemData>
{
	// Token: 0x060154C9 RID: 87241 RVA: 0x005E749C File Offset: 0x005E569C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x060154CA RID: 87242 RVA: 0x005E7538 File Offset: 0x005E5738
	public void Refresh(ShipTowerFightFinishItemData data)
	{
		this.ItemData = data;
		int num = data.ScoreA + data.ScoreB;
		base.GetText(0).SetText(num.ToString(), true);
		base.GetText(1).SetText(data.ScoreA.ToString(), true);
		base.GetText(2).SetText(data.ScoreB.ToString(), true);
		base.GetText(3).ShowTextNew(data.TotalTitle);
		base.GetText(4).ShowTextNew(data.TitleA);
		base.GetText(5).ShowTextNew(data.TitleB);
	}

	// Token: 0x060154CB RID: 87243 RVA: 0x005E75D4 File Offset: 0x005E57D4
	public override void Refresh(ShipTowerFightFinishItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0400A42B RID: 42027
	private ShipTowerFightFinishItemData ItemData;

	// Token: 0x02008D0C RID: 36108
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F729 RID: 194345
		public const int TextTotalScore = 0;

		// Token: 0x0402F72A RID: 194346
		public const int TextScoreA = 1;

		// Token: 0x0402F72B RID: 194347
		public const int TextScoreB = 2;

		// Token: 0x0402F72C RID: 194348
		public const int TextTotalTitle = 3;

		// Token: 0x0402F72D RID: 194349
		public const int TextTitleA = 4;

		// Token: 0x0402F72E RID: 194350
		public const int TextTitleB = 5;
	}
}
