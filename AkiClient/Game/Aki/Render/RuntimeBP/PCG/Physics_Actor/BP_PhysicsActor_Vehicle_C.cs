using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor
{
	// Token: 0x02003BAA RID: 15274
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Vehicle.BP_PhysicsActor_Vehicle_C")]
	[UnrealStructLayout(1320, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1320)]
	public class BP_PhysicsActor_Vehicle_C : AKuroPhysicActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021FA3 RID: 139171 RVA: 0x00958EA0 File Offset: 0x009570A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsActor_Vehicle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Vehicle.BP_PhysicsActor_Vehicle_C");
			}
			return BP_PhysicsActor_Vehicle_C._ClassPtr;
		}

		// Token: 0x06021FA4 RID: 139172 RVA: 0x00958EC4 File Offset: 0x009570C4
		public BP_PhysicsActor_Vehicle_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_Vehicle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021FA5 RID: 139173 RVA: 0x00958EEC File Offset: 0x009570EC
		public BP_PhysicsActor_Vehicle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_Vehicle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003E03 RID: 15875
		// (get) Token: 0x06021FA6 RID: 139174 RVA: 0x00958F20 File Offset: 0x00957120
		// (set) Token: 0x06021FA7 RID: 139175 RVA: 0x00958F59 File Offset: 0x00957159
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicsActor_Vehicle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_Vehicle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003E04 RID: 15876
		// (get) Token: 0x06021FA8 RID: 139176 RVA: 0x00958F7A File Offset: 0x0095717A
		// (set) Token: 0x06021FA9 RID: 139177 RVA: 0x00958F8E File Offset: 0x0095718E
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Vehicle_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Vehicle_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06021FAA RID: 139178 RVA: 0x00958FA3 File Offset: 0x009571A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_Vehicle_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021FAB RID: 139179 RVA: 0x00958FB7 File Offset: 0x009571B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Vehicle_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FAC RID: 139180 RVA: 0x00958FCC File Offset: 0x009571CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_Vehicle_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021FAD RID: 139181 RVA: 0x00958FE0 File Offset: 0x009571E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Vehicle_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FAE RID: 139182 RVA: 0x00958FF8 File Offset: 0x009571F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicsActor_Vehicle(int EntryPoint)
		{
			BP_PhysicsActor_Vehicle_C.__ExecuteUbergraph_BP_PhysicsActor_Vehicle_FunctionParams* ptr = stackalloc BP_PhysicsActor_Vehicle_C.__ExecuteUbergraph_BP_PhysicsActor_Vehicle_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicsActor_Vehicle_C.__ExecuteUbergraph_BP_PhysicsActor_Vehicle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_Vehicle_C.__ExecuteUbergraph_BP_PhysicsActor_Vehicle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Vehicle_C.__ExecuteUbergraph_BP_PhysicsActor_Vehicle_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021FAF RID: 139183 RVA: 0x0095903F File Offset: 0x0095723F
		protected BP_PhysicsActor_Vehicle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011296 RID: 70294
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Vehicle.BP_PhysicsActor_Vehicle_C";

		// Token: 0x04011297 RID: 70295
		private static IntPtr _ClassPtr;

		// Token: 0x04011298 RID: 70296
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011299 RID: 70297
		internal static int __PropertyOffset_0;

		// Token: 0x0401129A RID: 70298
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401129B RID: 70299
		internal static int __PropertyOffset_1;

		// Token: 0x0401129C RID: 70300
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0401129D RID: 70301
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0401129E RID: 70302
		private static IntPtr __ExecuteUbergraph_BP_PhysicsActor_Vehicle_NativeFunctionPtr;

		// Token: 0x02009B81 RID: 39809
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PhysicsActor_Vehicle_FunctionParams
		{
			// Token: 0x0403237A RID: 205690
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
