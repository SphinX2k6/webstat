using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B09 RID: 15113
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_BeiBi_S.BP_DollItem_BeiBi_S_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class BP_DollItem_BeiBi_S_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020780 RID: 132992 RVA: 0x0092CF04 File Offset: 0x0092B104
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_BeiBi_S_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_BeiBi_S.BP_DollItem_BeiBi_S_C");
			}
			return BP_DollItem_BeiBi_S_C._ClassPtr;
		}

		// Token: 0x06020781 RID: 132993 RVA: 0x0092CF28 File Offset: 0x0092B128
		public BP_DollItem_BeiBi_S_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_BeiBi_S_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020782 RID: 132994 RVA: 0x0092CF50 File Offset: 0x0092B150
		[NullableContext(1)]
		public BP_DollItem_BeiBi_S_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_BeiBi_S_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035BA RID: 13754
		// (get) Token: 0x06020783 RID: 132995 RVA: 0x0092CF84 File Offset: 0x0092B184
		// (set) Token: 0x06020784 RID: 132996 RVA: 0x0092CFBD File Offset: 0x0092B1BD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035BB RID: 13755
		// (get) Token: 0x06020785 RID: 132997 RVA: 0x0092CFDE File Offset: 0x0092B1DE
		// (set) Token: 0x06020786 RID: 132998 RVA: 0x0092CFF2 File Offset: 0x0092B1F2
		public unsafe UNiagaraComponent NS_Fx_Sl2_MZ_BeiBi_01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035BC RID: 13756
		// (get) Token: 0x06020787 RID: 132999 RVA: 0x0092D007 File Offset: 0x0092B207
		// (set) Token: 0x06020788 RID: 133000 RVA: 0x0092D01B File Offset: 0x0092B21B
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170035BD RID: 13757
		// (get) Token: 0x06020789 RID: 133001 RVA: 0x0092D030 File Offset: 0x0092B230
		// (set) Token: 0x0602078A RID: 133002 RVA: 0x0092D044 File Offset: 0x0092B244
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170035BE RID: 13758
		// (get) Token: 0x0602078B RID: 133003 RVA: 0x0092D059 File Offset: 0x0092B259
		// (set) Token: 0x0602078C RID: 133004 RVA: 0x0092D069 File Offset: 0x0092B269
		public unsafe float fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170035BF RID: 13759
		// (get) Token: 0x0602078D RID: 133005 RVA: 0x0092D07A File Offset: 0x0092B27A
		// (set) Token: 0x0602078E RID: 133006 RVA: 0x0092D08A File Offset: 0x0092B28A
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170035C0 RID: 13760
		// (get) Token: 0x0602078F RID: 133007 RVA: 0x0092D09B File Offset: 0x0092B29B
		// (set) Token: 0x06020790 RID: 133008 RVA: 0x0092D0AF File Offset: 0x0092B2AF
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170035C1 RID: 13761
		// (get) Token: 0x06020791 RID: 133009 RVA: 0x0092D0C4 File Offset: 0x0092B2C4
		// (set) Token: 0x06020792 RID: 133010 RVA: 0x0092D0D4 File Offset: 0x0092B2D4
		public unsafe float Tightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170035C2 RID: 13762
		// (get) Token: 0x06020793 RID: 133011 RVA: 0x0092D0E5 File Offset: 0x0092B2E5
		// (set) Token: 0x06020794 RID: 133012 RVA: 0x0092D0F9 File Offset: 0x0092B2F9
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170035C3 RID: 13763
		// (get) Token: 0x06020795 RID: 133013 RVA: 0x0092D10E File Offset: 0x0092B30E
		// (set) Token: 0x06020796 RID: 133014 RVA: 0x0092D11E File Offset: 0x0092B31E
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_S_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170035C4 RID: 13764
		// (get) Token: 0x06020797 RID: 133015 RVA: 0x0092D12F File Offset: 0x0092B32F
		// (set) Token: 0x06020798 RID: 133016 RVA: 0x0092D143 File Offset: 0x0092B343
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170035C5 RID: 13765
		// (get) Token: 0x06020799 RID: 133017 RVA: 0x0092D158 File Offset: 0x0092B358
		// (set) Token: 0x0602079A RID: 133018 RVA: 0x0092D16C File Offset: 0x0092B36C
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170035C6 RID: 13766
		// (get) Token: 0x0602079B RID: 133019 RVA: 0x0092D181 File Offset: 0x0092B381
		// (set) Token: 0x0602079C RID: 133020 RVA: 0x0092D195 File Offset: 0x0092B395
		public unsafe UMaterialInstance InputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170035C7 RID: 13767
		// (get) Token: 0x0602079D RID: 133021 RVA: 0x0092D1AA File Offset: 0x0092B3AA
		// (set) Token: 0x0602079E RID: 133022 RVA: 0x0092D1BE File Offset: 0x0092B3BE
		public unsafe UMaterialInstanceDynamic Dmaterial_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170035C8 RID: 13768
		// (get) Token: 0x0602079F RID: 133023 RVA: 0x0092D1D3 File Offset: 0x0092B3D3
		// (set) Token: 0x060207A0 RID: 133024 RVA: 0x0092D1E7 File Offset: 0x0092B3E7
		public unsafe UMaterialInstance InputMaterial_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_S_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x060207A1 RID: 133025 RVA: 0x0092D1FC File Offset: 0x0092B3FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060207A2 RID: 133026 RVA: 0x0092D210 File Offset: 0x0092B410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060207A3 RID: 133027 RVA: 0x0092D228 File Offset: 0x0092B428
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DollItem_BeiBi_S_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DollItem_BeiBi_S_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DollItem_BeiBi_S_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_BeiBi_S_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060207A4 RID: 133028 RVA: 0x0092D270 File Offset: 0x0092B470
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DollItem_BeiBi_S_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DollItem_BeiBi_S_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DollItem_BeiBi_S_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_BeiBi_S_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060207A5 RID: 133029 RVA: 0x0092D2B7 File Offset: 0x0092B4B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060207A6 RID: 133030 RVA: 0x0092D2CB File Offset: 0x0092B4CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060207A7 RID: 133031 RVA: 0x0092D2E0 File Offset: 0x0092B4E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollItem_BeiBi_S(int EntryPoint)
		{
			BP_DollItem_BeiBi_S_C.__ExecuteUbergraph_BP_DollItem_BeiBi_S_FunctionParams* ptr = stackalloc BP_DollItem_BeiBi_S_C.__ExecuteUbergraph_BP_DollItem_BeiBi_S_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_DollItem_BeiBi_S_C.__ExecuteUbergraph_BP_DollItem_BeiBi_S_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_BeiBi_S_C.__ExecuteUbergraph_BP_DollItem_BeiBi_S_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_BeiBi_S_C.__ExecuteUbergraph_BP_DollItem_BeiBi_S_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060207A8 RID: 133032 RVA: 0x0092D327 File Offset: 0x0092B527
		protected BP_DollItem_BeiBi_S_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103AE RID: 66478
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_BeiBi_S.BP_DollItem_BeiBi_S_C";

		// Token: 0x040103AF RID: 66479
		private static IntPtr _ClassPtr;

		// Token: 0x040103B0 RID: 66480
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103B1 RID: 66481
		internal new static int __PropertyOffset_0;

		// Token: 0x040103B2 RID: 66482
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040103B3 RID: 66483
		internal new static int __PropertyOffset_1;

		// Token: 0x040103B4 RID: 66484
		internal new static int __PropertyOffset_2;

		// Token: 0x040103B5 RID: 66485
		internal new static int __PropertyOffset_3;

		// Token: 0x040103B6 RID: 66486
		internal new static int __PropertyOffset_4;

		// Token: 0x040103B7 RID: 66487
		internal new static int __PropertyOffset_5;

		// Token: 0x040103B8 RID: 66488
		internal new static int __PropertyOffset_6;

		// Token: 0x040103B9 RID: 66489
		internal new static int __PropertyOffset_7;

		// Token: 0x040103BA RID: 66490
		internal new static int __PropertyOffset_8;

		// Token: 0x040103BB RID: 66491
		internal new static int __PropertyOffset_9;

		// Token: 0x040103BC RID: 66492
		internal new static int __PropertyOffset_10;

		// Token: 0x040103BD RID: 66493
		internal new static int __PropertyOffset_11;

		// Token: 0x040103BE RID: 66494
		internal static int __PropertyOffset_12;

		// Token: 0x040103BF RID: 66495
		internal static int __PropertyOffset_13;

		// Token: 0x040103C0 RID: 66496
		internal static int __PropertyOffset_14;

		// Token: 0x040103C1 RID: 66497
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040103C2 RID: 66498
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040103C3 RID: 66499
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040103C4 RID: 66500
		private static IntPtr __ExecuteUbergraph_BP_DollItem_BeiBi_S_NativeFunctionPtr;

		// Token: 0x020099BD RID: 39357
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403205F RID: 204895
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099BE RID: 39358
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_DollItem_BeiBi_S_FunctionParams
		{
			// Token: 0x04032060 RID: 204896
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
