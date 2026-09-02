using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F69 RID: 16233
	[UnrealObjectPath("/Game/Aki/Core/Fight/OnlyData.OnlyData_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class OnlyData_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028871 RID: 166001 RVA: 0x00A0E028 File Offset: 0x00A0C228
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (OnlyData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/OnlyData.OnlyData_C");
			}
			return OnlyData_C._ClassPtr;
		}

		// Token: 0x06028872 RID: 166002 RVA: 0x00A0E04C File Offset: 0x00A0C24C
		public OnlyData_C() : this(BuiltinUtils.AllocNativeUObject(OnlyData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028873 RID: 166003 RVA: 0x00A0E074 File Offset: 0x00A0C274
		[NullableContext(1)]
		public OnlyData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(OnlyData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028874 RID: 166004 RVA: 0x00A0E0A8 File Offset: 0x00A0C2A8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetCommonNewBulletData([Nullable(1)] string DataName, UObject __WorldContext, ref bool isFind, ref SReBulletDataMain BulletData)
		{
			OnlyData_C.StaticClass();
			OnlyData_C.__GetCommonNewBulletData_FunctionParams* ptr = stackalloc OnlyData_C.__GetCommonNewBulletData_FunctionParams[(UIntPtr)4055] + 15L / (long)sizeof(OnlyData_C.__GetCommonNewBulletData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnlyData_C.__GetCommonNewBulletData_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->DataName), DataName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->isFind = isFind;
			if (BulletData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMain.StaticStruct(), &ptr->BulletData, BulletData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(OnlyData_C._ClassDefaultObjectPtr, OnlyData_C.__GetCommonNewBulletData_NativeFunctionPtr, (void*)ptr);
			isFind = ptr->isFind;
			if (BulletData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMain.StaticStruct(), BulletData.NativePtr, &ptr->BulletData, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(OnlyData_C.__GetCommonNewBulletData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028875 RID: 166005 RVA: 0x00A0E17C File Offset: 0x00A0C37C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetCommonHitData([Nullable(1)] string DataName, UObject __WorldContext, ref bool isFind, ref SHitEffect HitData)
		{
			OnlyData_C.StaticClass();
			OnlyData_C.__GetCommonHitData_FunctionParams* ptr = stackalloc OnlyData_C.__GetCommonHitData_FunctionParams[(UIntPtr)391] + 15L / (long)sizeof(OnlyData_C.__GetCommonHitData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnlyData_C.__GetCommonHitData_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->DataName), DataName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->isFind = isFind;
			if (HitData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitEffect.StaticStruct(), &ptr->HitData, HitData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(OnlyData_C._ClassDefaultObjectPtr, OnlyData_C.__GetCommonHitData_NativeFunctionPtr, (void*)ptr);
			isFind = ptr->isFind;
			if (HitData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitEffect.StaticStruct(), HitData.NativePtr, &ptr->HitData, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(OnlyData_C.__GetCommonHitData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028876 RID: 166006 RVA: 0x00A0E250 File Offset: 0x00A0C450
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetCommonBulletData([Nullable(1)] string DataName, UObject __WorldContext, ref bool isFind, ref SBulletDataMain BulletData)
		{
			OnlyData_C.StaticClass();
			OnlyData_C.__GetCommonBulletData_FunctionParams* ptr = stackalloc OnlyData_C.__GetCommonBulletData_FunctionParams[(UIntPtr)751] + 15L / (long)sizeof(OnlyData_C.__GetCommonBulletData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(OnlyData_C.__GetCommonBulletData_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->DataName), DataName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->isFind = isFind;
			if (BulletData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataMain.StaticStruct(), &ptr->BulletData, BulletData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(OnlyData_C._ClassDefaultObjectPtr, OnlyData_C.__GetCommonBulletData_NativeFunctionPtr, (void*)ptr);
			isFind = ptr->isFind;
			if (BulletData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataMain.StaticStruct(), BulletData.NativePtr, &ptr->BulletData, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(OnlyData_C.__GetCommonBulletData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028877 RID: 166007 RVA: 0x00A0E323 File Offset: 0x00A0C523
		protected OnlyData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040155F9 RID: 87545
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/OnlyData.OnlyData_C";

		// Token: 0x040155FA RID: 87546
		private static IntPtr _ClassPtr;

		// Token: 0x040155FB RID: 87547
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040155FC RID: 87548
		private static IntPtr __GetCommonNewBulletData_NativeFunctionPtr;

		// Token: 0x040155FD RID: 87549
		private static IntPtr __GetCommonHitData_NativeFunctionPtr;

		// Token: 0x040155FE RID: 87550
		private static IntPtr __GetCommonBulletData_NativeFunctionPtr;

		// Token: 0x0200A11D RID: 41245
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4040)]
		protected ref struct __GetCommonNewBulletData_FunctionParams
		{
			// Token: 0x04032E41 RID: 208449
			[FieldOffset(0)]
			public FString DataName;

			// Token: 0x04032E42 RID: 208450
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032E43 RID: 208451
			[FieldOffset(24)]
			public bool isFind;

			// Token: 0x04032E44 RID: 208452
			[FieldOffset(32)]
			public byte BulletData;
		}

		// Token: 0x0200A11E RID: 41246
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 376)]
		protected ref struct __GetCommonHitData_FunctionParams
		{
			// Token: 0x04032E45 RID: 208453
			[FieldOffset(0)]
			public FString DataName;

			// Token: 0x04032E46 RID: 208454
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032E47 RID: 208455
			[FieldOffset(24)]
			public bool isFind;

			// Token: 0x04032E48 RID: 208456
			[FieldOffset(28)]
			public byte HitData;
		}

		// Token: 0x0200A11F RID: 41247
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 736)]
		protected ref struct __GetCommonBulletData_FunctionParams
		{
			// Token: 0x04032E49 RID: 208457
			[FieldOffset(0)]
			public FString DataName;

			// Token: 0x04032E4A RID: 208458
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032E4B RID: 208459
			[FieldOffset(24)]
			public bool isFind;

			// Token: 0x04032E4C RID: 208460
			[FieldOffset(32)]
			public byte BulletData;
		}
	}
}
