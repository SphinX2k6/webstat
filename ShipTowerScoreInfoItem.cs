using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D7 RID: 10711
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerScoreInfoItem : GridProxyAbstract<ShipTowerScoreInfoData>
{
	// Token: 0x060155A6 RID: 87462 RVA: 0x005EAE68 File Offset: 0x005E9068
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x060155A7 RID: 87463 RVA: 0x005EAEC4 File Offset: 0x005E90C4
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerScoreInfoItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerScoreInfoItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155A8 RID: 87464 RVA: 0x005EAF07 File Offset: 0x005E9107
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x060155A9 RID: 87465 RVA: 0x005EAF09 File Offset: 0x005E9109
	protected override void OnStart()
	{
	}

	// Token: 0x060155AA RID: 87466 RVA: 0x005EAF0B File Offset: 0x005E910B
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x060155AB RID: 87467 RVA: 0x005EAF10 File Offset: 0x005E9110
	public override void Refresh(ShipTowerScoreInfoData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		base.GetText(0).SetText(this.ItemData.Title, true);
		GenericLayout<ShipTowerScoreTargetItem, ShipTowerScoreTargetData> itemLayout = this.ItemLayout;
		if (itemLayout == null)
		{
			return;
		}
		itemLayout.RefreshByDataAsync(this.ItemData.TargetList, false, null).Forget();
	}

	// Token: 0x060155AC RID: 87468 RVA: 0x005EAF66 File Offset: 0x005E9166
	private ShipTowerScoreTargetItem CreateScoreTargetItem()
	{
		return new ShipTowerScoreTargetItem();
	}

	// Token: 0x0400A478 RID: 42104
	[Nullable(2)]
	private ShipTowerScoreInfoData ItemData;

	// Token: 0x0400A479 RID: 42105
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerScoreTargetItem, ShipTowerScoreTargetData> ItemLayout;

	// Token: 0x02008D40 RID: 36160
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F809 RID: 194569
		public const int TxtTitle = 0;

		// Token: 0x0402F80A RID: 194570
		public const int VLayoutItemList = 1;

		// Token: 0x0402F80B RID: 194571
		public const int ItemItem = 2;
	}
}
