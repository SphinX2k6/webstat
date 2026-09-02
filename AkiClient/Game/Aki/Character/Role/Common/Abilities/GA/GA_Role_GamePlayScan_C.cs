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
	// Token: 0x020040A8 RID: 16552
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_GamePlayScan.GA_Role_GamePlayScan_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_GamePlayScan_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B256 RID: 176726 RVA: 0x00A71A47 File Offset: 0x00A6FC47
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_GamePlayScan_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_GamePlayScan.GA_Role_GamePlayScan_C");
			}
			return GA_Role_GamePlayScan_C._ClassPtr;
		}

		// Token: 0x0602B257 RID: 176727 RVA: 0x00A71A6C File Offset: 0x00A6FC6C
		public GA_Role_GamePlayScan_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_GamePlayScan_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B258 RID: 176728 RVA: 0x00A71A94 File Offset: 0x00A6FC94
		public GA_Role_GamePlayScan_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_GamePlayScan_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070EF RID: 28911
		// (get) Token: 0x0602B259 RID: 176729 RVA: 0x00A71AC8 File Offset: 0x00A6FCC8
		// (set) Token: 0x0602B25A RID: 176730 RVA: 0x00A71B01 File Offset: 0x00A6FD01
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_GamePlayScan_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_GamePlayScan_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B25B RID: 176731 RVA: 0x00A71B22 File Offset: 0x00A6FD22
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_GamePlayScan_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B25C RID: 176732 RVA: 0x00A71B36 File Offset: 0x00A6FD36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_GamePlayScan_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B25D RID: 176733 RVA: 0x00A71B4C File Offset: 0x00A6FD4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_GamePlayScan(int EntryPoint)
		{
			GA_Role_GamePlayScan_C.__ExecuteUbergraph_GA_Role_GamePlayScan_FunctionParams* ptr = stackalloc GA_Role_GamePlayScan_C.__ExecuteUbergraph_GA_Role_GamePlayScan_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(GA_Role_GamePlayScan_C.__ExecuteUbergraph_GA_Role_GamePlayScan_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_GamePlayScan_C.__ExecuteUbergraph_GA_Role_GamePlayScan_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_GamePlayScan_C.__ExecuteUbergraph_GA_Role_GamePlayScan_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B25E RID: 176734 RVA: 0x00A71B96 File Offset: 0x00A6FD96
		protected GA_Role_GamePlayScan_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040179CB RID: 96715
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_GamePlayScan.GA_Role_GamePlayScan_C";

		// Token: 0x040179CC RID: 96716
		private static IntPtr _ClassPtr;

		// Token: 0x040179CD RID: 96717
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040179CE RID: 96718
		internal new static int __PropertyOffset_0;

		// Token: 0x040179CF RID: 96719
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040179D0 RID: 96720
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040179D1 RID: 96721
		private static IntPtr __ExecuteUbergraph_GA_Role_GamePlayScan_NativeFunctionPtr;

		// Token: 0x0200A2FE RID: 41726
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __ExecuteUbergraph_GA_Role_GamePlayScan_FunctionParams
		{
			// Token: 0x040330C9 RID: 209097
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
