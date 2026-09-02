using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F60 RID: 12128
[NullableContext(1)]
[Nullable(0)]
public class SnapModifier : IStaticVariableResetter
{
	// Token: 0x06018C9B RID: 101531 RVA: 0x007023BC File Offset: 0x007005BC
	static SnapModifier()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SnapModifier.CreateStaticDefaultValue), new Action(SnapModifier.ResetStaticDefaultValue));
	}

	// Token: 0x17002188 RID: 8584
	// (get) Token: 0x06018C9C RID: 101532 RVA: 0x007023DB File Offset: 0x007005DB
	private static EExtraEffectId[] SnapModifyEffectIds
	{
		get
		{
			return SnapModifier._snapModifyEffectIds;
		}
	}

	// Token: 0x06018C9D RID: 101533 RVA: 0x007023E2 File Offset: 0x007005E2
	public static void CreateStaticDefaultValue()
	{
		SnapModifier._snapModifyEffectIds = new EExtraEffectId[]
		{
			EExtraEffectId.ModifySnapshotBeforeCalculation,
			EExtraEffectId.ShieldModifySnapshot
		};
		SnapModifier._resultMapPool = new List<Dictionary<EAttributeType, float>>();
		SnapModifier._effectListPool = new List<List<SnapModifyBuffEffect>>();
	}

	// Token: 0x06018C9E RID: 101534 RVA: 0x0070240C File Offset: 0x0070060C
	public static void ResetStaticDefaultValue()
	{
		SnapModifier._snapModifyEffectIds = null;
		SnapModifier._resultMapPool = null;
		SnapModifier._effectListPool = null;
	}

	// Token: 0x06018C9F RID: 101535 RVA: 0x00702420 File Offset: 0x00700620
	private static Dictionary<EAttributeType, float> RentResultMap()
	{
		List<Dictionary<EAttributeType, float>> resultMapPool = SnapModifier._resultMapPool;
		if (resultMapPool == null || resultMapPool.Count == 0)
		{
			return new Dictionary<EAttributeType, float>();
		}
		Dictionary<EAttributeType, float> result = resultMapPool[resultMapPool.Count - 1];
		resultMapPool.RemoveAt(resultMapPool.Count - 1);
		return result;
	}

	// Token: 0x06018CA0 RID: 101536 RVA: 0x00702460 File Offset: 0x00700660
	private static void ReturnResultMap(Dictionary<EAttributeType, float> map)
	{
		map.Clear();
		List<Dictionary<EAttributeType, float>> resultMapPool = SnapModifier._resultMapPool;
		if (resultMapPool == null)
		{
			return;
		}
		resultMapPool.Add(map);
	}

	// Token: 0x06018CA1 RID: 101537 RVA: 0x00702478 File Offset: 0x00700678
	private static List<SnapModifyBuffEffect> RentEffectList()
	{
		List<List<SnapModifyBuffEffect>> effectListPool = SnapModifier._effectListPool;
		if (effectListPool == null || effectListPool.Count == 0)
		{
			return new List<SnapModifyBuffEffect>();
		}
		List<SnapModifyBuffEffect> result = effectListPool[effectListPool.Count - 1];
		effectListPool.RemoveAt(effectListPool.Count - 1);
		return result;
	}

	// Token: 0x06018CA2 RID: 101538 RVA: 0x007024B8 File Offset: 0x007006B8
	private static void ReturnEffectList(List<SnapModifyBuffEffect> list)
	{
		list.Clear();
		List<List<SnapModifyBuffEffect>> effectListPool = SnapModifier._effectListPool;
		if (effectListPool == null)
		{
			return;
		}
		effectListPool.Add(list);
	}

	// Token: 0x06018CA3 RID: 101539 RVA: 0x007024D0 File Offset: 0x007006D0
	private static void PrepareModify(RequirementPayload requirements, SnapshotPayload snapshots, bool isCheckCritical)
	{
		ExtraEffectManager buffEffectManager = snapshots.Attacker.OwnerBuffComponent.BuffEffectManager;
		ExtraEffectManager buffEffectManager2 = snapshots.Target.OwnerBuffComponent.BuffEffectManager;
		bool flag = buffEffectManager.HasAnyById(SnapModifier.SnapModifyEffectIds);
		bool flag2 = buffEffectManager2.HasAnyById(SnapModifier.SnapModifyEffectIds);
		if (!flag && !flag2)
		{
			return;
		}
		Dictionary<EAttributeType, float> dictionary = SnapModifier.RentResultMap();
		Dictionary<EAttributeType, float> dictionary2 = SnapModifier.RentResultMap();
		if (flag)
		{
			SnapModifier.CalculateModifyMap(requirements, snapshots, dictionary, buffEffectManager, ESnapTargetType.AttackerToAttacker, isCheckCritical);
			SnapModifier.CalculateModifyMap(requirements, snapshots, dictionary2, buffEffectManager, ESnapTargetType.AttackerToTarget, isCheckCritical);
		}
		if (flag2)
		{
			SnapModifier.CalculateModifyMap(requirements, snapshots, dictionary, buffEffectManager2, ESnapTargetType.TargetToAttacker, isCheckCritical);
			SnapModifier.CalculateModifyMap(requirements, snapshots, dictionary2, buffEffectManager2, ESnapTargetType.TargetToTarget, isCheckCritical);
		}
		SnapModifier.ModifySnapshot(dictionary, snapshots.AttackerSnapshot);
		SnapModifier.ModifySnapshot(dictionary2, snapshots.TargetSnapshot);
		SnapModifier.ReturnResultMap(dictionary);
		SnapModifier.ReturnResultMap(dictionary2);
	}

	// Token: 0x06018CA4 RID: 101540 RVA: 0x0070258A File Offset: 0x0070078A
	public static void PreCriticalModify(RequirementPayload requirements, SnapshotPayload snapshots)
	{
		SnapModifier.PrepareModify(requirements, snapshots, false);
	}

	// Token: 0x06018CA5 RID: 101541 RVA: 0x00702594 File Offset: 0x00700794
	public static void PostCriticalModify(RequirementPayload requirements, SnapshotPayload snapshots)
	{
		SnapModifier.PrepareModify(requirements, snapshots, true);
	}

	// Token: 0x06018CA6 RID: 101542 RVA: 0x007025A0 File Offset: 0x007007A0
	private static void CalculateModifyMap(RequirementPayload requires, SnapshotPayload snapshots, Dictionary<EAttributeType, float> resultMap, ExtraEffectManager holder, ESnapTargetType targetType, bool isCheckCritical)
	{
		IBuffComponent opponent = null;
		if (targetType > ESnapTargetType.AttackerToTarget)
		{
			if (targetType - ESnapTargetType.TargetToAttacker <= 1)
			{
				opponent = snapshots.Attacker.OwnerBuffComponent;
			}
		}
		else
		{
			opponent = snapshots.Target.OwnerBuffComponent;
		}
		List<SnapModifyBuffEffect> list = SnapModifier.RentEffectList();
		holder.CollectById<SnapModifyBuffEffect>(SnapModifier.SnapModifyEffectIds, list);
		foreach (SnapModifyBuffEffect snapModifyBuffEffect in list)
		{
			ESnapTargetType? targetType2 = snapModifyBuffEffect.TargetType;
			if ((targetType2.GetValueOrDefault() == targetType & targetType2 != null) && snapModifyBuffEffect.NeedCheckCritical == isCheckCritical)
			{
				snapModifyBuffEffect.TryExecuteSnap(requires, opponent, resultMap, snapshots);
			}
		}
		SnapModifier.ReturnEffectList(list);
	}

	// Token: 0x06018CA7 RID: 101543 RVA: 0x00702660 File Offset: 0x00700860
	private static void ModifySnapshot(Dictionary<EAttributeType, float> resultMap, AttributeSnapshot snapshot)
	{
		foreach (KeyValuePair<EAttributeType, float> keyValuePair in resultMap)
		{
			EAttributeType eattributeType;
			float num;
			keyValuePair.Deconstruct(out eattributeType, out num);
			EAttributeType eattributeType2 = eattributeType;
			float num2 = num;
			snapshot.CurrentValues[(int)eattributeType2] += num2;
		}
	}

	// Token: 0x0400C14B RID: 49483
	[Nullable(2)]
	private static EExtraEffectId[] _snapModifyEffectIds;

	// Token: 0x0400C14C RID: 49484
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<Dictionary<EAttributeType, float>> _resultMapPool;

	// Token: 0x0400C14D RID: 49485
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static List<List<SnapModifyBuffEffect>> _effectListPool;
}
