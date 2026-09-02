using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MosaicEffect
{
	// Token: 0x02003BBE RID: 15294
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MosaicEffect/BP_MosaicEffect.BP_MosaicEffect_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1345)]
	public class BP_MosaicEffect_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060224B0 RID: 140464 RVA: 0x00961383 File Offset: 0x0095F583
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MosaicEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MosaicEffect/BP_MosaicEffect.BP_MosaicEffect_C");
			}
			return BP_MosaicEffect_C._ClassPtr;
		}

		// Token: 0x060224B1 RID: 140465 RVA: 0x009613A8 File Offset: 0x0095F5A8
		public BP_MosaicEffect_C() : this(BuiltinUtils.AllocNativeUObject(BP_MosaicEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060224B2 RID: 140466 RVA: 0x009613D0 File Offset: 0x0095F5D0
		[NullableContext(1)]
		public BP_MosaicEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MosaicEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700401A RID: 16410
		// (get) Token: 0x060224B3 RID: 140467 RVA: 0x00961404 File Offset: 0x0095F604
		// (set) Token: 0x060224B4 RID: 140468 RVA: 0x0096143D File Offset: 0x0095F63D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MosaicEffect_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MosaicEffect_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700401B RID: 16411
		// (get) Token: 0x060224B5 RID: 140469 RVA: 0x0096145E File Offset: 0x0095F65E
		// (set) Token: 0x060224B6 RID: 140470 RVA: 0x00961472 File Offset: 0x0095F672
		public unsafe UNiagaraComponent NS_Fx_MosaicEffect
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700401C RID: 16412
		// (get) Token: 0x060224B7 RID: 140471 RVA: 0x00961487 File Offset: 0x0095F687
		// (set) Token: 0x060224B8 RID: 140472 RVA: 0x0096149B File Offset: 0x0095F69B
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700401D RID: 16413
		// (get) Token: 0x060224B9 RID: 140473 RVA: 0x009614B0 File Offset: 0x0095F6B0
		// (set) Token: 0x060224BA RID: 140474 RVA: 0x009614C4 File Offset: 0x0095F6C4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700401E RID: 16414
		// (get) Token: 0x060224BB RID: 140475 RVA: 0x009614D9 File Offset: 0x0095F6D9
		// (set) Token: 0x060224BC RID: 140476 RVA: 0x009614ED File Offset: 0x0095F6ED
		public unsafe PCG_RoadSpline_C RoadSpline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PCG_RoadSpline_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MosaicEffect_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700401F RID: 16415
		// (get) Token: 0x060224BD RID: 140477 RVA: 0x00961502 File Offset: 0x0095F702
		// (set) Token: 0x060224BE RID: 140478 RVA: 0x00961512 File Offset: 0x0095F712
		public unsafe bool bPlayerOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MosaicEffect_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MosaicEffect_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x060224BF RID: 140479 RVA: 0x00961523 File Offset: 0x0095F723
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MosaicEffect_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060224C0 RID: 140480 RVA: 0x00961537 File Offset: 0x0095F737
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MosaicEffect_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060224C1 RID: 140481 RVA: 0x0096154C File Offset: 0x0095F74C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MosaicEffect_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060224C2 RID: 140482 RVA: 0x00961560 File Offset: 0x0095F760
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MosaicEffect_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060224C3 RID: 140483 RVA: 0x00961578 File Offset: 0x0095F778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_MosaicEffect_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_MosaicEffect_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_MosaicEffect_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MosaicEffect_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MosaicEffect_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060224C4 RID: 140484 RVA: 0x009615D0 File Offset: 0x0095F7D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_MosaicEffect_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_MosaicEffect_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_MosaicEffect_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MosaicEffect_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MosaicEffect_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060224C5 RID: 140485 RVA: 0x00961628 File Offset: 0x0095F828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_MosaicEffect_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_MosaicEffect_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_MosaicEffect_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MosaicEffect_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MosaicEffect_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060224C6 RID: 140486 RVA: 0x00961680 File Offset: 0x0095F880
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_MosaicEffect_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_MosaicEffect_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_MosaicEffect_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MosaicEffect_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MosaicEffect_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060224C7 RID: 140487 RVA: 0x009616D8 File Offset: 0x0095F8D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MosaicEffect(int EntryPoint)
		{
			BP_MosaicEffect_C.__ExecuteUbergraph_BP_MosaicEffect_FunctionParams* ptr = stackalloc BP_MosaicEffect_C.__ExecuteUbergraph_BP_MosaicEffect_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_MosaicEffect_C.__ExecuteUbergraph_BP_MosaicEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MosaicEffect_C.__ExecuteUbergraph_BP_MosaicEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MosaicEffect_C.__ExecuteUbergraph_BP_MosaicEffect_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060224C8 RID: 140488 RVA: 0x0096171F File Offset: 0x0095F91F
		protected BP_MosaicEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401157C RID: 71036
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MosaicEffect/BP_MosaicEffect.BP_MosaicEffect_C";

		// Token: 0x0401157D RID: 71037
		private static IntPtr _ClassPtr;

		// Token: 0x0401157E RID: 71038
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401157F RID: 71039
		internal static int __PropertyOffset_0;

		// Token: 0x04011580 RID: 71040
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011581 RID: 71041
		internal static int __PropertyOffset_1;

		// Token: 0x04011582 RID: 71042
		internal static int __PropertyOffset_2;

		// Token: 0x04011583 RID: 71043
		internal static int __PropertyOffset_3;

		// Token: 0x04011584 RID: 71044
		internal static int __PropertyOffset_4;

		// Token: 0x04011585 RID: 71045
		internal static int __PropertyOffset_5;

		// Token: 0x04011586 RID: 71046
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011587 RID: 71047
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011588 RID: 71048
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04011589 RID: 71049
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x0401158A RID: 71050
		private static IntPtr __ExecuteUbergraph_BP_MosaicEffect_NativeFunctionPtr;

		// Token: 0x02009BBB RID: 39867
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x040323EE RID: 205806
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009BBC RID: 39868
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x040323EF RID: 205807
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009BBD RID: 39869
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_MosaicEffect_FunctionParams
		{
			// Token: 0x040323F0 RID: 205808
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
