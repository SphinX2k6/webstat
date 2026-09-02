using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BPWindBell
{
	// Token: 0x02003C3C RID: 15420
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BPWindBell/BP_Windbell_35_type2.BP_Windbell_35_type2_C")]
	[UnrealStructLayout(1624, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1620)]
	public class BP_Windbell_35_type2_C : AKuroPhysicActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060236C2 RID: 145090 RVA: 0x0098197F File Offset: 0x0097FB7F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Windbell_35_type2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BPWindBell/BP_Windbell_35_type2.BP_Windbell_35_type2_C");
			}
			return BP_Windbell_35_type2_C._ClassPtr;
		}

		// Token: 0x060236C3 RID: 145091 RVA: 0x009819A4 File Offset: 0x0097FBA4
		public BP_Windbell_35_type2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Windbell_35_type2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060236C4 RID: 145092 RVA: 0x009819CC File Offset: 0x0097FBCC
		[NullableContext(1)]
		public BP_Windbell_35_type2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Windbell_35_type2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004658 RID: 18008
		// (get) Token: 0x060236C5 RID: 145093 RVA: 0x00981A00 File Offset: 0x0097FC00
		// (set) Token: 0x060236C6 RID: 145094 RVA: 0x00981A39 File Offset: 0x0097FC39
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004659 RID: 18009
		// (get) Token: 0x060236C7 RID: 145095 RVA: 0x00981A5A File Offset: 0x0097FC5A
		// (set) Token: 0x060236C8 RID: 145096 RVA: 0x00981A6E File Offset: 0x0097FC6E
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700465A RID: 18010
		// (get) Token: 0x060236C9 RID: 145097 RVA: 0x00981A83 File Offset: 0x0097FC83
		// (set) Token: 0x060236CA RID: 145098 RVA: 0x00981A97 File Offset: 0x0097FC97
		public unsafe UStaticMeshComponent Box_main
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700465B RID: 18011
		// (get) Token: 0x060236CB RID: 145099 RVA: 0x00981AAC File Offset: 0x0097FCAC
		// (set) Token: 0x060236CC RID: 145100 RVA: 0x00981AC0 File Offset: 0x0097FCC0
		public unsafe UStaticMeshComponent SM_windbell_t2_box_9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700465C RID: 18012
		// (get) Token: 0x060236CD RID: 145101 RVA: 0x00981AD5 File Offset: 0x0097FCD5
		// (set) Token: 0x060236CE RID: 145102 RVA: 0x00981AE9 File Offset: 0x0097FCE9
		public unsafe UStaticMeshComponent SM_windbell_t2_box_8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700465D RID: 18013
		// (get) Token: 0x060236CF RID: 145103 RVA: 0x00981AFE File Offset: 0x0097FCFE
		// (set) Token: 0x060236D0 RID: 145104 RVA: 0x00981B12 File Offset: 0x0097FD12
		public unsafe UStaticMeshComponent SM_windbell_t2_box_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700465E RID: 18014
		// (get) Token: 0x060236D1 RID: 145105 RVA: 0x00981B27 File Offset: 0x0097FD27
		// (set) Token: 0x060236D2 RID: 145106 RVA: 0x00981B3B File Offset: 0x0097FD3B
		public unsafe UStaticMeshComponent SM_windbell_t2_box_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700465F RID: 18015
		// (get) Token: 0x060236D3 RID: 145107 RVA: 0x00981B50 File Offset: 0x0097FD50
		// (set) Token: 0x060236D4 RID: 145108 RVA: 0x00981B64 File Offset: 0x0097FD64
		public unsafe UStaticMeshComponent SM_windbell_t2_box_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004660 RID: 18016
		// (get) Token: 0x060236D5 RID: 145109 RVA: 0x00981B79 File Offset: 0x0097FD79
		// (set) Token: 0x060236D6 RID: 145110 RVA: 0x00981B8D File Offset: 0x0097FD8D
		public unsafe UStaticMeshComponent SM_windbell_t2_box_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004661 RID: 18017
		// (get) Token: 0x060236D7 RID: 145111 RVA: 0x00981BA2 File Offset: 0x0097FDA2
		// (set) Token: 0x060236D8 RID: 145112 RVA: 0x00981BB6 File Offset: 0x0097FDB6
		public unsafe UStaticMeshComponent SM_windbell_t2_box_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004662 RID: 18018
		// (get) Token: 0x060236D9 RID: 145113 RVA: 0x00981BCB File Offset: 0x0097FDCB
		// (set) Token: 0x060236DA RID: 145114 RVA: 0x00981BDF File Offset: 0x0097FDDF
		public unsafe UStaticMeshComponent SM_windbell_t2_box_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004663 RID: 18019
		// (get) Token: 0x060236DB RID: 145115 RVA: 0x00981BF4 File Offset: 0x0097FDF4
		// (set) Token: 0x060236DC RID: 145116 RVA: 0x00981C08 File Offset: 0x0097FE08
		public unsafe UStaticMeshComponent SM_windbell_t2_box_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004664 RID: 18020
		// (get) Token: 0x060236DD RID: 145117 RVA: 0x00981C1D File Offset: 0x0097FE1D
		// (set) Token: 0x060236DE RID: 145118 RVA: 0x00981C31 File Offset: 0x0097FE31
		public unsafe UStaticMeshComponent Box_main2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004665 RID: 18021
		// (get) Token: 0x060236DF RID: 145119 RVA: 0x00981C46 File Offset: 0x0097FE46
		// (set) Token: 0x060236E0 RID: 145120 RVA: 0x00981C5A File Offset: 0x0097FE5A
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004666 RID: 18022
		// (get) Token: 0x060236E1 RID: 145121 RVA: 0x00981C6F File Offset: 0x0097FE6F
		// (set) Token: 0x060236E2 RID: 145122 RVA: 0x00981C83 File Offset: 0x0097FE83
		public unsafe UCableComponent Cable_main
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004667 RID: 18023
		// (get) Token: 0x060236E3 RID: 145123 RVA: 0x00981C98 File Offset: 0x0097FE98
		// (set) Token: 0x060236E4 RID: 145124 RVA: 0x00981CAC File Offset: 0x0097FEAC
		public unsafe UPhysicsConstraintComponent PhysicsConstraint_main
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17004668 RID: 18024
		// (get) Token: 0x060236E5 RID: 145125 RVA: 0x00981CC1 File Offset: 0x0097FEC1
		// (set) Token: 0x060236E6 RID: 145126 RVA: 0x00981CD5 File Offset: 0x0097FED5
		public unsafe UCableComponent Cable5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004669 RID: 18025
		// (get) Token: 0x060236E7 RID: 145127 RVA: 0x00981CEA File Offset: 0x0097FEEA
		// (set) Token: 0x060236E8 RID: 145128 RVA: 0x00981CFE File Offset: 0x0097FEFE
		public unsafe UCableComponent Cable8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700466A RID: 18026
		// (get) Token: 0x060236E9 RID: 145129 RVA: 0x00981D13 File Offset: 0x0097FF13
		// (set) Token: 0x060236EA RID: 145130 RVA: 0x00981D27 File Offset: 0x0097FF27
		public unsafe UCableComponent Cable7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700466B RID: 18027
		// (get) Token: 0x060236EB RID: 145131 RVA: 0x00981D3C File Offset: 0x0097FF3C
		// (set) Token: 0x060236EC RID: 145132 RVA: 0x00981D50 File Offset: 0x0097FF50
		public unsafe UCableComponent Cable6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700466C RID: 18028
		// (get) Token: 0x060236ED RID: 145133 RVA: 0x00981D65 File Offset: 0x0097FF65
		// (set) Token: 0x060236EE RID: 145134 RVA: 0x00981D79 File Offset: 0x0097FF79
		public unsafe UCableComponent Cable4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x1700466D RID: 18029
		// (get) Token: 0x060236EF RID: 145135 RVA: 0x00981D8E File Offset: 0x0097FF8E
		// (set) Token: 0x060236F0 RID: 145136 RVA: 0x00981DA2 File Offset: 0x0097FFA2
		public unsafe UCableComponent Cable3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x1700466E RID: 18030
		// (get) Token: 0x060236F1 RID: 145137 RVA: 0x00981DB7 File Offset: 0x0097FFB7
		// (set) Token: 0x060236F2 RID: 145138 RVA: 0x00981DCB File Offset: 0x0097FFCB
		public unsafe UCableComponent Cable2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x1700466F RID: 18031
		// (get) Token: 0x060236F3 RID: 145139 RVA: 0x00981DE0 File Offset: 0x0097FFE0
		// (set) Token: 0x060236F4 RID: 145140 RVA: 0x00981DF4 File Offset: 0x0097FFF4
		public unsafe UCableComponent Cable1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004670 RID: 18032
		// (get) Token: 0x060236F5 RID: 145141 RVA: 0x00981E09 File Offset: 0x00980009
		// (set) Token: 0x060236F6 RID: 145142 RVA: 0x00981E1D File Offset: 0x0098001D
		public unsafe UPhysicsConstraintComponent PhysicsConstraint9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17004671 RID: 18033
		// (get) Token: 0x060236F7 RID: 145143 RVA: 0x00981E32 File Offset: 0x00980032
		// (set) Token: 0x060236F8 RID: 145144 RVA: 0x00981E46 File Offset: 0x00980046
		public unsafe UPhysicsConstraintComponent PhysicsConstraint8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004672 RID: 18034
		// (get) Token: 0x060236F9 RID: 145145 RVA: 0x00981E5B File Offset: 0x0098005B
		// (set) Token: 0x060236FA RID: 145146 RVA: 0x00981E6F File Offset: 0x0098006F
		public unsafe UPhysicsConstraintComponent PhysicsConstraint7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17004673 RID: 18035
		// (get) Token: 0x060236FB RID: 145147 RVA: 0x00981E84 File Offset: 0x00980084
		// (set) Token: 0x060236FC RID: 145148 RVA: 0x00981E98 File Offset: 0x00980098
		public unsafe UPhysicsConstraintComponent PhysicsConstraint6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004674 RID: 18036
		// (get) Token: 0x060236FD RID: 145149 RVA: 0x00981EAD File Offset: 0x009800AD
		// (set) Token: 0x060236FE RID: 145150 RVA: 0x00981EC1 File Offset: 0x009800C1
		public unsafe UBoxComponent Box1_Bend
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004675 RID: 18037
		// (get) Token: 0x060236FF RID: 145151 RVA: 0x00981ED6 File Offset: 0x009800D6
		// (set) Token: 0x06023700 RID: 145152 RVA: 0x00981EEA File Offset: 0x009800EA
		public unsafe UPhysicsConstraintComponent PhysicsConstraint
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17004676 RID: 18038
		// (get) Token: 0x06023701 RID: 145153 RVA: 0x00981EFF File Offset: 0x009800FF
		// (set) Token: 0x06023702 RID: 145154 RVA: 0x00981F13 File Offset: 0x00980113
		public unsafe UPhysicsConstraintComponent PhysicsConstraint5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17004677 RID: 18039
		// (get) Token: 0x06023703 RID: 145155 RVA: 0x00981F28 File Offset: 0x00980128
		// (set) Token: 0x06023704 RID: 145156 RVA: 0x00981F3C File Offset: 0x0098013C
		public unsafe UPhysicsConstraintComponent PhysicsConstraint4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17004678 RID: 18040
		// (get) Token: 0x06023705 RID: 145157 RVA: 0x00981F51 File Offset: 0x00980151
		// (set) Token: 0x06023706 RID: 145158 RVA: 0x00981F65 File Offset: 0x00980165
		public unsafe UPhysicsConstraintComponent PhysicsConstraint3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17004679 RID: 18041
		// (get) Token: 0x06023707 RID: 145159 RVA: 0x00981F7A File Offset: 0x0098017A
		// (set) Token: 0x06023708 RID: 145160 RVA: 0x00981F8E File Offset: 0x0098018E
		public unsafe UPhysicsConstraintComponent PhysicsConstraint2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type2_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x1700467A RID: 18042
		// (get) Token: 0x06023709 RID: 145161 RVA: 0x00981FA4 File Offset: 0x009801A4
		// (set) Token: 0x0602370A RID: 145162 RVA: 0x00981FDD File Offset: 0x009801DD
		[Nullable(1)]
		public TArray<UCableComponent> CablesArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UCableComponent> result;
				if ((result = this._CablesArr) == null)
				{
					result = (this._CablesArr = new TArray<UCableComponent>(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_34, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CablesArr.CopyAssign(value);
			}
		}

		// Token: 0x1700467B RID: 18043
		// (get) Token: 0x0602370B RID: 145163 RVA: 0x00981FEB File Offset: 0x009801EB
		// (set) Token: 0x0602370C RID: 145164 RVA: 0x00981FFB File Offset: 0x009801FB
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700467C RID: 18044
		// (get) Token: 0x0602370D RID: 145165 RVA: 0x0098200C File Offset: 0x0098020C
		// (set) Token: 0x0602370E RID: 145166 RVA: 0x0098201C File Offset: 0x0098021C
		public unsafe bool playerInRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700467D RID: 18045
		// (get) Token: 0x0602370F RID: 145167 RVA: 0x0098202D File Offset: 0x0098022D
		// (set) Token: 0x06023710 RID: 145168 RVA: 0x0098203D File Offset: 0x0098023D
		public unsafe bool alreadySimulate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700467E RID: 18046
		// (get) Token: 0x06023711 RID: 145169 RVA: 0x00982050 File Offset: 0x00980250
		// (set) Token: 0x06023712 RID: 145170 RVA: 0x00982089 File Offset: 0x00980289
		[Nullable(1)]
		public TArray<UStaticMeshComponent> SMsArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._SMsArr) == null)
				{
					result = (this._SMsArr = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_38, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMsArr.CopyAssign(value);
			}
		}

		// Token: 0x1700467F RID: 18047
		// (get) Token: 0x06023713 RID: 145171 RVA: 0x00982097 File Offset: 0x00980297
		// (set) Token: 0x06023714 RID: 145172 RVA: 0x009820A7 File Offset: 0x009802A7
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type2_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x06023715 RID: 145173 RVA: 0x009820B8 File Offset: 0x009802B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023716 RID: 145174 RVA: 0x009820CC File Offset: 0x009802CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023717 RID: 145175 RVA: 0x009820E4 File Offset: 0x009802E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Windbell_35_type2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023718 RID: 145176 RVA: 0x0098212C File Offset: 0x0098032C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Windbell_35_type2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023719 RID: 145177 RVA: 0x00982173 File Offset: 0x00980373
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ClosePhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ClosePhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x0602371A RID: 145178 RVA: 0x00982187 File Offset: 0x00980387
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ClosePhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ClosePhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602371B RID: 145179 RVA: 0x0098219C File Offset: 0x0098039C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OpenPhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__OpenPhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x0602371C RID: 145180 RVA: 0x009821B0 File Offset: 0x009803B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OpenPhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type2_C.__OpenPhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602371D RID: 145181 RVA: 0x009821C8 File Offset: 0x009803C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602371E RID: 145182 RVA: 0x00982284 File Offset: 0x00980484
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602371F RID: 145183 RVA: 0x00982310 File Offset: 0x00980510
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnApplyWorldOffset(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_Windbell_35_type2_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type2_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023720 RID: 145184 RVA: 0x00982364 File Offset: 0x00980564
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnApplyWorldOffset_Implementation(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_Windbell_35_type2_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type2_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023721 RID: 145185 RVA: 0x009823B8 File Offset: 0x009805B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Windbell_35_type2(int EntryPoint)
		{
			BP_Windbell_35_type2_C.__ExecuteUbergraph_BP_Windbell_35_type2_FunctionParams* ptr = stackalloc BP_Windbell_35_type2_C.__ExecuteUbergraph_BP_Windbell_35_type2_FunctionParams[(UIntPtr)719] + 15L / (long)sizeof(BP_Windbell_35_type2_C.__ExecuteUbergraph_BP_Windbell_35_type2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type2_C.__ExecuteUbergraph_BP_Windbell_35_type2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type2_C.__ExecuteUbergraph_BP_Windbell_35_type2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023722 RID: 145186 RVA: 0x00982402 File Offset: 0x00980602
		protected BP_Windbell_35_type2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401207C RID: 73852
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BPWindBell/BP_Windbell_35_type2.BP_Windbell_35_type2_C";

		// Token: 0x0401207D RID: 73853
		private static IntPtr _ClassPtr;

		// Token: 0x0401207E RID: 73854
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401207F RID: 73855
		internal static int __PropertyOffset_0;

		// Token: 0x04012080 RID: 73856
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012081 RID: 73857
		internal static int __PropertyOffset_1;

		// Token: 0x04012082 RID: 73858
		internal static int __PropertyOffset_2;

		// Token: 0x04012083 RID: 73859
		internal static int __PropertyOffset_3;

		// Token: 0x04012084 RID: 73860
		internal static int __PropertyOffset_4;

		// Token: 0x04012085 RID: 73861
		internal static int __PropertyOffset_5;

		// Token: 0x04012086 RID: 73862
		internal static int __PropertyOffset_6;

		// Token: 0x04012087 RID: 73863
		internal static int __PropertyOffset_7;

		// Token: 0x04012088 RID: 73864
		internal static int __PropertyOffset_8;

		// Token: 0x04012089 RID: 73865
		internal static int __PropertyOffset_9;

		// Token: 0x0401208A RID: 73866
		internal static int __PropertyOffset_10;

		// Token: 0x0401208B RID: 73867
		internal static int __PropertyOffset_11;

		// Token: 0x0401208C RID: 73868
		internal static int __PropertyOffset_12;

		// Token: 0x0401208D RID: 73869
		internal static int __PropertyOffset_13;

		// Token: 0x0401208E RID: 73870
		internal static int __PropertyOffset_14;

		// Token: 0x0401208F RID: 73871
		internal static int __PropertyOffset_15;

		// Token: 0x04012090 RID: 73872
		internal static int __PropertyOffset_16;

		// Token: 0x04012091 RID: 73873
		internal static int __PropertyOffset_17;

		// Token: 0x04012092 RID: 73874
		internal static int __PropertyOffset_18;

		// Token: 0x04012093 RID: 73875
		internal static int __PropertyOffset_19;

		// Token: 0x04012094 RID: 73876
		internal static int __PropertyOffset_20;

		// Token: 0x04012095 RID: 73877
		internal static int __PropertyOffset_21;

		// Token: 0x04012096 RID: 73878
		internal static int __PropertyOffset_22;

		// Token: 0x04012097 RID: 73879
		internal static int __PropertyOffset_23;

		// Token: 0x04012098 RID: 73880
		internal static int __PropertyOffset_24;

		// Token: 0x04012099 RID: 73881
		internal static int __PropertyOffset_25;

		// Token: 0x0401209A RID: 73882
		internal static int __PropertyOffset_26;

		// Token: 0x0401209B RID: 73883
		internal static int __PropertyOffset_27;

		// Token: 0x0401209C RID: 73884
		internal static int __PropertyOffset_28;

		// Token: 0x0401209D RID: 73885
		internal static int __PropertyOffset_29;

		// Token: 0x0401209E RID: 73886
		internal static int __PropertyOffset_30;

		// Token: 0x0401209F RID: 73887
		internal static int __PropertyOffset_31;

		// Token: 0x040120A0 RID: 73888
		internal static int __PropertyOffset_32;

		// Token: 0x040120A1 RID: 73889
		internal static int __PropertyOffset_33;

		// Token: 0x040120A2 RID: 73890
		internal static int __PropertyOffset_34;

		// Token: 0x040120A3 RID: 73891
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UCableComponent> _CablesArr;

		// Token: 0x040120A4 RID: 73892
		internal static int __PropertyOffset_35;

		// Token: 0x040120A5 RID: 73893
		internal static int __PropertyOffset_36;

		// Token: 0x040120A6 RID: 73894
		internal static int __PropertyOffset_37;

		// Token: 0x040120A7 RID: 73895
		internal static int __PropertyOffset_38;

		// Token: 0x040120A8 RID: 73896
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMsArr;

		// Token: 0x040120A9 RID: 73897
		internal static int __PropertyOffset_39;

		// Token: 0x040120AA RID: 73898
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040120AB RID: 73899
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040120AC RID: 73900
		private static IntPtr __ClosePhysicsVisibility_NativeFunctionPtr;

		// Token: 0x040120AD RID: 73901
		private static IntPtr __OpenPhysicsVisibility_NativeFunctionPtr;

		// Token: 0x040120AE RID: 73902
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040120AF RID: 73903
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040120B0 RID: 73904
		private static IntPtr __OnApplyWorldOffset_NativeFunctionPtr;

		// Token: 0x040120B1 RID: 73905
		private static IntPtr __ExecuteUbergraph_BP_Windbell_35_type2_NativeFunctionPtr;

		// Token: 0x02009CDC RID: 40156
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032658 RID: 206424
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CDD RID: 40157
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032659 RID: 206425
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403265A RID: 206426
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403265B RID: 206427
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403265C RID: 206428
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403265D RID: 206429
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403265E RID: 206430
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CDE RID: 40158
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403265F RID: 206431
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032660 RID: 206432
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032661 RID: 206433
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032662 RID: 206434
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CDF RID: 40159
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnApplyWorldOffset_FunctionParams
		{
			// Token: 0x04032663 RID: 206435
			[FieldOffset(0)]
			public FVector InWorldOffset;

			// Token: 0x04032664 RID: 206436
			[FieldOffset(12)]
			public bool bWorldShift;
		}

		// Token: 0x02009CE0 RID: 40160
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 704)]
		protected ref struct __ExecuteUbergraph_BP_Windbell_35_type2_FunctionParams
		{
			// Token: 0x04032665 RID: 206437
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
