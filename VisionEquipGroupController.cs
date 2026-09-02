using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200249B RID: 9371
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class VisionEquipGroupController : UiControllerBase<VisionEquipGroupController>
{
	// Token: 0x060122EB RID: 74475 RVA: 0x00500966 File Offset: 0x004FEB66
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x060122EC RID: 74476 RVA: 0x00500984 File Offset: 0x004FEB84
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x060122ED RID: 74477 RVA: 0x005009A2 File Offset: 0x004FEBA2
	private void OnDataDone()
	{
		this.RequestVisionEquipGroupInfo();
	}

	// Token: 0x060122EE RID: 74478 RVA: 0x005009AC File Offset: 0x004FEBAC
	public UniTask RequestVisionEquipGroupInfo()
	{
		VisionEquipGroupController.<RequestVisionEquipGroupInfo>d__3 <RequestVisionEquipGroupInfo>d__;
		<RequestVisionEquipGroupInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestVisionEquipGroupInfo>d__.<>1__state = -1;
		<RequestVisionEquipGroupInfo>d__.<>t__builder.Start<VisionEquipGroupController.<RequestVisionEquipGroupInfo>d__3>(ref <RequestVisionEquipGroupInfo>d__);
		return <RequestVisionEquipGroupInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060122EF RID: 74479 RVA: 0x005009E8 File Offset: 0x004FEBE8
	public UniTask<ErrorCode> RequestAddVisionEquipGroup(int roleId, [Nullable(1)] string name)
	{
		VisionEquipGroupController.<RequestAddVisionEquipGroup>d__4 <RequestAddVisionEquipGroup>d__;
		<RequestAddVisionEquipGroup>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode>.Create();
		<RequestAddVisionEquipGroup>d__.roleId = roleId;
		<RequestAddVisionEquipGroup>d__.name = name;
		<RequestAddVisionEquipGroup>d__.<>1__state = -1;
		<RequestAddVisionEquipGroup>d__.<>t__builder.Start<VisionEquipGroupController.<RequestAddVisionEquipGroup>d__4>(ref <RequestAddVisionEquipGroup>d__);
		return <RequestAddVisionEquipGroup>d__.<>t__builder.Task;
	}

	// Token: 0x060122F0 RID: 74480 RVA: 0x00500A34 File Offset: 0x004FEC34
	public void RequestDeleteVisionEquipGroup(int index)
	{
		DeletePhantomEquipGroupRequest deletePhantomEquipGroupRequest = DeletePhantomEquipGroupRequest.Create();
		deletePhantomEquipGroupRequest.Index = index;
		Singleton<Net>.Instance.Call<DeletePhantomEquipGroupResponse>(ERequestMessageId.DeletePhantomEquipGroupRequest, deletePhantomEquipGroupRequest, delegate(DeletePhantomEquipGroupResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26003, null, true, true);
				return;
			}
			ModelBase<VisionEquipGroupModel>.Instance.RefreshVisionEquipGroupData(response.PhantomEquipGroupInfos.ToList<PhantomEquipGroupInfo>());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionGroupDataDelete);
		}, 0);
	}

	// Token: 0x060122F1 RID: 74481 RVA: 0x00500A80 File Offset: 0x004FEC80
	public void RequestPutVisionGroupToTop(int index)
	{
		if (index == 0)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionGroupDataToTop);
			return;
		}
		TopPhantomEquipGroupRequest topPhantomEquipGroupRequest = TopPhantomEquipGroupRequest.Create();
		topPhantomEquipGroupRequest.Index = index;
		Singleton<Net>.Instance.Call<TopPhantomEquipGroupResponse>(ERequestMessageId.TopPhantomEquipGroupRequest, topPhantomEquipGroupRequest, delegate(TopPhantomEquipGroupResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18781, null, true, true);
				return;
			}
			ModelBase<VisionEquipGroupModel>.Instance.RefreshVisionEquipGroupData(response.PhantomEquipGroupInfos.ToList<PhantomEquipGroupInfo>());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionGroupDataToTop);
		}, 0);
	}

	// Token: 0x060122F2 RID: 74482 RVA: 0x00500AE0 File Offset: 0x004FECE0
	public UniTask<ErrorCode> RequestChangeVisionGroupName(int index, [Nullable(1)] string name)
	{
		VisionEquipGroupController.<RequestChangeVisionGroupName>d__7 <RequestChangeVisionGroupName>d__;
		<RequestChangeVisionGroupName>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode>.Create();
		<RequestChangeVisionGroupName>d__.index = index;
		<RequestChangeVisionGroupName>d__.name = name;
		<RequestChangeVisionGroupName>d__.<>1__state = -1;
		<RequestChangeVisionGroupName>d__.<>t__builder.Start<VisionEquipGroupController.<RequestChangeVisionGroupName>d__7>(ref <RequestChangeVisionGroupName>d__);
		return <RequestChangeVisionGroupName>d__.<>t__builder.Task;
	}

	// Token: 0x060122F3 RID: 74483 RVA: 0x00500B2C File Offset: 0x004FED2C
	public void RequestApplyVisionGroup(int index, int roleId)
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
		UsePhantomEquipGroupRequest usePhantomEquipGroupRequest = UsePhantomEquipGroupRequest.Create();
		usePhantomEquipGroupRequest.Index = index;
		usePhantomEquipGroupRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<UsePhantomEquipGroupResponse>(ERequestMessageId.UsePhantomEquipGroupRequest, usePhantomEquipGroupRequest, delegate(UsePhantomEquipGroupResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20670, null, true, true);
				return;
			}
			foreach (RolePhantomEquipInfo rolePhantomEquipInfo in response.EquipInfoList)
			{
				ModelBase<PhantomBattleModel>.Instance.UpdateRoleEquipmentData(rolePhantomEquipInfo);
				ModelBase<PhantomBattleModel>.Instance.UpdateFetterList(rolePhantomEquipInfo.RoleId);
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VisionAssembleHasUseTips", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.PhantomEquip);
		}, 0);
	}
}
