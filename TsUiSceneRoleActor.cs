using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002C55 RID: 11349
[UClass("/Game/Aki/TypeScript/Game/Module/UiComponent/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneRoleActor.TsUiSceneRoleActor_C")]
public class TsUiSceneRoleActor : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x06016C14 RID: 93204 RVA: 0x0064FEB0 File Offset: 0x0064E0B0
	public void Init(int roleActorIndex, EUiModelUseWay useWay)
	{
		this.RoleActorIndex = roleActorIndex;
		base.SetTickableWhenPaused(true);
		base.SetActorTickEnabled(true);
		base.CustomTimeDilation = ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
		UKuroRenderingRuntimeBPPluginBPLibrary.SetActorUISceneRendering(this, true);
		this.Model = Singleton<UiModelSystem>.Instance.CreateUiModelByUseWay(useWay, this);
		UiModelBase model = this.Model;
		if (model != null)
		{
			model.Init();
		}
		UiModelBase model2 = this.Model;
		if (model2 != null)
		{
			model2.Start();
		}
		base.SetPrimitiveEntityType(1U);
	}

	// Token: 0x06016C15 RID: 93205 RVA: 0x0064FF24 File Offset: 0x0064E124
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06016C16 RID: 93206 RVA: 0x0064FF9A File Offset: 0x0064E19A
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		UiModelBase model = this.Model;
		if (model == null)
		{
			return;
		}
		model.Tick(deltaSeconds);
	}

	// Token: 0x06016C17 RID: 93207 RVA: 0x0064FFAD File Offset: 0x0064E1AD
	public int GetRoleActorIndex()
	{
		return this.RoleActorIndex;
	}

	// Token: 0x06016C18 RID: 93208 RVA: 0x0064FFB5 File Offset: 0x0064E1B5
	public void Destroy()
	{
		UiModelBase model = this.Model;
		if (model != null)
		{
			model.End();
		}
		UiModelBase model2 = this.Model;
		if (model2 != null)
		{
			model2.Clear();
		}
		this.Model = null;
		this.RoleActorIndex = 0;
		UKuroActorManager.DestroyActor(this);
	}

	// Token: 0x06016C19 RID: 93209 RVA: 0x0064FFF0 File Offset: 0x0064E1F0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool IsShowUiWepaonEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("IsShowUiWepaonEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams*)ptr + 15L / (long)sizeof(TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06016C1A RID: 93210 RVA: 0x00650065 File Offset: 0x0064E265
	protected bool IsShowUiWepaonEffect_Implementation()
	{
		return true;
	}

	// Token: 0x06016C1B RID: 93211 RVA: 0x00650068 File Offset: 0x0064E268
	public void SetMoveOutActor()
	{
		this.BeforeMoveOutPos = base.D_K2_GetActorLocation();
		FHitResult fhitResult = null;
		base.D_K2_SetActorLocation(Vector.ZeroVectorDouble, false, ref fhitResult, false);
	}

	// Token: 0x06016C1C RID: 93212 RVA: 0x00650094 File Offset: 0x0064E294
	public void SetMoveInActor()
	{
		FHitResult fhitResult = null;
		base.D_K2_SetActorLocation(this.BeforeMoveOutPos, false, ref fhitResult, false);
	}

	// Token: 0x06016C1D RID: 93213 RVA: 0x006500B4 File Offset: 0x0064E2B4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiSceneRoleActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneRoleActor.TsUiSceneRoleActor_C");
		}
		return TsUiSceneRoleActor._ClassPtr;
	}

	// Token: 0x06016C1E RID: 93214 RVA: 0x006500D8 File Offset: 0x0064E2D8
	public TsUiSceneRoleActor() : this(BuiltinUtils.AllocNativeUObject(TsUiSceneRoleActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06016C1F RID: 93215 RVA: 0x00650100 File Offset: 0x0064E300
	[NullableContext(1)]
	public TsUiSceneRoleActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiSceneRoleActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06016C20 RID: 93216 RVA: 0x00650133 File Offset: 0x0064E333
	protected TsUiSceneRoleActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17001DD9 RID: 7641
	// (get) Token: 0x06016C21 RID: 93217 RVA: 0x00650147 File Offset: 0x0064E347
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsUiSceneRoleActor.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17001DDA RID: 7642
	// (get) Token: 0x06016C22 RID: 93218 RVA: 0x00650157 File Offset: 0x0064E357
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsUiSceneRoleActor.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06016C23 RID: 93219 RVA: 0x0065016B File Offset: 0x0064E36B
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x06016C24 RID: 93220 RVA: 0x00650179 File Offset: 0x0064E379
	protected unsafe virtual void __CPPCALL_IsShowUiWepaonEffect_Implementation(TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams* __Params)
	{
		__Params->__Result = this.IsShowUiWepaonEffect_Implementation();
	}

	// Token: 0x0400AF5D RID: 44893
	[Nullable(2)]
	public UiModelBase Model;

	// Token: 0x0400AF5E RID: 44894
	private int RoleActorIndex;

	// Token: 0x0400AF5F RID: 44895
	private FVectorDouble BeforeMoveOutPos = Vector.ZeroVectorDouble;

	// Token: 0x0400AF60 RID: 44896
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneRoleActor.TsUiSceneRoleActor_C";

	// Token: 0x0400AF61 RID: 44897
	private static IntPtr _ClassPtr;

	// Token: 0x0400AF62 RID: 44898
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400AF63 RID: 44899
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400AF64 RID: 44900
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x02008F6C RID: 36716
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __IsShowUiWepaonEffect_FunctionParams
	{
		// Token: 0x04030287 RID: 197255
		[FieldOffset(0)]
		public bool __Result;
	}
}
