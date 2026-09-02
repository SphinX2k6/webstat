using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Input;
using UnrealEngine;

// Token: 0x0200312D RID: 12589
[NullableContext(1)]
[Nullable(0)]
public class SkillBehaviorCondition
{
	// Token: 0x0601A127 RID: 106791 RVA: 0x007A5F94 File Offset: 0x007A4194
	public unsafe static bool SatisfyGroup(TArray<SSkillBehaviorCondition> skillBehaviorConditionGroup, string skillBehaviorConditionFormula, IBeginSkillBehaviorConditionParam param)
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < skillBehaviorConditionGroup.Num(); i++)
		{
			bool flag = SkillBehaviorCondition.Satisfy(skillBehaviorConditionGroup.Get(i), param);
			if (!string.IsNullOrEmpty(skillBehaviorConditionFormula))
			{
				list.Add(flag);
			}
			else if (!flag)
			{
				return false;
			}
		}
		if (list.Count > 0)
		{
			try
			{
				ILogicalStructure structure = new Parser(skillBehaviorConditionFormula).Parse();
				return new ConditionArray(list.ToArray(), structure).Evaluate();
			}
			catch (Exception ex)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
				Entity entity = param.Entity;
				string message = "SkillBehaviorCondition.SatisfyGroup技能行为条件公式解析异常";
				Exception e = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "技能Id";
				Skill skill = param.Skill;
				ptr = new ValueTuple<string, object>(item, (skill != null) ? skill.SkillId : 0);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item2 = "技能名";
				Skill skill2 = param.Skill;
				ptr2 = new ValueTuple<string, object>(item2, ((skill2 != null) ? skill2.SkillName : null) ?? string.Empty);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("formula", skillBehaviorConditionFormula);
				instance.ErrorWithStack(flag2, entity, message, e, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			return true;
		}
		return true;
	}

	// Token: 0x0601A128 RID: 106792 RVA: 0x007A60CC File Offset: 0x007A42CC
	public unsafe static bool Satisfy(SSkillBehaviorCondition skillBehaviorCondition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		string item = "未知条件类型";
		switch (skillBehaviorCondition.ConditionType)
		{
		case ESkillBehaviorConditionType.是否有技能目标:
			item = "是否有技能目标";
			flag = SkillBehaviorCondition.ConditionTarget(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.与技能目标锁定点距离:
			item = "与技能目标锁定点距离";
			flag = SkillBehaviorCondition.ConditionDistance(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.与技能目标锁定点角度:
			item = "与技能目标锁定点角度";
			flag = SkillBehaviorCondition.ConditionAngle(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.施法者标签检测:
			item = "施法者标签检测";
			flag = SkillBehaviorCondition.ConditionTag(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.施法者属性检测:
			item = "施法者属性检测";
			flag = SkillBehaviorCondition.ConditionAttribute(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.空中高度检测:
			item = "空中高度检测";
			flag = SkillBehaviorCondition.ConditionHeightAboveGround(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.与技能目标锁定点高度:
			item = "与技能目标锁定点高度";
			flag = SkillBehaviorCondition.ConditionHeight(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.是否有技能目标和是否战斗单位:
			item = "是否有技能目标和是否战斗单位";
			flag = SkillBehaviorCondition.ConditionTargetOnlyCombat(skillBehaviorCondition, param);
			break;
		case ESkillBehaviorConditionType.是否有摇杆输入:
			item = "是否有摇杆输入";
			flag = SkillBehaviorCondition.ConditionHasAxisInput(skillBehaviorCondition, param);
			break;
		}
		CombatLog.ELogType logType = CombatLog.ELogType.Debug;
		ESkillLogType skillLogType = ESkillLogType.SkillBehavior;
		Entity entity = param.Entity;
		string message = "SkillBehaviorCondition.Satisfy技能行为条件判断";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item2 = "技能Id";
		Skill skill = param.Skill;
		ptr = new ValueTuple<string, object>(item2, (skill != null) ? skill.SkillId : 0);
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item3 = "技能名";
		Skill skill2 = param.Skill;
		ptr2 = new ValueTuple<string, object>(item3, ((skill2 != null) ? skill2.SkillName : null) ?? string.Empty);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("条件", item);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("结果", flag);
		SkillUtils.Log(logType, skillLogType, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		return flag;
	}

	// Token: 0x0601A129 RID: 106793 RVA: 0x007A6264 File Offset: 0x007A4464
	private static bool ConditionTarget(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		BaseSkillComponent skillComponent = param.SkillComponent;
		if (((skillComponent != null) ? skillComponent.SkillTarget : null) != null)
		{
			flag = true;
		}
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A12A RID: 106794 RVA: 0x007A6298 File Offset: 0x007A4498
	private static bool ConditionDistance(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		BaseSkillComponent skillComponent = param.SkillComponent;
		if (((skillComponent != null) ? skillComponent.SkillTarget : null) != null)
		{
			global::Vector actorLocationProxy = param.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
			global::Vector v = global::Vector.Create(param.SkillComponent.GetTargetTransform().GetLocation());
			float lValue = condition.IgnoreZ ? ((float)global::Vector.Dist2D(actorLocationProxy, v)) : ((float)global::Vector.Distance(actorLocationProxy, v));
			flag = SkillBehaviorMisc.Compare(condition.ComparisonLogic, lValue, condition.Value, condition.RangeL, condition.RangeR);
		}
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A12B RID: 106795 RVA: 0x007A6338 File Offset: 0x007A4538
	private static bool ConditionAngle(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		BaseSkillComponent skillComponent = param.SkillComponent;
		if (((skillComponent != null) ? skillComponent.SkillTarget : null) != null)
		{
			BaseActorComponent component = param.Entity.GetComponent<BaseActorComponent>();
			global::Vector actorLocationProxy = component.ActorLocationProxy;
			global::Vector vector = global::Vector.Create(param.SkillComponent.GetTargetTransform().GetLocation());
			global::Vector vector2 = global::Vector.Create();
			vector.Subtraction(actorLocationProxy, vector2);
			if (condition.IgnoreZ)
			{
				vector2.Z = 0.0;
			}
			vector2.Normalize(9.99999993922529E-09);
			float lValue = condition.Sign ? ((float)Singleton<MathUtils>.Instance.SignedAngleOnPlaneDeg(component.ActorForwardProxy, vector2, global::Vector.UpVectorDouble)) : ((float)Singleton<MathUtils>.Instance.GetAngleByVectorDot(component.ActorForwardProxy, vector2));
			flag = SkillBehaviorMisc.Compare(condition.ComparisonLogic, lValue, condition.Value, condition.RangeL, condition.RangeR);
		}
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A12C RID: 106796 RVA: 0x007A6434 File Offset: 0x007A4634
	private static bool ConditionTag(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		BaseTagComponent component = param.Entity.GetComponent<BaseTagComponent>();
		bool flag = condition.AnyTag ? component.HasAnyTag(GameplayTagUtils.ConvertFromUeContainer(condition.TagToCheck)) : component.HasAllTag(GameplayTagUtils.ConvertFromUeContainer(condition.TagToCheck));
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A12D RID: 106797 RVA: 0x007A648C File Offset: 0x007A468C
	private static bool ConditionAttribute(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		BaseAttributeComponent component = param.Entity.GetComponent<BaseAttributeComponent>();
		float currentValue = component.GetCurrentValue((EAttributeType)condition.AttributeId1);
		float num = (condition.AttributeId2 > 0) ? component.GetCurrentValue((EAttributeType)condition.AttributeId2) : 0f;
		bool flag = SkillBehaviorMisc.Compare(condition.ComparisonLogic, currentValue, condition.Value + num * (float)condition.AttributeRate * 0.0001f, condition.RangeL, condition.RangeR);
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A12E RID: 106798 RVA: 0x007A6514 File Offset: 0x007A4714
	private static bool ConditionHeightAboveGround(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		float heightAboveGround = param.Entity.GetComponent<CharacterMoveComponent>().GetHeightAboveGround(500f);
		bool flag = SkillBehaviorMisc.Compare(condition.ComparisonLogic, heightAboveGround, condition.Value, condition.RangeL, condition.RangeR);
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A12F RID: 106799 RVA: 0x007A656C File Offset: 0x007A476C
	private static bool ConditionHeight(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		BaseSkillComponent skillComponent = param.SkillComponent;
		if (((skillComponent != null) ? skillComponent.SkillTarget : null) != null)
		{
			global::Vector actorLocationProxy = param.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
			global::Vector vector = global::Vector.Create(param.SkillComponent.GetTargetTransform().GetLocation());
			float lValue = (float)(actorLocationProxy.Z - vector.Z);
			flag = SkillBehaviorMisc.Compare(condition.ComparisonLogic, lValue, condition.Value, condition.RangeL, condition.RangeR);
		}
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A130 RID: 106800 RVA: 0x007A6600 File Offset: 0x007A4800
	private static bool ConditionTargetOnlyCombat(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		BaseSkillComponent skillComponent = param.SkillComponent;
		if (SkillUtils.IsTsActor((skillComponent != null) ? skillComponent.SkillTarget : null))
		{
			flag = true;
		}
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}

	// Token: 0x0601A131 RID: 106801 RVA: 0x007A6638 File Offset: 0x007A4838
	private static bool ConditionHasAxisInput(SSkillBehaviorCondition condition, IBeginSkillBehaviorConditionParam param)
	{
		bool flag = false;
		Dictionary<EInputAxis, float> axisValues = ModelBase<InputModel>.Instance.GetAxisValues();
		if (axisValues != null)
		{
			float num;
			bool flag2 = axisValues.TryGetValue(EInputAxis.MoveForward, out num);
			float num2;
			bool flag3 = axisValues.TryGetValue(EInputAxis.MoveRight, out num2);
			if ((flag2 && num != 0f) || (flag3 && num2 != 0f))
			{
				flag = true;
			}
		}
		if (!condition.Reverse)
		{
			return flag;
		}
		return !flag;
	}
}
