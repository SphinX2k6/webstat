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
	// Token: 0x02004086 RID: 16518
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Floater_Aim.GA_Floater_Aim_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Floater_Aim_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF71 RID: 175985 RVA: 0x00A6B730 File Offset: 0x00A69930
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Floater_Aim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Floater_Aim.GA_Floater_Aim_C");
			}
			return GA_Floater_Aim_C._ClassPtr;
		}

		// Token: 0x0602AF72 RID: 175986 RVA: 0x00A6B754 File Offset: 0x00A69954
		public GA_Floater_Aim_C() : this(BuiltinUtils.AllocNativeUObject(GA_Floater_Aim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF73 RID: 175987 RVA: 0x00A6B77C File Offset: 0x00A6997C
		[NullableContext(1)]
		public GA_Floater_Aim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Floater_Aim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700705D RID: 28765
		// (get) Token: 0x0602AF74 RID: 175988 RVA: 0x00A6B7B0 File Offset: 0x00A699B0
		// (set) Token: 0x0602AF75 RID: 175989 RVA: 0x00A6B7E9 File Offset: 0x00A699E9
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Floater_Aim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Floater_Aim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602AF76 RID: 175990 RVA: 0x00A6B80C File Offset: 0x00A69A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_8B6138384F011AC35A3A6290139F19F4(in FGameplayTag Tag)
		{
			GA_Floater_Aim_C.__Added_8B6138384F011AC35A3A6290139F19F4_FunctionParams* ptr = stackalloc GA_Floater_Aim_C.__Added_8B6138384F011AC35A3A6290139F19F4_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Floater_Aim_C.__Added_8B6138384F011AC35A3A6290139F19F4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Floater_Aim_C.__Added_8B6138384F011AC35A3A6290139F19F4_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Floater_Aim_C.__Added_8B6138384F011AC35A3A6290139F19F4_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF77 RID: 175991 RVA: 0x00A6B857 File Offset: 0x00A69A57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Floater_Aim_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF78 RID: 175992 RVA: 0x00A6B86B File Offset: 0x00A69A6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Floater_Aim_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF79 RID: 175993 RVA: 0x00A6B880 File Offset: 0x00A69A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Floater_Aim(int EntryPoint)
		{
			GA_Floater_Aim_C.__ExecuteUbergraph_GA_Floater_Aim_FunctionParams* ptr = stackalloc GA_Floater_Aim_C.__ExecuteUbergraph_GA_Floater_Aim_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(GA_Floater_Aim_C.__ExecuteUbergraph_GA_Floater_Aim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Floater_Aim_C.__ExecuteUbergraph_GA_Floater_Aim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Floater_Aim_C.__ExecuteUbergraph_GA_Floater_Aim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF7A RID: 175994 RVA: 0x00A6B8C7 File Offset: 0x00A69AC7
		protected GA_Floater_Aim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177A7 RID: 96167
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Floater_Aim.GA_Floater_Aim_C";

		// Token: 0x040177A8 RID: 96168
		private static IntPtr _ClassPtr;

		// Token: 0x040177A9 RID: 96169
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177AA RID: 96170
		internal new static int __PropertyOffset_0;

		// Token: 0x040177AB RID: 96171
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177AC RID: 96172
		private static IntPtr __Added_8B6138384F011AC35A3A6290139F19F4_NativeFunctionPtr;

		// Token: 0x040177AD RID: 96173
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177AE RID: 96174
		private static IntPtr __ExecuteUbergraph_GA_Floater_Aim_NativeFunctionPtr;

		// Token: 0x0200A2A5 RID: 41637
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_8B6138384F011AC35A3A6290139F19F4_FunctionParams
		{
			// Token: 0x04033058 RID: 208984
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A2A6 RID: 41638
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_GA_Floater_Aim_FunctionParams
		{
			// Token: 0x04033059 RID: 208985
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
