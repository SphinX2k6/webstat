using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D09 RID: 7433
public class GachaShareTenPanel : UiPanelBase
{
	// Token: 0x0600DA55 RID: 55893 RVA: 0x003AAE4C File Offset: 0x003A904C
	protected override UniTask OnBeforeStartAsync()
	{
		GachaShareTenPanel.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaShareTenPanel.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA56 RID: 55894 RVA: 0x003AAE90 File Offset: 0x003A9090
	[NullableContext(1)]
	public void Refresh(GachaResult[] dataList)
	{
		List<GachaResult> list = new List<GachaResult>(dataList);
		list.Sort(delegate(GachaResult a, GachaResult b)
		{
			if (a.Proto_GachaReward == null || b.Proto_GachaReward == null)
			{
				return 0;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.Proto_GachaReward.ItemId);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.Proto_GachaReward.ItemId);
			int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			if (num == num2)
			{
				int num3 = GachaShareTenPanel.<Refresh>g__RevertType|3_0(ConfigBase<GachaConfig>.Instance.GetItemIdType(a.Proto_GachaReward.ItemId));
				return GachaShareTenPanel.<Refresh>g__RevertType|3_0(ConfigBase<GachaConfig>.Instance.GetItemIdType(b.Proto_GachaReward.ItemId)) - num3;
			}
			return num2 - num;
		});
		this.GachaResultLayout.RefreshByData(list.ToArray(), null, false);
	}

	// Token: 0x0600DA57 RID: 55895 RVA: 0x003AAEDC File Offset: 0x003A90DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600DA58 RID: 55896 RVA: 0x003AAEFF File Offset: 0x003A90FF
	[NullableContext(2)]
	public UUIGridLayout GetGachaResultItemLayout()
	{
		return base.GetGridLayout(0);
	}

	// Token: 0x0600DA59 RID: 55897 RVA: 0x003AAF08 File Offset: 0x003A9108
	[NullableContext(1)]
	private GachaShareResultItem InitGachaResultItem()
	{
		return new GachaShareResultItem();
	}

	// Token: 0x0600DA5A RID: 55898 RVA: 0x003AAF0F File Offset: 0x003A910F
	protected override void OnBeforeDestroy()
	{
		GenericLayout<GachaShareResultItem, GachaResult> gachaResultLayout = this.GachaResultLayout;
		if (gachaResultLayout == null)
		{
			return;
		}
		gachaResultLayout.ClearChildren();
	}

	// Token: 0x0600DA5C RID: 55900 RVA: 0x003AAF29 File Offset: 0x003A9129
	[CompilerGenerated]
	internal static int <Refresh>g__RevertType|3_0(InventoryDefine.EItemDataType type)
	{
		switch (type)
		{
		case InventoryDefine.EItemDataType.RoleItem:
			return 2;
		case InventoryDefine.EItemDataType.WeaponItem:
			return 1;
		}
		return 0;
	}

	// Token: 0x04006843 RID: 26691
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<GachaShareResultItem, GachaResult> GachaResultLayout;

	// Token: 0x02008080 RID: 32896
	private enum EComponent
	{
		// Token: 0x0402BB5F RID: 179039
		GachaResultGridLayout
	}
}
