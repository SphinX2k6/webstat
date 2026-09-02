using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FED RID: 8173
internal class InfluenceSearchItem : UiPanelBase
{
	// Token: 0x0600F6BD RID: 63165 RVA: 0x00438E40 File Offset: 0x00437040
	[NullableContext(1)]
	public InfluenceSearchItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F6BE RID: 63166 RVA: 0x00438E58 File Offset: 0x00437058
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F6BF RID: 63167 RVA: 0x00438FC4 File Offset: 0x004371C4
	private void ButtonClick()
	{
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.SearchInfluence, this.InfluenceId, this.CountryId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.InfluenceSearchView, null);
	}

	// Token: 0x0600F6C0 RID: 63168 RVA: 0x00438FF2 File Offset: 0x004371F2
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.InfluenceReward);
	}

	// Token: 0x0600F6C1 RID: 63169 RVA: 0x00439000 File Offset: 0x00437200
	public void UpdateItem(int influenceId, int countryId)
	{
		this.InfluenceId = influenceId;
		this.CountryId = countryId;
		InfluenceInstance influenceInstance = ModelBase<InfluenceReputationModel>.Instance.GetInfluenceInstance(influenceId);
		Influence value = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(influenceInstance.Id).Value;
		base.SetTextureByPath(value.Logo, base.GetTexture(0), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
		UUIText text = base.GetText(2);
		if (!string.IsNullOrEmpty(value.ExtraDesc))
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.ExtraDesc, Array.Empty<object>());
		}
		else
		{
			text.SetUIActive(false);
		}
		this.UpdateState(influenceInstance.Relation);
		this.BindRedDot(influenceInstance.Id);
	}

	// Token: 0x0600F6C2 RID: 63170 RVA: 0x004390D1 File Offset: 0x004372D1
	private void UpdateState(EInfluenceRelation relation)
	{
		base.GetItem(3).SetUIActive(relation == EInfluenceRelation.Neutral);
		base.GetItem(4).SetUIActive(relation == EInfluenceRelation.Hostility);
		base.GetItem(5).SetUIActive(relation == EInfluenceRelation.Belong);
	}

	// Token: 0x0600F6C3 RID: 63171 RVA: 0x00439103 File Offset: 0x00437303
	private void BindRedDot(int influenceId)
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.InfluenceReward, base.GetItem(6), null, influenceId);
	}

	// Token: 0x04007733 RID: 30515
	private int CountryId;

	// Token: 0x04007734 RID: 30516
	private int InfluenceId;

	// Token: 0x0200836B RID: 33643
	private enum EInfluenceSearchItem
	{
		// Token: 0x0402C935 RID: 182581
		Texture,
		// Token: 0x0402C936 RID: 182582
		Name,
		// Token: 0x0402C937 RID: 182583
		Area,
		// Token: 0x0402C938 RID: 182584
		Neutral,
		// Token: 0x0402C939 RID: 182585
		Hostility,
		// Token: 0x0402C93A RID: 182586
		Belong,
		// Token: 0x0402C93B RID: 182587
		RedDot,
		// Token: 0x0402C93C RID: 182588
		Button
	}
}
