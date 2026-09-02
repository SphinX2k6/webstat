using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B58 RID: 11096
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsTalentTreeSkillInfoPanel : UiPanelBase
{
	// Token: 0x06016200 RID: 90624 RVA: 0x00623E88 File Offset: 0x00622088
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
	}

	// Token: 0x06016201 RID: 90625 RVA: 0x00624008 File Offset: 0x00622208
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsTalentTreeSkillInfoPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsTalentTreeSkillInfoPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016202 RID: 90626 RVA: 0x0062404B File Offset: 0x0062224B
	private SurvivorsTalentTreeMediumItemGrid InitGridItem()
	{
		return new SurvivorsTalentTreeMediumItemGrid();
	}

	// Token: 0x06016203 RID: 90627 RVA: 0x00624054 File Offset: 0x00622254
	public UniTask RefreshAsync(SurvivorsTalentNode talentNode)
	{
		SurvivorsTalentTreeSkillInfoPanel.<RefreshAsync>d__8 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.talentNode = talentNode;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SurvivorsTalentTreeSkillInfoPanel.<RefreshAsync>d__8>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016204 RID: 90628 RVA: 0x006240A0 File Offset: 0x006222A0
	private void OnClickConfirmBtn(int _)
	{
		if (!this.CostItem.IsEnough)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsTalentTreeNotEnough", Array.Empty<object>());
			return;
		}
		SurvivorsTalentEffect? effectConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetTalentTreeEffect(this.TalentNode.EffectId);
		if (effectConfig == null)
		{
			return;
		}
		ControllerBase<SurvivorsActivityController>.Instance.SurvivorsTalentLevelUpRequest(this.TalentNode.NodeId, delegate
		{
			if (effectConfig.Value.ShowType == 1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsTalentTreeUnlocked", Array.Empty<object>());
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsTalentUnlockView, effectConfig, null);
		});
	}

	// Token: 0x0400AAC8 RID: 43720
	private SurvivorsTalentNode TalentNode;

	// Token: 0x0400AAC9 RID: 43721
	[Nullable(2)]
	private ButtonItem ConfirmBtnItem;

	// Token: 0x0400AACA RID: 43722
	private CommonCostItem CostItem;

	// Token: 0x0400AACB RID: 43723
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SurvivorsTalentTreeMediumItemGrid, int> ItemLayout;

	// Token: 0x0400AACC RID: 43724
	[Nullable(2)]
	private FunctionalPanelConditionLock LockTipsItem;
}
