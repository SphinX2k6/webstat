using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E80 RID: 7808
[NullableContext(2)]
[Nullable(0)]
public class HandBookQuestPlotList : UiPanelBase, IDynamicScrollItem<HandBookPlotDynamicData>
{
	// Token: 0x0600E6D7 RID: 59095 RVA: 0x003E4BD4 File Offset: 0x003E2DD4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600E6D8 RID: 59096 RVA: 0x003E4C44 File Offset: 0x003E2E44
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		HandBookQuestPlotList.<Init>d__8 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<HandBookQuestPlotList.<Init>d__8>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E6D9 RID: 59097 RVA: 0x003E4C90 File Offset: 0x003E2E90
	private UniTask InitChildItem()
	{
		HandBookQuestPlotList.<InitChildItem>d__9 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<HandBookQuestPlotList.<InitChildItem>d__9>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600E6DA RID: 59098 RVA: 0x003E4CD4 File Offset: 0x003E2ED4
	[NullableContext(1)]
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(HandBookPlotDynamicData data)
	{
		if (data.TalkOption != null)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
		if (data.OptionTalker.GetValueOrDefault())
		{
			return base.GetItem(3).GetOwner() as AUIBaseActor;
		}
		if (!string.IsNullOrEmpty(data.NodeText))
		{
			return base.GetItem(2).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(0).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600E6DB RID: 59099 RVA: 0x003E4D4C File Offset: 0x003E2F4C
	[NullableContext(1)]
	public void Update(HandBookPlotDynamicData data, int index)
	{
		this.OptionData = data;
		HandBookQuestPlotTalkItem handBookQuestPlotTalkItem = this.HandBookQuestPlotTalkItem;
		if (handBookQuestPlotTalkItem != null)
		{
			handBookQuestPlotTalkItem.SetUiActive(false);
		}
		HandBookQuestPlotOption handBookQuestPlotOption = this.HandBookQuestPlotOption;
		if (handBookQuestPlotOption != null)
		{
			handBookQuestPlotOption.SetUiActive(false);
		}
		HandBookQuestPlotNode handBookQuestPlotNode = this.HandBookQuestPlotNode;
		if (handBookQuestPlotNode != null)
		{
			handBookQuestPlotNode.SetUiActive(false);
		}
		HandBookQuestPlotOptionTalker handBookQuestPlotOptionTalker = this.HandBookQuestPlotOptionTalker;
		if (handBookQuestPlotOptionTalker != null)
		{
			handBookQuestPlotOptionTalker.SetUiActive(false);
		}
		if (!string.IsNullOrEmpty(data.NodeText))
		{
			HandBookQuestPlotNode handBookQuestPlotNode2 = this.HandBookQuestPlotNode;
			if (handBookQuestPlotNode2 != null)
			{
				handBookQuestPlotNode2.SetUiActive(true);
			}
			HandBookQuestPlotNode handBookQuestPlotNode3 = this.HandBookQuestPlotNode;
			if (handBookQuestPlotNode3 != null)
			{
				handBookQuestPlotNode3.RefreshByNodeText(data.NodeText);
			}
		}
		else if (data.TalkOption != null)
		{
			HandBookQuestPlotOption handBookQuestPlotOption2 = this.HandBookQuestPlotOption;
			if (handBookQuestPlotOption2 != null)
			{
				handBookQuestPlotOption2.SetUiActive(true);
			}
			this.HandBookQuestPlotOption.RefreshByOption(data.TalkOption, data.PlotId, data.TalkItemId, data.OptionIndex.GetValueOrDefault(), data.IsChoseOption.GetValueOrDefault());
		}
		else if (data.OptionTalker.GetValueOrDefault())
		{
			HandBookQuestPlotOptionTalker handBookQuestPlotOptionTalker2 = this.HandBookQuestPlotOptionTalker;
			if (handBookQuestPlotOptionTalker2 != null)
			{
				handBookQuestPlotOptionTalker2.SetUiActive(true);
			}
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			string str = ConfigMultiTextLang.GetLocalTextNew("ColonTag", null) ?? "";
			string title = (playerName != "") ? (playerName + str + " ") : "";
			HandBookQuestPlotOptionTalker handBookQuestPlotOptionTalker3 = this.HandBookQuestPlotOptionTalker;
			if (handBookQuestPlotOptionTalker3 != null)
			{
				handBookQuestPlotOptionTalker3.RefreshByText(title);
			}
		}
		else
		{
			HandBookQuestPlotTalkItem handBookQuestPlotTalkItem2 = this.HandBookQuestPlotTalkItem;
			if (handBookQuestPlotTalkItem2 != null)
			{
				handBookQuestPlotTalkItem2.SetUiActive(true);
			}
			this.HandBookQuestPlotTalkItem.Refresh(data.TalkOwnerName, data.TalkText, data.PlotAudio);
		}
		if (this.OnRefreshNode != null)
		{
			this.OnRefreshNode(data.BelongToNode);
		}
	}

	// Token: 0x0600E6DC RID: 59100 RVA: 0x003E4EF4 File Offset: 0x003E30F4
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600E6DD RID: 59101 RVA: 0x003E4EFD File Offset: 0x003E30FD
	[NullableContext(1)]
	public void BindClickOptionToggleBack(TSelectedOpenCallback onClickToggle)
	{
		this.OnClickOptionToggleBack = onClickToggle;
	}

	// Token: 0x0600E6DE RID: 59102 RVA: 0x003E4F06 File Offset: 0x003E3106
	[NullableContext(1)]
	public void BindOnRefreshNode(TRefreshNode func)
	{
		this.OnRefreshNode = func;
	}

	// Token: 0x0600E6DF RID: 59103 RVA: 0x003E4F0F File Offset: 0x003E310F
	public UUIExtendToggle GetOptionToggle()
	{
		HandBookQuestPlotOption handBookQuestPlotOption = this.HandBookQuestPlotOption;
		if (handBookQuestPlotOption == null)
		{
			return null;
		}
		return handBookQuestPlotOption.Toggle;
	}

	// Token: 0x04006F51 RID: 28497
	private HandBookQuestPlotTalkItem HandBookQuestPlotTalkItem;

	// Token: 0x04006F52 RID: 28498
	private HandBookQuestPlotOption HandBookQuestPlotOption;

	// Token: 0x04006F53 RID: 28499
	private HandBookQuestPlotNode HandBookQuestPlotNode;

	// Token: 0x04006F54 RID: 28500
	private HandBookQuestPlotOptionTalker HandBookQuestPlotOptionTalker;

	// Token: 0x04006F55 RID: 28501
	private TSelectedOpenCallback OnClickOptionToggleBack;

	// Token: 0x04006F56 RID: 28502
	private TRefreshNode OnRefreshNode;

	// Token: 0x04006F57 RID: 28503
	public HandBookPlotDynamicData OptionData;
}
