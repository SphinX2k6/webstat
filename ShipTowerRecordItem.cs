using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029C8 RID: 10696
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerRecordItem : GridProxyAbstract<ShipTowerRecordItemData>
{
	// Token: 0x06015538 RID: 87352 RVA: 0x005E8E44 File Offset: 0x005E7044
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUITexture))
		};
	}

	// Token: 0x06015539 RID: 87353 RVA: 0x005E8ECC File Offset: 0x005E70CC
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerRecordItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerRecordItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601553A RID: 87354 RVA: 0x005E8F0F File Offset: 0x005E710F
	public override void Refresh(ShipTowerRecordItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0601553B RID: 87355 RVA: 0x005E8F18 File Offset: 0x005E7118
	public void Refresh(ShipTowerRecordItemData data)
	{
		this.ItemData = data;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(this.ItemData.Title, true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(this.ItemData.Score.ToString(), true);
		}
		UUIText text3 = base.GetText(2);
		if (text3 != null)
		{
			text3.SetText(this.ItemData.Wave.ToString(), true);
		}
		List<ShipTowerMediumItemData> list = (this.ItemData.TeamList != null) ? new List<ShipTowerMediumItemData>(this.ItemData.TeamList) : new List<ShipTowerMediumItemData>();
		list.Add(new ShipTowerMediumItemData
		{
			Id = this.ItemData.BuffId,
			Count = 1,
			IsBuff = new bool?(true),
			SkillBranchId = 0
		});
		GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0601553C RID: 87356 RVA: 0x005E8FFE File Offset: 0x005E71FE
	private ShipTowerMediumItem CreateMediumItem()
	{
		ShipTowerMediumItem shipTowerMediumItem = new ShipTowerMediumItem();
		shipTowerMediumItem.RefreshCallBack = new Action<ShipTowerMediumItemData>(shipTowerMediumItem.RefreshRecord);
		return shipTowerMediumItem;
	}

	// Token: 0x0400A450 RID: 42064
	private ShipTowerRecordItemData ItemData;

	// Token: 0x0400A451 RID: 42065
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> RewardLayout;

	// Token: 0x0400A452 RID: 42066
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerRecordItemData> ClickCallBack;

	// Token: 0x02008D27 RID: 36135
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F792 RID: 194450
		public const int TextName = 0;

		// Token: 0x0402F793 RID: 194451
		public const int TextScore = 1;

		// Token: 0x0402F794 RID: 194452
		public const int TextWave = 2;

		// Token: 0x0402F795 RID: 194453
		public const int HLayoutTeam = 3;

		// Token: 0x0402F796 RID: 194454
		public const int TextureBuffIcon = 4;
	}
}
