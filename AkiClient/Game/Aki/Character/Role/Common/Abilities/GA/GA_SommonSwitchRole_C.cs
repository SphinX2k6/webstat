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
	// Token: 0x020040B9 RID: 16569
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_SommonSwitchRole.GA_SommonSwitchRole_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_SommonSwitchRole_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B45B RID: 177243 RVA: 0x00A76123 File Offset: 0x00A74323
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_SommonSwitchRole_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SommonSwitchRole.GA_SommonSwitchRole_C");
			}
			return GA_SommonSwitchRole_C._ClassPtr;
		}

		// Token: 0x0602B45C RID: 177244 RVA: 0x00A76148 File Offset: 0x00A74348
		public GA_SommonSwitchRole_C() : this(BuiltinUtils.AllocNativeUObject(GA_SommonSwitchRole_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B45D RID: 177245 RVA: 0x00A76170 File Offset: 0x00A74370
		public GA_SommonSwitchRole_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_SommonSwitchRole_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007157 RID: 29015
		// (get) Token: 0x0602B45E RID: 177246 RVA: 0x00A761A4 File Offset: 0x00A743A4
		// (set) Token: 0x0602B45F RID: 177247 RVA: 0x00A761DD File Offset: 0x00A743DD
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_SommonSwitchRole_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_SommonSwitchRole_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007158 RID: 29016
		// (get) Token: 0x0602B460 RID: 177248 RVA: 0x00A761FE File Offset: 0x00A743FE
		// (set) Token: 0x0602B461 RID: 177249 RVA: 0x00A76212 File Offset: 0x00A74412
		[Nullable(2)]
		public unsafe UObject 变身开始_材质特效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + GA_SommonSwitchRole_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_SommonSwitchRole_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B462 RID: 177250 RVA: 0x00A76227 File Offset: 0x00A74427
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SommonSwitchRole_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B463 RID: 177251 RVA: 0x00A7623B File Offset: 0x00A7443B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SommonSwitchRole_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B464 RID: 177252 RVA: 0x00A76250 File Offset: 0x00A74450
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_SommonSwitchRole_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B465 RID: 177253 RVA: 0x00A76264 File Offset: 0x00A74464
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_SommonSwitchRole(int EntryPoint)
		{
			GA_SommonSwitchRole_C.__ExecuteUbergraph_GA_SommonSwitchRole_FunctionParams* ptr = stackalloc GA_SommonSwitchRole_C.__ExecuteUbergraph_GA_SommonSwitchRole_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(GA_SommonSwitchRole_C.__ExecuteUbergraph_GA_SommonSwitchRole_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_SommonSwitchRole_C.__ExecuteUbergraph_GA_SommonSwitchRole_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_SommonSwitchRole_C.__ExecuteUbergraph_GA_SommonSwitchRole_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B466 RID: 177254 RVA: 0x00A762AB File Offset: 0x00A744AB
		protected GA_SommonSwitchRole_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B45 RID: 97093
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_SommonSwitchRole.GA_SommonSwitchRole_C";

		// Token: 0x04017B46 RID: 97094
		private static IntPtr _ClassPtr;

		// Token: 0x04017B47 RID: 97095
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B48 RID: 97096
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B49 RID: 97097
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B4A RID: 97098
		internal new static int __PropertyOffset_1;

		// Token: 0x04017B4B RID: 97099
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B4C RID: 97100
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04017B4D RID: 97101
		private static IntPtr __ExecuteUbergraph_GA_SommonSwitchRole_NativeFunctionPtr;

		// Token: 0x0200A33E RID: 41790
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_GA_SommonSwitchRole_FunctionParams
		{
			// Token: 0x0403311B RID: 209179
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
