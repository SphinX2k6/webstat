using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001123 RID: 4387
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerSelectRoleView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x06007291 RID: 29329 RVA: 0x001DEBD2 File Offset: 0x001DCDD2
	public GuessJokerSelectRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007292 RID: 29330 RVA: 0x001DEBE8 File Offset: 0x001DCDE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(21, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(24, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(14, new Action(this.OnClickConfirm)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickMaskButton)),
			new ValueTuple<int, Delegate>(20, new Action<EToggleState>(this.OnHideToggleClick)),
			new ValueTuple<int, Delegate>(21, new Action(this.OnClickGetReward))
		};
	}

	// Token: 0x06007293 RID: 29331 RVA: 0x001DEEA8 File Offset: 0x001DD0A8
	protected override UniTask OnBeforeStartAsync()
	{
		GuessJokerSelectRoleView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GuessJokerSelectRoleView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007294 RID: 29332 RVA: 0x001DEEEB File Offset: 0x001DD0EB
	protected override void OnBeforeShow()
	{
		this.PauseTimeDilation();
		Singleton<UiCameraAnimationManager>.Instance.DisablePlayerActor();
	}

	// Token: 0x06007295 RID: 29333 RVA: 0x001DEEFD File Offset: 0x001DD0FD
	protected override void OnBeforeHide()
	{
		if (this.IsConfirmHide)
		{
			this.IsConfirmHide = false;
		}
		else
		{
			Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
		}
		this.ResumeTimeDilation();
	}

	// Token: 0x06007296 RID: 29334 RVA: 0x001DEF20 File Offset: 0x001DD120
	protected void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("GuessJokerSelectRoleView");
	}

	// Token: 0x06007297 RID: 29335 RVA: 0x001DEF31 File Offset: 0x001DD131
	protected void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("GuessJokerSelectRoleView");
	}

	// Token: 0x06007298 RID: 29336 RVA: 0x001DEF42 File Offset: 0x001DD142
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		if (this.CurCameraName != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)this.CurCameraName, new int?(viewId), isBlend);
		}
	}

	// Token: 0x06007299 RID: 29337 RVA: 0x001DEF68 File Offset: 0x001DD168
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		if (this.CurCameraName != null)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)this.CurCameraName, stackTopInfo, closeViewId, popOrDelete);
		}
	}

	// Token: 0x0600729A RID: 29338 RVA: 0x001DEF8B File Offset: 0x001DD18B
	private GuessJokerSelectRoleItem CreateRoleItem()
	{
		GuessJokerSelectRoleItem guessJokerSelectRoleItem = new GuessJokerSelectRoleItem();
		guessJokerSelectRoleItem.BindClickCallBack(new Action<GuessJokerSelectRoleItem>(this.OnClickRoleItem));
		return guessJokerSelectRoleItem;
	}

	// Token: 0x0600729B RID: 29339 RVA: 0x001DEFA4 File Offset: 0x001DD1A4
	private ActivitySmallItemGrid CreateRewardItem()
	{
		return new ActivitySmallItemGrid();
	}

	// Token: 0x0600729C RID: 29340 RVA: 0x001DEFAC File Offset: 0x001DD1AC
	private void OnSelectViewSequenceFinish(string sequenceName)
	{
		Action action;
		this.SequenceFinishCallbackMap.TryGetValue(sequenceName, out action);
		if (action != null)
		{
			action();
			this.SequenceFinishCallbackMap.Remove(sequenceName);
		}
	}

	// Token: 0x0600729D RID: 29341 RVA: 0x001DEFE0 File Offset: 0x001DD1E0
	private void ChangeRole(GuessJokerSelectRoleItem roleItem)
	{
		if (this.CurSelectRoleItem == roleItem)
		{
			return;
		}
		if (this.CurSelectRoleItem != null)
		{
			this.CurSelectRoleItem.OnDeselected(true);
		}
		roleItem.OnSelected(true);
		this.CurSelectRoleItem = roleItem;
		int level = this.CurSelectRoleItem.Level;
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(level);
		if (jokerLevelById == null)
		{
			return;
		}
		int aiRole = jokerLevelById.Value.AiRole;
		GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(aiRole);
		if (jokerAiConfigByRoleId == null)
		{
			return;
		}
		this.CheckClick(level);
		roleItem.RefreshRedDot();
		int selectRoleCameraId = jokerAiConfigByRoleId.Value.SelectRoleCameraId;
		string cameraNameByCameraId = GuessJokerUtils.GetCameraNameByCameraId(selectRoleCameraId);
		this.CurCameraName = cameraNameByCameraId;
		this.CurCameraSettingName = GuessJokerUtils.GetCameraSettingNameByCameraId(selectRoleCameraId);
		this.RefreshDetailView(roleItem.Level);
	}

	// Token: 0x0600729E RID: 29342 RVA: 0x001DF0AC File Offset: 0x001DD2AC
	private void CheckClick(int levelId)
	{
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		IGuessJokerLevelInfo guessJokerGameData = activityData.GetGuessJokerGameData(levelId);
		if (guessJokerGameData == null)
		{
			return;
		}
		if (!guessJokerGameData.Unlock || guessJokerGameData.FirstPass)
		{
			return;
		}
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerUnlockLevelClicked, null) ?? new HashSet<int>();
		if (!hashSet.Contains(levelId))
		{
			hashSet.Add(levelId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerUnlockLevelClicked, hashSet);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnGuessJokerRedDotNotify);
		}
	}

	// Token: 0x0600729F RID: 29343 RVA: 0x001DF128 File Offset: 0x001DD328
	private void PushCamera()
	{
		if (this.CurCameraSettingName != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "【action】Push Camera：" + this.CurCameraSettingName, default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(this.CurCameraSettingName, true, true, "1001", false, null, null);
		}
	}

	// Token: 0x060072A0 RID: 29344 RVA: 0x001DF18C File Offset: 0x001DD38C
	private void RefreshDetailView(int levelId)
	{
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		int aiRole = jokerLevelById.Value.AiRole;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<RoleConfig>.Instance.GetRoleConfig(aiRole).Value.Name, null);
		base.GetText(3).SetText(localTextNew, true);
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		IGuessJokerLevelInfo guessJokerGameData = activityData.GetGuessJokerGameData(levelId);
		if (guessJokerGameData == null)
		{
			return;
		}
		bool isFinished = guessJokerGameData.FirstPass;
		bool unlock = guessJokerGameData.Unlock;
		bool rewardGet = guessJokerGameData.RewardGet;
		base.GetItem(5).SetUIActive(guessJokerGameData.PlayerWin);
		base.GetSprite(12).SetUIActive(!unlock || !isFinished);
		base.GetSprite(13).SetUIActive(isFinished && rewardGet);
		base.GetButton(21).RootUIComp.Get().SetUIActive(isFinished && !rewardGet);
		int aiCardSkill = jokerLevelById.Value.AiCardSkill;
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(aiCardSkill);
		base.GetText(6).ShowTextNew(isFinished ? jokerSkill.Value.SkillName : "GuessJoker_SkillNameLockText");
		base.GetText(7).ShowTextNew(isFinished ? jokerSkill.Value.SkillDesc : "GuessJoker_SkillDescLockText");
		string textStringId = isFinished ? "GuessJoker_RematchConfirmText" : "GuessJoker_ConfirmText";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), textStringId, new <>z__ReadOnlySingleElementList<object>(localTextNew));
		base.SetTextureByPath(jokerSkill.Value.SkillIconPath, base.GetTexture(9), null, null);
		int passReward = jokerLevelById.Value.PassReward;
		this.RefreshRewardData(passReward, rewardGet);
		base.GetButton(14).RootUIComp.Get().SetUIActive(unlock);
		if (!unlock)
		{
			this.PanelLock.SetTextByTextId(jokerLevelById.Value.LockText, Array.Empty<string>());
		}
		this.PanelLock.SetUiActive(!unlock);
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerFirstFinishAnim, null) ?? new HashSet<int>();
		if (hashSet.Contains(levelId))
		{
			this.PlaySelectViewSequence("Unlock", delegate
			{
				this.GetTexture(9).SetUIActive(isFinished);
				this.GetSprite(8).SetUIActive(!isFinished);
			});
			hashSet.Remove(levelId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerFirstFinishAnim, hashSet);
			return;
		}
		base.GetTexture(9).SetUIActive(isFinished);
		base.GetSprite(8).SetUIActive(!isFinished);
	}

	// Token: 0x060072A1 RID: 29345 RVA: 0x001DF45C File Offset: 0x001DD65C
	private void PlaySelectViewSequence(string sequenceName, [Nullable(2)] Action finishCallback = null)
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}
		if (finishCallback != null)
		{
			this.SequenceFinishCallbackMap[sequenceName] = finishCallback;
		}
	}

	// Token: 0x060072A2 RID: 29346 RVA: 0x001DF498 File Offset: 0x001DD698
	private void RefreshRewardData(int dropId, bool isClaimed)
	{
		if (dropId == 0)
		{
			this.RewardScrollView.SetActive(false);
			return;
		}
		List<IItemGridData> list = new List<IItemGridData>();
		foreach (TItem item in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId))
		{
			ItemGridData item2 = new ItemGridData
			{
				Item = item,
				HasClaimed = isClaimed
			};
			list.Add(item2);
		}
		this.RewardScrollView.RefreshByData(list, null, false);
		this.RewardScrollView.SetActive(list.Count > 0);
	}

	// Token: 0x060072A3 RID: 29347 RVA: 0x001DF53C File Offset: 0x001DD73C
	private void OnClickRoleItem(GuessJokerSelectRoleItem roleItem)
	{
		this.ChangeRole(roleItem);
		this.PlaySelectViewSequence("Switch", null);
		this.PushCamera();
	}

	// Token: 0x060072A4 RID: 29348 RVA: 0x001DF557 File Offset: 0x001DD757
	private void OnClickMaskButton()
	{
		GuessJokerHeroSkillItem heroSkillItem = this.HeroSkillItem;
		if (heroSkillItem == null)
		{
			return;
		}
		heroSkillItem.CloseDetail();
	}

	// Token: 0x060072A5 RID: 29349 RVA: 0x001DF56C File Offset: 0x001DD76C
	private void OnClickConfirm()
	{
		if (this.CurSelectRoleItem == null)
		{
			return;
		}
		int level = this.CurSelectRoleItem.Level;
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(level);
		GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(jokerLevelById.Value.AiRole);
		if (jokerAiConfigByRoleId != null)
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.ShowOnlyGuessJokerNpc(jokerAiConfigByRoleId.Value.NpcId);
		}
		string[] array = jokerLevelById.Value.FirstEnterFlow();
		if (array.Length == 3)
		{
			ControllerBase<FlowController>.Instance.StartFlow(array[0], int.Parse(array[1]), int.Parse(array[2]), null, 0L, false, false, false, null);
		}
		this.IsConfirmHide = true;
		base.CloseMe(null);
	}

	// Token: 0x060072A6 RID: 29350 RVA: 0x001DF624 File Offset: 0x001DD824
	private void OnHideToggleClick(EToggleState state)
	{
		bool uiactive = state != EToggleState.ETT_Checked;
		base.GetItem(19).SetUIActive(uiactive);
		base.GetItem(22).SetUIActive(uiactive);
		base.GetButton(23).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(24).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060072A7 RID: 29351 RVA: 0x001DF68C File Offset: 0x001DD88C
	private void OnClickBack()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		if (levelId != -1)
		{
			int aiRole = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId).Value.AiRole;
			GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(aiRole);
			if (jokerAiConfigByRoleId == null)
			{
				base.CloseMe(null);
				return;
			}
			int npcId = jokerAiConfigByRoleId.Value.NpcId;
			if (npcId != 0)
			{
				ModelBase<GuessJokerGamePlayModel>.Instance.ShowOnlyGuessJokerNpc(npcId);
			}
		}
		else
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.HideAllGuessJokerNpc();
		}
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x060072A8 RID: 29352 RVA: 0x001DF71C File Offset: 0x001DD91C
	private void OnClickGetReward()
	{
		if (this.CurSelectRoleItem == null)
		{
			return;
		}
		int levelId = this.CurSelectRoleItem.Level;
		ControllerBase<GuessJokerController>.Instance.JokerGuessRewardRequest(levelId, delegate
		{
			this.RefreshDetailView(levelId);
			GuessJokerSelectRoleItem curSelectRoleItem = this.CurSelectRoleItem;
			if (curSelectRoleItem == null)
			{
				return;
			}
			curSelectRoleItem.RefreshRedDot();
		});
	}

	// Token: 0x060072A9 RID: 29353 RVA: 0x001DF76C File Offset: 0x001DD96C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Role"))
		{
			return null;
		}
		int index = int.Parse(configParams[1]);
		GuessJokerSelectRoleItem layoutItemByIndex = this.RoleLayout.GetLayoutItemByIndex(index);
		UUIItem uuiitem = (layoutItemByIndex != null) ? layoutItemByIndex.GuideGetToggleItem() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04003753 RID: 14163
	public PopupCaptionItem PopupCaption;

	// Token: 0x04003754 RID: 14164
	private GenericLayout<GuessJokerSelectRoleItem, int> RoleLayout;

	// Token: 0x04003755 RID: 14165
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

	// Token: 0x04003756 RID: 14166
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x04003757 RID: 14167
	[Nullable(2)]
	private GuessJokerSelectRoleItem CurSelectRoleItem;

	// Token: 0x04003758 RID: 14168
	[Nullable(2)]
	private string CurCameraName;

	// Token: 0x04003759 RID: 14169
	[Nullable(2)]
	private string CurCameraSettingName;

	// Token: 0x0400375A RID: 14170
	[Nullable(2)]
	private GuessJokerHeroSkillItem HeroSkillItem;

	// Token: 0x0400375B RID: 14171
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0400375C RID: 14172
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly Dictionary<string, Action> SequenceFinishCallbackMap = new Dictionary<string, Action>();

	// Token: 0x0400375D RID: 14173
	private bool IsConfirmHide;
}
