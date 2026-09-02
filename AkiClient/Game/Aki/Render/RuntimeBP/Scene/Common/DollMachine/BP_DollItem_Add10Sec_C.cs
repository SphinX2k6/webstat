using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B06 RID: 15110
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_Add10Sec.BP_DollItem_Add10Sec_C")]
	[UnrealStructLayout(1600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1600)]
	public class BP_DollItem_Add10Sec_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020755 RID: 132949 RVA: 0x0092C8B6 File Offset: 0x0092AAB6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_Add10Sec_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_Add10Sec.BP_DollItem_Add10Sec_C");
			}
			return BP_DollItem_Add10Sec_C._ClassPtr;
		}

		// Token: 0x06020756 RID: 132950 RVA: 0x0092C8DC File Offset: 0x0092AADC
		public BP_DollItem_Add10Sec_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_Add10Sec_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020757 RID: 132951 RVA: 0x0092C904 File Offset: 0x0092AB04
		public BP_DollItem_Add10Sec_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_Add10Sec_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035B2 RID: 13746
		// (get) Token: 0x06020758 RID: 132952 RVA: 0x0092C938 File Offset: 0x0092AB38
		// (set) Token: 0x06020759 RID: 132953 RVA: 0x0092C971 File Offset: 0x0092AB71
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollItem_Add10Sec_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollItem_Add10Sec_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035B3 RID: 13747
		// (get) Token: 0x0602075A RID: 132954 RVA: 0x0092C992 File Offset: 0x0092AB92
		// (set) Token: 0x0602075B RID: 132955 RVA: 0x0092C9A6 File Offset: 0x0092ABA6
		[Nullable(2)]
		public unsafe UChildActorComponent BP_EffectActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_Add10Sec_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_Add10Sec_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035B4 RID: 13748
		// (get) Token: 0x0602075C RID: 132956 RVA: 0x0092C9BB File Offset: 0x0092ABBB
		// (set) Token: 0x0602075D RID: 132957 RVA: 0x0092C9D0 File Offset: 0x0092ABD0
		public TSoftObjectPtr<EffectModelGroup> TimeGrabEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)BP_DollItem_Add10Sec_C.__PropertyOffset_2, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollItem_Add10Sec_C.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602075E RID: 132958 RVA: 0x0092C9F8 File Offset: 0x0092ABF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TogglePlayEffect(bool Enable)
		{
			BP_DollItem_Add10Sec_C.__TogglePlayEffect_FunctionParams* ptr = stackalloc BP_DollItem_Add10Sec_C.__TogglePlayEffect_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_DollItem_Add10Sec_C.__TogglePlayEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_Add10Sec_C.__TogglePlayEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add10Sec_C.__TogglePlayEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602075F RID: 132959 RVA: 0x0092CA3E File Offset: 0x0092AC3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add10Sec_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020760 RID: 132960 RVA: 0x0092CA52 File Offset: 0x0092AC52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_Add10Sec_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020761 RID: 132961 RVA: 0x0092CA68 File Offset: 0x0092AC68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void SetVisible(bool ToggleVisibility, bool TogglePhysics)
		{
			BP_DollItem_Add10Sec_C.__SetVisible_FunctionParams* ptr = stackalloc BP_DollItem_Add10Sec_C.__SetVisible_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_DollItem_Add10Sec_C.__SetVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_Add10Sec_C.__SetVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ToggleVisibility = ToggleVisibility;
			ptr->TogglePhysics = TogglePhysics;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add10Sec_C.__SetVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020762 RID: 132962 RVA: 0x0092CAB5 File Offset: 0x0092ACB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void PlayTimeEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_Add10Sec_C.__PlayTimeEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06020763 RID: 132963 RVA: 0x0092CACC File Offset: 0x0092ACCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollItem_Add10Sec(int EntryPoint)
		{
			BP_DollItem_Add10Sec_C.__ExecuteUbergraph_BP_DollItem_Add10Sec_FunctionParams* ptr = stackalloc BP_DollItem_Add10Sec_C.__ExecuteUbergraph_BP_DollItem_Add10Sec_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_DollItem_Add10Sec_C.__ExecuteUbergraph_BP_DollItem_Add10Sec_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_Add10Sec_C.__ExecuteUbergraph_BP_DollItem_Add10Sec_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_Add10Sec_C.__ExecuteUbergraph_BP_DollItem_Add10Sec_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020764 RID: 132964 RVA: 0x0092CB16 File Offset: 0x0092AD16
		protected BP_DollItem_Add10Sec_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401038E RID: 66446
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_Add10Sec.BP_DollItem_Add10Sec_C";

		// Token: 0x0401038F RID: 66447
		private static IntPtr _ClassPtr;

		// Token: 0x04010390 RID: 66448
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010391 RID: 66449
		internal new static int __PropertyOffset_0;

		// Token: 0x04010392 RID: 66450
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010393 RID: 66451
		internal new static int __PropertyOffset_1;

		// Token: 0x04010394 RID: 66452
		internal new static int __PropertyOffset_2;

		// Token: 0x04010395 RID: 66453
		private static IntPtr __TogglePlayEffect_NativeFunctionPtr;

		// Token: 0x04010396 RID: 66454
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010397 RID: 66455
		private static IntPtr __SetVisible_NativeFunctionPtr;

		// Token: 0x04010398 RID: 66456
		private static IntPtr __PlayTimeEffect_NativeFunctionPtr;

		// Token: 0x04010399 RID: 66457
		private static IntPtr __ExecuteUbergraph_BP_DollItem_Add10Sec_NativeFunctionPtr;

		// Token: 0x020099B6 RID: 39350
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __TogglePlayEffect_FunctionParams
		{
			// Token: 0x04032056 RID: 204886
			[FieldOffset(0)]
			public bool Enable;
		}

		// Token: 0x020099B7 RID: 39351
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected new ref struct __SetVisible_FunctionParams
		{
			// Token: 0x04032057 RID: 204887
			[FieldOffset(0)]
			public bool ToggleVisibility;

			// Token: 0x04032058 RID: 204888
			[FieldOffset(1)]
			public bool TogglePhysics;
		}

		// Token: 0x020099B8 RID: 39352
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __ExecuteUbergraph_BP_DollItem_Add10Sec_FunctionParams
		{
			// Token: 0x04032059 RID: 204889
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
