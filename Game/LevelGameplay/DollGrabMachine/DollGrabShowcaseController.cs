using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED9 RID: 28377
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DollGrabShowcaseController : ControllerBase<DollGrabShowcaseController>
	{
		// Token: 0x1700A41A RID: 42010
		// (get) Token: 0x06044C50 RID: 281680 RVA: 0x011E0B84 File Offset: 0x011DED84
		[Nullable(2)]
		private SceneItemDollGrabMachineComponent DollGrabMachineComponent
		{
			[NullableContext(2)]
			get
			{
				if (this.DollGrabShowcaseComponent == null)
				{
					return null;
				}
				int? bindInfiniteModeDollGrabEntityId = this.DollGrabShowcaseComponent.BindInfiniteModeDollGrabEntityId;
				bool flag = (bindInfiniteModeDollGrabEntityId ?? 0) == 0;
				if (flag)
				{
					return null;
				}
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(bindInfiniteModeDollGrabEntityId.Value);
				if (((entityByPbDataId != null) ? entityByPbDataId.Entity : null) == null)
				{
					return null;
				}
				return entityByPbDataId.Entity.GetComponent<SceneItemDollGrabMachineComponent>();
			}
		}

		// Token: 0x1700A41B RID: 42011
		// (get) Token: 0x06044C51 RID: 281681 RVA: 0x011E0BF1 File Offset: 0x011DEDF1
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IShowcaseDeliveryReward> DeliveryRewards
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				if (this.DollGrabShowcaseComponent == null)
				{
					return null;
				}
				return this.DollGrabShowcaseComponent.DeliveryRewards;
			}
		}

		// Token: 0x1700A41C RID: 42012
		// (get) Token: 0x06044C52 RID: 281682 RVA: 0x011E0C08 File Offset: 0x011DEE08
		public int ConditionId
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return 0;
				}
				return dollGrabMachineComponent.ConditionId;
			}
		}

		// Token: 0x1700A41D RID: 42013
		// (get) Token: 0x06044C53 RID: 281683 RVA: 0x011E0C1B File Offset: 0x011DEE1B
		public bool IsEndlessMode
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				return dollGrabMachineComponent != null && dollGrabMachineComponent.IsEndlessMode;
			}
		}

		// Token: 0x1700A41E RID: 42014
		// (get) Token: 0x06044C54 RID: 281684 RVA: 0x011E0C2E File Offset: 0x011DEE2E
		[Nullable(2)]
		public IDollGrabInfiniteShowCaseRewardData CurrentScoreRewardData
		{
			[NullableContext(2)]
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return null;
				}
				return dollGrabMachineComponent.CurrentScoreRewardData;
			}
		}

		// Token: 0x06044C55 RID: 281685 RVA: 0x011E0C44 File Offset: 0x011DEE44
		protected override bool OnInit()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineController] 初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<DollGrabModel>.Instance.LoadDollGrabMachineGlobalConfig();
			return true;
		}

		// Token: 0x06044C56 RID: 281686 RVA: 0x011E0C7B File Offset: 0x011DEE7B
		private void OpenDollGrabShowcaseInspectView()
		{
			if (this.IsGameplayReady)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabShowcaseInspectView, null, delegate(bool _, int _)
			{
				this.DollGrabShowcaseComponent.OnStartShowcaseGameplay();
			});
			this.IsGameplayReady = true;
			TsInteractionUtils.RegisterOpenViewName(EUiViewName.DollGrabShowcaseInspectView);
		}

		// Token: 0x06044C57 RID: 281687 RVA: 0x011E0CB4 File Offset: 0x011DEEB4
		public UniTask InitAllDollShowcaseActors()
		{
			DollGrabShowcaseController.<InitAllDollShowcaseActors>d__17 <InitAllDollShowcaseActors>d__;
			<InitAllDollShowcaseActors>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAllDollShowcaseActors>d__.<>4__this = this;
			<InitAllDollShowcaseActors>d__.<>1__state = -1;
			<InitAllDollShowcaseActors>d__.<>t__builder.Start<DollGrabShowcaseController.<InitAllDollShowcaseActors>d__17>(ref <InitAllDollShowcaseActors>d__);
			return <InitAllDollShowcaseActors>d__.<>t__builder.Task;
		}

		// Token: 0x06044C58 RID: 281688 RVA: 0x011E0CF8 File Offset: 0x011DEEF8
		public void StartDollGrabShowcaseView(IDollGrabShowcase config)
		{
			if (this.IsGameplayReady)
			{
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(config.ShowcaseEntityId);
			if (!entityByPbDataId || !entityByPbDataId.Entity)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.DollGrabMachine;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[DollGrabShowcase] 娃娃展示柜实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", config.ShowcaseEntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.DollGrabShowcaseComponent = entityByPbDataId.Entity.GetComponent<SceneItemDollGrabShowcaseComponent>();
			if (this.DollGrabShowcaseComponent == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabShowcase] 娃娃展示柜实体没有SceneItemDollGrabShowcaseComponent组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.OpenDollGrabShowcaseInspectView();
		}

		// Token: 0x06044C59 RID: 281689 RVA: 0x011E0DA8 File Offset: 0x011DEFA8
		public void StartDollGrabShowcaseViewByDelivery()
		{
			if (this.IsGameplayReady || this.DollGrabShowcaseComponent == null)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabDeliveryView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabDeliveryView, null);
			}
			this.OpenDollGrabShowcaseInspectView();
		}

		// Token: 0x06044C5A RID: 281690 RVA: 0x011E0DE4 File Offset: 0x011DEFE4
		[NullableContext(2)]
		public void OpenAllViewCamera(Action<ELevelEventState> finishCallback = null)
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return;
			}
			SceneItemActorComponent component = this.DollGrabShowcaseComponent.Entity.GetComponent<SceneItemActorComponent>();
			if (!component)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabShowcase] 娃娃展示柜实体没有SceneItemActorComponent组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			IShowcaseFullViewCameraConfig allViewCameraInfo = this.DollGrabShowcaseComponent.AllViewCameraInfo;
			if (allViewCameraInfo == null)
			{
				return;
			}
			Singleton<MathUtils>.Instance.CommonTempVector.Set((double)allViewCameraInfo.PosAndRot.X.GetValueOrDefault(), (double)allViewCameraInfo.PosAndRot.Y.GetValueOrDefault(), (double)allViewCameraInfo.PosAndRot.Z.GetValueOrDefault());
			Singleton<MathUtils>.Instance.CommonTempRotator.Set(allViewCameraInfo.PosAndRot.Pitch.GetValueOrDefault(), allViewCameraInfo.PosAndRot.A.GetValueOrDefault(), allViewCameraInfo.PosAndRot.Roll.GetValueOrDefault());
			BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.CineCamera;
			float fov = LguiUtil.AdaptFieldOfViewByViewport(allViewCameraInfo.Fov, (cineCamera != null) ? cineCamera.AspectRatio_DEPRECATED : 1.7777778f);
			DollGrabCameraConfig cameraInfo = new DollGrabCameraConfig(Singleton<MathUtils>.Instance.CommonTempVector, Singleton<MathUtils>.Instance.CommonTempRotator, 0.5f, 0.5f, true, true, fov);
			ModelBase<DollGrabModel>.Instance.ExecuteAdjustPlayerCamera(component, cameraInfo, "DollGrabMachineFixCamera", finishCallback);
		}

		// Token: 0x06044C5B RID: 281691 RVA: 0x011E0F50 File Offset: 0x011DF150
		public UniTask OpenFocusViewCamera(DollViewCameraInfo cameraInfo)
		{
			DollGrabShowcaseController.<OpenFocusViewCamera>d__21 <OpenFocusViewCamera>d__;
			<OpenFocusViewCamera>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenFocusViewCamera>d__.<>4__this = this;
			<OpenFocusViewCamera>d__.cameraInfo = cameraInfo;
			<OpenFocusViewCamera>d__.<>1__state = -1;
			<OpenFocusViewCamera>d__.<>t__builder.Start<DollGrabShowcaseController.<OpenFocusViewCamera>d__21>(ref <OpenFocusViewCamera>d__);
			return <OpenFocusViewCamera>d__.<>t__builder.Task;
		}

		// Token: 0x06044C5C RID: 281692 RVA: 0x011E0F9C File Offset: 0x011DF19C
		public void OnClickMoveInput(string name, InputDistributeDefine.EActionType actionType)
		{
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				if (name == "向左移动")
				{
					this.DollGrabShowcaseComponent.OpenDollViewCamera(350001);
					return;
				}
				if (!(name == "向右移动"))
				{
					return;
				}
				this.DollGrabShowcaseComponent.OpenDollViewCamera(350002);
				return;
			}
			else
			{
				if (name == "向左移动")
				{
					this.DollGrabShowcaseComponent.CloseDollViewCamera();
					return;
				}
				if (!(name == "向右移动"))
				{
					return;
				}
				this.DollGrabShowcaseComponent.CloseDollViewCamera();
				return;
			}
		}

		// Token: 0x06044C5D RID: 281693 RVA: 0x011E101F File Offset: 0x011DF21F
		public void ExitDollGrabGameplay()
		{
			this.IsGameplayReady = false;
			if (!this.EndToEndlessMode)
			{
				ModelBase<DollGrabModel>.Instance.ExecuteRestorePlayerCamera("DollGrabMachineFixCamera", null);
			}
			this.EndToEndlessMode = false;
			this.DollGrabShowcaseComponent.OnEndShowcaseGameplay();
			this.DollGrabShowcaseComponent = null;
		}

		// Token: 0x06044C5E RID: 281694 RVA: 0x011E105C File Offset: 0x011DF25C
		public void OnNotifyDollDelivery(DollDeliveryNotify notify)
		{
			Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
			foreach (int num in notify.ItemIds)
			{
				DollGrabItemsCsv? config = ConfigDollGrabItemsCsvById.GetConfig(num, true);
				if (config == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[OnNotifyDollDelivery] 交付娃娃信息配置缺失";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					if (!dictionary.ContainsKey(config.Value.ShowcaseBelongType))
					{
						dictionary.Add(config.Value.ShowcaseBelongType, new List<int>());
					}
					dictionary[config.Value.ShowcaseBelongType].Add(num);
				}
			}
			foreach (KeyValuePair<string, List<int>> keyValuePair in dictionary)
			{
				string text;
				List<int> list;
				keyValuePair.Deconstruct(out text, out list);
				string key = text;
				List<int> list2 = list;
				if (this.DollGrabShowcaseMap.ContainsKey(key))
				{
					this.DollGrabShowcaseMap[key].OnNotifyDollDeliveryInfos(list2, true);
				}
				else if (!this.DollDeliveryInfo.ContainsKey(key))
				{
					this.DollDeliveryInfo.Add(key, list2);
				}
				else
				{
					this.DollDeliveryInfo[key].AddRange(list2);
				}
			}
			foreach (int num2 in notify.DropIds)
			{
				Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(num2);
				if (dropPackagePreview == null)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.DollGrabMachine;
					ELogAuthor author2 = ELogAuthor.FJH;
					string message2 = "[OnNotifyDollDelivery] 交付掉落信息配置缺失";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DropId", num2);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					foreach (KeyValuePair<int, int> keyValuePair2 in dropPackagePreview)
					{
						int num3;
						int num4;
						keyValuePair2.Deconstruct(out num3, out num4);
						int configId = num3;
						int count = num4;
						RewardItemData item = new RewardItemData(configId, count, null, EDropItemType.Normal);
						ModelBase<DollGrabModel>.Instance.DollDeliveryRewardData.Add(item);
					}
				}
			}
		}

		// Token: 0x06044C5F RID: 281695 RVA: 0x011E12D8 File Offset: 0x011DF4D8
		public void OnClickDelivery()
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return;
			}
			DollDeliveryRequest dollDeliveryRequest = DollDeliveryRequest.Create();
			dollDeliveryRequest.EntityCfgId = this.DollGrabShowcaseComponent.PdDataId;
			Singleton<Net>.Instance.Call<DollDeliveryResponse>(ERequestMessageId.DollDeliveryRequest, dollDeliveryRequest, delegate(DollDeliveryResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[OnClickDelivery] 交付请求失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineDeliveryFinish, false);
				}
			}, 0);
		}

		// Token: 0x06044C60 RID: 281696 RVA: 0x011E1338 File Offset: 0x011DF538
		[NullableContext(0)]
		public UniTask<bool> RequestDollMachineMapInfoAsync()
		{
			DollGrabShowcaseController.<RequestDollMachineMapInfoAsync>d__26 <RequestDollMachineMapInfoAsync>d__;
			<RequestDollMachineMapInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestDollMachineMapInfoAsync>d__.<>1__state = -1;
			<RequestDollMachineMapInfoAsync>d__.<>t__builder.Start<DollGrabShowcaseController.<RequestDollMachineMapInfoAsync>d__26>(ref <RequestDollMachineMapInfoAsync>d__);
			return <RequestDollMachineMapInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044C61 RID: 281697 RVA: 0x011E1374 File Offset: 0x011DF574
		public void RegisterShowcase(SceneItemDollGrabShowcaseComponent comp)
		{
			if (this.DollGrabShowcaseMap.ContainsKey(comp.BelongType))
			{
				return;
			}
			this.DollGrabShowcaseMap.Add(comp.BelongType, comp);
			if (this.DollDeliveryInfo.ContainsKey(comp.BelongType))
			{
				comp.OnNotifyDollDeliveryInfos(this.DollDeliveryInfo[comp.BelongType], true);
				this.DollDeliveryInfo.Remove(comp.BelongType);
			}
		}

		// Token: 0x06044C62 RID: 281698 RVA: 0x011E13E4 File Offset: 0x011DF5E4
		public void UnregisterShowcase(SceneItemDollGrabShowcaseComponent comp)
		{
			if (!this.DollGrabShowcaseMap.ContainsKey(comp.BelongType))
			{
				return;
			}
			this.DollGrabShowcaseMap.Remove(comp.BelongType);
		}

		// Token: 0x06044C63 RID: 281699 RVA: 0x011E140C File Offset: 0x011DF60C
		public List<DollItemInfo> GetCurrentDollItemInfoList()
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return new List<DollItemInfo>();
			}
			return this.DollGrabShowcaseComponent.GetDollItemInfoList();
		}

		// Token: 0x06044C64 RID: 281700 RVA: 0x011E1427 File Offset: 0x011DF627
		[NullableContext(2)]
		public IDollCollectData GetCollectData()
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return null;
			}
			return this.DollGrabShowcaseComponent.GetCollectData();
		}

		// Token: 0x06044C65 RID: 281701 RVA: 0x011E143E File Offset: 0x011DF63E
		public void SetDeliveryCompleteCallback(Action callback)
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return;
			}
			this.DollGrabShowcaseComponent.SetDeliveryCompleteCallback(callback);
		}

		// Token: 0x06044C66 RID: 281702 RVA: 0x011E1458 File Offset: 0x011DF658
		public void ChangeShowcasePerformanceState(int state)
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return;
			}
			SceneItemStateComponent component = this.DollGrabShowcaseComponent.Entity.GetComponent<SceneItemStateComponent>();
			if (component == null)
			{
				return;
			}
			component.ChangePerformanceState(state, false, true);
		}

		// Token: 0x06044C67 RID: 281703 RVA: 0x011E148C File Offset: 0x011DF68C
		[NullableContext(0)]
		public UniTask<int?> StartDollGrabDeliveryView([Nullable(1)] SceneItemDollGrabShowcaseComponent showcaseComp)
		{
			DollGrabShowcaseController.<StartDollGrabDeliveryView>d__33 <StartDollGrabDeliveryView>d__;
			<StartDollGrabDeliveryView>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<StartDollGrabDeliveryView>d__.<>4__this = this;
			<StartDollGrabDeliveryView>d__.showcaseComp = showcaseComp;
			<StartDollGrabDeliveryView>d__.<>1__state = -1;
			<StartDollGrabDeliveryView>d__.<>t__builder.Start<DollGrabShowcaseController.<StartDollGrabDeliveryView>d__33>(ref <StartDollGrabDeliveryView>d__);
			return <StartDollGrabDeliveryView>d__.<>t__builder.Task;
		}

		// Token: 0x06044C68 RID: 281704 RVA: 0x011E14D7 File Offset: 0x011DF6D7
		public List<int> GetShowcaseBindingItemIds()
		{
			if (this.DollGrabShowcaseComponent == null)
			{
				return new List<int>();
			}
			return this.DollGrabShowcaseComponent.GetAllBindingItemIds();
		}

		// Token: 0x040264D0 RID: 156880
		[Nullable(2)]
		private SceneItemDollGrabShowcaseComponent DollGrabShowcaseComponent;

		// Token: 0x040264D1 RID: 156881
		private bool IsGameplayReady;

		// Token: 0x040264D2 RID: 156882
		private readonly Dictionary<string, List<int>> DollDeliveryInfo = new Dictionary<string, List<int>>();

		// Token: 0x040264D3 RID: 156883
		private readonly Dictionary<string, SceneItemDollGrabShowcaseComponent> DollGrabShowcaseMap = new Dictionary<string, SceneItemDollGrabShowcaseComponent>();

		// Token: 0x040264D4 RID: 156884
		public bool EndToEndlessMode;
	}
}
