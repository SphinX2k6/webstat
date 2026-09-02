using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200313E RID: 12606
[NullableContext(1)]
[Nullable(0)]
public class SkillUtils : IStaticVariableResetter
{
	// Token: 0x0601A184 RID: 106884 RVA: 0x007A7956 File Offset: 0x007A5B56
	static SkillUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SkillUtils.CreateStaticDefaultValue), new Action(SkillUtils.ResetStaticDefaultValue));
	}

	// Token: 0x0601A185 RID: 106885 RVA: 0x007A7980 File Offset: 0x007A5B80
	[NullableContext(2)]
	public static void GetSkillRotateDirect(EntityHandle entityHandle, SkillRotateTarget skillRotateTarget, AnimNotifyStateSkillRotateStyle skillRotateStyle, [Nullable(1)] global::Vector outVector)
	{
		outVector.Reset();
		if (entityHandle == null || !entityHandle.Valid || skillRotateTarget == null)
		{
			return;
		}
		BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		BaseSkillComponent component2 = entityHandle.Entity.GetComponent<BaseSkillComponent>();
		if (component2 == null || !component2.Valid)
		{
			return;
		}
		global::Vector actorLocationProxy = component.ActorLocationProxy;
		switch (skillRotateTarget.Type)
		{
		case ESkillRotateType.None:
			if (component2.SkillTarget != null && component2.SkillTarget.Valid)
			{
				BaseActorComponent target = component2.SkillTarget.Entity.CheckGetComponent<BaseActorComponent>();
				global::Vector currentSkillRotateTargetDirect = component2.GetCurrentSkillRotateTargetDirect(target, actorLocationProxy);
				outVector.DeepCopy(currentSkillRotateTargetDirect);
			}
			break;
		case ESkillRotateType.Location:
		{
			global::Vector targetVector = skillRotateTarget.TargetVector;
			if (targetVector != null)
			{
				SkillUtils.TmpVector.DeepCopy(targetVector);
				SkillUtils.TmpVector.SubtractionEqual(actorLocationProxy);
				outVector.DeepCopy(SkillUtils.TmpVector);
			}
			break;
		}
		case ESkillRotateType.Direct:
		{
			global::Vector targetVector2 = skillRotateTarget.TargetVector;
			if (targetVector2 != null)
			{
				outVector.DeepCopy(targetVector2);
			}
			break;
		}
		case ESkillRotateType.BlackBoardEntityId:
		case ESkillRotateType.BlackBoardInt:
		{
			int? num = null;
			if (skillRotateTarget.Type == ESkillRotateType.BlackBoardEntityId)
			{
				num = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(entityHandle.Entity.Id, skillRotateTarget.TargetString);
			}
			else
			{
				num = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(entityHandle.Entity.Id, skillRotateTarget.TargetString);
			}
			if (num != null)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(num.Value);
				BaseActorComponent baseActorComponent = (entity != null) ? entity.CheckGetComponent<BaseActorComponent>() : null;
				if (baseActorComponent != null && baseActorComponent.Valid)
				{
					SkillUtils.TmpVector.DeepCopy(baseActorComponent.ActorLocationProxy);
					SkillUtils.TmpVector.SubtractionEqual(actorLocationProxy);
					outVector.DeepCopy(SkillUtils.TmpVector);
				}
			}
			break;
		}
		case ESkillRotateType.BlackBoardLocation:
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(entityHandle.Entity.Id, skillRotateTarget.TargetString);
			if (vectorValueByEntity != null)
			{
				SkillUtils.TmpVector.DeepCopy(vectorValueByEntity);
				SkillUtils.TmpVector.SubtractionEqual(actorLocationProxy);
				outVector.DeepCopy(SkillUtils.TmpVector);
			}
			break;
		}
		case ESkillRotateType.BlackBoardDirect:
		{
			Aki.Protocol.Vector vectorValueByEntity2 = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(entityHandle.Entity.Id, skillRotateTarget.TargetString);
			if (vectorValueByEntity2 != null)
			{
				outVector.DeepCopy(vectorValueByEntity2);
			}
			break;
		}
		case ESkillRotateType.StandBy:
			outVector.DeepCopy(component.ActorForwardProxy);
			break;
		}
		if (skillRotateStyle != null)
		{
			if (skillRotateStyle.IsUseAnsRotateOffset && skillRotateStyle.AnsRotateOffset != 0f)
			{
				Singleton<MathUtils>.Instance.CommonTempRotator.Set(0f, skillRotateStyle.AnsRotateOffset, 0f);
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(component, outVector);
				Singleton<GravityUtils>.Instance.RotateDirectInGravityForActor(component, Singleton<MathUtils>.Instance.CommonTempRotator, outVector);
			}
			global::Vector actorForwardProxy = component.ActorForwardProxy;
			float angleOffsetInGravityAbsForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityAbsForActor(component, outVector, actorForwardProxy);
			if (skillRotateStyle.IsPaused)
			{
				if (skillRotateStyle.ResumeRotateThreshold > 0f)
				{
					if (angleOffsetInGravityAbsForActor < skillRotateStyle.ResumeRotateThreshold)
					{
						outVector.DeepCopy(actorForwardProxy);
						return;
					}
					skillRotateStyle.IsPaused = false;
					return;
				}
			}
			else if (skillRotateStyle.PauseRotateThreshold > 0f && angleOffsetInGravityAbsForActor < skillRotateStyle.PauseRotateThreshold)
			{
				skillRotateStyle.IsPaused = true;
				outVector.DeepCopy(actorForwardProxy);
			}
		}
	}

	// Token: 0x0601A186 RID: 106886 RVA: 0x007A7CA0 File Offset: 0x007A5EA0
	public static UTraceLineElement GetStaticLineTrace()
	{
		if (SkillUtils._lineTrace == null)
		{
			SkillUtils._lineTrace = new UTraceLineElement();
			SkillUtils._lineTrace.bIsSingle = true;
			SkillUtils._lineTrace.bIgnoreSelf = true;
			SkillUtils._lineTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			SkillUtils._lineTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
		}
		SkillUtils._lineTrace.WorldContextObject = GlobalData.World;
		SkillUtils._lineTrace.ClearCacheData(false);
		return SkillUtils._lineTrace;
	}

	// Token: 0x0601A187 RID: 106887 RVA: 0x007A7D14 File Offset: 0x007A5F14
	public static FTransformDouble? GetTargetSocketTransform(Entity target, string socketName, ERelativeTransformSpace space, string reason, ESocketTransformDefault defaultTransform = ESocketTransformDefault.None)
	{
		CharacterActorComponent component = target.GetComponent<CharacterActorComponent>();
		TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
		if (tsBaseCharacter != null && tsBaseCharacter.IsValid() && !string.IsNullOrEmpty(socketName))
		{
			USkeletalMeshComponent mesh = tsBaseCharacter.Mesh;
			FName? dynamicFName = FNameUtil.GetDynamicFName(socketName);
			if (mesh != null && dynamicFName != null && mesh.DoesSocketExist(dynamicFName.Value))
			{
				return new FTransformDouble?(mesh.D_GetSocketTransform(dynamicFName.Value, space));
			}
		}
		if (defaultTransform == ESocketTransformDefault.BaseActor)
		{
			BaseActorComponent component2 = target.GetComponent<BaseActorComponent>();
			if (component2 == null)
			{
				return null;
			}
			return new FTransformDouble?(component2.ActorTransform);
		}
		else
		{
			if (defaultTransform != ESocketTransformDefault.CharacterActor)
			{
				return null;
			}
			if (component == null)
			{
				return null;
			}
			return new FTransformDouble?(component.ActorTransform);
		}
	}

	// Token: 0x0601A188 RID: 106888 RVA: 0x007A7DD4 File Offset: 0x007A5FD4
	private static void AddRemoveEntityListener(EntityHandle myHandle)
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.RemoveEntity;
		Action<ERemoveEntityType, EntityHandle> handle;
		if ((handle = SkillUtils.<>O.<0>__OnRemoveEntity) == null)
		{
			handle = (SkillUtils.<>O.<0>__OnRemoveEntity = new Action<ERemoveEntityType, EntityHandle>(SkillUtils.OnRemoveEntity));
		}
		if (!instance.HasWithTarget(myHandle, name, handle))
		{
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.RemoveEntity;
			Action<ERemoveEntityType, EntityHandle> handle2;
			if ((handle2 = SkillUtils.<>O.<0>__OnRemoveEntity) == null)
			{
				handle2 = (SkillUtils.<>O.<0>__OnRemoveEntity = new Action<ERemoveEntityType, EntityHandle>(SkillUtils.OnRemoveEntity));
			}
			instance2.AddWithTarget<ERemoveEntityType, EntityHandle>(myHandle, name2, handle2);
		}
	}

	// Token: 0x0601A189 RID: 106889 RVA: 0x007A7E3C File Offset: 0x007A603C
	private static void RemoveRemoveEntityListener(EntityHandle myHandle)
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.RemoveEntity;
		Action<ERemoveEntityType, EntityHandle> handle;
		if ((handle = SkillUtils.<>O.<0>__OnRemoveEntity) == null)
		{
			handle = (SkillUtils.<>O.<0>__OnRemoveEntity = new Action<ERemoveEntityType, EntityHandle>(SkillUtils.OnRemoveEntity));
		}
		if (instance.HasWithTarget(myHandle, name, handle))
		{
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.RemoveEntity;
			Action<ERemoveEntityType, EntityHandle> handle2;
			if ((handle2 = SkillUtils.<>O.<0>__OnRemoveEntity) == null)
			{
				handle2 = (SkillUtils.<>O.<0>__OnRemoveEntity = new Action<ERemoveEntityType, EntityHandle>(SkillUtils.OnRemoveEntity));
			}
			instance2.RemoveWithTarget(myHandle, name2, handle2);
		}
	}

	// Token: 0x0601A18A RID: 106890 RVA: 0x007A7EA2 File Offset: 0x007A60A2
	private static void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		SkillUtils.EndAbsoluteTimeStop(handle.Id);
		SkillUtils.EndTimeStopRequest(handle.Id);
	}

	// Token: 0x0601A18B RID: 106891 RVA: 0x007A7EBC File Offset: 0x007A60BC
	public static void BeginAbsoluteTimeStop(int entityId, float duration, bool stopMove, float timeScale = 0f)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetHandle(entityId) : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		WorldEntity entity = entityHandle.Entity;
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityHandle))
		{
			return;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if ((component == null || !component.IsRole()) && (component == null || !component.IsAutoRole()))
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, entity, "只有角色才能使用动画和子弹冻结功能", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!ControllerBase<TimeController>.Instance.AddLock(entityId, stopMove, timeScale))
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, entity, "重复调用动画和子弹冻结功能，将不做处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity, "开启大招时停", default(ReadOnlySpan<ValueTuple<string, object>>));
		SkillUtils.AddRemoveEntityListener(entityHandle);
		RTimeStopAnimPush rtimeStopAnimPush = new RTimeStopAnimPush();
		rtimeStopAnimPush.Dilation = (int)(timeScale * 100f);
		rtimeStopAnimPush.Duration = (int)(duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RTimeStopAnimPush, entity, rtimeStopAnimPush, null, null, null);
		Singleton<EventSystem>.Instance.Emit<bool, float>(EEventName.OnAbsoluteTimeStop, true, duration);
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, float>(entity, EEventName.OnAbsoluteTimeStop, true, duration);
	}

	// Token: 0x0601A18C RID: 106892 RVA: 0x007A8010 File Offset: 0x007A6210
	public static void EndAbsoluteTimeStop(int entityId)
	{
		if (!ControllerBase<TimeController>.Instance.RemoveLock(entityId))
		{
			return;
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetHandle(entityId) : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		WorldEntity entity = entityHandle.Entity;
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity, "结束大招时停", default(ReadOnlySpan<ValueTuple<string, object>>));
		SkillUtils.RemoveRemoveEntityListener(entityHandle);
		RTimeStopAnimPush rtimeStopAnimPush = new RTimeStopAnimPush();
		rtimeStopAnimPush.Dilation = 100;
		rtimeStopAnimPush.Duration = 0;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RTimeStopAnimPush, entity, rtimeStopAnimPush, null, null, null);
		Singleton<EventSystem>.Instance.Emit<bool, float>(EEventName.OnAbsoluteTimeStop, false, 0f);
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, float>(entity, EEventName.OnAbsoluteTimeStop, false, 0f);
	}

	// Token: 0x0601A18D RID: 106893 RVA: 0x007A80E4 File Offset: 0x007A62E4
	public static void BeginTimeStopRequest(int entityId, float duration, float timeScale = 0f)
	{
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetHandle(entityId) : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		WorldEntity entity = entityHandle.Entity;
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityHandle))
		{
			return;
		}
		if (!ControllerBase<TimeController>.Instance.AddTimeStopRequestLock(entityId, timeScale))
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, entity, "重复进入副本时停，将不做处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity, "开启副本时停", default(ReadOnlySpan<ValueTuple<string, object>>));
		SkillUtils.AddRemoveEntityListener(entityHandle);
		RTimeStopPush rtimeStopPush = new RTimeStopPush();
		rtimeStopPush.Dilation = (int)(timeScale * 100f);
		rtimeStopPush.Duration = (int)(duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RTimeStopPush, entity, rtimeStopPush, null, null, null);
		Singleton<EventSystem>.Instance.Emit<bool, float>(EEventName.OnTimeStopRequest, true, duration);
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, float>(entity, EEventName.OnTimeStopRequest, true, duration);
	}

	// Token: 0x0601A18E RID: 106894 RVA: 0x007A81F4 File Offset: 0x007A63F4
	public static void EndTimeStopRequest(int entityId)
	{
		if (!ControllerBase<TimeController>.Instance.RemoveTimeStopRequestLock(entityId))
		{
			return;
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetHandle(entityId) : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		WorldEntity entity = entityHandle.Entity;
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity, "结束副本时停", default(ReadOnlySpan<ValueTuple<string, object>>));
		SkillUtils.RemoveRemoveEntityListener(entityHandle);
		RTimeStopPush rtimeStopPush = new RTimeStopPush();
		rtimeStopPush.Dilation = 100;
		rtimeStopPush.Duration = 0;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RTimeStopPush, entity, rtimeStopPush, null, null, null);
		Singleton<EventSystem>.Instance.Emit<bool, float>(EEventName.OnTimeStopRequest, false, 0f);
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, float>(entity, EEventName.OnTimeStopRequest, false, 0f);
	}

	// Token: 0x0601A18F RID: 106895 RVA: 0x007A82C8 File Offset: 0x007A64C8
	[NullableContext(2)]
	public static bool IsTsActor(EntityHandle skillTarget)
	{
		EEntityType? eentityType;
		if (skillTarget == null)
		{
			eentityType = null;
		}
		else
		{
			WorldEntity entity = skillTarget.Entity;
			if (entity == null)
			{
				eentityType = null;
			}
			else
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				eentityType = ((component != null) ? new EEntityType?(component.GetEntityType()) : null);
			}
		}
		EEntityType? eentityType2 = eentityType;
		EEntityType? eentityType3 = eentityType2;
		EEntityType eentityType4 = EEntityType.Player;
		return (eentityType3.GetValueOrDefault() == eentityType4 & eentityType3 != null) || eentityType2.GetValueOrDefault() == EEntityType.Npc || eentityType2.GetValueOrDefault() == EEntityType.Monster || eentityType2.GetValueOrDefault() == EEntityType.Vision;
	}

	// Token: 0x0601A190 RID: 106896 RVA: 0x007A8350 File Offset: 0x007A6550
	public static void Log(CombatLog.ELogType logType, ESkillLogType skillLogType, Entity entity, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			CharacterGasDebugComponent component = entity.GetComponent<CharacterGasDebugComponent>();
			if (component != null && component.Valid)
			{
				if (skillLogType != ESkillLogType.Skill)
				{
					if (skillLogType != ESkillLogType.SkillBehavior)
					{
						CombatLog instance = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
						string message2 = "未知技能日志类型";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillLogType", skillLogType);
						instance.Error(flag, entity, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					component.AddSkillBehaviorLogString(message, pairs);
				}
				else
				{
					component.AddSkillLogString(message, pairs);
				}
			}
		}
		switch (logType)
		{
		case CombatLog.ELogType.Info:
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, entity, message, pairs);
			return;
		case CombatLog.ELogType.Debug:
			break;
		case CombatLog.ELogType.Warn:
			Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Skill, entity, message, pairs);
			return;
		case CombatLog.ELogType.Error:
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, entity, message, pairs);
			break;
		default:
			return;
		}
	}

	// Token: 0x0601A191 RID: 106897 RVA: 0x007A840B File Offset: 0x007A660B
	public static void CreateStaticDefaultValue()
	{
		SkillUtils._lineTrace = null;
	}

	// Token: 0x0601A192 RID: 106898 RVA: 0x007A8413 File Offset: 0x007A6613
	public static void ResetStaticDefaultValue()
	{
		SkillUtils._lineTrace = null;
	}

	// Token: 0x0400D16E RID: 53614
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400D16F RID: 53615
	[Nullable(2)]
	private static UTraceLineElement _lineTrace;

	// Token: 0x020093CB RID: 37835
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031261 RID: 201313
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<ERemoveEntityType, EntityHandle> <0>__OnRemoveEntity;
	}
}
