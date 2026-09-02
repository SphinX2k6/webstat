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
	// Token: 0x0200407E RID: 16510
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_ManipulateSwitchMode.GA_Common_ManipulateSwitchMode_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Common_ManipulateSwitchMode_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AEC3 RID: 175811 RVA: 0x00A6A21F File Offset: 0x00A6841F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Common_ManipulateSwitchMode_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_ManipulateSwitchMode.GA_Common_ManipulateSwitchMode_C");
			}
			return GA_Common_ManipulateSwitchMode_C._ClassPtr;
		}

		// Token: 0x0602AEC4 RID: 175812 RVA: 0x00A6A244 File Offset: 0x00A68444
		public GA_Common_ManipulateSwitchMode_C() : this(BuiltinUtils.AllocNativeUObject(GA_Common_ManipulateSwitchMode_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AEC5 RID: 175813 RVA: 0x00A6A26C File Offset: 0x00A6846C
		public GA_Common_ManipulateSwitchMode_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Common_ManipulateSwitchMode_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007035 RID: 28725
		// (get) Token: 0x0602AEC6 RID: 175814 RVA: 0x00A6A2A0 File Offset: 0x00A684A0
		// (set) Token: 0x0602AEC7 RID: 175815 RVA: 0x00A6A2D9 File Offset: 0x00A684D9
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Common_ManipulateSwitchMode_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Common_ManipulateSwitchMode_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602AEC8 RID: 175816 RVA: 0x00A6A2FA File Offset: 0x00A684FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_ManipulateSwitchMode_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEC9 RID: 175817 RVA: 0x00A6A30E File Offset: 0x00A6850E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_ManipulateSwitchMode_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AECA RID: 175818 RVA: 0x00A6A324 File Offset: 0x00A68524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Common_ManipulateSwitchMode(int EntryPoint)
		{
			GA_Common_ManipulateSwitchMode_C.__ExecuteUbergraph_GA_Common_ManipulateSwitchMode_FunctionParams* ptr = stackalloc GA_Common_ManipulateSwitchMode_C.__ExecuteUbergraph_GA_Common_ManipulateSwitchMode_FunctionParams[(UIntPtr)1247] + 15L / (long)sizeof(GA_Common_ManipulateSwitchMode_C.__ExecuteUbergraph_GA_Common_ManipulateSwitchMode_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_ManipulateSwitchMode_C.__ExecuteUbergraph_GA_Common_ManipulateSwitchMode_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_ManipulateSwitchMode_C.__ExecuteUbergraph_GA_Common_ManipulateSwitchMode_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AECB RID: 175819 RVA: 0x00A6A36E File Offset: 0x00A6856E
		protected GA_Common_ManipulateSwitchMode_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401772C RID: 96044
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_ManipulateSwitchMode.GA_Common_ManipulateSwitchMode_C";

		// Token: 0x0401772D RID: 96045
		private static IntPtr _ClassPtr;

		// Token: 0x0401772E RID: 96046
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401772F RID: 96047
		internal new static int __PropertyOffset_0;

		// Token: 0x04017730 RID: 96048
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017731 RID: 96049
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017732 RID: 96050
		private static IntPtr __ExecuteUbergraph_GA_Common_ManipulateSwitchMode_NativeFunctionPtr;

		// Token: 0x0200A297 RID: 41623
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1232)]
		protected ref struct __ExecuteUbergraph_GA_Common_ManipulateSwitchMode_FunctionParams
		{
			// Token: 0x04033045 RID: 208965
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
