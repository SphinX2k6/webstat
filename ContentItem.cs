using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FE9 RID: 8169
internal class ContentItem : UiPanelBase
{
	// Token: 0x0600F69C RID: 63132 RVA: 0x00438521 File Offset: 0x00436721
	[NullableContext(1)]
	public ContentItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F69D RID: 63133 RVA: 0x00438538 File Offset: 0x00436738
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F69E RID: 63134 RVA: 0x00438620 File Offset: 0x00436820
	private void ConfirmClick()
	{
		ReputationDetailsData param = new ReputationDetailsData
		{
			InfluenceId = this.InfluenceId,
			CountryId = this.CountryId
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ReputationDetailsView, param, null);
	}

	// Token: 0x0600F69F RID: 63135 RVA: 0x0043865C File Offset: 0x0043685C
	public void UpdateItem(int influenceId, int countryId, EInfluenceRelation relation)
	{
		this.InfluenceId = influenceId;
		this.CountryId = countryId;
		this.UpdateContent();
		this.UpdateState(relation);
	}

	// Token: 0x0600F6A0 RID: 63136 RVA: 0x0043867C File Offset: 0x0043687C
	private void UpdateState(EInfluenceRelation relation)
	{
		UUIButtonComponent button = base.GetButton(1);
		UUIText text = base.GetText(3);
		if (relation == EInfluenceRelation.Belong)
		{
			button.RootUIComp.Get().SetUIActive(false);
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "InfluenceBelongTips", Array.Empty<object>());
			return;
		}
		if (relation == EInfluenceRelation.Hostility)
		{
			button.RootUIComp.Get().SetUIActive(false);
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "InfluenceHostilityTips", Array.Empty<object>());
			return;
		}
		if (relation == EInfluenceRelation.Neutral)
		{
			button.RootUIComp.Get().SetUIActive(true);
			text.SetUIActive(false);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InfluenceReputation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "出现未知关系类型";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Relation", relation);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600F6A1 RID: 63137 RVA: 0x00438754 File Offset: 0x00436954
	private void UpdateContent()
	{
		Influence value = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(this.InfluenceId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Introduction, Array.Empty<object>());
	}

	// Token: 0x0600F6A2 RID: 63138 RVA: 0x00438797 File Offset: 0x00436997
	public void BindRedDot()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.InfluenceReward, base.GetItem(2), null, this.InfluenceId);
	}

	// Token: 0x0400772A RID: 30506
	private int InfluenceId;

	// Token: 0x0400772B RID: 30507
	private int CountryId;

	// Token: 0x02008367 RID: 33639
	private enum EContentItem
	{
		// Token: 0x0402C922 RID: 182562
		Content,
		// Token: 0x0402C923 RID: 182563
		Confirm,
		// Token: 0x0402C924 RID: 182564
		RedDot,
		// Token: 0x0402C925 RID: 182565
		Tips
	}
}
