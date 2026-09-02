using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CED RID: 15597
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_CommonFluidSim_3_6.BP_CommonFluidSim_3_6_C")]
	[UnrealStructLayout(1576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1576)]
	public class BP_CommonFluidSim_3_6_C : BP_CommonFluidSim_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025409 RID: 152585 RVA: 0x009B54BA File Offset: 0x009B36BA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CommonFluidSim_3_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_CommonFluidSim_3_6.BP_CommonFluidSim_3_6_C");
			}
			return BP_CommonFluidSim_3_6_C._ClassPtr;
		}

		// Token: 0x0602540A RID: 152586 RVA: 0x009B54E0 File Offset: 0x009B36E0
		public BP_CommonFluidSim_3_6_C() : this(BuiltinUtils.AllocNativeUObject(BP_CommonFluidSim_3_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602540B RID: 152587 RVA: 0x009B5508 File Offset: 0x009B3708
		[NullableContext(1)]
		public BP_CommonFluidSim_3_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CommonFluidSim_3_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700506F RID: 20591
		// (get) Token: 0x0602540C RID: 152588 RVA: 0x009B553C File Offset: 0x009B373C
		// (set) Token: 0x0602540D RID: 152589 RVA: 0x009B5575 File Offset: 0x009B3775
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005070 RID: 20592
		// (get) Token: 0x0602540E RID: 152590 RVA: 0x009B5596 File Offset: 0x009B3796
		// (set) Token: 0x0602540F RID: 152591 RVA: 0x009B55AA File Offset: 0x009B37AA
		public unsafe FVector PlayerPrevUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005071 RID: 20593
		// (get) Token: 0x06025410 RID: 152592 RVA: 0x009B55BF File Offset: 0x009B37BF
		// (set) Token: 0x06025411 RID: 152593 RVA: 0x009B55D3 File Offset: 0x009B37D3
		public unsafe UMaterialInstanceDynamic AddPointsMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_3_6_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_3_6_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005072 RID: 20594
		// (get) Token: 0x06025412 RID: 152594 RVA: 0x009B55E8 File Offset: 0x009B37E8
		// (set) Token: 0x06025413 RID: 152595 RVA: 0x009B55FC File Offset: 0x009B37FC
		public unsafe FVectorDouble CurrPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005073 RID: 20595
		// (get) Token: 0x06025414 RID: 152596 RVA: 0x009B5611 File Offset: 0x009B3811
		// (set) Token: 0x06025415 RID: 152597 RVA: 0x009B5625 File Offset: 0x009B3825
		public unsafe BP_SceneBattleInteract_C Config
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_3_6_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_3_6_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005074 RID: 20596
		// (get) Token: 0x06025416 RID: 152598 RVA: 0x009B563A File Offset: 0x009B383A
		// (set) Token: 0x06025417 RID: 152599 RVA: 0x009B564A File Offset: 0x009B384A
		public unsafe float WeaponInteractRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005075 RID: 20597
		// (get) Token: 0x06025418 RID: 152600 RVA: 0x009B565B File Offset: 0x009B385B
		// (set) Token: 0x06025419 RID: 152601 RVA: 0x009B566B File Offset: 0x009B386B
		public unsafe float captureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005076 RID: 20598
		// (get) Token: 0x0602541A RID: 152602 RVA: 0x009B567C File Offset: 0x009B387C
		// (set) Token: 0x0602541B RID: 152603 RVA: 0x009B5690 File Offset: 0x009B3890
		public unsafe FVectorDouble PrevPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005077 RID: 20599
		// (get) Token: 0x0602541C RID: 152604 RVA: 0x009B56A5 File Offset: 0x009B38A5
		// (set) Token: 0x0602541D RID: 152605 RVA: 0x009B56B9 File Offset: 0x009B38B9
		public unsafe UTextureRenderTarget2D PointRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_3_6_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonFluidSim_3_6_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005078 RID: 20600
		// (get) Token: 0x0602541E RID: 152606 RVA: 0x009B56CE File Offset: 0x009B38CE
		// (set) Token: 0x0602541F RID: 152607 RVA: 0x009B56DE File Offset: 0x009B38DE
		public unsafe bool bUsingWeapon
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005079 RID: 20601
		// (get) Token: 0x06025420 RID: 152608 RVA: 0x009B56EF File Offset: 0x009B38EF
		// (set) Token: 0x06025421 RID: 152609 RVA: 0x009B56FF File Offset: 0x009B38FF
		public unsafe bool bCleared
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700507A RID: 20602
		// (get) Token: 0x06025422 RID: 152610 RVA: 0x009B5710 File Offset: 0x009B3910
		// (set) Token: 0x06025423 RID: 152611 RVA: 0x009B5720 File Offset: 0x009B3920
		public unsafe double WeaponMaxHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700507B RID: 20603
		// (get) Token: 0x06025424 RID: 152612 RVA: 0x009B5731 File Offset: 0x009B3931
		// (set) Token: 0x06025425 RID: 152613 RVA: 0x009B5741 File Offset: 0x009B3941
		public unsafe bool bPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700507C RID: 20604
		// (get) Token: 0x06025426 RID: 152614 RVA: 0x009B5752 File Offset: 0x009B3952
		// (set) Token: 0x06025427 RID: 152615 RVA: 0x009B5762 File Offset: 0x009B3962
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700507D RID: 20605
		// (get) Token: 0x06025428 RID: 152616 RVA: 0x009B5773 File Offset: 0x009B3973
		// (set) Token: 0x06025429 RID: 152617 RVA: 0x009B5787 File Offset: 0x009B3987
		public unsafe FVectorDouble LastPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700507E RID: 20606
		// (get) Token: 0x0602542A RID: 152618 RVA: 0x009B579C File Offset: 0x009B399C
		// (set) Token: 0x0602542B RID: 152619 RVA: 0x009B57B0 File Offset: 0x009B39B0
		public unsafe FVectorDouble tempPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CommonFluidSim_3_6_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x0602542C RID: 152620 RVA: 0x009B57C8 File Offset: 0x009B39C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble RTCenter, FVectorDouble WeaponPointLocation, float CaptureSize, ref FVector TexCoord)
		{
			BP_CommonFluidSim_3_6_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_CommonFluidSim_3_6_C.__CalcTexCoord_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_CommonFluidSim_3_6_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_3_6_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RTCenter = RTCenter;
			ptr->WeaponPointLocation = WeaponPointLocation;
			ptr->CaptureSize = CaptureSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x0602542D RID: 152621 RVA: 0x009B5839 File Offset: 0x009B3A39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void CheckSimEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__CheckSimEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0602542E RID: 152622 RVA: 0x009B584D File Offset: 0x009B3A4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602542F RID: 152623 RVA: 0x009B5861 File Offset: 0x009B3A61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025430 RID: 152624 RVA: 0x009B5878 File Offset: 0x009B3A78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CommonFluidSim_3_6_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CommonFluidSim_3_6_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CommonFluidSim_3_6_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_3_6_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025431 RID: 152625 RVA: 0x009B58C0 File Offset: 0x009B3AC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CommonFluidSim_3_6_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CommonFluidSim_3_6_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CommonFluidSim_3_6_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_3_6_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025432 RID: 152626 RVA: 0x009B5908 File Offset: 0x009B3B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteract(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_CommonFluidSim_3_6_C.__OnWeaponInteract_FunctionParams* ptr = stackalloc BP_CommonFluidSim_3_6_C.__OnWeaponInteract_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CommonFluidSim_3_6_C.__OnWeaponInteract_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_3_6_C.__OnWeaponInteract_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__OnWeaponInteract_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025433 RID: 152627 RVA: 0x009B596B File Offset: 0x009B3B6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear_RT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__Clear_RT_NativeFunctionPtr, null);
		}

		// Token: 0x06025434 RID: 152628 RVA: 0x009B5980 File Offset: 0x009B3B80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CommonFluidSim_3_6(int EntryPoint)
		{
			BP_CommonFluidSim_3_6_C.__ExecuteUbergraph_BP_CommonFluidSim_3_6_FunctionParams* ptr = stackalloc BP_CommonFluidSim_3_6_C.__ExecuteUbergraph_BP_CommonFluidSim_3_6_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_CommonFluidSim_3_6_C.__ExecuteUbergraph_BP_CommonFluidSim_3_6_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CommonFluidSim_3_6_C.__ExecuteUbergraph_BP_CommonFluidSim_3_6_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CommonFluidSim_3_6_C.__ExecuteUbergraph_BP_CommonFluidSim_3_6_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025435 RID: 152629 RVA: 0x009B59CA File Offset: 0x009B3BCA
		protected BP_CommonFluidSim_3_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013308 RID: 78600
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/BP_CommonFluidSim_3_6.BP_CommonFluidSim_3_6_C";

		// Token: 0x04013309 RID: 78601
		private static IntPtr _ClassPtr;

		// Token: 0x0401330A RID: 78602
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401330B RID: 78603
		internal new static int __PropertyOffset_0;

		// Token: 0x0401330C RID: 78604
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401330D RID: 78605
		internal new static int __PropertyOffset_1;

		// Token: 0x0401330E RID: 78606
		internal new static int __PropertyOffset_2;

		// Token: 0x0401330F RID: 78607
		internal new static int __PropertyOffset_3;

		// Token: 0x04013310 RID: 78608
		internal new static int __PropertyOffset_4;

		// Token: 0x04013311 RID: 78609
		internal new static int __PropertyOffset_5;

		// Token: 0x04013312 RID: 78610
		internal new static int __PropertyOffset_6;

		// Token: 0x04013313 RID: 78611
		internal new static int __PropertyOffset_7;

		// Token: 0x04013314 RID: 78612
		internal new static int __PropertyOffset_8;

		// Token: 0x04013315 RID: 78613
		internal new static int __PropertyOffset_9;

		// Token: 0x04013316 RID: 78614
		internal new static int __PropertyOffset_10;

		// Token: 0x04013317 RID: 78615
		internal new static int __PropertyOffset_11;

		// Token: 0x04013318 RID: 78616
		internal static int __PropertyOffset_12;

		// Token: 0x04013319 RID: 78617
		internal static int __PropertyOffset_13;

		// Token: 0x0401331A RID: 78618
		internal static int __PropertyOffset_14;

		// Token: 0x0401331B RID: 78619
		internal static int __PropertyOffset_15;

		// Token: 0x0401331C RID: 78620
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x0401331D RID: 78621
		private static IntPtr __CheckSimEnable_NativeFunctionPtr;

		// Token: 0x0401331E RID: 78622
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401331F RID: 78623
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013320 RID: 78624
		private static IntPtr __OnWeaponInteract_NativeFunctionPtr;

		// Token: 0x04013321 RID: 78625
		private static IntPtr __Clear_RT_NativeFunctionPtr;

		// Token: 0x04013322 RID: 78626
		private static IntPtr __ExecuteUbergraph_BP_CommonFluidSim_3_6_NativeFunctionPtr;

		// Token: 0x02009EEC RID: 40684
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x040329DC RID: 207324
			[FieldOffset(0)]
			public FVectorDouble RTCenter;

			// Token: 0x040329DD RID: 207325
			[FieldOffset(24)]
			public FVectorDouble WeaponPointLocation;

			// Token: 0x040329DE RID: 207326
			[FieldOffset(48)]
			public float CaptureSize;

			// Token: 0x040329DF RID: 207327
			[FieldOffset(52)]
			public FVector TexCoord;
		}

		// Token: 0x02009EED RID: 40685
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329E0 RID: 207328
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EEE RID: 40686
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteract_FunctionParams
		{
			// Token: 0x040329E1 RID: 207329
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040329E2 RID: 207330
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040329E3 RID: 207331
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009EEF RID: 40687
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __ExecuteUbergraph_BP_CommonFluidSim_3_6_FunctionParams
		{
			// Token: 0x040329E4 RID: 207332
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
