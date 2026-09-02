using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor
{
	// Token: 0x02003BA9 RID: 15273
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_PC_Mobile.BP_PhysicsActor_PC_Mobile_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_PhysicsActor_PC_Mobile_C : BP_PhysicsActor_Parent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021F96 RID: 139158 RVA: 0x00958CF5 File Offset: 0x00956EF5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsActor_PC_Mobile_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_PC_Mobile.BP_PhysicsActor_PC_Mobile_C");
			}
			return BP_PhysicsActor_PC_Mobile_C._ClassPtr;
		}

		// Token: 0x06021F97 RID: 139159 RVA: 0x00958D1C File Offset: 0x00956F1C
		public BP_PhysicsActor_PC_Mobile_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_PC_Mobile_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021F98 RID: 139160 RVA: 0x00958D44 File Offset: 0x00956F44
		public BP_PhysicsActor_PC_Mobile_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_PC_Mobile_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003E01 RID: 15873
		// (get) Token: 0x06021F99 RID: 139161 RVA: 0x00958D78 File Offset: 0x00956F78
		// (set) Token: 0x06021F9A RID: 139162 RVA: 0x00958DB1 File Offset: 0x00956FB1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicsActor_PC_Mobile_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_PC_Mobile_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003E02 RID: 15874
		// (get) Token: 0x06021F9B RID: 139163 RVA: 0x00958DD2 File Offset: 0x00956FD2
		// (set) Token: 0x06021F9C RID: 139164 RVA: 0x00958DE6 File Offset: 0x00956FE6
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_PC_Mobile_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_PC_Mobile_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06021F9D RID: 139165 RVA: 0x00958DFB File Offset: 0x00956FFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_PC_Mobile_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F9E RID: 139166 RVA: 0x00958E0F File Offset: 0x0095700F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_PC_Mobile_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F9F RID: 139167 RVA: 0x00958E24 File Offset: 0x00957024
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_PC_Mobile_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021FA0 RID: 139168 RVA: 0x00958E38 File Offset: 0x00957038
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_PC_Mobile_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FA1 RID: 139169 RVA: 0x00958E50 File Offset: 0x00957050
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicsActor_PC_Mobile(int EntryPoint)
		{
			BP_PhysicsActor_PC_Mobile_C.__ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_FunctionParams* ptr = stackalloc BP_PhysicsActor_PC_Mobile_C.__ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicsActor_PC_Mobile_C.__ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_PC_Mobile_C.__ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_PC_Mobile_C.__ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021FA2 RID: 139170 RVA: 0x00958E97 File Offset: 0x00957097
		protected BP_PhysicsActor_PC_Mobile_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401128D RID: 70285
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_PC_Mobile.BP_PhysicsActor_PC_Mobile_C";

		// Token: 0x0401128E RID: 70286
		private static IntPtr _ClassPtr;

		// Token: 0x0401128F RID: 70287
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011290 RID: 70288
		internal new static int __PropertyOffset_0;

		// Token: 0x04011291 RID: 70289
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011292 RID: 70290
		internal static int __PropertyOffset_1;

		// Token: 0x04011293 RID: 70291
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04011294 RID: 70292
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04011295 RID: 70293
		private static IntPtr __ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_NativeFunctionPtr;

		// Token: 0x02009B80 RID: 39808
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PhysicsActor_PC_Mobile_FunctionParams
		{
			// Token: 0x04032379 RID: 205689
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
