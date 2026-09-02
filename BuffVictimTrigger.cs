using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FD9 RID: 12249
[NullableContext(1)]
[Nullable(0)]
public class BuffVictimTrigger : Trigger
{
	// Token: 0x06018F7E RID: 102270 RVA: 0x007140C2 File Offset: 0x007122C2
	[NullableContext(2)]
	public BuffVictimTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F7F RID: 102271 RVA: 0x007140E0 File Offset: 0x007122E0
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.ListenBuffIds.Clear();
		for (int i = 1; i < triggerParams.Length; i++)
		{
			string[] array = triggerParams[i].Split('#', StringSplitOptions.None);
			if (array.Length >= 3)
			{
				int direction = Convert.ToInt32(array[0]);
				int threshold = Convert.ToInt32(array[2]);
				if (Convert.ToInt32((array.Length > 3) ? array[3] : "0") == 0)
				{
					long buffId = Convert.ToInt64(array[1]);
					this.AddBuffIdToListen(buffId, direction, threshold);
				}
				else
				{
					foreach (long buffId2 in BuffController.GetBuffIdsByGroup(Convert.ToInt32(array[1])))
					{
						this.AddBuffIdToListen(buffId2, direction, threshold);
					}
				}
			}
		}
	}

	// Token: 0x06018F80 RID: 102272 RVA: 0x007141AC File Offset: 0x007123AC
	private void AddBuffIdToListen(long buffId, int direction, int threshold)
	{
		List<ValueTuple<int, int>> list;
		if (!this.ListenBuffIds.TryGetValue(buffId, out list))
		{
			list = new List<ValueTuple<int, int>>();
			this.ListenBuffIds[buffId] = list;
		}
		list.Add(new ValueTuple<int, int>(direction, threshold));
	}

	// Token: 0x06018F81 RID: 102273 RVA: 0x007141EC File Offset: 0x007123EC
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds.Keys)
			{
				AbilityEvent.Instance.Add(target, EAbilityEventName.BuffStackChanged, key, new Action<long, int, int, Entity>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F82 RID: 102274 RVA: 0x00714278 File Offset: 0x00712478
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds.Keys)
			{
				AbilityEvent.Instance.Remove(target, EAbilityEventName.BuffStackChanged, key, new Action<long, int, int, Entity>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F83 RID: 102275 RVA: 0x00714304 File Offset: 0x00712504
	private void OnEvent(long buffId, int oldStack, int newStack, Entity victim)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		List<ValueTuple<int, int>> list;
		if (!this.ListenBuffIds.TryGetValue(buffId, out list))
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < list.Count; i++)
		{
			int item = list[i].Item1;
			int item2 = list[i].Item2;
			if ((item == 0 && newStack >= item2 && oldStack < item2) || (item == 1 && newStack <= item2 && oldStack > item2) || (item == 2 && newStack >= item2) || (item == 3 && newStack <= item2))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["BuffId"] = buffId;
		dictionary["OldStack"] = oldStack;
		dictionary["NewStack"] = newStack;
		dictionary["Victim"] = victim;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F84 RID: 102276 RVA: 0x007143EC File Offset: 0x007125EC
	public override string GetDebugTriggerType()
	{
		string[] array = new string[]
		{
			"增加到",
			"减少到",
			"大于等于",
			"小于等于"
		};
		List<string> list = new List<string>();
		foreach (KeyValuePair<long, List<ValueTuple<int, int>>> keyValuePair in this.ListenBuffIds)
		{
			List<string> list2 = new List<string>();
			for (int i = 0; i < keyValuePair.Value.Count; i++)
			{
				ValueTuple<int, int> valueTuple = keyValuePair.Value[i];
				List<string> list3 = list2;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted(array[valueTuple.Item1]);
				defaultInterpolatedStringHandler.AppendFormatted<int>(valueTuple.Item2);
				defaultInterpolatedStringHandler.AppendLiteral("层");
				list3.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			list.Add(keyValuePair.Key.ToString() + string.Join("或", list2));
		}
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身buff" + string.Join("、", list) + "时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色buff" + string.Join("、", list) + "层数变化时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色buff" + string.Join("、", list) + "层数变化时触发";
		case ETriggerTargetType.Enemy:
			return "敌人buff" + string.Join("、", list) + "层数变化时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C314 RID: 49940
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C315 RID: 49941
	[Nullable(new byte[]
	{
		1,
		1,
		0
	})]
	protected readonly Dictionary<long, List<ValueTuple<int, int>>> ListenBuffIds = new Dictionary<long, List<ValueTuple<int, int>>>();

	// Token: 0x0200934A RID: 37706
	[NullableContext(0)]
	protected enum EBuffVictimListenIdType
	{
		// Token: 0x04031072 RID: 200818
		BuffId,
		// Token: 0x04031073 RID: 200819
		BuffGroupId
	}
}
