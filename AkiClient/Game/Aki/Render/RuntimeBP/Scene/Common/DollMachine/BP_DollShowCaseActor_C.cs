using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B0E RID: 15118
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollShowCaseActor.BP_DollShowCaseActor_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1480)]
	public class BP_DollShowCaseActor_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060207E6 RID: 133094 RVA: 0x0092D99D File Offset: 0x0092BB9D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollShowCaseActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollShowCaseActor.BP_DollShowCaseActor_C");
			}
			return BP_DollShowCaseActor_C._ClassPtr;
		}

		// Token: 0x060207E7 RID: 133095 RVA: 0x0092D9C4 File Offset: 0x0092BBC4
		public BP_DollShowCaseActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollShowCaseActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060207E8 RID: 133096 RVA: 0x0092D9EC File Offset: 0x0092BBEC
		[NullableContext(1)]
		public BP_DollShowCaseActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollShowCaseActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035DC RID: 13788
		// (get) Token: 0x060207E9 RID: 133097 RVA: 0x0092DA20 File Offset: 0x0092BC20
		// (set) Token: 0x060207EA RID: 133098 RVA: 0x0092DA59 File Offset: 0x0092BC59
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035DD RID: 13789
		// (get) Token: 0x060207EB RID: 133099 RVA: 0x0092DA7A File Offset: 0x0092BC7A
		// (set) Token: 0x060207EC RID: 133100 RVA: 0x0092DA8E File Offset: 0x0092BC8E
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035DE RID: 13790
		// (get) Token: 0x060207ED RID: 133101 RVA: 0x0092DAA3 File Offset: 0x0092BCA3
		// (set) Token: 0x060207EE RID: 133102 RVA: 0x0092DAB7 File Offset: 0x0092BCB7
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170035DF RID: 13791
		// (get) Token: 0x060207EF RID: 133103 RVA: 0x0092DACC File Offset: 0x0092BCCC
		// (set) Token: 0x060207F0 RID: 133104 RVA: 0x0092DAE0 File Offset: 0x0092BCE0
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170035E0 RID: 13792
		// (get) Token: 0x060207F1 RID: 133105 RVA: 0x0092DAF5 File Offset: 0x0092BCF5
		// (set) Token: 0x060207F2 RID: 133106 RVA: 0x0092DB05 File Offset: 0x0092BD05
		public unsafe int DollElementId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170035E1 RID: 13793
		// (get) Token: 0x060207F3 RID: 133107 RVA: 0x0092DB18 File Offset: 0x0092BD18
		// (set) Token: 0x060207F4 RID: 133108 RVA: 0x0092DB51 File Offset: 0x0092BD51
		[Nullable(1)]
		public TMap<int, USkeletalMeshComponent> SkeletalMeshMap
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<int, USkeletalMeshComponent> result;
				if ((result = this._SkeletalMeshMap) == null)
				{
					result = (this._SkeletalMeshMap = new TMap<int, USkeletalMeshComponent>(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkeletalMeshMap.CopyAssign(value);
			}
		}

		// Token: 0x170035E2 RID: 13794
		// (get) Token: 0x060207F5 RID: 133109 RVA: 0x0092DB5F File Offset: 0x0092BD5F
		// (set) Token: 0x060207F6 RID: 133110 RVA: 0x0092DB73 File Offset: 0x0092BD73
		public unsafe BP_DollGrabLight_C BP_Light
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_DollGrabLight_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollShowCaseActor_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170035E3 RID: 13795
		// (get) Token: 0x060207F7 RID: 133111 RVA: 0x0092DB88 File Offset: 0x0092BD88
		// (set) Token: 0x060207F8 RID: 133112 RVA: 0x0092DB98 File Offset: 0x0092BD98
		public unsafe float PlayEffectIntervalTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170035E4 RID: 13796
		// (get) Token: 0x060207F9 RID: 133113 RVA: 0x0092DBA9 File Offset: 0x0092BDA9
		// (set) Token: 0x060207FA RID: 133114 RVA: 0x0092DBB9 File Offset: 0x0092BDB9
		public unsafe float CompleteEffectDurationTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170035E5 RID: 13797
		// (get) Token: 0x060207FB RID: 133115 RVA: 0x0092DBCA File Offset: 0x0092BDCA
		// (set) Token: 0x060207FC RID: 133116 RVA: 0x0092DBDA File Offset: 0x0092BDDA
		public unsafe float SetMaterialDelayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170035E6 RID: 13798
		// (get) Token: 0x060207FD RID: 133117 RVA: 0x0092DBEC File Offset: 0x0092BDEC
		// (set) Token: 0x060207FE RID: 133118 RVA: 0x0092DC25 File Offset: 0x0092BE25
		[Nullable(1)]
		public TArray<FVectorDouble> EffectOffsetLocationList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._EffectOffsetLocationList) == null)
				{
					result = (this._EffectOffsetLocationList = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.EffectOffsetLocationList.CopyAssign(value);
			}
		}

		// Token: 0x170035E7 RID: 13799
		// (get) Token: 0x060207FF RID: 133119 RVA: 0x0092DC34 File Offset: 0x0092BE34
		// (set) Token: 0x06020800 RID: 133120 RVA: 0x0092DC6D File Offset: 0x0092BE6D
		[Nullable(1)]
		public TArray<FVector> PartDollScaleList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._PartDollScaleList) == null)
				{
					result = (this._PartDollScaleList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_DollShowCaseActor_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.PartDollScaleList.CopyAssign(value);
			}
		}

		// Token: 0x06020801 RID: 133121 RVA: 0x0092DC7C File Offset: 0x0092BE7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SwitchLightState(int ActiveItemIdLength, bool IsComplete)
		{
			BP_DollShowCaseActor_C.__SwitchLightState_FunctionParams* ptr = stackalloc BP_DollShowCaseActor_C.__SwitchLightState_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_DollShowCaseActor_C.__SwitchLightState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollShowCaseActor_C.__SwitchLightState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ActiveItemIdLength = ActiveItemIdLength;
			ptr->IsComplete = IsComplete;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollShowCaseActor_C.__SwitchLightState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020802 RID: 133122 RVA: 0x0092DCC9 File Offset: 0x0092BEC9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollShowCaseActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020803 RID: 133123 RVA: 0x0092DCDD File Offset: 0x0092BEDD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollShowCaseActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020804 RID: 133124 RVA: 0x0092DCF4 File Offset: 0x0092BEF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollShowCaseActor(int EntryPoint)
		{
			BP_DollShowCaseActor_C.__ExecuteUbergraph_BP_DollShowCaseActor_FunctionParams* ptr = stackalloc BP_DollShowCaseActor_C.__ExecuteUbergraph_BP_DollShowCaseActor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DollShowCaseActor_C.__ExecuteUbergraph_BP_DollShowCaseActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollShowCaseActor_C.__ExecuteUbergraph_BP_DollShowCaseActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollShowCaseActor_C.__ExecuteUbergraph_BP_DollShowCaseActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020805 RID: 133125 RVA: 0x0092DD3B File Offset: 0x0092BF3B
		protected BP_DollShowCaseActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103E9 RID: 66537
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollShowCaseActor.BP_DollShowCaseActor_C";

		// Token: 0x040103EA RID: 66538
		private static IntPtr _ClassPtr;

		// Token: 0x040103EB RID: 66539
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103EC RID: 66540
		internal static int __PropertyOffset_0;

		// Token: 0x040103ED RID: 66541
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040103EE RID: 66542
		internal static int __PropertyOffset_1;

		// Token: 0x040103EF RID: 66543
		internal static int __PropertyOffset_2;

		// Token: 0x040103F0 RID: 66544
		internal static int __PropertyOffset_3;

		// Token: 0x040103F1 RID: 66545
		internal static int __PropertyOffset_4;

		// Token: 0x040103F2 RID: 66546
		internal static int __PropertyOffset_5;

		// Token: 0x040103F3 RID: 66547
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, USkeletalMeshComponent> _SkeletalMeshMap;

		// Token: 0x040103F4 RID: 66548
		internal static int __PropertyOffset_6;

		// Token: 0x040103F5 RID: 66549
		internal static int __PropertyOffset_7;

		// Token: 0x040103F6 RID: 66550
		internal static int __PropertyOffset_8;

		// Token: 0x040103F7 RID: 66551
		internal static int __PropertyOffset_9;

		// Token: 0x040103F8 RID: 66552
		internal static int __PropertyOffset_10;

		// Token: 0x040103F9 RID: 66553
		private TArray<FVectorDouble> _EffectOffsetLocationList;

		// Token: 0x040103FA RID: 66554
		internal static int __PropertyOffset_11;

		// Token: 0x040103FB RID: 66555
		private TArray<FVector> _PartDollScaleList;

		// Token: 0x040103FC RID: 66556
		private static IntPtr __SwitchLightState_NativeFunctionPtr;

		// Token: 0x040103FD RID: 66557
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040103FE RID: 66558
		private static IntPtr __ExecuteUbergraph_BP_DollShowCaseActor_NativeFunctionPtr;

		// Token: 0x020099C1 RID: 39361
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __SwitchLightState_FunctionParams
		{
			// Token: 0x04032063 RID: 204899
			[FieldOffset(0)]
			public int ActiveItemIdLength;

			// Token: 0x04032064 RID: 204900
			[FieldOffset(4)]
			public bool IsComplete;
		}

		// Token: 0x020099C2 RID: 39362
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_DollShowCaseActor_FunctionParams
		{
			// Token: 0x04032065 RID: 204901
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
