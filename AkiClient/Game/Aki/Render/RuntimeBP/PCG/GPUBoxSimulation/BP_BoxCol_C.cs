using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C22 RID: 15394
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_BoxCol.BP_BoxCol_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1645)]
	public class BP_BoxCol_C : AKuroCSRpbd, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060231B3 RID: 143795 RVA: 0x00978E1E File Offset: 0x0097701E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BoxCol_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_BoxCol.BP_BoxCol_C");
			}
			return BP_BoxCol_C._ClassPtr;
		}

		// Token: 0x060231B4 RID: 143796 RVA: 0x00978E44 File Offset: 0x00977044
		public BP_BoxCol_C() : this(BuiltinUtils.AllocNativeUObject(BP_BoxCol_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060231B5 RID: 143797 RVA: 0x00978E6C File Offset: 0x0097706C
		[NullableContext(1)]
		public BP_BoxCol_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BoxCol_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700446B RID: 17515
		// (get) Token: 0x060231B6 RID: 143798 RVA: 0x00978EA0 File Offset: 0x009770A0
		// (set) Token: 0x060231B7 RID: 143799 RVA: 0x00978ED9 File Offset: 0x009770D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700446C RID: 17516
		// (get) Token: 0x060231B8 RID: 143800 RVA: 0x00978EFA File Offset: 0x009770FA
		// (set) Token: 0x060231B9 RID: 143801 RVA: 0x00978F0E File Offset: 0x0097710E
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700446D RID: 17517
		// (get) Token: 0x060231BA RID: 143802 RVA: 0x00978F23 File Offset: 0x00977123
		// (set) Token: 0x060231BB RID: 143803 RVA: 0x00978F37 File Offset: 0x00977137
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700446E RID: 17518
		// (get) Token: 0x060231BC RID: 143804 RVA: 0x00978F4C File Offset: 0x0097714C
		// (set) Token: 0x060231BD RID: 143805 RVA: 0x00978F60 File Offset: 0x00977160
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700446F RID: 17519
		// (get) Token: 0x060231BE RID: 143806 RVA: 0x00978F75 File Offset: 0x00977175
		// (set) Token: 0x060231BF RID: 143807 RVA: 0x00978F89 File Offset: 0x00977189
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004470 RID: 17520
		// (get) Token: 0x060231C0 RID: 143808 RVA: 0x00978F9E File Offset: 0x0097719E
		// (set) Token: 0x060231C1 RID: 143809 RVA: 0x00978FB2 File Offset: 0x009771B2
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004471 RID: 17521
		// (get) Token: 0x060231C2 RID: 143810 RVA: 0x00978FC7 File Offset: 0x009771C7
		// (set) Token: 0x060231C3 RID: 143811 RVA: 0x00978FD7 File Offset: 0x009771D7
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004472 RID: 17522
		// (get) Token: 0x060231C4 RID: 143812 RVA: 0x00978FE8 File Offset: 0x009771E8
		// (set) Token: 0x060231C5 RID: 143813 RVA: 0x00978FFC File Offset: 0x009771FC
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004473 RID: 17523
		// (get) Token: 0x060231C6 RID: 143814 RVA: 0x00979011 File Offset: 0x00977211
		// (set) Token: 0x060231C7 RID: 143815 RVA: 0x00979021 File Offset: 0x00977221
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004474 RID: 17524
		// (get) Token: 0x060231C8 RID: 143816 RVA: 0x00979032 File Offset: 0x00977232
		// (set) Token: 0x060231C9 RID: 143817 RVA: 0x00979042 File Offset: 0x00977242
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004475 RID: 17525
		// (get) Token: 0x060231CA RID: 143818 RVA: 0x00979053 File Offset: 0x00977253
		// (set) Token: 0x060231CB RID: 143819 RVA: 0x00979063 File Offset: 0x00977263
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004476 RID: 17526
		// (get) Token: 0x060231CC RID: 143820 RVA: 0x00979074 File Offset: 0x00977274
		// (set) Token: 0x060231CD RID: 143821 RVA: 0x00979084 File Offset: 0x00977284
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004477 RID: 17527
		// (get) Token: 0x060231CE RID: 143822 RVA: 0x00979095 File Offset: 0x00977295
		// (set) Token: 0x060231CF RID: 143823 RVA: 0x009790A5 File Offset: 0x009772A5
		public unsafe bool editorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004478 RID: 17528
		// (get) Token: 0x060231D0 RID: 143824 RVA: 0x009790B6 File Offset: 0x009772B6
		// (set) Token: 0x060231D1 RID: 143825 RVA: 0x009790C6 File Offset: 0x009772C6
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004479 RID: 17529
		// (get) Token: 0x060231D2 RID: 143826 RVA: 0x009790D7 File Offset: 0x009772D7
		// (set) Token: 0x060231D3 RID: 143827 RVA: 0x009790E7 File Offset: 0x009772E7
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700447A RID: 17530
		// (get) Token: 0x060231D4 RID: 143828 RVA: 0x009790F8 File Offset: 0x009772F8
		// (set) Token: 0x060231D5 RID: 143829 RVA: 0x00979108 File Offset: 0x00977308
		public unsafe bool ReadDataInBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700447B RID: 17531
		// (get) Token: 0x060231D6 RID: 143830 RVA: 0x00979119 File Offset: 0x00977319
		// (set) Token: 0x060231D7 RID: 143831 RVA: 0x0097912D File Offset: 0x0097732D
		public unsafe UStaticMesh inputStaticMesh_ForBPL_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700447C RID: 17532
		// (get) Token: 0x060231D8 RID: 143832 RVA: 0x00979142 File Offset: 0x00977342
		// (set) Token: 0x060231D9 RID: 143833 RVA: 0x00979152 File Offset: 0x00977352
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700447D RID: 17533
		// (get) Token: 0x060231DA RID: 143834 RVA: 0x00979163 File Offset: 0x00977363
		// (set) Token: 0x060231DB RID: 143835 RVA: 0x00979177 File Offset: 0x00977377
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700447E RID: 17534
		// (get) Token: 0x060231DC RID: 143836 RVA: 0x0097918C File Offset: 0x0097738C
		// (set) Token: 0x060231DD RID: 143837 RVA: 0x009791A0 File Offset: 0x009773A0
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BoxCol_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700447F RID: 17535
		// (get) Token: 0x060231DE RID: 143838 RVA: 0x009791B5 File Offset: 0x009773B5
		// (set) Token: 0x060231DF RID: 143839 RVA: 0x009791C5 File Offset: 0x009773C5
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004480 RID: 17536
		// (get) Token: 0x060231E0 RID: 143840 RVA: 0x009791D6 File Offset: 0x009773D6
		// (set) Token: 0x060231E1 RID: 143841 RVA: 0x009791E6 File Offset: 0x009773E6
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004481 RID: 17537
		// (get) Token: 0x060231E2 RID: 143842 RVA: 0x009791F7 File Offset: 0x009773F7
		// (set) Token: 0x060231E3 RID: 143843 RVA: 0x00979207 File Offset: 0x00977407
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004482 RID: 17538
		// (get) Token: 0x060231E4 RID: 143844 RVA: 0x00979218 File Offset: 0x00977418
		// (set) Token: 0x060231E5 RID: 143845 RVA: 0x0097922C File Offset: 0x0097742C
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004483 RID: 17539
		// (get) Token: 0x060231E6 RID: 143846 RVA: 0x00979241 File Offset: 0x00977441
		// (set) Token: 0x060231E7 RID: 143847 RVA: 0x00979255 File Offset: 0x00977455
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004484 RID: 17540
		// (get) Token: 0x060231E8 RID: 143848 RVA: 0x0097926A File Offset: 0x0097746A
		// (set) Token: 0x060231E9 RID: 143849 RVA: 0x0097927A File Offset: 0x0097747A
		public unsafe bool alreadyBuildArr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004485 RID: 17541
		// (get) Token: 0x060231EA RID: 143850 RVA: 0x0097928B File Offset: 0x0097748B
		// (set) Token: 0x060231EB RID: 143851 RVA: 0x0097929B File Offset: 0x0097749B
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004486 RID: 17542
		// (get) Token: 0x060231EC RID: 143852 RVA: 0x009792AC File Offset: 0x009774AC
		// (set) Token: 0x060231ED RID: 143853 RVA: 0x009792BC File Offset: 0x009774BC
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004487 RID: 17543
		// (get) Token: 0x060231EE RID: 143854 RVA: 0x009792CD File Offset: 0x009774CD
		// (set) Token: 0x060231EF RID: 143855 RVA: 0x009792DD File Offset: 0x009774DD
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004488 RID: 17544
		// (get) Token: 0x060231F0 RID: 143856 RVA: 0x009792EE File Offset: 0x009774EE
		// (set) Token: 0x060231F1 RID: 143857 RVA: 0x009792FE File Offset: 0x009774FE
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BoxCol_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x060231F2 RID: 143858 RVA: 0x0097930F File Offset: 0x0097750F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060231F3 RID: 143859 RVA: 0x00979323 File Offset: 0x00977523
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060231F4 RID: 143860 RVA: 0x00979338 File Offset: 0x00977538
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060231F5 RID: 143861 RVA: 0x0097934C File Offset: 0x0097754C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060231F6 RID: 143862 RVA: 0x00979364 File Offset: 0x00977564
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BoxCol_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BoxCol_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BoxCol_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060231F7 RID: 143863 RVA: 0x009793AC File Offset: 0x009775AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BoxCol_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BoxCol_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BoxCol_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060231F8 RID: 143864 RVA: 0x009793F4 File Offset: 0x009775F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_BoxCol_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_BoxCol_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BoxCol_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060231F9 RID: 143865 RVA: 0x00979440 File Offset: 0x00977640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_BoxCol_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_BoxCol_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BoxCol_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060231FA RID: 143866 RVA: 0x0097948C File Offset: 0x0097768C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_BoxCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BoxCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BoxCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060231FB RID: 143867 RVA: 0x00979540 File Offset: 0x00977740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060231FC RID: 143868 RVA: 0x009795FC File Offset: 0x009777FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060231FD RID: 143869 RVA: 0x00979688 File Offset: 0x00977888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_BoxCol_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_BoxCol_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BoxCol_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060231FE RID: 143870 RVA: 0x009796EB File Offset: 0x009778EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OpenPhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__OpenPhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x060231FF RID: 143871 RVA: 0x009796FF File Offset: 0x009778FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OpenPhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__OpenPhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023200 RID: 143872 RVA: 0x00979714 File Offset: 0x00977914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ClosePhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__ClosePhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x06023201 RID: 143873 RVA: 0x00979728 File Offset: 0x00977928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ClosePhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__ClosePhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023202 RID: 143874 RVA: 0x00979740 File Offset: 0x00977940
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnApplyWorldOffset(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_BoxCol_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_BoxCol_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_BoxCol_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023203 RID: 143875 RVA: 0x00979794 File Offset: 0x00977994
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnApplyWorldOffset_Implementation(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_BoxCol_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_BoxCol_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_BoxCol_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023204 RID: 143876 RVA: 0x009797E8 File Offset: 0x009779E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void AfterTick(float DeltaSeconds)
		{
			BP_BoxCol_C.__AfterTick_FunctionParams* ptr = stackalloc BP_BoxCol_C.__AfterTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BoxCol_C.__AfterTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__AfterTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BoxCol_C.__AfterTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023205 RID: 143877 RVA: 0x00979830 File Offset: 0x00977A30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void AfterTick_Implementation(float DeltaSeconds)
		{
			BP_BoxCol_C.__AfterTick_FunctionParams* ptr = stackalloc BP_BoxCol_C.__AfterTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BoxCol_C.__AfterTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__AfterTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__AfterTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023206 RID: 143878 RVA: 0x00979878 File Offset: 0x00977A78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BoxCol(int EntryPoint)
		{
			BP_BoxCol_C.__ExecuteUbergraph_BP_BoxCol_FunctionParams* ptr = stackalloc BP_BoxCol_C.__ExecuteUbergraph_BP_BoxCol_FunctionParams[(UIntPtr)2511] + 15L / (long)sizeof(BP_BoxCol_C.__ExecuteUbergraph_BP_BoxCol_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BoxCol_C.__ExecuteUbergraph_BP_BoxCol_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BoxCol_C.__ExecuteUbergraph_BP_BoxCol_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023207 RID: 143879 RVA: 0x009798C2 File Offset: 0x00977AC2
		protected BP_BoxCol_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D9B RID: 73115
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_BoxCol.BP_BoxCol_C";

		// Token: 0x04011D9C RID: 73116
		private static IntPtr _ClassPtr;

		// Token: 0x04011D9D RID: 73117
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D9E RID: 73118
		internal static int __PropertyOffset_0;

		// Token: 0x04011D9F RID: 73119
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011DA0 RID: 73120
		internal static int __PropertyOffset_1;

		// Token: 0x04011DA1 RID: 73121
		internal static int __PropertyOffset_2;

		// Token: 0x04011DA2 RID: 73122
		internal static int __PropertyOffset_3;

		// Token: 0x04011DA3 RID: 73123
		internal static int __PropertyOffset_4;

		// Token: 0x04011DA4 RID: 73124
		internal static int __PropertyOffset_5;

		// Token: 0x04011DA5 RID: 73125
		internal static int __PropertyOffset_6;

		// Token: 0x04011DA6 RID: 73126
		internal static int __PropertyOffset_7;

		// Token: 0x04011DA7 RID: 73127
		internal static int __PropertyOffset_8;

		// Token: 0x04011DA8 RID: 73128
		internal static int __PropertyOffset_9;

		// Token: 0x04011DA9 RID: 73129
		internal static int __PropertyOffset_10;

		// Token: 0x04011DAA RID: 73130
		internal static int __PropertyOffset_11;

		// Token: 0x04011DAB RID: 73131
		internal static int __PropertyOffset_12;

		// Token: 0x04011DAC RID: 73132
		internal static int __PropertyOffset_13;

		// Token: 0x04011DAD RID: 73133
		internal static int __PropertyOffset_14;

		// Token: 0x04011DAE RID: 73134
		internal static int __PropertyOffset_15;

		// Token: 0x04011DAF RID: 73135
		internal static int __PropertyOffset_16;

		// Token: 0x04011DB0 RID: 73136
		internal static int __PropertyOffset_17;

		// Token: 0x04011DB1 RID: 73137
		internal static int __PropertyOffset_18;

		// Token: 0x04011DB2 RID: 73138
		internal static int __PropertyOffset_19;

		// Token: 0x04011DB3 RID: 73139
		internal static int __PropertyOffset_20;

		// Token: 0x04011DB4 RID: 73140
		internal static int __PropertyOffset_21;

		// Token: 0x04011DB5 RID: 73141
		internal static int __PropertyOffset_22;

		// Token: 0x04011DB6 RID: 73142
		internal static int __PropertyOffset_23;

		// Token: 0x04011DB7 RID: 73143
		internal static int __PropertyOffset_24;

		// Token: 0x04011DB8 RID: 73144
		internal static int __PropertyOffset_25;

		// Token: 0x04011DB9 RID: 73145
		internal static int __PropertyOffset_26;

		// Token: 0x04011DBA RID: 73146
		internal static int __PropertyOffset_27;

		// Token: 0x04011DBB RID: 73147
		internal static int __PropertyOffset_28;

		// Token: 0x04011DBC RID: 73148
		internal static int __PropertyOffset_29;

		// Token: 0x04011DBD RID: 73149
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011DBE RID: 73150
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011DBF RID: 73151
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011DC0 RID: 73152
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011DC1 RID: 73153
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011DC2 RID: 73154
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011DC3 RID: 73155
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011DC4 RID: 73156
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011DC5 RID: 73157
		private static IntPtr __OpenPhysicsVisibility_NativeFunctionPtr;

		// Token: 0x04011DC6 RID: 73158
		private static IntPtr __ClosePhysicsVisibility_NativeFunctionPtr;

		// Token: 0x04011DC7 RID: 73159
		private static IntPtr __OnApplyWorldOffset_NativeFunctionPtr;

		// Token: 0x04011DC8 RID: 73160
		private static IntPtr __AfterTick_NativeFunctionPtr;

		// Token: 0x04011DC9 RID: 73161
		private static IntPtr __ExecuteUbergraph_BP_BoxCol_NativeFunctionPtr;

		// Token: 0x02009C8E RID: 40078
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403259D RID: 206237
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C8F RID: 40079
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403259E RID: 206238
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C90 RID: 40080
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403259F RID: 206239
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x040325A0 RID: 206240
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325A1 RID: 206241
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325A2 RID: 206242
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x040325A3 RID: 206243
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009C91 RID: 40081
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325A4 RID: 206244
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325A5 RID: 206245
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325A6 RID: 206246
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325A7 RID: 206247
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040325A8 RID: 206248
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040325A9 RID: 206249
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C92 RID: 40082
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325AA RID: 206250
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325AB RID: 206251
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325AC RID: 206252
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325AD RID: 206253
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C93 RID: 40083
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040325AE RID: 206254
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040325AF RID: 206255
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040325B0 RID: 206256
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009C94 RID: 40084
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnApplyWorldOffset_FunctionParams
		{
			// Token: 0x040325B1 RID: 206257
			[FieldOffset(0)]
			public FVector InWorldOffset;

			// Token: 0x040325B2 RID: 206258
			[FieldOffset(12)]
			public bool bWorldShift;
		}

		// Token: 0x02009C95 RID: 40085
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __AfterTick_FunctionParams
		{
			// Token: 0x040325B3 RID: 206259
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C96 RID: 40086
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2496)]
		protected ref struct __ExecuteUbergraph_BP_BoxCol_FunctionParams
		{
			// Token: 0x040325B4 RID: 206260
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
