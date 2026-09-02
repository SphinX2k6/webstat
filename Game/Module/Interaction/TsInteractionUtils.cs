using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Interaction.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA2 RID: 23458
	[NullableContext(1)]
	[Nullable(0)]
	public class TsInteractionUtils : IStaticVariableResetter
	{
		// Token: 0x0603B547 RID: 243015 RVA: 0x00F065F3 File Offset: 0x00F047F3
		static TsInteractionUtils()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TsInteractionUtils.CreateStaticDefaultValue), new Action(TsInteractionUtils.ResetStaticDefaultValue));
		}

		// Token: 0x0603B548 RID: 243016 RVA: 0x00F06612 File Offset: 0x00F04812
		[return: Nullable(2)]
		public static SInteractionConfig GetInteractionConfig(string inRow)
		{
			return DataTableUtil.GetDataTableRowFromName<SInteractionConfig>(EDataTable.InteractionConfigs, inRow);
		}

		// Token: 0x0603B549 RID: 243017 RVA: 0x00F0661C File Offset: 0x00F0481C
		public static void HandleInteractionOptionFromVision(CommonInteractOption option, PawnInteractController controller, int visionId)
		{
			if (option.OptionType != EOptionType.Normal)
			{
				return;
			}
			IInteractActions interactActions = option.Type as IInteractActions;
			if (interactActions == null || interactActions.Actions == null || interactActions.Actions.Count != 1)
			{
				return;
			}
			if (interactActions.Actions[0].Name.ToEnumString() != "Collect")
			{
				return;
			}
			CreatureDataComponent component = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>(visionId);
			if (component == null)
			{
				return;
			}
			controller.HandleInteractRequest();
			int optionIndex = option.InstanceId - 1;
			LevelGeneralNetworks.RequestEntityInteractOption(controller.CreatureData.GetCreatureDataId(), optionIndex, delegate(EntityInteractResponse response, Net.CallbackStatus _)
			{
				PawnInteractController controller2 = controller;
				if (controller2 == null)
				{
					return;
				}
				controller2.HandleInteractResponse(response.ErrorCode, response.Interacting);
			}, new long?(component.GetCreatureDataId()));
		}

		// Token: 0x0603B54A RID: 243018 RVA: 0x00F066DC File Offset: 0x00F048DC
		public static void HandleInteractionOptionNew(CommonInteractOption option, PawnInteractController controller)
		{
			if (TsInteractionUtils.LockInteractionRequest)
			{
				if (controller.OnInteractActionEnd != null)
				{
					controller.OnInteractActionEnd();
				}
				return;
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.DynamicInteractServerResponse, option.Guid);
			if (option.OptionType != EOptionType.Custom)
			{
				CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
				if (characterActorComponent != null)
				{
					Entity entity = characterActorComponent.Entity;
					if (entity != null)
					{
						CharacterMovementSyncComponent component = entity.GetComponent<CharacterMovementSyncComponent>();
						if (component != null)
						{
							component.CollectSampleAndSend(true);
						}
					}
				}
			}
			switch (option.DelayRemove ? EOptionType.Custom : option.OptionType)
			{
			case EOptionType.Normal:
			{
				TsInteractionUtils.LockInteractionRequest = true;
				controller.HandleInteractRequest();
				int optionIndex = option.InstanceId - 1;
				LevelGeneralNetworks.RequestEntityInteractOption(controller.CreatureData.GetCreatureDataId(), optionIndex, delegate(EntityInteractResponse response, Net.CallbackStatus _)
				{
					TsInteractionUtils.LockInteractionRequest = false;
					PawnInteractController controller3 = controller;
					if (controller3 == null)
					{
						return;
					}
					controller3.HandleInteractResponse(response.ErrorCode, response.Interacting);
				}, null);
				return;
			}
			case EOptionType.Dynamic:
				TsInteractionUtils.LockInteractionRequest = true;
				controller.HandleInteractRequest();
				LevelGeneralNetworks.RequestEntityDynamicInteractOption(controller.CreatureData.GetCreatureDataId(), option.Guid, delegate(EntityDynamicInteractResponse response, Net.CallbackStatus _)
				{
					TsInteractionUtils.LockInteractionRequest = false;
					PawnInteractController controller3 = controller;
					if (controller3 != null)
					{
						controller3.HandleInteractResponse(response.ErrorCode, response.Interacting);
					}
					if (option != null)
					{
						Singleton<EventSystem>.Instance.Emit<string>(EEventName.DynamicInteractServerResponse, option.Guid);
					}
				});
				return;
			case EOptionType.Random:
				TsInteractionUtils.LockInteractionRequest = true;
				controller.HandleInteractRequest();
				LevelGeneralNetworks.RequestEntityRandomInteractOption(controller.CreatureData.GetCreatureDataId(), option.RandomOptionIndex.Value, delegate(EntityRandomInteractResponse response, Net.CallbackStatus _)
				{
					TsInteractionUtils.LockInteractionRequest = false;
					PawnInteractController controller3 = controller;
					if (controller3 == null)
					{
						return;
					}
					controller3.HandleInteractResponse(response.ErrorCode, response.Interacting);
				});
				return;
			case EOptionType.Custom:
				if (option.Type.Type == EInteractOption.Flow)
				{
					IInteractFlow interactFlow = option.Type as IInteractFlow;
					EntityContext context = EntityContext.Create(controller.EntityId.GetValueOrDefault(), null);
					if (interactFlow != null)
					{
						ControllerBase<FlowController>.Instance.StartFlow(interactFlow.Flow.FlowListName, interactFlow.Flow.FlowId, interactFlow.Flow.StateId, context, 0L, false, false, false, null);
					}
					PawnInteractController controller2 = controller;
					if (((controller2 != null) ? controller2.OnInteractActionEnd : null) != null)
					{
						controller.OnInteractActionEnd();
						return;
					}
				}
				else if (option.Type.Type == EInteractOption.Actions)
				{
					controller.HandleInteractClientAction();
					GeneralContext generalContext = option.Context;
					if (generalContext == null)
					{
						generalContext = EntityContext.Create(controller.EntityId.GetValueOrDefault(), null);
					}
					else
					{
						generalContext = GeneralContext.Copy(generalContext);
					}
					ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew((option.Type as IInteractActions).Actions, generalContext, delegate(ELevelEventState result)
					{
						PawnInteractController controller3 = controller;
						if (((controller3 != null) ? controller3.OnInteractActionEnd : null) != null)
						{
							controller.OnInteractActionEnd();
						}
						PawnInteractController controller4 = controller;
						if (controller4 == null)
						{
							return;
						}
						controller4.FinishInteractClientAction();
					});
					return;
				}
				break;
			default:
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "未定义的交互选项类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("optionType", option.OptionType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
			}
		}

		// Token: 0x0603B54B RID: 243019 RVA: 0x00F069F3 File Offset: 0x00F04BF3
		public static bool IsInteractHintViewOpened()
		{
			return TsInteractionUtils.IsOpenedInteractionHintView;
		}

		// Token: 0x17009769 RID: 38761
		// (get) Token: 0x0603B54C RID: 243020 RVA: 0x00F069FA File Offset: 0x00F04BFA
		public static bool IsInteractWaitOpenViewName
		{
			get
			{
				return TsInteractionUtils.WaitOpenViewName != null;
			}
		}

		// Token: 0x0603B54D RID: 243021 RVA: 0x00F06A08 File Offset: 0x00F04C08
		[NullableContext(0)]
		public static UniTask<bool> OpenInteractHintView()
		{
			TsInteractionUtils.<OpenInteractHintView>d__12 <OpenInteractHintView>d__;
			<OpenInteractHintView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenInteractHintView>d__.<>1__state = -1;
			<OpenInteractHintView>d__.<>t__builder.Start<TsInteractionUtils.<OpenInteractHintView>d__12>(ref <OpenInteractHintView>d__);
			return <OpenInteractHintView>d__.<>t__builder.Task;
		}

		// Token: 0x0603B54E RID: 243022 RVA: 0x00F06A44 File Offset: 0x00F04C44
		public static void CloseInteractHintView(string reason = "Unknown")
		{
			if (!TsInteractionUtils.IsInteractHintViewOpened())
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewDestroying(EUiViewName.InteractionHintView))
			{
				return;
			}
			if (reason != "Unknown")
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[InteractionDebug]尝试关闭交互界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			Singleton<UiManager>.Instance.CloseViewAsync(EUiViewName.InteractionHintView).ContinueWith(delegate(bool _)
			{
				TsInteractionUtils.IsOpenedInteractionHintView = false;
			}).Forget();
		}

		// Token: 0x0603B54F RID: 243023 RVA: 0x00F06ADC File Offset: 0x00F04CDC
		public static void RegisterWaitOpenViewName(EUiViewName waitOpenViewName)
		{
			if (TsInteractionUtils.WaitOpenViewName == waitOpenViewName)
			{
				return;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(waitOpenViewName);
			if (uiViewInfo != null && uiViewInfo.Type == ELayerType.Normal)
			{
				if (TsInteractionUtils.WaitOpenViewName == null)
				{
					EventSystem instance = Singleton<EventSystem>.Instance;
					EEventName name = EEventName.OnViewDone;
					Action<EUiViewName, UiViewBase> handle;
					if ((handle = TsInteractionUtils.<>O.<0>__OnOpenWaitViewDone) == null)
					{
						handle = (TsInteractionUtils.<>O.<0>__OnOpenWaitViewDone = new Action<EUiViewName, UiViewBase>(TsInteractionUtils.OnOpenWaitViewDone));
					}
					instance.Add<EUiViewName, UiViewBase>(name, handle);
				}
				TsInteractionUtils.WaitOpenViewName = new EUiViewName?(waitOpenViewName);
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				TimerSystem.Instance.Delay(delegate(float _)
				{
					if (TsInteractionUtils.WaitOpenViewName == waitOpenViewName)
					{
						Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "等待界面打开超时", default(ReadOnlySpan<ValueTuple<string, object>>));
						TsInteractionUtils.ClearWaitView();
					}
				}, 10000f, null, null, true, 1f);
			}
		}

		// Token: 0x0603B550 RID: 243024 RVA: 0x00F06BB4 File Offset: 0x00F04DB4
		[NullableContext(2)]
		private static void OnOpenWaitViewDone(EUiViewName viewName, UiViewBase view)
		{
			if (viewName != TsInteractionUtils.WaitOpenViewName)
			{
				return;
			}
			TsInteractionUtils.ClearWaitView();
		}

		// Token: 0x0603B551 RID: 243025 RVA: 0x00F06BEA File Offset: 0x00F04DEA
		public static void Init()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnStartLoadingState;
			Action handle;
			if ((handle = TsInteractionUtils.<>O.<1>__OnOpenLoading) == null)
			{
				handle = (TsInteractionUtils.<>O.<1>__OnOpenLoading = new Action(TsInteractionUtils.OnOpenLoading));
			}
			instance.Add(name, handle);
			TsInteractionUtils.LockInteractionRequest = false;
		}

		// Token: 0x0603B552 RID: 243026 RVA: 0x00F06C1D File Offset: 0x00F04E1D
		public static void Clear()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnStartLoadingState;
			Action handle;
			if ((handle = TsInteractionUtils.<>O.<1>__OnOpenLoading) == null)
			{
				handle = (TsInteractionUtils.<>O.<1>__OnOpenLoading = new Action(TsInteractionUtils.OnOpenLoading));
			}
			instance.Remove(name, handle);
			TsInteractionUtils.ClearCurrentOpenViewName();
		}

		// Token: 0x0603B553 RID: 243027 RVA: 0x00F06C50 File Offset: 0x00F04E50
		public static void RegisterOpenViewName(EUiViewName viewName)
		{
			if (TsInteractionUtils.CurrentOpenViewName == null)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.CloseView;
				Action<EUiViewName, int> handle;
				if ((handle = TsInteractionUtils.<>O.<2>__OnCloseView) == null)
				{
					handle = (TsInteractionUtils.<>O.<2>__OnCloseView = new Action<EUiViewName, int>(TsInteractionUtils.OnCloseView));
				}
				instance.Add<EUiViewName, int>(name, handle);
			}
			TsInteractionUtils.CurrentOpenViewName = new EUiViewName?(viewName);
		}

		// Token: 0x0603B554 RID: 243028 RVA: 0x00F06C9C File Offset: 0x00F04E9C
		public static void ClearCurrentOpenViewName()
		{
			if (TsInteractionUtils.CurrentOpenViewName != null)
			{
				TsInteractionUtils.CurrentOpenViewName = null;
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.CloseView;
				Action<EUiViewName, int> handle;
				if ((handle = TsInteractionUtils.<>O.<2>__OnCloseView) == null)
				{
					handle = (TsInteractionUtils.<>O.<2>__OnCloseView = new Action<EUiViewName, int>(TsInteractionUtils.OnCloseView));
				}
				instance.Remove(name, handle);
			}
		}

		// Token: 0x0603B555 RID: 243029 RVA: 0x00F06CE8 File Offset: 0x00F04EE8
		public static EUiViewName? GetCurrentOpenViewName()
		{
			return TsInteractionUtils.CurrentOpenViewName;
		}

		// Token: 0x0603B556 RID: 243030 RVA: 0x00F06CF0 File Offset: 0x00F04EF0
		private static void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != TsInteractionUtils.CurrentOpenViewName)
			{
				return;
			}
			TsInteractionUtils.CurrentOpenViewName = null;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.CloseView;
			Action<EUiViewName, int> handle;
			if ((handle = TsInteractionUtils.<>O.<2>__OnCloseView) == null)
			{
				handle = (TsInteractionUtils.<>O.<2>__OnCloseView = new Action<EUiViewName, int>(TsInteractionUtils.OnCloseView));
			}
			instance.Remove(name, handle);
		}

		// Token: 0x0603B557 RID: 243031 RVA: 0x00F06D5E File Offset: 0x00F04F5E
		private static void OnOpenLoading()
		{
			if (TsInteractionUtils.WaitOpenViewName != null)
			{
				TsInteractionUtils.OnOpenWaitViewDone(TsInteractionUtils.WaitOpenViewName.Value, null);
			}
			if (TsInteractionUtils.CurrentOpenViewName != null)
			{
				TsInteractionUtils.OnCloseView(TsInteractionUtils.CurrentOpenViewName.Value, 0);
			}
		}

		// Token: 0x0603B558 RID: 243032 RVA: 0x00F06D98 File Offset: 0x00F04F98
		public static bool IsInteractionOpenView()
		{
			return TsInteractionUtils.CurrentOpenViewName != null;
		}

		// Token: 0x0603B559 RID: 243033 RVA: 0x00F06DA4 File Offset: 0x00F04FA4
		private static void ClearWaitView()
		{
			TsInteractionUtils.WaitOpenViewName = null;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnViewDone;
			Action<EUiViewName, UiViewBase> handle;
			if ((handle = TsInteractionUtils.<>O.<0>__OnOpenWaitViewDone) == null)
			{
				Action<EUiViewName, UiViewBase> action = TsInteractionUtils.<>O.<0>__OnOpenWaitViewDone = new Action<EUiViewName, UiViewBase>(TsInteractionUtils.OnOpenWaitViewDone);
				handle = action;
			}
			instance.Remove(name, handle);
		}

		// Token: 0x0603B55A RID: 243034 RVA: 0x00F06DF0 File Offset: 0x00F04FF0
		public static void UpdateInteractHintView()
		{
			if (!TsInteractionUtils.LockInteractionRequest)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.InteractionViewUpdate);
			}
		}

		// Token: 0x0603B55B RID: 243035 RVA: 0x00F06E0C File Offset: 0x00F0500C
		public static void HandleEntityInteractByServerNotify(ActionNotify notify, long creatureDataId, int optionIndex)
		{
			WaitEntityTask.Create("TsInteractionUtils.HandleEntityInteractByServerNotify", creatureDataId, delegate(bool? result)
			{
				if (result == null || !result.Value)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[基础交互选项继续执行]等待实体超时", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
				if (entity == null)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[基础交互选项继续执行]查找不到对应实体", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				PawnInteractNewComponent component = entity.Entity.GetComponent<PawnInteractNewComponent>();
				if (component == null)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[基础交互选项继续执行]实体交互组件为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				PawnInteractController interactController = component.GetInteractController();
				if (interactController == null)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[基础交互选项继续执行]实体交互控制器为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				CommonInteractOption optionByIndex = interactController.GetOptionByIndex(optionIndex);
				if (optionByIndex == null)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[基础交互选项继续执行]实体当前交互选项为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (optionByIndex.Type.Type != EInteractOption.Actions)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[基础交互选项继续执行]实体当前交互不是行为", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				IInteractActions interactActions = optionByIndex.Type as IInteractActions;
				GeneralContext generalContext = optionByIndex.Context;
				if (generalContext == null)
				{
					generalContext = EntityContext.Create(interactController.EntityId.GetValueOrDefault(), null);
				}
				else
				{
					generalContext = GeneralContext.Copy(generalContext);
				}
				if (generalContext is EntityContext)
				{
					InteractionModel instance = ModelBase<InteractionModel>.Instance;
					int? entityId = ((EntityContext)generalContext).EntityId;
					CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
					if (instance2 != null)
					{
						instance2.GetCreatureDataId(entityId.Value);
					}
					instance.SetInteractTarget(entityId);
					instance.SetInterctCreatureDataId(creatureDataId);
				}
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsByServerNotify(interactActions.Actions, generalContext, notify.PlayerId, notify.IncId, notify.StartIndex, notify.EndIndex, notify.NeedFinishReq, null);
			}, 90000, true, true);
		}

		// Token: 0x0603B55C RID: 243036 RVA: 0x00F06E58 File Offset: 0x00F05058
		public static void HandleEntityDynamicInteractByServerNotify(ActionNotify notify, string guid)
		{
			GeneralContext generalContext = LevelGeneralContextUtil.CreateByServerContext((notify != null) ? notify.GameCtx : null);
			if (generalContext == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[动态交互选项继续执行]上下文缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			InteractionModel instance = ModelBase<InteractionModel>.Instance;
			IInteractOption dynamicConfig = instance.GetDynamicConfig(guid);
			if (dynamicConfig == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[动态交互选项继续执行]动态交互选项为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (dynamicConfig.Type.Type != EInteractOption.Actions)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "[动态交互选项继续执行]动态交互选项不是行为", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (generalContext is EntityContext)
			{
				int? entityId = ((EntityContext)generalContext).EntityId;
				long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId.Value);
				instance.SetInteractTarget(entityId);
				instance.SetInterctCreatureDataId(creatureDataId);
			}
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsByServerNotify((dynamicConfig.Type as IInteractActions).Actions, generalContext, notify.PlayerId, notify.IncId, notify.StartIndex, notify.EndIndex, notify.NeedFinishReq, null);
		}

		// Token: 0x0603B55D RID: 243037 RVA: 0x00F06F6C File Offset: 0x00F0516C
		public static int HandleInteractionSecondConfirm([Nullable(2)] CommonInteractOption option, PawnInteractController controller, Action<int, bool, CommonInteractOption> confirmCallback)
		{
			if (option == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[执行交互] 未提供交互选项信息";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", controller.InteractEntity.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			if (option.ConfirmBox == null)
			{
				TsInteractionUtils.HandleInteractionOptionNew(option, controller);
				return 0;
			}
			int num = Singleton<InteractConfirmController>.Instance.HandleAction(option, confirmCallback);
			if (num == 0)
			{
				if (controller.OnInteractActionEnd != null)
				{
					controller.OnInteractActionEnd();
				}
				return 0;
			}
			return num;
		}

		// Token: 0x0603B55E RID: 243038 RVA: 0x00F06FF0 File Offset: 0x00F051F0
		public unsafe static bool CheckTeleportInterceptByOption(int optionInstanceId, PawnInteractController controller)
		{
			InteractEntity interactEntity = controller.InteractEntity;
			Entity entity = (interactEntity != null) ? interactEntity.GetEntity() : null;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent == null)
			{
				return false;
			}
			IReadOnlyList<TeleportIntercept> configList = ConfigTeleportInterceptByEntityConfigId.GetConfigList(creatureDataComponent.GetPbDataId(), true);
			if (configList == null || configList.Count == 0)
			{
				return false;
			}
			int num = optionInstanceId - 1;
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			foreach (TeleportIntercept teleportIntercept in configList)
			{
				if (num == teleportIntercept.OptionIndex && instanceId == teleportIntercept.CurInstConfigId)
				{
					global::Vector position = global::Vector.Create((double)(*teleportIntercept.GetTargetPositionBytes()[0]), (double)(*teleportIntercept.GetTargetPositionBytes()[1]), (double)(*teleportIntercept.GetTargetPositionBytes()[2]));
					ValueTuple<bool, bool> valueTuple = ControllerBase<ResourceManagerController>.Instance.IsBlockResourceDownloaded(teleportIntercept.TargetMapConfigId, position);
					bool item = valueTuple.Item1;
					bool item2 = valueTuple.Item2;
					if (!item)
					{
						ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageTeleportToUnFinishAreaConfirm);
						confirmBoxDataNew.FunctionMap[1] = delegate()
						{
							ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
							ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.InvalidTeleportPosition);
						};
						ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
						return true;
					}
					if (item2)
					{
						ModelBase<SubPackageDownLoadModel>.Instance.OpenBlockNeedReLoginConfirm();
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603B55F RID: 243039 RVA: 0x00F0716C File Offset: 0x00F0536C
		public static bool CheckOptionLockType(int optionInstanceId, PawnInteractController controller, BaseTagComponent playerTagComponent)
		{
			CommonInteractOption commonInteractOption;
			if (optionInstanceId > -1)
			{
				commonInteractOption = controller.GetOptionByInstanceId(optionInstanceId);
			}
			else
			{
				commonInteractOption = controller.GetInteractiveOption(false);
			}
			if (commonInteractOption == null)
			{
				return false;
			}
			if (commonInteractOption.OptionLockTypeList != null && commonInteractOption.OptionLockTypeList.Count > 0)
			{
				using (List<EOptionLockType>.Enumerator enumerator = commonInteractOption.OptionLockTypeList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == EOptionLockType.OnMotor && playerTagComponent != null && playerTagComponent.HasExactTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托骑乘状态"]))
						{
							string localTextNew = ConfigMultiTextLang.GetLocalTextNew("InteractProhibitTips_Motor", null);
							ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType(EPromptSubViewType.FloatLinePrompt, null, null, new object[]
							{
								localTextNew
							}, null, null, null);
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0603B560 RID: 243040 RVA: 0x00F07244 File Offset: 0x00F05444
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0603B561 RID: 243041 RVA: 0x00F07246 File Offset: 0x00F05446
		public static void ResetStaticDefaultValue()
		{
			TsInteractionUtils.CurrentOpenViewName = null;
			TsInteractionUtils.LockInteractionRequest = false;
			TsInteractionUtils.IsOpenedInteractionHintView = false;
			TsInteractionUtils.WaitOpenViewName = null;
			TsInteractionUtils.IsWaitForInteractOpenViewDone = false;
		}

		// Token: 0x0402170A RID: 136970
		private static EUiViewName? CurrentOpenViewName;

		// Token: 0x0402170B RID: 136971
		private static bool LockInteractionRequest;

		// Token: 0x0402170C RID: 136972
		private static bool IsOpenedInteractionHintView;

		// Token: 0x0402170D RID: 136973
		public static EUiViewName? WaitOpenViewName;

		// Token: 0x0402170E RID: 136974
		public static bool IsWaitForInteractOpenViewDone;

		// Token: 0x0200BBCD RID: 48077
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04039F35 RID: 237365
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<EUiViewName, UiViewBase> <0>__OnOpenWaitViewDone;

			// Token: 0x04039F36 RID: 237366
			[Nullable(0)]
			public static Action <1>__OnOpenLoading;

			// Token: 0x04039F37 RID: 237367
			[Nullable(0)]
			public static Action<EUiViewName, int> <2>__OnCloseView;
		}
	}
}
