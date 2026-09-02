using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Config;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002EC5 RID: 11973
[NullableContext(1)]
[Nullable(0)]
public class CharacterPassiveSkillCustomAction : IStaticVariableResetter
{
	// Token: 0x06018979 RID: 100729 RVA: 0x006EC55A File Offset: 0x006EA75A
	static CharacterPassiveSkillCustomAction()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterPassiveSkillCustomAction.CreateStaticDefaultValue), new Action(CharacterPassiveSkillCustomAction.ResetStaticDefaultValue));
	}

	// Token: 0x17002143 RID: 8515
	// (get) Token: 0x0601897A RID: 100730 RVA: 0x006EC579 File Offset: 0x006EA779
	private static Dictionary<string, Func<TFormulaValue[], TFormulaValue>> BuiltinFunc
	{
		get
		{
			return CharacterPassiveSkillCustomAction._builtinFunc;
		}
	}

	// Token: 0x0601897B RID: 100731 RVA: 0x006EC580 File Offset: 0x006EA780
	[NullableContext(2)]
	private static ContextParam GetContext(TFormulaValue value)
	{
		ContextParam contextParam;
		if (value.TryGetContext(out contextParam) && contextParam != null)
		{
			return contextParam;
		}
		return null;
	}

	// Token: 0x0601897C RID: 100732 RVA: 0x006EC5A0 File Offset: 0x006EA7A0
	[NullableContext(2)]
	private static Entity GetEntityOrNull(TFormulaValue value)
	{
		Entity result;
		if (value.TryGetEntity(out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0601897D RID: 100733 RVA: 0x006EC5BC File Offset: 0x006EA7BC
	private static TFormulaValue FromJsonElement(JsonElement json)
	{
		switch (json.ValueKind)
		{
		case JsonValueKind.Array:
		{
			int arrayLength = json.GetArrayLength();
			long[] array = new long[arrayLength];
			bool flag = true;
			int num = 0;
			foreach (JsonElement jsonElement in json.EnumerateArray())
			{
				long num2;
				if (jsonElement.ValueKind != JsonValueKind.Number || !jsonElement.TryGetInt64(out num2))
				{
					flag = false;
					break;
				}
				array[num++] = num2;
			}
			if (flag)
			{
				return TFormulaValue.FromLongArray(array);
			}
			string[] array2 = new string[arrayLength];
			num = 0;
			foreach (JsonElement jsonElement2 in json.EnumerateArray())
			{
				if (jsonElement2.ValueKind != JsonValueKind.String)
				{
					return default(TFormulaValue);
				}
				array2[num++] = (jsonElement2.GetString() ?? string.Empty);
			}
			return TFormulaValue.FromStringArray(array2);
		}
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

	// Token: 0x0601897E RID: 100734 RVA: 0x006EC774 File Offset: 0x006EA974
	private static long GetInstigatorId([Nullable(2)] Entity instigator, CharacterBuffComponent buffComp)
	{
		CreatureDataComponent creatureDataComponent = (instigator != null) ? instigator.GetComponent<CreatureDataComponent>() : null;
		long? num = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
		if (num != null)
		{
			return num.Value;
		}
		return buffComp.CreatureDataId;
	}

	// Token: 0x0601897F RID: 100735 RVA: 0x006EC7C0 File Offset: 0x006EA9C0
	[NullableContext(2)]
	private unsafe static bool AddCustomBuff([Nullable(1)] ContextParam context, Entity targetEntity, long buffId, int stackCount, Entity instigator)
	{
		PassiveSkillData skill = context.PassiveSkillComp.GetSKill(context.SkillId);
		if (targetEntity == null || skill == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity owner = context.Owner;
			string message = "被动技能添加buff失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", context.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetEntity", (targetEntity != null) ? new int?(targetEntity.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Instigator", (instigator != null) ? new int?(instigator.Id) : null);
			instance.Warn(flag, owner, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		CharacterBuffComponent component = targetEntity.GetComponent<CharacterBuffComponent>();
		if (component == null)
		{
			return false;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
		defaultInterpolatedStringHandler.AppendLiteral("被动技能");
		defaultInterpolatedStringHandler.AppendFormatted<long>(context.SkillId);
		defaultInterpolatedStringHandler.AppendLiteral("添加");
		string reason = defaultInterpolatedStringHandler.ToStringAndClear();
		component.AddBuff(buffId, new AddBuffParam
		{
			InstigatorId = CharacterPassiveSkillCustomAction.GetInstigatorId(instigator, context.BuffComp),
			PreMessageId = skill.CombatMessageId,
			Reason = reason,
			OuterStackCount = new int?(stackCount)
		});
		return true;
	}

	// Token: 0x06018980 RID: 100736 RVA: 0x006EC924 File Offset: 0x006EAB24
	private static bool AddCustomBulletInternal(Entity owner, Entity attacker, Entity target, long bulletId, string[] hitCaseArray, int hitCaseIndex, long skillId, long? combatMessageId)
	{
		if (!attacker.Valid || !target.Valid)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			string message = "被动技能添加子弹失败,实体不合法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", skillId);
			instance.Warn(flag, owner, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		CharacterActorComponent component = target.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.PassiveSkill;
			string message2 = "被动技能添加子弹失败";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("skillId", skillId);
			instance2.Warn(flag2, owner, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		FTransformDouble? initialTransform = null;
		if (hitCaseArray != null && hitCaseIndex >= 0 && hitCaseIndex < hitCaseArray.Length)
		{
			string socketName = hitCaseArray[hitCaseIndex];
			ERelativeTransformSpace space = ERelativeTransformSpace.RTS_World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
			defaultInterpolatedStringHandler.AppendLiteral("被动技能");
			defaultInterpolatedStringHandler.AppendFormatted<long>(skillId);
			initialTransform = SkillUtils.GetTargetSocketTransform(target, socketName, space, defaultInterpolatedStringHandler.ToStringAndClear(), ESocketTransformDefault.None);
		}
		if (initialTransform == null)
		{
			initialTransform = new FTransformDouble?(component.ActorTransform);
		}
		ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(attacker, bulletId.ToString(), initialTransform, null, combatMessageId, EBulletCreateSource.Others);
		return true;
	}

	// Token: 0x06018981 RID: 100737 RVA: 0x006ECA24 File Offset: 0x006EAC24
	private unsafe static TFormulaValue RefreshBuffDuration(TFormulaValue[] args)
	{
		ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
		Entity entityOrNull = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		long[] buffIds = args[2];
		if (entityOrNull == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity entity = (context != null) ? context.Owner : null;
			string message = "被动技能刷新buff持续时间失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", (context != null) ? new long?(context.SkillId) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("target", entityOrNull);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return TFormulaValue.FromBool(false);
		}
		CharacterBuffComponent component = entityOrNull.GetComponent<CharacterBuffComponent>();
		if (component != null)
		{
			component.RefreshBuffDuration(buffIds, "被动技能行为刷新buff时长");
		}
		return TFormulaValue.FromBool(true);
	}

	// Token: 0x06018982 RID: 100738 RVA: 0x006ECB00 File Offset: 0x006EAD00
	private unsafe static TFormulaValue UpdateTag(TFormulaValue[] args)
	{
		ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
		Entity entityOrNull = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		string[] array = (string[])args[2];
		int num = (int)args[3];
		int deltaCount = (int)args[4];
		if (context == null || entityOrNull == null || num < 0 || num >= array.Length)
		{
			return TFormulaValue.FromBool(false);
		}
		BaseTagComponent component = entityOrNull.GetComponent<BaseTagComponent>();
		int tagIdByName = GameplayTagUtils.GetTagIdByName(array[num]);
		BaseBuffComponent component2 = entityOrNull.GetComponent<BaseBuffComponent>();
		bool flag = component2 != null && component2.HasBuffAuthority();
		if (component == null || tagIdByName == 0 || !flag)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.PassiveSkill;
			Entity owner = context.Owner;
			string message = "被动技能本地更新tag失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", context.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("index", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("target", entityOrNull.Id);
			instance.Warn(flag2, owner, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return TFormulaValue.FromBool(false);
		}
		component.TagContainer.UpdateExactTag(ETagChannel.PassiveSkill, tagIdByName, deltaCount);
		return TFormulaValue.FromBool(true);
	}

	// Token: 0x06018983 RID: 100739 RVA: 0x006ECC44 File Offset: 0x006EAE44
	private static TFormulaValue AddBuffByArray(TFormulaValue[] args)
	{
		ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
		Entity entityOrNull = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		long[] array = args[2];
		int num = (int)args[3];
		int stackCount = (int)args[4];
		Entity instigator = (args.Length > 5) ? CharacterPassiveSkillCustomAction.GetEntityOrNull(args[5]) : null;
		if (context == null || entityOrNull == null || num < 0 || num >= array.Length)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity owner = context.Owner;
			string message = "被动技能添加buff失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", num);
			instance.Warn(flag, owner, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return TFormulaValue.FromBool(false);
		}
		return TFormulaValue.FromBool(CharacterPassiveSkillCustomAction.AddCustomBuff(context, entityOrNull, array[num], stackCount, instigator));
	}

	// Token: 0x06018984 RID: 100740 RVA: 0x006ECD04 File Offset: 0x006EAF04
	private static TFormulaValue EndAbilityVision(TFormulaValue[] args)
	{
		Entity entityOrNull = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		EVisionType visionType = (EVisionType)((int)args[2]);
		CharacterVisionComponent characterVisionComponent = (entityOrNull != null) ? entityOrNull.GetComponent<CharacterVisionComponent>() : null;
		if (characterVisionComponent != null && characterVisionComponent.Valid)
		{
			characterVisionComponent.EndAbilityVision(visionType);
		}
		return TFormulaValue.FromBool(true);
	}

	// Token: 0x06018985 RID: 100741 RVA: 0x006ECD54 File Offset: 0x006EAF54
	private static TFormulaValue AddCustomBullet(TFormulaValue[] args)
	{
		CharacterPassiveSkillCustomAction.<>c__DisplayClass14_0 CS$<>8__locals1 = new CharacterPassiveSkillCustomAction.<>c__DisplayClass14_0();
		ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
		CS$<>8__locals1.attacker = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		CS$<>8__locals1.target = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[2]);
		CS$<>8__locals1.bulletId = (long)args[3];
		CS$<>8__locals1.hitCaseArray = (string[])args[4];
		CS$<>8__locals1.hitCaseIndex = (int)args[5];
		CS$<>8__locals1.delayMsAtPlayerQueue = ((args.Length > 6) ? ((int)args[6]) : 0);
		if (context == null || CS$<>8__locals1.attacker == null || CS$<>8__locals1.target == null)
		{
			return TFormulaValue.FromBool(false);
		}
		CS$<>8__locals1.owner = context.Owner;
		CS$<>8__locals1.skillId = context.SkillId;
		CharacterPassiveSkillCustomAction.<>c__DisplayClass14_0 CS$<>8__locals2 = CS$<>8__locals1;
		PassiveSkillData skill = context.PassiveSkillComp.GetSKill(context.SkillId);
		CS$<>8__locals2.combatMessageId = ((skill != null) ? skill.CombatMessageId : null);
		CreatureDataComponent component = CS$<>8__locals1.attacker.GetComponent<CreatureDataComponent>();
		bool flag = component != null && component.IsRole();
		if (CS$<>8__locals1.delayMsAtPlayerQueue <= 0 || !flag)
		{
			CharacterPassiveSkillCustomAction.AddCustomBulletInternal(CS$<>8__locals1.owner, CS$<>8__locals1.attacker, CS$<>8__locals1.target, CS$<>8__locals1.bulletId, CS$<>8__locals1.hitCaseArray, CS$<>8__locals1.hitCaseIndex, CS$<>8__locals1.skillId, CS$<>8__locals1.combatMessageId);
		}
		else
		{
			ControllerBase<PassiveSkillPlayerQueueController>.Instance.DoAction(new TPassiveSkillQueueCallback(CS$<>8__locals1.<AddCustomBullet>g__Action|0));
		}
		return TFormulaValue.FromBool(true);
	}

	// Token: 0x06018986 RID: 100742 RVA: 0x006ECEC0 File Offset: 0x006EB0C0
	private static TFormulaValue ExecDamage(TFormulaValue[] args)
	{
		ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
		Entity entityOrNull = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		long damageDataId = (long)args[2];
		if (context == null)
		{
			return TFormulaValue.FromBool(false);
		}
		PassiveSkillData skill = context.PassiveSkillComp.GetSKill(context.SkillId);
		if (entityOrNull == null || skill == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity owner = context.Owner;
			string message = "被动技能触发结算失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", context.SkillId);
			instance.Warn(flag, owner, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return TFormulaValue.FromBool(false);
		}
		BaseDamageComponent baseDamageComponent = entityOrNull.CheckGetComponent<BaseDamageComponent>();
		BaseActorComponent baseActorComponent = entityOrNull.CheckGetComponent<BaseActorComponent>();
		FVectorDouble? fvectorDouble = (baseActorComponent != null) ? new FVectorDouble?(baseActorComponent.ActorLocation) : null;
		Entity owner2 = context.Owner;
		if (baseDamageComponent == null || fvectorDouble == null)
		{
			return TFormulaValue.FromBool(false);
		}
		baseDamageComponent.ExecuteBuffDamage(new BuffDamageParam
		{
			DamageDataId = damageDataId,
			SkillLevel = 1,
			Attacker = owner2,
			HitPosition = fvectorDouble.Value
		}, new Partial_RequirementPayload(), skill.CombatMessageId.Value);
		return TFormulaValue.FromBool(true);
	}

	// Token: 0x06018987 RID: 100743 RVA: 0x006ECFE0 File Offset: 0x006EB1E0
	private unsafe static TFormulaValue RemoveBuffStack(TFormulaValue[] args)
	{
		ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
		Entity entityOrNull = CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]);
		long buffId = (long)args[2];
		int num = (int)args[3];
		if (num == 0)
		{
			return TFormulaValue.FromBool(true);
		}
		if (context == null || entityOrNull == null)
		{
			return TFormulaValue.FromBool(false);
		}
		BaseBuffComponent component = entityOrNull.GetComponent<BaseBuffComponent>();
		if (component == null || !component.HasBuffAuthority())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			Entity owner = context.Owner;
			string message = "被动技能移除buff失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", context.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetEntity", entityOrNull.Id);
			instance.Warn(flag, owner, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return TFormulaValue.FromBool(false);
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
		defaultInterpolatedStringHandler.AppendLiteral("被动技能");
		defaultInterpolatedStringHandler.AppendFormatted<long>(context.SkillId);
		string reason = defaultInterpolatedStringHandler.ToStringAndClear();
		component.RemoveBuff(buffId, num, reason, null, null, null);
		return TFormulaValue.FromBool(true);
	}

	// Token: 0x06018988 RID: 100744 RVA: 0x006ED11C File Offset: 0x006EB31C
	[return: Nullable(2)]
	public static Formula AddCustomAction(PassiveSkill? config, Entity owner, Dictionary<string, Func<TFormulaValue[], TFormulaValue>> buildInFunctions)
	{
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.TZQ;
			string message = "被动自定义行为创建失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("owner", owner.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		Dictionary<string, Func<TFormulaValue[], TFormulaValue>> builtinFunctions = new Dictionary<string, Func<TFormulaValue[], TFormulaValue>>(buildInFunctions);
		return new Formula(config.Value.SkillActionScript).SetBuiltinFunctions(builtinFunctions).SetContextBuiltinFunctions(CharacterPassiveSkillCustomAction.BuiltinFunc).SetDefaultParams(config.Value.ActionScriptParams).SetDefaultParam("Owner", TFormulaValue.FromEntity(owner));
	}

	// Token: 0x06018989 RID: 100745 RVA: 0x006ED1B4 File Offset: 0x006EB3B4
	public static void CreateStaticDefaultValue()
	{
		Dictionary<string, Func<TFormulaValue[], TFormulaValue>> dictionary = new Dictionary<string, Func<TFormulaValue[], TFormulaValue>>();
		dictionary["AddBuff2"] = delegate(TFormulaValue[] args)
		{
			ContextParam context = CharacterPassiveSkillCustomAction.GetContext(args[0]);
			if (context == null)
			{
				return TFormulaValue.FromBool(false);
			}
			return TFormulaValue.FromBool(CharacterPassiveSkillCustomAction.AddCustomBuff(context, CharacterPassiveSkillCustomAction.GetEntityOrNull(args[1]), (long)args[2], (int)args[3], (args.Length > 4) ? CharacterPassiveSkillCustomAction.GetEntityOrNull(args[4]) : null));
		};
		string key = "RefreshBuffDuration";
		Func<TFormulaValue[], TFormulaValue> value;
		if ((value = CharacterPassiveSkillCustomAction.<>O.<0>__RefreshBuffDuration) == null)
		{
			value = (CharacterPassiveSkillCustomAction.<>O.<0>__RefreshBuffDuration = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.RefreshBuffDuration));
		}
		dictionary[key] = value;
		string key2 = "UpdateTag";
		Func<TFormulaValue[], TFormulaValue> value2;
		if ((value2 = CharacterPassiveSkillCustomAction.<>O.<1>__UpdateTag) == null)
		{
			value2 = (CharacterPassiveSkillCustomAction.<>O.<1>__UpdateTag = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.UpdateTag));
		}
		dictionary[key2] = value2;
		string key3 = "AddBuffByArray";
		Func<TFormulaValue[], TFormulaValue> value3;
		if ((value3 = CharacterPassiveSkillCustomAction.<>O.<2>__AddBuffByArray) == null)
		{
			value3 = (CharacterPassiveSkillCustomAction.<>O.<2>__AddBuffByArray = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.AddBuffByArray));
		}
		dictionary[key3] = value3;
		string key4 = "EndAbilityVision";
		Func<TFormulaValue[], TFormulaValue> value4;
		if ((value4 = CharacterPassiveSkillCustomAction.<>O.<3>__EndAbilityVision) == null)
		{
			value4 = (CharacterPassiveSkillCustomAction.<>O.<3>__EndAbilityVision = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.EndAbilityVision));
		}
		dictionary[key4] = value4;
		string key5 = "AddCustomBullet";
		Func<TFormulaValue[], TFormulaValue> value5;
		if ((value5 = CharacterPassiveSkillCustomAction.<>O.<4>__AddCustomBullet) == null)
		{
			value5 = (CharacterPassiveSkillCustomAction.<>O.<4>__AddCustomBullet = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.AddCustomBullet));
		}
		dictionary[key5] = value5;
		string key6 = "ExecDamage";
		Func<TFormulaValue[], TFormulaValue> value6;
		if ((value6 = CharacterPassiveSkillCustomAction.<>O.<5>__ExecDamage) == null)
		{
			value6 = (CharacterPassiveSkillCustomAction.<>O.<5>__ExecDamage = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.ExecDamage));
		}
		dictionary[key6] = value6;
		string key7 = "RemoveBuffStack";
		Func<TFormulaValue[], TFormulaValue> value7;
		if ((value7 = CharacterPassiveSkillCustomAction.<>O.<6>__RemoveBuffStack) == null)
		{
			value7 = (CharacterPassiveSkillCustomAction.<>O.<6>__RemoveBuffStack = new Func<TFormulaValue[], TFormulaValue>(CharacterPassiveSkillCustomAction.RemoveBuffStack));
		}
		dictionary[key7] = value7;
		CharacterPassiveSkillCustomAction._builtinFunc = dictionary;
	}

	// Token: 0x0601898A RID: 100746 RVA: 0x006ED2FF File Offset: 0x006EB4FF
	public static void ResetStaticDefaultValue()
	{
		CharacterPassiveSkillCustomAction._builtinFunc = null;
	}

	// Token: 0x0400BE49 RID: 48713
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private static Dictionary<string, Func<TFormulaValue[], TFormulaValue>> _builtinFunc;

	// Token: 0x02009322 RID: 37666
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04030FD1 RID: 200657
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <0>__RefreshBuffDuration;

		// Token: 0x04030FD2 RID: 200658
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <1>__UpdateTag;

		// Token: 0x04030FD3 RID: 200659
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <2>__AddBuffByArray;

		// Token: 0x04030FD4 RID: 200660
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <3>__EndAbilityVision;

		// Token: 0x04030FD5 RID: 200661
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <4>__AddCustomBullet;

		// Token: 0x04030FD6 RID: 200662
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <5>__ExecDamage;

		// Token: 0x04030FD7 RID: 200663
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<TFormulaValue[], TFormulaValue> <6>__RemoveBuffStack;
	}
}
