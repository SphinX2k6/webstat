using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E38 RID: 11832
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsSceneInteractBlueprintFunctionLibrary.TsSceneInteractBlueprintFunctionLibrary_C")]
public class TsSceneInteractBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x060183DA RID: 99290 RVA: 0x006C566E File Offset: 0x006C386E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetSitDownState(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		return component != null && component.GetSitDownState();
	}

	// Token: 0x060183DB RID: 99291 RVA: 0x006C5686 File Offset: 0x006C3886
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetEnterSitDownIndex(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		return (float)((component != null) ? component.EnterSitDownIndex : 0);
	}

	// Token: 0x060183DC RID: 99292 RVA: 0x006C56A0 File Offset: 0x006C38A0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetLeaveSitDownIndex(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		return (float)((component != null) ? component.LeaveSitDownIndex : 0);
	}

	// Token: 0x060183DD RID: 99293 RVA: 0x006C56BA File Offset: 0x006C38BA
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void PreLeaveSitDownAction(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.PreLeaveSitDownAction("");
	}

	// Token: 0x060183DE RID: 99294 RVA: 0x006C56D6 File Offset: 0x006C38D6
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LeaveSitDownAction(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.LeaveSitDownAction();
	}

	// Token: 0x060183DF RID: 99295 RVA: 0x006C56ED File Offset: 0x006C38ED
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor GetGiantActor(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.Giant;
	}

	// Token: 0x060183E0 RID: 99296 RVA: 0x006C5705 File Offset: 0x006C3905
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndCatapult(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.EndCatapult();
	}

	// Token: 0x060183E1 RID: 99297 RVA: 0x006C571C File Offset: 0x006C391C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndBounce(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.EndBounce();
	}

	// Token: 0x060183E2 RID: 99298 RVA: 0x006C5733 File Offset: 0x006C3933
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsAiDriver(int entityId)
	{
		CharacterAiComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAiComponent>(entityId);
		return component != null && component.IsAiDriver;
	}

	// Token: 0x060183E3 RID: 99299 RVA: 0x006C574B File Offset: 0x006C394B
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsDropItem(int entityId)
	{
		return Singleton<EntitySystem>.Instance.GetComponent<SceneItemDropItemComponent>(entityId) != null;
	}

	// Token: 0x060183E4 RID: 99300 RVA: 0x006C575C File Offset: 0x006C395C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void PickUpDropItem(int entityId, int targetEntityId)
	{
		CreatureDataComponent component = Singleton<EntitySystem>.Instance.Get(targetEntityId).GetComponent<CreatureDataComponent>();
		ControllerBase<RewardController>.Instance.PickUpFightDrop(component.GetCreatureDataId(), component.GetPbDataId(), null);
	}

	// Token: 0x060183E5 RID: 99301 RVA: 0x006C5792 File Offset: 0x006C3992
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void InteractSceneItem(int entityId, int targetEntityId)
	{
		PawnInteractNewComponent component = Singleton<EntitySystem>.Instance.GetComponent<PawnInteractNewComponent>(targetEntityId);
		if (component == null)
		{
			return;
		}
		component.ExecuteInteractFromVision(entityId);
	}

	// Token: 0x060183E6 RID: 99302 RVA: 0x006C57AA File Offset: 0x006C39AA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSceneInteractBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsSceneInteractBlueprintFunctionLibrary.TsSceneInteractBlueprintFunctionLibrary_C");
		}
		return TsSceneInteractBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060183E7 RID: 99303 RVA: 0x006C57D0 File Offset: 0x006C39D0
	public TsSceneInteractBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsSceneInteractBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060183E8 RID: 99304 RVA: 0x006C57F8 File Offset: 0x006C39F8
	[NullableContext(1)]
	public TsSceneInteractBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSceneInteractBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060183E9 RID: 99305 RVA: 0x006C582B File Offset: 0x006C3A2B
	protected TsSceneInteractBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060183EA RID: 99306 RVA: 0x006C5834 File Offset: 0x006C3A34
	protected unsafe static void __CPPCALL_GetSitDownState_Implementation(TsSceneInteractBlueprintFunctionLibrary.__GetSitDownState_FunctionParams* __Params)
	{
		__Params->__Result = TsSceneInteractBlueprintFunctionLibrary.GetSitDownState(__Params->entityId);
	}

	// Token: 0x060183EB RID: 99307 RVA: 0x006C5847 File Offset: 0x006C3A47
	protected unsafe static void __CPPCALL_GetEnterSitDownIndex_Implementation(TsSceneInteractBlueprintFunctionLibrary.__GetEnterSitDownIndex_FunctionParams* __Params)
	{
		__Params->__Result = TsSceneInteractBlueprintFunctionLibrary.GetEnterSitDownIndex(__Params->entityId);
	}

	// Token: 0x060183EC RID: 99308 RVA: 0x006C585A File Offset: 0x006C3A5A
	protected unsafe static void __CPPCALL_GetLeaveSitDownIndex_Implementation(TsSceneInteractBlueprintFunctionLibrary.__GetLeaveSitDownIndex_FunctionParams* __Params)
	{
		__Params->__Result = TsSceneInteractBlueprintFunctionLibrary.GetLeaveSitDownIndex(__Params->entityId);
	}

	// Token: 0x060183ED RID: 99309 RVA: 0x006C586D File Offset: 0x006C3A6D
	protected unsafe static void __CPPCALL_PreLeaveSitDownAction_Implementation(TsSceneInteractBlueprintFunctionLibrary.__PreLeaveSitDownAction_FunctionParams* __Params)
	{
		TsSceneInteractBlueprintFunctionLibrary.PreLeaveSitDownAction(__Params->entityId);
	}

	// Token: 0x060183EE RID: 99310 RVA: 0x006C587A File Offset: 0x006C3A7A
	protected unsafe static void __CPPCALL_LeaveSitDownAction_Implementation(TsSceneInteractBlueprintFunctionLibrary.__LeaveSitDownAction_FunctionParams* __Params)
	{
		TsSceneInteractBlueprintFunctionLibrary.LeaveSitDownAction(__Params->entityId);
	}

	// Token: 0x060183EF RID: 99311 RVA: 0x006C5887 File Offset: 0x006C3A87
	protected unsafe static void __CPPCALL_GetGiantActor_Implementation(TsSceneInteractBlueprintFunctionLibrary.__GetGiantActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor giantActor = TsSceneInteractBlueprintFunctionLibrary.GetGiantActor(__Params->entityId);
		ptr = ((giantActor != null) ? giantActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060183F0 RID: 99312 RVA: 0x006C58A9 File Offset: 0x006C3AA9
	protected unsafe static void __CPPCALL_EndCatapult_Implementation(TsSceneInteractBlueprintFunctionLibrary.__EndCatapult_FunctionParams* __Params)
	{
		TsSceneInteractBlueprintFunctionLibrary.EndCatapult(__Params->entityId);
	}

	// Token: 0x060183F1 RID: 99313 RVA: 0x006C58B6 File Offset: 0x006C3AB6
	protected unsafe static void __CPPCALL_EndBounce_Implementation(TsSceneInteractBlueprintFunctionLibrary.__EndBounce_FunctionParams* __Params)
	{
		TsSceneInteractBlueprintFunctionLibrary.EndBounce(__Params->entityId);
	}

	// Token: 0x060183F2 RID: 99314 RVA: 0x006C58C3 File Offset: 0x006C3AC3
	protected unsafe static void __CPPCALL_IsAiDriver_Implementation(TsSceneInteractBlueprintFunctionLibrary.__IsAiDriver_FunctionParams* __Params)
	{
		__Params->__Result = TsSceneInteractBlueprintFunctionLibrary.IsAiDriver(__Params->entityId);
	}

	// Token: 0x060183F3 RID: 99315 RVA: 0x006C58D6 File Offset: 0x006C3AD6
	protected unsafe static void __CPPCALL_IsDropItem_Implementation(TsSceneInteractBlueprintFunctionLibrary.__IsDropItem_FunctionParams* __Params)
	{
		__Params->__Result = TsSceneInteractBlueprintFunctionLibrary.IsDropItem(__Params->entityId);
	}

	// Token: 0x060183F4 RID: 99316 RVA: 0x006C58E9 File Offset: 0x006C3AE9
	protected unsafe static void __CPPCALL_PickUpDropItem_Implementation(TsSceneInteractBlueprintFunctionLibrary.__PickUpDropItem_FunctionParams* __Params)
	{
		TsSceneInteractBlueprintFunctionLibrary.PickUpDropItem(__Params->entityId, __Params->targetEntityId);
	}

	// Token: 0x060183F5 RID: 99317 RVA: 0x006C58FC File Offset: 0x006C3AFC
	protected unsafe static void __CPPCALL_InteractSceneItem_Implementation(TsSceneInteractBlueprintFunctionLibrary.__InteractSceneItem_FunctionParams* __Params)
	{
		TsSceneInteractBlueprintFunctionLibrary.InteractSceneItem(__Params->entityId, __Params->targetEntityId);
	}

	// Token: 0x0400BA32 RID: 47666
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsSceneInteractBlueprintFunctionLibrary.TsSceneInteractBlueprintFunctionLibrary_C";

	// Token: 0x0400BA33 RID: 47667
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA34 RID: 47668
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020092CD RID: 37581
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSitDownState_FunctionParams
	{
		// Token: 0x04030E93 RID: 200339
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E94 RID: 200340
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E95 RID: 200341
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020092CE RID: 37582
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEnterSitDownIndex_FunctionParams
	{
		// Token: 0x04030E96 RID: 200342
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E97 RID: 200343
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E98 RID: 200344
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020092CF RID: 37583
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetLeaveSitDownIndex_FunctionParams
	{
		// Token: 0x04030E99 RID: 200345
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E9A RID: 200346
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E9B RID: 200347
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020092D0 RID: 37584
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __PreLeaveSitDownAction_FunctionParams
	{
		// Token: 0x04030E9C RID: 200348
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E9D RID: 200349
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092D1 RID: 37585
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LeaveSitDownAction_FunctionParams
	{
		// Token: 0x04030E9E RID: 200350
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E9F RID: 200351
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092D2 RID: 37586
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetGiantActor_FunctionParams
	{
		// Token: 0x04030EA0 RID: 200352
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EA1 RID: 200353
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030EA2 RID: 200354
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020092D3 RID: 37587
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndCatapult_FunctionParams
	{
		// Token: 0x04030EA3 RID: 200355
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EA4 RID: 200356
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092D4 RID: 37588
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndBounce_FunctionParams
	{
		// Token: 0x04030EA5 RID: 200357
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EA6 RID: 200358
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092D5 RID: 37589
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsAiDriver_FunctionParams
	{
		// Token: 0x04030EA7 RID: 200359
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EA8 RID: 200360
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030EA9 RID: 200361
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020092D6 RID: 37590
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsDropItem_FunctionParams
	{
		// Token: 0x04030EAA RID: 200362
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EAB RID: 200363
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030EAC RID: 200364
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020092D7 RID: 37591
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __PickUpDropItem_FunctionParams
	{
		// Token: 0x04030EAD RID: 200365
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EAE RID: 200366
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x04030EAF RID: 200367
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092D8 RID: 37592
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __InteractSceneItem_FunctionParams
	{
		// Token: 0x04030EB0 RID: 200368
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030EB1 RID: 200369
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x04030EB2 RID: 200370
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
