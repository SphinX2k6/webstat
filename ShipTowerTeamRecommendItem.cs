using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029E3 RID: 10723
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerTeamRecommendItem : GridProxyAbstract<ShipTowerTeamRecommendItemData>
{
	// Token: 0x060155F8 RID: 87544 RVA: 0x005EC360 File Offset: 0x005EA560
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x060155F9 RID: 87545 RVA: 0x005EC3E8 File Offset: 0x005EA5E8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerTeamRecommendItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerTeamRecommendItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155FA RID: 87546 RVA: 0x005EC42B File Offset: 0x005EA62B
	protected override void OnStart()
	{
	}

	// Token: 0x060155FB RID: 87547 RVA: 0x005EC430 File Offset: 0x005EA630
	public override void Refresh(ShipTowerTeamRecommendItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		List<ShipTowerMediumItemData> list = new List<ShipTowerMediumItemData>();
		for (int i = 0; i < data.RoleIdList1.Count; i++)
		{
			list.Add(data.RoleIdList1[i]);
		}
		list.Add(new ShipTowerMediumItemData
		{
			Id = data.Buff1,
			Count = 1,
			IsBuff = new bool?(true),
			SkillBranchId = 0
		});
		List<ShipTowerMediumItemData> list2 = new List<ShipTowerMediumItemData>();
		for (int j = 0; j < data.RoleIdList2.Count; j++)
		{
			list2.Add(data.RoleIdList2[j]);
		}
		list2.Add(new ShipTowerMediumItemData
		{
			Id = data.Buff2,
			Count = 1,
			IsBuff = new bool?(true),
			SkillBranchId = 0
		});
		GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> layoutTeam = this.LayoutTeam1;
		if (layoutTeam != null)
		{
			layoutTeam.RefreshByData(list, null, false);
		}
		GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> layoutTeam2 = this.LayoutTeam2;
		if (layoutTeam2 != null)
		{
			layoutTeam2.RefreshByData(list2, null, false);
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(data.Name, true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			text2.SetText(data.UseRate.ToString() + "%", true);
		}
		bool enableClick = this.ItemData.StageData != null && this.ItemData.StageData.IsCanApplyTeamRecommend(this.ItemData);
		this.BtnUse.SetEnableClick(enableClick);
	}

	// Token: 0x060155FC RID: 87548 RVA: 0x005EC5A3 File Offset: 0x005EA7A3
	private void OnClickUse()
	{
		Action<ShipTowerTeamRecommendItemData> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.ItemData);
	}

	// Token: 0x060155FD RID: 87549 RVA: 0x005EC5BB File Offset: 0x005EA7BB
	private ShipTowerMediumItem CreateRecommendRoleItem()
	{
		ShipTowerMediumItem shipTowerMediumItem = new ShipTowerMediumItem();
		shipTowerMediumItem.RefreshCallBack = new Action<ShipTowerMediumItemData>(shipTowerMediumItem.RefreshRecommend);
		shipTowerMediumItem.GetStageIdCallback = new Func<int?>(this.GetStageIdCallback);
		return shipTowerMediumItem;
	}

	// Token: 0x060155FE RID: 87550 RVA: 0x005EC5E8 File Offset: 0x005EA7E8
	private int? GetStageIdCallback()
	{
		ShipTowerStageData stageData = this.ItemData.StageData;
		if (stageData == null)
		{
			return null;
		}
		return new int?(stageData.Id);
	}

	// Token: 0x0400A493 RID: 42131
	private ShipTowerTeamRecommendItemData ItemData;

	// Token: 0x0400A494 RID: 42132
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> LayoutTeam1;

	// Token: 0x0400A495 RID: 42133
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerMediumItem, ShipTowerMediumItemData> LayoutTeam2;

	// Token: 0x0400A496 RID: 42134
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerTeamRecommendItemData> ClickCallBack;

	// Token: 0x0400A497 RID: 42135
	[Nullable(2)]
	private ButtonItem BtnUse;

	// Token: 0x02008D54 RID: 36180
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F865 RID: 194661
		public const int TextName = 0;

		// Token: 0x0402F866 RID: 194662
		public const int TextUseRate = 1;

		// Token: 0x0402F867 RID: 194663
		public const int HLayoutTeam1 = 2;

		// Token: 0x0402F868 RID: 194664
		public const int HLayoutTeam2 = 3;

		// Token: 0x0402F869 RID: 194665
		public const int BtnUse = 4;
	}
}
