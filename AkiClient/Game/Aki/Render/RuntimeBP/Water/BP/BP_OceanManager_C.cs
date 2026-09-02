using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A0A RID: 14858
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_OceanManager.BP_OceanManager_C")]
	[UnrealStructLayout(1176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1176)]
	public class BP_OceanManager_C : AActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601E500 RID: 124160 RVA: 0x008F28BB File Offset: 0x008F0ABB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_OceanManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_OceanManager.BP_OceanManager_C");
			}
			return BP_OceanManager_C._ClassPtr;
		}

		// Token: 0x0601E501 RID: 124161 RVA: 0x008F28DF File Offset: 0x008F0ADF
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_OceanManager_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x0601E502 RID: 124162 RVA: 0x008F28E8 File Offset: 0x008F0AE8
		public BP_OceanManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_OceanManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E503 RID: 124163 RVA: 0x008F2910 File Offset: 0x008F0B10
		[NullableContext(1)]
		public BP_OceanManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_OceanManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002989 RID: 10633
		// (get) Token: 0x0601E504 RID: 124164 RVA: 0x008F2944 File Offset: 0x008F0B44
		// (set) Token: 0x0601E505 RID: 124165 RVA: 0x008F297D File Offset: 0x008F0B7D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700298A RID: 10634
		// (get) Token: 0x0601E506 RID: 124166 RVA: 0x008F299E File Offset: 0x008F0B9E
		// (set) Token: 0x0601E507 RID: 124167 RVA: 0x008F29B2 File Offset: 0x008F0BB2
		public unsafe UNiagaraComponent NS_OceanData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700298B RID: 10635
		// (get) Token: 0x0601E508 RID: 124168 RVA: 0x008F29C7 File Offset: 0x008F0BC7
		// (set) Token: 0x0601E509 RID: 124169 RVA: 0x008F29DB File Offset: 0x008F0BDB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700298C RID: 10636
		// (get) Token: 0x0601E50A RID: 124170 RVA: 0x008F29F0 File Offset: 0x008F0BF0
		// (set) Token: 0x0601E50B RID: 124171 RVA: 0x008F2A29 File Offset: 0x008F0C29
		[Nullable(1)]
		public TArray<FVector> A_ActorPosArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._A_ActorPosArray) == null)
				{
					result = (this._A_ActorPosArray = new TArray<FVector>(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.A_ActorPosArray.CopyAssign(value);
			}
		}

		// Token: 0x1700298D RID: 10637
		// (get) Token: 0x0601E50C RID: 124172 RVA: 0x008F2A37 File Offset: 0x008F0C37
		// (set) Token: 0x0601E50D RID: 124173 RVA: 0x008F2A47 File Offset: 0x008F0C47
		public unsafe float Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700298E RID: 10638
		// (get) Token: 0x0601E50E RID: 124174 RVA: 0x008F2A58 File Offset: 0x008F0C58
		// (set) Token: 0x0601E50F RID: 124175 RVA: 0x008F2A91 File Offset: 0x008F0C91
		[Nullable(1)]
		public TArray<AActor> A_ActorArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._A_ActorArray) == null)
				{
					result = (this._A_ActorArray = new TArray<AActor>(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.A_ActorArray.CopyAssign(value);
			}
		}

		// Token: 0x1700298F RID: 10639
		// (get) Token: 0x0601E510 RID: 124176 RVA: 0x008F2A9F File Offset: 0x008F0C9F
		// (set) Token: 0x0601E511 RID: 124177 RVA: 0x008F2AB3 File Offset: 0x008F0CB3
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002990 RID: 10640
		// (get) Token: 0x0601E512 RID: 124178 RVA: 0x008F2AC8 File Offset: 0x008F0CC8
		// (set) Token: 0x0601E513 RID: 124179 RVA: 0x008F2B01 File Offset: 0x008F0D01
		[Nullable(1)]
		public TArray<FVector4> sphereList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector4> result;
				if ((result = this._sphereList) == null)
				{
					result = (this._sphereList = new TArray<FVector4>(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.sphereList.CopyAssign(value);
			}
		}

		// Token: 0x17002991 RID: 10641
		// (get) Token: 0x0601E514 RID: 124180 RVA: 0x008F2B0F File Offset: 0x008F0D0F
		// (set) Token: 0x0601E515 RID: 124181 RVA: 0x008F2B1F File Offset: 0x008F0D1F
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002992 RID: 10642
		// (get) Token: 0x0601E516 RID: 124182 RVA: 0x008F2B30 File Offset: 0x008F0D30
		// (set) Token: 0x0601E517 RID: 124183 RVA: 0x008F2B40 File Offset: 0x008F0D40
		public unsafe float V_inWater
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002993 RID: 10643
		// (get) Token: 0x0601E518 RID: 124184 RVA: 0x008F2B51 File Offset: 0x008F0D51
		// (set) Token: 0x0601E519 RID: 124185 RVA: 0x008F2B61 File Offset: 0x008F0D61
		public unsafe float V_total
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002994 RID: 10644
		// (get) Token: 0x0601E51A RID: 124186 RVA: 0x008F2B74 File Offset: 0x008F0D74
		// (set) Token: 0x0601E51B RID: 124187 RVA: 0x008F2BAD File Offset: 0x008F0DAD
		[Nullable(1)]
		public TArray<float> waveHeightList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._waveHeightList) == null)
				{
					result = (this._waveHeightList = new TArray<float>(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.waveHeightList.CopyAssign(value);
			}
		}

		// Token: 0x17002995 RID: 10645
		// (get) Token: 0x0601E51C RID: 124188 RVA: 0x008F2BBB File Offset: 0x008F0DBB
		// (set) Token: 0x0601E51D RID: 124189 RVA: 0x008F2BCB File Offset: 0x008F0DCB
		public unsafe float timescale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OceanManager_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002996 RID: 10646
		// (get) Token: 0x0601E51E RID: 124190 RVA: 0x008F2BDC File Offset: 0x008F0DDC
		// (set) Token: 0x0601E51F RID: 124191 RVA: 0x008F2BF0 File Offset: 0x008F0DF0
		public unsafe UVolumeTexture OceanWaveVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVolumeTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002997 RID: 10647
		// (get) Token: 0x0601E520 RID: 124192 RVA: 0x008F2C05 File Offset: 0x008F0E05
		// (set) Token: 0x0601E521 RID: 124193 RVA: 0x008F2C19 File Offset: 0x008F0E19
		public unsafe UTexture NewVar_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanManager_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x0601E522 RID: 124194 RVA: 0x008F2C2E File Offset: 0x008F0E2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_OceanManager_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E523 RID: 124195 RVA: 0x008F2C42 File Offset: 0x008F0E42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_OceanManager_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E524 RID: 124196 RVA: 0x008F2C57 File Offset: 0x008F0E57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_OceanManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E525 RID: 124197 RVA: 0x008F2C6B File Offset: 0x008F0E6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_OceanManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E526 RID: 124198 RVA: 0x008F2C80 File Offset: 0x008F0E80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_OceanManager_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_OceanManager_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_OceanManager_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_OceanManager_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_OceanManager_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_OceanManager_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E527 RID: 124199 RVA: 0x008F2D10 File Offset: 0x008F0F10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_OceanManager_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_OceanManager_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_OceanManager_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_OceanManager_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_OceanManager_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_OceanManager_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E528 RID: 124200 RVA: 0x008F2DA0 File Offset: 0x008F0FA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_OceanManager(int EntryPoint)
		{
			BP_OceanManager_C.__ExecuteUbergraph_BP_OceanManager_FunctionParams* ptr = stackalloc BP_OceanManager_C.__ExecuteUbergraph_BP_OceanManager_FunctionParams[(UIntPtr)567] + 15L / (long)sizeof(BP_OceanManager_C.__ExecuteUbergraph_BP_OceanManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_OceanManager_C.__ExecuteUbergraph_BP_OceanManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_OceanManager_C.__ExecuteUbergraph_BP_OceanManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E529 RID: 124201 RVA: 0x008F2DEA File Offset: 0x008F0FEA
		protected BP_OceanManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE92 RID: 61074
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x0400EE93 RID: 61075
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_OceanManager.BP_OceanManager_C";

		// Token: 0x0400EE94 RID: 61076
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE95 RID: 61077
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE96 RID: 61078
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE97 RID: 61079
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EE98 RID: 61080
		internal static int __PropertyOffset_1;

		// Token: 0x0400EE99 RID: 61081
		internal static int __PropertyOffset_2;

		// Token: 0x0400EE9A RID: 61082
		internal static int __PropertyOffset_3;

		// Token: 0x0400EE9B RID: 61083
		private TArray<FVector> _A_ActorPosArray;

		// Token: 0x0400EE9C RID: 61084
		internal static int __PropertyOffset_4;

		// Token: 0x0400EE9D RID: 61085
		internal static int __PropertyOffset_5;

		// Token: 0x0400EE9E RID: 61086
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _A_ActorArray;

		// Token: 0x0400EE9F RID: 61087
		internal static int __PropertyOffset_6;

		// Token: 0x0400EEA0 RID: 61088
		internal static int __PropertyOffset_7;

		// Token: 0x0400EEA1 RID: 61089
		private TArray<FVector4> _sphereList;

		// Token: 0x0400EEA2 RID: 61090
		internal static int __PropertyOffset_8;

		// Token: 0x0400EEA3 RID: 61091
		internal static int __PropertyOffset_9;

		// Token: 0x0400EEA4 RID: 61092
		internal static int __PropertyOffset_10;

		// Token: 0x0400EEA5 RID: 61093
		internal static int __PropertyOffset_11;

		// Token: 0x0400EEA6 RID: 61094
		private TArray<float> _waveHeightList;

		// Token: 0x0400EEA7 RID: 61095
		internal static int __PropertyOffset_12;

		// Token: 0x0400EEA8 RID: 61096
		internal static int __PropertyOffset_13;

		// Token: 0x0400EEA9 RID: 61097
		internal static int __PropertyOffset_14;

		// Token: 0x0400EEAA RID: 61098
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EEAB RID: 61099
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EEAC RID: 61100
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x0400EEAD RID: 61101
		private static IntPtr __ExecuteUbergraph_BP_OceanManager_NativeFunctionPtr;

		// Token: 0x020097A4 RID: 38820
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x04031D6F RID: 204143
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04031D70 RID: 204144
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x020097A5 RID: 38821
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 552)]
		protected ref struct __ExecuteUbergraph_BP_OceanManager_FunctionParams
		{
			// Token: 0x04031D71 RID: 204145
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
