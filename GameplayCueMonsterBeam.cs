using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002FB0 RID: 12208
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueMonsterBeam : GameplayCueBeam
{
	// Token: 0x06018E53 RID: 101971 RVA: 0x0070D2D1 File Offset: 0x0070B4D1
	protected override void OnInit()
	{
		base.OnInit();
		this.FallbackForwardOffset = this.ParseParamNumber("FallbackForwardOffset", 600f);
	}

	// Token: 0x06018E54 RID: 101972 RVA: 0x0070D2EF File Offset: 0x0070B4EF
	protected override void OnTick(float delta)
	{
		this.RefreshTarget();
		base.OnTick(delta);
	}

	// Token: 0x06018E55 RID: 101973 RVA: 0x0070D300 File Offset: 0x0070B500
	protected override void OnCreate()
	{
		this.RefreshTarget();
		this.BeamItem = GameplayCueBeamCommonItem.Spawn(this.GetBeamOwner(), this.CueConfig.Path, delegate(UNiagaraComponent niagaraComponent)
		{
			niagaraComponent.SetRenderInBurst(true);
		});
	}

	// Token: 0x06018E56 RID: 101974 RVA: 0x0070D34E File Offset: 0x0070B54E
	protected override void ValidateBeamConfig()
	{
	}

	// Token: 0x06018E57 RID: 101975 RVA: 0x0070D350 File Offset: 0x0070B550
	protected override bool ShouldHideBeam()
	{
		if (!this.HasTarget())
		{
			return this.ActorInternal.bHidden;
		}
		return this.ActorInternal.bHidden || this.TargetActor.bHidden;
	}

	// Token: 0x06018E58 RID: 101976 RVA: 0x0070D380 File Offset: 0x0070B580
	protected override ABaseCharacter GetBeamOwner()
	{
		if (!this.HasTarget())
		{
			return this.ActorInternal;
		}
		return this.TargetActor;
	}

	// Token: 0x06018E59 RID: 101977 RVA: 0x0070D398 File Offset: 0x0070B598
	protected override FVectorDouble[] GetBeamPoints()
	{
		if (this.HasTarget())
		{
			FVectorDouble[] array = new FVectorDouble[2];
			int num = 0;
			ABaseCharacter actorInternal = this.ActorInternal;
			List<FName> sockets = this.Sockets;
			array[num] = GameplayCueMonsterBeam.GetMeshSocketLocation(actorInternal, (sockets != null) ? new FName?(sockets[0]) : null);
			array[1] = this.GetTargetPoint();
			return array;
		}
		FVectorDouble[] array2 = new FVectorDouble[2];
		int num2 = 0;
		ABaseCharacter actorInternal2 = this.ActorInternal;
		List<FName> sockets2 = this.Sockets;
		array2[num2] = GameplayCueMonsterBeam.GetMeshSocketLocation(actorInternal2, (sockets2 != null) ? new FName?(sockets2[0]) : null);
		array2[1] = this.GetFallbackPoint();
		return array2;
	}

	// Token: 0x06018E5A RID: 101978 RVA: 0x0070D438 File Offset: 0x0070B638
	private bool HasTarget()
	{
		TsBaseCharacter targetActor = this.TargetActor;
		return targetActor != null && targetActor.IsValid() && this.TargetActor != this.ActorInternal;
	}

	// Token: 0x06018E5B RID: 101979 RVA: 0x0070D464 File Offset: 0x0070B664
	private void RefreshTarget()
	{
		ValueTuple<TsBaseCharacter, string> valueTuple = this.ResolveLockOnOrSkillTarget();
		TsBaseCharacter item = valueTuple.Item1;
		string item2 = valueTuple.Item2;
		this.TargetActor = item;
		this.TargetSocketName = item2;
	}

	// Token: 0x06018E5C RID: 101980 RVA: 0x0070D494 File Offset: 0x0070B694
	[return: TupleElementNames(new string[]
	{
		"Target",
		"Socket"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private ValueTuple<TsBaseCharacter, string> ResolveLockOnOrSkillTarget()
	{
		EntityHandle entityHandle = null;
		string item = string.Empty;
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterLockOnComponent characterLockOnComponent = (entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null;
		WorldEntity entity2 = this.EntityHandle.Entity;
		CharacterActorComponent characterActorComponent = (entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null;
		if (characterLockOnComponent != null && characterActorComponent != null && characterActorComponent.IsAutonomousProxy)
		{
			entityHandle = characterLockOnComponent.GetCurrentTarget();
			item = characterLockOnComponent.GetCurrentTargetSocketName();
		}
		bool flag;
		if (entityHandle == null)
		{
			flag = true;
		}
		else
		{
			WorldEntity entity3 = entityHandle.Entity;
			flag = !((entity3 != null) ? new bool?(entity3.Valid) : null).GetValueOrDefault();
		}
		if (flag)
		{
			WorldEntity entity4 = this.EntityHandle.Entity;
			CharacterSkillComponent characterSkillComponent = (entity4 != null) ? entity4.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent != null)
			{
				entityHandle = characterSkillComponent.SkillTarget;
				item = characterSkillComponent.SkillTargetSocket;
			}
		}
		bool flag2;
		if (entityHandle == null)
		{
			flag2 = true;
		}
		else
		{
			WorldEntity entity5 = entityHandle.Entity;
			flag2 = !((entity5 != null) ? new bool?(entity5.Valid) : null).GetValueOrDefault();
		}
		if (flag2)
		{
			return new ValueTuple<TsBaseCharacter, string>(null, string.Empty);
		}
		CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
		return new ValueTuple<TsBaseCharacter, string>((component != null) ? component.Actor : null, item);
	}

	// Token: 0x06018E5D RID: 101981 RVA: 0x0070D5B4 File Offset: 0x0070B7B4
	private FVectorDouble GetTargetPoint()
	{
		TsBaseCharacter targetActor = this.TargetActor;
		USkeletalMeshComponent mesh = targetActor.Mesh;
		if (mesh == null)
		{
			return targetActor.D_K2_GetActorLocation();
		}
		FName? fname;
		if (string.IsNullOrEmpty(this.TargetSocketName))
		{
			List<FName> sockets = this.Sockets;
			fname = ((sockets != null) ? new FName?(sockets[1]) : null);
		}
		else
		{
			fname = FNameUtil.GetDynamicFName(this.TargetSocketName);
		}
		FName? fname2 = fname;
		if (fname2 == null || !mesh.DoesSocketExist(fname2.Value))
		{
			fname2 = new FName?(Singleton<CharacterNameDefines>.Instance.HIT_CASE_NAME);
		}
		return mesh.D_GetSocketLocation(fname2.Value);
	}

	// Token: 0x06018E5E RID: 101982 RVA: 0x0070D64C File Offset: 0x0070B84C
	private FVectorDouble GetFallbackPoint()
	{
		FVectorDouble fvectorDouble = this.ActorInternal.D_K2_GetActorLocation();
		FVector actorForwardVector = this.ActorInternal.GetActorForwardVector();
		float fallbackForwardOffset = this.FallbackForwardOffset;
		return new FVectorDouble(fvectorDouble.X + (double)(actorForwardVector.X * fallbackForwardOffset), fvectorDouble.Y + (double)(actorForwardVector.Y * fallbackForwardOffset), fvectorDouble.Z + (double)(actorForwardVector.Z * fallbackForwardOffset));
	}

	// Token: 0x06018E5F RID: 101983 RVA: 0x0070D6B0 File Offset: 0x0070B8B0
	private static FVectorDouble GetMeshSocketLocation(ABaseCharacter actor, FName? socket)
	{
		USkeletalMeshComponent mesh = actor.Mesh;
		if (socket != null && mesh != null)
		{
			return mesh.D_GetSocketLocation(socket.Value);
		}
		return actor.D_K2_GetActorLocation();
	}

	// Token: 0x06018E60 RID: 101984 RVA: 0x0070D6E4 File Offset: 0x0070B8E4
	private float ParseParamNumber(string key, float defaultValue)
	{
		int parametersLength = this.CueConfig.ParametersLength;
		string text = key + "=";
		int i = 0;
		while (i < parametersLength)
		{
			string text2 = this.CueConfig.Parameters(i);
			if (text2.StartsWith(text))
			{
				float result;
				if (!float.TryParse(text2.Substring(text.Length), out result))
				{
					return defaultValue;
				}
				return result;
			}
			else
			{
				i++;
			}
		}
		return defaultValue;
	}

	// Token: 0x0400C286 RID: 49798
	private const float DEFAULT_FALLBACK_FORWARD_OFFSET = 600f;

	// Token: 0x0400C287 RID: 49799
	private float FallbackForwardOffset = 600f;

	// Token: 0x0400C288 RID: 49800
	[Nullable(2)]
	private TsBaseCharacter TargetActor;

	// Token: 0x0400C289 RID: 49801
	private string TargetSocketName = string.Empty;
}
