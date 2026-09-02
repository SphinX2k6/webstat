using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneInteraction.FruitTree
{
	// Token: 0x02003B2D RID: 15149
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneInteraction/FruitTree/BP_FruitTreeInteractionCPU.BP_FruitTreeInteractionCPU_C")]
	[UnrealStructLayout(1616, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1613)]
	public class BP_FruitTreeInteractionCPU_C : AKuroFruitTreeInteractionActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020AA5 RID: 133797 RVA: 0x0093345B File Offset: 0x0093165B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FruitTreeInteractionCPU_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneInteraction/FruitTree/BP_FruitTreeInteractionCPU.BP_FruitTreeInteractionCPU_C");
			}
			return BP_FruitTreeInteractionCPU_C._ClassPtr;
		}

		// Token: 0x06020AA6 RID: 133798 RVA: 0x00933480 File Offset: 0x00931680
		public BP_FruitTreeInteractionCPU_C() : this(BuiltinUtils.AllocNativeUObject(BP_FruitTreeInteractionCPU_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020AA7 RID: 133799 RVA: 0x009334A8 File Offset: 0x009316A8
		[NullableContext(1)]
		public BP_FruitTreeInteractionCPU_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FruitTreeInteractionCPU_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036A1 RID: 13985
		// (get) Token: 0x06020AA8 RID: 133800 RVA: 0x009334DC File Offset: 0x009316DC
		// (set) Token: 0x06020AA9 RID: 133801 RVA: 0x00933515 File Offset: 0x00931715
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FruitTreeInteractionCPU_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FruitTreeInteractionCPU_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036A2 RID: 13986
		// (get) Token: 0x06020AAA RID: 133802 RVA: 0x00933536 File Offset: 0x00931736
		// (set) Token: 0x06020AAB RID: 133803 RVA: 0x0093354A File Offset: 0x0093174A
		public unsafe UStaticMeshComponent WholeMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteractionCPU_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteractionCPU_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036A3 RID: 13987
		// (get) Token: 0x06020AAC RID: 133804 RVA: 0x0093355F File Offset: 0x0093175F
		// (set) Token: 0x06020AAD RID: 133805 RVA: 0x00933573 File Offset: 0x00931773
		public unsafe UHoudiniPointCache HPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteractionCPU_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteractionCPU_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036A4 RID: 13988
		// (get) Token: 0x06020AAE RID: 133806 RVA: 0x00933588 File Offset: 0x00931788
		// (set) Token: 0x06020AAF RID: 133807 RVA: 0x00933598 File Offset: 0x00931798
		public unsafe float RadiusIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FruitTreeInteractionCPU_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FruitTreeInteractionCPU_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170036A5 RID: 13989
		// (get) Token: 0x06020AB0 RID: 133808 RVA: 0x009335A9 File Offset: 0x009317A9
		// (set) Token: 0x06020AB1 RID: 133809 RVA: 0x009335B9 File Offset: 0x009317B9
		public unsafe bool ReverseV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FruitTreeInteractionCPU_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FruitTreeInteractionCPU_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020AB2 RID: 133810 RVA: 0x009335CA File Offset: 0x009317CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020AB3 RID: 133811 RVA: 0x009335DE File Offset: 0x009317DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020AB4 RID: 133812 RVA: 0x009335F4 File Offset: 0x009317F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_FruitTreeInteractionCPU_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_FruitTreeInteractionCPU_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_FruitTreeInteractionCPU_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteractionCPU_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020AB5 RID: 133813 RVA: 0x00933658 File Offset: 0x00931858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FruitTreeInteractionCPU_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FruitTreeInteractionCPU_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FruitTreeInteractionCPU_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteractionCPU_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020AB6 RID: 133814 RVA: 0x009336A0 File Offset: 0x009318A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FruitTreeInteractionCPU_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FruitTreeInteractionCPU_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FruitTreeInteractionCPU_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteractionCPU_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020AB7 RID: 133815 RVA: 0x009336E7 File Offset: 0x009318E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020AB8 RID: 133816 RVA: 0x009336FB File Offset: 0x009318FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020AB9 RID: 133817 RVA: 0x00933710 File Offset: 0x00931910
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020ABA RID: 133818 RVA: 0x009337CC File Offset: 0x009319CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020ABB RID: 133819 RVA: 0x00933858 File Offset: 0x00931A58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FruitTreeInteractionCPU(int EntryPoint)
		{
			BP_FruitTreeInteractionCPU_C.__ExecuteUbergraph_BP_FruitTreeInteractionCPU_FunctionParams* ptr = stackalloc BP_FruitTreeInteractionCPU_C.__ExecuteUbergraph_BP_FruitTreeInteractionCPU_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BP_FruitTreeInteractionCPU_C.__ExecuteUbergraph_BP_FruitTreeInteractionCPU_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteractionCPU_C.__ExecuteUbergraph_BP_FruitTreeInteractionCPU_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteractionCPU_C.__ExecuteUbergraph_BP_FruitTreeInteractionCPU_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020ABC RID: 133820 RVA: 0x009338A2 File Offset: 0x00931AA2
		protected BP_FruitTreeInteractionCPU_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105BE RID: 67006
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneInteraction/FruitTree/BP_FruitTreeInteractionCPU.BP_FruitTreeInteractionCPU_C";

		// Token: 0x040105BF RID: 67007
		private static IntPtr _ClassPtr;

		// Token: 0x040105C0 RID: 67008
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105C1 RID: 67009
		internal static int __PropertyOffset_0;

		// Token: 0x040105C2 RID: 67010
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040105C3 RID: 67011
		internal static int __PropertyOffset_1;

		// Token: 0x040105C4 RID: 67012
		internal static int __PropertyOffset_2;

		// Token: 0x040105C5 RID: 67013
		internal static int __PropertyOffset_3;

		// Token: 0x040105C6 RID: 67014
		internal static int __PropertyOffset_4;

		// Token: 0x040105C7 RID: 67015
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040105C8 RID: 67016
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040105C9 RID: 67017
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040105CA RID: 67018
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040105CB RID: 67019
		private static IntPtr __BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040105CC RID: 67020
		private static IntPtr __BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040105CD RID: 67021
		private static IntPtr __ExecuteUbergraph_BP_FruitTreeInteractionCPU_NativeFunctionPtr;

		// Token: 0x02009A09 RID: 39433
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040320EC RID: 205036
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040320ED RID: 205037
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040320EE RID: 205038
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009A0A RID: 39434
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040320EF RID: 205039
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A0B RID: 39435
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040320F0 RID: 205040
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040320F1 RID: 205041
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040320F2 RID: 205042
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040320F3 RID: 205043
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040320F4 RID: 205044
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040320F5 RID: 205045
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A0C RID: 39436
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_FruitTreeInteractionCPU_KillBounds_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040320F6 RID: 205046
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040320F7 RID: 205047
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040320F8 RID: 205048
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040320F9 RID: 205049
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A0D RID: 39437
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __ExecuteUbergraph_BP_FruitTreeInteractionCPU_FunctionParams
		{
			// Token: 0x040320FA RID: 205050
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
