using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.World;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E32 RID: 11826
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsExploreComponentBlueprintFunctionLibrary.TsExploreComponentBlueprintFunctionLibrary_C")]
public class TsExploreComponentBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06017FD5 RID: 98261 RVA: 0x006B7974 File Offset: 0x006B5B74
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static FVectorDouble CharacterGetHookLocation(int characterEntityId)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(characterEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || grapplingHookPointComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 角色获取当前交互钩锁点坐标失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CharacterEntityId", characterEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return FVectorDouble.ZeroVector;
		}
		return grapplingHookPointComponent.HookLocation.ToUeVector(false);
	}

	// Token: 0x06017FD6 RID: 98262 RVA: 0x006B7A70 File Offset: 0x006B5C70
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static FVectorDouble MotorcycleGetHookLocation(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || grapplingHookPointComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车获取当前交互钩锁点坐标失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return FVectorDouble.ZeroVector;
		}
		return grapplingHookPointComponent.HookLocation.ToUeVector(false);
	}

	// Token: 0x06017FD7 RID: 98263 RVA: 0x006B7B6C File Offset: 0x006B5D6C
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int CharacterGetInteractingHookEntityId(int characterEntityId)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(characterEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || grapplingHookPointComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车获取当前交互钩锁点实体Id失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CharacterEntityId", characterEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		return grapplingHookPointComponent.Entity.Id;
	}

	// Token: 0x06017FD8 RID: 98264 RVA: 0x006B7C64 File Offset: 0x006B5E64
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static int MotorcycleGetInteractingHookEntityId(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || grapplingHookPointComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车获取当前交互钩锁点实体Id失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		return grapplingHookPointComponent.Entity.Id;
	}

	// Token: 0x06017FD9 RID: 98265 RVA: 0x006B7D5C File Offset: 0x006B5F5C
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static EHookInteractTypeBp CharacterGetInteractingHookType(int characterEntityId)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(characterEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || grapplingHookPointComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 角色获取当前交互物类型失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CharacterEntityId", characterEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return EHookInteractTypeBp.FixedPointHook;
		}
		return grapplingHookPointComponent.GetHookInteractTypeBp();
	}

	// Token: 0x06017FDA RID: 98266 RVA: 0x006B7E4C File Offset: 0x006B604C
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static EHookInteractTypeBp MotorcycleGetInteractingHookType(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || grapplingHookPointComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车获取当前交互物类型失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return EHookInteractTypeBp.FixedPointHook;
		}
		return grapplingHookPointComponent.GetHookInteractTypeBp();
	}

	// Token: 0x06017FDB RID: 98267 RVA: 0x006B7F3C File Offset: 0x006B613C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool MotorcyclePullCollection(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		return component != null && component.Valid && component.TryPullCollection();
	}

	// Token: 0x06017FDC RID: 98268 RVA: 0x006B7F68 File Offset: 0x006B6168
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsMotorcyclePullingCollectionWithProgress(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent pullingTarget = component.PullingTarget;
			return pullingTarget != null && pullingTarget.PullCollectionWithProgress;
		}
		return false;
	}

	// Token: 0x06017FDD RID: 98269 RVA: 0x006B7FA0 File Offset: 0x006B61A0
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static bool MotorcycleCheckPullCollectionFinished(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		if (component == null || !component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 检查摩托车拉取采集物是否完成失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "EntityConfigId";
			int? num;
			if (component == null)
			{
				num = null;
			}
			else
			{
				GrapplingHookPointComponent pullingTarget = component.PullingTarget;
				num = ((pullingTarget != null) ? new int?(pullingTarget.EntityConfigId) : null);
			}
			ptr = new ValueTuple<string, object>(item, num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		GrapplingHookPointComponent pullingTarget2 = component.PullingTarget;
		return pullingTarget2 == null || pullingTarget2.MoveFinish;
	}

	// Token: 0x06017FDE RID: 98270 RVA: 0x006B80A4 File Offset: 0x006B62A4
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static bool MotorcycleForceLockTarget(int motorcycleEntityId, int targetEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		GrapplingHookPointComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<GrapplingHookPointComponent>(targetEntityId);
		if (component == null || !component.Valid || (component2 == null || !component2.Valid))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车强制锁定目标失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetEntityId", targetEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetEntityConfigId", (component2 != null) ? new int?(component2.EntityConfigId) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		return component.ForceLockTarget(component2, "MotorcycleForceLockTarget");
	}

	// Token: 0x06017FDF RID: 98271 RVA: 0x006B8190 File Offset: 0x006B6390
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static bool CharacterForceLockTarget(int characterEntityId, int targetEntityId)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(characterEntityId);
		GrapplingHookPointComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<GrapplingHookPointComponent>(targetEntityId);
		if (component == null || !component.Valid || (component2 == null || !component2.Valid))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 角色强制锁定目标失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CharacterEntityId", characterEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetEntityId", targetEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetEntityConfigId", (component2 != null) ? new int?(component2.EntityConfigId) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		return component.ForceLockTarget(component2, "CharacterForceLockTarget");
	}

	// Token: 0x06017FE0 RID: 98272 RVA: 0x006B827C File Offset: 0x006B647C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool CharacterCancelLockTarget(int characterEntityId, bool resetFocusTarget)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(characterEntityId);
		if (component == null || !component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 角色取消锁定目标失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CharacterEntityId", characterEntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		component.CancelLockTarget("CharacterCancelLockTarget", resetFocusTarget);
		return true;
	}

	// Token: 0x06017FE1 RID: 98273 RVA: 0x006B82E4 File Offset: 0x006B64E4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static bool MotorcycleGetFixHookParams(int motorcycleEntityId, ref float speed, ref UCurveFloat speedCurve, ref bool needQuat, ref FQuat targetQuat, ref UCurveFloat quatCurve)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.InteractingTarget : null;
		if (component == null || !component.Valid || (grapplingHookPointComponent == null || !grapplingHookPointComponent.Valid))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车获取钩锁配置失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetEntityConfigId", (grapplingHookPointComponent != null) ? new int?(grapplingHookPointComponent.EntityConfigId) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		grapplingHookPointComponent.GetMotorcycleFixHookParams(ref speed, ref speedCurve, ref needQuat, ref targetQuat, ref quatCurve);
		return true;
	}

	// Token: 0x06017FE2 RID: 98274 RVA: 0x006B83B4 File Offset: 0x006B65B4
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static void SetExploreComponentSyncEnabled(int entityId, bool enabled)
	{
		BaseExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseExploreComponent>(entityId);
		if (component == null || !component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 探索组件同步开关设置失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Character;
		ELogAuthor author2 = ELogAuthor.CK;
		string message2 = "[TsExploreComponentBlueprintFunctionLibrary] 探索组件同步开关";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", entityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SyncEnabled(Before)", component.SyncEnabled);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("SyncEnabled(After))", enabled);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		component.SyncEnabled = enabled;
	}

	// Token: 0x06017FE3 RID: 98275 RVA: 0x006B84DC File Offset: 0x006B66DC
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static long GetCharacterFixHookBuffIdByTarget(int characterEntityId)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(characterEntityId);
		if (component == null || !component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 角色获取定点钩锁BuffId失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CharacterEntityId", characterEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0L;
		}
		return component.GetFixHookBuffIdByTarget();
	}

	// Token: 0x06017FE4 RID: 98276 RVA: 0x006B8584 File Offset: 0x006B6784
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static long GetMotorcyclePullCollectionBuffIdByTarget(int motorcycleEntityId)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		if (component == null || !component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车获取拉取采集物BuffId失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0L;
		}
		return component.GetPullCollectionBuffIdByTarget();
	}

	// Token: 0x06017FE5 RID: 98277 RVA: 0x006B862C File Offset: 0x006B682C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool TransferRoleInteractingTargetToVehicle(int roleEntityId, int vehicleEntityId)
	{
		CharacterExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterExploreComponent>(roleEntityId);
		if (component == null || !component.Valid)
		{
			return false;
		}
		GrapplingHookPointComponent grapplingHookPointComponent = component.InteractingTarget;
		if (grapplingHookPointComponent == null)
		{
			grapplingHookPointComponent = component.FocusTarget;
		}
		if (grapplingHookPointComponent == null)
		{
			return false;
		}
		MotorcycleExploreComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(vehicleEntityId);
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		component2.SetFocusTarget(grapplingHookPointComponent, true);
		return true;
	}

	// Token: 0x06017FE6 RID: 98278 RVA: 0x006B8698 File Offset: 0x006B6898
	[UFunction(EFunctionFlags.FUNC_None)]
	protected unsafe static void SetIsHookEndByInterrupt(int motorcycleEntityId, bool isInterrupt)
	{
		MotorcycleExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<MotorcycleExploreComponent>(motorcycleEntityId);
		if (component != null && component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary] 摩托车设置钩锁打断标志";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MotorcycleEntityId", motorcycleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ExploreComponent", (component != null) ? new bool?(component.Valid) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			component.SetIsHookEndByInterruptProxy(isInterrupt);
		}
	}

	// Token: 0x06017FE7 RID: 98279 RVA: 0x006B873B File Offset: 0x006B693B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsExploreComponentBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsExploreComponentBlueprintFunctionLibrary.TsExploreComponentBlueprintFunctionLibrary_C");
		}
		return TsExploreComponentBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06017FE8 RID: 98280 RVA: 0x006B8760 File Offset: 0x006B6960
	public TsExploreComponentBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsExploreComponentBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017FE9 RID: 98281 RVA: 0x006B8788 File Offset: 0x006B6988
	[NullableContext(1)]
	public TsExploreComponentBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsExploreComponentBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017FEA RID: 98282 RVA: 0x006B87BB File Offset: 0x006B69BB
	protected TsExploreComponentBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06017FEB RID: 98283 RVA: 0x006B87C4 File Offset: 0x006B69C4
	protected unsafe static void __CPPCALL_CharacterGetHookLocation_Implementation(TsExploreComponentBlueprintFunctionLibrary.__CharacterGetHookLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.CharacterGetHookLocation(__Params->characterEntityId);
	}

	// Token: 0x06017FEC RID: 98284 RVA: 0x006B87D7 File Offset: 0x006B69D7
	protected unsafe static void __CPPCALL_MotorcycleGetHookLocation_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcycleGetHookLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.MotorcycleGetHookLocation(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FED RID: 98285 RVA: 0x006B87EA File Offset: 0x006B69EA
	protected unsafe static void __CPPCALL_CharacterGetInteractingHookEntityId_Implementation(TsExploreComponentBlueprintFunctionLibrary.__CharacterGetInteractingHookEntityId_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.CharacterGetInteractingHookEntityId(__Params->characterEntityId);
	}

	// Token: 0x06017FEE RID: 98286 RVA: 0x006B87FD File Offset: 0x006B69FD
	protected unsafe static void __CPPCALL_MotorcycleGetInteractingHookEntityId_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcycleGetInteractingHookEntityId_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.MotorcycleGetInteractingHookEntityId(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FEF RID: 98287 RVA: 0x006B8810 File Offset: 0x006B6A10
	protected unsafe static void __CPPCALL_CharacterGetInteractingHookType_Implementation(TsExploreComponentBlueprintFunctionLibrary.__CharacterGetInteractingHookType_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsExploreComponentBlueprintFunctionLibrary.CharacterGetInteractingHookType(__Params->characterEntityId);
	}

	// Token: 0x06017FF0 RID: 98288 RVA: 0x006B8825 File Offset: 0x006B6A25
	protected unsafe static void __CPPCALL_MotorcycleGetInteractingHookType_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcycleGetInteractingHookType_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsExploreComponentBlueprintFunctionLibrary.MotorcycleGetInteractingHookType(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FF1 RID: 98289 RVA: 0x006B883A File Offset: 0x006B6A3A
	protected unsafe static void __CPPCALL_MotorcyclePullCollection_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcyclePullCollection_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.MotorcyclePullCollection(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FF2 RID: 98290 RVA: 0x006B884D File Offset: 0x006B6A4D
	protected unsafe static void __CPPCALL_IsMotorcyclePullingCollectionWithProgress_Implementation(TsExploreComponentBlueprintFunctionLibrary.__IsMotorcyclePullingCollectionWithProgress_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.IsMotorcyclePullingCollectionWithProgress(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FF3 RID: 98291 RVA: 0x006B8860 File Offset: 0x006B6A60
	protected unsafe static void __CPPCALL_MotorcycleCheckPullCollectionFinished_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcycleCheckPullCollectionFinished_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.MotorcycleCheckPullCollectionFinished(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FF4 RID: 98292 RVA: 0x006B8873 File Offset: 0x006B6A73
	protected unsafe static void __CPPCALL_MotorcycleForceLockTarget_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcycleForceLockTarget_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.MotorcycleForceLockTarget(__Params->motorcycleEntityId, __Params->targetEntityId);
	}

	// Token: 0x06017FF5 RID: 98293 RVA: 0x006B888C File Offset: 0x006B6A8C
	protected unsafe static void __CPPCALL_CharacterForceLockTarget_Implementation(TsExploreComponentBlueprintFunctionLibrary.__CharacterForceLockTarget_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.CharacterForceLockTarget(__Params->characterEntityId, __Params->targetEntityId);
	}

	// Token: 0x06017FF6 RID: 98294 RVA: 0x006B88A5 File Offset: 0x006B6AA5
	protected unsafe static void __CPPCALL_CharacterCancelLockTarget_Implementation(TsExploreComponentBlueprintFunctionLibrary.__CharacterCancelLockTarget_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.CharacterCancelLockTarget(__Params->characterEntityId, __Params->resetFocusTarget);
	}

	// Token: 0x06017FF7 RID: 98295 RVA: 0x006B88C0 File Offset: 0x006B6AC0
	protected unsafe static void __CPPCALL_MotorcycleGetFixHookParams_Implementation(TsExploreComponentBlueprintFunctionLibrary.__MotorcycleGetFixHookParams_FunctionParams* __Params)
	{
		UCurveFloat orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UCurveFloat>(__Params->speedCurve);
		UCurveFloat orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UCurveFloat>(__Params->quatCurve);
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.MotorcycleGetFixHookParams(__Params->motorcycleEntityId, ref __Params->speed, ref orCreateUObjectByNativePointer, ref __Params->needQuat, ref __Params->targetQuat, ref orCreateUObjectByNativePointer2);
		*(&__Params->speedCurve) = ((orCreateUObjectByNativePointer != null) ? orCreateUObjectByNativePointer.NativePtr : ((IntPtr)0));
		*(&__Params->quatCurve) = ((orCreateUObjectByNativePointer2 != null) ? orCreateUObjectByNativePointer2.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06017FF8 RID: 98296 RVA: 0x006B8936 File Offset: 0x006B6B36
	protected unsafe static void __CPPCALL_SetExploreComponentSyncEnabled_Implementation(TsExploreComponentBlueprintFunctionLibrary.__SetExploreComponentSyncEnabled_FunctionParams* __Params)
	{
		TsExploreComponentBlueprintFunctionLibrary.SetExploreComponentSyncEnabled(__Params->entityId, __Params->enabled);
	}

	// Token: 0x06017FF9 RID: 98297 RVA: 0x006B8949 File Offset: 0x006B6B49
	protected unsafe static void __CPPCALL_GetCharacterFixHookBuffIdByTarget_Implementation(TsExploreComponentBlueprintFunctionLibrary.__GetCharacterFixHookBuffIdByTarget_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.GetCharacterFixHookBuffIdByTarget(__Params->characterEntityId);
	}

	// Token: 0x06017FFA RID: 98298 RVA: 0x006B895C File Offset: 0x006B6B5C
	protected unsafe static void __CPPCALL_GetMotorcyclePullCollectionBuffIdByTarget_Implementation(TsExploreComponentBlueprintFunctionLibrary.__GetMotorcyclePullCollectionBuffIdByTarget_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.GetMotorcyclePullCollectionBuffIdByTarget(__Params->motorcycleEntityId);
	}

	// Token: 0x06017FFB RID: 98299 RVA: 0x006B896F File Offset: 0x006B6B6F
	protected unsafe static void __CPPCALL_TransferRoleInteractingTargetToVehicle_Implementation(TsExploreComponentBlueprintFunctionLibrary.__TransferRoleInteractingTargetToVehicle_FunctionParams* __Params)
	{
		__Params->__Result = TsExploreComponentBlueprintFunctionLibrary.TransferRoleInteractingTargetToVehicle(__Params->roleEntityId, __Params->vehicleEntityId);
	}

	// Token: 0x06017FFC RID: 98300 RVA: 0x006B8988 File Offset: 0x006B6B88
	protected unsafe static void __CPPCALL_SetIsHookEndByInterrupt_Implementation(TsExploreComponentBlueprintFunctionLibrary.__SetIsHookEndByInterrupt_FunctionParams* __Params)
	{
		TsExploreComponentBlueprintFunctionLibrary.SetIsHookEndByInterrupt(__Params->motorcycleEntityId, __Params->isInterrupt);
	}

	// Token: 0x0400BA14 RID: 47636
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsExploreComponentBlueprintFunctionLibrary.TsExploreComponentBlueprintFunctionLibrary_C";

	// Token: 0x0400BA15 RID: 47637
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA16 RID: 47638
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020090DC RID: 37084
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __CharacterGetHookLocation_FunctionParams
	{
		// Token: 0x0403081E RID: 198686
		[FieldOffset(0)]
		public int characterEntityId;

		// Token: 0x0403081F RID: 198687
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030820 RID: 198688
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020090DD RID: 37085
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __MotorcycleGetHookLocation_FunctionParams
	{
		// Token: 0x04030821 RID: 198689
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030822 RID: 198690
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030823 RID: 198691
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020090DE RID: 37086
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CharacterGetInteractingHookEntityId_FunctionParams
	{
		// Token: 0x04030824 RID: 198692
		[FieldOffset(0)]
		public int characterEntityId;

		// Token: 0x04030825 RID: 198693
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030826 RID: 198694
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x020090DF RID: 37087
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MotorcycleGetInteractingHookEntityId_FunctionParams
	{
		// Token: 0x04030827 RID: 198695
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030828 RID: 198696
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030829 RID: 198697
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x020090E0 RID: 37088
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CharacterGetInteractingHookType_FunctionParams
	{
		// Token: 0x0403082A RID: 198698
		[FieldOffset(0)]
		public int characterEntityId;

		// Token: 0x0403082B RID: 198699
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403082C RID: 198700
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020090E1 RID: 37089
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MotorcycleGetInteractingHookType_FunctionParams
	{
		// Token: 0x0403082D RID: 198701
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x0403082E RID: 198702
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403082F RID: 198703
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020090E2 RID: 37090
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MotorcyclePullCollection_FunctionParams
	{
		// Token: 0x04030830 RID: 198704
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030831 RID: 198705
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030832 RID: 198706
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090E3 RID: 37091
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsMotorcyclePullingCollectionWithProgress_FunctionParams
	{
		// Token: 0x04030833 RID: 198707
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030834 RID: 198708
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030835 RID: 198709
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090E4 RID: 37092
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MotorcycleCheckPullCollectionFinished_FunctionParams
	{
		// Token: 0x04030836 RID: 198710
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030837 RID: 198711
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030838 RID: 198712
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090E5 RID: 37093
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MotorcycleForceLockTarget_FunctionParams
	{
		// Token: 0x04030839 RID: 198713
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x0403083A RID: 198714
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x0403083B RID: 198715
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403083C RID: 198716
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090E6 RID: 37094
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CharacterForceLockTarget_FunctionParams
	{
		// Token: 0x0403083D RID: 198717
		[FieldOffset(0)]
		public int characterEntityId;

		// Token: 0x0403083E RID: 198718
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x0403083F RID: 198719
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030840 RID: 198720
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090E7 RID: 37095
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CharacterCancelLockTarget_FunctionParams
	{
		// Token: 0x04030841 RID: 198721
		[FieldOffset(0)]
		public int characterEntityId;

		// Token: 0x04030842 RID: 198722
		[FieldOffset(4)]
		public bool resetFocusTarget;

		// Token: 0x04030843 RID: 198723
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030844 RID: 198724
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090E8 RID: 37096
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __MotorcycleGetFixHookParams_FunctionParams
	{
		// Token: 0x04030845 RID: 198725
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030846 RID: 198726
		[FieldOffset(4)]
		public float speed;

		// Token: 0x04030847 RID: 198727
		[FieldOffset(8)]
		public IntPtr speedCurve;

		// Token: 0x04030848 RID: 198728
		[FieldOffset(16)]
		public bool needQuat;

		// Token: 0x04030849 RID: 198729
		[FieldOffset(32)]
		public FQuat targetQuat;

		// Token: 0x0403084A RID: 198730
		[FieldOffset(48)]
		public IntPtr quatCurve;

		// Token: 0x0403084B RID: 198731
		[FieldOffset(56)]
		public IntPtr __WorldContext;

		// Token: 0x0403084C RID: 198732
		[FieldOffset(64)]
		public bool __Result;
	}

	// Token: 0x020090E9 RID: 37097
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetExploreComponentSyncEnabled_FunctionParams
	{
		// Token: 0x0403084D RID: 198733
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403084E RID: 198734
		[FieldOffset(4)]
		public bool enabled;

		// Token: 0x0403084F RID: 198735
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090EA RID: 37098
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCharacterFixHookBuffIdByTarget_FunctionParams
	{
		// Token: 0x04030850 RID: 198736
		[FieldOffset(0)]
		public int characterEntityId;

		// Token: 0x04030851 RID: 198737
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030852 RID: 198738
		[FieldOffset(16)]
		public long __Result;
	}

	// Token: 0x020090EB RID: 37099
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMotorcyclePullCollectionBuffIdByTarget_FunctionParams
	{
		// Token: 0x04030853 RID: 198739
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x04030854 RID: 198740
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030855 RID: 198741
		[FieldOffset(16)]
		public long __Result;
	}

	// Token: 0x020090EC RID: 37100
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __TransferRoleInteractingTargetToVehicle_FunctionParams
	{
		// Token: 0x04030856 RID: 198742
		[FieldOffset(0)]
		public int roleEntityId;

		// Token: 0x04030857 RID: 198743
		[FieldOffset(4)]
		public int vehicleEntityId;

		// Token: 0x04030858 RID: 198744
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030859 RID: 198745
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090ED RID: 37101
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetIsHookEndByInterrupt_FunctionParams
	{
		// Token: 0x0403085A RID: 198746
		[FieldOffset(0)]
		public int motorcycleEntityId;

		// Token: 0x0403085B RID: 198747
		[FieldOffset(4)]
		public bool isInterrupt;

		// Token: 0x0403085C RID: 198748
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
