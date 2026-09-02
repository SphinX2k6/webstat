using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B0A RID: 15114
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_FuDai.BP_DollItem_FuDai_C")]
	[UnrealStructLayout(1656, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1656)]
	public class BP_DollItem_FuDai_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060207A9 RID: 133033 RVA: 0x0092D330 File Offset: 0x0092B530
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_FuDai_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_FuDai.BP_DollItem_FuDai_C");
			}
			return BP_DollItem_FuDai_C._ClassPtr;
		}

		// Token: 0x060207AA RID: 133034 RVA: 0x0092D354 File Offset: 0x0092B554
		public BP_DollItem_FuDai_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_FuDai_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060207AB RID: 133035 RVA: 0x0092D37C File Offset: 0x0092B57C
		[NullableContext(1)]
		public BP_DollItem_FuDai_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_FuDai_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035C9 RID: 13769
		// (get) Token: 0x060207AC RID: 133036 RVA: 0x0092D3B0 File Offset: 0x0092B5B0
		// (set) Token: 0x060207AD RID: 133037 RVA: 0x0092D3E9 File Offset: 0x0092B5E9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035CA RID: 13770
		// (get) Token: 0x060207AE RID: 133038 RVA: 0x0092D40A File Offset: 0x0092B60A
		// (set) Token: 0x060207AF RID: 133039 RVA: 0x0092D41E File Offset: 0x0092B61E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035CB RID: 13771
		// (get) Token: 0x060207B0 RID: 133040 RVA: 0x0092D433 File Offset: 0x0092B633
		// (set) Token: 0x060207B1 RID: 133041 RVA: 0x0092D447 File Offset: 0x0092B647
		public unsafe UNiagaraComponent NS_Fx_Sl2_MZ_FuDai_02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170035CC RID: 13772
		// (get) Token: 0x060207B2 RID: 133042 RVA: 0x0092D45C File Offset: 0x0092B65C
		// (set) Token: 0x060207B3 RID: 133043 RVA: 0x0092D470 File Offset: 0x0092B670
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170035CD RID: 13773
		// (get) Token: 0x060207B4 RID: 133044 RVA: 0x0092D485 File Offset: 0x0092B685
		// (set) Token: 0x060207B5 RID: 133045 RVA: 0x0092D499 File Offset: 0x0092B699
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170035CE RID: 13774
		// (get) Token: 0x060207B6 RID: 133046 RVA: 0x0092D4AE File Offset: 0x0092B6AE
		// (set) Token: 0x060207B7 RID: 133047 RVA: 0x0092D4BE File Offset: 0x0092B6BE
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170035CF RID: 13775
		// (get) Token: 0x060207B8 RID: 133048 RVA: 0x0092D4CF File Offset: 0x0092B6CF
		// (set) Token: 0x060207B9 RID: 133049 RVA: 0x0092D4E3 File Offset: 0x0092B6E3
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170035D0 RID: 13776
		// (get) Token: 0x060207BA RID: 133050 RVA: 0x0092D4F8 File Offset: 0x0092B6F8
		// (set) Token: 0x060207BB RID: 133051 RVA: 0x0092D508 File Offset: 0x0092B708
		public unsafe float Tightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170035D1 RID: 13777
		// (get) Token: 0x060207BC RID: 133052 RVA: 0x0092D519 File Offset: 0x0092B719
		// (set) Token: 0x060207BD RID: 133053 RVA: 0x0092D52D File Offset: 0x0092B72D
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170035D2 RID: 13778
		// (get) Token: 0x060207BE RID: 133054 RVA: 0x0092D542 File Offset: 0x0092B742
		// (set) Token: 0x060207BF RID: 133055 RVA: 0x0092D556 File Offset: 0x0092B756
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170035D3 RID: 13779
		// (get) Token: 0x060207C0 RID: 133056 RVA: 0x0092D56B File Offset: 0x0092B76B
		// (set) Token: 0x060207C1 RID: 133057 RVA: 0x0092D57B File Offset: 0x0092B77B
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170035D4 RID: 13780
		// (get) Token: 0x060207C2 RID: 133058 RVA: 0x0092D58C File Offset: 0x0092B78C
		// (set) Token: 0x060207C3 RID: 133059 RVA: 0x0092D59C File Offset: 0x0092B79C
		public unsafe float fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollItem_FuDai_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170035D5 RID: 13781
		// (get) Token: 0x060207C4 RID: 133060 RVA: 0x0092D5AD File Offset: 0x0092B7AD
		// (set) Token: 0x060207C5 RID: 133061 RVA: 0x0092D5C1 File Offset: 0x0092B7C1
		public unsafe UMaterialInstance InputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170035D6 RID: 13782
		// (get) Token: 0x060207C6 RID: 133062 RVA: 0x0092D5D6 File Offset: 0x0092B7D6
		// (set) Token: 0x060207C7 RID: 133063 RVA: 0x0092D5EA File Offset: 0x0092B7EA
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170035D7 RID: 13783
		// (get) Token: 0x060207C8 RID: 133064 RVA: 0x0092D5FF File Offset: 0x0092B7FF
		// (set) Token: 0x060207C9 RID: 133065 RVA: 0x0092D613 File Offset: 0x0092B813
		public unsafe UMaterialInstanceDynamic Dmaterial_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170035D8 RID: 13784
		// (get) Token: 0x060207CA RID: 133066 RVA: 0x0092D628 File Offset: 0x0092B828
		// (set) Token: 0x060207CB RID: 133067 RVA: 0x0092D63C File Offset: 0x0092B83C
		public unsafe UMaterialInstance InputMaterial_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x060207CC RID: 133068 RVA: 0x0092D651 File Offset: 0x0092B851
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_FuDai_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060207CD RID: 133069 RVA: 0x0092D665 File Offset: 0x0092B865
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_FuDai_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060207CE RID: 133070 RVA: 0x0092D67A File Offset: 0x0092B87A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_FuDai_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060207CF RID: 133071 RVA: 0x0092D68E File Offset: 0x0092B88E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_FuDai_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060207D0 RID: 133072 RVA: 0x0092D6A4 File Offset: 0x0092B8A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DollItem_FuDai_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DollItem_FuDai_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DollItem_FuDai_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_FuDai_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_FuDai_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060207D1 RID: 133073 RVA: 0x0092D6EC File Offset: 0x0092B8EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DollItem_FuDai_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DollItem_FuDai_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DollItem_FuDai_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_FuDai_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_FuDai_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060207D2 RID: 133074 RVA: 0x0092D734 File Offset: 0x0092B934
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollItem_FuDai(int EntryPoint)
		{
			BP_DollItem_FuDai_C.__ExecuteUbergraph_BP_DollItem_FuDai_FunctionParams* ptr = stackalloc BP_DollItem_FuDai_C.__ExecuteUbergraph_BP_DollItem_FuDai_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_DollItem_FuDai_C.__ExecuteUbergraph_BP_DollItem_FuDai_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_FuDai_C.__ExecuteUbergraph_BP_DollItem_FuDai_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_FuDai_C.__ExecuteUbergraph_BP_DollItem_FuDai_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060207D3 RID: 133075 RVA: 0x0092D77B File Offset: 0x0092B97B
		protected BP_DollItem_FuDai_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103C5 RID: 66501
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_FuDai.BP_DollItem_FuDai_C";

		// Token: 0x040103C6 RID: 66502
		private static IntPtr _ClassPtr;

		// Token: 0x040103C7 RID: 66503
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103C8 RID: 66504
		internal new static int __PropertyOffset_0;

		// Token: 0x040103C9 RID: 66505
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040103CA RID: 66506
		internal new static int __PropertyOffset_1;

		// Token: 0x040103CB RID: 66507
		internal new static int __PropertyOffset_2;

		// Token: 0x040103CC RID: 66508
		internal new static int __PropertyOffset_3;

		// Token: 0x040103CD RID: 66509
		internal new static int __PropertyOffset_4;

		// Token: 0x040103CE RID: 66510
		internal new static int __PropertyOffset_5;

		// Token: 0x040103CF RID: 66511
		internal new static int __PropertyOffset_6;

		// Token: 0x040103D0 RID: 66512
		internal new static int __PropertyOffset_7;

		// Token: 0x040103D1 RID: 66513
		internal new static int __PropertyOffset_8;

		// Token: 0x040103D2 RID: 66514
		internal new static int __PropertyOffset_9;

		// Token: 0x040103D3 RID: 66515
		internal new static int __PropertyOffset_10;

		// Token: 0x040103D4 RID: 66516
		internal new static int __PropertyOffset_11;

		// Token: 0x040103D5 RID: 66517
		internal static int __PropertyOffset_12;

		// Token: 0x040103D6 RID: 66518
		internal static int __PropertyOffset_13;

		// Token: 0x040103D7 RID: 66519
		internal static int __PropertyOffset_14;

		// Token: 0x040103D8 RID: 66520
		internal static int __PropertyOffset_15;

		// Token: 0x040103D9 RID: 66521
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040103DA RID: 66522
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040103DB RID: 66523
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040103DC RID: 66524
		private static IntPtr __ExecuteUbergraph_BP_DollItem_FuDai_NativeFunctionPtr;

		// Token: 0x020099BF RID: 39359
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032061 RID: 204897
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099C0 RID: 39360
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_DollItem_FuDai_FunctionParams
		{
			// Token: 0x04032062 RID: 204898
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
