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
	// Token: 0x02004085 RID: 16517
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_ExploreSkillInteract_Custom.GA_ExploreSkillInteract_Custom_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_ExploreSkillInteract_Custom_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF68 RID: 175976 RVA: 0x00A6B5DB File Offset: 0x00A697DB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_ExploreSkillInteract_Custom_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_ExploreSkillInteract_Custom.GA_ExploreSkillInteract_Custom_C");
			}
			return GA_ExploreSkillInteract_Custom_C._ClassPtr;
		}

		// Token: 0x0602AF69 RID: 175977 RVA: 0x00A6B600 File Offset: 0x00A69800
		public GA_ExploreSkillInteract_Custom_C() : this(BuiltinUtils.AllocNativeUObject(GA_ExploreSkillInteract_Custom_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF6A RID: 175978 RVA: 0x00A6B628 File Offset: 0x00A69828
		public GA_ExploreSkillInteract_Custom_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_ExploreSkillInteract_Custom_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700705C RID: 28764
		// (get) Token: 0x0602AF6B RID: 175979 RVA: 0x00A6B65C File Offset: 0x00A6985C
		// (set) Token: 0x0602AF6C RID: 175980 RVA: 0x00A6B695 File Offset: 0x00A69895
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_ExploreSkillInteract_Custom_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_ExploreSkillInteract_Custom_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602AF6D RID: 175981 RVA: 0x00A6B6B6 File Offset: 0x00A698B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_ExploreSkillInteract_Custom_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF6E RID: 175982 RVA: 0x00A6B6CA File Offset: 0x00A698CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_ExploreSkillInteract_Custom_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF6F RID: 175983 RVA: 0x00A6B6E0 File Offset: 0x00A698E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_ExploreSkillInteract_Custom(int EntryPoint)
		{
			GA_ExploreSkillInteract_Custom_C.__ExecuteUbergraph_GA_ExploreSkillInteract_Custom_FunctionParams* ptr = stackalloc GA_ExploreSkillInteract_Custom_C.__ExecuteUbergraph_GA_ExploreSkillInteract_Custom_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_ExploreSkillInteract_Custom_C.__ExecuteUbergraph_GA_ExploreSkillInteract_Custom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_ExploreSkillInteract_Custom_C.__ExecuteUbergraph_GA_ExploreSkillInteract_Custom_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_ExploreSkillInteract_Custom_C.__ExecuteUbergraph_GA_ExploreSkillInteract_Custom_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF70 RID: 175984 RVA: 0x00A6B727 File Offset: 0x00A69927
		protected GA_ExploreSkillInteract_Custom_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177A0 RID: 96160
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_ExploreSkillInteract_Custom.GA_ExploreSkillInteract_Custom_C";

		// Token: 0x040177A1 RID: 96161
		private static IntPtr _ClassPtr;

		// Token: 0x040177A2 RID: 96162
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177A3 RID: 96163
		internal new static int __PropertyOffset_0;

		// Token: 0x040177A4 RID: 96164
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177A5 RID: 96165
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177A6 RID: 96166
		private static IntPtr __ExecuteUbergraph_GA_ExploreSkillInteract_Custom_NativeFunctionPtr;

		// Token: 0x0200A2A4 RID: 41636
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_ExploreSkillInteract_Custom_FunctionParams
		{
			// Token: 0x04033057 RID: 208983
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
