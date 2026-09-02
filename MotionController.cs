using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002285 RID: 8837
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MotionController : ControllerBase<MotionController>
{
	// Token: 0x06010B42 RID: 68418 RVA: 0x00493097 File Offset: 0x00491297
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x06010B43 RID: 68419 RVA: 0x004930A6 File Offset: 0x004912A6
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x06010B44 RID: 68420 RVA: 0x004930B5 File Offset: 0x004912B5
	protected void OnAddEvents()
	{
	}

	// Token: 0x06010B45 RID: 68421 RVA: 0x004930B7 File Offset: 0x004912B7
	protected void OnRemoveEvents()
	{
	}

	// Token: 0x06010B46 RID: 68422 RVA: 0x004930BC File Offset: 0x004912BC
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RoleMotionNewCanUnLockNotify>(ENotifyMessageId.RoleMotionNewCanUnLockNotify, new Action<RoleMotionNewCanUnLockNotify, Net.CallbackStatus>(this.OnRoleMotionNewCanUnLockNotify));
		Singleton<Net>.Instance.Register<RoleMotionActiveNotify>(ENotifyMessageId.RoleMotionActiveNotify, new Action<RoleMotionActiveNotify, Net.CallbackStatus>(this.OnRoleMotionActiveNotify));
		Singleton<Net>.Instance.Register<RoleMotionListNotify>(ENotifyMessageId.RoleMotionListNotify, new Action<RoleMotionListNotify, Net.CallbackStatus>(this.OnRoleMotionListNotify));
		Singleton<Net>.Instance.Register<RoleMotionFinishConditionNotify>(ENotifyMessageId.RoleMotionFinishConditionNotify, new Action<RoleMotionFinishConditionNotify, Net.CallbackStatus>(this.OnRoleMotionFinishConditionNotify));
	}

	// Token: 0x06010B47 RID: 68423 RVA: 0x0049313C File Offset: 0x0049133C
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleMotionNewCanUnLockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleMotionActiveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleMotionListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleMotionFinishConditionNotify);
	}

	// Token: 0x06010B48 RID: 68424 RVA: 0x0049318C File Offset: 0x0049138C
	public void RequestUnlockMotion(int roleId, int motionId)
	{
		RoleMotionUnLockRequest roleMotionUnLockRequest = RoleMotionUnLockRequest.Create();
		roleMotionUnLockRequest.RoleId = roleId;
		roleMotionUnLockRequest.UnLockId = motionId;
		Singleton<Net>.Instance.Call<RoleMotionUnLockResponse>(ERequestMessageId.RoleMotionUnLockRequest, roleMotionUnLockRequest, delegate(RoleMotionUnLockResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 26087, null, true, true);
				return;
			}
			ModelBase<MotionModel>.Instance.OnMotionUnlock(response.RoleId, response.UnLockId);
		}, 0);
	}

	// Token: 0x06010B49 RID: 68425 RVA: 0x004931DD File Offset: 0x004913DD
	private void OnRoleMotionNewCanUnLockNotify(RoleMotionNewCanUnLockNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<MotionModel>.Instance.OnNewMotionCanUnlock(message.RoleId, message.CanUnLockId);
	}

	// Token: 0x06010B4A RID: 68426 RVA: 0x004931F5 File Offset: 0x004913F5
	private void OnRoleMotionActiveNotify(RoleMotionActiveNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<MotionModel>.Instance.OnRoleMotionActive(message);
	}

	// Token: 0x06010B4B RID: 68427 RVA: 0x00493202 File Offset: 0x00491402
	private void OnRoleMotionListNotify(RoleMotionListNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<MotionModel>.Instance.OnGetAllRoleMotionInfo(message);
	}

	// Token: 0x06010B4C RID: 68428 RVA: 0x0049320F File Offset: 0x0049140F
	private void OnRoleMotionFinishConditionNotify(RoleMotionFinishConditionNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<MotionModel>.Instance.OnMotionFinishCondition(message);
	}
}
