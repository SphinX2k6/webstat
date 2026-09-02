using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BPWindBell
{
	// Token: 0x02003C3B RID: 15419
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BPWindBell/BP_Windbell_35_type1.BP_Windbell_35_type1_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class BP_Windbell_35_type1_C : AKuroPhysicActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023675 RID: 145013 RVA: 0x0098108F File Offset: 0x0097F28F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Windbell_35_type1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BPWindBell/BP_Windbell_35_type1.BP_Windbell_35_type1_C");
			}
			return BP_Windbell_35_type1_C._ClassPtr;
		}

		// Token: 0x06023676 RID: 145014 RVA: 0x009810B4 File Offset: 0x0097F2B4
		public BP_Windbell_35_type1_C() : this(BuiltinUtils.AllocNativeUObject(BP_Windbell_35_type1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023677 RID: 145015 RVA: 0x009810DC File Offset: 0x0097F2DC
		[NullableContext(1)]
		public BP_Windbell_35_type1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Windbell_35_type1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700463A RID: 17978
		// (get) Token: 0x06023678 RID: 145016 RVA: 0x00981110 File Offset: 0x0097F310
		// (set) Token: 0x06023679 RID: 145017 RVA: 0x00981149 File Offset: 0x0097F349
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700463B RID: 17979
		// (get) Token: 0x0602367A RID: 145018 RVA: 0x0098116A File Offset: 0x0097F36A
		// (set) Token: 0x0602367B RID: 145019 RVA: 0x0098117E File Offset: 0x0097F37E
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700463C RID: 17980
		// (get) Token: 0x0602367C RID: 145020 RVA: 0x00981193 File Offset: 0x0097F393
		// (set) Token: 0x0602367D RID: 145021 RVA: 0x009811A7 File Offset: 0x0097F3A7
		public unsafe UCableComponent Cable6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700463D RID: 17981
		// (get) Token: 0x0602367E RID: 145022 RVA: 0x009811BC File Offset: 0x0097F3BC
		// (set) Token: 0x0602367F RID: 145023 RVA: 0x009811D0 File Offset: 0x0097F3D0
		public unsafe UStaticMeshComponent Box3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700463E RID: 17982
		// (get) Token: 0x06023680 RID: 145024 RVA: 0x009811E5 File Offset: 0x0097F3E5
		// (set) Token: 0x06023681 RID: 145025 RVA: 0x009811F9 File Offset: 0x0097F3F9
		public unsafe UStaticMeshComponent Box4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700463F RID: 17983
		// (get) Token: 0x06023682 RID: 145026 RVA: 0x0098120E File Offset: 0x0097F40E
		// (set) Token: 0x06023683 RID: 145027 RVA: 0x00981222 File Offset: 0x0097F422
		public unsafe UStaticMeshComponent Box1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004640 RID: 17984
		// (get) Token: 0x06023684 RID: 145028 RVA: 0x00981237 File Offset: 0x0097F437
		// (set) Token: 0x06023685 RID: 145029 RVA: 0x0098124B File Offset: 0x0097F44B
		public unsafe UStaticMeshComponent Box2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004641 RID: 17985
		// (get) Token: 0x06023686 RID: 145030 RVA: 0x00981260 File Offset: 0x0097F460
		// (set) Token: 0x06023687 RID: 145031 RVA: 0x00981274 File Offset: 0x0097F474
		public unsafe UStaticMeshComponent Box5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004642 RID: 17986
		// (get) Token: 0x06023688 RID: 145032 RVA: 0x00981289 File Offset: 0x0097F489
		// (set) Token: 0x06023689 RID: 145033 RVA: 0x0098129D File Offset: 0x0097F49D
		public unsafe UStaticMeshComponent Box_main2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004643 RID: 17987
		// (get) Token: 0x0602368A RID: 145034 RVA: 0x009812B2 File Offset: 0x0097F4B2
		// (set) Token: 0x0602368B RID: 145035 RVA: 0x009812C6 File Offset: 0x0097F4C6
		public unsafe UStaticMeshComponent Box_main
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004644 RID: 17988
		// (get) Token: 0x0602368C RID: 145036 RVA: 0x009812DB File Offset: 0x0097F4DB
		// (set) Token: 0x0602368D RID: 145037 RVA: 0x009812EF File Offset: 0x0097F4EF
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004645 RID: 17989
		// (get) Token: 0x0602368E RID: 145038 RVA: 0x00981304 File Offset: 0x0097F504
		// (set) Token: 0x0602368F RID: 145039 RVA: 0x00981318 File Offset: 0x0097F518
		public unsafe UCableComponent Cable3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004646 RID: 17990
		// (get) Token: 0x06023690 RID: 145040 RVA: 0x0098132D File Offset: 0x0097F52D
		// (set) Token: 0x06023691 RID: 145041 RVA: 0x00981341 File Offset: 0x0097F541
		public unsafe UCableComponent Cable4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004647 RID: 17991
		// (get) Token: 0x06023692 RID: 145042 RVA: 0x00981356 File Offset: 0x0097F556
		// (set) Token: 0x06023693 RID: 145043 RVA: 0x0098136A File Offset: 0x0097F56A
		public unsafe UCableComponent Cable5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004648 RID: 17992
		// (get) Token: 0x06023694 RID: 145044 RVA: 0x0098137F File Offset: 0x0097F57F
		// (set) Token: 0x06023695 RID: 145045 RVA: 0x00981393 File Offset: 0x0097F593
		public unsafe UCableComponent Cable2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004649 RID: 17993
		// (get) Token: 0x06023696 RID: 145046 RVA: 0x009813A8 File Offset: 0x0097F5A8
		// (set) Token: 0x06023697 RID: 145047 RVA: 0x009813BC File Offset: 0x0097F5BC
		public unsafe UCableComponent Cable
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCableComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700464A RID: 17994
		// (get) Token: 0x06023698 RID: 145048 RVA: 0x009813D1 File Offset: 0x0097F5D1
		// (set) Token: 0x06023699 RID: 145049 RVA: 0x009813E5 File Offset: 0x0097F5E5
		public unsafe UPhysicsConstraintComponent PhysicsConstraint_main
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700464B RID: 17995
		// (get) Token: 0x0602369A RID: 145050 RVA: 0x009813FA File Offset: 0x0097F5FA
		// (set) Token: 0x0602369B RID: 145051 RVA: 0x0098140E File Offset: 0x0097F60E
		public unsafe UBoxComponent Box1_Bend
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700464C RID: 17996
		// (get) Token: 0x0602369C RID: 145052 RVA: 0x00981423 File Offset: 0x0097F623
		// (set) Token: 0x0602369D RID: 145053 RVA: 0x00981437 File Offset: 0x0097F637
		public unsafe UPhysicsConstraintComponent PhysicsConstraint5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700464D RID: 17997
		// (get) Token: 0x0602369E RID: 145054 RVA: 0x0098144C File Offset: 0x0097F64C
		// (set) Token: 0x0602369F RID: 145055 RVA: 0x00981460 File Offset: 0x0097F660
		public unsafe UPhysicsConstraintComponent PhysicsConstraint4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700464E RID: 17998
		// (get) Token: 0x060236A0 RID: 145056 RVA: 0x00981475 File Offset: 0x0097F675
		// (set) Token: 0x060236A1 RID: 145057 RVA: 0x00981489 File Offset: 0x0097F689
		public unsafe UPhysicsConstraintComponent PhysicsConstraint3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x1700464F RID: 17999
		// (get) Token: 0x060236A2 RID: 145058 RVA: 0x0098149E File Offset: 0x0097F69E
		// (set) Token: 0x060236A3 RID: 145059 RVA: 0x009814B2 File Offset: 0x0097F6B2
		public unsafe UPhysicsConstraintComponent PhysicsConstraint2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004650 RID: 18000
		// (get) Token: 0x060236A4 RID: 145060 RVA: 0x009814C7 File Offset: 0x0097F6C7
		// (set) Token: 0x060236A5 RID: 145061 RVA: 0x009814DB File Offset: 0x0097F6DB
		public unsafe UPhysicsConstraintComponent PhysicsConstraint
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Windbell_35_type1_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004651 RID: 18001
		// (get) Token: 0x060236A6 RID: 145062 RVA: 0x009814F0 File Offset: 0x0097F6F0
		// (set) Token: 0x060236A7 RID: 145063 RVA: 0x00981500 File Offset: 0x0097F700
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004652 RID: 18002
		// (get) Token: 0x060236A8 RID: 145064 RVA: 0x00981514 File Offset: 0x0097F714
		// (set) Token: 0x060236A9 RID: 145065 RVA: 0x0098154D File Offset: 0x0097F74D
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
					result = (this._CablesArr = new TArray<UCableComponent>(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_24, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CablesArr.CopyAssign(value);
			}
		}

		// Token: 0x17004653 RID: 18003
		// (get) Token: 0x060236AA RID: 145066 RVA: 0x0098155B File Offset: 0x0097F75B
		// (set) Token: 0x060236AB RID: 145067 RVA: 0x0098156B File Offset: 0x0097F76B
		public unsafe bool playerInRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004654 RID: 18004
		// (get) Token: 0x060236AC RID: 145068 RVA: 0x0098157C File Offset: 0x0097F77C
		// (set) Token: 0x060236AD RID: 145069 RVA: 0x0098158C File Offset: 0x0097F78C
		public unsafe bool alreadySimulate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004655 RID: 18005
		// (get) Token: 0x060236AE RID: 145070 RVA: 0x009815A0 File Offset: 0x0097F7A0
		// (set) Token: 0x060236AF RID: 145071 RVA: 0x009815D9 File Offset: 0x0097F7D9
		[Nullable(1)]
		public TArray<UStaticMeshComponent> SMCArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._SMCArr) == null)
				{
					result = (this._SMCArr = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMCArr.CopyAssign(value);
			}
		}

		// Token: 0x17004656 RID: 18006
		// (get) Token: 0x060236B0 RID: 145072 RVA: 0x009815E7 File Offset: 0x0097F7E7
		// (set) Token: 0x060236B1 RID: 145073 RVA: 0x009815F7 File Offset: 0x0097F7F7
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004657 RID: 18007
		// (get) Token: 0x060236B2 RID: 145074 RVA: 0x00981608 File Offset: 0x0097F808
		// (set) Token: 0x060236B3 RID: 145075 RVA: 0x0098161C File Offset: 0x0097F81C
		public unsafe FVector worldPositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Windbell_35_type1_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x060236B4 RID: 145076 RVA: 0x00981631 File Offset: 0x0097F831
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060236B5 RID: 145077 RVA: 0x00981645 File Offset: 0x0097F845
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060236B6 RID: 145078 RVA: 0x0098165C File Offset: 0x0097F85C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Windbell_35_type1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060236B7 RID: 145079 RVA: 0x009816A4 File Offset: 0x0097F8A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Windbell_35_type1_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060236B8 RID: 145080 RVA: 0x009816EC File Offset: 0x0097F8EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060236B9 RID: 145081 RVA: 0x009817A8 File Offset: 0x0097F9A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060236BA RID: 145082 RVA: 0x00981831 File Offset: 0x0097FA31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ClosePhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ClosePhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x060236BB RID: 145083 RVA: 0x00981845 File Offset: 0x0097FA45
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ClosePhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ClosePhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060236BC RID: 145084 RVA: 0x0098185A File Offset: 0x0097FA5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OpenPhysicsVisibility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__OpenPhysicsVisibility_NativeFunctionPtr, null);
		}

		// Token: 0x060236BD RID: 145085 RVA: 0x0098186E File Offset: 0x0097FA6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OpenPhysicsVisibility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type1_C.__OpenPhysicsVisibility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060236BE RID: 145086 RVA: 0x00981884 File Offset: 0x0097FA84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnApplyWorldOffset(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_Windbell_35_type1_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Windbell_35_type1_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060236BF RID: 145087 RVA: 0x009818D8 File Offset: 0x0097FAD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnApplyWorldOffset_Implementation(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_Windbell_35_type1_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type1_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060236C0 RID: 145088 RVA: 0x0098192C File Offset: 0x0097FB2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Windbell_35_type1(int EntryPoint)
		{
			BP_Windbell_35_type1_C.__ExecuteUbergraph_BP_Windbell_35_type1_FunctionParams* ptr = stackalloc BP_Windbell_35_type1_C.__ExecuteUbergraph_BP_Windbell_35_type1_FunctionParams[(UIntPtr)743] + 15L / (long)sizeof(BP_Windbell_35_type1_C.__ExecuteUbergraph_BP_Windbell_35_type1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Windbell_35_type1_C.__ExecuteUbergraph_BP_Windbell_35_type1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Windbell_35_type1_C.__ExecuteUbergraph_BP_Windbell_35_type1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060236C1 RID: 145089 RVA: 0x00981976 File Offset: 0x0097FB76
		protected BP_Windbell_35_type1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012050 RID: 73808
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BPWindBell/BP_Windbell_35_type1.BP_Windbell_35_type1_C";

		// Token: 0x04012051 RID: 73809
		private static IntPtr _ClassPtr;

		// Token: 0x04012052 RID: 73810
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012053 RID: 73811
		internal static int __PropertyOffset_0;

		// Token: 0x04012054 RID: 73812
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012055 RID: 73813
		internal static int __PropertyOffset_1;

		// Token: 0x04012056 RID: 73814
		internal static int __PropertyOffset_2;

		// Token: 0x04012057 RID: 73815
		internal static int __PropertyOffset_3;

		// Token: 0x04012058 RID: 73816
		internal static int __PropertyOffset_4;

		// Token: 0x04012059 RID: 73817
		internal static int __PropertyOffset_5;

		// Token: 0x0401205A RID: 73818
		internal static int __PropertyOffset_6;

		// Token: 0x0401205B RID: 73819
		internal static int __PropertyOffset_7;

		// Token: 0x0401205C RID: 73820
		internal static int __PropertyOffset_8;

		// Token: 0x0401205D RID: 73821
		internal static int __PropertyOffset_9;

		// Token: 0x0401205E RID: 73822
		internal static int __PropertyOffset_10;

		// Token: 0x0401205F RID: 73823
		internal static int __PropertyOffset_11;

		// Token: 0x04012060 RID: 73824
		internal static int __PropertyOffset_12;

		// Token: 0x04012061 RID: 73825
		internal static int __PropertyOffset_13;

		// Token: 0x04012062 RID: 73826
		internal static int __PropertyOffset_14;

		// Token: 0x04012063 RID: 73827
		internal static int __PropertyOffset_15;

		// Token: 0x04012064 RID: 73828
		internal static int __PropertyOffset_16;

		// Token: 0x04012065 RID: 73829
		internal static int __PropertyOffset_17;

		// Token: 0x04012066 RID: 73830
		internal static int __PropertyOffset_18;

		// Token: 0x04012067 RID: 73831
		internal static int __PropertyOffset_19;

		// Token: 0x04012068 RID: 73832
		internal static int __PropertyOffset_20;

		// Token: 0x04012069 RID: 73833
		internal static int __PropertyOffset_21;

		// Token: 0x0401206A RID: 73834
		internal static int __PropertyOffset_22;

		// Token: 0x0401206B RID: 73835
		internal static int __PropertyOffset_23;

		// Token: 0x0401206C RID: 73836
		internal static int __PropertyOffset_24;

		// Token: 0x0401206D RID: 73837
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UCableComponent> _CablesArr;

		// Token: 0x0401206E RID: 73838
		internal static int __PropertyOffset_25;

		// Token: 0x0401206F RID: 73839
		internal static int __PropertyOffset_26;

		// Token: 0x04012070 RID: 73840
		internal static int __PropertyOffset_27;

		// Token: 0x04012071 RID: 73841
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMCArr;

		// Token: 0x04012072 RID: 73842
		internal static int __PropertyOffset_28;

		// Token: 0x04012073 RID: 73843
		internal static int __PropertyOffset_29;

		// Token: 0x04012074 RID: 73844
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012075 RID: 73845
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012076 RID: 73846
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012077 RID: 73847
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012078 RID: 73848
		private static IntPtr __ClosePhysicsVisibility_NativeFunctionPtr;

		// Token: 0x04012079 RID: 73849
		private static IntPtr __OpenPhysicsVisibility_NativeFunctionPtr;

		// Token: 0x0401207A RID: 73850
		private static IntPtr __OnApplyWorldOffset_NativeFunctionPtr;

		// Token: 0x0401207B RID: 73851
		private static IntPtr __ExecuteUbergraph_BP_Windbell_35_type1_NativeFunctionPtr;

		// Token: 0x02009CD7 RID: 40151
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403264A RID: 206410
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CD8 RID: 40152
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403264B RID: 206411
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403264C RID: 206412
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403264D RID: 206413
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403264E RID: 206414
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403264F RID: 206415
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032650 RID: 206416
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CD9 RID: 40153
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032651 RID: 206417
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032652 RID: 206418
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032653 RID: 206419
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032654 RID: 206420
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CDA RID: 40154
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnApplyWorldOffset_FunctionParams
		{
			// Token: 0x04032655 RID: 206421
			[FieldOffset(0)]
			public FVector InWorldOffset;

			// Token: 0x04032656 RID: 206422
			[FieldOffset(12)]
			public bool bWorldShift;
		}

		// Token: 0x02009CDB RID: 40155
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 728)]
		protected ref struct __ExecuteUbergraph_BP_Windbell_35_type1_FunctionParams
		{
			// Token: 0x04032657 RID: 206423
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
