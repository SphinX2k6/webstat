using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FDA RID: 12250
[NullableContext(1)]
[Nullable(0)]
public class VisionTrigger : Trigger
{
	// Token: 0x06018F85 RID: 102277 RVA: 0x00714598 File Offset: 0x00712798
	[NullableContext(2)]
	public VisionTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F86 RID: 102278 RVA: 0x007145C8 File Offset: 0x007127C8
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.VisionIds.Clear();
		this.AllVision = false;
		this.TriggerCount = 0;
		this.TriggerCountMap.Clear();
		string[] array = ((triggerParams.Length > 1) ? triggerParams[1] : string.Empty).Split('#', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			int num;
			if (int.TryParse(array[i], out num))
			{
				this.VisionIds.Add(num);
				if (num == -1)
				{
					this.AllVision = true;
				}
			}
		}
		this.EachVisionMaxTriggerCount = Convert.ToInt32((triggerParams.Length > 2) ? triggerParams[2] : "-1");
	}

	// Token: 0x06018F87 RID: 102279 RVA: 0x00714678 File Offset: 0x00712878
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !Singleton<EventSystem>.Instance.HasWithTarget<int>(target, EEventName.ActivateAbilityVision, new Action<int>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int>(target, EEventName.ActivateAbilityVision, new Action<int>(this.OnEvent));
		}
	}

	// Token: 0x06018F88 RID: 102280 RVA: 0x007146E4 File Offset: 0x007128E4
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && Singleton<EventSystem>.Instance.HasWithTarget<int>(target, EEventName.ActivateAbilityVision, new Action<int>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int>(target, EEventName.ActivateAbilityVision, new Action<int>(this.OnEvent));
		}
	}

	// Token: 0x06018F89 RID: 102281 RVA: 0x00714750 File Offset: 0x00712950
	private void OnEvent(int visionId)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		if (!this.AllVision)
		{
			bool flag = false;
			for (int i = 0; i < this.VisionIds.Count; i++)
			{
				if (this.VisionIds[i] == visionId)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
		}
		int num2;
		int num = this.TriggerCountMap.TryGetValue(visionId, out num2) ? num2 : 0;
		this.TriggerCountMap[visionId] = num + 1;
		if (this.EachVisionMaxTriggerCount < 0 || num < this.EachVisionMaxTriggerCount)
		{
			this.TriggerCount++;
			Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
			dictionary["TriggerCount"] = this.TriggerCount;
			base.EvaluateAndExecute(dictionary);
		}
	}

	// Token: 0x06018F8A RID: 102282 RVA: 0x00714810 File Offset: 0x00712A10
	public override string GetDebugTriggerType()
	{
		string value = string.Join<int>(",", this.VisionIds);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
			defaultInterpolatedStringHandler.AppendLiteral("自身声骸");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("触发，每幻象最多触发");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.EachVisionMaxTriggerCount);
			defaultInterpolatedStringHandler.AppendLiteral("次");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case ETriggerTargetType.LocalFormation:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 2);
			defaultInterpolatedStringHandler.AppendLiteral("小队任意角色声骸");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("触发，每幻象最多触发");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.EachVisionMaxTriggerCount);
			defaultInterpolatedStringHandler.AppendLiteral("次");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case ETriggerTargetType.AllFormation:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 2);
			defaultInterpolatedStringHandler.AppendLiteral("全队任意角色声骸");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("触发，每幻象最多触发");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.EachVisionMaxTriggerCount);
			defaultInterpolatedStringHandler.AppendLiteral("次");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case ETriggerTargetType.Enemy:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
			defaultInterpolatedStringHandler.AppendLiteral("敌人声骸");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("触发，每幻象最多触发");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.EachVisionMaxTriggerCount);
			defaultInterpolatedStringHandler.AppendLiteral("次,暂未实现");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C316 RID: 49942
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C317 RID: 49943
	protected readonly List<int> VisionIds = new List<int>();

	// Token: 0x0400C318 RID: 49944
	protected bool AllVision;

	// Token: 0x0400C319 RID: 49945
	protected int TriggerCount;

	// Token: 0x0400C31A RID: 49946
	protected int EachVisionMaxTriggerCount = -1;

	// Token: 0x0400C31B RID: 49947
	protected readonly Dictionary<int, int> TriggerCountMap = new Dictionary<int, int>();
}
