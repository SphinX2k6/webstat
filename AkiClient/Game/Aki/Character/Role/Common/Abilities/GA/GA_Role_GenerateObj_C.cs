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
	// Token: 0x020040A9 RID: 16553
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_GenerateObj.GA_Role_GenerateObj_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_GenerateObj_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B25F RID: 176735 RVA: 0x00A71B9F File Offset: 0x00A6FD9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_GenerateObj_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_GenerateObj.GA_Role_GenerateObj_C");
			}
			return GA_Role_GenerateObj_C._ClassPtr;
		}

		// Token: 0x0602B260 RID: 176736 RVA: 0x00A71BC4 File Offset: 0x00A6FDC4
		public GA_Role_GenerateObj_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_GenerateObj_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B261 RID: 176737 RVA: 0x00A71BEC File Offset: 0x00A6FDEC
		public GA_Role_GenerateObj_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_GenerateObj_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070F0 RID: 28912
		// (get) Token: 0x0602B262 RID: 176738 RVA: 0x00A71C20 File Offset: 0x00A6FE20
		// (set) Token: 0x0602B263 RID: 176739 RVA: 0x00A71C59 File Offset: 0x00A6FE59
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_GenerateObj_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_GenerateObj_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B264 RID: 176740 RVA: 0x00A71C7A File Offset: 0x00A6FE7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_GenerateObj_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B265 RID: 176741 RVA: 0x00A71C8E File Offset: 0x00A6FE8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_GenerateObj_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B266 RID: 176742 RVA: 0x00A71CA4 File Offset: 0x00A6FEA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_GenerateObj(int EntryPoint)
		{
			GA_Role_GenerateObj_C.__ExecuteUbergraph_GA_Role_GenerateObj_FunctionParams* ptr = stackalloc GA_Role_GenerateObj_C.__ExecuteUbergraph_GA_Role_GenerateObj_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Role_GenerateObj_C.__ExecuteUbergraph_GA_Role_GenerateObj_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_GenerateObj_C.__ExecuteUbergraph_GA_Role_GenerateObj_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_GenerateObj_C.__ExecuteUbergraph_GA_Role_GenerateObj_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B267 RID: 176743 RVA: 0x00A71CEB File Offset: 0x00A6FEEB
		protected GA_Role_GenerateObj_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040179D2 RID: 96722
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_GenerateObj.GA_Role_GenerateObj_C";

		// Token: 0x040179D3 RID: 96723
		private static IntPtr _ClassPtr;

		// Token: 0x040179D4 RID: 96724
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040179D5 RID: 96725
		internal new static int __PropertyOffset_0;

		// Token: 0x040179D6 RID: 96726
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040179D7 RID: 96727
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040179D8 RID: 96728
		private static IntPtr __ExecuteUbergraph_GA_Role_GenerateObj_NativeFunctionPtr;

		// Token: 0x0200A2FF RID: 41727
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_GA_Role_GenerateObj_FunctionParams
		{
			// Token: 0x040330CA RID: 209098
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
