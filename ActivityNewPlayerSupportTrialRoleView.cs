using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001476 RID: 5238
[NullableContext(2)]
[Nullable(0)]
public class ActivityNewPlayerSupportTrialRoleView : UiViewBase
{
	// Token: 0x06009281 RID: 37505 RVA: 0x0026A2A2 File Offset: 0x002684A2
	[NullableContext(1)]
	public ActivityNewPlayerSupportTrialRoleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009282 RID: 37506 RVA: 0x0026A2C4 File Offset: 0x002684C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(16, new Action(this.OnRolePreviewBtnClick)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnSyncLevelBtnClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnRoleTrialConfirmClick)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnRoleFormationClick)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnHelpClick))
		};
	}

	// Token: 0x06009283 RID: 37507 RVA: 0x0026A510 File Offset: 0x00268710
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityNewPlayerSupportTrialRoleView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009284 RID: 37508 RVA: 0x0026A554 File Offset: 0x00268754
	protected override void OnBeforeDestroy()
	{
		this.SequencePlayer = null;
		this.LoadingSequencePlayer = null;
		UUIItem item = base.GetItem(3);
		AUIBaseActor auibaseActor = ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
		if (auibaseActor != null)
		{
			auibaseActor.OnSequencePlayEvent.Unbind();
		}
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Unbind();
		}
		this.RoleSpineItemMap.Clear();
		this.DestroyTimer();
	}

	// Token: 0x06009285 RID: 37509 RVA: 0x0026A5BE File Offset: 0x002687BE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCurTrialRoleGroupChanged, new Action<int?, int>(this.OnCurTrialRoleGroupChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnGroupTrialRoleChanged, new Action<int, int, int>(this.OnGroupTrialRoleChanged));
	}

	// Token: 0x06009286 RID: 37510 RVA: 0x0026A5F8 File Offset: 0x002687F8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCurTrialRoleGroupChanged, new Action<int?, int>(this.OnCurTrialRoleGroupChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGroupTrialRoleChanged, new Action<int, int, int>(this.OnGroupTrialRoleChanged));
	}

	// Token: 0x06009287 RID: 37511 RVA: 0x0026A634 File Offset: 0x00268834
	private UniTask InitTrialRoleListComponent()
	{
		ActivityNewPlayerSupportTrialRoleView.<InitTrialRoleListComponent>d__21 <InitTrialRoleListComponent>d__;
		<InitTrialRoleListComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTrialRoleListComponent>d__.<>4__this = this;
		<InitTrialRoleListComponent>d__.<>1__state = -1;
		<InitTrialRoleListComponent>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<InitTrialRoleListComponent>d__21>(ref <InitTrialRoleListComponent>d__);
		return <InitTrialRoleListComponent>d__.<>t__builder.Task;
	}

	// Token: 0x06009288 RID: 37512 RVA: 0x0026A678 File Offset: 0x00268878
	private void InitCommonTabTitle()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseButton));
		this.CaptionItem.SetTitleLocalText(this.ViewModel.CaptionText);
		this.CaptionItem.SetTitleIcon(this.ViewModel.CaptionIcon);
	}

	// Token: 0x06009289 RID: 37513 RVA: 0x0026A6DC File Offset: 0x002688DC
	private void InitSequence()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		(base.GetItem(3).GetOwner() as AUIBaseActor).OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
		this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnLevelUpSequenceEvent));
		this.LoadingSequencePlayer = new UiSequencePlayer(base.GetItem(18));
	}

	// Token: 0x0600928A RID: 37514 RVA: 0x0026A750 File Offset: 0x00268950
	private void OnClickCloseButton()
	{
		if (this.WaitingLoad)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600928B RID: 37515 RVA: 0x0026A764 File Offset: 0x00268964
	private void OnTrialRoleItemSelect(int groupId)
	{
		TrialRoleGroupData trialRoleByGroupId = this.ViewModel.GetTrialRoleByGroupId(groupId);
		if (trialRoleByGroupId == null)
		{
			return;
		}
		this.TrialRoleGroupData = trialRoleByGroupId;
		this.RefreshRoleItemAndViewAsync();
	}

	// Token: 0x0600928C RID: 37516 RVA: 0x0026A790 File Offset: 0x00268990
	private UniTask RefreshRoleItemAndViewAsync()
	{
		ActivityNewPlayerSupportTrialRoleView.<RefreshRoleItemAndViewAsync>d__26 <RefreshRoleItemAndViewAsync>d__;
		<RefreshRoleItemAndViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleItemAndViewAsync>d__.<>4__this = this;
		<RefreshRoleItemAndViewAsync>d__.<>1__state = -1;
		<RefreshRoleItemAndViewAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<RefreshRoleItemAndViewAsync>d__26>(ref <RefreshRoleItemAndViewAsync>d__);
		return <RefreshRoleItemAndViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600928D RID: 37517 RVA: 0x0026A7D4 File Offset: 0x002689D4
	private void OnCurTrialRoleGroupChanged(int? preGroupId, int curGroupId)
	{
		int trialRoleId = this.TrialRoleGroupData.TrialRoleId;
		EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
		if (Array.IndexOf<int>(((getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null) ?? Array.Empty<int>(), trialRoleId) >= 0)
		{
			this.RefreshCurTrialRoleGroupAsync();
			return;
		}
		this.RefreshCurTrialRoleGroup();
	}

	// Token: 0x0600928E RID: 37518 RVA: 0x0026A828 File Offset: 0x00268A28
	private void OnGroupTrialRoleChanged(int preRoleId, int curRoleId, int groupId)
	{
		int trialRoleId = this.TrialRoleGroupData.TrialRoleId;
		bool playLvUpAnim = trialRoleId != preRoleId && trialRoleId == curRoleId;
		this.RefreshRoleView(playLvUpAnim);
	}

	// Token: 0x0600928F RID: 37519 RVA: 0x0026A854 File Offset: 0x00268A54
	private void OnRolePreviewBtnClick()
	{
		if (this.WaitingLoad)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (TrialRoleGroupData trialRoleGroupData in this.ViewModel.GetTrialRoleList())
		{
			list.Add(trialRoleGroupData.GetPreviewTrialRoleId());
		}
		TrialRoleGroupData trialRoleGroupData2 = this.TrialRoleGroupData;
		int selectRoleId = (trialRoleGroupData2 != null) ? trialRoleGroupData2.GetPreviewTrialRoleId() : 0;
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, selectRoleId, list, null, null);
	}

	// Token: 0x06009290 RID: 37520 RVA: 0x0026A8EC File Offset: 0x00268AEC
	private void OnSyncLevelBtnClick()
	{
		if (this.WaitingLoad)
		{
			return;
		}
		if (!ModelBase<TrialRoleModel>.Instance.CheckCanOperateTrialRole())
		{
			return;
		}
		TrialRoleGroupData trialRoleGroupData = this.TrialRoleGroupData;
		if (trialRoleGroupData == null || !trialRoleGroupData.CanUpgrade())
		{
			return;
		}
		TrialRoleGroupData trialRoleGroupData2 = this.TrialRoleGroupData;
		int? num = (trialRoleGroupData2 != null) ? new int?(trialRoleGroupData2.TrialRoleId) : null;
		if (num == null)
		{
			return;
		}
		Action<int> requestTrialRoleLvUpFunc = this.ViewModel.GetRequestTrialRoleLvUpFunc();
		if (requestTrialRoleLvUpFunc == null)
		{
			return;
		}
		requestTrialRoleLvUpFunc(num.Value);
	}

	// Token: 0x06009291 RID: 37521 RVA: 0x0026A96C File Offset: 0x00268B6C
	private void OnRoleTrialConfirmClick()
	{
		if (this.WaitingLoad)
		{
			return;
		}
		if (!ModelBase<TrialRoleModel>.Instance.CheckCanOperateTrialRole())
		{
			return;
		}
		TrialRoleGroupData trialRoleGroupData = this.TrialRoleGroupData;
		int? num = (trialRoleGroupData != null) ? new int?(trialRoleGroupData.TrialRoleId) : null;
		if (num == null)
		{
			return;
		}
		Action<int, Action<int>> requestSetCurUseTrialRoleFunc = this.ViewModel.GetRequestSetCurUseTrialRoleFunc();
		if (requestSetCurUseTrialRoleFunc == null)
		{
			return;
		}
		requestSetCurUseTrialRoleFunc(num.Value, new Action<int>(this.OnSetCurUseTrialRoleCallback));
	}

	// Token: 0x06009292 RID: 37522 RVA: 0x0026A9E4 File Offset: 0x00268BE4
	private void OnSetCurUseTrialRoleCallback(int roleId)
	{
		int trialRoleId = this.TrialRoleGroupData.TrialRoleId;
		EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
		if (Array.IndexOf<int>(((getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null) ?? Array.Empty<int>(), trialRoleId) >= 0 || ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TrialRoleChooseConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<EditFormationController>.Instance.OpenEditFormationView(null);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06009293 RID: 37523 RVA: 0x0026AA79 File Offset: 0x00268C79
	private void OnRoleFormationClick()
	{
		if (this.WaitingLoad)
		{
			return;
		}
		ControllerBase<EditFormationController>.Instance.OpenEditFormationView(null);
	}

	// Token: 0x06009294 RID: 37524 RVA: 0x0026AA8F File Offset: 0x00268C8F
	private void OnHelpClick()
	{
		if (this.WaitingLoad)
		{
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(this.ViewModel.HelpId);
	}

	// Token: 0x06009295 RID: 37525 RVA: 0x0026AAAF File Offset: 0x00268CAF
	[NullableContext(1)]
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Sequence_Role_Switch")
		{
			this.RefreshRoleItem();
		}
	}

	// Token: 0x06009296 RID: 37526 RVA: 0x0026AAC4 File Offset: 0x00268CC4
	[NullableContext(1)]
	private void OnLevelUpSequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Sequence_Change_Number")
		{
			TrialRoleInfo trialRoleConfig = this.TrialRoleGroupData.TrialRoleConfig;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Text_PlayerLevelNum_Text", new <>z__ReadOnlySingleElementList<object>(trialRoleConfig.Level));
		}
	}

	// Token: 0x06009297 RID: 37527 RVA: 0x0026AB14 File Offset: 0x00268D14
	private UniTask RefreshRoleItemAsync(bool playSwitchAnim = false)
	{
		ActivityNewPlayerSupportTrialRoleView.<RefreshRoleItemAsync>d__37 <RefreshRoleItemAsync>d__;
		<RefreshRoleItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleItemAsync>d__.<>4__this = this;
		<RefreshRoleItemAsync>d__.playSwitchAnim = playSwitchAnim;
		<RefreshRoleItemAsync>d__.<>1__state = -1;
		<RefreshRoleItemAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<RefreshRoleItemAsync>d__37>(ref <RefreshRoleItemAsync>d__);
		return <RefreshRoleItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009298 RID: 37528 RVA: 0x0026AB60 File Offset: 0x00268D60
	private void RefreshRoleItem()
	{
		TrialRoleInfo trialRoleConfig = this.TrialRoleGroupData.TrialRoleConfig;
		foreach (KeyValuePair<int, NewPlayerSupportRoleSpineItem> keyValuePair in this.RoleSpineItemMap)
		{
			int key = keyValuePair.Key;
			keyValuePair.Value.SetUiActive(key == trialRoleConfig.GroupId);
		}
		NewPlayerSupportRoleBaseItem curRoleItem = this.CurRoleItem;
		if (curRoleItem == null)
		{
			return;
		}
		curRoleItem.Update(trialRoleConfig);
	}

	// Token: 0x06009299 RID: 37529 RVA: 0x0026ABE8 File Offset: 0x00268DE8
	private void RefreshRoleView(bool playLvUpAnim = false)
	{
		base.GetItem(18).SetUIActive(false);
		int trialRoleId = this.TrialRoleGroupData.TrialRoleId;
		int trialRoleGroupId = this.TrialRoleGroupData.TrialRoleGroupId;
		int realRoleId = this.TrialRoleGroupData.RealRoleId;
		string roleStand = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialRoleConfigByRoleId(realRoleId).Value.RoleStand;
		UUITexture roleTex = base.GetTexture(2);
		base.SetTextureByPath(roleStand, roleTex, null, delegate(bool _)
		{
			roleTex.SetSizeFromTexture();
		});
		string configColorByRealRoleId = this.GetConfigColorByRealRoleId(realRoleId);
		if (!StringUtils.IsBlank(configColorByRealRoleId))
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetColor(FColor.FromHex(configColorByRealRoleId));
			}
		}
		this.RefreshRoleTagAsync();
		this.RefreshRoleDescAsync();
		bool uiactive = this.TrialRoleGroupData.CanUpgrade();
		bool flag = this.TrialRoleGroupData.IsUnlocked();
		int? curUseTrialRoleId = this.ViewModel.GetCurUseTrialRoleId();
		int num = trialRoleId;
		bool flag2 = curUseTrialRoleId.GetValueOrDefault() == num & curUseTrialRoleId != null;
		base.GetItem(10).SetUIActive(!flag);
		base.GetButton(11).RootUIComp.Get().SetUIActive(uiactive);
		base.GetItem(12).SetUIActive(uiactive);
		base.GetItem(9).SetUIActive(flag && flag2);
		base.GetButton(5).RootUIComp.Get().SetUIActive(flag && flag2);
		base.GetButton(4).RootUIComp.Get().SetUIActive(flag && !flag2);
		if (!flag)
		{
			string trialRoleGroupUnlockDesc = this.ViewModel.GetTrialRoleGroupUnlockDesc(trialRoleGroupId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), trialRoleGroupUnlockDesc, Array.Empty<object>());
		}
		int previewTrialRoleId = this.TrialRoleGroupData.GetPreviewTrialRoleId();
		TrialRoleInfo? trialRoleConfig = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(previewTrialRoleId);
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Text_WorldLevelNum_Text", new <>z__ReadOnlySingleElementList<object>(originWorldLevel));
		if (playLvUpAnim)
		{
			this.SequencePlayer.PlayLevelSequenceByName("Saoguang", false, null, false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Text_PlayerLevelNum_Text", new <>z__ReadOnlySingleElementList<object>(trialRoleConfig.Value.Level));
	}

	// Token: 0x0600929A RID: 37530 RVA: 0x0026AE4C File Offset: 0x0026904C
	private UniTask RefreshRoleTagAsync()
	{
		ActivityNewPlayerSupportTrialRoleView.<RefreshRoleTagAsync>d__40 <RefreshRoleTagAsync>d__;
		<RefreshRoleTagAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleTagAsync>d__.<>4__this = this;
		<RefreshRoleTagAsync>d__.<>1__state = -1;
		<RefreshRoleTagAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<RefreshRoleTagAsync>d__40>(ref <RefreshRoleTagAsync>d__);
		return <RefreshRoleTagAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600929B RID: 37531 RVA: 0x0026AE90 File Offset: 0x00269090
	private UniTask RefreshRoleDescAsync()
	{
		ActivityNewPlayerSupportTrialRoleView.<RefreshRoleDescAsync>d__41 <RefreshRoleDescAsync>d__;
		<RefreshRoleDescAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleDescAsync>d__.<>4__this = this;
		<RefreshRoleDescAsync>d__.<>1__state = -1;
		<RefreshRoleDescAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<RefreshRoleDescAsync>d__41>(ref <RefreshRoleDescAsync>d__);
		return <RefreshRoleDescAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600929C RID: 37532 RVA: 0x0026AED4 File Offset: 0x002690D4
	private UniTask InitRoleSpineItem()
	{
		ActivityNewPlayerSupportTrialRoleView.<InitRoleSpineItem>d__42 <InitRoleSpineItem>d__;
		<InitRoleSpineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleSpineItem>d__.<>4__this = this;
		<InitRoleSpineItem>d__.<>1__state = -1;
		<InitRoleSpineItem>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<InitRoleSpineItem>d__42>(ref <InitRoleSpineItem>d__);
		return <InitRoleSpineItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600929D RID: 37533 RVA: 0x0026AF18 File Offset: 0x00269118
	private UniTask InitRoleCommonItem()
	{
		ActivityNewPlayerSupportTrialRoleView.<InitRoleCommonItem>d__43 <InitRoleCommonItem>d__;
		<InitRoleCommonItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleCommonItem>d__.<>4__this = this;
		<InitRoleCommonItem>d__.<>1__state = -1;
		<InitRoleCommonItem>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<InitRoleCommonItem>d__43>(ref <InitRoleCommonItem>d__);
		return <InitRoleCommonItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600929E RID: 37534 RVA: 0x0026AF5B File Offset: 0x0026915B
	private void PlaySwitchAnim()
	{
		NewPlayerSupportRoleBaseItem curRoleItem = this.CurRoleItem;
		if (curRoleItem == null)
		{
			return;
		}
		curRoleItem.PlaySwitchSeq();
	}

	// Token: 0x0600929F RID: 37535 RVA: 0x0026AF70 File Offset: 0x00269170
	[NullableContext(1)]
	private string GetConfigColorByRealRoleId(int realRoleId)
	{
		string result;
		if (!ActivityNewPlayerSupportDefine.RoleBgColor.TryGetValue(realRoleId, out result))
		{
			return "";
		}
		return result;
	}

	// Token: 0x060092A0 RID: 37536 RVA: 0x0026AF93 File Offset: 0x00269193
	private void RefreshCurTrialRoleGroup()
	{
		this.RefreshRoleView(false);
	}

	// Token: 0x060092A1 RID: 37537 RVA: 0x0026AF9C File Offset: 0x0026919C
	private UniTask RefreshCurTrialRoleGroupAsync()
	{
		ActivityNewPlayerSupportTrialRoleView.<RefreshCurTrialRoleGroupAsync>d__47 <RefreshCurTrialRoleGroupAsync>d__;
		<RefreshCurTrialRoleGroupAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurTrialRoleGroupAsync>d__.<>4__this = this;
		<RefreshCurTrialRoleGroupAsync>d__.<>1__state = -1;
		<RefreshCurTrialRoleGroupAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<RefreshCurTrialRoleGroupAsync>d__47>(ref <RefreshCurTrialRoleGroupAsync>d__);
		return <RefreshCurTrialRoleGroupAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060092A2 RID: 37538 RVA: 0x0026AFE0 File Offset: 0x002691E0
	private void ShowLoading()
	{
		if (this.AutoCloseTimer == null)
		{
			base.GetItem(18).SetUIActive(true);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("TrialRoleViewClosing", true);
			this.LoadingSequencePlayer.PlaySequence("Progressing", false, null);
			this.AutoCloseTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				base.GetItem(18).SetUIActive(false);
				Singleton<UiLayer>.Instance.SetShowMaskLayer("TrialRoleViewClosing", false);
			}, (float)this.AutoCloseViewTime, null, null, true, 1f);
		}
	}

	// Token: 0x060092A3 RID: 37539 RVA: 0x0026B058 File Offset: 0x00269258
	private UniTask WaitEntityLoad()
	{
		ActivityNewPlayerSupportTrialRoleView.<WaitEntityLoad>d__49 <WaitEntityLoad>d__;
		<WaitEntityLoad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitEntityLoad>d__.<>4__this = this;
		<WaitEntityLoad>d__.<>1__state = -1;
		<WaitEntityLoad>d__.<>t__builder.Start<ActivityNewPlayerSupportTrialRoleView.<WaitEntityLoad>d__49>(ref <WaitEntityLoad>d__);
		return <WaitEntityLoad>d__.<>t__builder.Task;
	}

	// Token: 0x060092A4 RID: 37540 RVA: 0x0026B09B File Offset: 0x0026929B
	private void DestroyTimer()
	{
		if (this.AutoCloseTimer == null)
		{
			return;
		}
		if (TimerSystem.GameplayTimeInstance.Has(this.AutoCloseTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoCloseTimer);
		}
		this.AutoCloseTimer = null;
	}

	// Token: 0x060092A5 RID: 37541 RVA: 0x0026B0D0 File Offset: 0x002692D0
	private bool CanSelectItem()
	{
		return !this.WaitingLoad;
	}

	// Token: 0x040043CC RID: 17356
	private PopupCaptionItem CaptionItem;

	// Token: 0x040043CD RID: 17357
	private NewPlayerSupportTrialRoleListComponent TrialRoleListComponent;

	// Token: 0x040043CE RID: 17358
	private TrialRoleGroupData TrialRoleGroupData;

	// Token: 0x040043CF RID: 17359
	private NewPlayerSupportRoleCommonItem RoleCommonItem;

	// Token: 0x040043D0 RID: 17360
	[Nullable(1)]
	private readonly Dictionary<int, NewPlayerSupportRoleSpineItem> RoleSpineItemMap = new Dictionary<int, NewPlayerSupportRoleSpineItem>();

	// Token: 0x040043D1 RID: 17361
	private NewPlayerSupportRoleBaseItem CurRoleItem;

	// Token: 0x040043D2 RID: 17362
	private RoleTagMediumIconItem RoleTagItem;

	// Token: 0x040043D3 RID: 17363
	private ActivityRoleDescribeComponent RoleDescComponent;

	// Token: 0x040043D4 RID: 17364
	private NewPlayerSupportTrialRoleViewModel ViewModel;

	// Token: 0x040043D5 RID: 17365
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040043D6 RID: 17366
	private bool WaitingLoad;

	// Token: 0x040043D7 RID: 17367
	private TimerHandle AutoCloseTimer;

	// Token: 0x040043D8 RID: 17368
	private readonly int AutoCloseViewTime = 30000;

	// Token: 0x040043D9 RID: 17369
	protected UiSequencePlayer LoadingSequencePlayer;

	// Token: 0x02007876 RID: 30838
	[NullableContext(0)]
	private static class EComponentType
	{
		// Token: 0x040296D8 RID: 169688
		public const int TitleItem = 0;

		// Token: 0x040296D9 RID: 169689
		public const int RoleIconBg = 1;

		// Token: 0x040296DA RID: 169690
		public const int RoleIcon = 2;

		// Token: 0x040296DB RID: 169691
		public const int RoleSpineItem = 3;

		// Token: 0x040296DC RID: 169692
		public const int RoleTrialConfirmBtn = 4;

		// Token: 0x040296DD RID: 169693
		public const int RoleFormationBtn = 5;

		// Token: 0x040296DE RID: 169694
		public const int LevelTxt = 6;

		// Token: 0x040296DF RID: 169695
		public const int RoleLevelTxt = 7;

		// Token: 0x040296E0 RID: 169696
		public const int HelpBtn = 8;

		// Token: 0x040296E1 RID: 169697
		public const int TrialingItem = 9;

		// Token: 0x040296E2 RID: 169698
		public const int LockItem = 10;

		// Token: 0x040296E3 RID: 169699
		public const int SyncLevelBtn = 11;

		// Token: 0x040296E4 RID: 169700
		public const int SyncLevelRedDot = 12;

		// Token: 0x040296E5 RID: 169701
		public const int RoleAttrItem = 13;

		// Token: 0x040296E6 RID: 169702
		public const int RoleTagItem = 14;

		// Token: 0x040296E7 RID: 169703
		public const int RoleListItem = 15;

		// Token: 0x040296E8 RID: 169704
		public const int RolePreviewBtn = 16;

		// Token: 0x040296E9 RID: 169705
		public const int LockTxt = 17;

		// Token: 0x040296EA RID: 169706
		public const int LoadingItem = 18;
	}
}
