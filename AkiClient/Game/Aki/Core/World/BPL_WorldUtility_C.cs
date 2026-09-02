using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.AI.Struct;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.Map.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.World
{
	// Token: 0x02003F43 RID: 16195
	[UnrealObjectPath("/Game/Aki/Core/World/BPL_WorldUtility.BPL_WorldUtility_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_WorldUtility_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602870A RID: 165642 RVA: 0x00A0AC4E File Offset: 0x00A08E4E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_WorldUtility_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/World/BPL_WorldUtility.BPL_WorldUtility_C");
			}
			return BPL_WorldUtility_C._ClassPtr;
		}

		// Token: 0x0602870B RID: 165643 RVA: 0x00A0AC74 File Offset: 0x00A08E74
		public BPL_WorldUtility_C() : this(BuiltinUtils.AllocNativeUObject(BPL_WorldUtility_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602870C RID: 165644 RVA: 0x00A0AC9C File Offset: 0x00A08E9C
		[NullableContext(1)]
		public BPL_WorldUtility_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_WorldUtility_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602870D RID: 165645 RVA: 0x00A0ACD0 File Offset: 0x00A08ED0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadAiConfig(FName RoleName, UObject __WorldContext, ref bool Exist, ref SAIConfig Out_Row)
		{
			BPL_WorldUtility_C.StaticClass();
			BPL_WorldUtility_C.__LoadAiConfig_FunctionParams* ptr = stackalloc BPL_WorldUtility_C.__LoadAiConfig_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BPL_WorldUtility_C.__LoadAiConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_WorldUtility_C.__LoadAiConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RoleName = RoleName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Exist = Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAIConfig.StaticStruct(), &ptr->Out_Row, Out_Row.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_WorldUtility_C._ClassDefaultObjectPtr, BPL_WorldUtility_C.__LoadAiConfig_NativeFunctionPtr, (void*)ptr);
			Exist = ptr->Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAIConfig.StaticStruct(), Out_Row.NativePtr, &ptr->Out_Row, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_WorldUtility_C.__LoadAiConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602870E RID: 165646 RVA: 0x00A0ADA0 File Offset: 0x00A08FA0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetEntityProperty(FName RoleName, UObject __WorldContext, ref bool Exist, ref SEntityProperty Out_Row)
		{
			BPL_WorldUtility_C.StaticClass();
			BPL_WorldUtility_C.__GetEntityProperty_FunctionParams* ptr = stackalloc BPL_WorldUtility_C.__GetEntityProperty_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BPL_WorldUtility_C.__GetEntityProperty_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_WorldUtility_C.__GetEntityProperty_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RoleName = RoleName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Exist = Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEntityProperty.StaticStruct(), &ptr->Out_Row, Out_Row.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_WorldUtility_C._ClassDefaultObjectPtr, BPL_WorldUtility_C.__GetEntityProperty_NativeFunctionPtr, (void*)ptr);
			Exist = ptr->Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEntityProperty.StaticStruct(), Out_Row.NativePtr, &ptr->Out_Row, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_WorldUtility_C.__GetEntityProperty_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602870F RID: 165647 RVA: 0x00A0AE70 File Offset: 0x00A09070
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetMapTableByName(FName RowName, UObject __WorldContext, ref bool Exist, ref SMapConfig Out_Row)
		{
			BPL_WorldUtility_C.StaticClass();
			BPL_WorldUtility_C.__GetMapTableByName_FunctionParams* ptr = stackalloc BPL_WorldUtility_C.__GetMapTableByName_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BPL_WorldUtility_C.__GetMapTableByName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_WorldUtility_C.__GetMapTableByName_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RowName = RowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Exist = Exist;
			ptr->Out_Row = Out_Row;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_WorldUtility_C._ClassDefaultObjectPtr, BPL_WorldUtility_C.__GetMapTableByName_NativeFunctionPtr, (void*)ptr);
			Exist = ptr->Exist;
			Out_Row = ptr->Out_Row;
		}

		// Token: 0x06028710 RID: 165648 RVA: 0x00A0AEFC File Offset: 0x00A090FC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetModelTableByName(FName RowName, UObject __WorldContext, ref bool Exist, ref SModelConfig Out_Row)
		{
			BPL_WorldUtility_C.StaticClass();
			BPL_WorldUtility_C.__GetModelTableByName_FunctionParams* ptr = stackalloc BPL_WorldUtility_C.__GetModelTableByName_FunctionParams[(UIntPtr)2343] + 15L / (long)sizeof(BPL_WorldUtility_C.__GetModelTableByName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_WorldUtility_C.__GetModelTableByName_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RowName = RowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Exist = Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SModelConfig.StaticStruct(), &ptr->Out_Row, Out_Row.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_WorldUtility_C._ClassDefaultObjectPtr, BPL_WorldUtility_C.__GetModelTableByName_NativeFunctionPtr, (void*)ptr);
			Exist = ptr->Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SModelConfig.StaticStruct(), Out_Row.NativePtr, &ptr->Out_Row, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_WorldUtility_C.__GetModelTableByName_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028711 RID: 165649 RVA: 0x00A0AFCC File Offset: 0x00A091CC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetEntityTableByName(FName RowName, UObject __WorldContext, ref bool Exist, ref SEntityConfig Out_Row)
		{
			BPL_WorldUtility_C.StaticClass();
			BPL_WorldUtility_C.__GetEntityTableByName_FunctionParams* ptr = stackalloc BPL_WorldUtility_C.__GetEntityTableByName_FunctionParams[(UIntPtr)1399] + 15L / (long)sizeof(BPL_WorldUtility_C.__GetEntityTableByName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_WorldUtility_C.__GetEntityTableByName_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RowName = RowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Exist = Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEntityConfig.StaticStruct(), &ptr->Out_Row, Out_Row.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_WorldUtility_C._ClassDefaultObjectPtr, BPL_WorldUtility_C.__GetEntityTableByName_NativeFunctionPtr, (void*)ptr);
			Exist = ptr->Exist;
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEntityConfig.StaticStruct(), Out_Row.NativePtr, &ptr->Out_Row, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_WorldUtility_C.__GetEntityTableByName_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028712 RID: 165650 RVA: 0x00A0B099 File Offset: 0x00A09299
		protected BPL_WorldUtility_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015451 RID: 87121
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/World/BPL_WorldUtility.BPL_WorldUtility_C";

		// Token: 0x04015452 RID: 87122
		private static IntPtr _ClassPtr;

		// Token: 0x04015453 RID: 87123
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015454 RID: 87124
		private static IntPtr __LoadAiConfig_NativeFunctionPtr;

		// Token: 0x04015455 RID: 87125
		private static IntPtr __GetEntityProperty_NativeFunctionPtr;

		// Token: 0x04015456 RID: 87126
		private static IntPtr __GetMapTableByName_NativeFunctionPtr;

		// Token: 0x04015457 RID: 87127
		private static IntPtr __GetModelTableByName_NativeFunctionPtr;

		// Token: 0x04015458 RID: 87128
		private static IntPtr __GetEntityTableByName_NativeFunctionPtr;

		// Token: 0x0200A0F2 RID: 41202
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __LoadAiConfig_FunctionParams
		{
			// Token: 0x04032DBE RID: 208318
			[FieldOffset(0)]
			public FName RoleName;

			// Token: 0x04032DBF RID: 208319
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032DC0 RID: 208320
			[FieldOffset(24)]
			public bool Exist;

			// Token: 0x04032DC1 RID: 208321
			[FieldOffset(32)]
			public byte Out_Row;
		}

		// Token: 0x0200A0F3 RID: 41203
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __GetEntityProperty_FunctionParams
		{
			// Token: 0x04032DC2 RID: 208322
			[FieldOffset(0)]
			public FName RoleName;

			// Token: 0x04032DC3 RID: 208323
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032DC4 RID: 208324
			[FieldOffset(24)]
			public bool Exist;

			// Token: 0x04032DC5 RID: 208325
			[FieldOffset(32)]
			public byte Out_Row;
		}

		// Token: 0x0200A0F4 RID: 41204
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetMapTableByName_FunctionParams
		{
			// Token: 0x04032DC6 RID: 208326
			[FieldOffset(0)]
			public FName RowName;

			// Token: 0x04032DC7 RID: 208327
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032DC8 RID: 208328
			[FieldOffset(24)]
			public bool Exist;

			// Token: 0x04032DC9 RID: 208329
			[FieldOffset(28)]
			public SMapConfig Out_Row;
		}

		// Token: 0x0200A0F5 RID: 41205
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2328)]
		protected ref struct __GetModelTableByName_FunctionParams
		{
			// Token: 0x04032DCA RID: 208330
			[FieldOffset(0)]
			public FName RowName;

			// Token: 0x04032DCB RID: 208331
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032DCC RID: 208332
			[FieldOffset(24)]
			public bool Exist;

			// Token: 0x04032DCD RID: 208333
			[FieldOffset(32)]
			public byte Out_Row;
		}

		// Token: 0x0200A0F6 RID: 41206
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1384)]
		protected ref struct __GetEntityTableByName_FunctionParams
		{
			// Token: 0x04032DCE RID: 208334
			[FieldOffset(0)]
			public FName RowName;

			// Token: 0x04032DCF RID: 208335
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032DD0 RID: 208336
			[FieldOffset(24)]
			public bool Exist;

			// Token: 0x04032DD1 RID: 208337
			[FieldOffset(32)]
			public byte Out_Row;
		}
	}
}
