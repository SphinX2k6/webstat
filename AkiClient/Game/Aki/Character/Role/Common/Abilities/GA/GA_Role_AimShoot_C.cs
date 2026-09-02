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
	// Token: 0x0200409F RID: 16543
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_AimShoot.GA_Role_AimShoot_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_AimShoot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B0FA RID: 176378 RVA: 0x00A6F187 File Offset: 0x00A6D387
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_AimShoot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_AimShoot.GA_Role_AimShoot_C");
			}
			return GA_Role_AimShoot_C._ClassPtr;
		}

		// Token: 0x0602B0FB RID: 176379 RVA: 0x00A6F1AC File Offset: 0x00A6D3AC
		public GA_Role_AimShoot_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_AimShoot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B0FC RID: 176380 RVA: 0x00A6F1D4 File Offset: 0x00A6D3D4
		public GA_Role_AimShoot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_AimShoot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007091 RID: 28817
		// (get) Token: 0x0602B0FD RID: 176381 RVA: 0x00A6F208 File Offset: 0x00A6D408
		// (set) Token: 0x0602B0FE RID: 176382 RVA: 0x00A6F241 File Offset: 0x00A6D441
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_AimShoot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_AimShoot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B0FF RID: 176383 RVA: 0x00A6F262 File Offset: 0x00A6D462
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_AimShoot_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B100 RID: 176384 RVA: 0x00A6F276 File Offset: 0x00A6D476
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_AimShoot_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B101 RID: 176385 RVA: 0x00A6F28C File Offset: 0x00A6D48C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_AimShoot(int EntryPoint)
		{
			GA_Role_AimShoot_C.__ExecuteUbergraph_GA_Role_AimShoot_FunctionParams* ptr = stackalloc GA_Role_AimShoot_C.__ExecuteUbergraph_GA_Role_AimShoot_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(GA_Role_AimShoot_C.__ExecuteUbergraph_GA_Role_AimShoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_AimShoot_C.__ExecuteUbergraph_GA_Role_AimShoot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_AimShoot_C.__ExecuteUbergraph_GA_Role_AimShoot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B102 RID: 176386 RVA: 0x00A6F2D3 File Offset: 0x00A6D4D3
		protected GA_Role_AimShoot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040178D3 RID: 96467
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_AimShoot.GA_Role_AimShoot_C";

		// Token: 0x040178D4 RID: 96468
		private static IntPtr _ClassPtr;

		// Token: 0x040178D5 RID: 96469
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040178D6 RID: 96470
		internal new static int __PropertyOffset_0;

		// Token: 0x040178D7 RID: 96471
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040178D8 RID: 96472
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040178D9 RID: 96473
		private static IntPtr __ExecuteUbergraph_GA_Role_AimShoot_NativeFunctionPtr;

		// Token: 0x0200A2DD RID: 41693
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_GA_Role_AimShoot_FunctionParams
		{
			// Token: 0x0403309E RID: 209054
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
