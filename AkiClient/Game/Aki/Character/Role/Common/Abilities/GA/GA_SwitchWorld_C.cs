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
	// Token: 0x020040CE RID: 16590
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_SwitchWorld.GA_SwitchWorld_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_SwitchWorld_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B63B RID: 177723 RVA: 0x00A7A6F8 File Offset: 0x00A788F8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_SwitchWorld_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SwitchWorld.GA_SwitchWorld_C");
			}
			return GA_SwitchWorld_C._ClassPtr;
		}

		// Token: 0x0602B63C RID: 177724 RVA: 0x00A7A71C File Offset: 0x00A7891C
		public GA_SwitchWorld_C() : this(BuiltinUtils.AllocNativeUObject(GA_SwitchWorld_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B63D RID: 177725 RVA: 0x00A7A744 File Offset: 0x00A78944
		public GA_SwitchWorld_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_SwitchWorld_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071A6 RID: 29094
		// (get) Token: 0x0602B63E RID: 177726 RVA: 0x00A7A778 File Offset: 0x00A78978
		// (set) Token: 0x0602B63F RID: 177727 RVA: 0x00A7A7B1 File Offset: 0x00A789B1
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_SwitchWorld_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_SwitchWorld_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B640 RID: 177728 RVA: 0x00A7A7D2 File Offset: 0x00A789D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SwitchWorld_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B641 RID: 177729 RVA: 0x00A7A7E6 File Offset: 0x00A789E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SwitchWorld_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B642 RID: 177730 RVA: 0x00A7A7FC File Offset: 0x00A789FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_SwitchWorld(int EntryPoint)
		{
			GA_SwitchWorld_C.__ExecuteUbergraph_GA_SwitchWorld_FunctionParams* ptr = stackalloc GA_SwitchWorld_C.__ExecuteUbergraph_GA_SwitchWorld_FunctionParams[(UIntPtr)407] + 15L / (long)sizeof(GA_SwitchWorld_C.__ExecuteUbergraph_GA_SwitchWorld_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SwitchWorld_C.__ExecuteUbergraph_GA_SwitchWorld_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SwitchWorld_C.__ExecuteUbergraph_GA_SwitchWorld_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B643 RID: 177731 RVA: 0x00A7A846 File Offset: 0x00A78A46
		protected GA_SwitchWorld_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CB3 RID: 97459
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SwitchWorld.GA_SwitchWorld_C";

		// Token: 0x04017CB4 RID: 97460
		private static IntPtr _ClassPtr;

		// Token: 0x04017CB5 RID: 97461
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CB6 RID: 97462
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CB7 RID: 97463
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CB8 RID: 97464
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CB9 RID: 97465
		private static IntPtr __ExecuteUbergraph_GA_SwitchWorld_NativeFunctionPtr;

		// Token: 0x0200A3A0 RID: 41888
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 392)]
		protected ref struct __ExecuteUbergraph_GA_SwitchWorld_FunctionParams
		{
			// Token: 0x0403317D RID: 209277
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
