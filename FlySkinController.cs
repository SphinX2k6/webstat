using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x02002A4E RID: 10830
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FlySkinController : UiControllerBase<FlySkinController>
{
	// Token: 0x06015B23 RID: 88867 RVA: 0x00605B6C File Offset: 0x00603D6C
	protected override void OnAddEvents()
	{
	}

	// Token: 0x06015B24 RID: 88868 RVA: 0x00605B6E File Offset: 0x00603D6E
	protected override void OnRemoveEvents()
	{
	}

	// Token: 0x06015B25 RID: 88869 RVA: 0x00605B70 File Offset: 0x00603D70
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RoleFlyEquipNotify>(ENotifyMessageId.RoleFlyEquipNotify, new Action<RoleFlyEquipNotify, Net.CallbackStatus>(this.OnRoleFlyEquipNotify));
		Singleton<Net>.Instance.Register<RoleFlyEquipChangeNotify>(ENotifyMessageId.RoleFlyEquipChangeNotify, new Action<RoleFlyEquipChangeNotify, Net.CallbackStatus>(this.OnRoleFlyEquipChangeNotify));
		Singleton<Net>.Instance.Register<FlyEquipAddNotify>(ENotifyMessageId.FlyEquipAddNotify, new Action<FlyEquipAddNotify, Net.CallbackStatus>(this.OnFlyEquipAddNotifyNotify));
	}

	// Token: 0x06015B26 RID: 88870 RVA: 0x00605BD1 File Offset: 0x00603DD1
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFlyEquipNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleFlyEquipChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlyEquipAddNotify);
	}

	// Token: 0x06015B27 RID: 88871 RVA: 0x00605C04 File Offset: 0x00603E04
	private void OnRoleFlyEquipNotify(RoleFlyEquipNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify == null)
		{
			return;
		}
		ModelBase<FlySkinModel>.Instance.UpdateFlySkinEquipDataList(notify.DataList);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleFlyEquipNotify);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFlySkinTabRedDot);
		Singleton<EventSystem>.Instance.Emit<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, EFlySkinType.Paragliding);
		Singleton<EventSystem>.Instance.Emit<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, EFlySkinType.SoarWing);
	}

	// Token: 0x06015B28 RID: 88872 RVA: 0x00605C68 File Offset: 0x00603E68
	private void OnRoleFlyEquipChangeNotify(RoleFlyEquipChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify == null)
		{
			return;
		}
		RepeatedField<RoleFlySkinChange> skinChanges = notify.SkinChanges;
		foreach (RoleFlySkinChange roleFlySkinChange in skinChanges)
		{
			ModelBase<FlySkinModel>.Instance.EquipFlySkin(roleFlySkinChange.RoleId, roleFlySkinChange.SkinId);
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<RoleFlySkinChange>>(EEventName.OnRoleFlyEquipChangeNotify, skinChanges);
	}

	// Token: 0x06015B29 RID: 88873 RVA: 0x00605CDC File Offset: 0x00603EDC
	private void OnFlyEquipAddNotifyNotify(FlyEquipAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify == null)
		{
			return;
		}
		RepeatedField<int> flySkins = notify.FlySkins;
		foreach (int skinId in flySkins)
		{
			ModelBase<FlySkinModel>.Instance.AddUnlockSkinId(skinId);
		}
		this.UpdateAllRoleSkinRedDot();
		Singleton<EventSystem>.Instance.Emit<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, EFlySkinType.Paragliding);
		Singleton<EventSystem>.Instance.Emit<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, EFlySkinType.SoarWing);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnFlyEquipAddNotify, flySkins);
	}

	// Token: 0x06015B2A RID: 88874 RVA: 0x00605D6C File Offset: 0x00603F6C
	public void FlySkinWearRequest(int roleDataId, int skinId)
	{
		if (!ControllerBase<SkinController>.Instance.CheckCanWearSkinAndShowTip())
		{
			return;
		}
		FlySkinWearRequest flySkinWearRequest = Aki.Protocol.FlySkinWearRequest.Create();
		flySkinWearRequest.RoleId = roleDataId;
		flySkinWearRequest.SkinId = skinId;
		Singleton<Net>.Instance.Call<FlySkinWearResponse>(ERequestMessageId.FlySkinWearRequest, flySkinWearRequest, delegate(FlySkinWearResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<FlySkinModel>.Instance.EquipFlySkin(roleDataId, skinId);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnFlySkinEquipResponse, roleDataId, skinId);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FlySkinReplaceTip", Array.Empty<object>());
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28448, null, true, true);
		}, 0);
	}

	// Token: 0x06015B2B RID: 88875 RVA: 0x00605DD8 File Offset: 0x00603FD8
	public void FlySkinWearAllRoleRequest(int skinId)
	{
		if (!ControllerBase<SkinController>.Instance.CheckCanWearSkinAndShowTip())
		{
			return;
		}
		FlySkinWearAllRoleRequest flySkinWearAllRoleRequest = Aki.Protocol.FlySkinWearAllRoleRequest.Create();
		flySkinWearAllRoleRequest.SkinId = skinId;
		Singleton<Net>.Instance.Call<FlySkinWearAllRoleResponse>(ERequestMessageId.FlySkinWearAllRoleRequest, flySkinWearAllRoleRequest, delegate(FlySkinWearAllRoleResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				RepeatedField<RoleFlySkinChange> skinChanges = response.SkinChanges;
				foreach (RoleFlySkinChange roleFlySkinChange in skinChanges)
				{
					ModelBase<FlySkinModel>.Instance.EquipFlySkin(roleFlySkinChange.RoleId, roleFlySkinChange.SkinId);
				}
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<RoleFlySkinChange>>(EEventName.OnFlySkinEquipToAllRoleResponse, skinChanges);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26368, null, true, true);
		}, 0);
	}

	// Token: 0x06015B2C RID: 88876 RVA: 0x00605E30 File Offset: 0x00604030
	public void FlySkinUnLoadRequest(int roleDataId, int skinId)
	{
		if (!ControllerBase<SkinController>.Instance.CheckCanWearSkinAndShowTip())
		{
			return;
		}
		FlySkinUnLoadRequest flySkinUnLoadRequest = Aki.Protocol.FlySkinUnLoadRequest.Create();
		flySkinUnLoadRequest.RoleId = roleDataId;
		flySkinUnLoadRequest.SkinId = skinId;
		Singleton<Net>.Instance.Call<FlySkinUnLoadResponse>(ERequestMessageId.FlySkinUnLoadRequest, flySkinUnLoadRequest, delegate(FlySkinUnLoadResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<FlySkinModel>.Instance.UnLoadRoleFlySkinBySkinId(roleDataId, skinId);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnFlySkinUnLoadResponse, roleDataId, skinId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16064, null, true, true);
		}, 0);
	}

	// Token: 0x06015B2D RID: 88877 RVA: 0x00605E9C File Offset: 0x0060409C
	public void FlySkinAllUnLoadRequest(EFlySkinType skinType)
	{
		if (!ControllerBase<SkinController>.Instance.CheckCanWearSkinAndShowTip())
		{
			return;
		}
		FlySkinAllUnLoadRequest flySkinAllUnLoadRequest = Aki.Protocol.FlySkinAllUnLoadRequest.Create();
		flySkinAllUnLoadRequest.SkinType = (int)skinType;
		Singleton<Net>.Instance.Call<FlySkinAllUnLoadResponse>(ERequestMessageId.FlySkinAllUnLoadRequest, flySkinAllUnLoadRequest, delegate(FlySkinAllUnLoadResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				foreach (int roleDataId in response.UnLoadSkinRoles)
				{
					ModelBase<FlySkinModel>.Instance.UnLoadRoleFlySkinBySkinType(roleDataId, skinType);
				}
				Singleton<EventSystem>.Instance.Emit<EFlySkinType>(EEventName.OnFlySkinAllUnLoadResponse, skinType);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16064, null, true, true);
		}, 0);
	}

	// Token: 0x06015B2E RID: 88878 RVA: 0x00605EF2 File Offset: 0x006040F2
	public void UpdateAllRoleSkinRedDot()
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(ERedDotName.RoleSkin);
		if (redDot == null)
		{
			return;
		}
		redDot.UpdateAllRedDotData();
	}
}
