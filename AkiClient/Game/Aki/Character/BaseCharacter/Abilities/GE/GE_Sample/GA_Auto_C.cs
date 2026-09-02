using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x02004337 RID: 17207
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GA_Auto.GA_Auto_C")]
	[UnrealStructLayout(992, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 992)]
	public class GA_Auto_C : UBaseGameplayAbility, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA41 RID: 186945 RVA: 0x00AC5668 File Offset: 0x00AC3868
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Auto_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GA_Auto.GA_Auto_C");
			}
			return GA_Auto_C._ClassPtr;
		}

		// Token: 0x0602DA42 RID: 186946 RVA: 0x00AC568C File Offset: 0x00AC388C
		public GA_Auto_C() : this(BuiltinUtils.AllocNativeUObject(GA_Auto_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA43 RID: 186947 RVA: 0x00AC56B4 File Offset: 0x00AC38B4
		public GA_Auto_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Auto_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D22 RID: 32034
		// (get) Token: 0x0602DA44 RID: 186948 RVA: 0x00AC56E8 File Offset: 0x00AC38E8
		// (set) Token: 0x0602DA45 RID: 186949 RVA: 0x00AC5721 File Offset: 0x00AC3921
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Auto_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Auto_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D23 RID: 32035
		// (get) Token: 0x0602DA46 RID: 186950 RVA: 0x00AC5742 File Offset: 0x00AC3942
		// (set) Token: 0x0602DA47 RID: 186951 RVA: 0x00AC5756 File Offset: 0x00AC3956
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Auto_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Auto_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602DA48 RID: 186952 RVA: 0x00AC576B File Offset: 0x00AC396B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Auto_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602DA49 RID: 186953 RVA: 0x00AC577F File Offset: 0x00AC397F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Auto_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DA4A RID: 186954 RVA: 0x00AC5794 File Offset: 0x00AC3994
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Auto(int EntryPoint)
		{
			GA_Auto_C.__ExecuteUbergraph_GA_Auto_FunctionParams* ptr = stackalloc GA_Auto_C.__ExecuteUbergraph_GA_Auto_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Auto_C.__ExecuteUbergraph_GA_Auto_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Auto_C.__ExecuteUbergraph_GA_Auto_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Auto_C.__ExecuteUbergraph_GA_Auto_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DA4B RID: 186955 RVA: 0x00AC57DB File Offset: 0x00AC39DB
		protected GA_Auto_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BBB RID: 105403
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GA_Auto.GA_Auto_C";

		// Token: 0x04019BBC RID: 105404
		private static IntPtr _ClassPtr;

		// Token: 0x04019BBD RID: 105405
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019BBE RID: 105406
		internal static int __PropertyOffset_0;

		// Token: 0x04019BBF RID: 105407
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019BC0 RID: 105408
		internal static int __PropertyOffset_1;

		// Token: 0x04019BC1 RID: 105409
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04019BC2 RID: 105410
		private static IntPtr __ExecuteUbergraph_GA_Auto_NativeFunctionPtr;

		// Token: 0x0200A531 RID: 42289
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_GA_Auto_FunctionParams
		{
			// Token: 0x040333EA RID: 209898
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
