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
	// Token: 0x020040A1 RID: 16545
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_DestroyObj.GA_Role_DestroyObj_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_DestroyObj_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B10E RID: 176398 RVA: 0x00A6F458 File Offset: 0x00A6D658
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_DestroyObj_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_DestroyObj.GA_Role_DestroyObj_C");
			}
			return GA_Role_DestroyObj_C._ClassPtr;
		}

		// Token: 0x0602B10F RID: 176399 RVA: 0x00A6F47C File Offset: 0x00A6D67C
		public GA_Role_DestroyObj_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_DestroyObj_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B110 RID: 176400 RVA: 0x00A6F4A4 File Offset: 0x00A6D6A4
		public GA_Role_DestroyObj_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_DestroyObj_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007094 RID: 28820
		// (get) Token: 0x0602B111 RID: 176401 RVA: 0x00A6F4D8 File Offset: 0x00A6D6D8
		// (set) Token: 0x0602B112 RID: 176402 RVA: 0x00A6F511 File Offset: 0x00A6D711
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_DestroyObj_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_DestroyObj_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B113 RID: 176403 RVA: 0x00A6F532 File Offset: 0x00A6D732
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_DestroyObj_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B114 RID: 176404 RVA: 0x00A6F546 File Offset: 0x00A6D746
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_DestroyObj_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B115 RID: 176405 RVA: 0x00A6F55C File Offset: 0x00A6D75C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_DestroyObj(int EntryPoint)
		{
			GA_Role_DestroyObj_C.__ExecuteUbergraph_GA_Role_DestroyObj_FunctionParams* ptr = stackalloc GA_Role_DestroyObj_C.__ExecuteUbergraph_GA_Role_DestroyObj_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Role_DestroyObj_C.__ExecuteUbergraph_GA_Role_DestroyObj_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_DestroyObj_C.__ExecuteUbergraph_GA_Role_DestroyObj_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_DestroyObj_C.__ExecuteUbergraph_GA_Role_DestroyObj_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B116 RID: 176406 RVA: 0x00A6F5A3 File Offset: 0x00A6D7A3
		protected GA_Role_DestroyObj_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178E2 RID: 96482
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_DestroyObj.GA_Role_DestroyObj_C";

		// Token: 0x040178E3 RID: 96483
		private static IntPtr _ClassPtr;

		// Token: 0x040178E4 RID: 96484
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178E5 RID: 96485
		internal new static int __PropertyOffset_0;

		// Token: 0x040178E6 RID: 96486
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178E7 RID: 96487
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178E8 RID: 96488
		private static IntPtr __ExecuteUbergraph_GA_Role_DestroyObj_NativeFunctionPtr;

		// Token: 0x0200A2DF RID: 41695
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_GA_Role_DestroyObj_FunctionParams
		{
			// Token: 0x040330A0 RID: 209056
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
