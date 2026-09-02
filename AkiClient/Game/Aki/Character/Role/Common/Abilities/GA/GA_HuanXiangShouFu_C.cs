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
	// Token: 0x0200408A RID: 16522
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_HuanXiangShouFu.GA_HuanXiangShouFu_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_HuanXiangShouFu_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AFAC RID: 176044 RVA: 0x00A6C053 File Offset: 0x00A6A253
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_HuanXiangShouFu_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_HuanXiangShouFu.GA_HuanXiangShouFu_C");
			}
			return GA_HuanXiangShouFu_C._ClassPtr;
		}

		// Token: 0x0602AFAD RID: 176045 RVA: 0x00A6C078 File Offset: 0x00A6A278
		public GA_HuanXiangShouFu_C() : this(BuiltinUtils.AllocNativeUObject(GA_HuanXiangShouFu_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AFAE RID: 176046 RVA: 0x00A6C0A0 File Offset: 0x00A6A2A0
		[NullableContext(1)]
		public GA_HuanXiangShouFu_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_HuanXiangShouFu_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007066 RID: 28774
		// (get) Token: 0x0602AFAF RID: 176047 RVA: 0x00A6C0D4 File Offset: 0x00A6A2D4
		// (set) Token: 0x0602AFB0 RID: 176048 RVA: 0x00A6C10D File Offset: 0x00A6A30D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_HuanXiangShouFu_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_HuanXiangShouFu_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007067 RID: 28775
		// (get) Token: 0x0602AFB1 RID: 176049 RVA: 0x00A6C12E File Offset: 0x00A6A32E
		// (set) Token: 0x0602AFB2 RID: 176050 RVA: 0x00A6C142 File Offset: 0x00A6A342
		public unsafe FVectorDouble loc
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_HuanXiangShouFu_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_HuanXiangShouFu_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602AFB3 RID: 176051 RVA: 0x00A6C158 File Offset: 0x00A6A358
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 面向目标收复(TsBaseCharacter 目标, FVectorDouble 面向目标)
		{
			GA_HuanXiangShouFu_C.__面向目标收复_FunctionParams* ptr = stackalloc GA_HuanXiangShouFu_C.__面向目标收复_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(GA_HuanXiangShouFu_C.__面向目标收复_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_HuanXiangShouFu_C.__面向目标收复_NativeFunctionPtr, (void*)ptr, 1);
			ptr->目标 = ((目标 != null) ? 目标.NativePtr : IntPtr.Zero);
			ptr->面向目标 = 面向目标;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_HuanXiangShouFu_C.__面向目标收复_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFB4 RID: 176052 RVA: 0x00A6C1B8 File Offset: 0x00A6A3B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_HuanXiangShouFu_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_HuanXiangShouFu_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_HuanXiangShouFu_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_HuanXiangShouFu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_HuanXiangShouFu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFB5 RID: 176053 RVA: 0x00A6C200 File Offset: 0x00A6A400
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_HuanXiangShouFu_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_HuanXiangShouFu_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_HuanXiangShouFu_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_HuanXiangShouFu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_HuanXiangShouFu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFB6 RID: 176054 RVA: 0x00A6C247 File Offset: 0x00A6A447
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_HuanXiangShouFu_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFB7 RID: 176055 RVA: 0x00A6C25B File Offset: 0x00A6A45B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_HuanXiangShouFu_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AFB8 RID: 176056 RVA: 0x00A6C270 File Offset: 0x00A6A470
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_HuanXiangShouFu(int EntryPoint)
		{
			GA_HuanXiangShouFu_C.__ExecuteUbergraph_GA_HuanXiangShouFu_FunctionParams* ptr = stackalloc GA_HuanXiangShouFu_C.__ExecuteUbergraph_GA_HuanXiangShouFu_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_HuanXiangShouFu_C.__ExecuteUbergraph_GA_HuanXiangShouFu_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_HuanXiangShouFu_C.__ExecuteUbergraph_GA_HuanXiangShouFu_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_HuanXiangShouFu_C.__ExecuteUbergraph_GA_HuanXiangShouFu_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFB9 RID: 176057 RVA: 0x00A6C2B7 File Offset: 0x00A6A4B7
		protected GA_HuanXiangShouFu_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177D5 RID: 96213
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_HuanXiangShouFu.GA_HuanXiangShouFu_C";

		// Token: 0x040177D6 RID: 96214
		private static IntPtr _ClassPtr;

		// Token: 0x040177D7 RID: 96215
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177D8 RID: 96216
		internal new static int __PropertyOffset_0;

		// Token: 0x040177D9 RID: 96217
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177DA RID: 96218
		internal new static int __PropertyOffset_1;

		// Token: 0x040177DB RID: 96219
		private static IntPtr __面向目标收复_NativeFunctionPtr;

		// Token: 0x040177DC RID: 96220
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040177DD RID: 96221
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177DE RID: 96222
		private static IntPtr __ExecuteUbergraph_GA_HuanXiangShouFu_NativeFunctionPtr;

		// Token: 0x0200A2AE RID: 41646
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __面向目标收复_FunctionParams
		{
			// Token: 0x04033061 RID: 208993
			[FieldOffset(0)]
			public IntPtr 目标;

			// Token: 0x04033062 RID: 208994
			[FieldOffset(8)]
			public FVectorDouble 面向目标;
		}

		// Token: 0x0200A2AF RID: 41647
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033063 RID: 208995
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2B0 RID: 41648
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_HuanXiangShouFu_FunctionParams
		{
			// Token: 0x04033064 RID: 208996
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
