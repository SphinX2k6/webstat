using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LongGrass
{
	// Token: 0x02003C5F RID: 15455
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LongGrass/BP_WeaponEnvInteraction.BP_WeaponEnvInteraction_C")]
	[UnrealStructLayout(1600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1596)]
	public class BP_WeaponEnvInteraction_C : AKuroWeaponEnvInteraction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023BE7 RID: 146407 RVA: 0x0098ADF4 File Offset: 0x00988FF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeaponEnvInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LongGrass/BP_WeaponEnvInteraction.BP_WeaponEnvInteraction_C");
			}
			return BP_WeaponEnvInteraction_C._ClassPtr;
		}

		// Token: 0x06023BE8 RID: 146408 RVA: 0x0098AE18 File Offset: 0x00989018
		public BP_WeaponEnvInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeaponEnvInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023BE9 RID: 146409 RVA: 0x0098AE40 File Offset: 0x00989040
		[NullableContext(1)]
		public BP_WeaponEnvInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeaponEnvInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004817 RID: 18455
		// (get) Token: 0x06023BEA RID: 146410 RVA: 0x0098AE74 File Offset: 0x00989074
		// (set) Token: 0x06023BEB RID: 146411 RVA: 0x0098AEAD File Offset: 0x009890AD
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WeaponEnvInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WeaponEnvInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004818 RID: 18456
		// (get) Token: 0x06023BEC RID: 146412 RVA: 0x0098AECE File Offset: 0x009890CE
		// (set) Token: 0x06023BED RID: 146413 RVA: 0x0098AEE2 File Offset: 0x009890E2
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004819 RID: 18457
		// (get) Token: 0x06023BEE RID: 146414 RVA: 0x0098AEF7 File Offset: 0x009890F7
		// (set) Token: 0x06023BEF RID: 146415 RVA: 0x0098AF0B File Offset: 0x0098910B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700481A RID: 18458
		// (get) Token: 0x06023BF0 RID: 146416 RVA: 0x0098AF20 File Offset: 0x00989120
		// (set) Token: 0x06023BF1 RID: 146417 RVA: 0x0098AF34 File Offset: 0x00989134
		public unsafe BP_SceneBattleInteract_C Config
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700481B RID: 18459
		// (get) Token: 0x06023BF2 RID: 146418 RVA: 0x0098AF49 File Offset: 0x00989149
		// (set) Token: 0x06023BF3 RID: 146419 RVA: 0x0098AF5D File Offset: 0x0098915D
		public unsafe BP_WeaponEnvReadback_C GPUReadBackActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WeaponEnvReadback_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponEnvInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700481C RID: 18460
		// (get) Token: 0x06023BF4 RID: 146420 RVA: 0x0098AF72 File Offset: 0x00989172
		// (set) Token: 0x06023BF5 RID: 146421 RVA: 0x0098AF82 File Offset: 0x00989182
		public unsafe int RTSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponEnvInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponEnvInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06023BF6 RID: 146422 RVA: 0x0098AF94 File Offset: 0x00989194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool WeaponPointVaildation(FVectorDouble SceneInteractPos, BP_SceneBattleInteract_C SceneInteractDA)
		{
			BP_WeaponEnvInteraction_C.__WeaponPointVaildation_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__WeaponPointVaildation_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__WeaponPointVaildation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__WeaponPointVaildation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SceneInteractPos = SceneInteractPos;
			ptr->SceneInteractDA = ((SceneInteractDA != null) ? SceneInteractDA.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__WeaponPointVaildation_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06023BF7 RID: 146423 RVA: 0x0098AFFC File Offset: 0x009891FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcDistance2D(FVectorDouble V1, FVectorDouble V2, ref double Distance)
		{
			BP_WeaponEnvInteraction_C.__CalcDistance2D_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__CalcDistance2D_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__CalcDistance2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__CalcDistance2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V1 = V1;
			ptr->V2 = V2;
			ptr->Distance = Distance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__CalcDistance2D_NativeFunctionPtr, (void*)ptr);
			Distance = ptr->Distance;
		}

		// Token: 0x06023BF8 RID: 146424 RVA: 0x0098B05C File Offset: 0x0098925C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble MainPlayerPos, FVectorDouble OtherPlayerPos, float InteractionSize, ref FVector2D TexCoord)
		{
			BP_WeaponEnvInteraction_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__CalcTexCoord_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MainPlayerPos = MainPlayerPos;
			ptr->OtherPlayerPos = OtherPlayerPos;
			ptr->InteractionSize = InteractionSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x06023BF9 RID: 146425 RVA: 0x0098B0D0 File Offset: 0x009892D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ResizeRT(int Size)
		{
			BP_WeaponEnvInteraction_C.__ResizeRT_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__ResizeRT_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__ResizeRT_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__ResizeRT_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Size = Size;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ResizeRT_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023BFA RID: 146426 RVA: 0x0098B116 File Offset: 0x00989316
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ClearRT_NativeFunctionPtr, null);
		}

		// Token: 0x06023BFB RID: 146427 RVA: 0x0098B12A File Offset: 0x0098932A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_MID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__Create_MID_NativeFunctionPtr, null);
		}

		// Token: 0x06023BFC RID: 146428 RVA: 0x0098B13E File Offset: 0x0098933E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023BFD RID: 146429 RVA: 0x0098B152 File Offset: 0x00989352
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023BFE RID: 146430 RVA: 0x0098B168 File Offset: 0x00989368
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_WeaponEnvInteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023BFF RID: 146431 RVA: 0x0098B1CB File Offset: 0x009893CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023C00 RID: 146432 RVA: 0x0098B1DF File Offset: 0x009893DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023C01 RID: 146433 RVA: 0x0098B1F4 File Offset: 0x009893F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WeaponEnvInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023C02 RID: 146434 RVA: 0x0098B23C File Offset: 0x0098943C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WeaponEnvInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C03 RID: 146435 RVA: 0x0098B283 File Offset: 0x00989483
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRenderTarget()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ClearRenderTarget_NativeFunctionPtr, null);
		}

		// Token: 0x06023C04 RID: 146436 RVA: 0x0098B298 File Offset: 0x00989498
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnEnvInteractChanged(bool bEnableEnvInteract)
		{
			BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bEnableEnvInteract = bEnableEnvInteract;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023C05 RID: 146437 RVA: 0x0098B2E0 File Offset: 0x009894E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnEnvInteractChanged_Implementation(bool bEnableEnvInteract)
		{
			BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bEnableEnvInteract = bEnableEnvInteract;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__OnEnvInteractChanged_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C06 RID: 146438 RVA: 0x0098B328 File Offset: 0x00989528
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WeaponEnvInteraction(int EntryPoint)
		{
			BP_WeaponEnvInteraction_C.__ExecuteUbergraph_BP_WeaponEnvInteraction_FunctionParams* ptr = stackalloc BP_WeaponEnvInteraction_C.__ExecuteUbergraph_BP_WeaponEnvInteraction_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_WeaponEnvInteraction_C.__ExecuteUbergraph_BP_WeaponEnvInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvInteraction_C.__ExecuteUbergraph_BP_WeaponEnvInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvInteraction_C.__ExecuteUbergraph_BP_WeaponEnvInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C07 RID: 146439 RVA: 0x0098B372 File Offset: 0x00989572
		protected BP_WeaponEnvInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040123BB RID: 74683
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LongGrass/BP_WeaponEnvInteraction.BP_WeaponEnvInteraction_C";

		// Token: 0x040123BC RID: 74684
		private static IntPtr _ClassPtr;

		// Token: 0x040123BD RID: 74685
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040123BE RID: 74686
		internal static int __PropertyOffset_0;

		// Token: 0x040123BF RID: 74687
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040123C0 RID: 74688
		internal static int __PropertyOffset_1;

		// Token: 0x040123C1 RID: 74689
		internal static int __PropertyOffset_2;

		// Token: 0x040123C2 RID: 74690
		internal static int __PropertyOffset_3;

		// Token: 0x040123C3 RID: 74691
		internal static int __PropertyOffset_4;

		// Token: 0x040123C4 RID: 74692
		internal static int __PropertyOffset_5;

		// Token: 0x040123C5 RID: 74693
		private static IntPtr __WeaponPointVaildation_NativeFunctionPtr;

		// Token: 0x040123C6 RID: 74694
		private static IntPtr __CalcDistance2D_NativeFunctionPtr;

		// Token: 0x040123C7 RID: 74695
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x040123C8 RID: 74696
		private static IntPtr __ResizeRT_NativeFunctionPtr;

		// Token: 0x040123C9 RID: 74697
		private static IntPtr __ClearRT_NativeFunctionPtr;

		// Token: 0x040123CA RID: 74698
		private static IntPtr __Create_MID_NativeFunctionPtr;

		// Token: 0x040123CB RID: 74699
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040123CC RID: 74700
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040123CD RID: 74701
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040123CE RID: 74702
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040123CF RID: 74703
		private static IntPtr __ClearRenderTarget_NativeFunctionPtr;

		// Token: 0x040123D0 RID: 74704
		private static IntPtr __OnEnvInteractChanged_NativeFunctionPtr;

		// Token: 0x040123D1 RID: 74705
		private static IntPtr __ExecuteUbergraph_BP_WeaponEnvInteraction_NativeFunctionPtr;

		// Token: 0x02009D30 RID: 40240
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __WeaponPointVaildation_FunctionParams
		{
			// Token: 0x040326F9 RID: 206585
			[FieldOffset(0)]
			public FVectorDouble SceneInteractPos;

			// Token: 0x040326FA RID: 206586
			[FieldOffset(24)]
			public IntPtr SceneInteractDA;

			// Token: 0x040326FB RID: 206587
			[FieldOffset(32)]
			public bool __Result;
		}

		// Token: 0x02009D31 RID: 40241
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __CalcDistance2D_FunctionParams
		{
			// Token: 0x040326FC RID: 206588
			[FieldOffset(0)]
			public FVectorDouble V1;

			// Token: 0x040326FD RID: 206589
			[FieldOffset(24)]
			public FVectorDouble V2;

			// Token: 0x040326FE RID: 206590
			[FieldOffset(48)]
			public double Distance;
		}

		// Token: 0x02009D32 RID: 40242
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x040326FF RID: 206591
			[FieldOffset(0)]
			public FVectorDouble MainPlayerPos;

			// Token: 0x04032700 RID: 206592
			[FieldOffset(24)]
			public FVectorDouble OtherPlayerPos;

			// Token: 0x04032701 RID: 206593
			[FieldOffset(48)]
			public float InteractionSize;

			// Token: 0x04032702 RID: 206594
			[FieldOffset(52)]
			public FVector2D TexCoord;
		}

		// Token: 0x02009D33 RID: 40243
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ResizeRT_FunctionParams
		{
			// Token: 0x04032703 RID: 206595
			[FieldOffset(0)]
			public int Size;
		}

		// Token: 0x02009D34 RID: 40244
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032704 RID: 206596
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032705 RID: 206597
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032706 RID: 206598
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D35 RID: 40245
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032707 RID: 206599
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D36 RID: 40246
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __OnEnvInteractChanged_FunctionParams
		{
			// Token: 0x04032708 RID: 206600
			[FieldOffset(0)]
			public bool bEnableEnvInteract;
		}

		// Token: 0x02009D37 RID: 40247
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __ExecuteUbergraph_BP_WeaponEnvInteraction_FunctionParams
		{
			// Token: 0x04032709 RID: 206601
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
