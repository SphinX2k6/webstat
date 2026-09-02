using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneDissolve
{
	// Token: 0x02003B30 RID: 15152
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneDissolve/BP_SceneDissolve.BP_SceneDissolve_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1364)]
	public class BP_SceneDissolve_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020ADB RID: 133851 RVA: 0x00933D28 File Offset: 0x00931F28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneDissolve_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneDissolve/BP_SceneDissolve.BP_SceneDissolve_C");
			}
			return BP_SceneDissolve_C._ClassPtr;
		}

		// Token: 0x06020ADC RID: 133852 RVA: 0x00933D4C File Offset: 0x00931F4C
		public BP_SceneDissolve_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneDissolve_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020ADD RID: 133853 RVA: 0x00933D74 File Offset: 0x00931F74
		[NullableContext(1)]
		public BP_SceneDissolve_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneDissolve_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036AD RID: 13997
		// (get) Token: 0x06020ADE RID: 133854 RVA: 0x00933DA8 File Offset: 0x00931FA8
		// (set) Token: 0x06020ADF RID: 133855 RVA: 0x00933DE1 File Offset: 0x00931FE1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036AE RID: 13998
		// (get) Token: 0x06020AE0 RID: 133856 RVA: 0x00933E02 File Offset: 0x00932002
		// (set) Token: 0x06020AE1 RID: 133857 RVA: 0x00933E16 File Offset: 0x00932016
		public unsafe UNiagaraComponent NS_Fx_SceneDissolve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036AF RID: 13999
		// (get) Token: 0x06020AE2 RID: 133858 RVA: 0x00933E2B File Offset: 0x0093202B
		// (set) Token: 0x06020AE3 RID: 133859 RVA: 0x00933E3F File Offset: 0x0093203F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036B0 RID: 14000
		// (get) Token: 0x06020AE4 RID: 133860 RVA: 0x00933E54 File Offset: 0x00932054
		// (set) Token: 0x06020AE5 RID: 133861 RVA: 0x00933E64 File Offset: 0x00932064
		public unsafe float DissolutionProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170036B1 RID: 14001
		// (get) Token: 0x06020AE6 RID: 133862 RVA: 0x00933E75 File Offset: 0x00932075
		// (set) Token: 0x06020AE7 RID: 133863 RVA: 0x00933E89 File Offset: 0x00932089
		public unsafe UMaterialParameterCollection MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170036B2 RID: 14002
		// (get) Token: 0x06020AE8 RID: 133864 RVA: 0x00933E9E File Offset: 0x0093209E
		// (set) Token: 0x06020AE9 RID: 133865 RVA: 0x00933EAE File Offset: 0x009320AE
		public unsafe float DissolutionHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170036B3 RID: 14003
		// (get) Token: 0x06020AEA RID: 133866 RVA: 0x00933EBF File Offset: 0x009320BF
		// (set) Token: 0x06020AEB RID: 133867 RVA: 0x00933ECF File Offset: 0x009320CF
		public unsafe float DissolutionRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170036B4 RID: 14004
		// (get) Token: 0x06020AEC RID: 133868 RVA: 0x00933EE0 File Offset: 0x009320E0
		// (set) Token: 0x06020AED RID: 133869 RVA: 0x00933EF4 File Offset: 0x009320F4
		public unsafe FVector DissolutionData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06020AEE RID: 133870 RVA: 0x00933F09 File Offset: 0x00932109
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06020AEF RID: 133871 RVA: 0x00933F1D File Offset: 0x0093211D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020AF0 RID: 133872 RVA: 0x00933F31 File Offset: 0x00932131
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020AF1 RID: 133873 RVA: 0x00933F46 File Offset: 0x00932146
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020AF2 RID: 133874 RVA: 0x00933F5A File Offset: 0x0093215A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020AF3 RID: 133875 RVA: 0x00933F70 File Offset: 0x00932170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneDissolve_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneDissolve_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneDissolve_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneDissolve_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020AF4 RID: 133876 RVA: 0x00933FB8 File Offset: 0x009321B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneDissolve_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneDissolve_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneDissolve_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneDissolve_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020AF5 RID: 133877 RVA: 0x00933FFF File Offset: 0x009321FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParamFromSeq()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_C.__SetParamFromSeq_NativeFunctionPtr, null);
		}

		// Token: 0x06020AF6 RID: 133878 RVA: 0x00934014 File Offset: 0x00932214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneDissolve(int EntryPoint)
		{
			BP_SceneDissolve_C.__ExecuteUbergraph_BP_SceneDissolve_FunctionParams* ptr = stackalloc BP_SceneDissolve_C.__ExecuteUbergraph_BP_SceneDissolve_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneDissolve_C.__ExecuteUbergraph_BP_SceneDissolve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneDissolve_C.__ExecuteUbergraph_BP_SceneDissolve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_C.__ExecuteUbergraph_BP_SceneDissolve_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020AF7 RID: 133879 RVA: 0x0093405B File Offset: 0x0093225B
		protected BP_SceneDissolve_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105E2 RID: 67042
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneDissolve/BP_SceneDissolve.BP_SceneDissolve_C";

		// Token: 0x040105E3 RID: 67043
		private static IntPtr _ClassPtr;

		// Token: 0x040105E4 RID: 67044
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105E5 RID: 67045
		internal static int __PropertyOffset_0;

		// Token: 0x040105E6 RID: 67046
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040105E7 RID: 67047
		internal static int __PropertyOffset_1;

		// Token: 0x040105E8 RID: 67048
		internal static int __PropertyOffset_2;

		// Token: 0x040105E9 RID: 67049
		internal static int __PropertyOffset_3;

		// Token: 0x040105EA RID: 67050
		internal static int __PropertyOffset_4;

		// Token: 0x040105EB RID: 67051
		internal static int __PropertyOffset_5;

		// Token: 0x040105EC RID: 67052
		internal static int __PropertyOffset_6;

		// Token: 0x040105ED RID: 67053
		internal static int __PropertyOffset_7;

		// Token: 0x040105EE RID: 67054
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x040105EF RID: 67055
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040105F0 RID: 67056
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040105F1 RID: 67057
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040105F2 RID: 67058
		private static IntPtr __SetParamFromSeq_NativeFunctionPtr;

		// Token: 0x040105F3 RID: 67059
		private static IntPtr __ExecuteUbergraph_BP_SceneDissolve_NativeFunctionPtr;

		// Token: 0x02009A12 RID: 39442
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032100 RID: 205056
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A13 RID: 39443
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_SceneDissolve_FunctionParams
		{
			// Token: 0x04032101 RID: 205057
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
