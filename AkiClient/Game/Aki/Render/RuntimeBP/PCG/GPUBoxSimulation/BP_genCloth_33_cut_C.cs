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
	// Token: 0x02003C26 RID: 15398
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth_33_cut.BP_genCloth_33_cut_C")]
	[UnrealStructLayout(1856, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1850)]
	public class BP_genCloth_33_cut_C : AKuroCSGenericCloth_33, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060232EA RID: 144106 RVA: 0x0097B3C7 File Offset: 0x009795C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_genCloth_33_cut_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth_33_cut.BP_genCloth_33_cut_C");
			}
			return BP_genCloth_33_cut_C._ClassPtr;
		}

		// Token: 0x060232EB RID: 144107 RVA: 0x0097B3EC File Offset: 0x009795EC
		public BP_genCloth_33_cut_C() : this(BuiltinUtils.AllocNativeUObject(BP_genCloth_33_cut_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060232EC RID: 144108 RVA: 0x0097B414 File Offset: 0x00979614
		[NullableContext(1)]
		public BP_genCloth_33_cut_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_genCloth_33_cut_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170044E0 RID: 17632
		// (get) Token: 0x060232ED RID: 144109 RVA: 0x0097B448 File Offset: 0x00979648
		// (set) Token: 0x060232EE RID: 144110 RVA: 0x0097B481 File Offset: 0x00979681
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170044E1 RID: 17633
		// (get) Token: 0x060232EF RID: 144111 RVA: 0x0097B4A2 File Offset: 0x009796A2
		// (set) Token: 0x060232F0 RID: 144112 RVA: 0x0097B4B6 File Offset: 0x009796B6
		public unsafe UStaticMeshComponent xpbd_test1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170044E2 RID: 17634
		// (get) Token: 0x060232F1 RID: 144113 RVA: 0x0097B4CB File Offset: 0x009796CB
		// (set) Token: 0x060232F2 RID: 144114 RVA: 0x0097B4DF File Offset: 0x009796DF
		public unsafe UStaticMeshComponent SM_NotClothPart
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170044E3 RID: 17635
		// (get) Token: 0x060232F3 RID: 144115 RVA: 0x0097B4F4 File Offset: 0x009796F4
		// (set) Token: 0x060232F4 RID: 144116 RVA: 0x0097B508 File Offset: 0x00979708
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170044E4 RID: 17636
		// (get) Token: 0x060232F5 RID: 144117 RVA: 0x0097B51D File Offset: 0x0097971D
		// (set) Token: 0x060232F6 RID: 144118 RVA: 0x0097B531 File Offset: 0x00979731
		public unsafe UBoxComponent BoxStopPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170044E5 RID: 17637
		// (get) Token: 0x060232F7 RID: 144119 RVA: 0x0097B546 File Offset: 0x00979746
		// (set) Token: 0x060232F8 RID: 144120 RVA: 0x0097B55A File Offset: 0x0097975A
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170044E6 RID: 17638
		// (get) Token: 0x060232F9 RID: 144121 RVA: 0x0097B56F File Offset: 0x0097976F
		// (set) Token: 0x060232FA RID: 144122 RVA: 0x0097B583 File Offset: 0x00979783
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170044E7 RID: 17639
		// (get) Token: 0x060232FB RID: 144123 RVA: 0x0097B598 File Offset: 0x00979798
		// (set) Token: 0x060232FC RID: 144124 RVA: 0x0097B5AC File Offset: 0x009797AC
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170044E8 RID: 17640
		// (get) Token: 0x060232FD RID: 144125 RVA: 0x0097B5C1 File Offset: 0x009797C1
		// (set) Token: 0x060232FE RID: 144126 RVA: 0x0097B5D5 File Offset: 0x009797D5
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170044E9 RID: 17641
		// (get) Token: 0x060232FF RID: 144127 RVA: 0x0097B5EA File Offset: 0x009797EA
		// (set) Token: 0x06023300 RID: 144128 RVA: 0x0097B5FE File Offset: 0x009797FE
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170044EA RID: 17642
		// (get) Token: 0x06023301 RID: 144129 RVA: 0x0097B613 File Offset: 0x00979813
		// (set) Token: 0x06023302 RID: 144130 RVA: 0x0097B623 File Offset: 0x00979823
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044EB RID: 17643
		// (get) Token: 0x06023303 RID: 144131 RVA: 0x0097B634 File Offset: 0x00979834
		// (set) Token: 0x06023304 RID: 144132 RVA: 0x0097B648 File Offset: 0x00979848
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170044EC RID: 17644
		// (get) Token: 0x06023305 RID: 144133 RVA: 0x0097B65D File Offset: 0x0097985D
		// (set) Token: 0x06023306 RID: 144134 RVA: 0x0097B66D File Offset: 0x0097986D
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170044ED RID: 17645
		// (get) Token: 0x06023307 RID: 144135 RVA: 0x0097B67E File Offset: 0x0097987E
		// (set) Token: 0x06023308 RID: 144136 RVA: 0x0097B68E File Offset: 0x0097988E
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044EE RID: 17646
		// (get) Token: 0x06023309 RID: 144137 RVA: 0x0097B69F File Offset: 0x0097989F
		// (set) Token: 0x0602330A RID: 144138 RVA: 0x0097B6AF File Offset: 0x009798AF
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044EF RID: 17647
		// (get) Token: 0x0602330B RID: 144139 RVA: 0x0097B6C0 File Offset: 0x009798C0
		// (set) Token: 0x0602330C RID: 144140 RVA: 0x0097B6D0 File Offset: 0x009798D0
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170044F0 RID: 17648
		// (get) Token: 0x0602330D RID: 144141 RVA: 0x0097B6E1 File Offset: 0x009798E1
		// (set) Token: 0x0602330E RID: 144142 RVA: 0x0097B6F1 File Offset: 0x009798F1
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044F1 RID: 17649
		// (get) Token: 0x0602330F RID: 144143 RVA: 0x0097B702 File Offset: 0x00979902
		// (set) Token: 0x06023310 RID: 144144 RVA: 0x0097B712 File Offset: 0x00979912
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044F2 RID: 17650
		// (get) Token: 0x06023311 RID: 144145 RVA: 0x0097B723 File Offset: 0x00979923
		// (set) Token: 0x06023312 RID: 144146 RVA: 0x0097B733 File Offset: 0x00979933
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170044F3 RID: 17651
		// (get) Token: 0x06023313 RID: 144147 RVA: 0x0097B744 File Offset: 0x00979944
		// (set) Token: 0x06023314 RID: 144148 RVA: 0x0097B754 File Offset: 0x00979954
		public unsafe bool ReadFromBPL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044F4 RID: 17652
		// (get) Token: 0x06023315 RID: 144149 RVA: 0x0097B765 File Offset: 0x00979965
		// (set) Token: 0x06023316 RID: 144150 RVA: 0x0097B775 File Offset: 0x00979975
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044F5 RID: 17653
		// (get) Token: 0x06023317 RID: 144151 RVA: 0x0097B786 File Offset: 0x00979986
		// (set) Token: 0x06023318 RID: 144152 RVA: 0x0097B79A File Offset: 0x0097999A
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170044F6 RID: 17654
		// (get) Token: 0x06023319 RID: 144153 RVA: 0x0097B7AF File Offset: 0x009799AF
		// (set) Token: 0x0602331A RID: 144154 RVA: 0x0097B7C3 File Offset: 0x009799C3
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170044F7 RID: 17655
		// (get) Token: 0x0602331B RID: 144155 RVA: 0x0097B7D8 File Offset: 0x009799D8
		// (set) Token: 0x0602331C RID: 144156 RVA: 0x0097B7E8 File Offset: 0x009799E8
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044F8 RID: 17656
		// (get) Token: 0x0602331D RID: 144157 RVA: 0x0097B7F9 File Offset: 0x009799F9
		// (set) Token: 0x0602331E RID: 144158 RVA: 0x0097B809 File Offset: 0x00979A09
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044F9 RID: 17657
		// (get) Token: 0x0602331F RID: 144159 RVA: 0x0097B81A File Offset: 0x00979A1A
		// (set) Token: 0x06023320 RID: 144160 RVA: 0x0097B82A File Offset: 0x00979A2A
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170044FA RID: 17658
		// (get) Token: 0x06023321 RID: 144161 RVA: 0x0097B83B File Offset: 0x00979A3B
		// (set) Token: 0x06023322 RID: 144162 RVA: 0x0097B84F File Offset: 0x00979A4F
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170044FB RID: 17659
		// (get) Token: 0x06023323 RID: 144163 RVA: 0x0097B864 File Offset: 0x00979A64
		// (set) Token: 0x06023324 RID: 144164 RVA: 0x0097B878 File Offset: 0x00979A78
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170044FC RID: 17660
		// (get) Token: 0x06023325 RID: 144165 RVA: 0x0097B88D File Offset: 0x00979A8D
		// (set) Token: 0x06023326 RID: 144166 RVA: 0x0097B8A1 File Offset: 0x00979AA1
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170044FD RID: 17661
		// (get) Token: 0x06023327 RID: 144167 RVA: 0x0097B8B6 File Offset: 0x00979AB6
		// (set) Token: 0x06023328 RID: 144168 RVA: 0x0097B8CA File Offset: 0x00979ACA
		public unsafe FVector gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170044FE RID: 17662
		// (get) Token: 0x06023329 RID: 144169 RVA: 0x0097B8DF File Offset: 0x00979ADF
		// (set) Token: 0x0602332A RID: 144170 RVA: 0x0097B8EF File Offset: 0x00979AEF
		public unsafe bool UseStaticCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170044FF RID: 17663
		// (get) Token: 0x0602332B RID: 144171 RVA: 0x0097B900 File Offset: 0x00979B00
		// (set) Token: 0x0602332C RID: 144172 RVA: 0x0097B914 File Offset: 0x00979B14
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_33_cut_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17004500 RID: 17664
		// (get) Token: 0x0602332D RID: 144173 RVA: 0x0097B92C File Offset: 0x00979B2C
		// (set) Token: 0x0602332E RID: 144174 RVA: 0x0097B965 File Offset: 0x00979B65
		[Nullable(1)]
		public TArray<FKuroCSUnifiedCollider_genericCloth_33> ColArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCSUnifiedCollider_genericCloth_33> result;
				if ((result = this._ColArr) == null)
				{
					result = (this._ColArr = new TArray<FKuroCSUnifiedCollider_genericCloth_33>(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_32, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ColArr.CopyAssign(value);
			}
		}

		// Token: 0x17004501 RID: 17665
		// (get) Token: 0x0602332F RID: 144175 RVA: 0x0097B973 File Offset: 0x00979B73
		// (set) Token: 0x06023330 RID: 144176 RVA: 0x0097B983 File Offset: 0x00979B83
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004502 RID: 17666
		// (get) Token: 0x06023331 RID: 144177 RVA: 0x0097B994 File Offset: 0x00979B94
		// (set) Token: 0x06023332 RID: 144178 RVA: 0x0097B9A4 File Offset: 0x00979BA4
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004503 RID: 17667
		// (get) Token: 0x06023333 RID: 144179 RVA: 0x0097B9B5 File Offset: 0x00979BB5
		// (set) Token: 0x06023334 RID: 144180 RVA: 0x0097B9C5 File Offset: 0x00979BC5
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004504 RID: 17668
		// (get) Token: 0x06023335 RID: 144181 RVA: 0x0097B9D6 File Offset: 0x00979BD6
		// (set) Token: 0x06023336 RID: 144182 RVA: 0x0097B9E6 File Offset: 0x00979BE6
		public unsafe bool alreadyBuildArr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004505 RID: 17669
		// (get) Token: 0x06023337 RID: 144183 RVA: 0x0097B9F7 File Offset: 0x00979BF7
		// (set) Token: 0x06023338 RID: 144184 RVA: 0x0097BA07 File Offset: 0x00979C07
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004506 RID: 17670
		// (get) Token: 0x06023339 RID: 144185 RVA: 0x0097BA18 File Offset: 0x00979C18
		// (set) Token: 0x0602333A RID: 144186 RVA: 0x0097BA28 File Offset: 0x00979C28
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004507 RID: 17671
		// (get) Token: 0x0602333B RID: 144187 RVA: 0x0097BA39 File Offset: 0x00979C39
		// (set) Token: 0x0602333C RID: 144188 RVA: 0x0097BA4D File Offset: 0x00979C4D
		public unsafe FVectorDouble AttackPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004508 RID: 17672
		// (get) Token: 0x0602333D RID: 144189 RVA: 0x0097BA62 File Offset: 0x00979C62
		// (set) Token: 0x0602333E RID: 144190 RVA: 0x0097BA76 File Offset: 0x00979C76
		public unsafe FVectorDouble PlayerDirectory
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17004509 RID: 17673
		// (get) Token: 0x0602333F RID: 144191 RVA: 0x0097BA8B File Offset: 0x00979C8B
		// (set) Token: 0x06023340 RID: 144192 RVA: 0x0097BA9F File Offset: 0x00979C9F
		public unsafe FVectorDouble PlayerPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700450A RID: 17674
		// (get) Token: 0x06023341 RID: 144193 RVA: 0x0097BAB4 File Offset: 0x00979CB4
		// (set) Token: 0x06023342 RID: 144194 RVA: 0x0097BAC4 File Offset: 0x00979CC4
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700450B RID: 17675
		// (get) Token: 0x06023343 RID: 144195 RVA: 0x0097BAD5 File Offset: 0x00979CD5
		// (set) Token: 0x06023344 RID: 144196 RVA: 0x0097BAE5 File Offset: 0x00979CE5
		public unsafe bool Splited
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700450C RID: 17676
		// (get) Token: 0x06023345 RID: 144197 RVA: 0x0097BAF8 File Offset: 0x00979CF8
		// (set) Token: 0x06023346 RID: 144198 RVA: 0x0097BB31 File Offset: 0x00979D31
		[Nullable(1)]
		public TArray<TSoftObjectPtr<UObject>> Staticmesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UObject>> result;
				if ((result = this._Staticmesh) == null)
				{
					result = (this._Staticmesh = new TArray<TSoftObjectPtr<UObject>>(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_44, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Staticmesh.CopyAssign(value);
			}
		}

		// Token: 0x1700450D RID: 17677
		// (get) Token: 0x06023347 RID: 144199 RVA: 0x0097BB3F File Offset: 0x00979D3F
		// (set) Token: 0x06023348 RID: 144200 RVA: 0x0097BB4F File Offset: 0x00979D4F
		public unsafe float mytimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700450E RID: 17678
		// (get) Token: 0x06023349 RID: 144201 RVA: 0x0097BB60 File Offset: 0x00979D60
		// (set) Token: 0x0602334A RID: 144202 RVA: 0x0097BB70 File Offset: 0x00979D70
		public unsafe bool startTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700450F RID: 17679
		// (get) Token: 0x0602334B RID: 144203 RVA: 0x0097BB84 File Offset: 0x00979D84
		// (set) Token: 0x0602334C RID: 144204 RVA: 0x0097BBBD File Offset: 0x00979DBD
		[Nullable(1)]
		public TArray<UStaticMesh> Staticmesh_0
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._Staticmesh_0) == null)
				{
					result = (this._Staticmesh_0 = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_47, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Staticmesh_0.CopyAssign(value);
			}
		}

		// Token: 0x17004510 RID: 17680
		// (get) Token: 0x0602334D RID: 144205 RVA: 0x0097BBCB File Offset: 0x00979DCB
		// (set) Token: 0x0602334E RID: 144206 RVA: 0x0097BBDB File Offset: 0x00979DDB
		public unsafe bool MID1_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004511 RID: 17681
		// (get) Token: 0x0602334F RID: 144207 RVA: 0x0097BBEC File Offset: 0x00979DEC
		// (set) Token: 0x06023350 RID: 144208 RVA: 0x0097BBFC File Offset: 0x00979DFC
		public unsafe bool 不需要砍碎
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_33_cut_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023351 RID: 144209 RVA: 0x0097BC0D File Offset: 0x00979E0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023352 RID: 144210 RVA: 0x0097BC21 File Offset: 0x00979E21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_cut_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023353 RID: 144211 RVA: 0x0097BC36 File Offset: 0x00979E36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023354 RID: 144212 RVA: 0x0097BC4A File Offset: 0x00979E4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023355 RID: 144213 RVA: 0x0097BC60 File Offset: 0x00979E60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_genCloth_33_cut_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023356 RID: 144214 RVA: 0x0097BCA8 File Offset: 0x00979EA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_genCloth_33_cut_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023357 RID: 144215 RVA: 0x0097BCF0 File Offset: 0x00979EF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_genCloth_33_cut_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023358 RID: 144216 RVA: 0x0097BD3C File Offset: 0x00979F3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_genCloth_33_cut_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023359 RID: 144217 RVA: 0x0097BD88 File Offset: 0x00979F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602335A RID: 144218 RVA: 0x0097BE3C File Offset: 0x0097A03C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602335B RID: 144219 RVA: 0x0097BEF8 File Offset: 0x0097A0F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602335C RID: 144220 RVA: 0x0097BF81 File Offset: 0x0097A181
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602335D RID: 144221 RVA: 0x0097BF95 File Offset: 0x0097A195
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetDeadNode()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__SetDeadNode_NativeFunctionPtr, null);
		}

		// Token: 0x0602335E RID: 144222 RVA: 0x0097BFAC File Offset: 0x0097A1AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_genCloth_33_cut_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_33_cut_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602335F RID: 144223 RVA: 0x0097C010 File Offset: 0x0097A210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_genCloth_33_cut(int EntryPoint)
		{
			BP_genCloth_33_cut_C.__ExecuteUbergraph_BP_genCloth_33_cut_FunctionParams* ptr = stackalloc BP_genCloth_33_cut_C.__ExecuteUbergraph_BP_genCloth_33_cut_FunctionParams[(UIntPtr)3199] + 15L / (long)sizeof(BP_genCloth_33_cut_C.__ExecuteUbergraph_BP_genCloth_33_cut_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_33_cut_C.__ExecuteUbergraph_BP_genCloth_33_cut_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_33_cut_C.__ExecuteUbergraph_BP_genCloth_33_cut_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023360 RID: 144224 RVA: 0x0097C05A File Offset: 0x0097A25A
		protected BP_genCloth_33_cut_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011E4A RID: 73290
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth_33_cut.BP_genCloth_33_cut_C";

		// Token: 0x04011E4B RID: 73291
		private static IntPtr _ClassPtr;

		// Token: 0x04011E4C RID: 73292
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011E4D RID: 73293
		internal static int __PropertyOffset_0;

		// Token: 0x04011E4E RID: 73294
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011E4F RID: 73295
		internal static int __PropertyOffset_1;

		// Token: 0x04011E50 RID: 73296
		internal static int __PropertyOffset_2;

		// Token: 0x04011E51 RID: 73297
		internal static int __PropertyOffset_3;

		// Token: 0x04011E52 RID: 73298
		internal static int __PropertyOffset_4;

		// Token: 0x04011E53 RID: 73299
		internal static int __PropertyOffset_5;

		// Token: 0x04011E54 RID: 73300
		internal static int __PropertyOffset_6;

		// Token: 0x04011E55 RID: 73301
		internal static int __PropertyOffset_7;

		// Token: 0x04011E56 RID: 73302
		internal static int __PropertyOffset_8;

		// Token: 0x04011E57 RID: 73303
		internal static int __PropertyOffset_9;

		// Token: 0x04011E58 RID: 73304
		internal static int __PropertyOffset_10;

		// Token: 0x04011E59 RID: 73305
		internal static int __PropertyOffset_11;

		// Token: 0x04011E5A RID: 73306
		internal static int __PropertyOffset_12;

		// Token: 0x04011E5B RID: 73307
		internal static int __PropertyOffset_13;

		// Token: 0x04011E5C RID: 73308
		internal static int __PropertyOffset_14;

		// Token: 0x04011E5D RID: 73309
		internal static int __PropertyOffset_15;

		// Token: 0x04011E5E RID: 73310
		internal static int __PropertyOffset_16;

		// Token: 0x04011E5F RID: 73311
		internal static int __PropertyOffset_17;

		// Token: 0x04011E60 RID: 73312
		internal static int __PropertyOffset_18;

		// Token: 0x04011E61 RID: 73313
		internal static int __PropertyOffset_19;

		// Token: 0x04011E62 RID: 73314
		internal static int __PropertyOffset_20;

		// Token: 0x04011E63 RID: 73315
		internal static int __PropertyOffset_21;

		// Token: 0x04011E64 RID: 73316
		internal static int __PropertyOffset_22;

		// Token: 0x04011E65 RID: 73317
		internal static int __PropertyOffset_23;

		// Token: 0x04011E66 RID: 73318
		internal static int __PropertyOffset_24;

		// Token: 0x04011E67 RID: 73319
		internal static int __PropertyOffset_25;

		// Token: 0x04011E68 RID: 73320
		internal static int __PropertyOffset_26;

		// Token: 0x04011E69 RID: 73321
		internal static int __PropertyOffset_27;

		// Token: 0x04011E6A RID: 73322
		internal static int __PropertyOffset_28;

		// Token: 0x04011E6B RID: 73323
		internal static int __PropertyOffset_29;

		// Token: 0x04011E6C RID: 73324
		internal static int __PropertyOffset_30;

		// Token: 0x04011E6D RID: 73325
		internal static int __PropertyOffset_31;

		// Token: 0x04011E6E RID: 73326
		internal static int __PropertyOffset_32;

		// Token: 0x04011E6F RID: 73327
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCSUnifiedCollider_genericCloth_33> _ColArr;

		// Token: 0x04011E70 RID: 73328
		internal static int __PropertyOffset_33;

		// Token: 0x04011E71 RID: 73329
		internal static int __PropertyOffset_34;

		// Token: 0x04011E72 RID: 73330
		internal static int __PropertyOffset_35;

		// Token: 0x04011E73 RID: 73331
		internal static int __PropertyOffset_36;

		// Token: 0x04011E74 RID: 73332
		internal static int __PropertyOffset_37;

		// Token: 0x04011E75 RID: 73333
		internal static int __PropertyOffset_38;

		// Token: 0x04011E76 RID: 73334
		internal static int __PropertyOffset_39;

		// Token: 0x04011E77 RID: 73335
		internal static int __PropertyOffset_40;

		// Token: 0x04011E78 RID: 73336
		internal static int __PropertyOffset_41;

		// Token: 0x04011E79 RID: 73337
		internal static int __PropertyOffset_42;

		// Token: 0x04011E7A RID: 73338
		internal static int __PropertyOffset_43;

		// Token: 0x04011E7B RID: 73339
		internal static int __PropertyOffset_44;

		// Token: 0x04011E7C RID: 73340
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UObject>> _Staticmesh;

		// Token: 0x04011E7D RID: 73341
		internal static int __PropertyOffset_45;

		// Token: 0x04011E7E RID: 73342
		internal static int __PropertyOffset_46;

		// Token: 0x04011E7F RID: 73343
		internal static int __PropertyOffset_47;

		// Token: 0x04011E80 RID: 73344
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _Staticmesh_0;

		// Token: 0x04011E81 RID: 73345
		internal static int __PropertyOffset_48;

		// Token: 0x04011E82 RID: 73346
		internal static int __PropertyOffset_49;

		// Token: 0x04011E83 RID: 73347
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011E84 RID: 73348
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011E85 RID: 73349
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011E86 RID: 73350
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011E87 RID: 73351
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E88 RID: 73352
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E89 RID: 73353
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011E8A RID: 73354
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011E8B RID: 73355
		private static IntPtr __SetDeadNode_NativeFunctionPtr;

		// Token: 0x04011E8C RID: 73356
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011E8D RID: 73357
		private static IntPtr __ExecuteUbergraph_BP_genCloth_33_cut_NativeFunctionPtr;

		// Token: 0x02009CAB RID: 40107
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040325F1 RID: 206321
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CAC RID: 40108
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040325F2 RID: 206322
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009CAD RID: 40109
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325F3 RID: 206323
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x040325F4 RID: 206324
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325F5 RID: 206325
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325F6 RID: 206326
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x040325F7 RID: 206327
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009CAE RID: 40110
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325F8 RID: 206328
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325F9 RID: 206329
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325FA RID: 206330
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325FB RID: 206331
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040325FC RID: 206332
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040325FD RID: 206333
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CAF RID: 40111
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325FE RID: 206334
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325FF RID: 206335
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032600 RID: 206336
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032601 RID: 206337
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CB0 RID: 40112
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032602 RID: 206338
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032603 RID: 206339
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032604 RID: 206340
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009CB1 RID: 40113
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3184)]
		protected ref struct __ExecuteUbergraph_BP_genCloth_33_cut_FunctionParams
		{
			// Token: 0x04032605 RID: 206341
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
