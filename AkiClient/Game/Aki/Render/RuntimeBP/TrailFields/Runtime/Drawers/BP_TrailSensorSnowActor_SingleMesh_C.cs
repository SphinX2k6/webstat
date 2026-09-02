using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers
{
	// Token: 0x02003A37 RID: 14903
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailSensorSnowActor_SingleMesh.BP_TrailSensorSnowActor_SingleMesh_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1352)]
	public class BP_TrailSensorSnowActor_SingleMesh_C : BP_TrailSensor_Mesh_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB95 RID: 125845 RVA: 0x008FCC53 File Offset: 0x008FAE53
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailSensorSnowActor_SingleMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailSensorSnowActor_SingleMesh.BP_TrailSensorSnowActor_SingleMesh_C");
			}
			return BP_TrailSensorSnowActor_SingleMesh_C._ClassPtr;
		}

		// Token: 0x0601EB96 RID: 125846 RVA: 0x008FCC78 File Offset: 0x008FAE78
		public BP_TrailSensorSnowActor_SingleMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensorSnowActor_SingleMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB97 RID: 125847 RVA: 0x008FCCA0 File Offset: 0x008FAEA0
		[NullableContext(1)]
		public BP_TrailSensorSnowActor_SingleMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensorSnowActor_SingleMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C16 RID: 11286
		// (get) Token: 0x0601EB98 RID: 125848 RVA: 0x008FCCD4 File Offset: 0x008FAED4
		// (set) Token: 0x0601EB99 RID: 125849 RVA: 0x008FCD0D File Offset: 0x008FAF0D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailSensorSnowActor_SingleMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailSensorSnowActor_SingleMesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C17 RID: 11287
		// (get) Token: 0x0601EB9A RID: 125850 RVA: 0x008FCD2E File Offset: 0x008FAF2E
		// (set) Token: 0x0601EB9B RID: 125851 RVA: 0x008FCD42 File Offset: 0x008FAF42
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorSnowActor_SingleMesh_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorSnowActor_SingleMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0601EB9C RID: 125852 RVA: 0x008FCD58 File Offset: 0x008FAF58
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetScale(UStaticMeshComponent 组件, float 乘数)
		{
			BP_TrailSensorSnowActor_SingleMesh_C.__SetScale_FunctionParams* ptr = stackalloc BP_TrailSensorSnowActor_SingleMesh_C.__SetScale_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_TrailSensorSnowActor_SingleMesh_C.__SetScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorSnowActor_SingleMesh_C.__SetScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->组件 = ((组件 != null) ? 组件.NativePtr : IntPtr.Zero);
			ptr->乘数 = 乘数;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorSnowActor_SingleMesh_C.__SetScale_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EB9D RID: 125853 RVA: 0x008FCDB4 File Offset: 0x008FAFB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorSnowActor_SingleMesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB9E RID: 125854 RVA: 0x008FCDC8 File Offset: 0x008FAFC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorSnowActor_SingleMesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB9F RID: 125855 RVA: 0x008FCDDD File Offset: 0x008FAFDD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorSnowActor_SingleMesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBA0 RID: 125856 RVA: 0x008FCDF1 File Offset: 0x008FAFF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorSnowActor_SingleMesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EBA1 RID: 125857 RVA: 0x008FCE08 File Offset: 0x008FB008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh(int EntryPoint)
		{
			BP_TrailSensorSnowActor_SingleMesh_C.__ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_FunctionParams* ptr = stackalloc BP_TrailSensorSnowActor_SingleMesh_C.__ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSensorSnowActor_SingleMesh_C.__ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorSnowActor_SingleMesh_C.__ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorSnowActor_SingleMesh_C.__ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EBA2 RID: 125858 RVA: 0x008FCE4F File Offset: 0x008FB04F
		protected BP_TrailSensorSnowActor_SingleMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F29A RID: 62106
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailSensorSnowActor_SingleMesh.BP_TrailSensorSnowActor_SingleMesh_C";

		// Token: 0x0400F29B RID: 62107
		private static IntPtr _ClassPtr;

		// Token: 0x0400F29C RID: 62108
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F29D RID: 62109
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F29E RID: 62110
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F29F RID: 62111
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F2A0 RID: 62112
		private static IntPtr __SetScale_NativeFunctionPtr;

		// Token: 0x0400F2A1 RID: 62113
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F2A2 RID: 62114
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F2A3 RID: 62115
		private static IntPtr __ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_NativeFunctionPtr;

		// Token: 0x020097F4 RID: 38900
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __SetScale_FunctionParams
		{
			// Token: 0x04031DE8 RID: 204264
			[FieldOffset(0)]
			public IntPtr 组件;

			// Token: 0x04031DE9 RID: 204265
			[FieldOffset(8)]
			public float 乘数;
		}

		// Token: 0x020097F5 RID: 38901
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_TrailSensorSnowActor_SingleMesh_FunctionParams
		{
			// Token: 0x04031DEA RID: 204266
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
