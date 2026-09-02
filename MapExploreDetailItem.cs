using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.VillageInfr;
using UnrealEngine;

// Token: 0x02001B95 RID: 7061
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MapExploreDetailItem : GridProxyAbstract<ExploreAreaItemData>
{
	// Token: 0x0600CD4E RID: 52558 RVA: 0x0036A5F8 File Offset: 0x003687F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleRoot));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CD4F RID: 52559 RVA: 0x0036A744 File Offset: 0x00368944
	public override void Refresh(ExploreAreaItemData data, bool isSelected, int gridIndex)
	{
		bool flag = data.IsUnlocked();
		UUIText text = base.GetText(4);
		UUIText text2 = base.GetText(3);
		this.AreaItemData = data;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null)
		{
			sprite.SetUIActive(flag);
		}
		text2.SetUIActive(flag);
		if (flag)
		{
			this.SetSpriteByPath(data.Icon, base.GetSprite(2), false, null, null);
			text.ShowTextNew(data.GetNameId());
			if (data.IsPercent())
			{
				UUIText uuitext = text2;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetProgress());
				defaultInterpolatedStringHandler.AppendLiteral("%");
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			else
			{
				UUIText uuitext2 = text2;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetCurrentCount());
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetTotalCount());
				uuitext2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			bool flag2 = data.IsCompleted();
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag2;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUIItem uuiitem2 = text2;
			bool bUseChangeColor2 = flag2;
			fcolor = new FColor?(text2.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		}
		else
		{
			text.ShowTextNew(data.LockDescId);
			UUIItem uuiitem3 = text;
			bool bUseChangeColor3 = false;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
		}
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		this.RefreshVillageInfrTag();
	}

	// Token: 0x0600CD50 RID: 52560 RVA: 0x0036A8C8 File Offset: 0x00368AC8
	private void RefreshVillageInfrTag()
	{
		ExploreProgress? exploreProgressConfigById = ConfigBase<ExploreProgressConfig>.Instance.GetExploreProgressConfigById(this.AreaItemData.ConfigId);
		base.GetItem(5).SetUIActive(false);
		if (exploreProgressConfigById == null)
		{
			return;
		}
		if (exploreProgressConfigById.Value.TagType != 1)
		{
			return;
		}
		InfrV2TreeBuild? treeConfigByAreaId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByAreaId(this.AreaItemData.AreaId);
		if (treeConfigByAreaId == null)
		{
			return;
		}
		IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(treeConfigByAreaId.Value.Id);
		if (treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete)
		{
			return;
		}
		base.GetItem(5).SetUIActive(true);
		base.GetText(6).ShowTextNew("VillageInfr_Tag");
	}

	// Token: 0x0600CD51 RID: 52561 RVA: 0x0036A97E File Offset: 0x00368B7E
	private void OnToggleRoot(EToggleState toggleState)
	{
		if (toggleState == EToggleState.ETT_Checked)
		{
			IScrollViewDelegate<IGridProxy<ExploreAreaItemData>, ExploreAreaItemData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
	}

	// Token: 0x0600CD52 RID: 52562 RVA: 0x0036A9A1 File Offset: 0x00368BA1
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		Singleton<EventSystem>.Instance.Emit<ExploreAreaItemData>(EEventName.MapExploreDetailItemClick, this.AreaItemData);
	}

	// Token: 0x0600CD53 RID: 52563 RVA: 0x0036A9D0 File Offset: 0x00368BD0
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600CD54 RID: 52564 RVA: 0x0036A9E8 File Offset: 0x00368BE8
	public UUIItem GetBtnRootItem()
	{
		return base.GetExtendToggle(0).RootUIComp;
	}

	// Token: 0x0400621C RID: 25116
	private ExploreAreaItemData AreaItemData;

	// Token: 0x02007E7A RID: 32378
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B151 RID: 176465
		RootToggle,
		// Token: 0x0402B152 RID: 176466
		LockIcon,
		// Token: 0x0402B153 RID: 176467
		Icon,
		// Token: 0x0402B154 RID: 176468
		Percent,
		// Token: 0x0402B155 RID: 176469
		Name,
		// Token: 0x0402B156 RID: 176470
		PanelVillageInfrTag,
		// Token: 0x0402B157 RID: 176471
		TextInfrTag
	}
}
