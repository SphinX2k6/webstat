using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.MailBind;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D19 RID: 23833
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FunctionController : UiControllerBase<FunctionController>
	{
		// Token: 0x0603C166 RID: 246118 RVA: 0x00F3CC9C File Offset: 0x00F3AE9C
		protected override bool OnInit()
		{
			this.OpenFunctionViewMap[EFunctionType.Role] = new Action(this.OpenRoleView);
			this.OpenFunctionViewMap[EFunctionType.Bag] = new Action(this.OpenBagView);
			this.OpenFunctionViewMap[EFunctionType.Calabash] = new Action(this.OpenCalabashView);
			this.OpenFunctionViewMap[EFunctionType.Quest] = new Action(this.OpenQuestView);
			this.OpenFunctionViewMap[EFunctionType.Mail] = new Action(this.OpenMailView);
			this.OpenFunctionViewMap[EFunctionType.TimeOfDay] = new Action(this.OpenTimeOfDayView);
			this.OpenFunctionViewMap[EFunctionType.Map] = new Action(this.OpenMapView);
			this.OpenFunctionViewMap[EFunctionType.Menu] = new Action(this.OpenMenuView);
			this.OpenFunctionViewMap[EFunctionType.FormatTeam] = delegate()
			{
				ControllerBase<EditFormationController>.Instance.OpenEditFormationView(null);
			};
			this.OpenFunctionViewMap[EFunctionType.Friend] = new Action(this.OpenFriendView);
			this.OpenFunctionViewMap[EFunctionType.Shop] = new Action(this.OpenPayShopView);
			this.OpenFunctionViewMap[EFunctionType.Gacha] = new Action(this.OpenGachaMainView);
			this.OpenFunctionViewMap[EFunctionType.Tutorial] = new Action(ControllerBase<TutorialController>.Instance.OpenTutorialView);
			this.OpenFunctionViewMap[EFunctionType.AdventureGuide] = delegate()
			{
				ControllerBase<AdventureGuideController>.Instance.OpenGuideView(null, null, null);
			};
			this.OpenFunctionViewMap[EFunctionType.ExploreTool] = new Action(this.OpenExploreSetView);
			this.OpenFunctionViewMap[EFunctionType.InfluenceReputation] = new Action(this.OpenInfluenceReputation);
			this.OpenFunctionViewMap[EFunctionType.UserFeedback] = new Action(this.OpenUserFeedback);
			this.OpenFunctionViewMap[EFunctionType.Forging] = new Action(this.OpenForging);
			this.OpenFunctionViewMap[EFunctionType.Compose] = new Action(this.OpenCompose);
			this.OpenFunctionViewMap[EFunctionType.BattlePass] = new Action(this.OpenBattlePass);
			this.OpenFunctionViewMap[EFunctionType.RoleHandBook] = new Action(this.OpenRoleHandBook);
			this.OpenFunctionViewMap[EFunctionType.HandBookSystem] = new Action(this.OpenHandBookSystem);
			this.OpenFunctionViewMap[EFunctionType.Photograph] = new Action(this.OpenPhotograph);
			this.OpenFunctionViewMap[EFunctionType.Achievement] = new Action(this.OpenAchievement);
			this.OpenFunctionViewMap[EFunctionType.Activity] = new Action(this.OpenActivity);
			this.OpenFunctionViewMap[EFunctionType.UserFeedback] = new Action(this.OpenCustomerService);
			this.OpenFunctionViewMap[EFunctionType.KuroStreet] = new Action(this.OpenKuroStreet);
			this.OpenFunctionViewMap[EFunctionType.Online] = new Action(this.OpenOnlineGame);
			this.OpenFunctionViewMap[EFunctionType.MailBind] = new Action(this.OpenMailBind);
			this.OpenFunctionViewMap[EFunctionType.GameIntroduction] = new Action(this.OpenGameIntroduction);
			this.OpenFunctionViewMap[EFunctionType.DirectTrainPro] = new Action(this.OpenDirectTrainPro);
			this.OpenFunctionViewMap[EFunctionType.HonamiStoryBackpack] = new Action(this.OpenHonamiStoryBackpack);
			this.OpenFunctionViewMap[EFunctionType.PhoneMsg] = new Action(this.OpenPhoneMsg);
			this.OpenFunctionViewMap[EFunctionType.PermanentPhantomArea] = new Action(this.OpenPermanentPhantomArea);
			this.OpenFunctionViewMap[EFunctionType.MotorDevelop] = new Action(this.OpenMotorcycle);
			this.OpenFunctionViewMap[EFunctionType.Infrastructure] = new Action(this.OpenInfrastructure);
			this.OpenFunctionViewMap[EFunctionType.VillageInfr] = new Action(this.OpenVillageInfr);
			this.OpenFunctionViewMap[EFunctionType.WeatherCentral] = new Action(this.OpenWeatherCentral);
			this.OpenFunctionViewMap[EFunctionType.SheriffAnomaly] = new Action(this.OpenSheriffAnomaly);
			this.OpenFunctionViewMap[EFunctionType.FeedbackReward] = new Action(this.OpenFeedbackReward);
			return true;
		}

		// Token: 0x0603C167 RID: 246119 RVA: 0x00F3D134 File Offset: 0x00F3B334
		protected void InitFunctionOpenViewLimit()
		{
			IReadOnlyList<FunctionOpenViewLimit> configList = ConfigFunctionOpenViewLimitAll.GetConfigList(true);
			if (configList != null)
			{
				int count = configList.Count;
				for (int i = 0; i < count; i++)
				{
					FunctionOpenViewLimit functionOpenViewLimit = configList[i];
					this.FunctionOpenViewLimitSet.Add(functionOpenViewLimit.ViewName);
				}
			}
		}

		// Token: 0x0603C168 RID: 246120 RVA: 0x00F3D179 File Offset: 0x00F3B379
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseViewFinish));
		}

		// Token: 0x0603C169 RID: 246121 RVA: 0x00F3D194 File Offset: 0x00F3B394
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseViewFinish));
		}

		// Token: 0x0603C16A RID: 246122 RVA: 0x00F3D1B0 File Offset: 0x00F3B3B0
		private void OnInputDistributeTagChanged(string tagName, bool tagExist)
		{
			if (tagExist)
			{
				Singleton<Log>.Instance.Info(ELogModule.Functional, ELogAuthor.YYZ, "功能开启界面打开时InputTag限制解除", default(ReadOnlySpan<ValueTuple<string, object>>));
				ModelBase<InputDistributeModel>.Instance.RemoveInputDistributeTagChangedListener("UiInputRoot", new TInputTagChangedCallback(this.OnInputDistributeTagChanged));
				this.TryOpenFunctionOpenView();
			}
		}

		// Token: 0x0603C16B RID: 246123 RVA: 0x00F3D200 File Offset: 0x00F3B400
		private void OnCharacterTagChanged(int tagId, bool tagExist)
		{
			if (!tagExist)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Functional;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "功能开启界面打开时Tag限制解除";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", tagId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				if (curRoleData != null)
				{
					BaseTagComponent gameplayTagComponent = curRoleData.GameplayTagComponent;
					if (gameplayTagComponent != null)
					{
						gameplayTagComponent.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnCharacterTagChanged));
					}
				}
				this.TryOpenFunctionOpenView();
			}
		}

		// Token: 0x0603C16C RID: 246124 RVA: 0x00F3D270 File Offset: 0x00F3B470
		[NullableContext(0)]
		public UniTask<bool> TryOpenFunctionOpenView()
		{
			FunctionController.<TryOpenFunctionOpenView>d__9 <TryOpenFunctionOpenView>d__;
			<TryOpenFunctionOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryOpenFunctionOpenView>d__.<>4__this = this;
			<TryOpenFunctionOpenView>d__.<>1__state = -1;
			<TryOpenFunctionOpenView>d__.<>t__builder.Start<FunctionController.<TryOpenFunctionOpenView>d__9>(ref <TryOpenFunctionOpenView>d__);
			return <TryOpenFunctionOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0603C16D RID: 246125 RVA: 0x00F3D2B4 File Offset: 0x00F3B4B4
		[NullableContext(0)]
		public UniTask<bool> ManualOpenFunctionOpenView([Nullable(1)] params int[] functionIdList)
		{
			FunctionController.<ManualOpenFunctionOpenView>d__10 <ManualOpenFunctionOpenView>d__;
			<ManualOpenFunctionOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ManualOpenFunctionOpenView>d__.<>4__this = this;
			<ManualOpenFunctionOpenView>d__.functionIdList = functionIdList;
			<ManualOpenFunctionOpenView>d__.<>1__state = -1;
			<ManualOpenFunctionOpenView>d__.<>t__builder.Start<FunctionController.<ManualOpenFunctionOpenView>d__10>(ref <ManualOpenFunctionOpenView>d__);
			return <ManualOpenFunctionOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0603C16E RID: 246126 RVA: 0x00F3D300 File Offset: 0x00F3B500
		[NullableContext(0)]
		private UniTask<bool> RequestFunctionShow([Nullable(1)] int[] functionIdList)
		{
			FunctionController.<RequestFunctionShow>d__11 <RequestFunctionShow>d__;
			<RequestFunctionShow>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestFunctionShow>d__.<>4__this = this;
			<RequestFunctionShow>d__.functionIdList = functionIdList;
			<RequestFunctionShow>d__.<>1__state = -1;
			<RequestFunctionShow>d__.<>t__builder.Start<FunctionController.<RequestFunctionShow>d__11>(ref <RequestFunctionShow>d__);
			return <RequestFunctionShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603C16F RID: 246127 RVA: 0x00F3D34C File Offset: 0x00F3B54C
		private bool CheckFunctionOpenViewLimit()
		{
			if (!ModelBase<FunctionModel>.Instance.IsExistNewOpenFunction())
			{
				return false;
			}
			bool flag = false;
			UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
			if (uiViewBase == null)
			{
				return false;
			}
			if (uiViewBase.ViewInfo.Name == Singleton<UiModel>.Instance.MainViewName)
			{
				flag = true;
			}
			if (!flag && this.IsInForceCanOpenView(uiViewBase.ViewInfo.Name.ToString()))
			{
				flag = true;
			}
			if (!flag)
			{
				return false;
			}
			if (!ModelBase<InputDistributeModel>.Instance.IsAllowUiInput())
			{
				Singleton<Log>.Instance.Info(ELogModule.Functional, ELogAuthor.YYZ, "功能开启界面打开时UI输入存在限制,不打开", default(ReadOnlySpan<ValueTuple<string, object>>));
				ModelBase<InputDistributeModel>.Instance.AddInputDistributeTagChangedListener("UiInputRoot", new TInputTagChangedCallback(this.OnInputDistributeTagChanged));
				return false;
			}
			bool result = true;
			int[] array = new int[]
			{
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"],
				GameplayTagDefine.EGameplayTagId["角色.Common.处决.处决中"]
			};
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			foreach (int num in array)
			{
				bool flag2;
				if (curRoleData == null)
				{
					flag2 = true;
				}
				else
				{
					BaseTagComponent gameplayTagComponent = curRoleData.GameplayTagComponent;
					flag2 = !((gameplayTagComponent != null) ? new bool?(gameplayTagComponent.HasTag(num)) : null).GetValueOrDefault();
				}
				if (!flag2)
				{
					if (curRoleData != null)
					{
						BaseTagComponent gameplayTagComponent2 = curRoleData.GameplayTagComponent;
						if (gameplayTagComponent2 != null)
						{
							gameplayTagComponent2.AddTagAddOrRemoveListener(num, new BaseTagComponent.TTagSwitchedCallback(this.OnCharacterTagChanged), null);
						}
					}
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Functional;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "功能开启界面打开时存在Tag限制";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", num);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0603C170 RID: 246128 RVA: 0x00F3D4F5 File Offset: 0x00F3B6F5
		private bool IsInForceCanOpenView(string viewName)
		{
			if (!this.IsInitFunctionOpenViewLimitSet)
			{
				this.InitFunctionOpenViewLimit();
				this.IsInitFunctionOpenViewLimitSet = true;
			}
			return this.FunctionOpenViewLimitSet.Contains(viewName);
		}

		// Token: 0x0603C171 RID: 246129 RVA: 0x00F3D518 File Offset: 0x00F3B718
		private void OnCloseViewFinish(EUiViewName viewName, int viewId)
		{
			this.TryOpenFunctionOpenView();
		}

		// Token: 0x0603C172 RID: 246130 RVA: 0x00F3D524 File Offset: 0x00F3B724
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<FuncOpenNotify>(ENotifyMessageId.FuncOpenNotify, delegate(FuncOpenNotify notify, [Nullable(2)] Net.CallbackStatus status)
			{
				ModelBase<FunctionModel>.Instance.SetFunctionOpenInfo(notify);
			});
			Singleton<Net>.Instance.Register<FuncOpenUpdateNotify>(ENotifyMessageId.FuncOpenUpdateNotify, delegate(FuncOpenUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
			{
				ModelBase<FunctionModel>.Instance.UpdateFunctionOpenInfo(notify);
				this.TryOpenFunctionOpenView();
			});
		}

		// Token: 0x0603C173 RID: 246131 RVA: 0x00F3D57C File Offset: 0x00F3B77C
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FuncOpenNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FuncOpenUpdateNotify);
		}

		// Token: 0x0603C174 RID: 246132 RVA: 0x00F3D5A0 File Offset: 0x00F3B7A0
		private void OpenRoleView()
		{
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, null, null, null);
		}

		// Token: 0x0603C175 RID: 246133 RVA: 0x00F3D5C4 File Offset: 0x00F3B7C4
		private void OpenBagView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, null, null);
		}

		// Token: 0x0603C176 RID: 246134 RVA: 0x00F3D5D7 File Offset: 0x00F3B7D7
		private void OpenCalabashView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, null, null);
		}

		// Token: 0x0603C177 RID: 246135 RVA: 0x00F3D5EA File Offset: 0x00F3B7EA
		private void OpenQuestView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, null, null);
		}

		// Token: 0x0603C178 RID: 246136 RVA: 0x00F3D5FD File Offset: 0x00F3B7FD
		private void OpenMailView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MailBoxView, null, null);
		}

		// Token: 0x0603C179 RID: 246137 RVA: 0x00F3D610 File Offset: 0x00F3B810
		private void OpenMenuView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuView, null, null);
		}

		// Token: 0x0603C17A RID: 246138 RVA: 0x00F3D623 File Offset: 0x00F3B823
		private void OpenMapView()
		{
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Mouse, false, null, null);
		}

		// Token: 0x0603C17B RID: 246139 RVA: 0x00F3D633 File Offset: 0x00F3B833
		private void OpenTimeOfDayView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TimeOfDaySecondView, null, null);
		}

		// Token: 0x0603C17C RID: 246140 RVA: 0x00F3D646 File Offset: 0x00F3B846
		private void OpenFriendView()
		{
			this.TryOpenFriendView();
		}

		// Token: 0x0603C17D RID: 246141 RVA: 0x00F3D650 File Offset: 0x00F3B850
		private UniTask TryOpenFriendView()
		{
			FunctionController.<TryOpenFriendView>d__26 <TryOpenFriendView>d__;
			<TryOpenFriendView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryOpenFriendView>d__.<>4__this = this;
			<TryOpenFriendView>d__.<>1__state = -1;
			<TryOpenFriendView>d__.<>t__builder.Start<FunctionController.<TryOpenFriendView>d__26>(ref <TryOpenFriendView>d__);
			return <TryOpenFriendView>d__.<>t__builder.Task;
		}

		// Token: 0x0603C17E RID: 246142 RVA: 0x00F3D694 File Offset: 0x00F3B894
		private UniTask OpenThirdPartyMessageBox(ESdkPrivilege privilege)
		{
			FunctionController.<OpenThirdPartyMessageBox>d__27 <OpenThirdPartyMessageBox>d__;
			<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenThirdPartyMessageBox>d__.privilege = privilege;
			<OpenThirdPartyMessageBox>d__.<>1__state = -1;
			<OpenThirdPartyMessageBox>d__.<>t__builder.Start<FunctionController.<OpenThirdPartyMessageBox>d__27>(ref <OpenThirdPartyMessageBox>d__);
			return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
		}

		// Token: 0x0603C17F RID: 246143 RVA: 0x00F3D6D7 File Offset: 0x00F3B8D7
		private void OpenPayShopView()
		{
			ControllerBase<PayShopController>.Instance.OpenPayShopView(null, null);
		}

		// Token: 0x0603C180 RID: 246144 RVA: 0x00F3D6E5 File Offset: 0x00F3B8E5
		private void OpenGachaMainView()
		{
			ControllerBase<GachaController>.Instance.OpenGachaMainView(true);
		}

		// Token: 0x0603C181 RID: 246145 RVA: 0x00F3D6F4 File Offset: 0x00F3B8F4
		private void OpenExploreSetView()
		{
			ControllerBase<RouletteController>.Instance.OpenAssemblyView(ERouletteType.Explore, null, null, null);
		}

		// Token: 0x0603C182 RID: 246146 RVA: 0x00F3D728 File Offset: 0x00F3B928
		private void OpenUserFeedback()
		{
			ControllerBase<KuroSdkController>.Instance.OpenFeedback();
		}

		// Token: 0x0603C183 RID: 246147 RVA: 0x00F3D734 File Offset: 0x00F3B934
		private void OpenInfluenceReputation()
		{
		}

		// Token: 0x0603C184 RID: 246148 RVA: 0x00F3D736 File Offset: 0x00F3B936
		private void OpenRoleHandBook()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleHandBookSelectionView, null, null);
		}

		// Token: 0x0603C185 RID: 246149 RVA: 0x00F3D749 File Offset: 0x00F3B949
		private void OpenHandBookSystem()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookEntranceView, null, null);
		}

		// Token: 0x0603C186 RID: 246150 RVA: 0x00F3D75C File Offset: 0x00F3B95C
		private void OpenPhotograph()
		{
			ControllerBase<PhotographController>.Instance.TryOpenPhotograph(ECameraCaptureType.NormalCamera);
		}

		// Token: 0x0603C187 RID: 246151 RVA: 0x00F3D76A File Offset: 0x00F3B96A
		private void OpenActivity()
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(0, EActivityViewOpenType.Menu, null, null);
		}

		// Token: 0x0603C188 RID: 246152 RVA: 0x00F3D77B File Offset: 0x00F3B97B
		private void OpenCustomerService()
		{
			ControllerBase<LogController>.Instance.RequestOutputDebugInfo();
			ControllerBase<KuroSdkController>.Instance.OpenCustomerService(EKuroSdkOpenCustomerServerType.Setting);
		}

		// Token: 0x0603C189 RID: 246153 RVA: 0x00F3D792 File Offset: 0x00F3B992
		private void OpenKuroStreet()
		{
			if (ModelBase<MailBindModel>.Instance.GetIsReward())
			{
				ControllerBase<ChannelController>.Instance.OpenKuroStreet();
			}
			else
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MailBindView, false, null);
			}
			ControllerBase<MailBindController>.Instance.RecordMailBindClick();
		}

		// Token: 0x0603C18A RID: 246154 RVA: 0x00F3D7CC File Offset: 0x00F3B9CC
		private void OpenMailBind()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MailBindView, true, null);
			ControllerBase<MailBindController>.Instance.RecordMailBindClick();
		}

		// Token: 0x0603C18B RID: 246155 RVA: 0x00F3D7EE File Offset: 0x00F3B9EE
		private void OpenGameIntroduction()
		{
			ControllerBase<ChannelController>.Instance.OpenGameIntroduction();
			ModelBase<KuroSdkModel>.Instance.SaveCurrentClickIntroductionVersion();
		}

		// Token: 0x0603C18C RID: 246156 RVA: 0x00F3D804 File Offset: 0x00F3BA04
		private void OpenDirectTrainPro()
		{
			ActivityDirectTrainHelper.TryOpenPro(false);
		}

		// Token: 0x0603C18D RID: 246157 RVA: 0x00F3D80D File Offset: 0x00F3BA0D
		private void OpenOnlineGame()
		{
			this.TryOpenOnlineGame();
		}

		// Token: 0x0603C18E RID: 246158 RVA: 0x00F3D818 File Offset: 0x00F3BA18
		private UniTask TryOpenOnlineGame()
		{
			FunctionController.<TryOpenOnlineGame>d__43 <TryOpenOnlineGame>d__;
			<TryOpenOnlineGame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryOpenOnlineGame>d__.<>4__this = this;
			<TryOpenOnlineGame>d__.<>1__state = -1;
			<TryOpenOnlineGame>d__.<>t__builder.Start<FunctionController.<TryOpenOnlineGame>d__43>(ref <TryOpenOnlineGame>d__);
			return <TryOpenOnlineGame>d__.<>t__builder.Task;
		}

		// Token: 0x0603C18F RID: 246159 RVA: 0x00F3D85B File Offset: 0x00F3BA5B
		private void OpenAchievement()
		{
			ControllerBase<AchievementController>.Instance.OpenAchievementMainView();
		}

		// Token: 0x0603C190 RID: 246160 RVA: 0x00F3D868 File Offset: 0x00F3BA68
		public void OpenFunctionRelateView(EFunctionType functionType)
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen((int)functionType))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
				return;
			}
			Action action;
			if (this.OpenFunctionViewMap.TryGetValue(functionType, out action))
			{
				action();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "原因：查找不到对应按钮打开界面的实现方式 解决：在FunctionController.OpenFunctionViewMap注册打开界面方法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("功能ID", functionType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603C191 RID: 246161 RVA: 0x00F3D8DA File Offset: 0x00F3BADA
		private void OpenCompose()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ComposeCarryOnView, null, null);
		}

		// Token: 0x0603C192 RID: 246162 RVA: 0x00F3D8ED File Offset: 0x00F3BAED
		private void OpenForging()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ForgingRootView, null, null);
		}

		// Token: 0x0603C193 RID: 246163 RVA: 0x00F3D900 File Offset: 0x00F3BB00
		private void OpenBattlePass()
		{
			ControllerBase<BattlePassController>.Instance.OpenBattlePassView();
		}

		// Token: 0x0603C194 RID: 246164 RVA: 0x00F3D90C File Offset: 0x00F3BB0C
		private void OpenHonamiStoryBackpack()
		{
			ControllerBase<HonamiStoryController>.Instance.OpenHonamiStoryBag().Forget<bool>();
		}

		// Token: 0x0603C195 RID: 246165 RVA: 0x00F3D920 File Offset: 0x00F3BB20
		private void OpenPhoneMsg()
		{
			PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
			{
				ShortMessage = null,
				NeedShowTips = false,
				NeedForceReadAllMsg = false,
				OpenWay = EPhoneMsgOpenWay.TerminalEsc,
				ViewType = EPhoneMsgViewType.Big
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, param, null);
		}

		// Token: 0x0603C196 RID: 246166 RVA: 0x00F3D96C File Offset: 0x00F3BB6C
		private void OpenPermanentPhantomArea()
		{
			PhantomArenaBattleController.OpenPhantomArenaMapEntrance(null, null);
		}

		// Token: 0x0603C197 RID: 246167 RVA: 0x00F3D990 File Offset: 0x00F3BB90
		private void OpenInfrastructure()
		{
			ControllerBase<InfrastructureController>.Instance.OpenInfrastructureMainView(null).Forget<int?>();
		}

		// Token: 0x0603C198 RID: 246168 RVA: 0x00F3D9A2 File Offset: 0x00F3BBA2
		private void OpenVillageInfr()
		{
			ControllerBase<VillageInfrController>.Instance.OpenVillageInfrMainView(null).Forget<int?>();
		}

		// Token: 0x0603C199 RID: 246169 RVA: 0x00F3D9B4 File Offset: 0x00F3BBB4
		private void OpenMotorcycle()
		{
			ControllerBase<MotorcycleDevelopController>.Instance.OpenRootView().Forget<bool>();
		}

		// Token: 0x0603C19A RID: 246170 RVA: 0x00F3D9C8 File Offset: 0x00F3BBC8
		private void OpenWeatherCentral()
		{
			ControllerBase<WeatherController>.Instance.TryOpenWeatherCentralMainView(null);
		}

		// Token: 0x0603C19B RID: 246171 RVA: 0x00F3D9E8 File Offset: 0x00F3BBE8
		private void OpenSheriffAnomaly()
		{
			ControllerBase<SheriffController>.Instance.OpenSheriffMap(null);
		}

		// Token: 0x0603C19C RID: 246172 RVA: 0x00F3D9F5 File Offset: 0x00F3BBF5
		private void OpenFeedbackReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FeedbackRewardMainView, null, null);
		}

		// Token: 0x0603C19D RID: 246173 RVA: 0x00F3DA08 File Offset: 0x00F3BC08
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x04021BE3 RID: 138211
		private bool IsInitFunctionOpenViewLimitSet;

		// Token: 0x04021BE4 RID: 138212
		private readonly Dictionary<EFunctionType, Action> OpenFunctionViewMap = new Dictionary<EFunctionType, Action>();

		// Token: 0x04021BE5 RID: 138213
		private readonly HashSet<string> FunctionOpenViewLimitSet = new HashSet<string>();
	}
}
