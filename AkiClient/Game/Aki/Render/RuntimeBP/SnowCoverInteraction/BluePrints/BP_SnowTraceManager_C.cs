using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints
{
	// Token: 0x02003A53 RID: 14931
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTraceManager.BP_SnowTraceManager_C")]
	[UnrealStructLayout(1760, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1760)]
	public class BP_SnowTraceManager_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EF39 RID: 126777 RVA: 0x00903208 File Offset: 0x00901408
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTraceManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTraceManager.BP_SnowTraceManager_C");
			}
			return BP_SnowTraceManager_C._ClassPtr;
		}

		// Token: 0x0601EF3A RID: 126778 RVA: 0x0090322C File Offset: 0x0090142C
		public BP_SnowTraceManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTraceManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EF3B RID: 126779 RVA: 0x00903254 File Offset: 0x00901454
		[NullableContext(1)]
		public BP_SnowTraceManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTraceManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D48 RID: 11592
		// (get) Token: 0x0601EF3C RID: 126780 RVA: 0x00903288 File Offset: 0x00901488
		// (set) Token: 0x0601EF3D RID: 126781 RVA: 0x009032C1 File Offset: 0x009014C1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D49 RID: 11593
		// (get) Token: 0x0601EF3E RID: 126782 RVA: 0x009032E2 File Offset: 0x009014E2
		// (set) Token: 0x0601EF3F RID: 126783 RVA: 0x009032F6 File Offset: 0x009014F6
		public unsafe BP_SnowTrailComponent_C BP_SnowTrailComponent_WeaponInte
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002D4A RID: 11594
		// (get) Token: 0x0601EF40 RID: 126784 RVA: 0x0090330B File Offset: 0x0090150B
		// (set) Token: 0x0601EF41 RID: 126785 RVA: 0x0090331F File Offset: 0x0090151F
		public unsafe BP_SnowTrailComponent_C BP_SnowTrailComponent_FootR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002D4B RID: 11595
		// (get) Token: 0x0601EF42 RID: 126786 RVA: 0x00903334 File Offset: 0x00901534
		// (set) Token: 0x0601EF43 RID: 126787 RVA: 0x00903348 File Offset: 0x00901548
		public unsafe BP_SnowTrailComponent_C BP_SnowTrailComponent_FootL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002D4C RID: 11596
		// (get) Token: 0x0601EF44 RID: 126788 RVA: 0x0090335D File Offset: 0x0090155D
		// (set) Token: 0x0601EF45 RID: 126789 RVA: 0x00903371 File Offset: 0x00901571
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002D4D RID: 11597
		// (get) Token: 0x0601EF46 RID: 126790 RVA: 0x00903386 File Offset: 0x00901586
		// (set) Token: 0x0601EF47 RID: 126791 RVA: 0x0090339A File Offset: 0x0090159A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002D4E RID: 11598
		// (get) Token: 0x0601EF48 RID: 126792 RVA: 0x009033AF File Offset: 0x009015AF
		// (set) Token: 0x0601EF49 RID: 126793 RVA: 0x009033C3 File Offset: 0x009015C3
		public unsafe UMaterial M_TrialDrawer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002D4F RID: 11599
		// (get) Token: 0x0601EF4A RID: 126794 RVA: 0x009033D8 File Offset: 0x009015D8
		// (set) Token: 0x0601EF4B RID: 126795 RVA: 0x009033EC File Offset: 0x009015EC
		public unsafe UMaterial M_TrailDrawer_Weapon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002D50 RID: 11600
		// (get) Token: 0x0601EF4C RID: 126796 RVA: 0x00903401 File Offset: 0x00901601
		// (set) Token: 0x0601EF4D RID: 126797 RVA: 0x00903415 File Offset: 0x00901615
		public unsafe UMaterial M_HistoryMerge
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002D51 RID: 11601
		// (get) Token: 0x0601EF4E RID: 126798 RVA: 0x0090342A File Offset: 0x0090162A
		// (set) Token: 0x0601EF4F RID: 126799 RVA: 0x0090343E File Offset: 0x0090163E
		public unsafe UMaterial M_HistoryCopy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002D52 RID: 11602
		// (get) Token: 0x0601EF50 RID: 126800 RVA: 0x00903453 File Offset: 0x00901653
		// (set) Token: 0x0601EF51 RID: 126801 RVA: 0x00903467 File Offset: 0x00901667
		public unsafe UMaterial M_DrawEdge
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002D53 RID: 11603
		// (get) Token: 0x0601EF52 RID: 126802 RVA: 0x0090347C File Offset: 0x0090167C
		// (set) Token: 0x0601EF53 RID: 126803 RVA: 0x00903490 File Offset: 0x00901690
		public unsafe UMaterialInstanceDynamic MI_TrailDrawer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002D54 RID: 11604
		// (get) Token: 0x0601EF54 RID: 126804 RVA: 0x009034A5 File Offset: 0x009016A5
		// (set) Token: 0x0601EF55 RID: 126805 RVA: 0x009034B9 File Offset: 0x009016B9
		public unsafe UMaterialInstanceDynamic MI_TrailDrawer_Weapon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002D55 RID: 11605
		// (get) Token: 0x0601EF56 RID: 126806 RVA: 0x009034CE File Offset: 0x009016CE
		// (set) Token: 0x0601EF57 RID: 126807 RVA: 0x009034E2 File Offset: 0x009016E2
		public unsafe UMaterialInstanceDynamic MI_HistoryMerge
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002D56 RID: 11606
		// (get) Token: 0x0601EF58 RID: 126808 RVA: 0x009034F7 File Offset: 0x009016F7
		// (set) Token: 0x0601EF59 RID: 126809 RVA: 0x0090350B File Offset: 0x0090170B
		public unsafe UMaterialInstanceDynamic MI_HistoryCopy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002D57 RID: 11607
		// (get) Token: 0x0601EF5A RID: 126810 RVA: 0x00903520 File Offset: 0x00901720
		// (set) Token: 0x0601EF5B RID: 126811 RVA: 0x00903534 File Offset: 0x00901734
		public unsafe UMaterialInstanceDynamic MI_TrailEdge
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002D58 RID: 11608
		// (get) Token: 0x0601EF5C RID: 126812 RVA: 0x00903549 File Offset: 0x00901749
		// (set) Token: 0x0601EF5D RID: 126813 RVA: 0x0090355D File Offset: 0x0090175D
		public unsafe UMaterialInstanceDynamic MI_WiderTrail
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17002D59 RID: 11609
		// (get) Token: 0x0601EF5E RID: 126814 RVA: 0x00903572 File Offset: 0x00901772
		// (set) Token: 0x0601EF5F RID: 126815 RVA: 0x00903586 File Offset: 0x00901786
		public unsafe UTextureRenderTarget2D CurrentRenderTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17002D5A RID: 11610
		// (get) Token: 0x0601EF60 RID: 126816 RVA: 0x0090359B File Offset: 0x0090179B
		// (set) Token: 0x0601EF61 RID: 126817 RVA: 0x009035AF File Offset: 0x009017AF
		public unsafe UTextureRenderTarget2D HistoryRenderTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002D5B RID: 11611
		// (get) Token: 0x0601EF62 RID: 126818 RVA: 0x009035C4 File Offset: 0x009017C4
		// (set) Token: 0x0601EF63 RID: 126819 RVA: 0x009035D8 File Offset: 0x009017D8
		public unsafe UTextureRenderTarget2D TrialRenderTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17002D5C RID: 11612
		// (get) Token: 0x0601EF64 RID: 126820 RVA: 0x009035ED File Offset: 0x009017ED
		// (set) Token: 0x0601EF65 RID: 126821 RVA: 0x009035FD File Offset: 0x009017FD
		public unsafe float MaxDrawDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002D5D RID: 11613
		// (get) Token: 0x0601EF66 RID: 126822 RVA: 0x0090360E File Offset: 0x0090180E
		// (set) Token: 0x0601EF67 RID: 126823 RVA: 0x0090361E File Offset: 0x0090181E
		public unsafe float SideFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002D5E RID: 11614
		// (get) Token: 0x0601EF68 RID: 126824 RVA: 0x0090362F File Offset: 0x0090182F
		// (set) Token: 0x0601EF69 RID: 126825 RVA: 0x00903643 File Offset: 0x00901843
		public unsafe UTextureRenderTarget2D WiderTrailRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17002D5F RID: 11615
		// (get) Token: 0x0601EF6A RID: 126826 RVA: 0x00903658 File Offset: 0x00901858
		// (set) Token: 0x0601EF6B RID: 126827 RVA: 0x0090366C File Offset: 0x0090186C
		public unsafe UMaterialParameterCollection PMC_SnowTraceParams
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17002D60 RID: 11616
		// (get) Token: 0x0601EF6C RID: 126828 RVA: 0x00903681 File Offset: 0x00901881
		// (set) Token: 0x0601EF6D RID: 126829 RVA: 0x00903695 File Offset: 0x00901895
		public unsafe FVector CurrentManagerLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002D61 RID: 11617
		// (get) Token: 0x0601EF6E RID: 126830 RVA: 0x009036AA File Offset: 0x009018AA
		// (set) Token: 0x0601EF6F RID: 126831 RVA: 0x009036BE File Offset: 0x009018BE
		public unsafe FVector HistoryLocaiton
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002D62 RID: 11618
		// (get) Token: 0x0601EF70 RID: 126832 RVA: 0x009036D3 File Offset: 0x009018D3
		// (set) Token: 0x0601EF71 RID: 126833 RVA: 0x009036E3 File Offset: 0x009018E3
		public unsafe bool IsLocaitonCalculated
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D63 RID: 11619
		// (get) Token: 0x0601EF72 RID: 126834 RVA: 0x009036F4 File Offset: 0x009018F4
		// (set) Token: 0x0601EF73 RID: 126835 RVA: 0x0090372D File Offset: 0x0090192D
		[Nullable(1)]
		public TArray<float> Hardness
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Hardness) == null)
				{
					result = (this._Hardness = new TArray<float>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Hardness.CopyAssign(value);
			}
		}

		// Token: 0x17002D64 RID: 11620
		// (get) Token: 0x0601EF74 RID: 126836 RVA: 0x0090373C File Offset: 0x0090193C
		// (set) Token: 0x0601EF75 RID: 126837 RVA: 0x00903775 File Offset: 0x00901975
		[Nullable(1)]
		public TArray<float> TrailDepth
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._TrailDepth) == null)
				{
					result = (this._TrailDepth = new TArray<float>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_28, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TrailDepth.CopyAssign(value);
			}
		}

		// Token: 0x17002D65 RID: 11621
		// (get) Token: 0x0601EF76 RID: 126838 RVA: 0x00903784 File Offset: 0x00901984
		// (set) Token: 0x0601EF77 RID: 126839 RVA: 0x009037BD File Offset: 0x009019BD
		[Nullable(1)]
		public TArray<float> TrailRadius
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._TrailRadius) == null)
				{
					result = (this._TrailRadius = new TArray<float>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_29, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TrailRadius.CopyAssign(value);
			}
		}

		// Token: 0x17002D66 RID: 11622
		// (get) Token: 0x0601EF78 RID: 126840 RVA: 0x009037CC File Offset: 0x009019CC
		// (set) Token: 0x0601EF79 RID: 126841 RVA: 0x00903805 File Offset: 0x00901A05
		[Nullable(1)]
		public TArray<float> Rotation
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new TArray<float>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_30, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Rotation.CopyAssign(value);
			}
		}

		// Token: 0x17002D67 RID: 11623
		// (get) Token: 0x0601EF7A RID: 126842 RVA: 0x00903814 File Offset: 0x00901A14
		// (set) Token: 0x0601EF7B RID: 126843 RVA: 0x0090384D File Offset: 0x00901A4D
		[Nullable(1)]
		public TArray<FVector2D> TrailsLocation
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._TrailsLocation) == null)
				{
					result = (this._TrailsLocation = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_31, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TrailsLocation.CopyAssign(value);
			}
		}

		// Token: 0x17002D68 RID: 11624
		// (get) Token: 0x0601EF7C RID: 126844 RVA: 0x0090385B File Offset: 0x00901A5B
		// (set) Token: 0x0601EF7D RID: 126845 RVA: 0x0090386B File Offset: 0x00901A6B
		public unsafe float TrailFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002D69 RID: 11625
		// (get) Token: 0x0601EF7E RID: 126846 RVA: 0x0090387C File Offset: 0x00901A7C
		// (set) Token: 0x0601EF7F RID: 126847 RVA: 0x0090388C File Offset: 0x00901A8C
		public unsafe float TrailAttenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17002D6A RID: 11626
		// (get) Token: 0x0601EF80 RID: 126848 RVA: 0x0090389D File Offset: 0x00901A9D
		// (set) Token: 0x0601EF81 RID: 126849 RVA: 0x009038AD File Offset: 0x00901AAD
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D6B RID: 11627
		// (get) Token: 0x0601EF82 RID: 126850 RVA: 0x009038BE File Offset: 0x00901ABE
		// (set) Token: 0x0601EF83 RID: 126851 RVA: 0x009038CE File Offset: 0x00901ACE
		public unsafe float MovementThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17002D6C RID: 11628
		// (get) Token: 0x0601EF84 RID: 126852 RVA: 0x009038DF File Offset: 0x00901ADF
		// (set) Token: 0x0601EF85 RID: 126853 RVA: 0x009038EF File Offset: 0x00901AEF
		public unsafe float TrailSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17002D6D RID: 11629
		// (get) Token: 0x0601EF86 RID: 126854 RVA: 0x00903900 File Offset: 0x00901B00
		// (set) Token: 0x0601EF87 RID: 126855 RVA: 0x00903910 File Offset: 0x00901B10
		public unsafe float TrailIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17002D6E RID: 11630
		// (get) Token: 0x0601EF88 RID: 126856 RVA: 0x00903921 File Offset: 0x00901B21
		// (set) Token: 0x0601EF89 RID: 126857 RVA: 0x00903931 File Offset: 0x00901B31
		public unsafe float SnowDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17002D6F RID: 11631
		// (get) Token: 0x0601EF8A RID: 126858 RVA: 0x00903942 File Offset: 0x00901B42
		// (set) Token: 0x0601EF8B RID: 126859 RVA: 0x00903952 File Offset: 0x00901B52
		public unsafe bool DrawEdge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D70 RID: 11632
		// (get) Token: 0x0601EF8C RID: 126860 RVA: 0x00903963 File Offset: 0x00901B63
		// (set) Token: 0x0601EF8D RID: 126861 RVA: 0x00903973 File Offset: 0x00901B73
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D71 RID: 11633
		// (get) Token: 0x0601EF8E RID: 126862 RVA: 0x00903984 File Offset: 0x00901B84
		// (set) Token: 0x0601EF8F RID: 126863 RVA: 0x00903994 File Offset: 0x00901B94
		public unsafe bool bIsHitSnow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D72 RID: 11634
		// (get) Token: 0x0601EF90 RID: 126864 RVA: 0x009039A8 File Offset: 0x00901BA8
		// (set) Token: 0x0601EF91 RID: 126865 RVA: 0x009039E1 File Offset: 0x00901BE1
		[Nullable(1)]
		public FDrawToRenderTargetContext RenderContext
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FDrawToRenderTargetContext result;
				if ((result = this._RenderContext) == null)
				{
					result = (this._RenderContext = new FDrawToRenderTargetContext(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_42, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FDrawToRenderTargetContext.StaticStruct(), base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D73 RID: 11635
		// (get) Token: 0x0601EF92 RID: 126866 RVA: 0x00903A02 File Offset: 0x00901C02
		// (set) Token: 0x0601EF93 RID: 126867 RVA: 0x00903A12 File Offset: 0x00901C12
		public unsafe float GlobalMovementThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17002D74 RID: 11636
		// (get) Token: 0x0601EF94 RID: 126868 RVA: 0x00903A23 File Offset: 0x00901C23
		// (set) Token: 0x0601EF95 RID: 126869 RVA: 0x00903A33 File Offset: 0x00901C33
		public unsafe float GlobalTrailAttenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17002D75 RID: 11637
		// (get) Token: 0x0601EF96 RID: 126870 RVA: 0x00903A44 File Offset: 0x00901C44
		// (set) Token: 0x0601EF97 RID: 126871 RVA: 0x00903A7D File Offset: 0x00901C7D
		[Nullable(1)]
		public TArray<FVector2D> BulletPosList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._BulletPosList) == null)
				{
					result = (this._BulletPosList = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_45, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BulletPosList.CopyAssign(value);
			}
		}

		// Token: 0x17002D76 RID: 11638
		// (get) Token: 0x0601EF98 RID: 126872 RVA: 0x00903A8B File Offset: 0x00901C8B
		// (set) Token: 0x0601EF99 RID: 126873 RVA: 0x00903A9B File Offset: 0x00901C9B
		public unsafe float GlobalMaxDrawDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17002D77 RID: 11639
		// (get) Token: 0x0601EF9A RID: 126874 RVA: 0x00903AAC File Offset: 0x00901CAC
		// (set) Token: 0x0601EF9B RID: 126875 RVA: 0x00903ABC File Offset: 0x00901CBC
		public unsafe float WeaponRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17002D78 RID: 11640
		// (get) Token: 0x0601EF9C RID: 126876 RVA: 0x00903ACD File Offset: 0x00901CCD
		// (set) Token: 0x0601EF9D RID: 126877 RVA: 0x00903AE1 File Offset: 0x00901CE1
		public unsafe FLinearColor Parameter_Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17002D79 RID: 11641
		// (get) Token: 0x0601EF9E RID: 126878 RVA: 0x00903AF6 File Offset: 0x00901CF6
		// (set) Token: 0x0601EF9F RID: 126879 RVA: 0x00903B0A File Offset: 0x00901D0A
		public unsafe FName Parameter_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17002D7A RID: 11642
		// (get) Token: 0x0601EFA0 RID: 126880 RVA: 0x00903B20 File Offset: 0x00901D20
		// (set) Token: 0x0601EFA1 RID: 126881 RVA: 0x00903B59 File Offset: 0x00901D59
		[Nullable(1)]
		public TArray<FName> FootPointName
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._FootPointName) == null)
				{
					result = (this._FootPointName = new TArray<FName>(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_50, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FootPointName.CopyAssign(value);
			}
		}

		// Token: 0x17002D7B RID: 11643
		// (get) Token: 0x0601EFA2 RID: 126882 RVA: 0x00903B67 File Offset: 0x00901D67
		// (set) Token: 0x0601EFA3 RID: 126883 RVA: 0x00903B77 File Offset: 0x00901D77
		public unsafe float WeaponDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17002D7C RID: 11644
		// (get) Token: 0x0601EFA4 RID: 126884 RVA: 0x00903B88 File Offset: 0x00901D88
		// (set) Token: 0x0601EFA5 RID: 126885 RVA: 0x00903B98 File Offset: 0x00901D98
		public unsafe bool bIsMoto
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_52) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_52) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D7D RID: 11645
		// (get) Token: 0x0601EFA6 RID: 126886 RVA: 0x00903BA9 File Offset: 0x00901DA9
		// (set) Token: 0x0601EFA7 RID: 126887 RVA: 0x00903BBD File Offset: 0x00901DBD
		public unsafe UMaterialParameterCollection MPC_SnowTrail
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_53);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_53, value);
			}
		}

		// Token: 0x17002D7E RID: 11646
		// (get) Token: 0x0601EFA8 RID: 126888 RVA: 0x00903BD2 File Offset: 0x00901DD2
		// (set) Token: 0x0601EFA9 RID: 126889 RVA: 0x00903BE2 File Offset: 0x00901DE2
		public unsafe bool bSequenceMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D7F RID: 11647
		// (get) Token: 0x0601EFAA RID: 126890 RVA: 0x00903BF3 File Offset: 0x00901DF3
		// (set) Token: 0x0601EFAB RID: 126891 RVA: 0x00903C03 File Offset: 0x00901E03
		public unsafe bool bGICustom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowTraceManager_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D80 RID: 11648
		// (get) Token: 0x0601EFAC RID: 126892 RVA: 0x00903C14 File Offset: 0x00901E14
		// (set) Token: 0x0601EFAD RID: 126893 RVA: 0x00903C28 File Offset: 0x00901E28
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTraceManager_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x0601EFAE RID: 126894 RVA: 0x00903C40 File Offset: 0x00901E40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCharacterComp(bool bIsEnable)
		{
			BP_SnowTraceManager_C.__SetCharacterComp_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__SetCharacterComp_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_SnowTraceManager_C.__SetCharacterComp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__SetCharacterComp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsEnable = bIsEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__SetCharacterComp_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFAF RID: 126895 RVA: 0x00903C88 File Offset: 0x00901E88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckIfHitSnow(ref bool IsHit)
		{
			BP_SnowTraceManager_C.__CheckIfHitSnow_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__CheckIfHitSnow_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(BP_SnowTraceManager_C.__CheckIfHitSnow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__CheckIfHitSnow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsHit = IsHit;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__CheckIfHitSnow_NativeFunctionPtr, (void*)ptr);
			IsHit = ptr->IsHit;
		}

		// Token: 0x0601EFB0 RID: 126896 RVA: 0x00903CDA File Offset: 0x00901EDA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCurrentSettings()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__UpdateCurrentSettings_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFB1 RID: 126897 RVA: 0x00903CF0 File Offset: 0x00901EF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Register_Trail_Lerp(FVector Location, float Size)
		{
			BP_SnowTraceManager_C.__Register_Trail_Lerp_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__Register_Trail_Lerp_FunctionParams[(UIntPtr)147] + 15L / (long)sizeof(BP_SnowTraceManager_C.__Register_Trail_Lerp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__Register_Trail_Lerp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Location = Location;
			ptr->Size = Size;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__Register_Trail_Lerp_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFB2 RID: 126898 RVA: 0x00903D40 File Offset: 0x00901F40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void VisualizeCollSphere(AActor Actor)
		{
			BP_SnowTraceManager_C.__VisualizeCollSphere_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__VisualizeCollSphere_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SnowTraceManager_C.__VisualizeCollSphere_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__VisualizeCollSphere_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__VisualizeCollSphere_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFB3 RID: 126899 RVA: 0x00903D95 File Offset: 0x00901F95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RenderTrail()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__RenderTrail_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFB4 RID: 126900 RVA: 0x00903DAC File Offset: 0x00901FAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Register_Trail(FVector TrialCompLocation, float Radisu, float Depth, float Hardness, float Rotation)
		{
			BP_SnowTraceManager_C.__Register_Trail_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__Register_Trail_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_SnowTraceManager_C.__Register_Trail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__Register_Trail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TrialCompLocation = TrialCompLocation;
			ptr->Radisu = Radisu;
			ptr->Depth = Depth;
			ptr->Hardness = Hardness;
			ptr->Rotation = Rotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__Register_Trail_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFB5 RID: 126901 RVA: 0x00903E14 File Offset: 0x00902014
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RegisterWeaponPoint(FVector TrialCompLocation, float Radius, float Depth)
		{
			BP_SnowTraceManager_C.__RegisterWeaponPoint_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__RegisterWeaponPoint_FunctionParams[(UIntPtr)115] + 15L / (long)sizeof(BP_SnowTraceManager_C.__RegisterWeaponPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__RegisterWeaponPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TrialCompLocation = TrialCompLocation;
			ptr->Radius = Radius;
			ptr->Depth = Depth;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__RegisterWeaponPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFB6 RID: 126902 RVA: 0x00903E68 File Offset: 0x00902068
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalculateLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__CalculateLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFB7 RID: 126903 RVA: 0x00903E7C File Offset: 0x0090207C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialize()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__Initialize_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFB8 RID: 126904 RVA: 0x00903E90 File Offset: 0x00902090
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFB9 RID: 126905 RVA: 0x00903EA4 File Offset: 0x009020A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EFBA RID: 126906 RVA: 0x00903EBC File Offset: 0x009020BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SnowTraceManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFBB RID: 126907 RVA: 0x00903F04 File Offset: 0x00902104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SnowTraceManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EFBC RID: 126908 RVA: 0x00903F4B File Offset: 0x0090214B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ChangeSettings()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__ChangeSettings_NativeFunctionPtr, null);
		}

		// Token: 0x0601EFBD RID: 126909 RVA: 0x00903F60 File Offset: 0x00902160
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SnowTraceManager_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFBE RID: 126910 RVA: 0x00903FAC File Offset: 0x009021AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SnowTraceManager_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EFBF RID: 126911 RVA: 0x00903FF8 File Offset: 0x009021F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFC0 RID: 126912 RVA: 0x00904050 File Offset: 0x00902250
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EFC1 RID: 126913 RVA: 0x009040A8 File Offset: 0x009022A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_SnowTraceManager_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EFC2 RID: 126914 RVA: 0x00904100 File Offset: 0x00902300
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_SnowTraceManager_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTraceManager_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EFC3 RID: 126915 RVA: 0x00904158 File Offset: 0x00902358
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SnowTraceManager(int EntryPoint)
		{
			BP_SnowTraceManager_C.__ExecuteUbergraph_BP_SnowTraceManager_FunctionParams* ptr = stackalloc BP_SnowTraceManager_C.__ExecuteUbergraph_BP_SnowTraceManager_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_SnowTraceManager_C.__ExecuteUbergraph_BP_SnowTraceManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowTraceManager_C.__ExecuteUbergraph_BP_SnowTraceManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowTraceManager_C.__ExecuteUbergraph_BP_SnowTraceManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EFC4 RID: 126916 RVA: 0x009041A2 File Offset: 0x009023A2
		protected BP_SnowTraceManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F4E0 RID: 62688
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTraceManager.BP_SnowTraceManager_C";

		// Token: 0x0400F4E1 RID: 62689
		private static IntPtr _ClassPtr;

		// Token: 0x0400F4E2 RID: 62690
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F4E3 RID: 62691
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4E4 RID: 62692
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F4E5 RID: 62693
		internal static int __PropertyOffset_1;

		// Token: 0x0400F4E6 RID: 62694
		internal static int __PropertyOffset_2;

		// Token: 0x0400F4E7 RID: 62695
		internal static int __PropertyOffset_3;

		// Token: 0x0400F4E8 RID: 62696
		internal static int __PropertyOffset_4;

		// Token: 0x0400F4E9 RID: 62697
		internal static int __PropertyOffset_5;

		// Token: 0x0400F4EA RID: 62698
		internal static int __PropertyOffset_6;

		// Token: 0x0400F4EB RID: 62699
		internal static int __PropertyOffset_7;

		// Token: 0x0400F4EC RID: 62700
		internal static int __PropertyOffset_8;

		// Token: 0x0400F4ED RID: 62701
		internal static int __PropertyOffset_9;

		// Token: 0x0400F4EE RID: 62702
		internal static int __PropertyOffset_10;

		// Token: 0x0400F4EF RID: 62703
		internal static int __PropertyOffset_11;

		// Token: 0x0400F4F0 RID: 62704
		internal static int __PropertyOffset_12;

		// Token: 0x0400F4F1 RID: 62705
		internal static int __PropertyOffset_13;

		// Token: 0x0400F4F2 RID: 62706
		internal static int __PropertyOffset_14;

		// Token: 0x0400F4F3 RID: 62707
		internal static int __PropertyOffset_15;

		// Token: 0x0400F4F4 RID: 62708
		internal static int __PropertyOffset_16;

		// Token: 0x0400F4F5 RID: 62709
		internal static int __PropertyOffset_17;

		// Token: 0x0400F4F6 RID: 62710
		internal static int __PropertyOffset_18;

		// Token: 0x0400F4F7 RID: 62711
		internal static int __PropertyOffset_19;

		// Token: 0x0400F4F8 RID: 62712
		internal static int __PropertyOffset_20;

		// Token: 0x0400F4F9 RID: 62713
		internal static int __PropertyOffset_21;

		// Token: 0x0400F4FA RID: 62714
		internal static int __PropertyOffset_22;

		// Token: 0x0400F4FB RID: 62715
		internal static int __PropertyOffset_23;

		// Token: 0x0400F4FC RID: 62716
		internal static int __PropertyOffset_24;

		// Token: 0x0400F4FD RID: 62717
		internal static int __PropertyOffset_25;

		// Token: 0x0400F4FE RID: 62718
		internal static int __PropertyOffset_26;

		// Token: 0x0400F4FF RID: 62719
		internal static int __PropertyOffset_27;

		// Token: 0x0400F500 RID: 62720
		private TArray<float> _Hardness;

		// Token: 0x0400F501 RID: 62721
		internal static int __PropertyOffset_28;

		// Token: 0x0400F502 RID: 62722
		private TArray<float> _TrailDepth;

		// Token: 0x0400F503 RID: 62723
		internal static int __PropertyOffset_29;

		// Token: 0x0400F504 RID: 62724
		private TArray<float> _TrailRadius;

		// Token: 0x0400F505 RID: 62725
		internal static int __PropertyOffset_30;

		// Token: 0x0400F506 RID: 62726
		private TArray<float> _Rotation;

		// Token: 0x0400F507 RID: 62727
		internal static int __PropertyOffset_31;

		// Token: 0x0400F508 RID: 62728
		private TArray<FVector2D> _TrailsLocation;

		// Token: 0x0400F509 RID: 62729
		internal static int __PropertyOffset_32;

		// Token: 0x0400F50A RID: 62730
		internal static int __PropertyOffset_33;

		// Token: 0x0400F50B RID: 62731
		internal static int __PropertyOffset_34;

		// Token: 0x0400F50C RID: 62732
		internal static int __PropertyOffset_35;

		// Token: 0x0400F50D RID: 62733
		internal static int __PropertyOffset_36;

		// Token: 0x0400F50E RID: 62734
		internal static int __PropertyOffset_37;

		// Token: 0x0400F50F RID: 62735
		internal static int __PropertyOffset_38;

		// Token: 0x0400F510 RID: 62736
		internal static int __PropertyOffset_39;

		// Token: 0x0400F511 RID: 62737
		internal static int __PropertyOffset_40;

		// Token: 0x0400F512 RID: 62738
		internal static int __PropertyOffset_41;

		// Token: 0x0400F513 RID: 62739
		internal static int __PropertyOffset_42;

		// Token: 0x0400F514 RID: 62740
		private FDrawToRenderTargetContext _RenderContext;

		// Token: 0x0400F515 RID: 62741
		internal static int __PropertyOffset_43;

		// Token: 0x0400F516 RID: 62742
		internal static int __PropertyOffset_44;

		// Token: 0x0400F517 RID: 62743
		internal static int __PropertyOffset_45;

		// Token: 0x0400F518 RID: 62744
		private TArray<FVector2D> _BulletPosList;

		// Token: 0x0400F519 RID: 62745
		internal static int __PropertyOffset_46;

		// Token: 0x0400F51A RID: 62746
		internal static int __PropertyOffset_47;

		// Token: 0x0400F51B RID: 62747
		internal static int __PropertyOffset_48;

		// Token: 0x0400F51C RID: 62748
		internal static int __PropertyOffset_49;

		// Token: 0x0400F51D RID: 62749
		internal static int __PropertyOffset_50;

		// Token: 0x0400F51E RID: 62750
		private TArray<FName> _FootPointName;

		// Token: 0x0400F51F RID: 62751
		internal static int __PropertyOffset_51;

		// Token: 0x0400F520 RID: 62752
		internal static int __PropertyOffset_52;

		// Token: 0x0400F521 RID: 62753
		internal static int __PropertyOffset_53;

		// Token: 0x0400F522 RID: 62754
		internal static int __PropertyOffset_54;

		// Token: 0x0400F523 RID: 62755
		internal static int __PropertyOffset_55;

		// Token: 0x0400F524 RID: 62756
		internal static int __PropertyOffset_56;

		// Token: 0x0400F525 RID: 62757
		private static IntPtr __SetCharacterComp_NativeFunctionPtr;

		// Token: 0x0400F526 RID: 62758
		private static IntPtr __CheckIfHitSnow_NativeFunctionPtr;

		// Token: 0x0400F527 RID: 62759
		private static IntPtr __UpdateCurrentSettings_NativeFunctionPtr;

		// Token: 0x0400F528 RID: 62760
		private static IntPtr __Register_Trail_Lerp_NativeFunctionPtr;

		// Token: 0x0400F529 RID: 62761
		private static IntPtr __VisualizeCollSphere_NativeFunctionPtr;

		// Token: 0x0400F52A RID: 62762
		private static IntPtr __RenderTrail_NativeFunctionPtr;

		// Token: 0x0400F52B RID: 62763
		private static IntPtr __Register_Trail_NativeFunctionPtr;

		// Token: 0x0400F52C RID: 62764
		private static IntPtr __RegisterWeaponPoint_NativeFunctionPtr;

		// Token: 0x0400F52D RID: 62765
		private static IntPtr __CalculateLocation_NativeFunctionPtr;

		// Token: 0x0400F52E RID: 62766
		private static IntPtr __Initialize_NativeFunctionPtr;

		// Token: 0x0400F52F RID: 62767
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F530 RID: 62768
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F531 RID: 62769
		private static IntPtr __ChangeSettings_NativeFunctionPtr;

		// Token: 0x0400F532 RID: 62770
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F533 RID: 62771
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x0400F534 RID: 62772
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x0400F535 RID: 62773
		private static IntPtr __ExecuteUbergraph_BP_SnowTraceManager_NativeFunctionPtr;

		// Token: 0x02009827 RID: 38951
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __SetCharacterComp_FunctionParams
		{
			// Token: 0x04031E46 RID: 204358
			[FieldOffset(0)]
			public bool bIsEnable;
		}

		// Token: 0x02009828 RID: 38952
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __CheckIfHitSnow_FunctionParams
		{
			// Token: 0x04031E47 RID: 204359
			[FieldOffset(0)]
			public bool IsHit;
		}

		// Token: 0x02009829 RID: 38953
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 132)]
		protected ref struct __Register_Trail_Lerp_FunctionParams
		{
			// Token: 0x04031E48 RID: 204360
			[FieldOffset(0)]
			public FVector Location;

			// Token: 0x04031E49 RID: 204361
			[FieldOffset(12)]
			public float Size;
		}

		// Token: 0x0200982A RID: 38954
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __VisualizeCollSphere_FunctionParams
		{
			// Token: 0x04031E4A RID: 204362
			[FieldOffset(0)]
			public IntPtr Actor;
		}

		// Token: 0x0200982B RID: 38955
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __Register_Trail_FunctionParams
		{
			// Token: 0x04031E4B RID: 204363
			[FieldOffset(0)]
			public FVector TrialCompLocation;

			// Token: 0x04031E4C RID: 204364
			[FieldOffset(12)]
			public float Radisu;

			// Token: 0x04031E4D RID: 204365
			[FieldOffset(16)]
			public float Depth;

			// Token: 0x04031E4E RID: 204366
			[FieldOffset(20)]
			public float Hardness;

			// Token: 0x04031E4F RID: 204367
			[FieldOffset(24)]
			public float Rotation;
		}

		// Token: 0x0200982C RID: 38956
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 100)]
		protected ref struct __RegisterWeaponPoint_FunctionParams
		{
			// Token: 0x04031E50 RID: 204368
			[FieldOffset(0)]
			public FVector TrialCompLocation;

			// Token: 0x04031E51 RID: 204369
			[FieldOffset(12)]
			public float Radius;

			// Token: 0x04031E52 RID: 204370
			[FieldOffset(16)]
			public float Depth;
		}

		// Token: 0x0200982D RID: 38957
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E53 RID: 204371
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200982E RID: 38958
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E54 RID: 204372
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200982F RID: 38959
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04031E55 RID: 204373
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009830 RID: 38960
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04031E56 RID: 204374
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009831 RID: 38961
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_SnowTraceManager_FunctionParams
		{
			// Token: 0x04031E57 RID: 204375
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
