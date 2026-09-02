using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SandTrail
{
	// Token: 0x02003B92 RID: 15250
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_SandInteraction.BP_SandInteraction_C")]
	[UnrealStructLayout(2064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2064)]
	public class BP_SandInteraction_C : NinjaLive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021CDD RID: 138461 RVA: 0x00953E5F File Offset: 0x0095205F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SandInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_SandInteraction.BP_SandInteraction_C");
			}
			return BP_SandInteraction_C._ClassPtr;
		}

		// Token: 0x06021CDE RID: 138462 RVA: 0x00953E84 File Offset: 0x00952084
		public BP_SandInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_SandInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021CDF RID: 138463 RVA: 0x00953EAC File Offset: 0x009520AC
		public BP_SandInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SandInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D1F RID: 15647
		// (get) Token: 0x06021CE0 RID: 138464 RVA: 0x00953EE0 File Offset: 0x009520E0
		// (set) Token: 0x06021CE1 RID: 138465 RVA: 0x00953F19 File Offset: 0x00952119
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D20 RID: 15648
		// (get) Token: 0x06021CE2 RID: 138466 RVA: 0x00953F3A File Offset: 0x0095213A
		// (set) Token: 0x06021CE3 RID: 138467 RVA: 0x00953F4E File Offset: 0x0095214E
		[Nullable(2)]
		public unsafe UNiagaraComponent SandParticle1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandInteraction_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D21 RID: 15649
		// (get) Token: 0x06021CE4 RID: 138468 RVA: 0x00953F63 File Offset: 0x00952163
		// (set) Token: 0x06021CE5 RID: 138469 RVA: 0x00953F77 File Offset: 0x00952177
		[Nullable(2)]
		public unsafe UNiagaraComponent SandParticle
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandInteraction_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SandInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D22 RID: 15650
		// (get) Token: 0x06021CE6 RID: 138470 RVA: 0x00953F8C File Offset: 0x0095218C
		// (set) Token: 0x06021CE7 RID: 138471 RVA: 0x00953F9C File Offset: 0x0095219C
		public unsafe bool bMoto
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D23 RID: 15651
		// (get) Token: 0x06021CE8 RID: 138472 RVA: 0x00953FAD File Offset: 0x009521AD
		// (set) Token: 0x06021CE9 RID: 138473 RVA: 0x00953FBD File Offset: 0x009521BD
		public unsafe float OriginKuroTrailEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003D24 RID: 15652
		// (get) Token: 0x06021CEA RID: 138474 RVA: 0x00953FCE File Offset: 0x009521CE
		// (set) Token: 0x06021CEB RID: 138475 RVA: 0x00953FDE File Offset: 0x009521DE
		public unsafe float CharacterVeloMotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003D25 RID: 15653
		// (get) Token: 0x06021CEC RID: 138476 RVA: 0x00953FEF File Offset: 0x009521EF
		// (set) Token: 0x06021CED RID: 138477 RVA: 0x00953FFF File Offset: 0x009521FF
		public unsafe float CharacterGlobalBrush
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003D26 RID: 15654
		// (get) Token: 0x06021CEE RID: 138478 RVA: 0x00954010 File Offset: 0x00952210
		// (set) Token: 0x06021CEF RID: 138479 RVA: 0x00954020 File Offset: 0x00952220
		public unsafe bool CloseOriTrail
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D27 RID: 15655
		// (get) Token: 0x06021CF0 RID: 138480 RVA: 0x00954031 File Offset: 0x00952231
		// (set) Token: 0x06021CF1 RID: 138481 RVA: 0x00954041 File Offset: 0x00952241
		public unsafe bool bPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D28 RID: 15656
		// (get) Token: 0x06021CF2 RID: 138482 RVA: 0x00954054 File Offset: 0x00952254
		// (set) Token: 0x06021CF3 RID: 138483 RVA: 0x0095408D File Offset: 0x0095228D
		public TSet<string> physicMaterialsSet
		{
			get
			{
				base.FastCheckIsValid();
				TSet<string> result;
				if ((result = this._physicMaterialsSet) == null)
				{
					result = (this._physicMaterialsSet = new TSet<string>(base.NativePtr + (IntPtr)BP_SandInteraction_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.physicMaterialsSet.CopyAssign(value);
			}
		}

		// Token: 0x06021CF4 RID: 138484 RVA: 0x0095409C File Offset: 0x0095229C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckPhysicMat([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<string> Array)
		{
			BP_SandInteraction_C.__CheckPhysicMat_FunctionParams* ptr = stackalloc BP_SandInteraction_C.__CheckPhysicMat_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_SandInteraction_C.__CheckPhysicMat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandInteraction_C.__CheckPhysicMat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<string> tarray = Array;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Array);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SandInteraction_C.__CheckPhysicMat_NativeFunctionPtr, (void*)ptr);
			TArray<string> tarray2 = Array;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Array);
			}
			UnrealReflectionUtils.DestroyStruct(BP_SandInteraction_C.__CheckPhysicMat_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06021CF5 RID: 138485 RVA: 0x00954114 File Offset: 0x00952314
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SandInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SandInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SandInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SandInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021CF6 RID: 138486 RVA: 0x0095415C File Offset: 0x0095235C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SandInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SandInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SandInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SandInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CF7 RID: 138487 RVA: 0x009541A3 File Offset: 0x009523A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SandInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021CF8 RID: 138488 RVA: 0x009541B7 File Offset: 0x009523B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SandInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021CF9 RID: 138489 RVA: 0x009541CC File Offset: 0x009523CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SandInteraction_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SandInteraction_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SandInteraction_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SandInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021CFA RID: 138490 RVA: 0x00954218 File Offset: 0x00952418
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SandInteraction_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SandInteraction_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SandInteraction_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SandInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CFB RID: 138491 RVA: 0x00954264 File Offset: 0x00952464
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SandInteraction(int EntryPoint)
		{
			BP_SandInteraction_C.__ExecuteUbergraph_BP_SandInteraction_FunctionParams* ptr = stackalloc BP_SandInteraction_C.__ExecuteUbergraph_BP_SandInteraction_FunctionParams[(UIntPtr)1551] + 15L / (long)sizeof(BP_SandInteraction_C.__ExecuteUbergraph_BP_SandInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SandInteraction_C.__ExecuteUbergraph_BP_SandInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SandInteraction_C.__ExecuteUbergraph_BP_SandInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CFC RID: 138492 RVA: 0x009542AE File Offset: 0x009524AE
		protected BP_SandInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040110E9 RID: 69865
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_SandInteraction.BP_SandInteraction_C";

		// Token: 0x040110EA RID: 69866
		private static IntPtr _ClassPtr;

		// Token: 0x040110EB RID: 69867
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040110EC RID: 69868
		internal new static int __PropertyOffset_0;

		// Token: 0x040110ED RID: 69869
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040110EE RID: 69870
		internal new static int __PropertyOffset_1;

		// Token: 0x040110EF RID: 69871
		internal new static int __PropertyOffset_2;

		// Token: 0x040110F0 RID: 69872
		internal new static int __PropertyOffset_3;

		// Token: 0x040110F1 RID: 69873
		internal new static int __PropertyOffset_4;

		// Token: 0x040110F2 RID: 69874
		internal new static int __PropertyOffset_5;

		// Token: 0x040110F3 RID: 69875
		internal new static int __PropertyOffset_6;

		// Token: 0x040110F4 RID: 69876
		internal new static int __PropertyOffset_7;

		// Token: 0x040110F5 RID: 69877
		internal new static int __PropertyOffset_8;

		// Token: 0x040110F6 RID: 69878
		internal new static int __PropertyOffset_9;

		// Token: 0x040110F7 RID: 69879
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<string> _physicMaterialsSet;

		// Token: 0x040110F8 RID: 69880
		private static IntPtr __CheckPhysicMat_NativeFunctionPtr;

		// Token: 0x040110F9 RID: 69881
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040110FA RID: 69882
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040110FB RID: 69883
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040110FC RID: 69884
		private static IntPtr __ExecuteUbergraph_BP_SandInteraction_NativeFunctionPtr;

		// Token: 0x02009B4F RID: 39759
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __CheckPhysicMat_FunctionParams
		{
			// Token: 0x0403232E RID: 205614
			[FieldOffset(0)]
			public byte Array;
		}

		// Token: 0x02009B50 RID: 39760
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403232F RID: 205615
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B51 RID: 39761
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032330 RID: 205616
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009B52 RID: 39762
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1536)]
		protected ref struct __ExecuteUbergraph_BP_SandInteraction_FunctionParams
		{
			// Token: 0x04032331 RID: 205617
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
