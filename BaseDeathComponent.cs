using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002E65 RID: 11877
[NullableContext(1)]
[Nullable(0)]
public class BaseDeathComponent : EntityComponent
{
	// Token: 0x06018662 RID: 99938 RVA: 0x006D5621 File Offset: 0x006D3821
	protected override bool OnStart()
	{
		this.MontageComponent = base.Entity.CheckGetComponent<BaseMontageComponent>();
		this.TimeScaleComponent = base.Entity.CheckGetComponent<PawnTimeScaleComponent>();
		this.LoadDeathMontage();
		return true;
	}

	// Token: 0x06018663 RID: 99939 RVA: 0x006D564C File Offset: 0x006D384C
	public bool IsDead()
	{
		return this.IsDeadInternal;
	}

	// Token: 0x06018664 RID: 99940 RVA: 0x006D5654 File Offset: 0x006D3854
	public unsafe virtual bool ExecuteDeath(long? contextId)
	{
		if (this.IsDeadInternal)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "实体重复死亡";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Battle;
		ELogAuthor author2 = ELogAuthor.ZQR;
		string message2 = "[DeathComponent]执行角色死亡逻辑";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", base.Entity.ToString());
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "PbDataId";
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		ptr = new ValueTuple<string, object>(item, (component != null) ? new int?(component.GetPbDataId()) : null);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.IsDeadInternal = true;
		PawnTimeScaleComponent timeScaleComponent = this.TimeScaleComponent;
		if (timeScaleComponent != null)
		{
			timeScaleComponent.RemoveAllTimeScale();
		}
		return true;
	}

	// Token: 0x06018665 RID: 99941 RVA: 0x006D573F File Offset: 0x006D393F
	protected bool HasDeathMontage(ECharacterDeathMontageType montageType)
	{
		return this.DeathMontageMap.ContainsKey(montageType) || this.ReplaceDeathMontageMap.ContainsKey(montageType);
	}

	// Token: 0x06018666 RID: 99942 RVA: 0x006D575D File Offset: 0x006D395D
	[NullableContext(2)]
	protected virtual UAnimMontage GetDeathMontage(ECharacterDeathMontageType montageType)
	{
		return this.DeathMontageMap.GetValueOrDefault(montageType);
	}

	// Token: 0x06018667 RID: 99943 RVA: 0x006D576B File Offset: 0x006D396B
	[NullableContext(2)]
	protected string GetDeathMontageName(ECharacterDeathMontageType montageType)
	{
		return BaseDeathComponent.DeathMontagePathMap.GetValueOrDefault(montageType);
	}

	// Token: 0x06018668 RID: 99944 RVA: 0x006D5778 File Offset: 0x006D3978
	[NullableContext(2)]
	protected unsafe void PlayDeathMontageWithType(ECharacterDeathMontageType montageType, Action<bool> endCallback = null, long? contextId = null, bool? forceDisableAnimOptimization = null)
	{
		int? num = null;
		OrderedDictionary<int, string> orderedDictionary;
		if (this.ReplaceDeathMontageMap.TryGetValue(montageType, out orderedDictionary) && orderedDictionary.Count > 0)
		{
			if (orderedDictionary.Count > 0)
			{
				string value = orderedDictionary.GetAt(orderedDictionary.Count - 1).Value;
				if (!string.IsNullOrEmpty(value))
				{
					BaseMontageComponent montageComponent = this.MontageComponent;
					num = ((montageComponent != null) ? montageComponent.CreateTaskWithName(value, null, endCallback, -1f) : null);
				}
			}
		}
		else
		{
			UAnimMontage deathMontage = this.GetDeathMontage(montageType);
			if (deathMontage != null)
			{
				BaseMontageComponent montageComponent2 = this.MontageComponent;
				num = ((montageComponent2 != null) ? montageComponent2.CreateTaskWithMontage(deathMontage, null, endCallback, -1f) : null);
			}
		}
		if (num == null)
		{
			string item = BaseDeathComponent.DeathMontagePathMap[montageType];
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Animation;
			Entity entity = base.Entity;
			string message = "蒙太奇播放失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montageType", montageType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("path", item);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (endCallback != null)
			{
				endCallback(true);
			}
			return;
		}
		if (forceDisableAnimOptimization.GetValueOrDefault())
		{
			BaseAnimationComponent component = base.Entity.GetComponent<BaseAnimationComponent>();
			if (component != null)
			{
				component.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.Death, false);
			}
		}
		BaseMontageComponent montageComponent3 = this.MontageComponent;
		if (montageComponent3 == null)
		{
			return;
		}
		montageComponent3.PlayMontageTaskWhenReady(num.Value, 0f, contextId, -1f);
	}

	// Token: 0x06018669 RID: 99945 RVA: 0x006D58E8 File Offset: 0x006D3AE8
	[NullableContext(2)]
	protected bool TryPlayDeathMontageWithTag(Action<bool> endCallback = null, long? contextId = null, bool? forceDisableAnimOptimization = null)
	{
		int? num = null;
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component != null && this.TagDeathMontageConfigMap.Count > 0)
		{
			foreach (ValueTuple<int, string, string> valueTuple in this.TagDeathMontageConfigMap.Values)
			{
				if (component.HasTag(valueTuple.Item1))
				{
					BaseMontageComponent montageComponent = this.MontageComponent;
					num = ((montageComponent != null) ? montageComponent.CreateTaskWithName(valueTuple.Item3, null, endCallback, -1f) : null);
					break;
				}
			}
		}
		if (num != null)
		{
			if (forceDisableAnimOptimization.GetValueOrDefault())
			{
				BaseAnimationComponent component2 = base.Entity.GetComponent<BaseAnimationComponent>();
				if (component2 != null)
				{
					component2.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.Death, false);
				}
			}
			BaseMontageComponent montageComponent2 = this.MontageComponent;
			if (montageComponent2 != null)
			{
				montageComponent2.PlayMontageTaskWhenReady(num.Value, 0f, contextId, -1f);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0601866A RID: 99946 RVA: 0x006D59E8 File Offset: 0x006D3BE8
	public int ReplaceDeathMontage(ECharacterDeathMontageType montageType, string montageName)
	{
		OrderedDictionary<int, string> orderedDictionary;
		if (!this.ReplaceDeathMontageMap.TryGetValue(montageType, out orderedDictionary))
		{
			orderedDictionary = (this.ReplaceDeathMontageMap[montageType] = new OrderedDictionary<int, string>());
		}
		OrderedDictionary<int, string> orderedDictionary2 = orderedDictionary;
		int num = this.ReplaceHandleId + 1;
		this.ReplaceHandleId = num;
		orderedDictionary2.TryAdd(num, montageName);
		return this.ReplaceHandleId;
	}

	// Token: 0x0601866B RID: 99947 RVA: 0x006D5A38 File Offset: 0x006D3C38
	public void ResetDeathMontage(int handle)
	{
		foreach (OrderedDictionary<int, string> orderedDictionary in this.ReplaceDeathMontageMap.Values)
		{
			orderedDictionary.Remove(handle);
		}
	}

	// Token: 0x0601866C RID: 99948 RVA: 0x006D5A90 File Offset: 0x006D3C90
	public int RegisterTagDeathMontage(int tagId, string tagName, string montageName)
	{
		int num = this.TagReplaceHandleId + 1;
		this.TagReplaceHandleId = num;
		int num2 = num;
		this.TagDeathMontageConfigMap[num2] = new ValueTuple<int, string, string>(tagId, tagName, montageName);
		return num2;
	}

	// Token: 0x0601866D RID: 99949 RVA: 0x006D5AC4 File Offset: 0x006D3CC4
	public unsafe void UnregisterTagDeathMontage(int tagId, string montageName)
	{
		int? num = null;
		foreach (KeyValuePair<int, ValueTuple<int, string, string>> keyValuePair in this.TagDeathMontageConfigMap)
		{
			ValueTuple<int, string, string> value = keyValuePair.Value;
			if (value.Item1 == tagId && value.Item3 == montageName)
			{
				num = new int?(keyValuePair.Key);
				break;
			}
		}
		if (num != null)
		{
			this.TagDeathMontageConfigMap.Remove(num.Value);
		}
		if (this.TagDeathMontageConfigMap.Count > 0)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
			Entity entity = base.Entity;
			string message = "[DeathComponent]标签蒙太奇配置Map未正确清空,可能同时激活了多个状态机BindState:替换死亡动画_Tag";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("剩余数量", this.TagDeathMontageConfigMap.Count);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			int num2 = 0;
			foreach (ValueTuple<int, string, string> valueTuple2 in this.TagDeathMontageConfigMap.Values)
			{
				num2++;
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
				Entity entity2 = base.Entity;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[剩余配置");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TagId", valueTuple2.Item1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TagName", valueTuple2.Item2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MontageName", valueTuple2.Item3);
				instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			this.TagDeathMontageConfigMap.Clear();
		}
	}

	// Token: 0x0601866E RID: 99950 RVA: 0x006D5CC0 File Offset: 0x006D3EC0
	private void LoadDeathMontage()
	{
		foreach (KeyValuePair<ECharacterDeathMontageType, string> keyValuePair in BaseDeathComponent.DeathMontagePathMap)
		{
			ECharacterDeathMontageType echaracterDeathMontageType;
			string text;
			keyValuePair.Deconstruct(out echaracterDeathMontageType, out text);
			ECharacterDeathMontageType key = echaracterDeathMontageType;
			string name = text;
			BaseMontageComponent montageComponent = this.MontageComponent;
			UAnimMontage uanimMontage = (montageComponent != null) ? montageComponent.GetMontageByName(name, true, false) : null;
			if (uanimMontage != null)
			{
				this.DeathMontageMap[key] = uanimMontage;
			}
		}
	}

	// Token: 0x0601866F RID: 99951 RVA: 0x006D5D48 File Offset: 0x006D3F48
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseDeathComponent baseDeathComponent = (BaseDeathComponent)componentTemplate;
		if (base.CanResetComponentProperty("IsDeadInternal"))
		{
			this.IsDeadInternal = baseDeathComponent.IsDeadInternal;
		}
		if (base.CanResetComponentProperty("MontageComponent"))
		{
			if (baseDeathComponent.MontageComponent == null)
			{
				this.MontageComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMontageComponent>(this.MontageComponent), "MontageComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TimeScaleComponent"))
		{
			if (baseDeathComponent.TimeScaleComponent == null)
			{
				this.TimeScaleComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComponent), "TimeScaleComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DeathMontageMap") && baseDeathComponent.DeathMontageMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ECharacterDeathMontageType, UAnimMontage>>(this.DeathMontageMap), "DeathMontageMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ReplaceHandleId"))
		{
			this.ReplaceHandleId = baseDeathComponent.ReplaceHandleId;
		}
		if (base.CanResetComponentProperty("ReplaceDeathMontageMap") && baseDeathComponent.ReplaceDeathMontageMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ECharacterDeathMontageType, OrderedDictionary<int, string>>>(this.ReplaceDeathMontageMap), "ReplaceDeathMontageMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagDeathMontageConfigMap") && baseDeathComponent.TagDeathMontageConfigMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<OrderedDictionary<int, ValueTuple<int, string, string>>>(this.TagDeathMontageConfigMap), "TagDeathMontageConfigMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagReplaceHandleId"))
		{
			this.TagReplaceHandleId = baseDeathComponent.TagReplaceHandleId;
		}
		return true;
	}

	// Token: 0x0400BB59 RID: 47961
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<ECharacterDeathMontageType, string> DeathMontagePathMap = new Dictionary<ECharacterDeathMontageType, string>
	{
		{
			ECharacterDeathMontageType.Die,
			"AM_Death"
		},
		{
			ECharacterDeathMontageType.DieInWater,
			"AM_Death_InWater"
		},
		{
			ECharacterDeathMontageType.DieInAir,
			"AM_Death_InAir"
		},
		{
			ECharacterDeathMontageType.DieFalling,
			"AM_Death_Falling"
		}
	};

	// Token: 0x0400BB5A RID: 47962
	protected bool IsDeadInternal;

	// Token: 0x0400BB5B RID: 47963
	[Nullable(2)]
	protected BaseMontageComponent MontageComponent;

	// Token: 0x0400BB5C RID: 47964
	[Nullable(2)]
	protected PawnTimeScaleComponent TimeScaleComponent;

	// Token: 0x0400BB5D RID: 47965
	private readonly Dictionary<ECharacterDeathMontageType, UAnimMontage> DeathMontageMap = new Dictionary<ECharacterDeathMontageType, UAnimMontage>();

	// Token: 0x0400BB5E RID: 47966
	private int ReplaceHandleId;

	// Token: 0x0400BB5F RID: 47967
	private readonly Dictionary<ECharacterDeathMontageType, OrderedDictionary<int, string>> ReplaceDeathMontageMap = new Dictionary<ECharacterDeathMontageType, OrderedDictionary<int, string>>();

	// Token: 0x0400BB60 RID: 47968
	[TupleElementNames(new string[]
	{
		"TagId",
		"TagName",
		"MontageName"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	private readonly OrderedDictionary<int, ValueTuple<int, string, string>> TagDeathMontageConfigMap = new OrderedDictionary<int, ValueTuple<int, string, string>>();

	// Token: 0x0400BB61 RID: 47969
	private int TagReplaceHandleId;
}
