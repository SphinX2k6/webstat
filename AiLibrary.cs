using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02000CEA RID: 3306
[NullableContext(1)]
[Nullable(0)]
public class AiLibrary
{
	// Token: 0x060041CC RID: 16844 RVA: 0x0006EC08 File Offset: 0x0006CE08
	public unsafe static bool IsSkillAvailable(AiController aiController, int skillInfoId, CharacterSkillComponent skillComp, BaseTagComponent tagComp, int ignoreSkillType, double targetAngle, double height, double distance, double angle, bool checkDistanceAndAngle, bool debugLog = false)
	{
		AiSkillInfos aiSkillInfos;
		if (!aiController.AiSkill.SkillInfos.TryGetValue(skillInfoId, out aiSkillInfos))
		{
			return false;
		}
		AiSkillPrecondition aiSkillPrecondition;
		if (!aiController.AiSkill.SkillPreconditionMap.TryGetValue(aiSkillInfos.SkillPreconditionId, out aiSkillPrecondition))
		{
			return false;
		}
		if (!aiSkillPrecondition.NeedTarget)
		{
			return false;
		}
		bool flag = debugLog && !Singleton<Info>.Instance.IsBuildShipping;
		if (flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Detect Skill";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillInfoId", skillInfoId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (ignoreSkillType >= 0 && aiSkillInfos.SkillType != ignoreSkillType)
		{
			if (flag)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.AI;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "FailType";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ignoreSkillType);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return false;
		}
		int num;
		int skillId = int.TryParse(aiSkillInfos.SkillId, out num) ? num : 0;
		if (!aiController.AiSkill.CanActivate(skillInfoId) || !skillComp.IsCanUseSkill(skillId) || !aiController.AiSkill.CanActivate(skillInfoId))
		{
			if (flag)
			{
				Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "FailCD", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return false;
		}
		FGameplayTag fgameplayTag;
		aiController.AiSkill.PreconditionTagMap.TryGetValue(aiSkillInfos.SkillPreconditionId, out fgameplayTag);
		FGameplayTag tag;
		if (aiSkillPrecondition.NeedTag.Length > 0 && (!tagComp.Valid || (aiController.AiSkill.PreconditionTagMap.TryGetValue(aiSkillInfos.SkillPreconditionId, out tag) && !tagComp.HasTag(tag.TagId()))))
		{
			if (flag)
			{
				Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "FailTag", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return false;
		}
		if (aiSkillPrecondition.TargetAngleRange == null || aiSkillPrecondition.HeightRange == null || aiSkillPrecondition.DistanceRange == null || aiSkillPrecondition.AngleRange == null || !Singleton<MathUtils>.Instance.InRangeAngle(targetAngle, aiSkillPrecondition.TargetAngleRange.Value) || !Singleton<MathUtils>.Instance.InRange(height, aiSkillPrecondition.HeightRange.Value) || (checkDistanceAndAngle && (!Singleton<MathUtils>.Instance.InRange(distance, aiSkillPrecondition.DistanceRange.Value) || !Singleton<MathUtils>.Instance.InRangeAngle(angle, aiSkillPrecondition.AngleRange.Value))))
		{
			if (flag)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.AI;
				ELogAuthor author3 = ELogAuthor.LCZ;
				string message3 = "FailLocation";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TargetAngle", targetAngle);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Distance", distance);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Angle", angle);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Height", height);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			return false;
		}
		return true;
	}

	// Token: 0x060041CD RID: 16845 RVA: 0x0006EF2C File Offset: 0x0006D12C
	public unsafe static bool SelectSkillWithTarget(AiController aiController, CharacterSkillComponent skillComponent, CharacterActorComponent targetActorComp, int skillType, bool debug = false)
	{
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		BaseTagComponent component = charActorComp.Entity.GetComponent<BaseTagComponent>();
		global::Vector vector = global::Vector.Create();
		Singleton<MathUtils>.Instance.InverseTransformPositionNoScale(targetActorComp.FloorLocation, targetActorComp.ActorRotationProxy, charActorComp.FloorLocation, vector);
		double angleByVector2D = global::Vector.GetAngleByVector2D(vector);
		Singleton<MathUtils>.Instance.InverseTransformPositionNoScale(charActorComp.FloorLocation, charActorComp.ActorRotationProxy, targetActorComp.FloorLocation, vector);
		global::Vector vector2 = vector;
		double z = vector2.Z;
		double distance = Math.Max(vector2.Size2D() - (double)charActorComp.ScaledRadius - (double)targetActorComp.ScaledRadius, 1E-08);
		double angleByVector2D2 = global::Vector.GetAngleByVector2D(vector2);
		int num = 0;
		int value = 0;
		int num2 = 0;
		if (debug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SelectSkillWithTarget";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", aiController.CharActorComp.Actor.GetName());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		foreach (int num3 in aiController.AiSkill.ActiveSkillGroup)
		{
			Span<int> arrayIntBytes = aiController.AiSkill.BaseSkill.Value.RandomSkills()[num3].GetArrayIntBytes();
			for (int i = 0; i < arrayIntBytes.Length; i++)
			{
				int num4 = *arrayIntBytes[i];
				AiSkillInfos aiSkillInfos;
				if (!aiController.AiSkill.SkillInfos.TryGetValue(num4, out aiSkillInfos))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "没有配置技能库";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", num4);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else if (aiSkillInfos.SkillWeight > 0 && AiLibrary.IsSkillAvailable(aiController, num4, skillComponent, component, skillType, angleByVector2D, z, distance, angleByVector2D2, true, debug))
				{
					int skillWeight = aiSkillInfos.SkillWeight;
					num += skillWeight;
					if (Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)num) < (double)skillWeight)
					{
						value = num4;
						int num5;
						num2 = (int.TryParse(aiSkillInfos.SkillId, out num5) ? num5 : 0);
					}
				}
			}
		}
		if (debug)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.AI;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "SelectSkillWithTarget Success";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("SkillId", num2);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		}
		if (num2 != 0)
		{
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(charActorComp.Entity.Id, "SkillId", num2.ToString());
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(charActorComp.Entity.Id, "SkillInfoId", value);
			return true;
		}
		return false;
	}

	// Token: 0x060041CE RID: 16846 RVA: 0x0006F1D4 File Offset: 0x0006D3D4
	public static bool SelectSkillWithoutTarget(AiController aiController, CharacterSkillComponent skillComponent, int skillType)
	{
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		BaseTagComponent component = charActorComp.Entity.GetComponent<BaseTagComponent>();
		int num = 0;
		int value = 0;
		int num2 = 0;
		foreach (int num3 in aiController.AiSkill.ActiveSkillGroup)
		{
			foreach (int num4 in aiController.AiSkill.BaseSkill.Value.RandomSkills()[num3].ArrayInt())
			{
				AiSkillInfos aiSkillInfos;
				AiSkillPrecondition aiSkillPrecondition;
				if (!aiController.AiSkill.SkillInfos.TryGetValue(num4, out aiSkillInfos))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.BehaviorTree;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "没有配置技能库";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", num4);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (!aiController.AiSkill.SkillPreconditionMap.TryGetValue(aiSkillInfos.SkillPreconditionId, out aiSkillPrecondition))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "没有配置技能前置条件";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", aiSkillInfos.SkillPreconditionId);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else if (!aiSkillPrecondition.NeedTarget && (skillType < 0 || aiSkillInfos.SkillType == skillType))
				{
					int num6;
					int num5 = int.TryParse(aiSkillInfos.SkillId, out num6) ? num6 : 0;
					FGameplayTag tag;
					if (skillComponent.IsCanUseSkill(num5) && aiController.AiSkill.CanActivate(num4) && (aiSkillPrecondition.NeedTag.Length <= 0 || !aiController.AiSkill.PreconditionTagMap.TryGetValue(aiSkillInfos.SkillPreconditionId, out tag) || tag.TagId() == 0 || (component.Valid && component.HasTag(tag.TagId()))))
					{
						int skillWeight = aiSkillInfos.SkillWeight;
						num += skillWeight;
						if (Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)num) < (double)skillWeight)
						{
							value = num4;
							num2 = num5;
						}
					}
				}
			}
		}
		if (num2 != 0)
		{
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(charActorComp.Entity.Id, "SkillId", num2.ToString());
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(charActorComp.Entity.Id, "SkillInfoId", value);
			return true;
		}
		return false;
	}
}
