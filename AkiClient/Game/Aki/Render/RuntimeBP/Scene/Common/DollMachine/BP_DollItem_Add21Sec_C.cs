using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B07 RID: 15111
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_Add21Sec.BP_DollItem_Add21Sec_C")]
	[UnrealStructLayout(1600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1600)]
	public class BP_DollItem_Add21Sec_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020765 RID: 132965 RVA: 0x0092CB1F File Offset: 0x0092AD1F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_Add21Sec_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_Add21Sec.BP_DollItem_Add21Sec_C");
			}
			return BP_DollItem_Add21Sec_C._ClassPtr;
		}

		// Token: 0x06020766 RID: 132966 RVA: 0x0092CB44 File Offset: 0x0092AD44
		public BP_DollItem_Add21Sec_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_Add21Sec_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020767 RID: 132967 RVA: 0x0092CB6C File Offset: 0x0092AD6C
		public BP_DollItem_Add21Sec_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_Add21Sec_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035B5 RID: 13749
		// (get) Token: 0x06020768 RID: 132968 RVA: 0x0092CBA0 File Offset: 0x0092ADA0
		// (set) Token: 0x06020769 RID: 132969 RVA: 0x0092CBD9 File Offset: 0x0092ADD9
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollItem_Add21Sec_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollItem_Add21Sec_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035B6 RID: 13750
		// (get) Token: 0x0602076A RID: 132970 RVA: 0x0092CBFA File Offset: 0x0092ADFA
		// (set) Token: 0x0602076B RID: 132971 RVA: 0x0092CC0E File Offset: 0x0092AE0E
		[Nullable(2)]
		public unsafe UChildActorComponent BP_EffectActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_Add21Sec_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_Add21Sec_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035B7 RID: 13751
		// (get) Token: 0x0602076C RID: 132972 RVA: 0x0092CC23 File Offset: 0x0092AE23
		// (set) Token: 0x0602076D RID: 132973 RVA: 0x0092CC38 File Offset: 0x0092AE38
		public TSoftObjectPtr<EffectModelGroup> TimeGrabEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)BP_DollItem_Add21Sec_C.__PropertyOffset_2, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollItem_Add21Sec_C.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602076E RID: 132974 RVA: 0x0092CC60 File Offset: 0x0092AE60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TogglePlayEffect(bool Enable)
		{
			BP_DollItem_Add21Sec_C.__TogglePlayEffect_FunctionParams* ptr = stackalloc BP_DollItem_Add21Sec_C.__TogglePlayEffect_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_DollItem_Add21Sec_C.__TogglePlayEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_Add21Sec_C.__TogglePlayEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add21Sec_C.__TogglePlayEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602076F RID: 132975 RVA: 0x0092CCA6 File Offset: 0x0092AEA6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add21Sec_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020770 RID: 132976 RVA: 0x0092CCBA File Offset: 0x0092AEBA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_Add21Sec_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020771 RID: 132977 RVA: 0x0092CCD0 File Offset: 0x0092AED0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void SetVisible(bool ToggleVisibility, bool TogglePhysics)
		{
			BP_DollItem_Add21Sec_C.__SetVisible_FunctionParams* ptr = stackalloc BP_DollItem_Add21Sec_C.__SetVisible_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_DollItem_Add21Sec_C.__SetVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_Add21Sec_C.__SetVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ToggleVisibility = ToggleVisibility;
			ptr->TogglePhysics = TogglePhysics;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add21Sec_C.__SetVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020772 RID: 132978 RVA: 0x0092CD1D File Offset: 0x0092AF1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void PlayTimeEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add21Sec_C.__PlayTimeEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06020773 RID: 132979 RVA: 0x0092CD34 File Offset: 0x0092AF34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollItem_Add21Sec(int EntryPoint)
		{
			BP_DollItem_Add21Sec_C.__ExecuteUbergraph_BP_DollItem_Add21Sec_FunctionParams* ptr = stackalloc BP_DollItem_Add21Sec_C.__ExecuteUbergraph_BP_DollItem_Add21Sec_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_DollItem_Add21Sec_C.__ExecuteUbergraph_BP_DollItem_Add21Sec_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_Add21Sec_C.__ExecuteUbergraph_BP_DollItem_Add21Sec_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_Add21Sec_C.__ExecuteUbergraph_BP_DollItem_Add21Sec_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020774 RID: 132980 RVA: 0x0092CD7E File Offset: 0x0092AF7E
		protected BP_DollItem_Add21Sec_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401039A RID: 66458
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_Add21Sec.BP_DollItem_Add21Sec_C";

		// Token: 0x0401039B RID: 66459
		private static IntPtr _ClassPtr;

		// Token: 0x0401039C RID: 66460
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401039D RID: 66461
		internal new static int __PropertyOffset_0;

		// Token: 0x0401039E RID: 66462
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401039F RID: 66463
		internal new static int __PropertyOffset_1;

		// Token: 0x040103A0 RID: 66464
		internal new static int __PropertyOffset_2;

		// Token: 0x040103A1 RID: 66465
		private static IntPtr __TogglePlayEffect_NativeFunctionPtr;

		// Token: 0x040103A2 RID: 66466
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040103A3 RID: 66467
		private static IntPtr __SetVisible_NativeFunctionPtr;

		// Token: 0x040103A4 RID: 66468
		private static IntPtr __PlayTimeEffect_NativeFunctionPtr;

		// Token: 0x040103A5 RID: 66469
		private static IntPtr __ExecuteUbergraph_BP_DollItem_Add21Sec_NativeFunctionPtr;

		// Token: 0x020099B9 RID: 39353
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __TogglePlayEffect_FunctionParams
		{
			// Token: 0x0403205A RID: 204890
			[FieldOffset(0)]
			public bool Enable;
		}

		// Token: 0x020099BA RID: 39354
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected new ref struct __SetVisible_FunctionParams
		{
			// Token: 0x0403205B RID: 204891
			[FieldOffset(0)]
			public bool ToggleVisibility;

			// Token: 0x0403205C RID: 204892
			[FieldOffset(1)]
			public bool TogglePhysics;
		}

		// Token: 0x020099BB RID: 39355
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __ExecuteUbergraph_BP_DollItem_Add21Sec_FunctionParams
		{
			// Token: 0x0403205D RID: 204893
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
