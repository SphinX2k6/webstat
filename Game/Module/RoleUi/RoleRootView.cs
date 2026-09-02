using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.RoleUi.Component;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.UiComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x0200505D RID: 20573
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleRootView : UiViewBase
	{
		// Token: 0x06034F4B RID: 216907 RVA: 0x00D477E4 File Offset: 0x00D459E4
		public RoleRootView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17008B61 RID: 35681
		// (get) Token: 0x06034F4C RID: 216908 RVA: 0x00D47833 File Offset: 0x00D45A33
		private bool IsLock
		{
			get
			{
				return this.Operating;
			}
		}

		// Token: 0x06034F4D RID: 216909 RVA: 0x00D4783B File Offset: 0x00D45A3B
		private void Lock()
		{
			this.Operating = true;
		}

		// Token: 0x06034F4E RID: 216910 RVA: 0x00D47844 File Offset: 0x00D45A44
		private void Unlock()
		{
			this.Operating = false;
			if (this.ViewOperationQueue.Size == 0)
			{
				return;
			}
			OperationParam operationParam = this.ViewOperationQueue.Pop();
			if (operationParam == null)
			{
				return;
			}
			switch (operationParam.OperationType)
			{
			case EOperationType.RefreshRoleList:
				this.RefreshRoleList();
				return;
			case EOperationType.RefreshTabList:
				this.RefreshTabList();
				return;
			case EOperationType.OnRoleSelect:
				this.OnRoleSelect(0);
				return;
			default:
				return;
			}
		}

		// Token: 0x06034F4F RID: 216911 RVA: 0x00D478A8 File Offset: 0x00D45AA8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.RoleListClick)),
				new ValueTuple<int, Delegate>(13, new Action<EToggleState>(this.OnSkillShowTagToggleClick)),
				new ValueTuple<int, Delegate>(14, new Action(this.OnSkillShowTagHelpButtonClick))
			};
		}

		// Token: 0x06034F50 RID: 216912 RVA: 0x00D47A3C File Offset: 0x00D45C3C
		protected override UniTask OnBeforeStartAsync()
		{
			RoleRootView.<OnBeforeStartAsync>d__30 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleRootView.<OnBeforeStartAsync>d__30>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034F51 RID: 216913 RVA: 0x00D47A80 File Offset: 0x00D45C80
		private UniTask InitRoleDevelopEntranceItem()
		{
			RoleRootView.<InitRoleDevelopEntranceItem>d__31 <InitRoleDevelopEntranceItem>d__;
			<InitRoleDevelopEntranceItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleDevelopEntranceItem>d__.<>4__this = this;
			<InitRoleDevelopEntranceItem>d__.<>1__state = -1;
			<InitRoleDevelopEntranceItem>d__.<>t__builder.Start<RoleRootView.<InitRoleDevelopEntranceItem>d__31>(ref <InitRoleDevelopEntranceItem>d__);
			return <InitRoleDevelopEntranceItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034F52 RID: 216914 RVA: 0x00D47AC4 File Offset: 0x00D45CC4
		private UniTask TryRequestTrialRoleInfo()
		{
			RoleRootView.<TryRequestTrialRoleInfo>d__32 <TryRequestTrialRoleInfo>d__;
			<TryRequestTrialRoleInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryRequestTrialRoleInfo>d__.<>4__this = this;
			<TryRequestTrialRoleInfo>d__.<>1__state = -1;
			<TryRequestTrialRoleInfo>d__.<>t__builder.Start<RoleRootView.<TryRequestTrialRoleInfo>d__32>(ref <TryRequestTrialRoleInfo>d__);
			return <TryRequestTrialRoleInfo>d__.<>t__builder.Task;
		}

		// Token: 0x06034F53 RID: 216915 RVA: 0x00D47B08 File Offset: 0x00D45D08
		private void UpdateTrialRoleResonanceData(List<int> trialRoleIdList)
		{
			foreach (int num in trialRoleIdList)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
				if (roleDataById == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Role;
					ELogAuthor author = ELogAuthor.CXJ;
					string message = "角色数据不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("角色Id", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					int parentId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num).Value.ParentId;
					RoleDataBase roleDataById2 = ModelBase<RoleModel>.Instance.GetRoleDataById(parentId, true);
					roleDataById.GetResonanceData().CopyFrom(roleDataById2.GetResonanceData());
				}
			}
		}

		// Token: 0x06034F54 RID: 216916 RVA: 0x00D47BD4 File Offset: 0x00D45DD4
		private void ClearTrialRoleResonanceData()
		{
			List<int> list = new List<int>();
			foreach (int num in this.RoleViewAgent.GetRoleIdList())
			{
				if (RoleUtils.IsTrialRole(num))
				{
					list.Add(num);
				}
			}
			foreach (int num2 in list)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num2, true);
				if (roleDataById == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Role;
					ELogAuthor author = ELogAuthor.CXJ;
					string message = "角色数据不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("角色Id", num2);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					roleDataById.GetResonanceData().Clear();
				}
			}
		}

		// Token: 0x06034F55 RID: 216917 RVA: 0x00D47CBC File Offset: 0x00D45EBC
		private void HandleLoadScene()
		{
			if (!this.CanHandleLoadScene)
			{
				TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
				if (roleSystemRoleActor != null)
				{
					this.TsUiSceneRoleActor = roleSystemRoleActor;
				}
				return;
			}
			this.CanHandleLoadScene = false;
			if (this.TsUiSceneRoleActor == null)
			{
				this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
			}
			this.LoadFloorEffect();
			UiModelBase model = this.TsUiSceneRoleActor.Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			if (uiModelActorComponent == null)
			{
				return;
			}
			uiModelActorComponent.SetTransformByTag("RoleCase");
		}

		// Token: 0x06034F56 RID: 216918 RVA: 0x00D47D33 File Offset: 0x00D45F33
		protected override void OnHandleLoadScene()
		{
			this.HandleLoadScene();
		}

		// Token: 0x06034F57 RID: 216919 RVA: 0x00D47D3C File Offset: 0x00D45F3C
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<EUiTabViewName, int>(EEventName.SelectRoleTabOutside, new Action<EUiTabViewName, int>(this.OnSelectRoleTabOutside));
			Singleton<EventSystem>.Instance.Add(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
			this.RefreshRoleDevButtonVisibility();
			this.RefreshSkillShowTagRoot();
		}

		// Token: 0x06034F58 RID: 216920 RVA: 0x00D47D8D File Offset: 0x00D45F8D
		protected override void OnBeforeShow()
		{
			this.HandleLoadScene();
			this.RefreshRoleList();
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.SetCurrentTabViewState(true);
		}

		// Token: 0x06034F59 RID: 216921 RVA: 0x00D47DAC File Offset: 0x00D45FAC
		protected void RefreshRoleList()
		{
			if (this.IsLock)
			{
				OperationParam element = new OperationParam(EOperationType.RefreshRoleList, null);
				this.ViewOperationQueue.Push(element);
				return;
			}
			this.Lock();
			this.RefreshRoleListAsync().ContinueWith(new Action(this.Unlock));
		}

		// Token: 0x06034F5A RID: 216922 RVA: 0x00D47DF4 File Offset: 0x00D45FF4
		protected UniTask RefreshRoleListAsync()
		{
			RoleRootView.<RefreshRoleListAsync>d__40 <RefreshRoleListAsync>d__;
			<RefreshRoleListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleListAsync>d__.<>4__this = this;
			<RefreshRoleListAsync>d__.<>1__state = -1;
			<RefreshRoleListAsync>d__.<>t__builder.Start<RoleRootView.<RefreshRoleListAsync>d__40>(ref <RefreshRoleListAsync>d__);
			return <RefreshRoleListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034F5B RID: 216923 RVA: 0x00D47E38 File Offset: 0x00D46038
		private UniTask UpdateRoleListAndScrollAsync(int targetRoleId)
		{
			RoleRootView.<UpdateRoleListAndScrollAsync>d__41 <UpdateRoleListAndScrollAsync>d__;
			<UpdateRoleListAndScrollAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateRoleListAndScrollAsync>d__.<>4__this = this;
			<UpdateRoleListAndScrollAsync>d__.targetRoleId = targetRoleId;
			<UpdateRoleListAndScrollAsync>d__.<>1__state = -1;
			<UpdateRoleListAndScrollAsync>d__.<>t__builder.Start<RoleRootView.<UpdateRoleListAndScrollAsync>d__41>(ref <UpdateRoleListAndScrollAsync>d__);
			return <UpdateRoleListAndScrollAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034F5C RID: 216924 RVA: 0x00D47E84 File Offset: 0x00D46084
		protected void RefreshTabList()
		{
			if (this.IsLock)
			{
				OperationParam element = new OperationParam(EOperationType.RefreshTabList, null);
				this.ViewOperationQueue.Push(element);
				return;
			}
			this.Lock();
			this.RefreshTabListAsync().ContinueWith(new Action(this.Unlock));
		}

		// Token: 0x06034F5D RID: 216925 RVA: 0x00D47ECC File Offset: 0x00D460CC
		protected UniTask RefreshTabListAsync()
		{
			RoleRootView.<RefreshTabListAsync>d__43 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<RoleRootView.<RefreshTabListAsync>d__43>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034F5E RID: 216926 RVA: 0x00D47F10 File Offset: 0x00D46110
		protected void OnRoleSelect(int i = 0)
		{
			if (this.IsLock)
			{
				OperationParam element = new OperationParam(EOperationType.OnRoleSelect, null);
				this.ViewOperationQueue.Push(element);
				return;
			}
			this.Lock();
			this.OnRoleSelectAsync().ContinueWith(new Action(this.Unlock));
		}

		// Token: 0x06034F5F RID: 216927 RVA: 0x00D47F58 File Offset: 0x00D46158
		protected UniTask OnRoleSelectAsync()
		{
			RoleRootView.<OnRoleSelectAsync>d__45 <OnRoleSelectAsync>d__;
			<OnRoleSelectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRoleSelectAsync>d__.<>4__this = this;
			<OnRoleSelectAsync>d__.<>1__state = -1;
			<OnRoleSelectAsync>d__.<>t__builder.Start<RoleRootView.<OnRoleSelectAsync>d__45>(ref <OnRoleSelectAsync>d__);
			return <OnRoleSelectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034F60 RID: 216928 RVA: 0x00D47F9B File Offset: 0x00D4619B
		protected void OnSelectRoleTabOutside(EUiTabViewName tabViewName, int roleId)
		{
			this.Lock();
			this.SelectRoleTabOutSide(tabViewName, roleId).ContinueWith(new Action(this.Unlock));
		}

		// Token: 0x06034F61 RID: 216929 RVA: 0x00D47FC0 File Offset: 0x00D461C0
		protected UniTask SelectRoleTabOutSide(EUiTabViewName tabViewName, int roleId)
		{
			RoleRootView.<SelectRoleTabOutSide>d__47 <SelectRoleTabOutSide>d__;
			<SelectRoleTabOutSide>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectRoleTabOutSide>d__.<>4__this = this;
			<SelectRoleTabOutSide>d__.tabViewName = tabViewName;
			<SelectRoleTabOutSide>d__.roleId = roleId;
			<SelectRoleTabOutSide>d__.<>1__state = -1;
			<SelectRoleTabOutSide>d__.<>t__builder.Start<RoleRootView.<SelectRoleTabOutSide>d__47>(ref <SelectRoleTabOutSide>d__);
			return <SelectRoleTabOutSide>d__.<>t__builder.Task;
		}

		// Token: 0x06034F62 RID: 216930 RVA: 0x00D48014 File Offset: 0x00D46214
		protected UniTask SelectRoleOutside(int roleId)
		{
			RoleRootView.<SelectRoleOutside>d__48 <SelectRoleOutside>d__;
			<SelectRoleOutside>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectRoleOutside>d__.<>4__this = this;
			<SelectRoleOutside>d__.roleId = roleId;
			<SelectRoleOutside>d__.<>1__state = -1;
			<SelectRoleOutside>d__.<>t__builder.Start<RoleRootView.<SelectRoleOutside>d__48>(ref <SelectRoleOutside>d__);
			return <SelectRoleOutside>d__.<>t__builder.Task;
		}

		// Token: 0x06034F63 RID: 216931 RVA: 0x00D48060 File Offset: 0x00D46260
		protected void InitTabComponent()
		{
			CommonTabComponentData<RoleTabItem> data = new CommonTabComponentData<RoleTabItem>(new Func<UUIItem, int?, RoleTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<RoleTabItem>(base.GetItem(2), data, new Action(this.CloseClick), false);
			this.LastClickTime = null;
			this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(4), EKeyMode.Default);
		}

		// Token: 0x06034F64 RID: 216932 RVA: 0x00D480F0 File Offset: 0x00D462F0
		protected bool CanToggleChange(int index, bool? forceSwitch = false)
		{
			if (forceSwitch.GetValueOrDefault())
			{
				return true;
			}
			if (this.GetCurrentTabCanNotShowByRoleType(index))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_RoleInformalTrialTips_Text", Array.Empty<object>());
				return false;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return true;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
			if (this.LastClickTime != null)
			{
				double? num = Singleton<Time>.Instance.Now - this.LastClickTime;
				int? num2 = intConfig;
				double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
				if (!(num.GetValueOrDefault() >= num3.GetValueOrDefault() & (num != null & num3 != null)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06034F65 RID: 216933 RVA: 0x00D481D8 File Offset: 0x00D463D8
		private bool GetCurrentTabCanNotShowByRoleType(int index)
		{
			if (this.TabDataList.Count <= 0)
			{
				return false;
			}
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(curSelectRoleId);
			ERoleSystemMode roleSystemMode = this.RoleViewAgent.GetRoleSystemMode();
			return (roleSystemMode == ERoleSystemMode.Trial || roleSystemMode == ERoleSystemMode.SpecialTrial) && roleConfig.Value.RoleType == 5 && this.TabDataList[index].ChildViewName != EUiTabViewName.RoleAttributeTabView && this.TabDataList[index].ChildViewName != EUiTabViewName.RolePhantomTabView && this.TabDataList[index].ChildViewName != EUiTabViewName.RolePreviewAttributeTabView;
		}

		// Token: 0x06034F66 RID: 216934 RVA: 0x00D482A8 File Offset: 0x00D464A8
		private bool IsConflict(int index)
		{
			if (this.RoleViewAgent.Source == ERoleViewSource.WheelTower)
			{
				int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
				IConflictInfo conflictInfo = ModelBase<WheelTowerModel>.Instance.CheckConflict(curSelectRoleId);
				if (conflictInfo == null)
				{
					return false;
				}
				if ((conflictInfo.WeaponConflict && this.TabDataList[index].Id == 4) || (conflictInfo.PhantomConflict && this.TabDataList[index].Id == 5))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06034F67 RID: 216935 RVA: 0x00D48321 File Offset: 0x00D46521
		private RoleTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new RoleTabItem
			{
				IsConflict = new Func<int, bool>(this.IsConflict)
			};
		}

		// Token: 0x06034F68 RID: 216936 RVA: 0x00D4833C File Offset: 0x00D4653C
		private void ToggleCallBack(int index)
		{
			this.ClickTimes++;
			this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
			RoleTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			if (this.CurSelectTabView != null)
			{
				this.RoleViewAgent.SetPreSelectTabName(this.CurSelectTabView);
			}
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, this.RoleViewAgent, null);
			this.RoleViewAgent.SetCurSelectTabName(euiTabViewName);
			this.CurSelectTabIndex = index;
			this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
			this.PlayLightSequence(index, this.ClickTimes);
			this.CanCameraInput = this.CheckCanCameraInput();
			this.RefreshTabHelpId(euiTabViewName);
			this.RefreshRoleBackgroundMusicSwitchItem();
			this.RefreshRoleDevButtonVisibility();
			this.RefreshSkillShowTagRoot();
		}

		// Token: 0x06034F69 RID: 216937 RVA: 0x00D48424 File Offset: 0x00D46624
		private void RefreshRoleDevButtonVisibility()
		{
			this.RoleDevelopEntranceItem.RefreshView();
		}

		// Token: 0x06034F6A RID: 216938 RVA: 0x00D48434 File Offset: 0x00D46634
		private void RefreshTabHelpId(string currentTabName)
		{
			TabComponentWithCaptionItem<RoleTabItem> tabComponent = this.TabComponent;
			if (tabComponent != null)
			{
				tabComponent.SetHelpButtonShowState(false);
			}
			if (currentTabName == EUiTabViewName.RolePhantomTabView.ToString())
			{
				TabComponentWithCaptionItem<RoleTabItem> tabComponent2 = this.TabComponent;
				if (tabComponent2 != null)
				{
					tabComponent2.SetHelpButtonCallBack(delegate
					{
						ControllerBase<HelpController>.Instance.OpenHelpById(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomEquipHelpGroupId());
					});
				}
				TabComponentWithCaptionItem<RoleTabItem> tabComponent3 = this.TabComponent;
				if (tabComponent3 == null)
				{
					return;
				}
				tabComponent3.SetHelpButtonShowState(true);
			}
		}

		// Token: 0x06034F6B RID: 216939 RVA: 0x00D484AC File Offset: 0x00D466AC
		private void UpdateHomeBtnState()
		{
			if (this.TabComponent == null)
			{
				return;
			}
			bool flag = RoleDefine.RoleViewSourceHideHomeInInstance[this.RoleViewAgent.Source];
			this.TabComponent.SetHomeBtnShowState(!flag || !ControllerBase<GameModeController>.Instance.IsInInstance());
		}

		// Token: 0x06034F6C RID: 216940 RVA: 0x00D484F8 File Offset: 0x00D466F8
		private void PlayLightSequence(int tabIndex, int clickTimes)
		{
			string sequencePath = this.TabDataList[tabIndex].LightSequence;
			ALevelSequenceActor alevelSequenceActor;
			if (this.LevelSequenceActorCache.TryGetValue(tabIndex, out alevelSequenceActor))
			{
				if (this.ShowSequencePlayer != null)
				{
					this.ShowSequencePlayer.Stop();
					this.IsLightSequenceLoop = false;
					this.ShowSequencePlayer = null;
				}
				ULevelSequencePlayer sequencePlayer = alevelSequenceActor.SequencePlayer;
				sequencePlayer.Play();
				this.IsLightSequenceLoop = true;
				this.ShowSequencePlayer = sequencePlayer;
				return;
			}
			int num;
			if (this.LevelSequenceActorLoadStatus.TryGetValue(tabIndex, out num) && num == 1)
			{
				return;
			}
			this.LevelSequenceActorLoadStatus[tabIndex] = 1;
			Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(sequencePath, delegate([Nullable(2)] ULevelSequence levelSequenceObject, string _)
			{
				if (ObjectUtils.IsValid(levelSequenceObject))
				{
					FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
					fmovieSceneSequencePlaybackSettings.bRestoreState = true;
					ALevelSequenceActor alevelSequenceActor2 = null;
					ULevelSequencePlayer.CreateLevelSequencePlayer(GlobalData.World, levelSequenceObject, new FMovieSceneSequencePlaybackSettings(), ref alevelSequenceActor2);
					alevelSequenceActor2.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
					alevelSequenceActor2.SetSequence(levelSequenceObject);
					this.LevelSequenceActorCache[tabIndex] = alevelSequenceActor2;
					if (this.ShowSequencePlayer != null)
					{
						this.ShowSequencePlayer.Stop();
						this.IsLightSequenceLoop = false;
						this.ShowSequencePlayer = null;
					}
					if (this.CurSelectTabIndex == tabIndex)
					{
						this.ShowSequencePlayer = alevelSequenceActor2.SequencePlayer;
						alevelSequenceActor2.bOverrideInstanceData = true;
						UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = alevelSequenceActor2.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
						FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform().Value);
						udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
						this.ShowSequencePlayer.Play();
						this.IsLightSequenceLoop = true;
					}
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Role;
					ELogAuthor author = ELogAuthor.LZK;
					string message = "加载level sequence失败:";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sequencePath", sequencePath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.LevelSequenceActorLoadStatus[tabIndex] = 0;
			}, 100, this.MemoryTag);
		}

		// Token: 0x06034F6D RID: 216941 RVA: 0x00D485DE File Offset: 0x00D467DE
		private void OnInputUiLookUp(float value)
		{
			if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.UiCameraControlRotationComponent.AddPitchInput(-value);
		}

		// Token: 0x06034F6E RID: 216942 RVA: 0x00D4860A File Offset: 0x00D4680A
		private void OnInputUiTurn(float value)
		{
			if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.UiCameraControlRotationComponent.AddYawInput(value);
		}

		// Token: 0x06034F6F RID: 216943 RVA: 0x00D48635 File Offset: 0x00D46835
		private void OnInputUiZoom(string axisName, float value)
		{
			if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.UiCameraControlRotationComponent.AddZoomInput(value);
		}

		// Token: 0x06034F70 RID: 216944 RVA: 0x00D48660 File Offset: 0x00D46860
		private void OnRightStickPress()
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
			if (lastHandleData != null)
			{
				Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData.HandleName, true, true, "1001", false, null, null);
			}
		}

		// Token: 0x06034F71 RID: 216945 RVA: 0x00D486A7 File Offset: 0x00D468A7
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
			{
				this.TouchMoved();
			}
		}

		// Token: 0x06034F72 RID: 216946 RVA: 0x00D486C4 File Offset: 0x00D468C4
		private void TouchMoved()
		{
			if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
			{
				float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
				this.UiCameraControlRotationComponent.AddZoomInput(-fingerExpandCloseValue);
			}
		}

		// Token: 0x06034F73 RID: 216947 RVA: 0x00D486F8 File Offset: 0x00D468F8
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x06034F74 RID: 216948 RVA: 0x00D48730 File Offset: 0x00D46930
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			RoleRootView.<>c__DisplayClass66_0 CS$<>8__locals1 = new RoleRootView.<>c__DisplayClass66_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.IsLock)
			{
				Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.LZK, "异步操作执行过程中不能触发引导", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (configParams[0] == "Rover")
			{
				RoleRootView.<>c__DisplayClass66_1 CS$<>8__locals2 = new RoleRootView.<>c__DisplayClass66_1();
				CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
				IReadOnlyList<int> roleIdList = this.RoleViewAgent.GetRoleIdList();
				int num = -1;
				for (int i = 0; i < roleIdList.Count; i++)
				{
					int roleId = roleIdList[i];
					if (ModelBase<RoleModel>.Instance.IsMainRole(roleId))
					{
						num = i;
						break;
					}
				}
				if (num < 0 || num >= roleIdList.Count)
				{
					return null;
				}
				RoleRootView.<>c__DisplayClass66_1 CS$<>8__locals3 = CS$<>8__locals2;
				RoleListComponent roleListComponent = this.RoleListComponent;
				RoleListItem targetItem;
				if (roleListComponent == null)
				{
					targetItem = null;
				}
				else
				{
					GenericScrollViewNew<RoleListItem, RoleListItemData> selfScrollView = roleListComponent.GetSelfScrollView();
					targetItem = ((selfScrollView != null) ? selfScrollView.GetScrollItemByIndex(num) : null);
				}
				CS$<>8__locals3.targetItem = targetItem;
				if (CS$<>8__locals2.targetItem == null)
				{
					return null;
				}
				TimerSystem.Instance.Next(delegate(float _)
				{
					CS$<>8__locals2.CS$<>8__locals1.<>4__this.RoleListComponent.GetSelfScrollView().ScrollTo(CS$<>8__locals2.targetItem.GetRootItem(), false);
				}, null, null);
				RoleIconItem roleIconItem = CS$<>8__locals2.targetItem.RoleIconItem;
				UUIItem uuiitem = (roleIconItem != null) ? roleIconItem.GetRootItem() : null;
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
			else if (configParams.Length == 2 && configParams[0] == ConfigBase<GuideConfig>.Instance.TabTag)
			{
				if (this.TabComponent == null)
				{
					CommonTabComponentData<RoleTabItem> data = new CommonTabComponentData<RoleTabItem>(new Func<UUIItem, int?, RoleTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
					this.TabComponent = new TabComponentWithCaptionItem<RoleTabItem>(base.GetItem(2), data, new Action(this.CloseClick), false);
					this.UpdateHomeBtnState();
				}
				GenericLayout<RoleTabItem, CommonTabItemData> layout = this.TabComponent.GetTabComponent().GetLayout();
				if (layout == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.TL;
					string message = "角色界面聚焦引导的额外参数配置有误, 找不到Layout";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				int index = int.Parse(configParams[1]);
				RoleTabItem layoutItemByIndex = layout.GetLayoutItemByIndex(index);
				if (layoutItemByIndex == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.LZK, "Layout加载未完成", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return new UUIItem[]
				{
					layoutItemByIndex.GetRootItem(),
					layoutItemByIndex.GetIconSprite()
				};
			}
			else
			{
				if (configParams.Length == 2 && configParams[0] == ConfigBase<GuideConfig>.Instance.SlotTag)
				{
					int index2 = int.Parse(configParams[1]);
					TWeakObjectPtr<UUIItem> rootUIComp = this.RoleListComponent.GetSelfScrollView().GetScrollItemByIndex(index2).GetToggleForGuide().RootUIComp;
					return new UUIItem[]
					{
						rootUIComp,
						rootUIComp
					};
				}
				string s;
				if (configParams.Length == 2)
				{
					s = Array.Find<string>(configParams, (string param) => int.Parse(param) == ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId());
				}
				else
				{
					s = configParams[0];
				}
				int num2 = int.Parse(s);
				IReadOnlyList<int> roleIdList2 = this.RoleViewAgent.GetRoleIdList();
				int num3 = -1;
				for (int j = 0; j < roleIdList2.Count; j++)
				{
					if (roleIdList2[j] == num2)
					{
						num3 = j;
						break;
					}
				}
				if (num3 < 0 || num3 >= roleIdList2.Count)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Guide;
					ELogAuthor author2 = ELogAuthor.TL;
					string message2 = "角色界面聚焦引导的额外参数配置有误, 找不到角色Id";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("roleId", num2);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return null;
				}
				RoleRootView.<>c__DisplayClass66_0 CS$<>8__locals4 = CS$<>8__locals1;
				RoleListComponent roleListComponent2 = this.RoleListComponent;
				RoleListItem targetItem2;
				if (roleListComponent2 == null)
				{
					targetItem2 = null;
				}
				else
				{
					GenericScrollViewNew<RoleListItem, RoleListItemData> selfScrollView2 = roleListComponent2.GetSelfScrollView();
					targetItem2 = ((selfScrollView2 != null) ? selfScrollView2.GetScrollItemByIndex(num3) : null);
				}
				CS$<>8__locals4.targetItem2 = targetItem2;
				if (CS$<>8__locals1.targetItem2 == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Guide;
					ELogAuthor author3 = ELogAuthor.LZK;
					string message3 = "角色界面聚焦引导的额外参数配置有误, 找不到角色Id";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("roleId", num2);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return null;
				}
				TimerSystem.Instance.Next(delegate(float _)
				{
					CS$<>8__locals1.<>4__this.RoleListComponent.GetSelfScrollView().ScrollTo(CS$<>8__locals1.targetItem2.GetRootItem(), false);
				}, null, null);
				RoleIconItem roleIconItem2 = CS$<>8__locals1.targetItem2.RoleIconItem;
				UUIItem uuiitem2 = (roleIconItem2 != null) ? roleIconItem2.GetRootItem() : null;
				if (uuiitem2 == null)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Guide;
					ELogAuthor author4 = ELogAuthor.LZK;
					string message4 = "角色界面聚焦引导的额外参数配置有误, 找不到角色Id";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("roleId", num2);
					instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
		}

		// Token: 0x06034F75 RID: 216949 RVA: 0x00D48B42 File Offset: 0x00D46D42
		protected void CloseClick()
		{
			if (this.RoleViewAgent.Source == ERoleViewSource.WheelTower)
			{
				this.ClearTrialRoleResonanceData();
			}
			base.CloseMe(null);
		}

		// Token: 0x06034F76 RID: 216950 RVA: 0x00D48B5F File Offset: 0x00D46D5F
		protected void OnInternalViewQuit()
		{
			this.RoleViewAgent.RoleViewState = ERoleViewState.External;
			this.ShowRoleList();
			this.TabComponent.ShowItem();
		}

		// Token: 0x06034F77 RID: 216951 RVA: 0x00D48B7E File Offset: 0x00D46D7E
		protected void OnInternalViewEnter()
		{
			this.RoleViewAgent.RoleViewState = ERoleViewState.Internal;
			this.HideRoleList();
			this.TabComponent.HideItem();
		}

		// Token: 0x06034F78 RID: 216952 RVA: 0x00D48BA0 File Offset: 0x00D46DA0
		private void ShowRoleList()
		{
			this.UiViewSequence.PlaySequence("RoleListStart", false, null);
		}

		// Token: 0x06034F79 RID: 216953 RVA: 0x00D48BC8 File Offset: 0x00D46DC8
		private void HideRoleList()
		{
			this.UiViewSequence.PlaySequence("RoleListClose", false, null);
		}

		// Token: 0x06034F7A RID: 216954 RVA: 0x00D48BEF File Offset: 0x00D46DEF
		protected void RoleListClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSelectionView, this.RoleViewAgent, null);
		}

		// Token: 0x06034F7B RID: 216955 RVA: 0x00D48C08 File Offset: 0x00D46E08
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.SwitchRootTabState, new Action<bool>(this.SwitchPanelTabState));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.AttributeComponentEvent, new Action<bool>(this.PlayRightAnimation));
			Singleton<EventSystem>.Instance.Add(EEventName.UiRoleSequenceEndKeyFrame, new Action(this.UiRoleSequenceEndKeyFrame));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.SelectRoleTab, new Action<int>(this.ToggleCallBack));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRoleInternalViewEnter, new Action(this.OnInternalViewEnter));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRoleInternalViewQuit, new Action(this.OnInternalViewQuit));
			Singleton<EventSystem>.Instance.Add<UiCameraHandleData, UiCameraHandleData, string>(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
			Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSelect));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			UUIDraggableComponent draggable = base.GetDraggable(6);
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
			draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
			draggable.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
			Singleton<EventSystem>.Instance.Add<string, float>(EEventName.NavigationTriggerRoleZoom, new Action<string, float>(this.OnInputUiZoom));
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationTriggerRoleReset, new Action(this.OnRightStickPress));
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06034F7C RID: 216956 RVA: 0x00D48E20 File Offset: 0x00D47020
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.SwitchRootTabState, new Action<bool>(this.SwitchPanelTabState));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.AttributeComponentEvent, new Action<bool>(this.PlayRightAnimation));
			Singleton<EventSystem>.Instance.Remove(EEventName.UiRoleSequenceEndKeyFrame, new Action(this.UiRoleSequenceEndKeyFrame));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.SelectRoleTab, new Action<int>(this.ToggleCallBack));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleInternalViewEnter, new Action(this.OnInternalViewEnter));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleInternalViewQuit, new Action(this.OnInternalViewQuit));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSelect));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x06034F7D RID: 216957 RVA: 0x00D48F10 File Offset: 0x00D47110
		private void RemoveCameraEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<UiCameraHandleData, UiCameraHandleData, string>(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
			Singleton<EventSystem>.Instance.Remove<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
			UUIDraggableComponent draggable = base.GetDraggable(6);
			draggable.OnPointerBeginDragCallBack.Unbind();
			draggable.OnPointerDragCallBack.Unbind();
			draggable.OnPointerEndDragCallBack.Unbind();
			draggable.OnPointerScrollCallBack.Unbind();
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
			Singleton<EventSystem>.Instance.Remove<string, float>(EEventName.NavigationTriggerRoleZoom, new Action<string, float>(this.OnInputUiZoom));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleReset, new Action(this.OnRightStickPress));
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
			{
				0,
				1
			}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06034F7E RID: 216958 RVA: 0x00D4901C File Offset: 0x00D4721C
		[NullableContext(2)]
		private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		}

		// Token: 0x06034F7F RID: 216959 RVA: 0x00D49038 File Offset: 0x00D47238
		[NullableContext(2)]
		private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput || Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1 || Singleton<InputSettings>.Instance.IsInputKeyDown("RightMouseButton"))
			{
				this.CurrentDragPosition = null;
				return;
			}
			FVector? currentDragPosition = this.CurrentDragPosition;
			this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
			if (currentDragPosition == null)
			{
				return;
			}
			float num = this.CurrentDragPosition.Value.X - currentDragPosition.Value.X;
			float num2 = this.CurrentDragPosition.Value.Y - currentDragPosition.Value.Y;
			if (num != 0f)
			{
				this.UiCameraControlRotationComponent.AddYawInput(num);
			}
			if (num2 != 0f)
			{
				this.UiCameraControlRotationComponent.AddPitchInput(num2);
			}
		}

		// Token: 0x06034F80 RID: 216960 RVA: 0x00D490FE File Offset: 0x00D472FE
		[NullableContext(2)]
		private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			this.CurrentDragPosition = null;
		}

		// Token: 0x06034F81 RID: 216961 RVA: 0x00D49115 File Offset: 0x00D47315
		[NullableContext(2)]
		private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (eventData.scrollAxisValue != 0f)
			{
				this.UiCameraControlRotationComponent.AddZoomInput(-eventData.scrollAxisValue);
			}
		}

		// Token: 0x06034F82 RID: 216962 RVA: 0x00D4913F File Offset: 0x00D4733F
		private void OnPlayCameraAnimationStart(UiCameraHandleData uiCameraHandleData, UiCameraHandleData cameraHandleData, string arg3)
		{
			this.CanCameraInput = false;
			UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
			if (uiCameraControlRotationComponent == null)
			{
				return;
			}
			uiCameraControlRotationComponent.PauseTick();
		}

		// Token: 0x06034F83 RID: 216963 RVA: 0x00D49158 File Offset: 0x00D47358
		private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
		{
			if (!this.CheckCameraViewNameInTabView(handleData.ViewName))
			{
				return;
			}
			UiCamera uiCamera = UiCameraManager.Get();
			this.UiCameraControlRotationComponent = (uiCamera.AddUiCameraComponent(typeof(UiCameraControlRotationComponent), false) as UiCameraControlRotationComponent);
			SUiRoleCameraSetting? defaultRoleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetDefaultRoleCameraConfig();
			if (defaultRoleCameraConfig == null)
			{
				return;
			}
			this.UiCameraControlRotationComponent.InitDataByConfig(defaultRoleCameraConfig.Value);
			this.UiCameraControlRotationComponent.SetNeedFloorReflection(true);
			this.CanCameraInput = this.CheckCanCameraInput();
			if (this.CanCameraInput)
			{
				TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
				FVectorDouble sourceLocation = tsUiSceneRoleActor.D_K2_GetActorLocation();
				UiModelBase model = tsUiSceneRoleActor.Model;
				int roleConfigId = ((model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null).RoleConfigId;
				string roleBody = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId).Value.RoleBody;
				SUiRoleCameraOffsetSetting value = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraOffsetConfig(roleBody).Value;
				this.UiCameraControlRotationComponent.UpdateData(sourceLocation, value.镜头浮动最大高度, value.镜头浮动最低高度, value.镜头浮动最长臂长, value.镜头浮动最短臂长);
				this.UiCameraControlRotationComponent.Activate();
				this.UiCameraControlRotationComponent.ResumeTick();
				return;
			}
			TimerSystem.Instance.Next(delegate(float _)
			{
				UiSceneUtils.SetSceneFloorReflection(false, false);
			}, null, null);
		}

		// Token: 0x06034F84 RID: 216964 RVA: 0x00D492A8 File Offset: 0x00D474A8
		private bool CheckCanCameraInput()
		{
			if (Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation())
			{
				return false;
			}
			EUiTabViewName? currentTabViewName = this.TabViewComponent.GetCurrentTabViewName(null);
			bool result = false;
			EUiTabViewName[] ui_ROLE_CAN_ROTATE_TABVIEW = RoleDefine.UI_ROLE_CAN_ROTATE_TABVIEW;
			for (int i = 0; i < ui_ROLE_CAN_ROTATE_TABVIEW.Length; i++)
			{
				if (currentTabViewName == ui_ROLE_CAN_ROTATE_TABVIEW[i])
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06034F85 RID: 216965 RVA: 0x00D49320 File Offset: 0x00D47520
		private bool CheckCameraViewNameInTabView(string viewName)
		{
			foreach (UiDynamicTab uiDynamicTab in this.TabDataList)
			{
				if (uiDynamicTab.ChildViewName == viewName)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06034F86 RID: 216966 RVA: 0x00D49384 File Offset: 0x00D47584
		private void SwitchPanelTabState(bool bActive)
		{
			base.GetItem(2).SetUIActive(bActive);
		}

		// Token: 0x06034F87 RID: 216967 RVA: 0x00D49393 File Offset: 0x00D47593
		private void PlayRightAnimation(bool bOpen)
		{
			this.UiViewSequence.PlaySequencePurely(bOpen ? "hide" : "show", false, false);
		}

		// Token: 0x06034F88 RID: 216968 RVA: 0x00D493B1 File Offset: 0x00D475B1
		protected void RefreshUiMode()
		{
			this.RefreshRoleSystemModeUiParam();
		}

		// Token: 0x06034F89 RID: 216969 RVA: 0x00D493BC File Offset: 0x00D475BC
		protected void RefreshRoleSystemModeUiParam()
		{
			IRoleSystemUiParams roleSystemUiParams = this.RoleViewAgent.GetRoleSystemUiParams();
			this.BindRedDot(roleSystemUiParams.RoleListButtonRedDot);
			this.SetRoleListButtonVisible(roleSystemUiParams.RoleListButton);
			this.RoleListComponent.SetRoleSystemUiParams(roleSystemUiParams);
			this.RefreshRoleBackgroundMusicSwitchItem();
		}

		// Token: 0x06034F8A RID: 216970 RVA: 0x00D49400 File Offset: 0x00D47600
		protected virtual void LoadFloorEffect()
		{
			AActor actorByTag = Singleton<UiSceneManager>.Instance.GetActorByTag("RoleFloorCase");
			if (actorByTag != null)
			{
				this.FloorEffect = EffectUtil.SpawnUiEffect("RoleSystemFloorEffect", "[RoleRootView.LoadFloorEffect]", new FTransformDouble?(actorByTag.D_GetTransform()), new EffectContext(null, actorByTag, false)).Value;
			}
		}

		// Token: 0x06034F8B RID: 216971 RVA: 0x00D49458 File Offset: 0x00D47658
		protected ERedDotName? GetRedDotName(EUiTabViewName tabViewName)
		{
			if (tabViewName == EUiTabViewName.RoleAttributeTabView)
			{
				return new ERedDotName?(ERedDotName.RoleAttributeTab);
			}
			if (tabViewName == EUiTabViewName.RoleResonanceTabNewView)
			{
				return new ERedDotName?(ERedDotName.RoleResonanceTab);
			}
			if (tabViewName == EUiTabViewName.RolePhantomTabView)
			{
				return new ERedDotName?(ERedDotName.VisionTabRedDot);
			}
			if (tabViewName == EUiTabViewName.RoleWeaponTabView)
			{
				return new ERedDotName?(ERedDotName.RoleWeaponTabBreakUp);
			}
			if (tabViewName == EUiTabViewName.RoleFavorTabView)
			{
				return new ERedDotName?(ERedDotName.RoleFavorTab);
			}
			return null;
		}

		// Token: 0x06034F8C RID: 216972 RVA: 0x00D494D7 File Offset: 0x00D476D7
		protected void BindRedDot(bool roleListButtonRedDot)
		{
			if (roleListButtonRedDot)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoleSelectionList, base.GetItem(8), null, 0);
				return;
			}
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RoleSelectionList, base.GetItem(8), 0);
			base.GetItem(8).SetUIActive(false);
		}

		// Token: 0x06034F8D RID: 216973 RVA: 0x00D49514 File Offset: 0x00D47714
		protected void UnBindRedDot()
		{
			foreach (RoleTabItem roleTabItem in this.TabComponent.GetTabItemMap().Values)
			{
				roleTabItem.UnBindRedDot();
			}
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RoleSelectionList);
		}

		// Token: 0x06034F8E RID: 216974 RVA: 0x00D4957C File Offset: 0x00D4777C
		public void SetRoleListButtonVisible(bool bVisible)
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(bVisible);
		}

		// Token: 0x06034F8F RID: 216975 RVA: 0x00D495A3 File Offset: 0x00D477A3
		public void SetRoleListVisible(bool bVisible)
		{
			base.GetItem(3).SetUIActive(bVisible);
		}

		// Token: 0x06034F90 RID: 216976 RVA: 0x00D495B4 File Offset: 0x00D477B4
		public void RefreshRoleBackgroundMusicSwitchItem()
		{
			IRoleSystemUiParams roleSystemUiParams = this.RoleViewAgent.GetRoleSystemUiParams();
			RoleViewAgent roleViewAgent = this.RoleViewAgent;
			RoleDataBase roleDataBase = (roleViewAgent != null) ? roleViewAgent.GetCurSelectRoleData() : null;
			if (this.CurSelectTabView != EUiTabViewName.RoleSkillTabView || !roleSystemUiParams.BackgroundMusicSwitch || roleDataBase == null || roleDataBase.IsTrialRole() || !roleDataBase.GetRoleConfig().EnableOperateSelfBgm)
			{
				base.GetItem(9).SetUIActive(false);
				return;
			}
			base.GetItem(9).SetUIActive(true);
			RoleBackgroundMusicSwitchItem roleBackgroundMusicSwitchItem = this.RoleBackgroundMusicSwitchItem;
			if (roleBackgroundMusicSwitchItem == null)
			{
				return;
			}
			roleBackgroundMusicSwitchItem.RefreshByRoleData(roleDataBase);
		}

		// Token: 0x06034F91 RID: 216977 RVA: 0x00D4965C File Offset: 0x00D4785C
		protected override void OnBeforeHide()
		{
			this.RemoveCameraEventListener();
			this.CanCameraInput = false;
			if (this.ShowSequencePlayer != null)
			{
				this.IsLightSequenceLoop = false;
				this.ShowSequencePlayer.Stop();
				this.ShowSequencePlayer = null;
			}
			UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
			this.UiCameraControlRotationComponent = null;
		}

		// Token: 0x06034F92 RID: 216978 RVA: 0x00D496B2 File Offset: 0x00D478B2
		protected override void OnHandleReleaseScene()
		{
			this.HandleReleaseScene();
		}

		// Token: 0x06034F93 RID: 216979 RVA: 0x00D496BA File Offset: 0x00D478BA
		protected override void OnAfterHide()
		{
			this.RoleListComponent.UnBindRedDot();
			this.TabViewComponent.SetCurrentTabViewState(false);
		}

		// Token: 0x06034F94 RID: 216980 RVA: 0x00D496D4 File Offset: 0x00D478D4
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
			Singleton<EventSystem>.Instance.Remove(EEventName.SelectRoleTabOutside, new Action<EUiTabViewName, int>(this.OnSelectRoleTabOutside));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
			DynamicMaskButton showTagTipsMaskButton = this.ShowTagTipsMaskButton;
			if (showTagTipsMaskButton == null)
			{
				return;
			}
			showTagTipsMaskButton.Destroy(null);
		}

		// Token: 0x06034F95 RID: 216981 RVA: 0x00D49730 File Offset: 0x00D47930
		private void HandleReleaseScene()
		{
			if (this.CanHandleLoadScene)
			{
				return;
			}
			this.CanHandleLoadScene = true;
			if (Singleton<EffectSystem>.Instance.IsValid(this.FloorEffect))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.FloorEffect, "[RoleRootView.HandleReleaseScene]", false, null);
			}
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
			this.TsUiSceneRoleActor = null;
			Singleton<UiSceneManager>.Instance.ClearUiSequenceFrame();
			ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.None);
		}

		// Token: 0x06034F96 RID: 216982 RVA: 0x00D497AC File Offset: 0x00D479AC
		protected override void OnBeforeDestroyImplement()
		{
			this.HandleReleaseScene();
			this.ClearData();
		}

		// Token: 0x06034F97 RID: 216983 RVA: 0x00D497BC File Offset: 0x00D479BC
		protected void ClearData()
		{
			if (this.TabViewComponent != null)
			{
				this.TabViewComponent.DestroyTabViewComponent();
				this.TabViewComponent = null;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.FloorEffect))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.FloorEffect, "[RoleRootView.ClearData]", true, null);
				this.FloorEffect = 0;
			}
			foreach (ALevelSequenceActor alevelSequenceActor in this.LevelSequenceActorCache.Values)
			{
				alevelSequenceActor.SetShouldLatentDestroy(true);
			}
			this.LevelSequenceActorCache.Clear();
			this.CurSelectTabIndex = 0;
			this.ClickTimes = 0;
			UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
			foreach (int num in this.RoleViewAgent.GetRoleIdList())
			{
				ModelBase<SortModel>.Instance.ClearSortConfigData(EFilterSortConfigId.VisionEquipment, 10, num.ToString());
				ModelBase<FilterModel>.Instance.ClearFilterConfigData(EFilterSortConfigId.VisionEquipment, 10, num.ToString());
			}
		}

		// Token: 0x06034F98 RID: 216984 RVA: 0x00D498F4 File Offset: 0x00D47AF4
		private void UiRoleSequenceEndKeyFrame()
		{
			if (!this.IsLightSequenceLoop)
			{
				return;
			}
			FMovieSceneSequencePlaybackParams playbackPosition = new FMovieSceneSequencePlaybackParams(new FFrameTime(new FFrameNumber(Singleton<UiSceneManager>.Instance.GetUiStartSequenceFrame()), 0f), 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Jump);
			this.ShowSequencePlayer.SetPlaybackPosition(playbackPosition);
		}

		// Token: 0x06034F99 RID: 216985 RVA: 0x00D49941 File Offset: 0x00D47B41
		private void OnRoleDevTargetRoleIdChange()
		{
			this.RefreshRoleDevButtonVisibility();
		}

		// Token: 0x06034F9A RID: 216986 RVA: 0x00D4994C File Offset: 0x00D47B4C
		private void RefreshSkillShowTagRoot()
		{
			bool flag = this.CurSelectTabView == EUiTabViewName.RoleSkillTabView;
			base.GetItem(12).SetUIActive(flag);
			if (flag)
			{
				EToggleState state = ModelBase<RoleModel>.Instance.IsShowSkillShowTag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				base.GetExtendToggle(13).SetToggleState(state, false, false, false);
			}
			base.GetItem(15).SetUIActive(false);
		}

		// Token: 0x06034F9B RID: 216987 RVA: 0x00D499C4 File Offset: 0x00D47BC4
		private void OnSkillShowTagToggleClick(EToggleState state)
		{
			bool flag = state == EToggleState.ETT_Checked;
			ModelBase<RoleModel>.Instance.IsShowSkillShowTag = flag;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSkillShowTagToggleChanged, flag);
			ControllerBase<RoleController>.Instance.LogRoleDevelopSkillRecommendClick(this.RoleViewAgent.GetCurSelectRoleData().GetDataId(), flag);
		}

		// Token: 0x06034F9C RID: 216988 RVA: 0x00D49A0D File Offset: 0x00D47C0D
		private void OnSkillShowTagHelpButtonClick()
		{
			if (base.GetItem(15).bIsUIActive)
			{
				this.HideShowTagTips();
				return;
			}
			this.ShowShowTagTips();
		}

		// Token: 0x06034F9D RID: 216989 RVA: 0x00D49A2C File Offset: 0x00D47C2C
		private UniTask ShowShowTagTips()
		{
			RoleRootView.<ShowShowTagTips>d__108 <ShowShowTagTips>d__;
			<ShowShowTagTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowShowTagTips>d__.<>4__this = this;
			<ShowShowTagTips>d__.<>1__state = -1;
			<ShowShowTagTips>d__.<>t__builder.Start<RoleRootView.<ShowShowTagTips>d__108>(ref <ShowShowTagTips>d__);
			return <ShowShowTagTips>d__.<>t__builder.Task;
		}

		// Token: 0x06034F9E RID: 216990 RVA: 0x00D49A6F File Offset: 0x00D47C6F
		private void HideShowTagTips()
		{
			base.GetItem(15).SetUIActive(false);
			if (this.ShowTagTipsMaskButton != null)
			{
				this.ShowTagTipsMaskButton.ResetItemParent();
				this.ShowTagTipsMaskButton.SetActive(false);
			}
		}

		// Token: 0x06034F9F RID: 216991 RVA: 0x00D49A9E File Offset: 0x00D47C9E
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (base.GetItem(15).bIsUIActive)
			{
				this.HideShowTagTips();
			}
		}

		// Token: 0x0401E85B RID: 125019
		[Nullable(2)]
		protected RoleBackgroundMusicSwitchItem RoleBackgroundMusicSwitchItem;

		// Token: 0x0401E85C RID: 125020
		[Nullable(2)]
		protected RoleListComponent RoleListComponent;

		// Token: 0x0401E85D RID: 125021
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0401E85E RID: 125022
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<RoleTabItem> TabComponent;

		// Token: 0x0401E85F RID: 125023
		[Nullable(2)]
		private TsUiSceneRoleActor TsUiSceneRoleActor;

		// Token: 0x0401E860 RID: 125024
		protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401E861 RID: 125025
		private int FloorEffect;

		// Token: 0x0401E862 RID: 125026
		[Nullable(2)]
		protected UiCameraHandleData RoleRootUiCameraHandleData;

		// Token: 0x0401E863 RID: 125027
		private int CurSelectTabIndex;

		// Token: 0x0401E864 RID: 125028
		private EUiTabViewName? CurSelectTabView;

		// Token: 0x0401E865 RID: 125029
		[Nullable(2)]
		private ULevelSequencePlayer ShowSequencePlayer;

		// Token: 0x0401E866 RID: 125030
		private int ClickTimes;

		// Token: 0x0401E867 RID: 125031
		private double? LastClickTime;

		// Token: 0x0401E868 RID: 125032
		private bool IsLightSequenceLoop = true;

		// Token: 0x0401E869 RID: 125033
		private readonly Dictionary<int, ALevelSequenceActor> LevelSequenceActorCache = new Dictionary<int, ALevelSequenceActor>();

		// Token: 0x0401E86A RID: 125034
		private readonly Dictionary<int, int> LevelSequenceActorLoadStatus = new Dictionary<int, int>();

		// Token: 0x0401E86B RID: 125035
		private bool CanCameraInput;

		// Token: 0x0401E86C RID: 125036
		[Nullable(2)]
		private UiCameraControlRotationComponent UiCameraControlRotationComponent;

		// Token: 0x0401E86D RID: 125037
		[Nullable(2)]
		private RoleViewAgent RoleViewAgent;

		// Token: 0x0401E86E RID: 125038
		private readonly Queue<OperationParam> ViewOperationQueue = new Queue<OperationParam>(4);

		// Token: 0x0401E86F RID: 125039
		private bool Operating;

		// Token: 0x0401E870 RID: 125040
		private bool CanHandleLoadScene = true;

		// Token: 0x0401E871 RID: 125041
		private RoleDevelopEntranceItem RoleDevelopEntranceItem;

		// Token: 0x0401E872 RID: 125042
		[Nullable(2)]
		private DynamicMaskButton ShowTagTipsMaskButton;

		// Token: 0x0401E873 RID: 125043
		private FVector? CurrentDragPosition;
	}
}
