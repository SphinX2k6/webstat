using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D9 RID: 10713
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerShareLineupItem : GridProxyAbstract<ShipTowerRecordItemData>
{
	// Token: 0x060155B8 RID: 87480 RVA: 0x005EB150 File Offset: 0x005E9350
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x060155B9 RID: 87481 RVA: 0x005EB1D8 File Offset: 0x005E93D8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerShareLineupItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerShareLineupItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155BA RID: 87482 RVA: 0x005EB21C File Offset: 0x005E941C
	public override void Refresh(ShipTowerRecordItemData data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(data.Title, true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(data.Score.ToString(), true);
		}
		UUIText text3 = base.GetText(2);
		if (text3 != null)
		{
			text3.SetText(data.Wave.ToString(), true);
		}
		List<ShipTowerMediumItemData> data2 = new List<ShipTowerMediumItemData>(data.TeamList)
		{
			new ShipTowerMediumItemData
			{
				Id = data.BuffId,
				Count = 1,
				IsBuff = new bool?(true),
				SkillBranchId = 0
			}
		};
		GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> roleLayout = this.RoleLayout;
		if (roleLayout == null)
		{
			return;
		}
		roleLayout.RefreshByData(data2, null, false);
	}

	// Token: 0x060155BB RID: 87483 RVA: 0x005EB2CE File Offset: 0x005E94CE
	private ShipTowerMediumItem CreateRoleItem()
	{
		ShipTowerMediumItem shipTowerMediumItem = new ShipTowerMediumItem();
		shipTowerMediumItem.RefreshCallBack = new Action<ShipTowerMediumItemData>(shipTowerMediumItem.RefreshRecord);
		return shipTowerMediumItem;
	}

	// Token: 0x0400A47B RID: 42107
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> RoleLayout;

	// Token: 0x02008D44 RID: 36164
	[NullableContext(0)]
	private enum ELineupItemComponent
	{
		// Token: 0x0402F81B RID: 194587
		TitleText,
		// Token: 0x0402F81C RID: 194588
		NumOneText,
		// Token: 0x0402F81D RID: 194589
		NumTwoText,
		// Token: 0x0402F81E RID: 194590
		PnHor,
		// Token: 0x0402F81F RID: 194591
		RoleItem
	}
}
