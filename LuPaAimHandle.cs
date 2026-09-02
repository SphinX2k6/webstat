using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;

// Token: 0x02001F94 RID: 8084
[NullableContext(2)]
[Nullable(0)]
public class LuPaAimHandle : HudUnitHandleBase
{
	// Token: 0x0600F295 RID: 62101 RVA: 0x00424946 File Offset: 0x00422B46
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.TryActivate();
	}

	// Token: 0x0600F296 RID: 62102 RVA: 0x00424954 File Offset: 0x00422B54
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add<EntityHandle>(EEventName.SpecialSkillLuPaSwitchLockTarget, new Action<EntityHandle>(this.OnSwitchLockTarget));
	}

	// Token: 0x0600F297 RID: 62103 RVA: 0x0042498B File Offset: 0x00422B8B
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove<EntityHandle>(EEventName.SpecialSkillLuPaSwitchLockTarget, new Action<EntityHandle>(this.OnSwitchLockTarget));
	}

	// Token: 0x0600F298 RID: 62104 RVA: 0x004249C2 File Offset: 0x00422BC2
	private void OnChangeRole(int newEntityId, int oldEntityId)
	{
		this.TryActivate();
	}

	// Token: 0x0600F299 RID: 62105 RVA: 0x004249CA File Offset: 0x00422BCA
	private void OnSwitchLockTarget(EntityHandle target)
	{
		this.LockTarget = target;
		this.RefreshLockState();
	}

	// Token: 0x0600F29A RID: 62106 RVA: 0x004249D9 File Offset: 0x00422BD9
	private void RefreshAimVisible()
	{
		if (this.AimUnit == null)
		{
			return;
		}
		this.AimUnit.SetTargetVisible(this.IsAiming);
	}

	// Token: 0x0600F29B RID: 62107 RVA: 0x004249F5 File Offset: 0x00422BF5
	private void RefreshLockState()
	{
		if (this.AimUnit == null)
		{
			return;
		}
		EntityHandle lockTarget = this.LockTarget;
		if (lockTarget != null && lockTarget.Valid)
		{
			this.AimUnit.SetLockState(true);
			return;
		}
		this.AimUnit.SetLockState(false);
	}

	// Token: 0x0600F29C RID: 62108 RVA: 0x00424A30 File Offset: 0x00422C30
	private void TryActivate()
	{
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData == null || curRoleData.CreatureRoleId != 1207)
		{
			this.Deactivate();
			return;
		}
		this.TagTask = curRoleData.GameplayTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.露帕瞄准"]), new BaseTagComponent.TTagSwitchedCallback(this.OnAimTagChanged), null);
		this.IsAiming = curRoleData.GameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.瞄准镜头.露帕瞄准"]);
		this.BuffComponent = curRoleData.BuffComponent;
		if (this.IsAiming)
		{
			this.Activate();
		}
	}

	// Token: 0x0600F29D RID: 62109 RVA: 0x00424AD4 File Offset: 0x00422CD4
	private void Activate()
	{
		if (this.AimUnit != null)
		{
			this.RefreshAimVisible();
			return;
		}
		if (this.IsLoadingAimUnit)
		{
			return;
		}
		this.IsLoadingAimUnit = true;
		base.NewHudUnit<LuPaAimUnit>(typeof(LuPaAimUnit), "UiItem_AimLuPa", true, false).ContinueWith(delegate(LuPaAimUnit aimUnit)
		{
			this.AimUnit = aimUnit;
			this.RefreshAimVisible();
			this.RefreshLockState();
		}).Forget(delegate(Exception _)
		{
			this.IsLoadingAimUnit = false;
		}, true);
	}

	// Token: 0x0600F29E RID: 62110 RVA: 0x00424B3A File Offset: 0x00422D3A
	private void Deactivate()
	{
		if (this.TagTask != null)
		{
			this.TagTask.EndTask();
			this.TagTask = null;
		}
		this.BuffComponent = null;
		this.IsAiming = false;
		this.LockTarget = null;
		this.RefreshAimVisible();
	}

	// Token: 0x0600F29F RID: 62111 RVA: 0x00424B71 File Offset: 0x00422D71
	private void OnAimTagChanged(int tagId, bool tagExist)
	{
		this.IsAiming = tagExist;
		if (this.IsAiming)
		{
			this.Activate();
			return;
		}
		this.RefreshAimVisible();
	}

	// Token: 0x0600F2A0 RID: 62112 RVA: 0x00424B90 File Offset: 0x00422D90
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (!this.IsAiming || this.AimUnit == null || this.BuffComponent == null)
		{
			return;
		}
		if (this.Buff == null || this.BuffComponent.GetBuffByHandle(this.BuffHandle) == null)
		{
			this.Buff = this.BuffComponent.GetBuffById(12076110101L);
			IActiveBuff buff = this.Buff;
			this.BuffHandle = ((buff != null) ? buff.Handle : 0);
		}
		if (this.Buff != null && this.Buff.Duration > 0f)
		{
			this.AimUnit.SetProgress(this.Buff.GetRemainDuration() / this.Buff.Duration);
		}
	}

	// Token: 0x0400747D RID: 29821
	private const long BUFF_ID = 12076110101L;

	// Token: 0x0400747E RID: 29822
	private bool IsLoadingAimUnit;

	// Token: 0x0400747F RID: 29823
	private LuPaAimUnit AimUnit;

	// Token: 0x04007480 RID: 29824
	private ITagTask TagTask;

	// Token: 0x04007481 RID: 29825
	private bool IsAiming;

	// Token: 0x04007482 RID: 29826
	private CharacterBuffComponent BuffComponent;

	// Token: 0x04007483 RID: 29827
	private IActiveBuff Buff;

	// Token: 0x04007484 RID: 29828
	private int BuffHandle;

	// Token: 0x04007485 RID: 29829
	private EntityHandle LockTarget;
}
