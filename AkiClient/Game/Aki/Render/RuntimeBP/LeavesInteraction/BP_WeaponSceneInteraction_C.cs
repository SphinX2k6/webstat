using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction
{
	// Token: 0x02003C66 RID: 15462
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_WeaponSceneInteraction.BP_WeaponSceneInteraction_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1428)]
	public class BP_WeaponSceneInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023CF8 RID: 146680 RVA: 0x0098CBB7 File Offset: 0x0098ADB7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeaponSceneInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_WeaponSceneInteraction.BP_WeaponSceneInteraction_C");
			}
			return BP_WeaponSceneInteraction_C._ClassPtr;
		}

		// Token: 0x06023CF9 RID: 146681 RVA: 0x0098CBDC File Offset: 0x0098ADDC
		public BP_WeaponSceneInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeaponSceneInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023CFA RID: 146682 RVA: 0x0098CC04 File Offset: 0x0098AE04
		[NullableContext(1)]
		public BP_WeaponSceneInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeaponSceneInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004876 RID: 18550
		// (get) Token: 0x06023CFB RID: 146683 RVA: 0x0098CC38 File Offset: 0x0098AE38
		// (set) Token: 0x06023CFC RID: 146684 RVA: 0x0098CC71 File Offset: 0x0098AE71
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004877 RID: 18551
		// (get) Token: 0x06023CFD RID: 146685 RVA: 0x0098CC92 File Offset: 0x0098AE92
		// (set) Token: 0x06023CFE RID: 146686 RVA: 0x0098CCA6 File Offset: 0x0098AEA6
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004878 RID: 18552
		// (get) Token: 0x06023CFF RID: 146687 RVA: 0x0098CCBB File Offset: 0x0098AEBB
		// (set) Token: 0x06023D00 RID: 146688 RVA: 0x0098CCCF File Offset: 0x0098AECF
		public unsafe BP_SceneBattleInteract_C Config
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004879 RID: 18553
		// (get) Token: 0x06023D01 RID: 146689 RVA: 0x0098CCE4 File Offset: 0x0098AEE4
		// (set) Token: 0x06023D02 RID: 146690 RVA: 0x0098CCF8 File Offset: 0x0098AEF8
		public unsafe UMaterialInstanceDynamic AddPointsMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700487A RID: 18554
		// (get) Token: 0x06023D03 RID: 146691 RVA: 0x0098CD0D File Offset: 0x0098AF0D
		// (set) Token: 0x06023D04 RID: 146692 RVA: 0x0098CD21 File Offset: 0x0098AF21
		public unsafe UTextureRenderTarget2D PointRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700487B RID: 18555
		// (get) Token: 0x06023D05 RID: 146693 RVA: 0x0098CD36 File Offset: 0x0098AF36
		// (set) Token: 0x06023D06 RID: 146694 RVA: 0x0098CD4A File Offset: 0x0098AF4A
		public unsafe FVectorDouble PrevPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700487C RID: 18556
		// (get) Token: 0x06023D07 RID: 146695 RVA: 0x0098CD5F File Offset: 0x0098AF5F
		// (set) Token: 0x06023D08 RID: 146696 RVA: 0x0098CD73 File Offset: 0x0098AF73
		public unsafe FVectorDouble CurrPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700487D RID: 18557
		// (get) Token: 0x06023D09 RID: 146697 RVA: 0x0098CD88 File Offset: 0x0098AF88
		// (set) Token: 0x06023D0A RID: 146698 RVA: 0x0098CD98 File Offset: 0x0098AF98
		public unsafe float captureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700487E RID: 18558
		// (get) Token: 0x06023D0B RID: 146699 RVA: 0x0098CDA9 File Offset: 0x0098AFA9
		// (set) Token: 0x06023D0C RID: 146700 RVA: 0x0098CDBD File Offset: 0x0098AFBD
		public unsafe UTextureRenderTarget2D ResultRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponSceneInteraction_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700487F RID: 18559
		// (get) Token: 0x06023D0D RID: 146701 RVA: 0x0098CDD2 File Offset: 0x0098AFD2
		// (set) Token: 0x06023D0E RID: 146702 RVA: 0x0098CDE2 File Offset: 0x0098AFE2
		public unsafe float PlayerSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004880 RID: 18560
		// (get) Token: 0x06023D0F RID: 146703 RVA: 0x0098CDF3 File Offset: 0x0098AFF3
		// (set) Token: 0x06023D10 RID: 146704 RVA: 0x0098CE07 File Offset: 0x0098B007
		public unsafe FVector PlayerPrevUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004881 RID: 18561
		// (get) Token: 0x06023D11 RID: 146705 RVA: 0x0098CE1C File Offset: 0x0098B01C
		// (set) Token: 0x06023D12 RID: 146706 RVA: 0x0098CE2C File Offset: 0x0098B02C
		public unsafe float WeaponInteractRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponSceneInteraction_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06023D13 RID: 146707 RVA: 0x0098CE40 File Offset: 0x0098B040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord(FVectorDouble RTCenter, FVectorDouble WeaponPointLocation, float CaptureSize, ref FVector TexCoord)
		{
			BP_WeaponSceneInteraction_C.__CalcTexCoord_FunctionParams* ptr = stackalloc BP_WeaponSceneInteraction_C.__CalcTexCoord_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_WeaponSceneInteraction_C.__CalcTexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponSceneInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RTCenter = RTCenter;
			ptr->WeaponPointLocation = WeaponPointLocation;
			ptr->CaptureSize = CaptureSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__CalcTexCoord_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x06023D14 RID: 146708 RVA: 0x0098CEB1 File Offset: 0x0098B0B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023D15 RID: 146709 RVA: 0x0098CEC5 File Offset: 0x0098B0C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023D16 RID: 146710 RVA: 0x0098CEDC File Offset: 0x0098B0DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WeaponSceneInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeaponSceneInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponSceneInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponSceneInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D17 RID: 146711 RVA: 0x0098CF24 File Offset: 0x0098B124
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WeaponSceneInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeaponSceneInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponSceneInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponSceneInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D18 RID: 146712 RVA: 0x0098CF6C File Offset: 0x0098B16C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteract(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_WeaponSceneInteraction_C.__OnWeaponInteract_FunctionParams* ptr = stackalloc BP_WeaponSceneInteraction_C.__OnWeaponInteract_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_WeaponSceneInteraction_C.__OnWeaponInteract_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponSceneInteraction_C.__OnWeaponInteract_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__OnWeaponInteract_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D19 RID: 146713 RVA: 0x0098CFCF File Offset: 0x0098B1CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear_RT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__Clear_RT_NativeFunctionPtr, null);
		}

		// Token: 0x06023D1A RID: 146714 RVA: 0x0098CFE4 File Offset: 0x0098B1E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WeaponSceneInteraction(int EntryPoint)
		{
			BP_WeaponSceneInteraction_C.__ExecuteUbergraph_BP_WeaponSceneInteraction_FunctionParams* ptr = stackalloc BP_WeaponSceneInteraction_C.__ExecuteUbergraph_BP_WeaponSceneInteraction_FunctionParams[(UIntPtr)511] + 15L / (long)sizeof(BP_WeaponSceneInteraction_C.__ExecuteUbergraph_BP_WeaponSceneInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponSceneInteraction_C.__ExecuteUbergraph_BP_WeaponSceneInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponSceneInteraction_C.__ExecuteUbergraph_BP_WeaponSceneInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D1B RID: 146715 RVA: 0x0098D02E File Offset: 0x0098B22E
		protected BP_WeaponSceneInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401247D RID: 74877
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_WeaponSceneInteraction.BP_WeaponSceneInteraction_C";

		// Token: 0x0401247E RID: 74878
		private static IntPtr _ClassPtr;

		// Token: 0x0401247F RID: 74879
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012480 RID: 74880
		internal static int __PropertyOffset_0;

		// Token: 0x04012481 RID: 74881
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012482 RID: 74882
		internal static int __PropertyOffset_1;

		// Token: 0x04012483 RID: 74883
		internal static int __PropertyOffset_2;

		// Token: 0x04012484 RID: 74884
		internal static int __PropertyOffset_3;

		// Token: 0x04012485 RID: 74885
		internal static int __PropertyOffset_4;

		// Token: 0x04012486 RID: 74886
		internal static int __PropertyOffset_5;

		// Token: 0x04012487 RID: 74887
		internal static int __PropertyOffset_6;

		// Token: 0x04012488 RID: 74888
		internal static int __PropertyOffset_7;

		// Token: 0x04012489 RID: 74889
		internal static int __PropertyOffset_8;

		// Token: 0x0401248A RID: 74890
		internal static int __PropertyOffset_9;

		// Token: 0x0401248B RID: 74891
		internal static int __PropertyOffset_10;

		// Token: 0x0401248C RID: 74892
		internal static int __PropertyOffset_11;

		// Token: 0x0401248D RID: 74893
		private static IntPtr __CalcTexCoord_NativeFunctionPtr;

		// Token: 0x0401248E RID: 74894
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401248F RID: 74895
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012490 RID: 74896
		private static IntPtr __OnWeaponInteract_NativeFunctionPtr;

		// Token: 0x04012491 RID: 74897
		private static IntPtr __Clear_RT_NativeFunctionPtr;

		// Token: 0x04012492 RID: 74898
		private static IntPtr __ExecuteUbergraph_BP_WeaponSceneInteraction_NativeFunctionPtr;

		// Token: 0x02009D46 RID: 40262
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __CalcTexCoord_FunctionParams
		{
			// Token: 0x04032722 RID: 206626
			[FieldOffset(0)]
			public FVectorDouble RTCenter;

			// Token: 0x04032723 RID: 206627
			[FieldOffset(24)]
			public FVectorDouble WeaponPointLocation;

			// Token: 0x04032724 RID: 206628
			[FieldOffset(48)]
			public float CaptureSize;

			// Token: 0x04032725 RID: 206629
			[FieldOffset(52)]
			public FVector TexCoord;
		}

		// Token: 0x02009D47 RID: 40263
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032726 RID: 206630
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D48 RID: 40264
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteract_FunctionParams
		{
			// Token: 0x04032727 RID: 206631
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032728 RID: 206632
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032729 RID: 206633
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D49 RID: 40265
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 496)]
		protected ref struct __ExecuteUbergraph_BP_WeaponSceneInteraction_FunctionParams
		{
			// Token: 0x0403272A RID: 206634
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
