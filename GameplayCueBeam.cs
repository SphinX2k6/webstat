using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F9E RID: 12190
[NullableContext(2)]
[Nullable(0)]
public class GameplayCueBeam : GameplayCueBase
{
	// Token: 0x06018DBA RID: 101818 RVA: 0x00709B20 File Offset: 0x00707D20
	protected override void OnInit()
	{
		string[] array = this.CueConfig.Socket.Split('#', StringSplitOptions.None);
		this.Sockets = new List<FName>(array.Length);
		foreach (string key in array)
		{
			this.Sockets.Add(FNameUtil.GetDynamicFName(key).Value);
		}
		EntityHandle instigator = this.Instigator;
		TsBaseCharacter instigatorActor;
		if (instigator == null)
		{
			instigatorActor = null;
		}
		else
		{
			WorldEntity entity = instigator.Entity;
			if (entity == null)
			{
				instigatorActor = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = entity.CheckGetComponent<CharacterActorComponent>();
				instigatorActor = ((characterActorComponent != null) ? characterActorComponent.Actor : null);
			}
		}
		this.InstigatorActor = instigatorActor;
		this.ValidateBeamConfig();
	}

	// Token: 0x06018DBB RID: 101819 RVA: 0x00709BB4 File Offset: 0x00707DB4
	protected override void OnTick(float delta)
	{
		if (this.BeamItem == null)
		{
			return;
		}
		if (this.ShouldHideBeam())
		{
			this.BeamItem.GetOwner().SetActorHiddenInGame(true);
			return;
		}
		this.BeamItem.GetOwner().SetActorHiddenInGame(false);
		this.BeamItem.Tick(this.GetBeamPoints(), delta);
	}

	// Token: 0x06018DBC RID: 101820 RVA: 0x00709C07 File Offset: 0x00707E07
	protected override void OnCreate()
	{
		this.BeamItem = GameplayCueBeamCommonItem.Spawn(this.GetBeamOwner(), this.CueConfig.Path, null);
	}

	// Token: 0x06018DBD RID: 101821 RVA: 0x00709C26 File Offset: 0x00707E26
	protected override void OnDestroy()
	{
		if (this.BeamItem != null)
		{
			this.BeamItem.Destroy();
			this.BeamItem = null;
		}
	}

	// Token: 0x06018DBE RID: 101822 RVA: 0x00709C42 File Offset: 0x00707E42
	public new static bool IsSingleInstance()
	{
		return false;
	}

	// Token: 0x06018DBF RID: 101823 RVA: 0x00709C48 File Offset: 0x00707E48
	protected virtual void ValidateBeamConfig()
	{
		if (this.Instigator == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HXY, "无法获取Buff特效连线创建者", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.InstigatorActor == this.ActorInternal)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HXY, "Buff特效连线两端不能是同一个人", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06018DC0 RID: 101824 RVA: 0x00709CA3 File Offset: 0x00707EA3
	protected virtual bool ShouldHideBeam()
	{
		return this.InstigatorActor.bHidden || this.ActorInternal.bHidden;
	}

	// Token: 0x06018DC1 RID: 101825 RVA: 0x00709CBF File Offset: 0x00707EBF
	[NullableContext(1)]
	protected virtual ABaseCharacter GetBeamOwner()
	{
		return this.InstigatorActor;
	}

	// Token: 0x06018DC2 RID: 101826 RVA: 0x00709CC7 File Offset: 0x00707EC7
	[NullableContext(1)]
	protected virtual FVectorDouble[] GetBeamPoints()
	{
		return new FVectorDouble[]
		{
			this.GetInstigatorPoint(),
			this.GetActorPoint()
		};
	}

	// Token: 0x06018DC3 RID: 101827 RVA: 0x00709CEC File Offset: 0x00707EEC
	protected FVectorDouble GetInstigatorPoint()
	{
		if (!(this.Sockets[0] != null))
		{
			return this.InstigatorActor.D_K2_GetActorLocation();
		}
		return this.InstigatorActor.Mesh.D_GetSocketLocation(this.Sockets[0]);
	}

	// Token: 0x06018DC4 RID: 101828 RVA: 0x00709D3C File Offset: 0x00707F3C
	protected FVectorDouble GetActorPoint()
	{
		if (!(this.Sockets[1] != null))
		{
			return this.ActorInternal.D_K2_GetActorLocation();
		}
		return this.ActorInternal.Mesh.D_GetSocketLocation(this.Sockets[1]);
	}

	// Token: 0x06018DC5 RID: 101829 RVA: 0x00709D8A File Offset: 0x00707F8A
	protected bool HasExternalInstigator()
	{
		TsBaseCharacter instigatorActor = this.InstigatorActor;
		return instigatorActor != null && instigatorActor.IsValid() && this.InstigatorActor != this.ActorInternal;
	}

	// Token: 0x0400C225 RID: 49701
	protected TsBaseCharacter InstigatorActor;

	// Token: 0x0400C226 RID: 49702
	protected List<FName> Sockets;

	// Token: 0x0400C227 RID: 49703
	protected GameplayCueBeamCommonItem BeamItem;
}
