using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SandTrail
{
	// Token: 0x02003B93 RID: 15251
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_SandParticleInteraction.BP_SandParticleInteraction_C")]
	[UnrealStructLayout(1336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1336)]
	public class BP_SandParticleInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021CFD RID: 138493 RVA: 0x009542B7 File Offset: 0x009524B7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SandParticleInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_SandParticleInteraction.BP_SandParticleInteraction_C");
			}
			return BP_SandParticleInteraction_C._ClassPtr;
		}

		// Token: 0x06021CFE RID: 138494 RVA: 0x009542DC File Offset: 0x009524DC
		public BP_SandParticleInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_SandParticleInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021CFF RID: 138495 RVA: 0x00954304 File Offset: 0x00952504
		[NullableContext(1)]
		public BP_SandParticleInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SandParticleInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D29 RID: 15657
		// (get) Token: 0x06021D00 RID: 138496 RVA: 0x00954338 File Offset: 0x00952538
		// (set) Token: 0x06021D01 RID: 138497 RVA: 0x00954371 File Offset: 0x00952571
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SandParticleInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SandParticleInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D2A RID: 15658
		// (get) Token: 0x06021D02 RID: 138498 RVA: 0x00954392 File Offset: 0x00952592
		// (set) Token: 0x06021D03 RID: 138499 RVA: 0x009543A6 File Offset: 0x009525A6
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandParticleInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandParticleInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D2B RID: 15659
		// (get) Token: 0x06021D04 RID: 138500 RVA: 0x009543BB File Offset: 0x009525BB
		// (set) Token: 0x06021D05 RID: 138501 RVA: 0x009543CF File Offset: 0x009525CF
		public unsafe UNiagaraComponent NS_InputForFluidSimu
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandParticleInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandParticleInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D2C RID: 15660
		// (get) Token: 0x06021D06 RID: 138502 RVA: 0x009543E4 File Offset: 0x009525E4
		// (set) Token: 0x06021D07 RID: 138503 RVA: 0x009543F8 File Offset: 0x009525F8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandParticleInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandParticleInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06021D08 RID: 138504 RVA: 0x00954410 File Offset: 0x00952610
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SandParticleInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SandParticleInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SandParticleInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandParticleInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SandParticleInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D09 RID: 138505 RVA: 0x00954458 File Offset: 0x00952658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SandParticleInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SandParticleInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SandParticleInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandParticleInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SandParticleInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D0A RID: 138506 RVA: 0x009544A0 File Offset: 0x009526A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SandParticleInteraction(int EntryPoint)
		{
			BP_SandParticleInteraction_C.__ExecuteUbergraph_BP_SandParticleInteraction_FunctionParams* ptr = stackalloc BP_SandParticleInteraction_C.__ExecuteUbergraph_BP_SandParticleInteraction_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_SandParticleInteraction_C.__ExecuteUbergraph_BP_SandParticleInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandParticleInteraction_C.__ExecuteUbergraph_BP_SandParticleInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SandParticleInteraction_C.__ExecuteUbergraph_BP_SandParticleInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D0B RID: 138507 RVA: 0x009544E7 File Offset: 0x009526E7
		protected BP_SandParticleInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040110FD RID: 69885
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_SandParticleInteraction.BP_SandParticleInteraction_C";

		// Token: 0x040110FE RID: 69886
		private static IntPtr _ClassPtr;

		// Token: 0x040110FF RID: 69887
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011100 RID: 69888
		internal static int __PropertyOffset_0;

		// Token: 0x04011101 RID: 69889
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011102 RID: 69890
		internal static int __PropertyOffset_1;

		// Token: 0x04011103 RID: 69891
		internal static int __PropertyOffset_2;

		// Token: 0x04011104 RID: 69892
		internal static int __PropertyOffset_3;

		// Token: 0x04011105 RID: 69893
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011106 RID: 69894
		private static IntPtr __ExecuteUbergraph_BP_SandParticleInteraction_NativeFunctionPtr;

		// Token: 0x02009B53 RID: 39763
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032332 RID: 205618
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B54 RID: 39764
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_SandParticleInteraction_FunctionParams
		{
			// Token: 0x04032333 RID: 205619
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
