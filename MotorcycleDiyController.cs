using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x020022DA RID: 8922
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MotorcycleDiyController : ControllerBase<MotorcycleDiyController>
{
	// Token: 0x06010E18 RID: 69144 RVA: 0x0049FDEC File Offset: 0x0049DFEC
	protected override bool OnInit()
	{
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x06010E19 RID: 69145 RVA: 0x0049FDF5 File Offset: 0x0049DFF5
	protected override bool OnClear()
	{
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x06010E1A RID: 69146 RVA: 0x0049FE00 File Offset: 0x0049E000
	protected void OnRegisterNetEvent()
	{
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenSet));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<Net>.Instance.Register<MotorOutlookRegionInfoNotify>(ENotifyMessageId.MotorOutlookRegionInfoNotify, new Action<MotorOutlookRegionInfoNotify, Net.CallbackStatus>(this.OnMotorOutlookRegionInfoNotify));
		Singleton<Net>.Instance.Register<MotorOutlookAddNotify>(ENotifyMessageId.MotorOutlookAddNotify, new Action<MotorOutlookAddNotify, Net.CallbackStatus>(this.OnMotorOutlookAddNotify));
		Singleton<Net>.Instance.Register<MotorOutlookOwnedChangeNotify>(ENotifyMessageId.MotorOutlookOwnedChangeNotify, new Action<MotorOutlookOwnedChangeNotify, Net.CallbackStatus>(this.OnMotorOutlookOwnedChangeNotify));
		Singleton<Net>.Instance.Register<MotorOutlookEquippedChangeNotify>(ENotifyMessageId.MotorOutlookEquippedChangeNotify, new Action<MotorOutlookEquippedChangeNotify, Net.CallbackStatus>(this.OnMotorOutlookEquippedChangeNotify));
		Singleton<Net>.Instance.Register<MotorOutlookFullChangeNotify>(ENotifyMessageId.MotorOutlookFullChangeNotify, new Action<MotorOutlookFullChangeNotify, Net.CallbackStatus>(this.OnMotorOutlookFullChangeNotify));
	}

	// Token: 0x06010E1B RID: 69147 RVA: 0x0049FEF0 File Offset: 0x0049E0F0
	protected void OnUnRegisterNetEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenSet));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOutlookRegionInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOutlookAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOutlookOwnedChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOutlookEquippedChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOutlookFullChangeNotify);
	}

	// Token: 0x06010E1C RID: 69148 RVA: 0x0049FFA1 File Offset: 0x0049E1A1
	private void OnFunctionOpenSet(EFunctionType functionType, bool isOpen)
	{
		if (!isOpen)
		{
			return;
		}
		if (functionType == EFunctionType.MotorDevelop)
		{
			this.MotorDiyInfoRequest();
		}
	}

	// Token: 0x06010E1D RID: 69149 RVA: 0x0049FFB5 File Offset: 0x0049E1B5
	private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
	{
		if (!isOpen)
		{
			return;
		}
		if (functionType == EFunctionType.MotorDevelop)
		{
			this.MotorDiyInfoRequest();
		}
	}

	// Token: 0x06010E1E RID: 69150 RVA: 0x0049FFCC File Offset: 0x0049E1CC
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
	{
		foreach (IProto_NormalItem proto_NormalItem in normalItemList)
		{
			if (ModelBase<MotorcycleDiyModel>.Instance.IsSceneItemId(proto_NormalItem.Id))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiySceneItemUpdate);
				break;
			}
		}
	}

	// Token: 0x06010E1F RID: 69151 RVA: 0x004A0034 File Offset: 0x0049E234
	private void OnMotorOutlookRegionInfoNotify(MotorOutlookRegionInfoNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<MotorcycleDiyModel>.Instance.UpdateMotorCanUseOutlookInfo(message);
		}
	}

	// Token: 0x06010E20 RID: 69152 RVA: 0x004A0044 File Offset: 0x0049E244
	private void OnMotorOutlookAddNotify(MotorOutlookAddNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<MotorcycleDiyModel>.Instance.AddMotorOutlookInfo(message);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoUpdate);
		}
	}

	// Token: 0x06010E21 RID: 69153 RVA: 0x004A0064 File Offset: 0x0049E264
	private void OnMotorOutlookOwnedChangeNotify(MotorOutlookOwnedChangeNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<MotorcycleDiyModel>.Instance.UpdateMotorOutlookOwnedChange(message);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoUpdate);
		}
	}

	// Token: 0x06010E22 RID: 69154 RVA: 0x004A0084 File Offset: 0x0049E284
	private void OnMotorOutlookEquippedChangeNotify(MotorOutlookEquippedChangeNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<MotorcycleDiyModel>.Instance.UpdateMotorOutlookEquippedChange(message);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoUpdate);
		}
	}

	// Token: 0x06010E23 RID: 69155 RVA: 0x004A00A4 File Offset: 0x0049E2A4
	private void OnMotorOutlookFullChangeNotify(MotorOutlookFullChangeNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message != null)
		{
			ModelBase<MotorcycleDiyModel>.Instance.UpdateMotorOutlookFullChange(message);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyFullOutlookUpdate);
		}
	}

	// Token: 0x06010E24 RID: 69156 RVA: 0x004A00D4 File Offset: 0x0049E2D4
	public void MotorDiyInfoRequest()
	{
		MotorOutlookInfoRequest message = MotorOutlookInfoRequest.Create();
		Singleton<Net>.Instance.Call<MotorOutlookInfoResponse>(ERequestMessageId.MotorOutlookInfoRequest, message, delegate(MotorOutlookInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<MotorcycleDiyModel>.Instance.UpdateMotorOutlookInfo(response);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20233, null, true, true);
		}, 0);
	}

	// Token: 0x06010E25 RID: 69157 RVA: 0x004A0118 File Offset: 0x0049E318
	[NullableContext(2)]
	public void EquipMotorSkinRequest(int skinId, Action callBack = null)
	{
		MotorUseSkinRequest motorUseSkinRequest = MotorUseSkinRequest.Create();
		motorUseSkinRequest.SkinId = skinId;
		Singleton<Net>.Instance.Call<MotorUseSkinResponse>(ERequestMessageId.MotorUseSkinRequest, motorUseSkinRequest, delegate(MotorUseSkinResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28777, null, true, true);
				return;
			}
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, 0);
	}

	// Token: 0x06010E26 RID: 69158 RVA: 0x004A015C File Offset: 0x0049E35C
	public void EquipMotorOutLookRequest(List<int> stickerIds, List<int> decorateIds, int frameId, [Nullable(2)] Action callBack = null)
	{
		MotorChangeOutlookRequest motorChangeOutlookRequest = MotorChangeOutlookRequest.Create();
		motorChangeOutlookRequest.StickerEquipped.AddRange(stickerIds);
		motorChangeOutlookRequest.DecorationsEquipped.AddRange(decorateIds);
		motorChangeOutlookRequest.FrameEquipped = frameId;
		Singleton<Net>.Instance.Call<MotorChangeOutlookResponse>(ERequestMessageId.MotorChangeOutlookRequest, motorChangeOutlookRequest, delegate(MotorChangeOutlookResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18201, null, true, true);
				return;
			}
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, 0);
	}

	// Token: 0x06010E27 RID: 69159 RVA: 0x004A01BC File Offset: 0x0049E3BC
	public void CreateMotorOutlookPresetRequest(List<int> stickerIds, List<int> decorateIds, int frameId, string name, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Action<List<MotorOutlookPresetPlanPb>> callBack = null)
	{
		MotorOutlookCreatePresetRequest motorOutlookCreatePresetRequest = MotorOutlookCreatePresetRequest.Create();
		MotorOutlookEquippedPb motorOutlookEquippedPb = MotorOutlookEquippedPb.Create();
		motorOutlookEquippedPb.StickerEquipped.AddRange(stickerIds);
		motorOutlookEquippedPb.DecorationsEquipped.AddRange(decorateIds);
		motorOutlookEquippedPb.FrameEquipped = frameId;
		motorOutlookCreatePresetRequest.Preset = motorOutlookEquippedPb;
		motorOutlookCreatePresetRequest.Name = name;
		Singleton<Net>.Instance.Call<MotorOutlookCreatePresetResponse>(ERequestMessageId.MotorOutlookCreatePresetRequest, motorOutlookCreatePresetRequest, delegate(MotorOutlookCreatePresetResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15857, null, true, true);
				return;
			}
			MotorOutlookPlayerPresetPb motorOutlookPreset = response.MotorOutlookPreset;
			RepeatedField<MotorOutlookPresetPlanPb> plan = motorOutlookPreset.Plan;
			ModelBase<MotorcycleDiyModel>.Instance.UpdateCustomPresetInfo(motorOutlookPreset);
			Action<List<MotorOutlookPresetPlanPb>> callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2((plan != null) ? plan.ToList<MotorOutlookPresetPlanPb>() : new List<MotorOutlookPresetPlanPb>());
		}, 0);
	}

	// Token: 0x06010E28 RID: 69160 RVA: 0x004A0230 File Offset: 0x0049E430
	[return: Nullable(0)]
	public UniTask<Aki.Protocol.ErrorCode> CreateMotorOutlookPresetRequestAsync(List<int> stickerIds, List<int> decorateIds, int frameId, string name)
	{
		MotorcycleDiyController.<CreateMotorOutlookPresetRequestAsync>d__16 <CreateMotorOutlookPresetRequestAsync>d__;
		<CreateMotorOutlookPresetRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
		<CreateMotorOutlookPresetRequestAsync>d__.stickerIds = stickerIds;
		<CreateMotorOutlookPresetRequestAsync>d__.decorateIds = decorateIds;
		<CreateMotorOutlookPresetRequestAsync>d__.frameId = frameId;
		<CreateMotorOutlookPresetRequestAsync>d__.name = name;
		<CreateMotorOutlookPresetRequestAsync>d__.<>1__state = -1;
		<CreateMotorOutlookPresetRequestAsync>d__.<>t__builder.Start<MotorcycleDiyController.<CreateMotorOutlookPresetRequestAsync>d__16>(ref <CreateMotorOutlookPresetRequestAsync>d__);
		return <CreateMotorOutlookPresetRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010E29 RID: 69161 RVA: 0x004A028C File Offset: 0x0049E48C
	[NullableContext(2)]
	public void DeleteMotorOutlookPresetRequest(int presetId, Action callBack = null)
	{
		MotorOutlookDeletePresetRequest motorOutlookDeletePresetRequest = MotorOutlookDeletePresetRequest.Create();
		motorOutlookDeletePresetRequest.Id = presetId;
		Singleton<Net>.Instance.Call<MotorOutlookDeletePresetResponse>(ERequestMessageId.MotorOutlookDeletePresetRequest, motorOutlookDeletePresetRequest, delegate(MotorOutlookDeletePresetResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28577, null, true, true);
				return;
			}
			ModelBase<MotorcycleDiyModel>.Instance.RemoveSingleCustomPresetInfo(presetId);
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, 0);
	}

	// Token: 0x06010E2A RID: 69162 RVA: 0x004A02DC File Offset: 0x0049E4DC
	[return: Nullable(0)]
	public UniTask<Aki.Protocol.ErrorCode> EditMotorOutlookPresetRequestAsync(int presetId, List<int> stickerIds, List<int> decorateIds, int frameId, string name)
	{
		MotorcycleDiyController.<EditMotorOutlookPresetRequestAsync>d__18 <EditMotorOutlookPresetRequestAsync>d__;
		<EditMotorOutlookPresetRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
		<EditMotorOutlookPresetRequestAsync>d__.presetId = presetId;
		<EditMotorOutlookPresetRequestAsync>d__.stickerIds = stickerIds;
		<EditMotorOutlookPresetRequestAsync>d__.decorateIds = decorateIds;
		<EditMotorOutlookPresetRequestAsync>d__.frameId = frameId;
		<EditMotorOutlookPresetRequestAsync>d__.name = name;
		<EditMotorOutlookPresetRequestAsync>d__.<>1__state = -1;
		<EditMotorOutlookPresetRequestAsync>d__.<>t__builder.Start<MotorcycleDiyController.<EditMotorOutlookPresetRequestAsync>d__18>(ref <EditMotorOutlookPresetRequestAsync>d__);
		return <EditMotorOutlookPresetRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010E2B RID: 69163 RVA: 0x004A0344 File Offset: 0x0049E544
	public void EditMotorOutlookPresetRequest(int presetId, List<int> stickerIds, List<int> decorateIds, int frameId, string name, [Nullable(2)] Action callBack = null)
	{
		MotorOutlookEditPresetRequest motorOutlookEditPresetRequest = MotorOutlookEditPresetRequest.Create();
		MotorOutlookEquippedPb motorOutlookEquippedPb = MotorOutlookEquippedPb.Create();
		motorOutlookEquippedPb.StickerEquipped.AddRange(stickerIds);
		motorOutlookEquippedPb.DecorationsEquipped.AddRange(decorateIds);
		motorOutlookEquippedPb.FrameEquipped = frameId;
		MotorOutlookPresetPlanPb motorOutlookPresetPlanPb = MotorOutlookPresetPlanPb.Create();
		motorOutlookPresetPlanPb.Id = presetId;
		motorOutlookPresetPlanPb.Preset = motorOutlookEquippedPb;
		motorOutlookPresetPlanPb.Name = name;
		motorOutlookEditPresetRequest.PresetPlan = motorOutlookPresetPlanPb;
		Singleton<Net>.Instance.Call<MotorOutlookEditPresetResponse>(ERequestMessageId.MotorOutlookEditPresetRequest, motorOutlookEditPresetRequest, delegate(MotorOutlookEditPresetResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17807, null, true, true);
				return;
			}
			ModelBase<MotorcycleDiyModel>.Instance.UpdateCustomPresetInfo(response.MotorOutlookPreset);
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, 0);
	}

	// Token: 0x06010E2C RID: 69164 RVA: 0x004A03CC File Offset: 0x0049E5CC
	public void EquipMotorStickerRequest(List<int> stickerIds, [Nullable(2)] Action callBack = null)
	{
		int equippedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId();
		List<int> equippedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationIdList();
		this.EquipMotorOutLookRequest(stickerIds, equippedDecorationIdList, equippedFrameId, callBack);
	}

	// Token: 0x06010E2D RID: 69165 RVA: 0x004A03FC File Offset: 0x0049E5FC
	[NullableContext(2)]
	public void EquipMotorFrameRequest(int frameId, Action callBack = null)
	{
		List<int> equippedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerIdList();
		List<int> equippedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationIdList();
		this.EquipMotorOutLookRequest(equippedStickerIdList, equippedDecorationIdList, frameId, callBack);
	}

	// Token: 0x06010E2E RID: 69166 RVA: 0x004A042C File Offset: 0x0049E62C
	public void EquipMotorDecorationRequest(List<int> decorateIds, [Nullable(2)] Action callBack = null)
	{
		List<int> equippedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerIdList();
		int equippedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId();
		this.EquipMotorOutLookRequest(equippedStickerIdList, decorateIds, equippedFrameId, callBack);
	}

	// Token: 0x06010E2F RID: 69167 RVA: 0x004A045C File Offset: 0x0049E65C
	[NullableContext(2)]
	public void UseMotorSceneRequest(int sceneId, Action callBack = null)
	{
		MotorUseSceneRequest motorUseSceneRequest = MotorUseSceneRequest.Create();
		motorUseSceneRequest.SceneId = sceneId;
		Singleton<Net>.Instance.Call<MotorUseSceneResponse>(ERequestMessageId.MotorUseSceneRequest, motorUseSceneRequest, delegate(MotorUseSceneResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18051, null, true, true);
				return;
			}
			int currentSceneId = (response.SceneInUse > 0) ? response.SceneInUse : sceneId;
			ModelBase<MotorcycleDiyModel>.Instance.SetCurrentSceneId(currentSceneId);
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		}, 0);
	}

	// Token: 0x06010E30 RID: 69168 RVA: 0x004A04AC File Offset: 0x0049E6AC
	[NullableContext(0)]
	public UniTask<bool> OpenRootView()
	{
		MotorcycleDiyController.<OpenRootView>d__24 <OpenRootView>d__;
		<OpenRootView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenRootView>d__.<>1__state = -1;
		<OpenRootView>d__.<>t__builder.Start<MotorcycleDiyController.<OpenRootView>d__24>(ref <OpenRootView>d__);
		return <OpenRootView>d__.<>t__builder.Task;
	}

	// Token: 0x06010E31 RID: 69169 RVA: 0x004A04E8 File Offset: 0x0049E6E8
	public void OpenTargetViewByReward(List<RewardItemData> motorItemDataList, int jumpDiyType = 0)
	{
		if (motorItemDataList.Count == 0)
		{
			return;
		}
		int motorSkinId = 0;
		foreach (RewardItemData rewardItemData in motorItemDataList)
		{
			if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(rewardItemData.ConfigId)) == InventoryDefine.EItemDataType.MotorSkinItem)
			{
				motorSkinId = rewardItemData.ConfigId;
				break;
			}
		}
		if (motorSkinId == 0)
		{
			this.OpenRootViewByReward(motorItemDataList, jumpDiyType);
			return;
		}
		if (ModelBase<MotorcycleDiyModel>.Instance.IsEquipFrameLockedByPlayer())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorSkin_Tips03", Array.Empty<object>());
			return;
		}
		this.EquipMotorSkinRequest(motorSkinId, delegate
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiySkinView, null, null);
			ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotForAnyItem(motorSkinId);
		});
	}

	// Token: 0x06010E32 RID: 69170 RVA: 0x004A05B8 File Offset: 0x0049E7B8
	public void OpenRootViewByReward(List<RewardItemData> motorItemDataList, int jumpDiyType = 0)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		int num = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId();
		int num2 = num;
		EUiTabViewName openTabView = EUiTabViewName.MotorcycleDiyFrameTabView;
		switch (jumpDiyType)
		{
		case 1:
			openTabView = EUiTabViewName.MotorcycleDiyFrameTabView;
			break;
		case 2:
			openTabView = EUiTabViewName.MotorcycleDiyStickerTabView;
			break;
		case 3:
			openTabView = EUiTabViewName.MotorcycleDiyDecorationTabView;
			break;
		}
		foreach (RewardItemData rewardItemData in motorItemDataList)
		{
			InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(rewardItemData.ConfigId));
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorFrameItem)
			{
				num2 = rewardItemData.ConfigId;
			}
			else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorStickerItem)
			{
				list.Add(rewardItemData.ConfigId);
			}
			else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorDecorationItem)
			{
				list2.Add(rewardItemData.ConfigId);
			}
		}
		if (num != num2 && ModelBase<MotorcycleDiyModel>.Instance.IsEquipFrameLockedByPlayer())
		{
			ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorDIYWarning02", Array.Empty<object>());
			return;
		}
		num = num2;
		List<int> list3 = new List<int>
		{
			0,
			0,
			0
		};
		foreach (int num3 in list)
		{
			MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num3);
			if (motorStickerConfig != null)
			{
				int partId = motorStickerConfig.Value.PartId;
				int num4 = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART, partId);
				if (num4 != -1)
				{
					list3[num4] = num3;
				}
			}
		}
		List<int> defaultDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetDefaultDecorationIdList();
		foreach (int num5 in list2)
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num5);
			if (motorDecorationConfig != null)
			{
				int partId2 = motorDecorationConfig.Value.PartId;
				int num6 = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART, partId2);
				if (num6 != -1)
				{
					defaultDecorationIdList[num6] = num5;
				}
			}
		}
		this.EquipMotorOutLookRequest(list3, defaultDecorationIdList, num, delegate
		{
			ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
			IOpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
			{
				OpenTabView = new EUiTabViewName?(openTabView)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
		});
	}

	// Token: 0x06010E33 RID: 69171 RVA: 0x004A0828 File Offset: 0x0049EA28
	public void OpenMotorGeneralPreviewView(int previewId)
	{
		MotorGeneralPreview? motorGeneralPreviewConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorGeneralPreviewConfig(previewId);
		if (motorGeneralPreviewConfig == null)
		{
			return;
		}
		EUiViewName? euiViewName = null;
		if (motorGeneralPreviewConfig.Value.GetStickerArray() != null && motorGeneralPreviewConfig.Value.GetStickerArray().Length != 0)
		{
			euiViewName = new EUiViewName?(EUiViewName.MotorcycleDiyStickerPreviewView);
		}
		else if ((motorGeneralPreviewConfig.Value.GetDecorationsArray() != null && motorGeneralPreviewConfig.Value.GetDecorationsArray().Length != 0) || motorGeneralPreviewConfig.Value.Frame > 0)
		{
			euiViewName = new EUiViewName?(EUiViewName.MotorcycleDiyDecorationPreviewView);
		}
		if (euiViewName == null)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(euiViewName.Value, previewId, null);
	}

	// Token: 0x06010E34 RID: 69172 RVA: 0x004A08E8 File Offset: 0x0049EAE8
	[NullableContext(0)]
	public UniTask<bool> OpenMotorcycleScenePopupView()
	{
		MotorcycleDiyController.<OpenMotorcycleScenePopupView>d__28 <OpenMotorcycleScenePopupView>d__;
		<OpenMotorcycleScenePopupView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenMotorcycleScenePopupView>d__.<>1__state = -1;
		<OpenMotorcycleScenePopupView>d__.<>t__builder.Start<MotorcycleDiyController.<OpenMotorcycleScenePopupView>d__28>(ref <OpenMotorcycleScenePopupView>d__);
		return <OpenMotorcycleScenePopupView>d__.<>t__builder.Task;
	}
}
