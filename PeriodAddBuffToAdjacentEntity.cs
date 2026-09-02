using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002F80 RID: 12160
[NullableContext(1)]
[Nullable(0)]
public class PeriodAddBuffToAdjacentEntity : PeriodExecution
{
	// Token: 0x06018D2B RID: 101675 RVA: 0x00705DD8 File Offset: 0x00703FD8
	public PeriodAddBuffToAdjacentEntity(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D2C RID: 101676 RVA: 0x00705E10 File Offset: 0x00704010
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length < 2)
		{
			return;
		}
		this.Distance = float.Parse(extraEffectParameters_[0]);
		string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i].Trim());
		}
		if (extraEffectParameters_.Length > 2 && !string.IsNullOrEmpty(extraEffectParameters_[2]))
		{
			string[] array2 = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
			this.CampFilter = new EAuraTargetFilter[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				this.CampFilter[j] = (EAuraTargetFilter)int.Parse(array2[j].Trim());
			}
		}
		else
		{
			this.CampFilter = new EAuraTargetFilter[]
			{
				EAuraTargetFilter.Instigator,
				EAuraTargetFilter.AllyOfInstigator
			};
		}
		this.TransferStackCount = (extraEffectParameters_.Length > 3 && int.Parse(extraEffectParameters_[3]) == 1);
		this.CheckBeforeAdd = (extraEffectParameters_.Length > 4 && int.Parse(extraEffectParameters_[4]) == 1);
		this.RemoveBuffOnLeave = (extraEffectParameters_.Length > 5 && int.Parse(extraEffectParameters_[5]) == 1);
		this.NeedInstigator = false;
		for (int k = 0; k < this.CampFilter.Length; k++)
		{
			EAuraTargetFilter eauraTargetFilter = this.CampFilter[k];
			if (eauraTargetFilter == EAuraTargetFilter.Instigator || eauraTargetFilter == EAuraTargetFilter.EnemyOfInstigator || eauraTargetFilter == EAuraTargetFilter.AllyOfInstigator)
			{
				this.NeedInstigator = true;
				break;
			}
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Buff");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral("的光环额外效果导致的共享添加");
		this.BuffReason = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06018D2D RID: 101677 RVA: 0x00705FA8 File Offset: 0x007041A8
	protected override bool CheckExecutable()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
		}
		return true;
	}

	// Token: 0x06018D2E RID: 101678 RVA: 0x00705FCC File Offset: 0x007041CC
	[return: Nullable(2)]
	public unsafe override object OnExecute(params object[] args)
	{
		Entity ownerEntity = base.OwnerEntity;
		global::Vector vector;
		if (ownerEntity == null)
		{
			vector = null;
		}
		else
		{
			BaseActorComponent component = ownerEntity.GetComponent<BaseActorComponent>();
			vector = ((component != null) ? component.ActorLocationProxy : null);
		}
		global::Vector vector2 = vector;
		CreatureDataComponent creatureDataComponent = (ownerEntity != null) ? ownerEntity.GetComponent<CreatureDataComponent>() : null;
		if (vector2 == null || creatureDataComponent == null)
		{
			return null;
		}
		if (ownerEntity == null)
		{
			return null;
		}
		EntityHandle instigatorEntity = base.InstigatorEntity;
		WorldEntity worldEntity = (instigatorEntity != null) ? instigatorEntity.Entity : null;
		CreatureDataComponent creatureDataComponent2 = (worldEntity != null) ? worldEntity.CheckGetComponent<CreatureDataComponent>() : null;
		if (this.NeedInstigator && creatureDataComponent2 == null)
		{
			if (!this.HasWarned)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = ownerEntity;
				string message = "光环效果指定了施加者阵营判断，但施加者不合法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "handle";
				IActiveBuff buff = this.Buff;
				ptr = new ValueTuple<string, object>(item, (buff != null) ? new int?(buff.Handle) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", this.BuffId);
				instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.HasWarned = true;
			}
			return null;
		}
		ECamp? instigatorCamp = (creatureDataComponent2 != null) ? new ECamp?(creatureDataComponent2.GetEntityCamp()) : null;
		ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(vector2, this.Distance, EEntityTypeQuery.Character, this.EntityHandleList, true);
		List<BaseBuffComponent> list = new List<BaseBuffComponent>();
		ECamp entityCamp = creatureDataComponent.GetEntityCamp();
		IActiveBuff buff2 = this.Buff;
		long? num = (buff2 != null) ? buff2.InstigatorId : null;
		for (int i = 0; i < this.EntityHandleList.Count; i++)
		{
			bool flag2 = false;
			WorldEntity entity2 = this.EntityHandleList[i].Entity;
			if (entity2 != null && entity2.Valid && entity2.IsInit)
			{
				CreatureDataComponent component2 = entity2.GetComponent<CreatureDataComponent>();
				CharacterBuffComponent component3 = entity2.GetComponent<CharacterBuffComponent>();
				if (component2 != null && component3 != null)
				{
					ECamp targetCamp = (component2.GetEntityType() == EEntityType.Player) ? ECamp.Player : component2.GetEntityCamp();
					for (int j = 0; j < this.CampFilter.Length; j++)
					{
						if (this.CheckCamp(this.CampFilter[j], entity2.Id, targetCamp, (worldEntity != null) ? new int?(worldEntity.Id) : null, instigatorCamp, ownerEntity.Id, entityCamp))
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						list.Add(component3);
					}
				}
			}
		}
		if (this.RemoveBuffOnLeave)
		{
			HashSet<int> orCreateExecutionState = ((ActiveBuffInternal)this.Buff).GetOrCreateExecutionState(this.Index);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (BaseBuffComponent baseBuffComponent in list)
			{
				Entity entity3 = baseBuffComponent.GetEntity();
				int? num2 = (entity3 != null) ? new int?(entity3.Id) : null;
				if (num2 != null)
				{
					hashSet.Add(num2.Value);
				}
			}
			List<int> list2 = new List<int>();
			foreach (int item2 in orCreateExecutionState)
			{
				if (!hashSet.Contains(item2))
				{
					list2.Add(item2);
				}
			}
			foreach (int id in list2)
			{
				EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(id);
				CharacterBuffComponent characterBuffComponent;
				if (handle == null)
				{
					characterBuffComponent = null;
				}
				else
				{
					WorldEntity entity4 = handle.Entity;
					characterBuffComponent = ((entity4 != null) ? entity4.GetComponent<CharacterBuffComponent>() : null);
				}
				CharacterBuffComponent characterBuffComponent2 = characterBuffComponent;
				if (characterBuffComponent2 != null)
				{
					foreach (long num3 in this.BuffIds)
					{
						BaseBuffComponent buffApplyTarget = characterBuffComponent2.GetBuffApplyTarget(num3, num.GetValueOrDefault());
						if (buffApplyTarget != null && buffApplyTarget.Valid)
						{
							BaseBuffComponent baseBuffComponent2 = characterBuffComponent2;
							long buffId = num3;
							int stackCount = -1;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Buff");
							defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
							defaultInterpolatedStringHandler.AppendLiteral("光环效果：实体离开范围，移除buff");
							baseBuffComponent2.RemoveBuff(buffId, stackCount, defaultInterpolatedStringHandler.ToStringAndClear(), null, null, null);
						}
					}
				}
			}
			orCreateExecutionState.Clear();
			foreach (int item3 in hashSet)
			{
				orCreateExecutionState.Add(item3);
			}
		}
		int? num4;
		if (!this.TransferStackCount)
		{
			num4 = null;
		}
		else
		{
			IActiveBuff buff3 = this.Buff;
			num4 = ((buff3 != null) ? new int?(buff3.StackCount) : null);
		}
		int? stackCount2 = num4;
		foreach (BaseBuffComponent baseBuffComponent3 in list)
		{
			foreach (long buffId2 in this.BuffIds)
			{
				BaseBuffComponent buffApplyTarget2 = baseBuffComponent3.GetBuffApplyTarget(buffId2, num.GetValueOrDefault());
				if (buffApplyTarget2 != null && (!this.CheckBeforeAdd || !buffApplyTarget2.HasBuff(buffId2, false)))
				{
					baseBuffComponent3.AddIterativeBuff(buffId2, this.Buff, stackCount2, false, this.BuffReason, null, null);
				}
			}
		}
		return null;
	}

	// Token: 0x06018D2F RID: 101679 RVA: 0x00706560 File Offset: 0x00704760
	public override void OnBuffRemovedCallback(ActiveBuffInternal buff)
	{
		this.ClearAuraBuffsOnLeave(buff);
	}

	// Token: 0x06018D30 RID: 101680 RVA: 0x00706569 File Offset: 0x00704769
	public override void OnBuffActiveChangedCallback(ActiveBuffInternal buff, bool isActive)
	{
		if (!isActive)
		{
			this.ClearAuraBuffsOnLeave(buff);
		}
	}

	// Token: 0x06018D31 RID: 101681 RVA: 0x00706578 File Offset: 0x00704778
	private void ClearAuraBuffsOnLeave(ActiveBuffInternal buff)
	{
		if (!this.RemoveBuffOnLeave)
		{
			return;
		}
		HashSet<int> orCreateExecutionState = buff.GetOrCreateExecutionState(this.Index);
		if (orCreateExecutionState.Count == 0)
		{
			return;
		}
		long? instigatorId = buff.InstigatorId;
		foreach (int id in orCreateExecutionState)
		{
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(id);
			CharacterBuffComponent characterBuffComponent;
			if (handle == null)
			{
				characterBuffComponent = null;
			}
			else
			{
				WorldEntity entity = handle.Entity;
				characterBuffComponent = ((entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null);
			}
			CharacterBuffComponent characterBuffComponent2 = characterBuffComponent;
			if (characterBuffComponent2 != null)
			{
				foreach (long num in this.BuffIds)
				{
					BaseBuffComponent buffApplyTarget = characterBuffComponent2.GetBuffApplyTarget(num, instigatorId.GetValueOrDefault());
					if (buffApplyTarget != null && buffApplyTarget.Valid)
					{
						BaseBuffComponent baseBuffComponent = characterBuffComponent2;
						long buffId = num;
						int stackCount = -1;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Buff");
						defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
						defaultInterpolatedStringHandler.AppendLiteral("光环效果：光环buff被移除或失活，清除所有受影响实体的buff");
						baseBuffComponent.RemoveBuff(buffId, stackCount, defaultInterpolatedStringHandler.ToStringAndClear(), null, null, null);
					}
				}
			}
		}
		orCreateExecutionState.Clear();
	}

	// Token: 0x06018D32 RID: 101682 RVA: 0x007066C4 File Offset: 0x007048C4
	public bool CheckCamp(EAuraTargetFilter filter, int targetId, ECamp targetCamp, int? instigatorId, ECamp? instigatorCamp, int ownerId, ECamp ownerCamp)
	{
		switch (filter)
		{
		case EAuraTargetFilter.Instigator:
		{
			int? num = instigatorId;
			return targetId == num.GetValueOrDefault() & num != null;
		}
		case EAuraTargetFilter.Owner:
			return targetId == ownerId;
		case EAuraTargetFilter.AllyOfInstigator:
		{
			int? num = instigatorId;
			return !(targetId == num.GetValueOrDefault() & num != null) && instigatorCamp != null && CampUtils.GetCampRelationship(instigatorCamp.Value, targetCamp) == ERelation.Friend;
		}
		case EAuraTargetFilter.EnemyOfInstigator:
			return instigatorCamp != null && CampUtils.GetCampRelationship(instigatorCamp.Value, targetCamp) == ERelation.Enemy;
		case EAuraTargetFilter.AllyOfOwner:
			return targetId != ownerId && CampUtils.GetCampRelationship(ownerCamp, targetCamp) == ERelation.Friend;
		case EAuraTargetFilter.EnemyOfOwner:
			return CampUtils.GetCampRelationship(ownerCamp, targetCamp) == ERelation.Enemy;
		default:
			return false;
		}
	}

	// Token: 0x06018D33 RID: 101683 RVA: 0x00706780 File Offset: 0x00704980
	public override string GetDebugEffectString()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < this.CampFilter.Length; i++)
		{
			switch (this.CampFilter[i])
			{
			case EAuraTargetFilter.Instigator:
				list.Add("施加者");
				break;
			case EAuraTargetFilter.Owner:
				list.Add("持有者");
				break;
			case EAuraTargetFilter.AllyOfInstigator:
				list.Add("施加者的友方");
				break;
			case EAuraTargetFilter.EnemyOfInstigator:
				list.Add("施加者的敌方");
				break;
			case EAuraTargetFilter.AllyOfOwner:
				list.Add("持有者的友方");
				break;
			case EAuraTargetFilter.EnemyOfOwner:
				list.Add("持有者的敌方");
				break;
			default:
				list.Add("Unknown");
				break;
			}
		}
		string value = this.TransferStackCount ? "（传递层数）" : string.Empty;
		string value2 = this.CheckBeforeAdd ? "（不重复添加）" : string.Empty;
		string value3 = this.RemoveBuffOnLeave ? "（离开移除）" : string.Empty;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 6);
		defaultInterpolatedStringHandler.AppendLiteral("为");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Distance / 100f, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("m内的");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join("、", list));
		defaultInterpolatedStringHandler.AppendLiteral("附加Buff");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.BuffIds));
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C1AD RID: 49581
	private float Distance;

	// Token: 0x0400C1AE RID: 49582
	private EAuraTargetFilter[] CampFilter = Array.Empty<EAuraTargetFilter>();

	// Token: 0x0400C1AF RID: 49583
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400C1B0 RID: 49584
	private bool HasWarned;

	// Token: 0x0400C1B1 RID: 49585
	private readonly List<EntityHandle> EntityHandleList = new List<EntityHandle>();

	// Token: 0x0400C1B2 RID: 49586
	private string BuffReason = string.Empty;

	// Token: 0x0400C1B3 RID: 49587
	private bool NeedInstigator;

	// Token: 0x0400C1B4 RID: 49588
	private bool TransferStackCount;

	// Token: 0x0400C1B5 RID: 49589
	private bool CheckBeforeAdd;

	// Token: 0x0400C1B6 RID: 49590
	private bool RemoveBuffOnLeave;
}
