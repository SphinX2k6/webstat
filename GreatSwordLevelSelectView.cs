using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E15 RID: 7701
[NullableContext(1)]
[Nullable(0)]
public class GreatSwordLevelSelectView : UiViewBase
{
	// Token: 0x0600E359 RID: 58201 RVA: 0x003D35FB File Offset: 0x003D17FB
	public GreatSwordLevelSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E35A RID: 58202 RVA: 0x003D360F File Offset: 0x003D180F
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<ITrialSubChallenge>>(EEventName.GreatSwordLevelRefreshUI, new Action<IReadOnlyList<ITrialSubChallenge>>(this.OnRefreshChallengeUI));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.GreatSwordLevelSelectedComplete, new Action<int, int>(this.OnChallengeConfirmed));
	}

	// Token: 0x0600E35B RID: 58203 RVA: 0x003D3649 File Offset: 0x003D1849
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GreatSwordLevelRefreshUI, new Action<IReadOnlyList<ITrialSubChallenge>>(this.OnRefreshChallengeUI));
		Singleton<EventSystem>.Instance.Remove(EEventName.GreatSwordLevelSelectedComplete, new Action<int, int>(this.OnChallengeConfirmed));
	}

	// Token: 0x0600E35C RID: 58204 RVA: 0x003D3684 File Offset: 0x003D1884
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0600E35D RID: 58205 RVA: 0x003D3788 File Offset: 0x003D1988
	protected override UniTask OnBeforeStartAsync()
	{
		GreatSwordLevelSelectView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GreatSwordLevelSelectView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E35E RID: 58206 RVA: 0x003D37CB File Offset: 0x003D19CB
	protected override void OnStart()
	{
		this.BindStaticUiData();
	}

	// Token: 0x0600E35F RID: 58207 RVA: 0x003D37D4 File Offset: 0x003D19D4
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		int levelIndex = (ModelBase<GreatSwordChallengeModel>.Instance.GetSubChallenges() ?? new List<TrialSubChallenge>()).FindAll((TrialSubChallenge subChallenge) => subChallenge.Unlocked).Count - 1;
		this.OnClickTrialLevelItem(levelIndex);
	}

	// Token: 0x0600E360 RID: 58208 RVA: 0x003D382D File Offset: 0x003D1A2D
	protected override void OnAfterDestroy()
	{
		ControllerBase<GeneralLogicTreeController>.Instance.OpenSystemBoardResultRequest(ModelBase<GreatSwordChallengeModel>.Instance.GetIsStartChallenge() ? 2 : 0, ModelBase<GreatSwordChallengeModel>.Instance.GetActionIncId());
		ModelBase<GreatSwordChallengeModel>.Instance.ClearData();
	}

	// Token: 0x0600E361 RID: 58209 RVA: 0x003D385D File Offset: 0x003D1A5D
	private void RefreshView()
	{
		this.RefreshTrialLevels();
		this.RefreshChallengeGoals();
		this.RefreshTopDescription();
	}

	// Token: 0x0600E362 RID: 58210 RVA: 0x003D3874 File Offset: 0x003D1A74
	private void BindStaticUiData()
	{
		ITrialChallenge challenge = ModelBase<GreatSwordChallengeModel>.Instance.GetChallenge();
		BlackSwordChallenge? config = ConfigBlackSwordChallengeById.GetConfig((challenge != null) ? challenge.BoardId : 0, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), ((config != null) ? config.GetValueOrDefault().Title : null) ?? "", Array.Empty<object>());
		string path = ((config != null) ? config.GetValueOrDefault().Icon : null) ?? "";
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			this.SetSpriteByPath(path, sprite, false, null, null);
		}
	}

	// Token: 0x0600E363 RID: 58211 RVA: 0x003D391C File Offset: 0x003D1B1C
	private void RefreshTrialLevels()
	{
		this.TrialLevelItems = new List<GreatSwordTrialLevelItem>();
		List<TrialSubChallenge> data = ModelBase<GreatSwordChallengeModel>.Instance.GetSubChallenges() ?? new List<TrialSubChallenge>();
		GenericLayout<GreatSwordTrialLevelItem, TrialSubChallenge> trialLevelLayout = this.TrialLevelLayout;
		if (trialLevelLayout == null)
		{
			return;
		}
		trialLevelLayout.RefreshByData(data, null, false);
	}

	// Token: 0x0600E364 RID: 58212 RVA: 0x003D395C File Offset: 0x003D1B5C
	private void RefreshChallengeGoals()
	{
		List<TrialSubChallenge> list = ModelBase<GreatSwordChallengeModel>.Instance.GetSubChallenges() ?? new List<TrialSubChallenge>();
		int selectedIndex = ModelBase<GreatSwordChallengeModel>.Instance.GetSelectedIndex();
		List<TrialSubChallenge> list2;
		if (selectedIndex >= list.Count)
		{
			list2 = new List<TrialSubChallenge>();
		}
		else
		{
			(list2 = new List<TrialSubChallenge>()).Add(list[selectedIndex]);
		}
		List<TrialSubChallenge> data = list2;
		GenericLayout<GreatSwordGoalItem, TrialSubChallenge> challengeGoalLayout = this.ChallengeGoalLayout;
		if (challengeGoalLayout == null)
		{
			return;
		}
		challengeGoalLayout.RefreshByData(data, null, false);
	}

	// Token: 0x0600E365 RID: 58213 RVA: 0x003D39C0 File Offset: 0x003D1BC0
	private void RefreshTopDescription()
	{
		List<TrialSubChallenge> list = ModelBase<GreatSwordChallengeModel>.Instance.GetSubChallenges() ?? new List<TrialSubChallenge>();
		int selectedIndex = ModelBase<GreatSwordChallengeModel>.Instance.GetSelectedIndex();
		TrialSubChallenge trialSubChallenge = (selectedIndex < list.Count) ? list[selectedIndex] : null;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), (trialSubChallenge != null) ? trialSubChallenge.Config.RuleText : "", Array.Empty<object>());
	}

	// Token: 0x0600E366 RID: 58214 RVA: 0x003D3A2E File Offset: 0x003D1C2E
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E367 RID: 58215 RVA: 0x003D3A37 File Offset: 0x003D1C37
	private void OnRefreshChallengeUI(IReadOnlyList<ITrialSubChallenge> challenges)
	{
		this.RefreshView();
	}

	// Token: 0x0600E368 RID: 58216 RVA: 0x003D3A3F File Offset: 0x003D1C3F
	private void OnChallengeConfirmed(int boardId, int levelId)
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E369 RID: 58217 RVA: 0x003D3A48 File Offset: 0x003D1C48
	private void OnClickStartChallenge(int _)
	{
		ITrialChallenge challenge = ModelBase<GreatSwordChallengeModel>.Instance.GetChallenge();
		BlackSwordChallenge? blackSwordChallenge;
		int instId = (ConfigBlackSwordChallengeById.GetConfig((challenge != null) ? challenge.BoardId : 0, true) != null) ? blackSwordChallenge.GetValueOrDefault().RelativeDungeonId : 0;
		int selectedIndex = ModelBase<GreatSwordChallengeModel>.Instance.GetSelectedIndex();
		List<TrialSubChallenge> subChallenges = ModelBase<GreatSwordChallengeModel>.Instance.GetSubChallenges();
		int levelId = (selectedIndex < subChallenges.Count) ? subChallenges[selectedIndex].Config.Id : 0;
		ControllerBase<GreatSwordController>.Instance.RequestGreatSwordLevelSelected(instId, levelId);
	}

	// Token: 0x0600E36A RID: 58218 RVA: 0x003D3AD4 File Offset: 0x003D1CD4
	private GreatSwordTrialLevelItem InitTrialLevelItem()
	{
		GreatSwordTrialLevelItem greatSwordTrialLevelItem = new GreatSwordTrialLevelItem();
		greatSwordTrialLevelItem.CanClickCallBack = new Func<int, bool>(this.CanClickItem);
		greatSwordTrialLevelItem.OnClickToggleCallBack = new Action<int>(this.OnClickTrialLevelItem);
		this.TrialLevelItems.Add(greatSwordTrialLevelItem);
		return greatSwordTrialLevelItem;
	}

	// Token: 0x0600E36B RID: 58219 RVA: 0x003D3B18 File Offset: 0x003D1D18
	private GreatSwordGoalItem InitPnlListItem()
	{
		return new GreatSwordGoalItem();
	}

	// Token: 0x0600E36C RID: 58220 RVA: 0x003D3B20 File Offset: 0x003D1D20
	private bool CanClickItem(int levelIndex)
	{
		List<TrialSubChallenge> list = ModelBase<GreatSwordChallengeModel>.Instance.GetSubChallenges() ?? new List<TrialSubChallenge>();
		TrialSubChallenge trialSubChallenge = (levelIndex < list.Count) ? list[levelIndex] : null;
		if (trialSubChallenge == null || !trialSubChallenge.Unlocked)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BlackSwordTips_LevelNotUnlocked", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0600E36D RID: 58221 RVA: 0x003D3B78 File Offset: 0x003D1D78
	private void OnClickTrialLevelItem(int levelIndex)
	{
		if (!this.CanClickItem(levelIndex))
		{
			return;
		}
		for (int i = 0; i < this.TrialLevelItems.Count; i++)
		{
			this.TrialLevelItems[i].SetToggleState((i == levelIndex) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
		}
		ModelBase<GreatSwordChallengeModel>.Instance.SetSelectedIndex(levelIndex);
		this.RefreshChallengeGoals();
		this.RefreshTopDescription();
		this.UiViewSequence.StopSequenceByKey("Switch", false, true);
		this.UiViewSequence.PlaySequence("Switch", false, null);
	}

	// Token: 0x04006D58 RID: 27992
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<GreatSwordTrialLevelItem, TrialSubChallenge> TrialLevelLayout;

	// Token: 0x04006D59 RID: 27993
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<GreatSwordGoalItem, TrialSubChallenge> ChallengeGoalLayout;

	// Token: 0x04006D5A RID: 27994
	private List<GreatSwordTrialLevelItem> TrialLevelItems = new List<GreatSwordTrialLevelItem>();

	// Token: 0x04006D5B RID: 27995
	[Nullable(2)]
	private ButtonItem ConfirmButton;
}
