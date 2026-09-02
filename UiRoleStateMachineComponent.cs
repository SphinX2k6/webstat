using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002CB4 RID: 11444
[NullableContext(2)]
[Nullable(0)]
public class UiRoleStateMachineComponent : UiModelComponentBase
{
	// Token: 0x06016F7B RID: 94075 RVA: 0x0065DF29 File Offset: 0x0065C129
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
	}

	// Token: 0x06016F7C RID: 94076 RVA: 0x0065DF4D File Offset: 0x0065C14D
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
	}

	// Token: 0x06016F7D RID: 94077 RVA: 0x0065DF71 File Offset: 0x0065C171
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
	}

	// Token: 0x06016F7E RID: 94078 RVA: 0x0065DF95 File Offset: 0x0065C195
	public void SetState(EPerformanceRoleState roleState, bool reLoop = false, bool reLoopFromLoopToStart = false, bool waitLaseStateEnd = false)
	{
		this.RoleState = roleState;
		this.ReLoop = reLoop;
		this.ReLoopFromLoopToStart = reLoopFromLoopToStart;
		this.WaitLaseStateEnd = waitLaseStateEnd;
		this.Execute();
	}

	// Token: 0x06016F7F RID: 94079 RVA: 0x0065DFBC File Offset: 0x0065C1BC
	private void Execute()
	{
		if (this.ModelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			return;
		}
		USkeletalMeshComponent mainMeshComponent = this.ActorComponent.MainMeshComponent;
		ABP_PerformanceRole_C animInstanceFromSkeletalMesh = this.ActorComponent.GetAnimInstanceFromSkeletalMesh(mainMeshComponent);
		if (animInstanceFromSkeletalMesh == null)
		{
			return;
		}
		animInstanceFromSkeletalMesh.SetState(this.RoleState, this.ReLoop, this.ReLoopFromLoopToStart, this.WaitLaseStateEnd);
	}

	// Token: 0x06016F80 RID: 94080 RVA: 0x0065E012 File Offset: 0x0065C212
	public void OnRoleMeshLoadComplete()
	{
		this.SetDefaultPerformDelay();
		this.Execute();
	}

	// Token: 0x06016F81 RID: 94081 RVA: 0x0065E020 File Offset: 0x0065C220
	private void SetDefaultPerformDelay()
	{
		USkeletalMeshComponent mainMeshComponent = this.ActorComponent.MainMeshComponent;
		ABP_PerformanceRole_C animInstanceFromSkeletalMesh = this.ActorComponent.GetAnimInstanceFromSkeletalMesh(mainMeshComponent);
		float? rolePerformanceDelayTime = ConfigBase<RoleConfig>.Instance.GetRolePerformanceDelayTime();
		if (animInstanceFromSkeletalMesh == null)
		{
			return;
		}
		animInstanceFromSkeletalMesh.SetPerformDelay(rolePerformanceDelayTime.Value);
	}

	// Token: 0x0400B11B RID: 45339
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B11C RID: 45340
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B11D RID: 45341
	private EPerformanceRoleState RoleState;

	// Token: 0x0400B11E RID: 45342
	private bool ReLoop;

	// Token: 0x0400B11F RID: 45343
	private bool WaitLaseStateEnd;

	// Token: 0x0400B120 RID: 45344
	private bool ReLoopFromLoopToStart;
}
