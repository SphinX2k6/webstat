using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Utils;

// Token: 0x02002FC5 RID: 12229
[NullableContext(2)]
[Nullable(0)]
public abstract class Trigger
{
	// Token: 0x1700218F RID: 8591
	// (get) Token: 0x06018EE3 RID: 102115 RVA: 0x007102E7 File Offset: 0x0070E4E7
	// (set) Token: 0x06018EE4 RID: 102116 RVA: 0x007102EF File Offset: 0x0070E4EF
	public ITriggerConfig Config { get; set; }

	// Token: 0x17002190 RID: 8592
	// (get) Token: 0x06018EE5 RID: 102117 RVA: 0x007102F8 File Offset: 0x0070E4F8
	// (set) Token: 0x06018EE6 RID: 102118 RVA: 0x00710300 File Offset: 0x0070E500
	public int Handle { get; set; }

	// Token: 0x17002191 RID: 8593
	// (get) Token: 0x06018EE7 RID: 102119 RVA: 0x00710309 File Offset: 0x0070E509
	// (set) Token: 0x06018EE8 RID: 102120 RVA: 0x00710311 File Offset: 0x0070E511
	public CharacterTriggerComponent OwnerTriggerComp { get; set; }

	// Token: 0x17002192 RID: 8594
	// (get) Token: 0x06018EE9 RID: 102121 RVA: 0x0071031A File Offset: 0x0070E51A
	// (set) Token: 0x06018EEA RID: 102122 RVA: 0x00710322 File Offset: 0x0070E522
	public TTriggerCallback Callback { get; set; }

	// Token: 0x17002193 RID: 8595
	// (get) Token: 0x06018EEB RID: 102123 RVA: 0x0071032B File Offset: 0x0070E52B
	// (set) Token: 0x06018EEC RID: 102124 RVA: 0x00710333 File Offset: 0x0070E533
	public TTriggerChecker Checker { get; set; }

	// Token: 0x06018EED RID: 102125 RVA: 0x0071033C File Offset: 0x0070E53C
	public Trigger(ITriggerConfig config, int handle, CharacterTriggerComponent ownerTriggerComp, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> functions, TTriggerCallback callback, TTriggerChecker checker)
	{
		if (config == null)
		{
			throw new Exception("找不到对应的Trigger配置");
		}
		this.Config = config;
		this.Handle = handle;
		this.OwnerTriggerComp = ownerTriggerComp;
		this.Callback = callback;
		this.Checker = checker;
		ETriggerEvent triggerType;
		if (!Enum.TryParse<ETriggerEvent>((config.Type == "temp_hittrigger1.0") ? "temp_hittrigger1_0" : config.Type, out triggerType))
		{
			throw new Exception("找不到对应的Trigger触发器类型");
		}
		this.TriggerType = triggerType;
		this.ExecuteType = config.ExecuteType;
		this.LastFormulaResult = false;
		string formula = config.Formula;
		Dictionary<string, Func<TFormulaValue[], TFormulaValue>> builtinFunctions = new Dictionary<string, Func<TFormulaValue[], TFormulaValue>>(functions);
		this.Formula = new Formula(formula).SetBuiltinFunctions(builtinFunctions).AddBuiltinFunction("Accumulate", delegate(TFormulaValue[] args)
		{
			float num = (float)args[0];
			float num2 = (float)args[1];
			if (args.Length >= 3 && !(bool)args[2])
			{
				return TFormulaValue.FromBool(false);
			}
			this.accumulateValue += (double)num;
			if (this.accumulateValue >= (double)num2)
			{
				this.accumulateValue = 0.0;
				return TFormulaValue.FromBool(true);
			}
			return TFormulaValue.FromBool(false);
		}).SetDefaultParams(config.Params).SetDefaultParam("Owner", TFormulaValue.FromEntity((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null));
	}

	// Token: 0x06018EEE RID: 102126 RVA: 0x00710434 File Offset: 0x0070E634
	private static TFormulaValue FromJsonElement(JsonElement json)
	{
		switch (json.ValueKind)
		{
		case JsonValueKind.String:
			return TFormulaValue.FromString(json.GetString() ?? string.Empty);
		case JsonValueKind.Number:
		{
			int value;
			if (json.TryGetInt32(out value))
			{
				return TFormulaValue.FromInt(value);
			}
			long value2;
			if (json.TryGetInt64(out value2))
			{
				return TFormulaValue.FromLong(value2);
			}
			float value3;
			if (json.TryGetSingle(out value3))
			{
				return TFormulaValue.FromFloat(value3);
			}
			break;
		}
		case JsonValueKind.True:
		case JsonValueKind.False:
			return TFormulaValue.FromBool(json.GetBoolean());
		}
		return default(TFormulaValue);
	}

	// Token: 0x06018EEF RID: 102127 RVA: 0x007104C6 File Offset: 0x0070E6C6
	public bool CanContinuousTrigger()
	{
		return this.ExecuteType != EExecuteType.DisableContinuousTrigger;
	}

	// Token: 0x06018EF0 RID: 102128 RVA: 0x007104D4 File Offset: 0x0070E6D4
	public unsafe void EvaluateAndExecute([Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, TFormulaValue> extraParams = null)
	{
		bool flag;
		if (!this.Formula.Evaluate(extraParams, null).TryGetBool(out flag) || !flag)
		{
			this.LastFormulaResult = false;
			return;
		}
		if (!this.CanContinuousTrigger() && this.LastFormulaResult)
		{
			return;
		}
		this.LastFormulaResult = true;
		try
		{
			if (this.TryLock())
			{
				TTriggerCallback callback = this.Callback;
				if (callback != null)
				{
					callback(this.Formula.Params, extraParams);
				}
				this.Unlock();
			}
			else
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.PassiveSkill;
				CharacterTriggerComponent ownerTriggerComp = this.OwnerTriggerComp;
				Entity entity = (ownerTriggerComp != null) ? ownerTriggerComp.Entity : null;
				string message = "被动技能不能在同一个调用栈中递归触发";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("触发器", this.GetDebugName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Formula", this.Formula.GetTotalFormulaString());
				instance.Error(flag2, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		catch (Exception ex)
		{
			this.Unlock();
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.PassiveSkill;
			CharacterTriggerComponent ownerTriggerComp2 = this.OwnerTriggerComp;
			Entity entity2 = (ownerTriggerComp2 != null) ? ownerTriggerComp2.Entity : null;
			string message2 = "触发器回调函数执行错误";
			Exception e = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("触发器", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Formula", this.Formula.GetTotalFormulaString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("错误信息", ex.Message);
			instance2.ErrorWithStack(flag3, entity2, message2, e, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
	}

	// Token: 0x06018EF1 RID: 102129 RVA: 0x00710670 File Offset: 0x0070E870
	protected bool TryLock()
	{
		if (this.IterationLock == Singleton<Time>.Instance.Frame)
		{
			return false;
		}
		this.IterationLock = Singleton<Time>.Instance.Frame;
		return true;
	}

	// Token: 0x06018EF2 RID: 102130 RVA: 0x00710697 File Offset: 0x0070E897
	protected void Unlock()
	{
		this.IterationLock = -1;
	}

	// Token: 0x06018EF3 RID: 102131 RVA: 0x007106A0 File Offset: 0x0070E8A0
	[NullableContext(1)]
	public virtual void OnInitParams(string[] triggerParams)
	{
	}

	// Token: 0x06018EF4 RID: 102132 RVA: 0x007106A2 File Offset: 0x0070E8A2
	public void SetActive(bool isActive)
	{
		if (this.IsActive == isActive)
		{
			return;
		}
		this.IsActive = isActive;
		if (isActive)
		{
			this.OnActive();
			return;
		}
		this.OnInactive();
	}

	// Token: 0x06018EF5 RID: 102133
	protected abstract void OnActive();

	// Token: 0x06018EF6 RID: 102134
	protected abstract void OnInactive();

	// Token: 0x06018EF7 RID: 102135 RVA: 0x007106C5 File Offset: 0x0070E8C5
	public virtual void Destroy()
	{
		this.SetActive(false);
		Formula formula = this.Formula;
		if (formula != null)
		{
			formula.Dispose();
		}
		this.OwnerTriggerComp = null;
		this.Config = null;
		this.ExecuteType = EExecuteType.Default;
		this.LastFormulaResult = false;
		this.Callback = null;
	}

	// Token: 0x06018EF8 RID: 102136 RVA: 0x00710702 File Offset: 0x0070E902
	[NullableContext(1)]
	public string GetLastFormulaResult()
	{
		return this.Formula.GetLastResult();
	}

	// Token: 0x06018EF9 RID: 102137 RVA: 0x0071070F File Offset: 0x0070E90F
	[NullableContext(1)]
	public void SetDebugName(string name)
	{
		this.DebugName = name;
	}

	// Token: 0x06018EFA RID: 102138 RVA: 0x00710718 File Offset: 0x0070E918
	[NullableContext(1)]
	public virtual string GetDebugName()
	{
		return this.DebugName ?? this.TriggerType.ToString();
	}

	// Token: 0x06018EFB RID: 102139 RVA: 0x00710735 File Offset: 0x0070E935
	[NullableContext(1)]
	public virtual string GetDebugTriggerType()
	{
		return this.TriggerType.ToString();
	}

	// Token: 0x06018EFC RID: 102140 RVA: 0x00710748 File Offset: 0x0070E948
	[NullableContext(1)]
	protected static string GetDamageCalculationTypeText(ECalculationType calculationType)
	{
		switch (calculationType)
		{
		case ECalculationType.Hurt:
			return "伤害";
		case ECalculationType.Heal:
			return "治疗";
		case ECalculationType.Cost:
			return "Cost";
		default:
			return calculationType.ToString();
		}
	}

	// Token: 0x06018EFD RID: 102141 RVA: 0x0071077D File Offset: 0x0070E97D
	public string GetDebugFormulaString()
	{
		return this.Formula.GetTotalFormulaString();
	}

	// Token: 0x06018EFE RID: 102142 RVA: 0x0071078C File Offset: 0x0070E98C
	public static Trigger Create(ETriggerEvent triggerType, ITriggerConfig config, int handle, CharacterTriggerComponent ownerTriggerComp, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> functions, TTriggerCallback callback, TTriggerChecker checker)
	{
		switch (triggerType)
		{
		case ETriggerEvent.BeHitTrigger:
			return new BeHitTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.HitTrigger:
			return new HitTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.AttributeChangedTrigger:
			return new AttributeChangedTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.TeamAttributeChangeTrigger:
			return new TeamAttributeChangedTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.TagTrigger:
			return new TagTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.LimitDodgeTrigger:
			return new LimitDodgeTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.SkillTrigger:
			return new SkillTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.DamageTrigger:
			return new DamageTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.BeDamageTrigger:
			return new BeDamageTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.GameplayEventTrigger:
			return new GameplayEventTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.temp_hittrigger1_0:
			return new HitTriggerIncludingVision(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.GlobalDamageTrigger:
			return new GlobalDamageTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.QteGoBattleTrigger:
			return new QteGoBattleTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.QteGoDownTrigger:
			return new QteGoDownTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.DeathTrigger:
			return new DeathTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.KillTrigger:
			return new KillTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.BuffInstigatorTrigger:
			return new BuffInstigatorTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.BuffVictimTrigger:
			return new BuffVictimTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.TagStackTrigger:
			return new TagStackTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.VisionTrigger:
			return new VisionTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.DamageIdTrigger:
			return new DamageIdTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.BuffAddFailureTrigger:
			return new BuffAddFailureTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.ShieldTrigger:
			return new ShieldTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.ShowTargetTrigger:
			return new ShowTargetTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.RegionDetectTrigger:
			return new RegionDetectTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.BreakWeaknessTrigger:
			return new BreakWeaknessTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.EnterBattleTrigger:
			return new EnterBattleTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.LeaveBattleTrigger:
			return new LeaveBattleTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.ClearShowTargetTrigger:
			return new ClearShowTargetTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		case ETriggerEvent.BuffStackInstigatorTrigger:
			return new BuffStackInstigatorTrigger(config, handle, ownerTriggerComp, functions, callback, checker);
		default:
			return null;
		}
	}

	// Token: 0x0400C2DF RID: 49887
	[Nullable(1)]
	private readonly Formula Formula;

	// Token: 0x0400C2E0 RID: 49888
	protected ETriggerEvent TriggerType;

	// Token: 0x0400C2E1 RID: 49889
	private bool IsActive;

	// Token: 0x0400C2E2 RID: 49890
	protected EExecuteType ExecuteType;

	// Token: 0x0400C2E3 RID: 49891
	private bool LastFormulaResult;

	// Token: 0x0400C2E4 RID: 49892
	private double accumulateValue;

	// Token: 0x0400C2EA RID: 49898
	public int IterationLock = -1;

	// Token: 0x0400C2EB RID: 49899
	protected string DebugName;
}
