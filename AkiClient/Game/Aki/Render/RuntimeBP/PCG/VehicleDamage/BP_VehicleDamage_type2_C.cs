using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.VehicleDamage
{
	// Token: 0x02003B61 RID: 15201
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage_type2.BP_VehicleDamage_type2_C")]
	[UnrealStructLayout(2560, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2556)]
	public class BP_VehicleDamage_type2_C : AKuroVehicleDestructionActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602155F RID: 136543 RVA: 0x0094658B File Offset: 0x0094478B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VehicleDamage_type2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage_type2.BP_VehicleDamage_type2_C");
			}
			return BP_VehicleDamage_type2_C._ClassPtr;
		}

		// Token: 0x06021560 RID: 136544 RVA: 0x009465B0 File Offset: 0x009447B0
		public BP_VehicleDamage_type2_C() : this(BuiltinUtils.AllocNativeUObject(BP_VehicleDamage_type2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021561 RID: 136545 RVA: 0x009465D8 File Offset: 0x009447D8
		[NullableContext(1)]
		public BP_VehicleDamage_type2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VehicleDamage_type2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003A8B RID: 14987
		// (get) Token: 0x06021562 RID: 136546 RVA: 0x0094660C File Offset: 0x0094480C
		// (set) Token: 0x06021563 RID: 136547 RVA: 0x00946645 File Offset: 0x00944845
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003A8C RID: 14988
		// (get) Token: 0x06021564 RID: 136548 RVA: 0x00946666 File Offset: 0x00944866
		// (set) Token: 0x06021565 RID: 136549 RVA: 0x0094667A File Offset: 0x0094487A
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003A8D RID: 14989
		// (get) Token: 0x06021566 RID: 136550 RVA: 0x0094668F File Offset: 0x0094488F
		// (set) Token: 0x06021567 RID: 136551 RVA: 0x009466A3 File Offset: 0x009448A3
		public unsafe UBoxComponent BoxTrigger
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003A8E RID: 14990
		// (get) Token: 0x06021568 RID: 136552 RVA: 0x009466B8 File Offset: 0x009448B8
		// (set) Token: 0x06021569 RID: 136553 RVA: 0x009466CC File Offset: 0x009448CC
		public unsafe UStaticMeshComponent blast_10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003A8F RID: 14991
		// (get) Token: 0x0602156A RID: 136554 RVA: 0x009466E1 File Offset: 0x009448E1
		// (set) Token: 0x0602156B RID: 136555 RVA: 0x009466F5 File Offset: 0x009448F5
		public unsafe UBoxComponent myCustomBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003A90 RID: 14992
		// (get) Token: 0x0602156C RID: 136556 RVA: 0x0094670A File Offset: 0x0094490A
		// (set) Token: 0x0602156D RID: 136557 RVA: 0x0094671E File Offset: 0x0094491E
		public unsafe UNiagaraComponent NS_VehicleFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003A91 RID: 14993
		// (get) Token: 0x0602156E RID: 136558 RVA: 0x00946733 File Offset: 0x00944933
		// (set) Token: 0x0602156F RID: 136559 RVA: 0x00946747 File Offset: 0x00944947
		public unsafe UNiagaraComponent NS_VehicleBloom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003A92 RID: 14994
		// (get) Token: 0x06021570 RID: 136560 RVA: 0x0094675C File Offset: 0x0094495C
		// (set) Token: 0x06021571 RID: 136561 RVA: 0x00946770 File Offset: 0x00944970
		public unsafe UBoxComponent ValidAttackBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003A93 RID: 14995
		// (get) Token: 0x06021572 RID: 136562 RVA: 0x00946785 File Offset: 0x00944985
		// (set) Token: 0x06021573 RID: 136563 RVA: 0x00946799 File Offset: 0x00944999
		public unsafe UNiagaraComponent NS_engineFly
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003A94 RID: 14996
		// (get) Token: 0x06021574 RID: 136564 RVA: 0x009467AE File Offset: 0x009449AE
		// (set) Token: 0x06021575 RID: 136565 RVA: 0x009467C2 File Offset: 0x009449C2
		public unsafe UStaticMeshComponent blast_small14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003A95 RID: 14997
		// (get) Token: 0x06021576 RID: 136566 RVA: 0x009467D7 File Offset: 0x009449D7
		// (set) Token: 0x06021577 RID: 136567 RVA: 0x009467EB File Offset: 0x009449EB
		public unsafe UStaticMeshComponent blast_small10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003A96 RID: 14998
		// (get) Token: 0x06021578 RID: 136568 RVA: 0x00946800 File Offset: 0x00944A00
		// (set) Token: 0x06021579 RID: 136569 RVA: 0x00946814 File Offset: 0x00944A14
		public unsafe UStaticMeshComponent blast_small13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003A97 RID: 14999
		// (get) Token: 0x0602157A RID: 136570 RVA: 0x00946829 File Offset: 0x00944A29
		// (set) Token: 0x0602157B RID: 136571 RVA: 0x0094683D File Offset: 0x00944A3D
		public unsafe UStaticMeshComponent blast_small12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003A98 RID: 15000
		// (get) Token: 0x0602157C RID: 136572 RVA: 0x00946852 File Offset: 0x00944A52
		// (set) Token: 0x0602157D RID: 136573 RVA: 0x00946866 File Offset: 0x00944A66
		public unsafe UStaticMeshComponent blast_small11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003A99 RID: 15001
		// (get) Token: 0x0602157E RID: 136574 RVA: 0x0094687B File Offset: 0x00944A7B
		// (set) Token: 0x0602157F RID: 136575 RVA: 0x0094688F File Offset: 0x00944A8F
		public unsafe UStaticMeshComponent blast_small8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003A9A RID: 15002
		// (get) Token: 0x06021580 RID: 136576 RVA: 0x009468A4 File Offset: 0x00944AA4
		// (set) Token: 0x06021581 RID: 136577 RVA: 0x009468B8 File Offset: 0x00944AB8
		public unsafe UStaticMeshComponent blast_small9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003A9B RID: 15003
		// (get) Token: 0x06021582 RID: 136578 RVA: 0x009468CD File Offset: 0x00944ACD
		// (set) Token: 0x06021583 RID: 136579 RVA: 0x009468E1 File Offset: 0x00944AE1
		public unsafe UStaticMeshComponent blast_small7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003A9C RID: 15004
		// (get) Token: 0x06021584 RID: 136580 RVA: 0x009468F6 File Offset: 0x00944AF6
		// (set) Token: 0x06021585 RID: 136581 RVA: 0x0094690A File Offset: 0x00944B0A
		public unsafe UStaticMeshComponent blast_small5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003A9D RID: 15005
		// (get) Token: 0x06021586 RID: 136582 RVA: 0x0094691F File Offset: 0x00944B1F
		// (set) Token: 0x06021587 RID: 136583 RVA: 0x00946933 File Offset: 0x00944B33
		public unsafe UStaticMeshComponent blast_small6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003A9E RID: 15006
		// (get) Token: 0x06021588 RID: 136584 RVA: 0x00946948 File Offset: 0x00944B48
		// (set) Token: 0x06021589 RID: 136585 RVA: 0x0094695C File Offset: 0x00944B5C
		public unsafe UStaticMeshComponent blast_small2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003A9F RID: 15007
		// (get) Token: 0x0602158A RID: 136586 RVA: 0x00946971 File Offset: 0x00944B71
		// (set) Token: 0x0602158B RID: 136587 RVA: 0x00946985 File Offset: 0x00944B85
		public unsafe UStaticMeshComponent blast_small3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003AA0 RID: 15008
		// (get) Token: 0x0602158C RID: 136588 RVA: 0x0094699A File Offset: 0x00944B9A
		// (set) Token: 0x0602158D RID: 136589 RVA: 0x009469AE File Offset: 0x00944BAE
		public unsafe UStaticMeshComponent blast_small1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003AA1 RID: 15009
		// (get) Token: 0x0602158E RID: 136590 RVA: 0x009469C3 File Offset: 0x00944BC3
		// (set) Token: 0x0602158F RID: 136591 RVA: 0x009469D7 File Offset: 0x00944BD7
		public unsafe UPhysicsConstraintComponent cons_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003AA2 RID: 15010
		// (get) Token: 0x06021590 RID: 136592 RVA: 0x009469EC File Offset: 0x00944BEC
		// (set) Token: 0x06021591 RID: 136593 RVA: 0x00946A00 File Offset: 0x00944C00
		public unsafe UStaticMeshComponent blast_back_cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003AA3 RID: 15011
		// (get) Token: 0x06021592 RID: 136594 RVA: 0x00946A15 File Offset: 0x00944C15
		// (set) Token: 0x06021593 RID: 136595 RVA: 0x00946A29 File Offset: 0x00944C29
		public unsafe UStaticMeshComponent blast_wheel3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003AA4 RID: 15012
		// (get) Token: 0x06021594 RID: 136596 RVA: 0x00946A3E File Offset: 0x00944C3E
		// (set) Token: 0x06021595 RID: 136597 RVA: 0x00946A52 File Offset: 0x00944C52
		public unsafe UStaticMeshComponent blast_wheel2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003AA5 RID: 15013
		// (get) Token: 0x06021596 RID: 136598 RVA: 0x00946A67 File Offset: 0x00944C67
		// (set) Token: 0x06021597 RID: 136599 RVA: 0x00946A7B File Offset: 0x00944C7B
		public unsafe UStaticMeshComponent blast_wheel1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003AA6 RID: 15014
		// (get) Token: 0x06021598 RID: 136600 RVA: 0x00946A90 File Offset: 0x00944C90
		// (set) Token: 0x06021599 RID: 136601 RVA: 0x00946AA4 File Offset: 0x00944CA4
		public unsafe UStaticMeshComponent blast_wheel4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003AA7 RID: 15015
		// (get) Token: 0x0602159A RID: 136602 RVA: 0x00946AB9 File Offset: 0x00944CB9
		// (set) Token: 0x0602159B RID: 136603 RVA: 0x00946ACD File Offset: 0x00944CCD
		public unsafe UStaticMeshComponent blast_front_cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003AA8 RID: 15016
		// (get) Token: 0x0602159C RID: 136604 RVA: 0x00946AE2 File Offset: 0x00944CE2
		// (set) Token: 0x0602159D RID: 136605 RVA: 0x00946AF6 File Offset: 0x00944CF6
		public unsafe UPhysicsConstraintComponent cons_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003AA9 RID: 15017
		// (get) Token: 0x0602159E RID: 136606 RVA: 0x00946B0B File Offset: 0x00944D0B
		// (set) Token: 0x0602159F RID: 136607 RVA: 0x00946B1F File Offset: 0x00944D1F
		public unsafe UPhysicsConstraintComponent cons_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003AAA RID: 15018
		// (get) Token: 0x060215A0 RID: 136608 RVA: 0x00946B34 File Offset: 0x00944D34
		// (set) Token: 0x060215A1 RID: 136609 RVA: 0x00946B48 File Offset: 0x00944D48
		public unsafe UPhysicsConstraintComponent cons_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003AAB RID: 15019
		// (get) Token: 0x060215A2 RID: 136610 RVA: 0x00946B5D File Offset: 0x00944D5D
		// (set) Token: 0x060215A3 RID: 136611 RVA: 0x00946B71 File Offset: 0x00944D71
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003AAC RID: 15020
		// (get) Token: 0x060215A4 RID: 136612 RVA: 0x00946B86 File Offset: 0x00944D86
		// (set) Token: 0x060215A5 RID: 136613 RVA: 0x00946B9A File Offset: 0x00944D9A
		public unsafe UStaticMeshComponent SM_vehicleDamage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003AAD RID: 15021
		// (get) Token: 0x060215A6 RID: 136614 RVA: 0x00946BAF File Offset: 0x00944DAF
		// (set) Token: 0x060215A7 RID: 136615 RVA: 0x00946BC3 File Offset: 0x00944DC3
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003AAE RID: 15022
		// (get) Token: 0x060215A8 RID: 136616 RVA: 0x00946BD8 File Offset: 0x00944DD8
		// (set) Token: 0x060215A9 RID: 136617 RVA: 0x00946BEC File Offset: 0x00944DEC
		public unsafe UMaterialInstanceDynamic StampMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003AAF RID: 15023
		// (get) Token: 0x060215AA RID: 136618 RVA: 0x00946C04 File Offset: 0x00944E04
		// (set) Token: 0x060215AB RID: 136619 RVA: 0x00946C3D File Offset: 0x00944E3D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> CarAllMats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._CarAllMats) == null)
				{
					result = (this._CarAllMats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_36, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CarAllMats.CopyAssign(value);
			}
		}

		// Token: 0x17003AB0 RID: 15024
		// (get) Token: 0x060215AC RID: 136620 RVA: 0x00946C4B File Offset: 0x00944E4B
		// (set) Token: 0x060215AD RID: 136621 RVA: 0x00946C5F File Offset: 0x00944E5F
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003AB1 RID: 15025
		// (get) Token: 0x060215AE RID: 136622 RVA: 0x00946C74 File Offset: 0x00944E74
		// (set) Token: 0x060215AF RID: 136623 RVA: 0x00946C84 File Offset: 0x00944E84
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003AB2 RID: 15026
		// (get) Token: 0x060215B0 RID: 136624 RVA: 0x00946C95 File Offset: 0x00944E95
		// (set) Token: 0x060215B1 RID: 136625 RVA: 0x00946CA5 File Offset: 0x00944EA5
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003AB3 RID: 15027
		// (get) Token: 0x060215B2 RID: 136626 RVA: 0x00946CB6 File Offset: 0x00944EB6
		// (set) Token: 0x060215B3 RID: 136627 RVA: 0x00946CCA File Offset: 0x00944ECA
		public unsafe FVector CurWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003AB4 RID: 15028
		// (get) Token: 0x060215B4 RID: 136628 RVA: 0x00946CDF File Offset: 0x00944EDF
		// (set) Token: 0x060215B5 RID: 136629 RVA: 0x00946CF3 File Offset: 0x00944EF3
		public unsafe FVector hittingPoint_world_position_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17003AB5 RID: 15029
		// (get) Token: 0x060215B6 RID: 136630 RVA: 0x00946D08 File Offset: 0x00944F08
		// (set) Token: 0x060215B7 RID: 136631 RVA: 0x00946D1C File Offset: 0x00944F1C
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17003AB6 RID: 15030
		// (get) Token: 0x060215B8 RID: 136632 RVA: 0x00946D31 File Offset: 0x00944F31
		// (set) Token: 0x060215B9 RID: 136633 RVA: 0x00946D45 File Offset: 0x00944F45
		public unsafe UTextureRenderTarget2D SkinMaskRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17003AB7 RID: 15031
		// (get) Token: 0x060215BA RID: 136634 RVA: 0x00946D5A File Offset: 0x00944F5A
		// (set) Token: 0x060215BB RID: 136635 RVA: 0x00946D6E File Offset: 0x00944F6E
		public unsafe UTexture2D TreePosTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003AB8 RID: 15032
		// (get) Token: 0x060215BC RID: 136636 RVA: 0x00946D83 File Offset: 0x00944F83
		// (set) Token: 0x060215BD RID: 136637 RVA: 0x00946D97 File Offset: 0x00944F97
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17003AB9 RID: 15033
		// (get) Token: 0x060215BE RID: 136638 RVA: 0x00946DAC File Offset: 0x00944FAC
		// (set) Token: 0x060215BF RID: 136639 RVA: 0x00946DBC File Offset: 0x00944FBC
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003ABA RID: 15034
		// (get) Token: 0x060215C0 RID: 136640 RVA: 0x00946DCD File Offset: 0x00944FCD
		// (set) Token: 0x060215C1 RID: 136641 RVA: 0x00946DDD File Offset: 0x00944FDD
		public unsafe bool debugWeapon_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003ABB RID: 15035
		// (get) Token: 0x060215C2 RID: 136642 RVA: 0x00946DEE File Offset: 0x00944FEE
		// (set) Token: 0x060215C3 RID: 136643 RVA: 0x00946DFE File Offset: 0x00944FFE
		public unsafe bool debugDamage_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003ABC RID: 15036
		// (get) Token: 0x060215C4 RID: 136644 RVA: 0x00946E10 File Offset: 0x00945010
		// (set) Token: 0x060215C5 RID: 136645 RVA: 0x00946E49 File Offset: 0x00945049
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
					result = (this._SMComponents = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_49, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMComponents.CopyAssign(value);
			}
		}

		// Token: 0x17003ABD RID: 15037
		// (get) Token: 0x060215C6 RID: 136646 RVA: 0x00946E58 File Offset: 0x00945058
		// (set) Token: 0x060215C7 RID: 136647 RVA: 0x00946E91 File Offset: 0x00945091
		[Nullable(1)]
		public TArray<float> SMHealth
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._SMHealth) == null)
				{
					result = (this._SMHealth = new TArray<float>(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_50, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMHealth.CopyAssign(value);
			}
		}

		// Token: 0x17003ABE RID: 15038
		// (get) Token: 0x060215C8 RID: 136648 RVA: 0x00946EA0 File Offset: 0x009450A0
		// (set) Token: 0x060215C9 RID: 136649 RVA: 0x00946ED9 File Offset: 0x009450D9
		[Nullable(1)]
		public TArray<UPhysicsConstraintComponent> ConsArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UPhysicsConstraintComponent> result;
				if ((result = this._ConsArr) == null)
				{
					result = (this._ConsArr = new TArray<UPhysicsConstraintComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_51, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ConsArr.CopyAssign(value);
			}
		}

		// Token: 0x17003ABF RID: 15039
		// (get) Token: 0x060215CA RID: 136650 RVA: 0x00946EE8 File Offset: 0x009450E8
		// (set) Token: 0x060215CB RID: 136651 RVA: 0x00946F21 File Offset: 0x00945121
		[Nullable(1)]
		public TArray<FVector> ForceArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._ForceArr) == null)
				{
					result = (this._ForceArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_52, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ForceArr.CopyAssign(value);
			}
		}

		// Token: 0x17003AC0 RID: 15040
		// (get) Token: 0x060215CC RID: 136652 RVA: 0x00946F2F File Offset: 0x0094512F
		// (set) Token: 0x060215CD RID: 136653 RVA: 0x00946F3F File Offset: 0x0094513F
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AC1 RID: 15041
		// (get) Token: 0x060215CE RID: 136654 RVA: 0x00946F50 File Offset: 0x00945150
		// (set) Token: 0x060215CF RID: 136655 RVA: 0x00946F64 File Offset: 0x00945164
		public unsafe FVector LastHitPositon
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17003AC2 RID: 15042
		// (get) Token: 0x060215D0 RID: 136656 RVA: 0x00946F7C File Offset: 0x0094517C
		// (set) Token: 0x060215D1 RID: 136657 RVA: 0x00946FB5 File Offset: 0x009451B5
		[Nullable(1)]
		public TArray<UStaticMeshComponent> Wheels
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._Wheels) == null)
				{
					result = (this._Wheels = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_55, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Wheels.CopyAssign(value);
			}
		}

		// Token: 0x17003AC3 RID: 15043
		// (get) Token: 0x060215D2 RID: 136658 RVA: 0x00946FC3 File Offset: 0x009451C3
		// (set) Token: 0x060215D3 RID: 136659 RVA: 0x00946FD7 File Offset: 0x009451D7
		public unsafe UNiagaraSystem NS_Bloom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x17003AC4 RID: 15044
		// (get) Token: 0x060215D4 RID: 136660 RVA: 0x00946FEC File Offset: 0x009451EC
		// (set) Token: 0x060215D5 RID: 136661 RVA: 0x00947000 File Offset: 0x00945200
		public unsafe UNiagaraSystem NS_Attack
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17003AC5 RID: 15045
		// (get) Token: 0x060215D6 RID: 136662 RVA: 0x00947015 File Offset: 0x00945215
		// (set) Token: 0x060215D7 RID: 136663 RVA: 0x00947025 File Offset: 0x00945225
		public unsafe bool EngineAlreadyBreak
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_58) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_58) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AC6 RID: 15046
		// (get) Token: 0x060215D8 RID: 136664 RVA: 0x00947036 File Offset: 0x00945236
		// (set) Token: 0x060215D9 RID: 136665 RVA: 0x00947046 File Offset: 0x00945246
		public unsafe bool EngineBreakOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AC7 RID: 15047
		// (get) Token: 0x060215DA RID: 136666 RVA: 0x00947057 File Offset: 0x00945257
		// (set) Token: 0x060215DB RID: 136667 RVA: 0x00947067 File Offset: 0x00945267
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_60) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_60) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003AC8 RID: 15048
		// (get) Token: 0x060215DC RID: 136668 RVA: 0x00947078 File Offset: 0x00945278
		// (set) Token: 0x060215DD RID: 136669 RVA: 0x0094708C File Offset: 0x0094528C
		public unsafe UNiagaraSystem NS_CarFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x17003AC9 RID: 15049
		// (get) Token: 0x060215DE RID: 136670 RVA: 0x009470A1 File Offset: 0x009452A1
		// (set) Token: 0x060215DF RID: 136671 RVA: 0x009470B5 File Offset: 0x009452B5
		public unsafe UNiagaraSystem NS_EngineFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17003ACA RID: 15050
		// (get) Token: 0x060215E0 RID: 136672 RVA: 0x009470CA File Offset: 0x009452CA
		// (set) Token: 0x060215E1 RID: 136673 RVA: 0x009470DA File Offset: 0x009452DA
		public unsafe bool bDebug_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_63) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_63) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003ACB RID: 15051
		// (get) Token: 0x060215E2 RID: 136674 RVA: 0x009470EB File Offset: 0x009452EB
		// (set) Token: 0x060215E3 RID: 136675 RVA: 0x009470FF File Offset: 0x009452FF
		public unsafe UNiagaraSystem NS_TireBroken
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17003ACC RID: 15052
		// (get) Token: 0x060215E4 RID: 136676 RVA: 0x00947114 File Offset: 0x00945314
		// (set) Token: 0x060215E5 RID: 136677 RVA: 0x00947124 File Offset: 0x00945324
		public unsafe bool bIsOpen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_65) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_65) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003ACD RID: 15053
		// (get) Token: 0x060215E6 RID: 136678 RVA: 0x00947135 File Offset: 0x00945335
		// (set) Token: 0x060215E7 RID: 136679 RVA: 0x00947145 File Offset: 0x00945345
		public unsafe bool bIsTrans
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_66) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_66) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003ACE RID: 15054
		// (get) Token: 0x060215E8 RID: 136680 RVA: 0x00947156 File Offset: 0x00945356
		// (set) Token: 0x060215E9 RID: 136681 RVA: 0x0094716A File Offset: 0x0094536A
		public unsafe FTransform LeftTrans1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17003ACF RID: 15055
		// (get) Token: 0x060215EA RID: 136682 RVA: 0x0094717F File Offset: 0x0094537F
		// (set) Token: 0x060215EB RID: 136683 RVA: 0x00947193 File Offset: 0x00945393
		public unsafe FTransform LeftTrans2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17003AD0 RID: 15056
		// (get) Token: 0x060215EC RID: 136684 RVA: 0x009471A8 File Offset: 0x009453A8
		// (set) Token: 0x060215ED RID: 136685 RVA: 0x009471BC File Offset: 0x009453BC
		public unsafe FTransform LeftTrans3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17003AD1 RID: 15057
		// (get) Token: 0x060215EE RID: 136686 RVA: 0x009471D1 File Offset: 0x009453D1
		// (set) Token: 0x060215EF RID: 136687 RVA: 0x009471E5 File Offset: 0x009453E5
		public unsafe FTransform RightTrans1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17003AD2 RID: 15058
		// (get) Token: 0x060215F0 RID: 136688 RVA: 0x009471FA File Offset: 0x009453FA
		// (set) Token: 0x060215F1 RID: 136689 RVA: 0x0094720E File Offset: 0x0094540E
		public unsafe FTransform RightTrans2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17003AD3 RID: 15059
		// (get) Token: 0x060215F2 RID: 136690 RVA: 0x00947223 File Offset: 0x00945423
		// (set) Token: 0x060215F3 RID: 136691 RVA: 0x00947237 File Offset: 0x00945437
		public unsafe FTransform RightTrans3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x17003AD4 RID: 15060
		// (get) Token: 0x060215F4 RID: 136692 RVA: 0x0094724C File Offset: 0x0094544C
		// (set) Token: 0x060215F5 RID: 136693 RVA: 0x00947260 File Offset: 0x00945460
		public unsafe UAkAudioEvent CloseDoorSound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_73);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_73, value);
			}
		}

		// Token: 0x17003AD5 RID: 15061
		// (get) Token: 0x060215F6 RID: 136694 RVA: 0x00947275 File Offset: 0x00945475
		// (set) Token: 0x060215F7 RID: 136695 RVA: 0x00947289 File Offset: 0x00945489
		public unsafe UAkAudioEvent OpenDoorSound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_74);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_type2_C.__PropertyOffset_74, value);
			}
		}

		// Token: 0x17003AD6 RID: 15062
		// (get) Token: 0x060215F8 RID: 136696 RVA: 0x0094729E File Offset: 0x0094549E
		// (set) Token: 0x060215F9 RID: 136697 RVA: 0x009472AE File Offset: 0x009454AE
		public unsafe float dtForNiagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17003AD7 RID: 15063
		// (get) Token: 0x060215FA RID: 136698 RVA: 0x009472BF File Offset: 0x009454BF
		// (set) Token: 0x060215FB RID: 136699 RVA: 0x009472CF File Offset: 0x009454CF
		public unsafe int thisFrameWeaponID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17003AD8 RID: 15064
		// (get) Token: 0x060215FC RID: 136700 RVA: 0x009472E0 File Offset: 0x009454E0
		// (set) Token: 0x060215FD RID: 136701 RVA: 0x009472F0 File Offset: 0x009454F0
		public unsafe int lastFrameWeaponID_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_type2_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x060215FE RID: 136702 RVA: 0x00947304 File Offset: 0x00945504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreateDM(UStaticMeshComponent Component)
		{
			BP_VehicleDamage_type2_C.__CreateDM_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__CreateDM_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__CreateDM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__CreateDM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Component = ((Component != null) ? Component.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__CreateDM_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060215FF RID: 136703 RVA: 0x00947359 File Offset: 0x00945559
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021600 RID: 136704 RVA: 0x0094736D File Offset: 0x0094556D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021601 RID: 136705 RVA: 0x00947384 File Offset: 0x00945584
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_288D18084A520619C86AF88579BB211B(int PlayingID)
		{
			BP_VehicleDamage_type2_C.__Completed_288D18084A520619C86AF88579BB211B_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__Completed_288D18084A520619C86AF88579BB211B_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__Completed_288D18084A520619C86AF88579BB211B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__Completed_288D18084A520619C86AF88579BB211B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__Completed_288D18084A520619C86AF88579BB211B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021602 RID: 136706 RVA: 0x009473CC File Offset: 0x009455CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_A1D80AE34A6FB523D2E3408304A08CA8(int PlayingID)
		{
			BP_VehicleDamage_type2_C.__Completed_A1D80AE34A6FB523D2E3408304A08CA8_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__Completed_A1D80AE34A6FB523D2E3408304A08CA8_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__Completed_A1D80AE34A6FB523D2E3408304A08CA8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__Completed_A1D80AE34A6FB523D2E3408304A08CA8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__Completed_A1D80AE34A6FB523D2E3408304A08CA8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021603 RID: 136707 RVA: 0x00947414 File Offset: 0x00945614
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_325847C543568188EA0591BC9EE24EE7(int PlayingID)
		{
			BP_VehicleDamage_type2_C.__Completed_325847C543568188EA0591BC9EE24EE7_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__Completed_325847C543568188EA0591BC9EE24EE7_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__Completed_325847C543568188EA0591BC9EE24EE7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__Completed_325847C543568188EA0591BC9EE24EE7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__Completed_325847C543568188EA0591BC9EE24EE7_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021604 RID: 136708 RVA: 0x0094745A File Offset: 0x0094565A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021605 RID: 136709 RVA: 0x0094746E File Offset: 0x0094566E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021606 RID: 136710 RVA: 0x00947484 File Offset: 0x00945684
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VehicleDamage_type2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021607 RID: 136711 RVA: 0x009474CC File Offset: 0x009456CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VehicleDamage_type2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021608 RID: 136712 RVA: 0x00947514 File Offset: 0x00945714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_VehicleDamage_type2_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021609 RID: 136713 RVA: 0x00947577 File Offset: 0x00945777
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x0602160A RID: 136714 RVA: 0x0094758B File Offset: 0x0094578B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__CustomEvent_NativeFunctionPtr, null);
		}

		// Token: 0x0602160B RID: 136715 RVA: 0x0094759F File Offset: 0x0094579F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602160C RID: 136716 RVA: 0x009475B3 File Offset: 0x009457B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__test_NativeFunctionPtr, null);
		}

		// Token: 0x0602160D RID: 136717 RVA: 0x009475C8 File Offset: 0x009457C8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnVehiclePartBroken_Event_0(int PartIndex, string PartName)
		{
			BP_VehicleDamage_type2_C.__OnVehiclePartBroken_Event_0_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__OnVehiclePartBroken_Event_0_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__OnVehiclePartBroken_Event_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PartIndex = PartIndex;
			FString.CopyFrom((void*)(&ptr->PartName), PartName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_VehicleDamage_type2_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602160E RID: 136718 RVA: 0x0094762C File Offset: 0x0094582C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VehicleDamage_type2(int EntryPoint)
		{
			BP_VehicleDamage_type2_C.__ExecuteUbergraph_BP_VehicleDamage_type2_FunctionParams* ptr = stackalloc BP_VehicleDamage_type2_C.__ExecuteUbergraph_BP_VehicleDamage_type2_FunctionParams[(UIntPtr)3327] + 15L / (long)sizeof(BP_VehicleDamage_type2_C.__ExecuteUbergraph_BP_VehicleDamage_type2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_type2_C.__ExecuteUbergraph_BP_VehicleDamage_type2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_type2_C.__ExecuteUbergraph_BP_VehicleDamage_type2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602160F RID: 136719 RVA: 0x00947676 File Offset: 0x00945876
		protected BP_VehicleDamage_type2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010C66 RID: 68710
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage_type2.BP_VehicleDamage_type2_C";

		// Token: 0x04010C67 RID: 68711
		private static IntPtr _ClassPtr;

		// Token: 0x04010C68 RID: 68712
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010C69 RID: 68713
		internal static int __PropertyOffset_0;

		// Token: 0x04010C6A RID: 68714
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010C6B RID: 68715
		internal static int __PropertyOffset_1;

		// Token: 0x04010C6C RID: 68716
		internal static int __PropertyOffset_2;

		// Token: 0x04010C6D RID: 68717
		internal static int __PropertyOffset_3;

		// Token: 0x04010C6E RID: 68718
		internal static int __PropertyOffset_4;

		// Token: 0x04010C6F RID: 68719
		internal static int __PropertyOffset_5;

		// Token: 0x04010C70 RID: 68720
		internal static int __PropertyOffset_6;

		// Token: 0x04010C71 RID: 68721
		internal static int __PropertyOffset_7;

		// Token: 0x04010C72 RID: 68722
		internal static int __PropertyOffset_8;

		// Token: 0x04010C73 RID: 68723
		internal static int __PropertyOffset_9;

		// Token: 0x04010C74 RID: 68724
		internal static int __PropertyOffset_10;

		// Token: 0x04010C75 RID: 68725
		internal static int __PropertyOffset_11;

		// Token: 0x04010C76 RID: 68726
		internal static int __PropertyOffset_12;

		// Token: 0x04010C77 RID: 68727
		internal static int __PropertyOffset_13;

		// Token: 0x04010C78 RID: 68728
		internal static int __PropertyOffset_14;

		// Token: 0x04010C79 RID: 68729
		internal static int __PropertyOffset_15;

		// Token: 0x04010C7A RID: 68730
		internal static int __PropertyOffset_16;

		// Token: 0x04010C7B RID: 68731
		internal static int __PropertyOffset_17;

		// Token: 0x04010C7C RID: 68732
		internal static int __PropertyOffset_18;

		// Token: 0x04010C7D RID: 68733
		internal static int __PropertyOffset_19;

		// Token: 0x04010C7E RID: 68734
		internal static int __PropertyOffset_20;

		// Token: 0x04010C7F RID: 68735
		internal static int __PropertyOffset_21;

		// Token: 0x04010C80 RID: 68736
		internal static int __PropertyOffset_22;

		// Token: 0x04010C81 RID: 68737
		internal static int __PropertyOffset_23;

		// Token: 0x04010C82 RID: 68738
		internal static int __PropertyOffset_24;

		// Token: 0x04010C83 RID: 68739
		internal static int __PropertyOffset_25;

		// Token: 0x04010C84 RID: 68740
		internal static int __PropertyOffset_26;

		// Token: 0x04010C85 RID: 68741
		internal static int __PropertyOffset_27;

		// Token: 0x04010C86 RID: 68742
		internal static int __PropertyOffset_28;

		// Token: 0x04010C87 RID: 68743
		internal static int __PropertyOffset_29;

		// Token: 0x04010C88 RID: 68744
		internal static int __PropertyOffset_30;

		// Token: 0x04010C89 RID: 68745
		internal static int __PropertyOffset_31;

		// Token: 0x04010C8A RID: 68746
		internal static int __PropertyOffset_32;

		// Token: 0x04010C8B RID: 68747
		internal static int __PropertyOffset_33;

		// Token: 0x04010C8C RID: 68748
		internal static int __PropertyOffset_34;

		// Token: 0x04010C8D RID: 68749
		internal static int __PropertyOffset_35;

		// Token: 0x04010C8E RID: 68750
		internal static int __PropertyOffset_36;

		// Token: 0x04010C8F RID: 68751
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CarAllMats;

		// Token: 0x04010C90 RID: 68752
		internal static int __PropertyOffset_37;

		// Token: 0x04010C91 RID: 68753
		internal static int __PropertyOffset_38;

		// Token: 0x04010C92 RID: 68754
		internal static int __PropertyOffset_39;

		// Token: 0x04010C93 RID: 68755
		internal static int __PropertyOffset_40;

		// Token: 0x04010C94 RID: 68756
		internal static int __PropertyOffset_41;

		// Token: 0x04010C95 RID: 68757
		internal static int __PropertyOffset_42;

		// Token: 0x04010C96 RID: 68758
		internal static int __PropertyOffset_43;

		// Token: 0x04010C97 RID: 68759
		internal static int __PropertyOffset_44;

		// Token: 0x04010C98 RID: 68760
		internal static int __PropertyOffset_45;

		// Token: 0x04010C99 RID: 68761
		internal static int __PropertyOffset_46;

		// Token: 0x04010C9A RID: 68762
		internal static int __PropertyOffset_47;

		// Token: 0x04010C9B RID: 68763
		internal static int __PropertyOffset_48;

		// Token: 0x04010C9C RID: 68764
		internal static int __PropertyOffset_49;

		// Token: 0x04010C9D RID: 68765
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMComponents;

		// Token: 0x04010C9E RID: 68766
		internal static int __PropertyOffset_50;

		// Token: 0x04010C9F RID: 68767
		private TArray<float> _SMHealth;

		// Token: 0x04010CA0 RID: 68768
		internal static int __PropertyOffset_51;

		// Token: 0x04010CA1 RID: 68769
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UPhysicsConstraintComponent> _ConsArr;

		// Token: 0x04010CA2 RID: 68770
		internal static int __PropertyOffset_52;

		// Token: 0x04010CA3 RID: 68771
		private TArray<FVector> _ForceArr;

		// Token: 0x04010CA4 RID: 68772
		internal static int __PropertyOffset_53;

		// Token: 0x04010CA5 RID: 68773
		internal static int __PropertyOffset_54;

		// Token: 0x04010CA6 RID: 68774
		internal static int __PropertyOffset_55;

		// Token: 0x04010CA7 RID: 68775
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _Wheels;

		// Token: 0x04010CA8 RID: 68776
		internal static int __PropertyOffset_56;

		// Token: 0x04010CA9 RID: 68777
		internal static int __PropertyOffset_57;

		// Token: 0x04010CAA RID: 68778
		internal static int __PropertyOffset_58;

		// Token: 0x04010CAB RID: 68779
		internal static int __PropertyOffset_59;

		// Token: 0x04010CAC RID: 68780
		internal static int __PropertyOffset_60;

		// Token: 0x04010CAD RID: 68781
		internal static int __PropertyOffset_61;

		// Token: 0x04010CAE RID: 68782
		internal static int __PropertyOffset_62;

		// Token: 0x04010CAF RID: 68783
		internal static int __PropertyOffset_63;

		// Token: 0x04010CB0 RID: 68784
		internal static int __PropertyOffset_64;

		// Token: 0x04010CB1 RID: 68785
		internal static int __PropertyOffset_65;

		// Token: 0x04010CB2 RID: 68786
		internal static int __PropertyOffset_66;

		// Token: 0x04010CB3 RID: 68787
		internal static int __PropertyOffset_67;

		// Token: 0x04010CB4 RID: 68788
		internal static int __PropertyOffset_68;

		// Token: 0x04010CB5 RID: 68789
		internal static int __PropertyOffset_69;

		// Token: 0x04010CB6 RID: 68790
		internal static int __PropertyOffset_70;

		// Token: 0x04010CB7 RID: 68791
		internal static int __PropertyOffset_71;

		// Token: 0x04010CB8 RID: 68792
		internal static int __PropertyOffset_72;

		// Token: 0x04010CB9 RID: 68793
		internal static int __PropertyOffset_73;

		// Token: 0x04010CBA RID: 68794
		internal static int __PropertyOffset_74;

		// Token: 0x04010CBB RID: 68795
		internal static int __PropertyOffset_75;

		// Token: 0x04010CBC RID: 68796
		internal static int __PropertyOffset_76;

		// Token: 0x04010CBD RID: 68797
		internal static int __PropertyOffset_77;

		// Token: 0x04010CBE RID: 68798
		private static IntPtr __CreateDM_NativeFunctionPtr;

		// Token: 0x04010CBF RID: 68799
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010CC0 RID: 68800
		private static IntPtr __Completed_288D18084A520619C86AF88579BB211B_NativeFunctionPtr;

		// Token: 0x04010CC1 RID: 68801
		private static IntPtr __Completed_A1D80AE34A6FB523D2E3408304A08CA8_NativeFunctionPtr;

		// Token: 0x04010CC2 RID: 68802
		private static IntPtr __Completed_325847C543568188EA0591BC9EE24EE7_NativeFunctionPtr;

		// Token: 0x04010CC3 RID: 68803
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010CC4 RID: 68804
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010CC5 RID: 68805
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04010CC6 RID: 68806
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010CC7 RID: 68807
		private static IntPtr __CustomEvent_NativeFunctionPtr;

		// Token: 0x04010CC8 RID: 68808
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010CC9 RID: 68809
		private static IntPtr __test_NativeFunctionPtr;

		// Token: 0x04010CCA RID: 68810
		private static IntPtr __OnVehiclePartBroken_Event_0_NativeFunctionPtr;

		// Token: 0x04010CCB RID: 68811
		private static IntPtr __ExecuteUbergraph_BP_VehicleDamage_type2_NativeFunctionPtr;

		// Token: 0x02009AB9 RID: 39609
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __CreateDM_FunctionParams
		{
			// Token: 0x0403222C RID: 205356
			[FieldOffset(0)]
			public IntPtr Component;
		}

		// Token: 0x02009ABA RID: 39610
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_288D18084A520619C86AF88579BB211B_FunctionParams
		{
			// Token: 0x0403222D RID: 205357
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009ABB RID: 39611
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_A1D80AE34A6FB523D2E3408304A08CA8_FunctionParams
		{
			// Token: 0x0403222E RID: 205358
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009ABC RID: 39612
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_325847C543568188EA0591BC9EE24EE7_FunctionParams
		{
			// Token: 0x0403222F RID: 205359
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009ABD RID: 39613
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032230 RID: 205360
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009ABE RID: 39614
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032231 RID: 205361
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032232 RID: 205362
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032233 RID: 205363
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009ABF RID: 39615
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnVehiclePartBroken_Event_0_FunctionParams
		{
			// Token: 0x04032234 RID: 205364
			[FieldOffset(0)]
			public int PartIndex;

			// Token: 0x04032235 RID: 205365
			[FieldOffset(8)]
			public FString PartName;
		}

		// Token: 0x02009AC0 RID: 39616
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3312)]
		protected ref struct __ExecuteUbergraph_BP_VehicleDamage_type2_FunctionParams
		{
			// Token: 0x04032236 RID: 205366
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
