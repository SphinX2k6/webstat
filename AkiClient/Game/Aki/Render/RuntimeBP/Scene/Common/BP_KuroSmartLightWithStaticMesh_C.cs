using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003ADC RID: 15068
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSmartLightWithStaticMesh.BP_KuroSmartLightWithStaticMesh_C")]
	[UnrealStructLayout(1272, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1272)]
	public class BP_KuroSmartLightWithStaticMesh_C : BP_KuroSmartLight_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020430 RID: 132144 RVA: 0x00926DD8 File Offset: 0x00924FD8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSmartLightWithStaticMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSmartLightWithStaticMesh.BP_KuroSmartLightWithStaticMesh_C");
			}
			return BP_KuroSmartLightWithStaticMesh_C._ClassPtr;
		}

		// Token: 0x06020431 RID: 132145 RVA: 0x00926DFC File Offset: 0x00924FFC
		public BP_KuroSmartLightWithStaticMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSmartLightWithStaticMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020432 RID: 132146 RVA: 0x00926E24 File Offset: 0x00925024
		[NullableContext(1)]
		public BP_KuroSmartLightWithStaticMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSmartLightWithStaticMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034B2 RID: 13490
		// (get) Token: 0x06020433 RID: 132147 RVA: 0x00926E58 File Offset: 0x00925058
		// (set) Token: 0x06020434 RID: 132148 RVA: 0x00926E91 File Offset: 0x00925091
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroSmartLightWithStaticMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroSmartLightWithStaticMesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034B3 RID: 13491
		// (get) Token: 0x06020435 RID: 132149 RVA: 0x00926EB2 File Offset: 0x009250B2
		// (set) Token: 0x06020436 RID: 132150 RVA: 0x00926EC6 File Offset: 0x009250C6
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLightWithStaticMesh_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLightWithStaticMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020437 RID: 132151 RVA: 0x00926EDC File Offset: 0x009250DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnUpdateLightOn(float Time)
		{
			BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_FunctionParams* ptr = stackalloc BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020438 RID: 132152 RVA: 0x00926F24 File Offset: 0x00925124
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void OnUpdateLightOn_Implementation(float Time)
		{
			BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_FunctionParams* ptr = stackalloc BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020439 RID: 132153 RVA: 0x00926F6C File Offset: 0x0092516C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnUpdateLightOff(float Time)
		{
			BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_FunctionParams* ptr = stackalloc BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602043A RID: 132154 RVA: 0x00926FB4 File Offset: 0x009251B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void OnUpdateLightOff_Implementation(float Time)
		{
			BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_FunctionParams* ptr = stackalloc BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLightWithStaticMesh_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602043B RID: 132155 RVA: 0x00926FFC File Offset: 0x009251FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh(int EntryPoint)
		{
			BP_KuroSmartLightWithStaticMesh_C.__ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_FunctionParams* ptr = stackalloc BP_KuroSmartLightWithStaticMesh_C.__ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_KuroSmartLightWithStaticMesh_C.__ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLightWithStaticMesh_C.__ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLightWithStaticMesh_C.__ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602043C RID: 132156 RVA: 0x00927043 File Offset: 0x00925243
		protected BP_KuroSmartLightWithStaticMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010184 RID: 65924
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSmartLightWithStaticMesh.BP_KuroSmartLightWithStaticMesh_C";

		// Token: 0x04010185 RID: 65925
		private static IntPtr _ClassPtr;

		// Token: 0x04010186 RID: 65926
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010187 RID: 65927
		internal new static int __PropertyOffset_0;

		// Token: 0x04010188 RID: 65928
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010189 RID: 65929
		internal new static int __PropertyOffset_1;

		// Token: 0x0401018A RID: 65930
		private static IntPtr __OnUpdateLightOn_NativeFunctionPtr;

		// Token: 0x0401018B RID: 65931
		private static IntPtr __OnUpdateLightOff_NativeFunctionPtr;

		// Token: 0x0401018C RID: 65932
		private static IntPtr __ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_NativeFunctionPtr;

		// Token: 0x02009982 RID: 39298
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnUpdateLightOn_FunctionParams
		{
			// Token: 0x04032008 RID: 204808
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009983 RID: 39299
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnUpdateLightOff_FunctionParams
		{
			// Token: 0x04032009 RID: 204809
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009984 RID: 39300
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_KuroSmartLightWithStaticMesh_FunctionParams
		{
			// Token: 0x0403200A RID: 204810
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
