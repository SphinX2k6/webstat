using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002813 RID: 10259
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevPhantomSuitItem : GridProxyAbstract<RoleDevPhantomSuitItemData>
{
	// Token: 0x060143F2 RID: 82930 RVA: 0x005A2BDC File Offset: 0x005A0DDC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUILayoutBase))
		};
	}

	// Token: 0x060143F3 RID: 82931 RVA: 0x005A2C4C File Offset: 0x005A0E4C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevPhantomSuitItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevPhantomSuitItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060143F4 RID: 82932 RVA: 0x005A2C90 File Offset: 0x005A0E90
	private UniTask InitItems()
	{
		RoleDevPhantomSuitItem.<InitItems>d__6 <InitItems>d__;
		<InitItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitItems>d__.<>4__this = this;
		<InitItems>d__.<>1__state = -1;
		<InitItems>d__.<>t__builder.Start<RoleDevPhantomSuitItem.<InitItems>d__6>(ref <InitItems>d__);
		return <InitItems>d__.<>t__builder.Task;
	}

	// Token: 0x060143F5 RID: 82933 RVA: 0x005A2CD4 File Offset: 0x005A0ED4
	public override void Refresh(RoleDevPhantomSuitItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentRoleId = data.RoleId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.SuitName, Array.Empty<object>());
		if (data.UseRate > 0)
		{
			base.GetText(2).SetUIActive(true);
			base.GetText(2).SetText(data.UseRateText, true);
		}
		else
		{
			base.GetText(2).SetUIActive(false);
		}
		this.RefreshElementIcon(data);
		this.RefreshVisionSuitItems(data);
	}

	// Token: 0x060143F6 RID: 82934 RVA: 0x005A2D50 File Offset: 0x005A0F50
	private void RefreshElementIcon(RoleDevPhantomSuitItemData data)
	{
		UUIItem item = base.GetItem(0);
		if (item != null && this.ElementSuitItem != null)
		{
			item.SetUIActive(data.HasElementIcon);
			if (data.HasElementIcon && data.FetterGroupConfig != null)
			{
				this.ElementSuitItem.Update(data.FetterGroupConfig);
				this.ElementSuitItem.SetUiActive(true);
			}
		}
	}

	// Token: 0x060143F7 RID: 82935 RVA: 0x005A2DB4 File Offset: 0x005A0FB4
	private void RefreshVisionSuitItems(RoleDevPhantomSuitItemData data)
	{
		List<RoleDevPhantomVisionSuitItemData> list = new List<RoleDevPhantomVisionSuitItemData>();
		RoleDevPhantomFetterGroupData roleDevPhantomFetterGroupData = new RoleDevPhantomFetterGroupData();
		roleDevPhantomFetterGroupData.InitByFetterGroup(data.SuitId, this.CurrentRoleId, data.RecommendGroupIds);
		list.Add(roleDevPhantomFetterGroupData);
		foreach (int dungeonId in data.DungeonIdList)
		{
			RoleDevPhantomDungeonData roleDevPhantomDungeonData = new RoleDevPhantomDungeonData();
			roleDevPhantomDungeonData.InitByDungeon(dungeonId);
			list.Add(roleDevPhantomDungeonData);
		}
		GenericLayout<RoleDevPhantomVisionSuitItem, RoleDevPhantomVisionSuitItemData> visionSuitItemLayout = this.VisionSuitItemLayout;
		if (visionSuitItemLayout == null)
		{
			return;
		}
		visionSuitItemLayout.RefreshByData(list, null, false);
	}

	// Token: 0x060143F8 RID: 82936 RVA: 0x005A2E58 File Offset: 0x005A1058
	public override object GetKey(RoleDevPhantomSuitItemData data, int gridIndex)
	{
		return data.SuitId;
	}

	// Token: 0x060143F9 RID: 82937 RVA: 0x005A2E65 File Offset: 0x005A1065
	private RoleDevPhantomVisionSuitItem CreateVisionSuitItem()
	{
		return new RoleDevPhantomVisionSuitItem();
	}

	// Token: 0x04009D87 RID: 40327
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevPhantomVisionSuitItem, RoleDevPhantomVisionSuitItemData> VisionSuitItemLayout;

	// Token: 0x04009D88 RID: 40328
	[Nullable(2)]
	private VisionFetterSuitItem ElementSuitItem;

	// Token: 0x04009D89 RID: 40329
	private int CurrentRoleId;

	// Token: 0x02008B9B RID: 35739
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F0C8 RID: 192712
		PanelElementIcon,
		// Token: 0x0402F0C9 RID: 192713
		TxtSuitName,
		// Token: 0x0402F0CA RID: 192714
		TxtUseRate,
		// Token: 0x0402F0CB RID: 192715
		PanelVisionSuitLayout
	}
}
