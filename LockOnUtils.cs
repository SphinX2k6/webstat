using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020030BC RID: 12476
[NullableContext(2)]
[Nullable(0)]
public class LockOnUtils : IStaticVariableResetter
{
	// Token: 0x06019B66 RID: 105318 RVA: 0x0077B788 File Offset: 0x00779988
	static LockOnUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LockOnUtils.CreateStaticDefaultValue), new Action(LockOnUtils.ResetStaticDefaultValue));
	}

	// Token: 0x06019B67 RID: 105319 RVA: 0x0077B7A7 File Offset: 0x007799A7
	public static void CreateStaticDefaultValue()
	{
		LockOnUtils._lockOnIgnoreBlockTag = GameplayTagDefine.EGameplayTagId["角色.Common.索敌无视遮挡"];
	}

	// Token: 0x06019B68 RID: 105320 RVA: 0x0077B7BD File Offset: 0x007799BD
	public static void ResetStaticDefaultValue()
	{
		LockOnUtils._lockOnIgnoreBlockTag = 0;
		LockOnUtils._lineTrace = null;
	}

	// Token: 0x06019B69 RID: 105321 RVA: 0x0077B7CB File Offset: 0x007799CB
	public static bool CheckFriendCamp(int camp)
	{
		return camp == 0 || camp == 2 || camp == 4;
	}

	// Token: 0x06019B6A RID: 105322 RVA: 0x0077B7DC File Offset: 0x007799DC
	[NullableContext(1)]
	public static UTraceLineElement GetLockOnLineTrace([Nullable(2)] UObject worldContextObject, bool showLine = false)
	{
		if (LockOnUtils._lineTrace == null)
		{
			LockOnUtils._lineTrace = UE.NewObject<UTraceLineElement>(null, null, EObjectFlags.RF_NoFlags);
			LockOnUtils._lineTrace.bIsSingle = true;
			LockOnUtils._lineTrace.bIgnoreSelf = true;
			LockOnUtils._lineTrace.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		}
		LockOnUtils._lineTrace.WorldContextObject = worldContextObject;
		if (showLine)
		{
			LockOnUtils._lineTrace.DrawTime = 5f;
			LockOnUtils._lineTrace.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			Singleton<TraceElementCommon>.Instance.SetTraceColor(LockOnUtils._lineTrace, ColorUtils.LinearGreen);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(LockOnUtils._lineTrace, ColorUtils.LinearRed);
		}
		else
		{
			LockOnUtils._lineTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
		}
		return LockOnUtils._lineTrace;
	}

	// Token: 0x06019B6B RID: 105323 RVA: 0x0077B884 File Offset: 0x00779A84
	public static bool TraceDetectBlock(UObject worldContextObject, FVector from, FVector to, AActor targetActor, bool showLine = false, BaseTagComponent tagComp = null)
	{
		if (tagComp != null && tagComp.HasTag(LockOnUtils._lockOnIgnoreBlockTag))
		{
			return false;
		}
		UTraceLineElement lockOnLineTrace = LockOnUtils.GetLockOnLineTrace(worldContextObject, showLine);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lockOnLineTrace, from);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lockOnLineTrace, to);
		if (!Singleton<TraceElementCommon>.Instance.LineTrace(lockOnLineTrace, "LockOnUtils_TraceDetectBlock") || !lockOnLineTrace.HitResult.bBlockingHit)
		{
			return false;
		}
		AActor aactor = lockOnLineTrace.HitResult.Actors.Get(0).Get();
		AActor entityActorByChildActor = ModelBase<CreatureModel>.Instance.GetEntityActorByChildActor(aactor);
		return aactor != targetActor && entityActorByChildActor != targetActor;
	}

	// Token: 0x06019B6C RID: 105324 RVA: 0x0077B928 File Offset: 0x00779B28
	public unsafe static bool IsValidLockOnTarget(EntityHandle handle, FGameplayTagContainer lockOnGameplayTags = null, FGameplayTagContainer ignoreLockOnGameplayTagContainer = null, bool forceCheckTag = false)
	{
		if (handle == null || !handle.Valid || (handle == null || !handle.IsInit))
		{
			return false;
		}
		WorldEntity entity = handle.Entity;
		if (entity == null || !entity.Active)
		{
			return false;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component != null && component.GetRemoveState())
		{
			return false;
		}
		if (component == null || !component.GetVisible())
		{
			return false;
		}
		BaseTagComponent component2 = handle.Entity.GetComponent<BaseTagComponent>();
		if (component2 == null && forceCheckTag)
		{
			return false;
		}
		if (component2 != null)
		{
			int num = (ignoreLockOnGameplayTagContainer != null) ? ignoreLockOnGameplayTagContainer.GameplayTags.Num() : 0;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					FGameplayTag tag = ignoreLockOnGameplayTagContainer.GameplayTags.Get(i);
					if (component2.HasTag(tag.TagId()))
					{
						return false;
					}
				}
			}
			else
			{
				BaseTagComponent baseTagComponent = component2;
				<>y__InlineArray2<int> <>y__InlineArray = default(<>y__InlineArray2<int>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<int>, int>(ref <>y__InlineArray, 0) = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"];
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<int>, int>(ref <>y__InlineArray, 1) = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不可锁定"];
				ReadOnlySpan<int> readOnlySpan = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<int>, int>(<>y__InlineArray, 2);
				if (baseTagComponent.HasAnyTag(readOnlySpan))
				{
					return false;
				}
			}
			int num2 = (lockOnGameplayTags != null) ? lockOnGameplayTags.GameplayTags.Num() : 0;
			if (num2 > 0)
			{
				bool result = false;
				for (int j = 0; j < num2; j++)
				{
					FGameplayTag tag2 = lockOnGameplayTags.GameplayTags.Get(j);
					if (component2.HasTag(tag2.TagId()))
					{
						result = true;
						break;
					}
				}
				return result;
			}
		}
		return true;
	}

	// Token: 0x06019B6D RID: 105325 RVA: 0x0077BAB0 File Offset: 0x00779CB0
	public static FVectorDouble? GetLockOnTargetLocation(AActor target)
	{
		FVectorDouble? result = null;
		if (target == null || !target.IsValid())
		{
			return result;
		}
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(target, false);
		if (entityByActor != null)
		{
			WorldEntity entity = entityByActor.Entity;
			SceneItemActorComponent sceneItemActorComponent = (entity != null) ? entity.GetComponent<SceneItemActorComponent>() : null;
			if (sceneItemActorComponent != null)
			{
				SceneInteractionActor sceneInteractionActor = sceneItemActorComponent.GetInteractionMainActor() as SceneInteractionActor;
				if (sceneInteractionActor != null)
				{
					AActor actorByKey = sceneInteractionActor.GetActorByKey("Center");
					if (actorByKey != null)
					{
						result = new FVectorDouble?(actorByKey.D_K2_GetActorLocation());
					}
				}
			}
			FVectorDouble value = result.GetValueOrDefault();
			if (result == null)
			{
				value = entityByActor.Entity.GetComponent<BaseActorComponent>().ActorLocation;
				result = new FVectorDouble?(value);
			}
		}
		else
		{
			result = new FVectorDouble?(target.D_K2_GetActorLocation());
		}
		return result;
	}

	// Token: 0x0400CCD2 RID: 52434
	[Nullable(1)]
	private const string SCENE_ITEM_ACTOR_KEY = "Center";

	// Token: 0x0400CCD3 RID: 52435
	[Nullable(1)]
	private const string PROFILE_KEY = "LockOnUtils_TraceDetectBlock";

	// Token: 0x0400CCD4 RID: 52436
	private static int _lockOnIgnoreBlockTag;

	// Token: 0x0400CCD5 RID: 52437
	private static UTraceLineElement _lineTrace;
}
