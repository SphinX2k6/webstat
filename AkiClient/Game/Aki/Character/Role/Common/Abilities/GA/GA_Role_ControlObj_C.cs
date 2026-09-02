using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040A0 RID: 16544
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_ControlObj.GA_Role_ControlObj_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Role_ControlObj_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B103 RID: 176387 RVA: 0x00A6F2DC File Offset: 0x00A6D4DC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_ControlObj_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_ControlObj.GA_Role_ControlObj_C");
			}
			return GA_Role_ControlObj_C._ClassPtr;
		}

		// Token: 0x0602B104 RID: 176388 RVA: 0x00A6F300 File Offset: 0x00A6D500
		public GA_Role_ControlObj_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_ControlObj_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B105 RID: 176389 RVA: 0x00A6F328 File Offset: 0x00A6D528
		public GA_Role_ControlObj_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_ControlObj_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007092 RID: 28818
		// (get) Token: 0x0602B106 RID: 176390 RVA: 0x00A6F35C File Offset: 0x00A6D55C
		// (set) Token: 0x0602B107 RID: 176391 RVA: 0x00A6F395 File Offset: 0x00A6D595
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_ControlObj_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_ControlObj_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007093 RID: 28819
		// (get) Token: 0x0602B108 RID: 176392 RVA: 0x00A6F3B6 File Offset: 0x00A6D5B6
		// (set) Token: 0x0602B109 RID: 176393 RVA: 0x00A6F3CA File Offset: 0x00A6D5CA
		[Nullable(2)]
		public unsafe UPhysicsHandleComponent Physics_Handle
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsHandleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_ControlObj_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_ControlObj_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B10A RID: 176394 RVA: 0x00A6F3DF File Offset: 0x00A6D5DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_ControlObj_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B10B RID: 176395 RVA: 0x00A6F3F3 File Offset: 0x00A6D5F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_ControlObj_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B10C RID: 176396 RVA: 0x00A6F408 File Offset: 0x00A6D608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_ControlObj(int EntryPoint)
		{
			GA_Role_ControlObj_C.__ExecuteUbergraph_GA_Role_ControlObj_FunctionParams* ptr = stackalloc GA_Role_ControlObj_C.__ExecuteUbergraph_GA_Role_ControlObj_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Role_ControlObj_C.__ExecuteUbergraph_GA_Role_ControlObj_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_ControlObj_C.__ExecuteUbergraph_GA_Role_ControlObj_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_ControlObj_C.__ExecuteUbergraph_GA_Role_ControlObj_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B10D RID: 176397 RVA: 0x00A6F44F File Offset: 0x00A6D64F
		protected GA_Role_ControlObj_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178DA RID: 96474
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_ControlObj.GA_Role_ControlObj_C";

		// Token: 0x040178DB RID: 96475
		private static IntPtr _ClassPtr;

		// Token: 0x040178DC RID: 96476
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178DD RID: 96477
		internal new static int __PropertyOffset_0;

		// Token: 0x040178DE RID: 96478
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178DF RID: 96479
		internal new static int __PropertyOffset_1;

		// Token: 0x040178E0 RID: 96480
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178E1 RID: 96481
		private static IntPtr __ExecuteUbergraph_GA_Role_ControlObj_NativeFunctionPtr;

		// Token: 0x0200A2DE RID: 41694
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_GA_Role_ControlObj_FunctionParams
		{
			// Token: 0x0403309F RID: 209055
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
