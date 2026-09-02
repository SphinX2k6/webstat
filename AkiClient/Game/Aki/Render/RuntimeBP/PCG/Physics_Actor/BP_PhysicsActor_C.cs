using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor
{
	// Token: 0x02003BA6 RID: 15270
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor.BP_PhysicsActor_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_PhysicsActor_C : BP_PhysicsActor_Parent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021F6B RID: 139115 RVA: 0x009587C7 File Offset: 0x009569C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor.BP_PhysicsActor_C");
			}
			return BP_PhysicsActor_C._ClassPtr;
		}

		// Token: 0x06021F6C RID: 139116 RVA: 0x009587EC File Offset: 0x009569EC
		public BP_PhysicsActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021F6D RID: 139117 RVA: 0x00958814 File Offset: 0x00956A14
		public BP_PhysicsActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DF8 RID: 15864
		// (get) Token: 0x06021F6E RID: 139118 RVA: 0x00958848 File Offset: 0x00956A48
		// (set) Token: 0x06021F6F RID: 139119 RVA: 0x00958881 File Offset: 0x00956A81
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicsActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DF9 RID: 15865
		// (get) Token: 0x06021F70 RID: 139120 RVA: 0x009588A2 File Offset: 0x00956AA2
		// (set) Token: 0x06021F71 RID: 139121 RVA: 0x009588B6 File Offset: 0x00956AB6
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06021F72 RID: 139122 RVA: 0x009588CB File Offset: 0x00956ACB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F73 RID: 139123 RVA: 0x009588DF File Offset: 0x00956ADF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F74 RID: 139124 RVA: 0x009588F4 File Offset: 0x00956AF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F75 RID: 139125 RVA: 0x00958908 File Offset: 0x00956B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F76 RID: 139126 RVA: 0x00958920 File Offset: 0x00956B20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicsActor(int EntryPoint)
		{
			BP_PhysicsActor_C.__ExecuteUbergraph_BP_PhysicsActor_FunctionParams* ptr = stackalloc BP_PhysicsActor_C.__ExecuteUbergraph_BP_PhysicsActor_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicsActor_C.__ExecuteUbergraph_BP_PhysicsActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_C.__ExecuteUbergraph_BP_PhysicsActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_C.__ExecuteUbergraph_BP_PhysicsActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F77 RID: 139127 RVA: 0x00958967 File Offset: 0x00956B67
		protected BP_PhysicsActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011271 RID: 70257
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor.BP_PhysicsActor_C";

		// Token: 0x04011272 RID: 70258
		private static IntPtr _ClassPtr;

		// Token: 0x04011273 RID: 70259
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011274 RID: 70260
		internal new static int __PropertyOffset_0;

		// Token: 0x04011275 RID: 70261
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011276 RID: 70262
		internal static int __PropertyOffset_1;

		// Token: 0x04011277 RID: 70263
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04011278 RID: 70264
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04011279 RID: 70265
		private static IntPtr __ExecuteUbergraph_BP_PhysicsActor_NativeFunctionPtr;

		// Token: 0x02009B7D RID: 39805
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PhysicsActor_FunctionParams
		{
			// Token: 0x04032374 RID: 205684
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
