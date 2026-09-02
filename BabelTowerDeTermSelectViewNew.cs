using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001211 RID: 4625
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerDeTermSelectViewNew : UiViewBase
{
	// Token: 0x06007A7E RID: 31358 RVA: 0x001FF53B File Offset: 0x001FD73B
	public BabelTowerDeTermSelectViewNew(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007A7F RID: 31359 RVA: 0x001FF550 File Offset: 0x001FD750
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickQuestBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007A80 RID: 31360 RVA: 0x001FF69C File Offset: 0x001FD89C
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerDeTermSelectViewNew.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerDeTermSelectViewNew.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007A81 RID: 31361 RVA: 0x001FF6DF File Offset: 0x001FD8DF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007A82 RID: 31362 RVA: 0x001FF6FD File Offset: 0x001FD8FD
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007A83 RID: 31363 RVA: 0x001FF71C File Offset: 0x001FD91C
	protected override void OnStart()
	{
		int levelId = (int)(this.OpenParam ?? 0);
		ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.Clear();
		ModelBase<BabelTowerModel>.Instance.DeTermSelectIndex = 0;
		this.InitDeTermSelectInfo(levelId);
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.SetLevelId(levelId);
		}
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem != null)
		{
			desRightItem.SetLevelId(levelId);
		}
		BabelTowerDesRightItem desRightItem2 = this.DesRightItem;
		if (desRightItem2 != null)
		{
			desRightItem2.RefreshBuffList(0);
		}
		BabelTowerQuickItem quickItem = this.QuickItem;
		if (quickItem != null)
		{
			quickItem.SetLevelId(levelId);
		}
		this.RefreshView();
	}

	// Token: 0x06007A84 RID: 31364 RVA: 0x001FF7B0 File Offset: 0x001FD9B0
	private void InitDeTermSelectInfo(int levelId)
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId);
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		HashSet<int> clearedDeTerms = ModelBase<BabelTowerModel>.Instance.ClearedDeTerms;
		if (babelTowerLevelConfig.FixBabelDeTermdsLength > 0)
		{
			for (int i = 0; i < babelTowerLevelConfig.FixBabelDeTermdsLength; i++)
			{
				int num = babelTowerLevelConfig.FixBabelDeTermds(i);
				ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(num);
				BabelTowerSelectInfo babelTowerSelectInfo = new BabelTowerSelectInfo();
				babelTowerSelectInfo.State = EBabelTowerDeTermState.StaticSelect;
				BabelTowerModel instance = ModelBase<BabelTowerModel>.Instance;
				int deTermSelectIndex = instance.DeTermSelectIndex;
				instance.DeTermSelectIndex = deTermSelectIndex + 1;
				babelTowerSelectInfo.SelectIndex = deTermSelectIndex;
				BabelTowerSelectInfo value = babelTowerSelectInfo;
				ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[num] = value;
			}
		}
		for (int j = 0; j < babelTowerLevelConfig.BabelTowerDeTermMutexArrayLength; j++)
		{
			int id = babelTowerLevelConfig.BabelTowerDeTermMutexArray(j);
			BabelTowerDeTermMutex babelTowerDeTermMutual = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTermMutual(id);
			for (int k = 0; k < babelTowerDeTermMutual.MutexDeTermGroupLength; k++)
			{
				int id2 = babelTowerDeTermMutual.MutexDeTermGroup(k);
				foreach (BabelTowerDeTerm babelTowerDeTerm in ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTermByGroupId(id2))
				{
					if (babelTowerData.GetDeTermIsLock(babelTowerDeTerm.Id))
					{
						BabelTowerSelectInfo babelTowerSelectInfo2 = new BabelTowerSelectInfo();
						babelTowerSelectInfo2.State = EBabelTowerDeTermState.Lock;
						BabelTowerModel instance2 = ModelBase<BabelTowerModel>.Instance;
						int deTermSelectIndex = instance2.DeTermSelectIndex;
						instance2.DeTermSelectIndex = deTermSelectIndex + 1;
						babelTowerSelectInfo2.SelectIndex = deTermSelectIndex;
						BabelTowerSelectInfo value2 = babelTowerSelectInfo2;
						ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[babelTowerDeTerm.Id] = value2;
					}
					else if (babelTowerData.GetDeTermIsUse(levelId, babelTowerDeTerm.Id))
					{
						EBabelTowerDeTermState state = clearedDeTerms.Contains(babelTowerDeTerm.Id) ? EBabelTowerDeTermState.Normal : EBabelTowerDeTermState.Select;
						BabelTowerSelectInfo babelTowerSelectInfo3 = new BabelTowerSelectInfo();
						babelTowerSelectInfo3.State = state;
						BabelTowerModel instance3 = ModelBase<BabelTowerModel>.Instance;
						int deTermSelectIndex = instance3.DeTermSelectIndex;
						instance3.DeTermSelectIndex = deTermSelectIndex + 1;
						babelTowerSelectInfo3.SelectIndex = deTermSelectIndex;
						BabelTowerSelectInfo value3 = babelTowerSelectInfo3;
						ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[babelTowerDeTerm.Id] = value3;
					}
					else
					{
						BabelTowerSelectInfo babelTowerSelectInfo4 = new BabelTowerSelectInfo();
						babelTowerSelectInfo4.State = EBabelTowerDeTermState.Normal;
						BabelTowerModel instance4 = ModelBase<BabelTowerModel>.Instance;
						int deTermSelectIndex = instance4.DeTermSelectIndex;
						instance4.DeTermSelectIndex = deTermSelectIndex + 1;
						babelTowerSelectInfo4.SelectIndex = deTermSelectIndex;
						BabelTowerSelectInfo value4 = babelTowerSelectInfo4;
						ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo[babelTowerDeTerm.Id] = value4;
					}
				}
			}
		}
	}

	// Token: 0x06007A85 RID: 31365 RVA: 0x001FFA0C File Offset: 0x001FDC0C
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.RefreshDifficultyBg();
		if (this.SvBuffItem != null)
		{
			BabelTowerQuickItem quickItem = this.QuickItem;
			int num = (quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1;
			if (num >= 0)
			{
				int id = (int)(this.OpenParam ?? 0);
				int instId = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(id).InstId;
				IReadOnlyList<BabelTowerQuick> babelTowerQuickByInstId = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerQuickByInstId(instId);
				BabelTowerQuick? babelTowerQuick = (babelTowerQuickByInstId != null && num < babelTowerQuickByInstId.Count) ? new BabelTowerQuick?(babelTowerQuickByInstId[num]) : null;
				if (babelTowerQuick != null)
				{
					this.SvBuffItem.ApplyQuickSelectDeTerms(BabelTowerDeTermSelectViewNew.BuildBuffGroupList(babelTowerQuick.Value));
				}
			}
			this.SvBuffItem.RefreshBuffList(null);
			this.SvBuffItem.RefreshStarNum();
		}
		if (this.DesRightItem != null)
		{
			this.DesRightItem.SetLevelId((int)(this.OpenParam ?? 0));
			this.DesRightItem.RefreshBuffList(0);
		}
		if (this.QuickItem != null)
		{
			this.QuickItem.SetLevelId((int)(this.OpenParam ?? 0));
			this.QuickItem.RefreshQuickListWithSelection();
		}
	}

	// Token: 0x06007A86 RID: 31366 RVA: 0x001FFB48 File Offset: 0x001FDD48
	private void RefreshView()
	{
		int num = (int)(this.OpenParam ?? 0);
		int maxRecordText;
		if (ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(num).IsDifficult)
		{
			BabelActivityLevelInfo babelActivityLevelInfo;
			maxRecordText = (ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().HardLevelDataMap.TryGetValue(num, out babelActivityLevelInfo) ? babelActivityLevelInfo.MaxPassStar : 0);
		}
		else
		{
			BabelActivityLevelInfo babelActivityLevelInfo2;
			maxRecordText = (ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().NormalLevelDataMap.TryGetValue(num, out babelActivityLevelInfo2) ? babelActivityLevelInfo2.MaxPassStar : 0);
		}
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem == null)
		{
			return;
		}
		desRightItem.SetMaxRecordText(maxRecordText);
	}

	// Token: 0x06007A87 RID: 31367 RVA: 0x001FFBDC File Offset: 0x001FDDDC
	private void RefreshDifficultyBg()
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig((int)(this.OpenParam ?? 0));
		bool isDifficult = babelTowerLevelConfig.IsDifficult;
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetUIActive(isDifficult);
		}
		UUITexture texture2 = base.GetTexture(3);
		if (texture2 != null)
		{
			texture2.SetUIActive(isDifficult);
		}
		if (isDifficult && !string.IsNullOrEmpty(babelTowerLevelConfig.BossTexture))
		{
			base.SetTextureByPath(babelTowerLevelConfig.BossTexture, base.GetTexture(3), null, null);
		}
	}

	// Token: 0x06007A88 RID: 31368 RVA: 0x001FFC68 File Offset: 0x001FDE68
	private void RefreshDifficultyColor(int currentStar)
	{
		int id = (int)(this.OpenParam ?? 0);
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(id);
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(babelTowerLevelConfig.ActivityId, currentStar);
		if (babelTowerDifficulty == null)
		{
			return;
		}
		FColor colorBg = FColor.FromHex(babelTowerDifficulty.Value.TextBgColor);
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem != null)
		{
			desRightItem.SetColorBg(colorBg);
		}
		BabelTowerDesRightItem desRightItem2 = this.DesRightItem;
		if (desRightItem2 == null)
		{
			return;
		}
		desRightItem2.SetDifficultyText(babelTowerDifficulty.Value.DifficultyTextKey);
	}

	// Token: 0x06007A89 RID: 31369 RVA: 0x001FFCFC File Offset: 0x001FDEFC
	private void BabelTowerRefreshLevelInfo()
	{
		if (this.SvBuffItem != null)
		{
			this.SvBuffItem.RefreshBuffList(null);
			this.SvBuffItem.RefreshStarNum();
		}
		if (this.QuickItem != null)
		{
			this.QuickItem.SetLevelId((int)(this.OpenParam ?? 0));
		}
	}

	// Token: 0x06007A8A RID: 31370 RVA: 0x001FFD50 File Offset: 0x001FDF50
	private void OnRefreshStarNum(int currentStar)
	{
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem != null)
		{
			desRightItem.SetStarNum(currentStar);
		}
		this.RefreshDifficultyColor(currentStar);
	}

	// Token: 0x06007A8B RID: 31371 RVA: 0x001FFD6B File Offset: 0x001FDF6B
	private void OnDeTermToggle(int deTermId)
	{
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem == null)
		{
			return;
		}
		desRightItem.RefreshBuffList(deTermId);
	}

	// Token: 0x06007A8C RID: 31372 RVA: 0x001FFD7E File Offset: 0x001FDF7E
	private void OnDesRightRefresh(int deTermId)
	{
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem == null)
		{
			return;
		}
		desRightItem.RefreshBuffList(deTermId);
	}

	// Token: 0x06007A8D RID: 31373 RVA: 0x001FFD94 File Offset: 0x001FDF94
	private static List<int> BuildBuffGroupList(BabelTowerQuick quickConfig)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < quickConfig.BuffGroupLength; i++)
		{
			list.Add(quickConfig.BuffGroup(i));
		}
		return list;
	}

	// Token: 0x06007A8E RID: 31374 RVA: 0x001FFDC8 File Offset: 0x001FDFC8
	private void OnQuickSelectApplied(BabelTowerQuick quickConfig)
	{
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.ApplyQuickSelectDeTerms(BabelTowerDeTermSelectViewNew.BuildBuffGroupList(quickConfig));
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 != null)
		{
			BabelTowerQuickItem quickItem = this.QuickItem;
			svBuffItem2.SetQuickSelectComponentsOpacity((quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1);
		}
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem != null)
		{
			desRightItem.RefreshBuffList(0);
		}
		BabelTowerQuickItem quickItem2 = this.QuickItem;
		if (quickItem2 == null)
		{
			return;
		}
		quickItem2.RefreshQuickListWithSelection();
	}

	// Token: 0x06007A8F RID: 31375 RVA: 0x001FFE34 File Offset: 0x001FE034
	private void OnQuickSelectCleared()
	{
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.ClearAllSelect();
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 != null)
		{
			BabelTowerQuickItem quickItem = this.QuickItem;
			svBuffItem2.SetQuickSelectComponentsOpacity((quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1);
		}
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem == null)
		{
			return;
		}
		desRightItem.RefreshBuffList(0);
	}

	// Token: 0x06007A90 RID: 31376 RVA: 0x001FFE88 File Offset: 0x001FE088
	private void OnBuffClick(int index, int deTermId)
	{
		if (deTermId <= 0)
		{
			return;
		}
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		MutexGroupItem mutexGroupItem = (svBuffItem != null) ? svBuffItem.FindMutexGroupItemByDeTermId(deTermId) : null;
		if (mutexGroupItem != null)
		{
			mutexGroupItem.HandleToggle(deTermId, null);
		}
		BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
		{
			IsDeTerm = true,
			ConfigId = deTermId,
			ShowWays = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x06007A91 RID: 31377 RVA: 0x001FFEE5 File Offset: 0x001FE0E5
	private void OnDesRightBuffClick(int deTermId)
	{
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem == null)
		{
			return;
		}
		svBuffItem.ScrollToDeTerm(deTermId);
	}

	// Token: 0x06007A92 RID: 31378 RVA: 0x001FFEF8 File Offset: 0x001FE0F8
	private void OnClickQuestBtn()
	{
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().CheckIfInOpenTime())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerIsNotOpen", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x06007A93 RID: 31379 RVA: 0x001FFF31 File Offset: 0x001FE131
	private void OnClickQuickSelectBtn()
	{
		if (this.IsShowingQuickSelect)
		{
			this.HideQuickSelectPanelWithAnimation();
			return;
		}
		this.ShowQuickSelectPanelWithAnimation();
	}

	// Token: 0x06007A94 RID: 31380 RVA: 0x001FFF48 File Offset: 0x001FE148
	private void OnCloseHandler()
	{
		if (this.IsShowingQuickSelect)
		{
			this.HideQuickSelectPanelWithAnimation();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06007A95 RID: 31381 RVA: 0x001FFF60 File Offset: 0x001FE160
	private void ShowQuickSelectPanelWithAnimation()
	{
		BabelTowerDeTermSelectViewNew.<>c__DisplayClass31_0 CS$<>8__locals1 = new BabelTowerDeTermSelectViewNew.<>c__DisplayClass31_0();
		CS$<>8__locals1.<>4__this = this;
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.SetQuickSelectPanelVisible(true);
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 != null)
		{
			BabelTowerQuickItem quickItem = this.QuickItem;
			svBuffItem2.SetQuickSelectComponentsOpacity((quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1);
		}
		BabelTowerDeTermSelectViewNew.<>c__DisplayClass31_0 CS$<>8__locals2 = CS$<>8__locals1;
		BabelTowerQuickItem quickItem2 = this.QuickItem;
		CS$<>8__locals2.firstItem = ((quickItem2 != null) ? quickItem2.GetFirstQuickItem() : null);
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_In", new Action<string>(this.OnSwitchInFinished));
		this.UiViewSequence.StopSequenceByKey("Switch_Out", true, true);
		base.PlayOrReplaySequence("Switch_In", false, null);
		this.UiViewSequence.AddSequenceFinishEvent("Switch_In", new Action<string>(this.OnSwitchInFinished), true);
		BabelTowerQuickItem quickItem3 = this.QuickItem;
		if (quickItem3 != null)
		{
			quickItem3.PlayContentAnimController();
		}
		if (CS$<>8__locals1.firstItem != null)
		{
			BabelTowerQuickItem quickItem4 = this.QuickItem;
			if (quickItem4 == null)
			{
				return;
			}
			quickItem4.BindLateUpdate(delegate(float _)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(CS$<>8__locals1.firstItem, true, false, false);
				BabelTowerQuickItem quickItem5 = CS$<>8__locals1.<>4__this.QuickItem;
				if (quickItem5 == null)
				{
					return;
				}
				quickItem5.UnBindLateUpdate();
			});
		}
	}

	// Token: 0x06007A96 RID: 31382 RVA: 0x0020005C File Offset: 0x001FE25C
	private void OnSwitchInFinished(string _)
	{
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_In", new Action<string>(this.OnSwitchInFinished));
		this.IsShowingQuickSelect = true;
		this.BackupCurrentDeTermState();
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.SetActionButtonsVisible(false, new bool?(false));
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 == null)
		{
			return;
		}
		svBuffItem2.SetQuickSelectPanelVisible(true);
	}

	// Token: 0x06007A97 RID: 31383 RVA: 0x002000E4 File Offset: 0x001FE2E4
	private void BackupCurrentDeTermState()
	{
		this.BackupDeTermSelectInfo.Clear();
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo)
		{
			this.BackupDeTermSelectInfo[keyValuePair.Key] = new BabelTowerSelectInfo
			{
				State = keyValuePair.Value.State,
				SelectIndex = keyValuePair.Value.SelectIndex
			};
		}
	}

	// Token: 0x06007A98 RID: 31384 RVA: 0x0020017C File Offset: 0x001FE37C
	private void RestoreBackupDeTermState()
	{
		Dictionary<int, IBabelTowerSelectInfo> deTermSelectInfo = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo;
		deTermSelectInfo.Clear();
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in this.BackupDeTermSelectInfo)
		{
			deTermSelectInfo[keyValuePair.Key] = new BabelTowerSelectInfo
			{
				State = keyValuePair.Value.State,
				SelectIndex = keyValuePair.Value.SelectIndex
			};
		}
		this.BackupDeTermSelectInfo.Clear();
	}

	// Token: 0x06007A99 RID: 31385 RVA: 0x0020021C File Offset: 0x001FE41C
	private void HideQuickSelectPanelWithAnimation()
	{
		if (this.IsHidingQuickSelect)
		{
			return;
		}
		this.IsHidingQuickSelect = true;
		this.RestoreBackupDeTermState();
		BabelTowerQuickItem quickItem = this.QuickItem;
		if (quickItem != null)
		{
			quickItem.ClearSelectionWithoutCallback();
		}
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem != null)
		{
			desRightItem.RefreshBuffList(0);
		}
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.RefreshBuffList(null);
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 != null)
		{
			svBuffItem2.RefreshStarNum();
		}
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		BabelTowerSvBuffItem svBuffItem3 = this.SvBuffItem;
		if (svBuffItem3 != null)
		{
			svBuffItem3.SetQuickSelectPanelVisible(false);
		}
		BabelTowerSvBuffItem svBuffItem4 = this.SvBuffItem;
		if (svBuffItem4 != null)
		{
			svBuffItem4.SetQuickSelectComponentsOpacity(-1);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_Out", new Action<string>(this.OnSwitchOutFinished));
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_Out", new Action<string>(this.OnConfirmSwitchOutFinished));
		this.UiViewSequence.StopSequenceByKey("Switch_In", true, true);
		base.PlayOrReplaySequence("Switch_Out", false, null);
		this.UiViewSequence.AddSequenceFinishEvent("Switch_Out", new Action<string>(this.OnSwitchOutFinished), true);
	}

	// Token: 0x06007A9A RID: 31386 RVA: 0x0020034C File Offset: 0x001FE54C
	private void OnSwitchOutFinished(string _)
	{
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_Out", new Action<string>(this.OnSwitchOutFinished));
		this.IsHidingQuickSelect = false;
		this.IsShowingQuickSelect = false;
		int id = (int)(this.OpenParam ?? 0);
		bool isDifficult = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(id).IsDifficult;
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.SetActionButtonsVisible(isDifficult, new bool?(isDifficult));
		}
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "BabelTowerDeTermSelectViewShow");
	}

	// Token: 0x06007A9B RID: 31387 RVA: 0x002003DC File Offset: 0x001FE5DC
	private void ShowDesRightPanel()
	{
		this.IsShowingQuickSelect = false;
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		int id = (int)(this.OpenParam ?? 0);
		bool isDifficult = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(id).IsDifficult;
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.SetActionButtonsVisible(isDifficult, new bool?(isDifficult));
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 != null)
		{
			svBuffItem2.SetQuickSelectPanelVisible(false);
		}
		BabelTowerSvBuffItem svBuffItem3 = this.SvBuffItem;
		if (svBuffItem3 != null)
		{
			BabelTowerQuickItem quickItem = this.QuickItem;
			svBuffItem3.SetQuickSelectComponentsOpacity((quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1);
		}
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "BabelTowerDeTermSelectViewShow");
	}

	// Token: 0x06007A9C RID: 31388 RVA: 0x002004A4 File Offset: 0x001FE6A4
	private void SwitchToDesRightFromQuickSelect()
	{
		BabelTowerDesRightItem desRightItem = this.DesRightItem;
		if (desRightItem != null)
		{
			desRightItem.RefreshBuffList(0);
		}
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.RefreshBuffList(null);
		}
		BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
		if (svBuffItem2 != null)
		{
			svBuffItem2.RefreshStarNum();
		}
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		BabelTowerSvBuffItem svBuffItem3 = this.SvBuffItem;
		if (svBuffItem3 != null)
		{
			svBuffItem3.SetQuickSelectPanelVisible(false);
		}
		BabelTowerSvBuffItem svBuffItem4 = this.SvBuffItem;
		if (svBuffItem4 != null)
		{
			svBuffItem4.SetQuickSelectComponentsOpacity(-1);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_Out", new Action<string>(this.OnSwitchOutFinished));
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_Out", new Action<string>(this.OnConfirmSwitchOutFinished));
		this.UiViewSequence.StopSequenceByKey("Switch_In", true, true);
		base.PlayOrReplaySequence("Switch_Out", false, null);
		this.UiViewSequence.AddSequenceFinishEvent("Switch_Out", new Action<string>(this.OnConfirmSwitchOutFinished), true);
	}

	// Token: 0x06007A9D RID: 31389 RVA: 0x002005AC File Offset: 0x001FE7AC
	private void OnConfirmSwitchOutFinished(string _)
	{
		this.UiViewSequence.RemoveSequenceFinishEvent("Switch_Out", new Action<string>(this.OnConfirmSwitchOutFinished));
		this.IsShowingQuickSelect = false;
		this.BackupDeTermSelectInfo.Clear();
		BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
		if (svBuffItem != null)
		{
			svBuffItem.SetActionButtonsVisible(true, new bool?(true));
		}
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "BabelTowerDeTermSelectViewShow");
	}

	// Token: 0x06007A9E RID: 31390 RVA: 0x00200614 File Offset: 0x001FE814
	private void OnClickClearBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerClearDeTerm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			BabelTowerQuickItem quickItem = this.QuickItem;
			if (quickItem != null)
			{
				quickItem.ClearSelection();
			}
			BabelTowerSvBuffItem svBuffItem = this.SvBuffItem;
			if (svBuffItem != null)
			{
				svBuffItem.ClearAllSelect();
			}
			BabelTowerSvBuffItem svBuffItem2 = this.SvBuffItem;
			if (svBuffItem2 != null)
			{
				BabelTowerQuickItem quickItem2 = this.QuickItem;
				svBuffItem2.SetQuickSelectComponentsOpacity((quickItem2 != null) ? quickItem2.GetSelectedQuickIndex() : -1);
			}
			BabelTowerDesRightItem desRightItem = this.DesRightItem;
			if (desRightItem == null)
			{
				return;
			}
			desRightItem.RefreshBuffList(0);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06007A9F RID: 31391 RVA: 0x00200650 File Offset: 0x001FE850
	private void SubmitCurrentSelection(bool jumpToPreBattle)
	{
		List<int> selectedDeTermList = ModelBase<BabelTowerModel>.Instance.GetSelectedDeTermList();
		int currentDeTermStar = ModelBase<BabelTowerModel>.Instance.GetCurrentDeTermStar();
		int levelId = (int)(this.OpenParam ?? 0);
		BabelTowerQuickItem quickItem = this.QuickItem;
		int quickId = (quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1;
		ControllerBase<BabelTowerController>.Instance.SubmitDeTermSelectionAndJump(levelId, selectedDeTermList, currentDeTermStar, jumpToPreBattle, quickId).Forget();
	}

	// Token: 0x06007AA0 RID: 31392 RVA: 0x002006B0 File Offset: 0x001FE8B0
	private void OnClickConfirmBtn()
	{
		BabelTowerQuickItem quickItem = this.QuickItem;
		if (((quickItem != null) ? quickItem.GetSelectedQuickIndex() : -1) >= 0)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerQuickSelectConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				this.SwitchToDesRightFromQuickSelect();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.SwitchToDesRightFromQuickSelect();
	}

	// Token: 0x06007AA1 RID: 31393 RVA: 0x00200708 File Offset: 0x001FE908
	private void OnClickGoBtn()
	{
		int currentDeTermStar = ModelBase<BabelTowerModel>.Instance.GetCurrentDeTermStar();
		int id = (int)(this.OpenParam ?? 0);
		if (currentDeTermStar >= ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(id).PassStar)
		{
			this.SubmitCurrentSelection(true);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerLowStarConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			this.SubmitCurrentSelection(true);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x04003ACF RID: 15055
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003AD0 RID: 15056
	[Nullable(2)]
	private BabelTowerDesRightItem DesRightItem;

	// Token: 0x04003AD1 RID: 15057
	[Nullable(2)]
	private BabelTowerSvBuffItem SvBuffItem;

	// Token: 0x04003AD2 RID: 15058
	[Nullable(2)]
	private BabelTowerQuickItem QuickItem;

	// Token: 0x04003AD3 RID: 15059
	private bool IsShowingQuickSelect;

	// Token: 0x04003AD4 RID: 15060
	private bool IsHidingQuickSelect;

	// Token: 0x04003AD5 RID: 15061
	private readonly Dictionary<int, IBabelTowerSelectInfo> BackupDeTermSelectInfo = new Dictionary<int, IBabelTowerSelectInfo>();

	// Token: 0x02007561 RID: 30049
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028807 RID: 165895
		public const int CaptionItem = 0;

		// Token: 0x04028808 RID: 165896
		public const int QuestBtn = 1;

		// Token: 0x04028809 RID: 165897
		public const int HardBg = 2;

		// Token: 0x0402880A RID: 165898
		public const int BossBg = 3;

		// Token: 0x0402880B RID: 165899
		public const int SvBuffItem = 4;

		// Token: 0x0402880C RID: 165900
		public const int DesRightItem = 5;

		// Token: 0x0402880D RID: 165901
		public const int QuickItem = 6;
	}
}
