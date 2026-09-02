using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02000D3A RID: 3386
[NullableContext(1)]
[Nullable(0)]
internal class CurveMoveParams
{
	// Token: 0x060046A3 RID: 18083 RVA: 0x0008F6E0 File Offset: 0x0008D8E0
	public bool RefreshTarget(string key, string socket, EPositionDatumTarget datum, ECurveMoveTargetBlackboardType? keyType = null)
	{
		BaseActorComponent targetActorComp = this.TargetActorComp;
		bool flag;
		if (targetActorComp == null)
		{
			flag = true;
		}
		else
		{
			Entity entity = targetActorComp.Entity;
			flag = !((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault();
		}
		if (flag)
		{
			this.TargetActorComp = null;
			this.TargetCharActorComp = null;
		}
		this.LastLocation.DeepCopy(this.CharActorComp.LastActorLocation);
		ECurveMoveTargetBlackboardType? ecurveMoveTargetBlackboardType = keyType;
		ECurveMoveTargetBlackboardType ecurveMoveTargetBlackboardType2 = ECurveMoveTargetBlackboardType.LocationVector;
		if (ecurveMoveTargetBlackboardType.GetValueOrDefault() == ecurveMoveTargetBlackboardType2 & ecurveMoveTargetBlackboardType != null)
		{
			this.TargetActorComp = this.CharActorComp;
			this.TargetCharActorComp = this.CharActorComp;
			this.SocketName = socket;
			return true;
		}
		switch (datum)
		{
		case EPositionDatumTarget.User:
			this.TargetActorComp = this.CharActorComp;
			this.TargetCharActorComp = this.CharActorComp;
			this.SocketName = socket;
			break;
		case EPositionDatumTarget.Skill:
		{
			CharacterSkillComponent charSkillComp = this.CharSkillComp;
			EntityHandle entityHandle = (charSkillComp != null) ? charSkillComp.GetSkillTargetForAns() : null;
			if (entityHandle == null || !entityHandle.Valid)
			{
				return false;
			}
			BaseActorComponent targetActorComp2 = this.TargetActorComp;
			bool flag2;
			if (targetActorComp2 == null)
			{
				flag2 = false;
			}
			else
			{
				Entity entity2 = targetActorComp2.Entity;
				flag2 = ((entity2 != null) ? new bool?(entity2.Valid) : null).GetValueOrDefault();
			}
			if (flag2 && entityHandle.Id == this.TargetActorComp.Entity.Id)
			{
				return true;
			}
			this.TargetActorComp = entityHandle.Entity.GetComponent<BaseActorComponent>();
			this.TargetCharActorComp = entityHandle.Entity.GetComponent<CharacterActorComponent>();
			this.SocketName = this.CharSkillComp.SkillTargetSocket;
			break;
		}
		case EPositionDatumTarget.Blackboard:
		{
			Entity targetEntity = this.GetTargetEntity(key, keyType);
			if (targetEntity == null || !targetEntity.Valid)
			{
				return false;
			}
			BaseActorComponent targetActorComp3 = this.TargetActorComp;
			bool flag3;
			if (targetActorComp3 == null)
			{
				flag3 = false;
			}
			else
			{
				Entity entity3 = targetActorComp3.Entity;
				flag3 = ((entity3 != null) ? new bool?(entity3.Valid) : null).GetValueOrDefault();
			}
			if (flag3 && this.TargetActorComp.Entity.Id == targetEntity.Id)
			{
				return true;
			}
			this.TargetActorComp = targetEntity.GetComponent<BaseActorComponent>();
			this.TargetCharActorComp = targetEntity.GetComponent<CharacterActorComponent>();
			this.SocketName = socket;
			break;
		}
		}
		return true;
	}

	// Token: 0x060046A4 RID: 18084 RVA: 0x0008F900 File Offset: 0x0008DB00
	[return: Nullable(2)]
	private Entity GetTargetEntity(string key, ECurveMoveTargetBlackboardType? keyType)
	{
		int? num = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(this.CharActorComp.Entity.Id, key);
		ECurveMoveTargetBlackboardType? ecurveMoveTargetBlackboardType = keyType;
		ECurveMoveTargetBlackboardType ecurveMoveTargetBlackboardType2 = ECurveMoveTargetBlackboardType.CreatureDataId;
		if (ecurveMoveTargetBlackboardType.GetValueOrDefault() == ecurveMoveTargetBlackboardType2 & ecurveMoveTargetBlackboardType != null)
		{
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity((long)num.Value);
					if (entity == null)
					{
						return null;
					}
					return entity.Entity;
				}
			}
			return null;
		}
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				goto IL_DB;
			}
		}
		num = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(this.CharActorComp.Entity.Id, key);
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				goto IL_DB;
			}
		}
		return null;
		IL_DB:
		return Singleton<EntitySystem>.Instance.Get(num.Value);
	}

	// Token: 0x060046A5 RID: 18085 RVA: 0x0008F9F9 File Offset: 0x0008DBF9
	public void Clear()
	{
		this.CharActorComp = null;
		this.CharUnifiedComp = null;
		this.CharSkillComp = null;
		this.TargetActorComp = null;
		this.TargetCharActorComp = null;
		this.SocketName = "";
	}

	// Token: 0x0400131F RID: 4895
	[Nullable(2)]
	public CharacterActorComponent CharActorComp;

	// Token: 0x04001320 RID: 4896
	[Nullable(2)]
	public CharacterUnifiedStateComponent CharUnifiedComp;

	// Token: 0x04001321 RID: 4897
	[Nullable(2)]
	public CharacterSkillComponent CharSkillComp;

	// Token: 0x04001322 RID: 4898
	[Nullable(2)]
	public BaseActorComponent TargetActorComp;

	// Token: 0x04001323 RID: 4899
	[Nullable(2)]
	public CharacterActorComponent TargetCharActorComp;

	// Token: 0x04001324 RID: 4900
	public double NowTime;

	// Token: 0x04001325 RID: 4901
	public double TotalTime;

	// Token: 0x04001326 RID: 4902
	public string SocketName = "";

	// Token: 0x04001327 RID: 4903
	public readonly Vector LastLocation = Vector.Create();

	// Token: 0x04001328 RID: 4904
	public readonly Vector InitLocation = Vector.Create();

	// Token: 0x04001329 RID: 4905
	public readonly Vector TargetOffset = Vector.Create();

	// Token: 0x0400132A RID: 4906
	public readonly Vector TargetPos = Vector.Create();

	// Token: 0x0400132B RID: 4907
	public readonly Vector LastTargetPos = Vector.Create();

	// Token: 0x0400132C RID: 4908
	public readonly Vector TargetVec = Vector.Create();

	// Token: 0x0400132D RID: 4909
	public bool AlongStraightLine;

	// Token: 0x0400132E RID: 4910
	public bool AllowMovement;

	// Token: 0x0400132F RID: 4911
	public bool CanSetActorTargetPos;

	// Token: 0x04001330 RID: 4912
	public bool FlyingMove;

	// Token: 0x04001331 RID: 4913
	public float LastSplineDistance;
}
