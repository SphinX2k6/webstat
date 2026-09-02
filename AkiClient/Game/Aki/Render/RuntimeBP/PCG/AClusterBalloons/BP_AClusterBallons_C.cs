using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C4C RID: 15436
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/BP_AClusterBallons.BP_AClusterBallons_C")]
	[UnrealStructLayout(1912, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1912)]
	public class BP_AClusterBallons_C : AKuroCSBalloons, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060238FB RID: 145659 RVA: 0x00985BCF File Offset: 0x00983DCF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AClusterBallons_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/BP_AClusterBallons.BP_AClusterBallons_C");
			}
			return BP_AClusterBallons_C._ClassPtr;
		}

		// Token: 0x060238FC RID: 145660 RVA: 0x00985BF4 File Offset: 0x00983DF4
		public BP_AClusterBallons_C() : this(BuiltinUtils.AllocNativeUObject(BP_AClusterBallons_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060238FD RID: 145661 RVA: 0x00985C1C File Offset: 0x00983E1C
		[NullableContext(1)]
		public BP_AClusterBallons_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AClusterBallons_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700471B RID: 18203
		// (get) Token: 0x060238FE RID: 145662 RVA: 0x00985C50 File Offset: 0x00983E50
		// (set) Token: 0x060238FF RID: 145663 RVA: 0x00985C89 File Offset: 0x00983E89
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700471C RID: 18204
		// (get) Token: 0x06023900 RID: 145664 RVA: 0x00985CAA File Offset: 0x00983EAA
		// (set) Token: 0x06023901 RID: 145665 RVA: 0x00985CBE File Offset: 0x00983EBE
		public unsafe UStaticMeshComponent balloonBase
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700471D RID: 18205
		// (get) Token: 0x06023902 RID: 145666 RVA: 0x00985CD3 File Offset: 0x00983ED3
		// (set) Token: 0x06023903 RID: 145667 RVA: 0x00985CE7 File Offset: 0x00983EE7
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700471E RID: 18206
		// (get) Token: 0x06023904 RID: 145668 RVA: 0x00985CFC File Offset: 0x00983EFC
		// (set) Token: 0x06023905 RID: 145669 RVA: 0x00985D10 File Offset: 0x00983F10
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700471F RID: 18207
		// (get) Token: 0x06023906 RID: 145670 RVA: 0x00985D25 File Offset: 0x00983F25
		// (set) Token: 0x06023907 RID: 145671 RVA: 0x00985D39 File Offset: 0x00983F39
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004720 RID: 18208
		// (get) Token: 0x06023908 RID: 145672 RVA: 0x00985D4E File Offset: 0x00983F4E
		// (set) Token: 0x06023909 RID: 145673 RVA: 0x00985D62 File Offset: 0x00983F62
		public unsafe PD_BakedBalloon_C DA_Bake
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_BakedBalloon_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004721 RID: 18209
		// (get) Token: 0x0602390A RID: 145674 RVA: 0x00985D77 File Offset: 0x00983F77
		// (set) Token: 0x0602390B RID: 145675 RVA: 0x00985D8B File Offset: 0x00983F8B
		public unsafe PD_SM_To_Balloon_C DA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_SM_To_Balloon_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004722 RID: 18210
		// (get) Token: 0x0602390C RID: 145676 RVA: 0x00985DA0 File Offset: 0x00983FA0
		// (set) Token: 0x0602390D RID: 145677 RVA: 0x00985DB4 File Offset: 0x00983FB4
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004723 RID: 18211
		// (get) Token: 0x0602390E RID: 145678 RVA: 0x00985DC9 File Offset: 0x00983FC9
		// (set) Token: 0x0602390F RID: 145679 RVA: 0x00985DD9 File Offset: 0x00983FD9
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004724 RID: 18212
		// (get) Token: 0x06023910 RID: 145680 RVA: 0x00985DEA File Offset: 0x00983FEA
		// (set) Token: 0x06023911 RID: 145681 RVA: 0x00985DFE File Offset: 0x00983FFE
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004725 RID: 18213
		// (get) Token: 0x06023912 RID: 145682 RVA: 0x00985E13 File Offset: 0x00984013
		// (set) Token: 0x06023913 RID: 145683 RVA: 0x00985E23 File Offset: 0x00984023
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004726 RID: 18214
		// (get) Token: 0x06023914 RID: 145684 RVA: 0x00985E34 File Offset: 0x00984034
		// (set) Token: 0x06023915 RID: 145685 RVA: 0x00985E44 File Offset: 0x00984044
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004727 RID: 18215
		// (get) Token: 0x06023916 RID: 145686 RVA: 0x00985E55 File Offset: 0x00984055
		// (set) Token: 0x06023917 RID: 145687 RVA: 0x00985E65 File Offset: 0x00984065
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004728 RID: 18216
		// (get) Token: 0x06023918 RID: 145688 RVA: 0x00985E76 File Offset: 0x00984076
		// (set) Token: 0x06023919 RID: 145689 RVA: 0x00985E86 File Offset: 0x00984086
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004729 RID: 18217
		// (get) Token: 0x0602391A RID: 145690 RVA: 0x00985E97 File Offset: 0x00984097
		// (set) Token: 0x0602391B RID: 145691 RVA: 0x00985EA7 File Offset: 0x009840A7
		public unsafe bool beditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700472A RID: 18218
		// (get) Token: 0x0602391C RID: 145692 RVA: 0x00985EB8 File Offset: 0x009840B8
		// (set) Token: 0x0602391D RID: 145693 RVA: 0x00985EC8 File Offset: 0x009840C8
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700472B RID: 18219
		// (get) Token: 0x0602391E RID: 145694 RVA: 0x00985ED9 File Offset: 0x009840D9
		// (set) Token: 0x0602391F RID: 145695 RVA: 0x00985EE9 File Offset: 0x009840E9
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700472C RID: 18220
		// (get) Token: 0x06023920 RID: 145696 RVA: 0x00985EFA File Offset: 0x009840FA
		// (set) Token: 0x06023921 RID: 145697 RVA: 0x00985F0A File Offset: 0x0098410A
		public unsafe int YCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700472D RID: 18221
		// (get) Token: 0x06023922 RID: 145698 RVA: 0x00985F1B File Offset: 0x0098411B
		// (set) Token: 0x06023923 RID: 145699 RVA: 0x00985F2B File Offset: 0x0098412B
		public unsafe bool ReadDataInBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700472E RID: 18222
		// (get) Token: 0x06023924 RID: 145700 RVA: 0x00985F3C File Offset: 0x0098413C
		// (set) Token: 0x06023925 RID: 145701 RVA: 0x00985F50 File Offset: 0x00984150
		public unsafe UStaticMesh inputStaticMesh_ForBPL_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700472F RID: 18223
		// (get) Token: 0x06023926 RID: 145702 RVA: 0x00985F65 File Offset: 0x00984165
		// (set) Token: 0x06023927 RID: 145703 RVA: 0x00985F79 File Offset: 0x00984179
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004730 RID: 18224
		// (get) Token: 0x06023928 RID: 145704 RVA: 0x00985F8E File Offset: 0x0098418E
		// (set) Token: 0x06023929 RID: 145705 RVA: 0x00985FA2 File Offset: 0x009841A2
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004731 RID: 18225
		// (get) Token: 0x0602392A RID: 145706 RVA: 0x00985FB7 File Offset: 0x009841B7
		// (set) Token: 0x0602392B RID: 145707 RVA: 0x00985FC7 File Offset: 0x009841C7
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004732 RID: 18226
		// (get) Token: 0x0602392C RID: 145708 RVA: 0x00985FD8 File Offset: 0x009841D8
		// (set) Token: 0x0602392D RID: 145709 RVA: 0x00985FE8 File Offset: 0x009841E8
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004733 RID: 18227
		// (get) Token: 0x0602392E RID: 145710 RVA: 0x00985FF9 File Offset: 0x009841F9
		// (set) Token: 0x0602392F RID: 145711 RVA: 0x0098600D File Offset: 0x0098420D
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004734 RID: 18228
		// (get) Token: 0x06023930 RID: 145712 RVA: 0x00986022 File Offset: 0x00984222
		// (set) Token: 0x06023931 RID: 145713 RVA: 0x00986036 File Offset: 0x00984236
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004735 RID: 18229
		// (get) Token: 0x06023932 RID: 145714 RVA: 0x0098604B File Offset: 0x0098424B
		// (set) Token: 0x06023933 RID: 145715 RVA: 0x0098605B File Offset: 0x0098425B
		public unsafe bool alreadyBuildArr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004736 RID: 18230
		// (get) Token: 0x06023934 RID: 145716 RVA: 0x0098606C File Offset: 0x0098426C
		// (set) Token: 0x06023935 RID: 145717 RVA: 0x0098607C File Offset: 0x0098427C
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004737 RID: 18231
		// (get) Token: 0x06023936 RID: 145718 RVA: 0x0098608D File Offset: 0x0098428D
		// (set) Token: 0x06023937 RID: 145719 RVA: 0x0098609D File Offset: 0x0098429D
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004738 RID: 18232
		// (get) Token: 0x06023938 RID: 145720 RVA: 0x009860AE File Offset: 0x009842AE
		// (set) Token: 0x06023939 RID: 145721 RVA: 0x009860BE File Offset: 0x009842BE
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004739 RID: 18233
		// (get) Token: 0x0602393A RID: 145722 RVA: 0x009860CF File Offset: 0x009842CF
		// (set) Token: 0x0602393B RID: 145723 RVA: 0x009860E3 File Offset: 0x009842E3
		public unsafe UChildActorComponent EditorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x1700473A RID: 18234
		// (get) Token: 0x0602393C RID: 145724 RVA: 0x009860F8 File Offset: 0x009842F8
		// (set) Token: 0x0602393D RID: 145725 RVA: 0x00986131 File Offset: 0x00984331
		[Nullable(1)]
		public TArray<float> weightArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._weightArr) == null)
				{
					result = (this._weightArr = new TArray<float>(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_31, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.weightArr.CopyAssign(value);
			}
		}

		// Token: 0x1700473B RID: 18235
		// (get) Token: 0x0602393E RID: 145726 RVA: 0x0098613F File Offset: 0x0098433F
		// (set) Token: 0x0602393F RID: 145727 RVA: 0x00986153 File Offset: 0x00984353
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x1700473C RID: 18236
		// (get) Token: 0x06023940 RID: 145728 RVA: 0x00986168 File Offset: 0x00984368
		// (set) Token: 0x06023941 RID: 145729 RVA: 0x009861A1 File Offset: 0x009843A1
		[Nullable(1)]
		public TArray<UStaticMesh> SMarr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._SMarr) == null)
				{
					result = (this._SMarr = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_33, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMarr.CopyAssign(value);
			}
		}

		// Token: 0x1700473D RID: 18237
		// (get) Token: 0x06023942 RID: 145730 RVA: 0x009861B0 File Offset: 0x009843B0
		// (set) Token: 0x06023943 RID: 145731 RVA: 0x009861E9 File Offset: 0x009843E9
		[Nullable(1)]
		public TArray<UStaticMeshComponent> SMComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._SMComponents) == null)
				{
					result = (this._SMComponents = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_34, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMComponents.CopyAssign(value);
			}
		}

		// Token: 0x1700473E RID: 18238
		// (get) Token: 0x06023944 RID: 145732 RVA: 0x009861F7 File Offset: 0x009843F7
		// (set) Token: 0x06023945 RID: 145733 RVA: 0x00986207 File Offset: 0x00984407
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x1700473F RID: 18239
		// (get) Token: 0x06023946 RID: 145734 RVA: 0x00986218 File Offset: 0x00984418
		// (set) Token: 0x06023947 RID: 145735 RVA: 0x00986228 File Offset: 0x00984428
		public unsafe bool UseBakedData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004740 RID: 18240
		// (get) Token: 0x06023948 RID: 145736 RVA: 0x00986239 File Offset: 0x00984439
		// (set) Token: 0x06023949 RID: 145737 RVA: 0x0098624D File Offset: 0x0098444D
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17004741 RID: 18241
		// (get) Token: 0x0602394A RID: 145738 RVA: 0x00986262 File Offset: 0x00984462
		// (set) Token: 0x0602394B RID: 145739 RVA: 0x00986272 File Offset: 0x00984472
		public unsafe int BakeID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004742 RID: 18242
		// (get) Token: 0x0602394C RID: 145740 RVA: 0x00986283 File Offset: 0x00984483
		// (set) Token: 0x0602394D RID: 145741 RVA: 0x00986293 File Offset: 0x00984493
		public unsafe bool startWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004743 RID: 18243
		// (get) Token: 0x0602394E RID: 145742 RVA: 0x009862A4 File Offset: 0x009844A4
		// (set) Token: 0x0602394F RID: 145743 RVA: 0x009862B4 File Offset: 0x009844B4
		public unsafe bool rebuild
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004744 RID: 18244
		// (get) Token: 0x06023950 RID: 145744 RVA: 0x009862C5 File Offset: 0x009844C5
		// (set) Token: 0x06023951 RID: 145745 RVA: 0x009862D9 File Offset: 0x009844D9
		public unsafe AKuroCSReadback ReadBackActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroCSReadback>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17004745 RID: 18245
		// (get) Token: 0x06023952 RID: 145746 RVA: 0x009862EE File Offset: 0x009844EE
		// (set) Token: 0x06023953 RID: 145747 RVA: 0x00986302 File Offset: 0x00984502
		public unsafe FVector 气球包围盒半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004746 RID: 18246
		// (get) Token: 0x06023954 RID: 145748 RVA: 0x00986317 File Offset: 0x00984517
		// (set) Token: 0x06023955 RID: 145749 RVA: 0x00986327 File Offset: 0x00984527
		public unsafe bool useStaticRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004747 RID: 18247
		// (get) Token: 0x06023956 RID: 145750 RVA: 0x00986338 File Offset: 0x00984538
		// (set) Token: 0x06023957 RID: 145751 RVA: 0x0098634C File Offset: 0x0098454C
		public unsafe UTextureRenderTarget2D StaticRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17004748 RID: 18248
		// (get) Token: 0x06023958 RID: 145752 RVA: 0x00986361 File Offset: 0x00984561
		// (set) Token: 0x06023959 RID: 145753 RVA: 0x00986375 File Offset: 0x00984575
		public unsafe UTextureRenderTarget2D StaticRT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17004749 RID: 18249
		// (get) Token: 0x0602395A RID: 145754 RVA: 0x0098638A File Offset: 0x0098458A
		// (set) Token: 0x0602395B RID: 145755 RVA: 0x0098639E File Offset: 0x0098459E
		public unsafe UMaterialInstanceDynamic MID_bake
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x1700474A RID: 18250
		// (get) Token: 0x0602395C RID: 145756 RVA: 0x009863B3 File Offset: 0x009845B3
		// (set) Token: 0x0602395D RID: 145757 RVA: 0x009863C7 File Offset: 0x009845C7
		public unsafe UTexture2D Tex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x1700474B RID: 18251
		// (get) Token: 0x0602395E RID: 145758 RVA: 0x009863DC File Offset: 0x009845DC
		// (set) Token: 0x0602395F RID: 145759 RVA: 0x009863F0 File Offset: 0x009845F0
		public unsafe UTexture2D Tex_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x1700474C RID: 18252
		// (get) Token: 0x06023960 RID: 145760 RVA: 0x00986405 File Offset: 0x00984605
		// (set) Token: 0x06023961 RID: 145761 RVA: 0x00986419 File Offset: 0x00984619
		public unsafe UTextureRenderTarget2D RT_test1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x1700474D RID: 18253
		// (get) Token: 0x06023962 RID: 145762 RVA: 0x0098642E File Offset: 0x0098462E
		// (set) Token: 0x06023963 RID: 145763 RVA: 0x00986442 File Offset: 0x00984642
		public unsafe UMaterialInstanceDynamic MID_bake_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x06023964 RID: 145764 RVA: 0x00986457 File Offset: 0x00984657
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void buildFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__buildFunction_NativeFunctionPtr, null);
		}

		// Token: 0x06023965 RID: 145765 RVA: 0x0098646B File Offset: 0x0098466B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023966 RID: 145766 RVA: 0x0098647F File Offset: 0x0098467F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023967 RID: 145767 RVA: 0x00986494 File Offset: 0x00984694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023968 RID: 145768 RVA: 0x009864A8 File Offset: 0x009846A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023969 RID: 145769 RVA: 0x009864C0 File Offset: 0x009846C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AClusterBallons_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AClusterBallons_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602396A RID: 145770 RVA: 0x00986508 File Offset: 0x00984708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AClusterBallons_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AClusterBallons_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602396B RID: 145771 RVA: 0x00986550 File Offset: 0x00984750
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_AClusterBallons_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_AClusterBallons_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602396C RID: 145772 RVA: 0x0098659C File Offset: 0x0098479C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_AClusterBallons_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_AClusterBallons_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602396D RID: 145773 RVA: 0x009865E8 File Offset: 0x009847E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602396E RID: 145774 RVA: 0x009866A4 File Offset: 0x009848A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602396F RID: 145775 RVA: 0x00986730 File Offset: 0x00984930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_AClusterBallons_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_AClusterBallons_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023970 RID: 145776 RVA: 0x00986793 File Offset: 0x00984993
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023971 RID: 145777 RVA: 0x009867A7 File Offset: 0x009849A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Bake()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__Bake_NativeFunctionPtr, null);
		}

		// Token: 0x06023972 RID: 145778 RVA: 0x009867BB File Offset: 0x009849BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x06023973 RID: 145779 RVA: 0x009867CF File Offset: 0x009849CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__CustomEvent_1_NativeFunctionPtr, null);
		}

		// Token: 0x06023974 RID: 145780 RVA: 0x009867E3 File Offset: 0x009849E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OpenPhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__OpenPhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x06023975 RID: 145781 RVA: 0x009867F7 File Offset: 0x009849F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OpenPhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__OpenPhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023976 RID: 145782 RVA: 0x0098680C File Offset: 0x00984A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ClosePhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_C.__ClosePhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x06023977 RID: 145783 RVA: 0x00986820 File Offset: 0x00984A20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ClosePhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__ClosePhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023978 RID: 145784 RVA: 0x00986838 File Offset: 0x00984A38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AClusterBallons(int EntryPoint)
		{
			BP_AClusterBallons_C.__ExecuteUbergraph_BP_AClusterBallons_FunctionParams* ptr = stackalloc BP_AClusterBallons_C.__ExecuteUbergraph_BP_AClusterBallons_FunctionParams[(UIntPtr)2703] + 15L / (long)sizeof(BP_AClusterBallons_C.__ExecuteUbergraph_BP_AClusterBallons_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_C.__ExecuteUbergraph_BP_AClusterBallons_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_C.__ExecuteUbergraph_BP_AClusterBallons_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023979 RID: 145785 RVA: 0x00986882 File Offset: 0x00984A82
		protected BP_AClusterBallons_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040121C7 RID: 74183
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/BP_AClusterBallons.BP_AClusterBallons_C";

		// Token: 0x040121C8 RID: 74184
		private static IntPtr _ClassPtr;

		// Token: 0x040121C9 RID: 74185
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040121CA RID: 74186
		internal static int __PropertyOffset_0;

		// Token: 0x040121CB RID: 74187
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040121CC RID: 74188
		internal static int __PropertyOffset_1;

		// Token: 0x040121CD RID: 74189
		internal static int __PropertyOffset_2;

		// Token: 0x040121CE RID: 74190
		internal static int __PropertyOffset_3;

		// Token: 0x040121CF RID: 74191
		internal static int __PropertyOffset_4;

		// Token: 0x040121D0 RID: 74192
		internal static int __PropertyOffset_5;

		// Token: 0x040121D1 RID: 74193
		internal static int __PropertyOffset_6;

		// Token: 0x040121D2 RID: 74194
		internal static int __PropertyOffset_7;

		// Token: 0x040121D3 RID: 74195
		internal static int __PropertyOffset_8;

		// Token: 0x040121D4 RID: 74196
		internal static int __PropertyOffset_9;

		// Token: 0x040121D5 RID: 74197
		internal static int __PropertyOffset_10;

		// Token: 0x040121D6 RID: 74198
		internal static int __PropertyOffset_11;

		// Token: 0x040121D7 RID: 74199
		internal static int __PropertyOffset_12;

		// Token: 0x040121D8 RID: 74200
		internal static int __PropertyOffset_13;

		// Token: 0x040121D9 RID: 74201
		internal static int __PropertyOffset_14;

		// Token: 0x040121DA RID: 74202
		internal static int __PropertyOffset_15;

		// Token: 0x040121DB RID: 74203
		internal static int __PropertyOffset_16;

		// Token: 0x040121DC RID: 74204
		internal static int __PropertyOffset_17;

		// Token: 0x040121DD RID: 74205
		internal static int __PropertyOffset_18;

		// Token: 0x040121DE RID: 74206
		internal static int __PropertyOffset_19;

		// Token: 0x040121DF RID: 74207
		internal static int __PropertyOffset_20;

		// Token: 0x040121E0 RID: 74208
		internal static int __PropertyOffset_21;

		// Token: 0x040121E1 RID: 74209
		internal static int __PropertyOffset_22;

		// Token: 0x040121E2 RID: 74210
		internal static int __PropertyOffset_23;

		// Token: 0x040121E3 RID: 74211
		internal static int __PropertyOffset_24;

		// Token: 0x040121E4 RID: 74212
		internal static int __PropertyOffset_25;

		// Token: 0x040121E5 RID: 74213
		internal static int __PropertyOffset_26;

		// Token: 0x040121E6 RID: 74214
		internal static int __PropertyOffset_27;

		// Token: 0x040121E7 RID: 74215
		internal static int __PropertyOffset_28;

		// Token: 0x040121E8 RID: 74216
		internal static int __PropertyOffset_29;

		// Token: 0x040121E9 RID: 74217
		internal static int __PropertyOffset_30;

		// Token: 0x040121EA RID: 74218
		internal static int __PropertyOffset_31;

		// Token: 0x040121EB RID: 74219
		private TArray<float> _weightArr;

		// Token: 0x040121EC RID: 74220
		internal static int __PropertyOffset_32;

		// Token: 0x040121ED RID: 74221
		internal static int __PropertyOffset_33;

		// Token: 0x040121EE RID: 74222
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _SMarr;

		// Token: 0x040121EF RID: 74223
		internal static int __PropertyOffset_34;

		// Token: 0x040121F0 RID: 74224
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMComponents;

		// Token: 0x040121F1 RID: 74225
		internal static int __PropertyOffset_35;

		// Token: 0x040121F2 RID: 74226
		internal static int __PropertyOffset_36;

		// Token: 0x040121F3 RID: 74227
		internal static int __PropertyOffset_37;

		// Token: 0x040121F4 RID: 74228
		internal static int __PropertyOffset_38;

		// Token: 0x040121F5 RID: 74229
		internal static int __PropertyOffset_39;

		// Token: 0x040121F6 RID: 74230
		internal static int __PropertyOffset_40;

		// Token: 0x040121F7 RID: 74231
		internal static int __PropertyOffset_41;

		// Token: 0x040121F8 RID: 74232
		internal static int __PropertyOffset_42;

		// Token: 0x040121F9 RID: 74233
		internal static int __PropertyOffset_43;

		// Token: 0x040121FA RID: 74234
		internal static int __PropertyOffset_44;

		// Token: 0x040121FB RID: 74235
		internal static int __PropertyOffset_45;

		// Token: 0x040121FC RID: 74236
		internal static int __PropertyOffset_46;

		// Token: 0x040121FD RID: 74237
		internal static int __PropertyOffset_47;

		// Token: 0x040121FE RID: 74238
		internal static int __PropertyOffset_48;

		// Token: 0x040121FF RID: 74239
		internal static int __PropertyOffset_49;

		// Token: 0x04012200 RID: 74240
		internal static int __PropertyOffset_50;

		// Token: 0x04012201 RID: 74241
		private static IntPtr __buildFunction_NativeFunctionPtr;

		// Token: 0x04012202 RID: 74242
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012203 RID: 74243
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012204 RID: 74244
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012205 RID: 74245
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04012206 RID: 74246
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012207 RID: 74247
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012208 RID: 74248
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04012209 RID: 74249
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401220A RID: 74250
		private static IntPtr __Bake_NativeFunctionPtr;

		// Token: 0x0401220B RID: 74251
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x0401220C RID: 74252
		private static IntPtr __CustomEvent_1_NativeFunctionPtr;

		// Token: 0x0401220D RID: 74253
		private static IntPtr __OpenPhysicsVisibility_NativeFunctionPtr;

		// Token: 0x0401220E RID: 74254
		private static IntPtr __ClosePhysicsVisibility_NativeFunctionPtr;

		// Token: 0x0401220F RID: 74255
		private static IntPtr __ExecuteUbergraph_BP_AClusterBallons_NativeFunctionPtr;

		// Token: 0x02009D06 RID: 40198
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326B4 RID: 206516
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D07 RID: 40199
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040326B5 RID: 206517
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D08 RID: 40200
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040326B6 RID: 206518
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040326B7 RID: 206519
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040326B8 RID: 206520
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040326B9 RID: 206521
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040326BA RID: 206522
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040326BB RID: 206523
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009D09 RID: 40201
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040326BC RID: 206524
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040326BD RID: 206525
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040326BE RID: 206526
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040326BF RID: 206527
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009D0A RID: 40202
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040326C0 RID: 206528
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040326C1 RID: 206529
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040326C2 RID: 206530
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D0B RID: 40203
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2688)]
		protected ref struct __ExecuteUbergraph_BP_AClusterBallons_FunctionParams
		{
			// Token: 0x040326C3 RID: 206531
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
