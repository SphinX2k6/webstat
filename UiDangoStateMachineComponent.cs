using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.NPC.Tuanzi;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002C9A RID: 11418
[NullableContext(2)]
[Nullable(0)]
public class UiDangoStateMachineComponent : UiModelComponentBase
{
	// Token: 0x06016E9F RID: 93855 RVA: 0x0065A587 File Offset: 0x00658787
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
	}

	// Token: 0x06016EA0 RID: 93856 RVA: 0x0065A5AB File Offset: 0x006587AB
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnDangoMeshLoadComplete));
	}

	// Token: 0x06016EA1 RID: 93857 RVA: 0x0065A5CF File Offset: 0x006587CF
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnDangoMeshLoadComplete));
	}

	// Token: 0x06016EA2 RID: 93858 RVA: 0x0065A5F3 File Offset: 0x006587F3
	public void SetState(EDangoState dangoState, float stateParam = 0f, float stateParam2 = 0f)
	{
		this.DangoState = dangoState;
		this.DangoStateParam = stateParam;
		this.DangoStateParam2 = stateParam2;
		this.Execute();
	}

	// Token: 0x06016EA3 RID: 93859 RVA: 0x0065A610 File Offset: 0x00658810
	private void Execute()
	{
		if (this.ModelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			return;
		}
		ABP_TuanziNPC_C dangoBp = this.GetDangoBp();
		EDangoState dangoState = this.DangoState;
		if (dangoState != EDangoState.ActionPerform)
		{
			if (dangoState != EDangoState.MoveJump)
			{
				return;
			}
			if (dangoBp != null)
			{
				dangoBp.StartJumpWithParams(this.DangoStateParam, this.DangoStateParam2);
			}
		}
		else if (dangoBp != null)
		{
			dangoBp.StartActionPerform((EDangoActionPerformType)this.DangoStateParam);
			return;
		}
	}

	// Token: 0x06016EA4 RID: 93860 RVA: 0x0065A66C File Offset: 0x0065886C
	public ABP_TuanziNPC_C GetDangoBp()
	{
		UiModelActorComponent actorComponent = this.ActorComponent;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComponent != null) ? actorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			return null;
		}
		UiModelActorComponent actorComponent2 = this.ActorComponent;
		if (actorComponent2 == null)
		{
			return null;
		}
		return actorComponent2.GetDangoAnimInstanceFromSkeletalMesh(uskeletalMeshComponent);
	}

	// Token: 0x06016EA5 RID: 93861 RVA: 0x0065A6A3 File Offset: 0x006588A3
	public void OnDangoMeshLoadComplete()
	{
		this.Execute();
	}

	// Token: 0x0400B0B9 RID: 45241
	private EDangoState DangoState;

	// Token: 0x0400B0BA RID: 45242
	private float DangoStateParam;

	// Token: 0x0400B0BB RID: 45243
	private float DangoStateParam2;

	// Token: 0x0400B0BC RID: 45244
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B0BD RID: 45245
	private UiModelActorComponent ActorComponent;
}
