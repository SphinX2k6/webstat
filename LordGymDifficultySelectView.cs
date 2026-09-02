using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021FA RID: 8698
[NullableContext(1)]
[Nullable(0)]
public class LordGymDifficultySelectView : UiViewBase
{
	// Token: 0x0601067C RID: 67196 RVA: 0x0047B862 File Offset: 0x00479A62
	public LordGymDifficultySelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601067D RID: 67197 RVA: 0x0047B86C File Offset: 0x00479A6C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(10, new Action(this.OnStartChallengeButtonClick)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnHistoryButtonClick)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnCloseBtnClick))
		};
	}

	// Token: 0x0601067E RID: 67198 RVA: 0x0047BA2C File Offset: 0x00479C2C
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymDifficultySelectView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymDifficultySelectView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601067F RID: 67199 RVA: 0x0047BA6F File Offset: 0x00479C6F
	protected override void OnHandleLoadScene()
	{
		Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
		ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.LordEntranceId, true, false).Forget();
	}

	// Token: 0x06010680 RID: 67200 RVA: 0x0047BA9C File Offset: 0x00479C9C
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyLordSkeletalHandle();
	}

	// Token: 0x06010681 RID: 67201 RVA: 0x0047BAA8 File Offset: 0x00479CA8
	protected virtual void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06010682 RID: 67202 RVA: 0x0047BAB4 File Offset: 0x00479CB4
	private void OnHelpBtnClick()
	{
		int helpId = ConfigLordGymEntranceSetById.GetConfig(this.LordEntranceSetId, true).Value.HelpId;
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x06010683 RID: 67203 RVA: 0x0047BAE9 File Offset: 0x00479CE9
	private LordGymDifficultyItem CreateDifficultyLoopItem()
	{
		return this.CreateItem();
	}

	// Token: 0x06010684 RID: 67204 RVA: 0x0047BAF1 File Offset: 0x00479CF1
	protected virtual LordGymDifficultyItem CreateItem()
	{
		return new LordGymDifficultyItem
		{
			OnToggleClick = new Action<int>(this.OnLordDifficultyToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(this.CanLordDifficultyToggleChange)
		};
	}

	// Token: 0x06010685 RID: 67205 RVA: 0x0047BB1C File Offset: 0x00479D1C
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06010686 RID: 67206 RVA: 0x0047BB23 File Offset: 0x00479D23
	private void OnStartChallengeButtonClick()
	{
		this.OnStartChallenge();
	}

	// Token: 0x06010687 RID: 67207 RVA: 0x0047BB2C File Offset: 0x00479D2C
	protected virtual void OnStartChallenge()
	{
		if (!ControllerBase<LordGymController>.Instance.IsInEntranceEntity())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("LordGymOpen_ErrorTipText", Array.Empty<object>());
			return;
		}
		int selectedGridIndex = this.LordDifficultyScrollView.GetSelectedGridIndex();
		int lordId = this.LordList[selectedGridIndex];
		ControllerBase<LordGymController>.Instance.LordGymBeginRequest(lordId).ContinueWith(delegate(bool isSuccess)
		{
			if (isSuccess)
			{
				Singleton<UiManager>.Instance.ResetToBattleView(null);
				ModelBase<LordGymModel>.Instance.LastChallengeLordEntranceId = this.LordEntranceId;
			}
		}).Forget();
	}

	// Token: 0x06010688 RID: 67208 RVA: 0x0047BB94 File Offset: 0x00479D94
	private void OnHistoryButtonClick()
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(this.SelectedLordId);
		LordGymChallengeRecordViewParam param = new LordGymChallengeRecordViewParam
		{
			EntranceId = this.LordEntranceId,
			Difficulty = ((lordGymConfig != null) ? lordGymConfig.Value.Difficulty : 0)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymChallengeRecordView, param, null);
	}

	// Token: 0x06010689 RID: 67209 RVA: 0x0047BBF8 File Offset: 0x00479DF8
	private void SetDefaultSelect()
	{
		if (this.LordList == null || this.LordList.Count == 0)
		{
			return;
		}
		ILordGymDifficultySelectViewParam lordGymDifficultySelectViewParam = this.OpenParam as ILordGymDifficultySelectViewParam;
		int num = (lordGymDifficultySelectViewParam != null) ? lordGymDifficultySelectViewParam.DefaultLordId : 0;
		if (num > 0)
		{
			int num2 = this.LordList.IndexOf(num);
			if (num2 >= 0)
			{
				this.SelectLordDifficultyByIndex(num2);
				return;
			}
		}
		int num3 = 0;
		LordGymModel instance = ModelBase<LordGymModel>.Instance;
		for (int i = 0; i < this.LordList.Count; i++)
		{
			int lordId = this.LordList[i];
			if (instance.GetLordGymIsUnLock(lordId) && instance.GetLastGymFinish(lordId) && i >= num3)
			{
				num3 = i;
			}
		}
		this.SelectLordDifficultyByIndex(num3);
	}

	// Token: 0x0601068A RID: 67210 RVA: 0x0047BCA4 File Offset: 0x00479EA4
	protected bool CanLordDifficultyToggleChange(int index)
	{
		return index != this.LordDifficultyScrollView.GetSelectedGridIndex();
	}

	// Token: 0x0601068B RID: 67211 RVA: 0x0047BCB7 File Offset: 0x00479EB7
	protected void OnLordDifficultyToggleClick(int index)
	{
		if (!this.CanLordDifficultyToggleChange(index))
		{
			return;
		}
		this.SelectLordDifficultyByIndex(index);
	}

	// Token: 0x0601068C RID: 67212 RVA: 0x0047BCCA File Offset: 0x00479ECA
	public void SelectLordDifficultyByIndex(int index)
	{
		LoopScrollView<LordGymDifficultyItem, int> lordDifficultyScrollView = this.LordDifficultyScrollView;
		if (lordDifficultyScrollView != null)
		{
			lordDifficultyScrollView.SelectGridProxy(index, false);
		}
		this.SelectedLordId = this.LordList[index];
		this.RefreshDetail();
	}

	// Token: 0x0601068D RID: 67213 RVA: 0x0047BCF8 File Offset: 0x00479EF8
	public virtual void RefreshDetail()
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(this.SelectedLordId);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(value.MonsterLevel.ToString()));
		int rewardId = value.RewardId;
		List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(rewardId, null);
		bool isPass = ModelBase<LordGymModel>.Instance.GetLordGymIsFinish(this.SelectedLordId);
		this.RewardScrollView.RefreshByData(exchangeRewardPreviewRewardList, delegate
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardScrollView.GetScrollItemList())
			{
				commonItemSmallItemGrid.SetReceivedVisible(isPass);
			}
		}, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.PlayDescription, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.NewGymTitle, Array.Empty<object>());
		LordGymPassRecord lordGymPassRecord;
		ModelBase<LordGymModel>.Instance.LordGymRecord.TryGetValue(this.SelectedLordId, out lordGymPassRecord);
		if (lordGymPassRecord != null && lordGymPassRecord != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "BestPassTime", new <>z__ReadOnlySingleElementList<object>(Singleton<TimeUtil>.Instance.GetTimeString((double)lordGymPassRecord.PassTime)));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "NoPassRecord", Array.Empty<object>());
		}
		bool flag = !ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(this.SelectedLordId);
		bool lastGymFinish = ModelBase<LordGymModel>.Instance.GetLastGymFinish(this.SelectedLordId);
		bool flag2 = value.MonsterLevel > ModelBase<EditFormationModel>.Instance.GetFormationAverageLevel();
		base.GetItem(12).SetUIActive(flag || !lastGymFinish);
		base.GetItem(9).SetUIActive(flag2 && !flag && lastGymFinish);
		UUIItem uuiitem = base.GetButton(10).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(!flag && lastGymFinish);
		}
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), value.LockDescription, Array.Empty<object>());
		}
		else if (!lastGymFinish)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "LordGymLockTips", Array.Empty<object>());
		}
		else if (flag2)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "LordGymLowLevel", Array.Empty<object>());
		}
		if (isPass)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Text_ButtonTextChallengeOneMore_Text", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Text_StartBattle_Text", Array.Empty<object>());
	}

	// Token: 0x04008156 RID: 33110
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04008157 RID: 33111
	protected int LordEntranceSetId;

	// Token: 0x04008158 RID: 33112
	protected int LordEntranceId;

	// Token: 0x04008159 RID: 33113
	[Nullable(2)]
	protected List<int> LordList;

	// Token: 0x0400815A RID: 33114
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected LoopScrollView<LordGymDifficultyItem, int> LordDifficultyScrollView;

	// Token: 0x0400815B RID: 33115
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x0400815C RID: 33116
	protected int SelectedLordId;

	// Token: 0x020084BD RID: 33981
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402CF8A RID: 184202
		public const int CaptionItem = 0;

		// Token: 0x0402CF8B RID: 184203
		public const int DifficultyLoopScrollView = 1;

		// Token: 0x0402CF8C RID: 184204
		public const int DifficultyLoopItem = 2;

		// Token: 0x0402CF8D RID: 184205
		public const int LordNameText = 3;

		// Token: 0x0402CF8E RID: 184206
		public const int LordLevelText = 4;

		// Token: 0x0402CF8F RID: 184207
		public const int DetailText = 5;

		// Token: 0x0402CF90 RID: 184208
		public const int RewardScrollView = 6;

		// Token: 0x0402CF91 RID: 184209
		public const int HistoryButton = 7;

		// Token: 0x0402CF92 RID: 184210
		public const int HistoryText = 8;

		// Token: 0x0402CF93 RID: 184211
		public const int WarningItem = 9;

		// Token: 0x0402CF94 RID: 184212
		public const int StartChallengeButton = 10;

		// Token: 0x0402CF95 RID: 184213
		public const int StartChallengeText = 11;

		// Token: 0x0402CF96 RID: 184214
		public const int LockItem = 12;

		// Token: 0x0402CF97 RID: 184215
		public const int ConditionText = 13;

		// Token: 0x0402CF98 RID: 184216
		public const int BackBtn = 14;
	}
}
