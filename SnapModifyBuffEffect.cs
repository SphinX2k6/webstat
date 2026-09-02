using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F61 RID: 12129
[NullableContext(1)]
[Nullable(0)]
public abstract class SnapModifyBuffEffect : BuffEffect
{
	// Token: 0x06018CA9 RID: 101545 RVA: 0x007026D4 File Offset: 0x007008D4
	protected SnapModifyBuffEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CAA RID: 101546 RVA: 0x007026E3 File Offset: 0x007008E3
	protected override bool CheckAuthority()
	{
		return false;
	}

	// Token: 0x06018CAB RID: 101547 RVA: 0x007026E8 File Offset: 0x007008E8
	public bool TryExecuteSnap(Partial_RequirementPayload context, IBuffComponent opponent, Dictionary<EAttributeType, float> resultMap, SnapshotPayload snapshots)
	{
		if (!base.Check(context, opponent))
		{
			return false;
		}
		this.ExecuteContext = context;
		this.LoopLock = Singleton<Time>.Instance.Frame;
		this.OnExecuteSnap(resultMap, snapshots);
		this.PostExecuted();
		this.LoopLock = -1;
		this.ExecuteContext = null;
		return true;
	}

	// Token: 0x06018CAC RID: 101548 RVA: 0x00702736 File Offset: 0x00700936
	protected virtual void OnExecuteSnap(Dictionary<EAttributeType, float> resultMap, SnapshotPayload snapshots)
	{
		this.OnExecute(new object[]
		{
			resultMap,
			snapshots
		});
	}

	// Token: 0x06018CAD RID: 101549 RVA: 0x00702750 File Offset: 0x00700950
	protected float GetAttrValue(SnapshotPayload snapshots, EAttributeType attrId, EAttributeRefType attributeType, ESnapAttributeSourceType targetType)
	{
		IAttributeSet attrSet = this.GetAttrSet(snapshots, targetType);
		if (attrSet == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.LC, "[SnapModifier] Get attributeSet failed.", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0f;
		}
		if (attributeType == EAttributeRefType.BaseValue)
		{
			return attrSet.GetBaseValue(attrId);
		}
		return attrSet.GetCurrentValue(attrId);
	}

	// Token: 0x06018CAE RID: 101550 RVA: 0x007027A0 File Offset: 0x007009A0
	[return: Nullable(2)]
	private IAttributeSet GetAttrSet(SnapshotPayload snapshots, ESnapAttributeSourceType targetType)
	{
		IAttributeSet result;
		switch (targetType)
		{
		case ESnapAttributeSourceType.BuffMaker:
		{
			EntityHandle instigatorEntity = base.InstigatorEntity;
			IAttributeSet attributeSet;
			if (instigatorEntity == null)
			{
				attributeSet = null;
			}
			else
			{
				WorldEntity entity = instigatorEntity.Entity;
				attributeSet = ((entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null);
			}
			result = attributeSet;
			break;
		}
		case ESnapAttributeSourceType.BuffHolder:
		{
			Entity ownerEntity = base.OwnerEntity;
			result = ((ownerEntity != null) ? ownerEntity.GetComponent<BaseAttributeComponent>() : null);
			break;
		}
		case ESnapAttributeSourceType.Attacker:
			result = snapshots.AttackerSnapshot;
			break;
		case ESnapAttributeSourceType.Target:
			result = snapshots.TargetSnapshot;
			break;
		default:
			result = null;
			break;
		}
		return result;
	}

	// Token: 0x0400C14E RID: 49486
	public ESnapTargetType? TargetType;

	// Token: 0x0400C14F RID: 49487
	public bool NeedCheckCritical;
}
