using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Summon;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x0200245C RID: 9308
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PhantomBattleController : UiControllerBase<PhantomBattleController>
{
	// Token: 0x060120A1 RID: 73889 RVA: 0x004F6627 File Offset: 0x004F4827
	public static void InitData()
	{
	}

	// Token: 0x060120A2 RID: 73890 RVA: 0x004F662C File Offset: 0x004F482C
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<Aki.Protocol.PhantomItem>(EEventName.OnAddPhantomItem, new Action<Aki.Protocol.PhantomItem>(this.OnAddPhantomItem));
		Singleton<EventSystem>.Instance.Add<Aki.Protocol.PhantomItem>(EEventName.OnResponsePhantomItem, new Action<Aki.Protocol.PhantomItem>(this.OnResponsePhantomItem));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemovePhantomItem, new Action<IReadOnlyList<int>>(this.OnRemovePhantomItem));
		Singleton<EventSystem>.Instance.Add<PhantomItemResponse>(EEventName.OnEquipPhantomItem, new Action<PhantomItemResponse>(this.OnEquipPhantomItem));
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
	}

	// Token: 0x060120A3 RID: 73891 RVA: 0x004F66C8 File Offset: 0x004F48C8
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddPhantomItem, new Action<Aki.Protocol.PhantomItem>(this.OnAddPhantomItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResponsePhantomItem, new Action<Aki.Protocol.PhantomItem>(this.OnResponsePhantomItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemovePhantomItem, new Action<IReadOnlyList<int>>(this.OnRemovePhantomItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEquipPhantomItem, new Action<PhantomItemResponse>(this.OnEquipPhantomItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
	}

	// Token: 0x060120A4 RID: 73892 RVA: 0x004F6761 File Offset: 0x004F4961
	private void OnResponsePhantomItem(Aki.Protocol.PhantomItem phantomItem)
	{
		ModelBase<PhantomBattleModel>.Instance.NewPhantomBattleData(phantomItem);
	}

	// Token: 0x060120A5 RID: 73893 RVA: 0x004F676F File Offset: 0x004F496F
	private void OnAddPhantomItem(Aki.Protocol.PhantomItem phantomItem)
	{
		ModelBase<PhantomBattleModel>.Instance.NewPhantomBattleData(phantomItem);
	}

	// Token: 0x060120A6 RID: 73894 RVA: 0x004F6780 File Offset: 0x004F4980
	private void OnRemovePhantomItem(IReadOnlyList<int> uniqueIdList)
	{
		foreach (int uniqueId in uniqueIdList)
		{
			ModelBase<PhantomBattleModel>.Instance.RemovePhantomBattleData(uniqueId);
		}
	}

	// Token: 0x060120A7 RID: 73895 RVA: 0x004F67CC File Offset: 0x004F49CC
	private void OnEquipPhantomItem(PhantomItemResponse equipInfoList)
	{
		foreach (RolePhantomEquipInfo data in equipInfoList.EquipInfo)
		{
			ModelBase<PhantomBattleModel>.Instance.UpdateRoleEquipmentData(data);
		}
		foreach (RolePhantomPropInfo data2 in equipInfoList.PropInfo)
		{
			ModelBase<PhantomBattleModel>.Instance.UpdateRoleEquipmentPropData(data2);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquip);
	}

	// Token: 0x060120A8 RID: 73896 RVA: 0x004F6870 File Offset: 0x004F4A70
	[NullableContext(2)]
	public PhantomBattleData GetPhantomItemDataByUniqueId(int uniqueId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
	}

	// Token: 0x060120A9 RID: 73897 RVA: 0x004F687D File Offset: 0x004F4A7D
	public void ChangeRoleEvent(int roleId)
	{
		ModelBase<PhantomBattleModel>.Instance.UpdateFetterList(roleId);
	}

	// Token: 0x060120AA RID: 73898 RVA: 0x004F688C File Offset: 0x004F4A8C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PhantomEquipInfoNotify>(ENotifyMessageId.PhantomEquipInfoNotify, new Action<PhantomEquipInfoNotify, Net.CallbackStatus>(this.OnPhantomEquipInfoNotify));
		Singleton<Net>.Instance.Register<PhantomItemUpdateNotify>(ENotifyMessageId.PhantomItemUpdateNotify, new Action<PhantomItemUpdateNotify, Net.CallbackStatus>(this.OnPhantomItemUpdate));
		Singleton<Net>.Instance.Register<RolePhantomPropUpdateNotify>(ENotifyMessageId.RolePhantomPropUpdateNotify, new Action<RolePhantomPropUpdateNotify, Net.CallbackStatus>(this.OnRolePhantomPropUpdateNotify));
		Singleton<Net>.Instance.Register<PhantomUpdateNotify>(ENotifyMessageId.PhantomUpdateNotify, new Action<PhantomUpdateNotify, Net.CallbackStatus>(this.OnPhantomUpdateNotify));
		Singleton<Net>.Instance.Register<PhantomSkinAddNotify>(ENotifyMessageId.PhantomSkinAddNotify, new Action<PhantomSkinAddNotify, Net.CallbackStatus>(this.PhantomSkinAddNotify));
		Singleton<Net>.Instance.Register<PhantomUnlockNotify>(ENotifyMessageId.PhantomUnlockNotify, new Action<PhantomUnlockNotify, Net.CallbackStatus>(this.PhantomUnlockNotify));
	}

	// Token: 0x060120AB RID: 73899 RVA: 0x004F6944 File Offset: 0x004F4B44
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomEquipInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomItemUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RolePhantomPropUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomSkinAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomUnlockNotify);
	}

	// Token: 0x060120AC RID: 73900 RVA: 0x004F69B4 File Offset: 0x004F4BB4
	public void SendPhantomLevelUpRequest(int incId, List<PhantomConsumeItem> consumeItem, int identifyCount)
	{
		PhantomLevelUpRequest phantomLevelUpRequest = PhantomLevelUpRequest.Create();
		phantomLevelUpRequest.IncId = incId;
		phantomLevelUpRequest.ConsumeList.AddRange(consumeItem);
		phantomLevelUpRequest.IdentifyCount = identifyCount;
		LevelUpPastVisionData data = ModelBase<PhantomBattleModel>.Instance.CreatePhantomLevelCacheData(incId);
		Singleton<Net>.Instance.Call<PhantomLevelUpResponse>(ERequestMessageId.PhantomLevelUpRequest, phantomLevelUpRequest, delegate(PhantomLevelUpResponse response, Net.CallbackStatus _)
		{
			PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24219, null, true, true);
				return;
			}
			instance.ResetLevelUpItemData();
			PhantomBattleData phantomItemDataByUniqueId = this.GetPhantomItemDataByUniqueId(response.UpdateInfo.IncrId);
			if (phantomItemDataByUniqueId == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "幻象升级返回，获取phantomBattleData异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			phantomItemDataByUniqueId.SetData(response.UpdateInfo);
			instance.PhantomLevelUpReceiveItem(response.ItemMap.ToDictionary<int, int>());
			instance.CachePhantomLevelUpData(data);
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomLevelUp);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PhantomLevelUpWithId, incId);
		}, 0);
	}

	// Token: 0x060120AD RID: 73901 RVA: 0x004F6A30 File Offset: 0x004F4C30
	public void TryShowReceiveItem()
	{
		TItem[] tempSaveItemList = ModelBase<PhantomBattleModel>.Instance.GetTempSaveItemList();
		if (tempSaveItemList.Length != 0)
		{
			List<RewardItemData> list = new List<RewardItemData>();
			foreach (TItem titem in tempSaveItemList)
			{
				InventoryDefine.IGetItemData itemData = titem.ItemData;
				int count = titem.Count;
				RewardItemData item = new RewardItemData(itemData.ItemId, count, new int?(itemData.IncId), EDropItemType.Normal);
				list.Add(item);
			}
			ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1008, list, null);
			ModelBase<PhantomBattleModel>.Instance.ClearTempSaveItemList();
		}
	}

	// Token: 0x060120AE RID: 73902 RVA: 0x004F6AB8 File Offset: 0x004F4CB8
	public void SendPhantomPutOnRequest(int incId, int roleId, int pos, int sourcePos = -1, bool fromDrag = false)
	{
		if (ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["幻象.Common.技能中"]))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
			return;
		}
		if (PhantomUtil.IsInVisionSkill())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
			return;
		}
		int getConfigId = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem.GetConfigId;
		int? phantomEquipOnRoleId = ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(incId);
		bool flag = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(incId);
		int roleIndexPhantomId = ModelBase<PhantomBattleModel>.Instance.GetRoleIndexPhantomId(roleId, pos);
		int? phantomEquipOnRoleId2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(roleIndexPhantomId);
		bool flag2 = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(roleIndexPhantomId);
		int num = getConfigId;
		int? num2 = phantomEquipOnRoleId;
		bool flag3;
		if (num == num2.GetValueOrDefault() & num2 != null)
		{
			num2 = phantomEquipOnRoleId;
			int num3 = 0;
			flag3 = (num2.GetValueOrDefault() > num3 & num2 != null);
		}
		else
		{
			flag3 = false;
		}
		if (!flag3 || !flag)
		{
			int num4 = getConfigId;
			num2 = phantomEquipOnRoleId2;
			bool flag4;
			if (num4 == num2.GetValueOrDefault() & num2 != null)
			{
				num2 = phantomEquipOnRoleId2;
				int num3 = 0;
				flag4 = (num2.GetValueOrDefault() > num3 & num2 != null);
			}
			else
			{
				flag4 = false;
			}
			if (!flag4 || !flag2)
			{
				goto IL_1C7;
			}
		}
		bool flag5 = false;
		int id = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Id;
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(Singleton<EntitySystem>.Instance.Get(id), ESummonType.ConcomitantVision, 1);
		if (summonedEntity != null && summonedEntity.Entity.Active)
		{
			flag5 = true;
		}
		if (flag5)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
			return;
		}
		IL_1C7:
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(true))
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
			return;
		}
		PhantomPutOnRequest phantomPutOnRequest = PhantomPutOnRequest.Create();
		phantomPutOnRequest.IncId = incId;
		phantomPutOnRequest.RoleId = roleId;
		phantomPutOnRequest.Pos = pos;
		Singleton<Net>.Instance.Call<PhantomPutOnResponse>(ERequestMessageId.PhantomPutOnRequest, phantomPutOnRequest, delegate(PhantomPutOnResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18225, null, true, true);
				Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
				return;
			}
			RepeatedField<RolePhantomEquipInfo> equipInfoList = response.EquipInfoList;
			if (equipInfoList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "角色幻象装备数据异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (RolePhantomEquipInfo rolePhantomEquipInfo in equipInfoList)
			{
				ModelBase<PhantomBattleModel>.Instance.UpdateRoleEquipmentData(rolePhantomEquipInfo);
				ModelBase<PhantomBattleModel>.Instance.UpdateFetterList(rolePhantomEquipInfo.RoleId);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquip);
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.PhantomEquipWithSourceAndTargetPos, sourcePos, pos, fromDrag);
		}, 0);
	}

	// Token: 0x060120AF RID: 73903 RVA: 0x004F6CEC File Offset: 0x004F4EEC
	public void SendPhantomAutoPutRequest(int roleId, List<int> uniqueIdList, [Nullable(2)] Action successCallBack = null)
	{
		if (ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["幻象.Common.技能中"]))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			return;
		}
		if (PhantomUtil.IsInVisionSkill())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			return;
		}
		bool flag = false;
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(Singleton<EntitySystem>.Instance.Get(ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Id), ESummonType.ConcomitantVision, 1);
		if (summonedEntity != null && summonedEntity.Entity.Active)
		{
			flag = true;
		}
		if (flag)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			return;
		}
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(true))
		{
			return;
		}
		PhantomAutoPutRequest phantomAutoPutRequest = PhantomAutoPutRequest.Create();
		phantomAutoPutRequest.RoleId = roleId;
		phantomAutoPutRequest.PhantomItemIncrId.AddRange(uniqueIdList);
		Singleton<Net>.Instance.Call<PhantomAutoPutResponse>(ERequestMessageId.PhantomAutoPutRequest, phantomAutoPutRequest, delegate(PhantomAutoPutResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24247, null, true, true);
				return;
			}
			RepeatedField<RolePhantomEquipInfo> equipInfoList = response.EquipInfoList;
			if (equipInfoList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "角色幻象装备数据异常!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (RolePhantomEquipInfo rolePhantomEquipInfo in equipInfoList)
			{
				ModelBase<PhantomBattleModel>.Instance.UpdateRoleEquipmentData(rolePhantomEquipInfo);
				ModelBase<PhantomBattleModel>.Instance.UpdateFetterList(rolePhantomEquipInfo.RoleId);
			}
			Action successCallBack2 = successCallBack;
			if (successCallBack2 != null)
			{
				successCallBack2();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquip);
			Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.PhantomEquipWithSourceAndTargetPos, 0, 0, false);
		}, 0);
	}

	// Token: 0x060120B0 RID: 73904 RVA: 0x004F6DF4 File Offset: 0x004F4FF4
	public void ApplyRecommendEquip(int roleId, List<int> uniqueIdList, Action onSuccess)
	{
		if (!ModelBase<PhantomBattleModel>.Instance.GetRoleIfEquipVision(roleId))
		{
			this.SendPhantomAutoPutRequest(roleId, uniqueIdList, onSuccess);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomSupplementTips);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			this.SendPhantomAutoPutRequest(roleId, uniqueIdList, onSuccess);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060120B1 RID: 73905 RVA: 0x004F6E7C File Offset: 0x004F507C
	private void OnRolePhantomPropUpdateNotify(RolePhantomPropUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (RolePhantomPropInfo rolePhantomPropInfo in response.PropInfo)
		{
			ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(rolePhantomPropInfo.RoleId).Phrase(rolePhantomPropInfo);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRolePropUpdate);
	}

	// Token: 0x060120B2 RID: 73906 RVA: 0x004F6EE8 File Offset: 0x004F50E8
	private void OnPhantomUpdateNotify(PhantomUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<PhantomBattleModel>.Instance.SetMaxCost(notify.TotalCost);
	}

	// Token: 0x060120B3 RID: 73907 RVA: 0x004F6EFC File Offset: 0x004F50FC
	private void PhantomUnlockNotify(PhantomUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify.UnlockQualityItemList.Count > 0)
		{
			ModelBase<PhantomBattleModel>.Instance.CacheNewQualityData(notify);
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.DoShowUnlockQualityView();
			}, (float)ConfigBase<CalabashConfig>.Instance.DelayTime, null, null, true, 1f);
			return;
		}
		foreach (int num in notify.UnlockMonsterItemList)
		{
			int qualityId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(num).Value.QualityId;
			ModelBase<CalabashModel>.Instance.AddCalabashUnlockTipsList(num, qualityId);
		}
		this.DoShowNewItemView();
	}

	// Token: 0x060120B4 RID: 73908 RVA: 0x004F6FB8 File Offset: 0x004F51B8
	private void PhantomSkinAddNotify(PhantomSkinAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<int> skinIds = notify.SkinIds;
		ModelBase<PhantomBattleModel>.Instance.ConcatUnlockSkinList(skinIds.ToList<int>());
		foreach (int num in skinIds)
		{
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.VisionSkin, num);
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.VisionSkin);
			ModelBase<PhantomBattleModel>.Instance.CacheNewSkinData(num);
		}
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.DoShowUnlockQualityView();
		}, (float)ConfigBase<CalabashConfig>.Instance.DelayTime, null, null, true, 1f);
	}

	// Token: 0x060120B5 RID: 73909 RVA: 0x004F7060 File Offset: 0x004F5260
	private void OnPhantomEquipInfoNotify(PhantomEquipInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<RolePhantomEquipInfo> equipInfo = notify.EquipInfo;
		if (equipInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "没有角色装备过幻象!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (RolePhantomEquipInfo data in equipInfo)
		{
			ModelBase<PhantomBattleModel>.Instance.UpdateRoleEquipmentData(data);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquip);
	}

	// Token: 0x060120B6 RID: 73910 RVA: 0x004F70E4 File Offset: 0x004F52E4
	private void OnPhantomItemUpdate(PhantomItemUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (Aki.Protocol.PhantomItem phantomItem in notify.UpdateInfo)
		{
			PhantomBattleData phantomItemDataByUniqueId = this.GetPhantomItemDataByUniqueId(phantomItem.IncrId);
			if (phantomItemDataByUniqueId != null)
			{
				phantomItemDataByUniqueId.UpdateData(phantomItem);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomItemUpdate);
	}

	// Token: 0x060120B7 RID: 73911 RVA: 0x004F7154 File Offset: 0x004F5354
	public UniTask RequestPhantomIdentify(int uniqueId, int count)
	{
		PhantomBattleController.<RequestPhantomIdentify>d__22 <RequestPhantomIdentify>d__;
		<RequestPhantomIdentify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestPhantomIdentify>d__.<>4__this = this;
		<RequestPhantomIdentify>d__.uniqueId = uniqueId;
		<RequestPhantomIdentify>d__.count = count;
		<RequestPhantomIdentify>d__.<>1__state = -1;
		<RequestPhantomIdentify>d__.<>t__builder.Start<PhantomBattleController.<RequestPhantomIdentify>d__22>(ref <RequestPhantomIdentify>d__);
		return <RequestPhantomIdentify>d__.<>t__builder.Task;
	}

	// Token: 0x060120B8 RID: 73912 RVA: 0x004F71A8 File Offset: 0x004F53A8
	public void PhantomSkinChangeRequest(int uniqueId, int skinId, bool changeDefault)
	{
		if (ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["幻象.Common.技能中"]))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
			return;
		}
		if (PhantomUtil.IsInVisionSkill())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquipError);
			return;
		}
		bool flag = false;
		int id = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Id;
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(Singleton<EntitySystem>.Instance.Get(id), ESummonType.ConcomitantVision, 1);
		if (summonedEntity != null && summonedEntity.Entity.Active)
		{
			flag = true;
		}
		if (flag)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("VisionSkilling", Array.Empty<object>());
			return;
		}
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTagAndShowTips(false))
		{
			return;
		}
		PhantomSkinChangeRequest phantomSkinChangeRequest = Aki.Protocol.PhantomSkinChangeRequest.Create();
		phantomSkinChangeRequest.IncrId = uniqueId;
		phantomSkinChangeRequest.SkinId = skinId;
		phantomSkinChangeRequest.ChangeDefault = changeDefault;
		Singleton<Net>.Instance.Call<PhantomSkinChangeResponse>(ERequestMessageId.PhantomSkinChangeRequest, phantomSkinChangeRequest, delegate(PhantomSkinChangeResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15410, null, true, true);
				return;
			}
			PhantomBattleData phantomItemDataByUniqueId = this.GetPhantomItemDataByUniqueId(uniqueId);
			if (phantomItemDataByUniqueId != null)
			{
				phantomItemDataByUniqueId.SetSkinId(skinId);
			}
			if (changeDefault)
			{
				ModelBase<PhantomBattleModel>.Instance.SetDefaultSkin(phantomItemDataByUniqueId.GetConfig().MonsterId, skinId);
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomSkinUse", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionSkinEquip);
		}, 0);
	}

	// Token: 0x060120B9 RID: 73913 RVA: 0x004F72FC File Offset: 0x004F54FC
	public void RequestForTraceMonster(int monsterId)
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
			return;
		}
		MonsterDetectionRecord monsterDetectionRecord;
		if (ModelBase<AdventureGuideModel>.Instance.GetAllDetectMonsters().TryGetValue(monsterId, out monsterDetectionRecord))
		{
			int[] array = ControllerBase<AdventureGuideController>.Instance.GetValidMonsterEntityIdsOfDetectConf(monsterDetectionRecord.Conf);
			if (array.Length == 0)
			{
				int entityConfigId = monsterDetectionRecord.Conf.EntityConfigId;
				if (entityConfigId == 0)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NoMonster", Array.Empty<object>());
					return;
				}
				array = new int[]
				{
					entityConfigId
				};
			}
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.NormalMonster, array, monsterId);
		}
	}

	// Token: 0x060120BA RID: 73914 RVA: 0x004F73A0 File Offset: 0x004F55A0
	[NullableContext(2)]
	public UniTask OpenPhantomBattleFetterView(int selectedGroupId, int roleId, bool showFastFilter = true, List<int> recommendGroupIds = null)
	{
		PhantomBattleController.<OpenPhantomBattleFetterView>d__25 <OpenPhantomBattleFetterView>d__;
		<OpenPhantomBattleFetterView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenPhantomBattleFetterView>d__.selectedGroupId = selectedGroupId;
		<OpenPhantomBattleFetterView>d__.roleId = roleId;
		<OpenPhantomBattleFetterView>d__.showFastFilter = showFastFilter;
		<OpenPhantomBattleFetterView>d__.recommendGroupIds = recommendGroupIds;
		<OpenPhantomBattleFetterView>d__.<>1__state = -1;
		<OpenPhantomBattleFetterView>d__.<>t__builder.Start<PhantomBattleController.<OpenPhantomBattleFetterView>d__25>(ref <OpenPhantomBattleFetterView>d__);
		return <OpenPhantomBattleFetterView>d__.<>t__builder.Task;
	}

	// Token: 0x060120BB RID: 73915 RVA: 0x004F73FC File Offset: 0x004F55FC
	private void OnActiveBattleView()
	{
		if (ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList.Count > 0)
		{
			this.DoShowUnlockQualityView();
		}
		if (ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList.Count > 0)
		{
			this.DoShowNewItemView();
		}
	}

	// Token: 0x060120BC RID: 73916 RVA: 0x004F7430 File Offset: 0x004F5630
	private void DoShowUnlockQualityView()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CalabashUnlockItemView) && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView) && !ModelBase<SundryModel>.Instance.IsBlockTips && ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList.Count > 0)
		{
			VisionUnlockQualityData param = ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList[0];
			ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList.RemoveAt(0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashUnlockItemView, param, null);
		}
	}

	// Token: 0x060120BD RID: 73917 RVA: 0x004F74B0 File Offset: 0x004F56B0
	private void DoShowNewItemView()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CalabashUnlockItemView) && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView) && !ModelBase<SundryModel>.Instance.IsBlockTips && ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList.Count > 0)
		{
			VisionUnlockQualityData param = ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList[0];
			ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList.RemoveAt(0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashUnlockItemView, param, null);
		}
	}

	// Token: 0x060120BE RID: 73918 RVA: 0x004F752F File Offset: 0x004F572F
	public bool CheckIsEquip(int uniqueId)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsEquip(uniqueId);
	}

	// Token: 0x060120BF RID: 73919 RVA: 0x004F753C File Offset: 0x004F573C
	public bool CheckIsEquipByMonsterId(int monsterId, int roleId)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckMonsterIsEquipOnRole(roleId, monsterId);
	}

	// Token: 0x060120C0 RID: 73920 RVA: 0x004F754A File Offset: 0x004F574A
	public bool CheckIsMain(int id)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(id);
	}

	// Token: 0x060120C1 RID: 73921 RVA: 0x004F7557 File Offset: 0x004F5757
	public bool CheckIsSub(int id)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsSub(id);
	}

	// Token: 0x060120C2 RID: 73922 RVA: 0x004F7564 File Offset: 0x004F5764
	public bool CheckFetterActivate(int fettersId, int roleId)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckFetterActiveState(roleId, fettersId);
	}

	// Token: 0x060120C3 RID: 73923 RVA: 0x004F7572 File Offset: 0x004F5772
	public bool CheckPhantomIsUnlock(int monsterId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomIsUnlock(monsterId);
	}

	// Token: 0x060120C4 RID: 73924 RVA: 0x004F757F File Offset: 0x004F577F
	public int? GetEquipRole(int uniqueId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(uniqueId);
	}

	// Token: 0x060120C5 RID: 73925 RVA: 0x004F758C File Offset: 0x004F578C
	public void SetMeshShow(int itemId, [Nullable(2)] Action callBack, SkeletalObserverHandle observer, bool isChangeLocation = true)
	{
		PhantomBattleController.<>c__DisplayClass36_0 CS$<>8__locals1 = new PhantomBattleController.<>c__DisplayClass36_0();
		CS$<>8__locals1.itemId = itemId;
		CS$<>8__locals1.callBack = callBack;
		UiModelBase model = observer.Model;
		CS$<>8__locals1.phantomInstance = ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(CS$<>8__locals1.itemId);
		int meshId = CS$<>8__locals1.phantomInstance.PhantomItem.Value.MeshId;
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		if (uiModelDataComponent != null && uiModelDataComponent.ModelConfigId == meshId)
		{
			if (uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete)
			{
				Action callBack2 = CS$<>8__locals1.callBack;
				if (callBack2 == null)
				{
					return;
				}
				callBack2();
			}
			return;
		}
		if (ConfigBase<SkeletalObserverConfig>.Instance.GetMeshConfig(meshId) == null)
		{
			return;
		}
		CS$<>8__locals1.actorComponent = model.CheckGetComponent<UiModelActorComponent>();
		CS$<>8__locals1.animationComponent = model.CheckGetComponent<UiModelAnimationComponent>();
		CS$<>8__locals1.animationComponent.StopAnimation();
		if (isChangeLocation)
		{
			this.SetMeshTransform(observer);
		}
		CS$<>8__locals1.loadComponent = model.CheckGetComponent<UiModelLoadComponent>();
		CS$<>8__locals1.animationComponent.SetAnimationMode(EAnimationMode.AnimationSingleNode);
		string standAnim = ModelBase<PhantomBattleModel>.Instance.GetStandAnim(CS$<>8__locals1.itemId);
		Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(standAnim, delegate([Nullable(2)] UAnimationAsset result, string _)
		{
			if (result != null)
			{
				CS$<>8__locals1.loadComponent.LoadModelByModelId(CS$<>8__locals1.phantomInstance.PhantomItem.Value.MeshId, true, delegate
				{
					CS$<>8__locals1.<SetMeshShow>g__LoadFinishCallBack|0(result);
				}, null);
			}
		}, 100, "Ui.PhantomUi");
	}

	// Token: 0x060120C6 RID: 73926 RVA: 0x004F76A1 File Offset: 0x004F58A1
	public void SetMeshTransform(SkeletalObserverHandle observer)
	{
		observer.Model.CheckGetComponent<UiModelActorComponent>().SetTransformByTag("MonsterCase");
	}

	// Token: 0x060120C7 RID: 73927 RVA: 0x004F76B8 File Offset: 0x004F58B8
	public EEquipType GetEquipState(int roleId, int index, int uniqueId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetRolePhantomEquipState(roleId, index, uniqueId);
	}

	// Token: 0x060120C8 RID: 73928 RVA: 0x004F76C7 File Offset: 0x004F58C7
	public int GetEquipByIndex(int roleId, int index)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetRoleIndexPhantomId(roleId, index);
	}

	// Token: 0x060120C9 RID: 73929 RVA: 0x004F76D5 File Offset: 0x004F58D5
	public List<ItemInfo> GetLevelUpItemList(int uniqueId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomLevelUpItemSortList(uniqueId).ToList<ItemInfo>();
	}

	// Token: 0x060120CA RID: 73930 RVA: 0x004F76E7 File Offset: 0x004F58E7
	public int GetLevelUpNeedCost(int exp)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetLevelUpNeedCost(exp);
	}

	// Token: 0x060120CB RID: 73931 RVA: 0x004F76F4 File Offset: 0x004F58F4
	public int GetMaxLevel(int uniqueId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomMaxLevel(uniqueId);
	}

	// Token: 0x060120CC RID: 73932 RVA: 0x004F7701 File Offset: 0x004F5901
	public bool CheckPhantomLevelSatisfied(int itemId, int level)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckIfHasPhantomSatisfiedLevelCondition(itemId, level);
	}

	// Token: 0x060120CD RID: 73933 RVA: 0x004F770F File Offset: 0x004F590F
	public bool CheckHasPhantomMaxLevel()
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckIfHasPhantomLevelMax();
	}

	// Token: 0x060120CE RID: 73934 RVA: 0x004F771C File Offset: 0x004F591C
	[NullableContext(0)]
	public UniTask<double> GetProgressCurveValue(float progress, double startPosition, double targetPosition)
	{
		PhantomBattleController.<GetProgressCurveValue>d__45 <GetProgressCurveValue>d__;
		<GetProgressCurveValue>d__.<>t__builder = AsyncUniTaskMethodBuilder<double>.Create();
		<GetProgressCurveValue>d__.progress = progress;
		<GetProgressCurveValue>d__.startPosition = startPosition;
		<GetProgressCurveValue>d__.targetPosition = targetPosition;
		<GetProgressCurveValue>d__.<>1__state = -1;
		<GetProgressCurveValue>d__.<>t__builder.Start<PhantomBattleController.<GetProgressCurveValue>d__45>(ref <GetProgressCurveValue>d__);
		return <GetProgressCurveValue>d__.<>t__builder.Task;
	}

	// Token: 0x060120CF RID: 73935 RVA: 0x004F776F File Offset: 0x004F596F
	public void RecordVisionLevelUpSettingRedDot()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.VisionLevelUpSettingRedDot, true);
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.VisionLevelUpIdentifyRedDot, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshVisionLevelUpSettingRedPoint);
	}

	// Token: 0x060120D0 RID: 73936 RVA: 0x004F7794 File Offset: 0x004F5994
	[NullableContext(0)]
	public UniTask<bool> RequestPhBaPlanUsePlan()
	{
		PhantomBattleController.<RequestPhBaPlanUsePlan>d__47 <RequestPhBaPlanUsePlan>d__;
		<RequestPhBaPlanUsePlan>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPhBaPlanUsePlan>d__.<>1__state = -1;
		<RequestPhBaPlanUsePlan>d__.<>t__builder.Start<PhantomBattleController.<RequestPhBaPlanUsePlan>d__47>(ref <RequestPhBaPlanUsePlan>d__);
		return <RequestPhBaPlanUsePlan>d__.<>t__builder.Task;
	}

	// Token: 0x060120D1 RID: 73937 RVA: 0x004F77D0 File Offset: 0x004F59D0
	[NullableContext(0)]
	public UniTask<bool> RequestPhBaPlanSaveUsePlan(bool isReset, [Nullable(1)] HashSet<int> openIdSet)
	{
		PhantomBattleController.<RequestPhBaPlanSaveUsePlan>d__48 <RequestPhBaPlanSaveUsePlan>d__;
		<RequestPhBaPlanSaveUsePlan>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPhBaPlanSaveUsePlan>d__.<>4__this = this;
		<RequestPhBaPlanSaveUsePlan>d__.isReset = isReset;
		<RequestPhBaPlanSaveUsePlan>d__.openIdSet = openIdSet;
		<RequestPhBaPlanSaveUsePlan>d__.<>1__state = -1;
		<RequestPhBaPlanSaveUsePlan>d__.<>t__builder.Start<PhantomBattleController.<RequestPhBaPlanSaveUsePlan>d__48>(ref <RequestPhBaPlanSaveUsePlan>d__);
		return <RequestPhBaPlanSaveUsePlan>d__.<>t__builder.Task;
	}

	// Token: 0x060120D2 RID: 73938 RVA: 0x004F7824 File Offset: 0x004F5A24
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<PhBaPlanFindPlanResponse> RequestPhBaPlanFindPlan(string code)
	{
		PhantomBattleController.<RequestPhBaPlanFindPlan>d__49 <RequestPhBaPlanFindPlan>d__;
		<RequestPhBaPlanFindPlan>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhBaPlanFindPlanResponse>.Create();
		<RequestPhBaPlanFindPlan>d__.code = code;
		<RequestPhBaPlanFindPlan>d__.<>1__state = -1;
		<RequestPhBaPlanFindPlan>d__.<>t__builder.Start<PhantomBattleController.<RequestPhBaPlanFindPlan>d__49>(ref <RequestPhBaPlanFindPlan>d__);
		return <RequestPhBaPlanFindPlan>d__.<>t__builder.Task;
	}

	// Token: 0x060120D3 RID: 73939 RVA: 0x004F7868 File Offset: 0x004F5A68
	[NullableContext(0)]
	public UniTask<bool> RequestPhBaPlanUpdatePlan()
	{
		PhantomBattleController.<RequestPhBaPlanUpdatePlan>d__50 <RequestPhBaPlanUpdatePlan>d__;
		<RequestPhBaPlanUpdatePlan>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPhBaPlanUpdatePlan>d__.<>1__state = -1;
		<RequestPhBaPlanUpdatePlan>d__.<>t__builder.Start<PhantomBattleController.<RequestPhBaPlanUpdatePlan>d__50>(ref <RequestPhBaPlanUpdatePlan>d__);
		return <RequestPhBaPlanUpdatePlan>d__.<>t__builder.Task;
	}

	// Token: 0x060120D4 RID: 73940 RVA: 0x004F78A4 File Offset: 0x004F5AA4
	[NullableContext(0)]
	public UniTask<bool> RequestPhBaPlanSetFiveStarSwitch()
	{
		PhantomBattleController.<RequestPhBaPlanSetFiveStarSwitch>d__51 <RequestPhBaPlanSetFiveStarSwitch>d__;
		<RequestPhBaPlanSetFiveStarSwitch>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPhBaPlanSetFiveStarSwitch>d__.<>1__state = -1;
		<RequestPhBaPlanSetFiveStarSwitch>d__.<>t__builder.Start<PhantomBattleController.<RequestPhBaPlanSetFiveStarSwitch>d__51>(ref <RequestPhBaPlanSetFiveStarSwitch>d__);
		return <RequestPhBaPlanSetFiveStarSwitch>d__.<>t__builder.Task;
	}

	// Token: 0x060120D5 RID: 73941 RVA: 0x004F78E0 File Offset: 0x004F5AE0
	[NullableContext(0)]
	public UniTask<bool> RequestPhBaPlanSetPlanStatus([Nullable(1)] List<int> fetterIdList, bool isOpen)
	{
		PhantomBattleController.<RequestPhBaPlanSetPlanStatus>d__52 <RequestPhBaPlanSetPlanStatus>d__;
		<RequestPhBaPlanSetPlanStatus>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestPhBaPlanSetPlanStatus>d__.fetterIdList = fetterIdList;
		<RequestPhBaPlanSetPlanStatus>d__.isOpen = isOpen;
		<RequestPhBaPlanSetPlanStatus>d__.<>1__state = -1;
		<RequestPhBaPlanSetPlanStatus>d__.<>t__builder.Start<PhantomBattleController.<RequestPhBaPlanSetPlanStatus>d__52>(ref <RequestPhBaPlanSetPlanStatus>d__);
		return <RequestPhBaPlanSetPlanStatus>d__.<>t__builder.Task;
	}
}
