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
	// Token: 0x02003B60 RID: 15200
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage_DoorOpen.BP_VehicleDamage_DoorOpen_C")]
	[UnrealStructLayout(2704, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2700)]
	public class BP_VehicleDamage_DoorOpen_C : AKuroVehicleDestructionActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021466 RID: 136294 RVA: 0x00944D97 File Offset: 0x00942F97
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VehicleDamage_DoorOpen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage_DoorOpen.BP_VehicleDamage_DoorOpen_C");
			}
			return BP_VehicleDamage_DoorOpen_C._ClassPtr;
		}

		// Token: 0x06021467 RID: 136295 RVA: 0x00944DBC File Offset: 0x00942FBC
		public BP_VehicleDamage_DoorOpen_C() : this(BuiltinUtils.AllocNativeUObject(BP_VehicleDamage_DoorOpen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021468 RID: 136296 RVA: 0x00944DE4 File Offset: 0x00942FE4
		[NullableContext(1)]
		public BP_VehicleDamage_DoorOpen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VehicleDamage_DoorOpen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003A23 RID: 14883
		// (get) Token: 0x06021469 RID: 136297 RVA: 0x00944E18 File Offset: 0x00943018
		// (set) Token: 0x0602146A RID: 136298 RVA: 0x00944E51 File Offset: 0x00943051
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003A24 RID: 14884
		// (get) Token: 0x0602146B RID: 136299 RVA: 0x00944E72 File Offset: 0x00943072
		// (set) Token: 0x0602146C RID: 136300 RVA: 0x00944E86 File Offset: 0x00943086
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003A25 RID: 14885
		// (get) Token: 0x0602146D RID: 136301 RVA: 0x00944E9B File Offset: 0x0094309B
		// (set) Token: 0x0602146E RID: 136302 RVA: 0x00944EAF File Offset: 0x009430AF
		public unsafe UBoxComponent BoxTrigger
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003A26 RID: 14886
		// (get) Token: 0x0602146F RID: 136303 RVA: 0x00944EC4 File Offset: 0x009430C4
		// (set) Token: 0x06021470 RID: 136304 RVA: 0x00944ED8 File Offset: 0x009430D8
		public unsafe UStaticMeshComponent blast_10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003A27 RID: 14887
		// (get) Token: 0x06021471 RID: 136305 RVA: 0x00944EED File Offset: 0x009430ED
		// (set) Token: 0x06021472 RID: 136306 RVA: 0x00944F01 File Offset: 0x00943101
		public unsafe UBoxComponent myCustomBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003A28 RID: 14888
		// (get) Token: 0x06021473 RID: 136307 RVA: 0x00944F16 File Offset: 0x00943116
		// (set) Token: 0x06021474 RID: 136308 RVA: 0x00944F2A File Offset: 0x0094312A
		public unsafe UNiagaraComponent NS_VehicleFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003A29 RID: 14889
		// (get) Token: 0x06021475 RID: 136309 RVA: 0x00944F3F File Offset: 0x0094313F
		// (set) Token: 0x06021476 RID: 136310 RVA: 0x00944F53 File Offset: 0x00943153
		public unsafe UNiagaraComponent NS_VehicleBloom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003A2A RID: 14890
		// (get) Token: 0x06021477 RID: 136311 RVA: 0x00944F68 File Offset: 0x00943168
		// (set) Token: 0x06021478 RID: 136312 RVA: 0x00944F7C File Offset: 0x0094317C
		public unsafe UBoxComponent ValidAttackBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003A2B RID: 14891
		// (get) Token: 0x06021479 RID: 136313 RVA: 0x00944F91 File Offset: 0x00943191
		// (set) Token: 0x0602147A RID: 136314 RVA: 0x00944FA5 File Offset: 0x009431A5
		public unsafe UNiagaraComponent NS_engineFly
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003A2C RID: 14892
		// (get) Token: 0x0602147B RID: 136315 RVA: 0x00944FBA File Offset: 0x009431BA
		// (set) Token: 0x0602147C RID: 136316 RVA: 0x00944FCE File Offset: 0x009431CE
		public unsafe UStaticMeshComponent blast_small14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003A2D RID: 14893
		// (get) Token: 0x0602147D RID: 136317 RVA: 0x00944FE3 File Offset: 0x009431E3
		// (set) Token: 0x0602147E RID: 136318 RVA: 0x00944FF7 File Offset: 0x009431F7
		public unsafe UStaticMeshComponent blast_small10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003A2E RID: 14894
		// (get) Token: 0x0602147F RID: 136319 RVA: 0x0094500C File Offset: 0x0094320C
		// (set) Token: 0x06021480 RID: 136320 RVA: 0x00945020 File Offset: 0x00943220
		public unsafe UStaticMeshComponent blast_small13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003A2F RID: 14895
		// (get) Token: 0x06021481 RID: 136321 RVA: 0x00945035 File Offset: 0x00943235
		// (set) Token: 0x06021482 RID: 136322 RVA: 0x00945049 File Offset: 0x00943249
		public unsafe UStaticMeshComponent blast_small12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003A30 RID: 14896
		// (get) Token: 0x06021483 RID: 136323 RVA: 0x0094505E File Offset: 0x0094325E
		// (set) Token: 0x06021484 RID: 136324 RVA: 0x00945072 File Offset: 0x00943272
		public unsafe UStaticMeshComponent blast_small11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003A31 RID: 14897
		// (get) Token: 0x06021485 RID: 136325 RVA: 0x00945087 File Offset: 0x00943287
		// (set) Token: 0x06021486 RID: 136326 RVA: 0x0094509B File Offset: 0x0094329B
		public unsafe UStaticMeshComponent blast_small8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003A32 RID: 14898
		// (get) Token: 0x06021487 RID: 136327 RVA: 0x009450B0 File Offset: 0x009432B0
		// (set) Token: 0x06021488 RID: 136328 RVA: 0x009450C4 File Offset: 0x009432C4
		public unsafe UStaticMeshComponent blast_small9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003A33 RID: 14899
		// (get) Token: 0x06021489 RID: 136329 RVA: 0x009450D9 File Offset: 0x009432D9
		// (set) Token: 0x0602148A RID: 136330 RVA: 0x009450ED File Offset: 0x009432ED
		public unsafe UStaticMeshComponent blast_small7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003A34 RID: 14900
		// (get) Token: 0x0602148B RID: 136331 RVA: 0x00945102 File Offset: 0x00943302
		// (set) Token: 0x0602148C RID: 136332 RVA: 0x00945116 File Offset: 0x00943316
		public unsafe UStaticMeshComponent blast_small5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003A35 RID: 14901
		// (get) Token: 0x0602148D RID: 136333 RVA: 0x0094512B File Offset: 0x0094332B
		// (set) Token: 0x0602148E RID: 136334 RVA: 0x0094513F File Offset: 0x0094333F
		public unsafe UStaticMeshComponent blast_small6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003A36 RID: 14902
		// (get) Token: 0x0602148F RID: 136335 RVA: 0x00945154 File Offset: 0x00943354
		// (set) Token: 0x06021490 RID: 136336 RVA: 0x00945168 File Offset: 0x00943368
		public unsafe UStaticMeshComponent blast_small2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003A37 RID: 14903
		// (get) Token: 0x06021491 RID: 136337 RVA: 0x0094517D File Offset: 0x0094337D
		// (set) Token: 0x06021492 RID: 136338 RVA: 0x00945191 File Offset: 0x00943391
		public unsafe UStaticMeshComponent blast_small3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003A38 RID: 14904
		// (get) Token: 0x06021493 RID: 136339 RVA: 0x009451A6 File Offset: 0x009433A6
		// (set) Token: 0x06021494 RID: 136340 RVA: 0x009451BA File Offset: 0x009433BA
		public unsafe UStaticMeshComponent blast_small1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003A39 RID: 14905
		// (get) Token: 0x06021495 RID: 136341 RVA: 0x009451CF File Offset: 0x009433CF
		// (set) Token: 0x06021496 RID: 136342 RVA: 0x009451E3 File Offset: 0x009433E3
		public unsafe UPhysicsConstraintComponent cons_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003A3A RID: 14906
		// (get) Token: 0x06021497 RID: 136343 RVA: 0x009451F8 File Offset: 0x009433F8
		// (set) Token: 0x06021498 RID: 136344 RVA: 0x0094520C File Offset: 0x0094340C
		public unsafe UStaticMeshComponent blast_back_cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003A3B RID: 14907
		// (get) Token: 0x06021499 RID: 136345 RVA: 0x00945221 File Offset: 0x00943421
		// (set) Token: 0x0602149A RID: 136346 RVA: 0x00945235 File Offset: 0x00943435
		public unsafe UStaticMeshComponent blast_wheel3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003A3C RID: 14908
		// (get) Token: 0x0602149B RID: 136347 RVA: 0x0094524A File Offset: 0x0094344A
		// (set) Token: 0x0602149C RID: 136348 RVA: 0x0094525E File Offset: 0x0094345E
		public unsafe UStaticMeshComponent blast_wheel2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003A3D RID: 14909
		// (get) Token: 0x0602149D RID: 136349 RVA: 0x00945273 File Offset: 0x00943473
		// (set) Token: 0x0602149E RID: 136350 RVA: 0x00945287 File Offset: 0x00943487
		public unsafe UStaticMeshComponent blast_wheel1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003A3E RID: 14910
		// (get) Token: 0x0602149F RID: 136351 RVA: 0x0094529C File Offset: 0x0094349C
		// (set) Token: 0x060214A0 RID: 136352 RVA: 0x009452B0 File Offset: 0x009434B0
		public unsafe UStaticMeshComponent blast_wheel4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003A3F RID: 14911
		// (get) Token: 0x060214A1 RID: 136353 RVA: 0x009452C5 File Offset: 0x009434C5
		// (set) Token: 0x060214A2 RID: 136354 RVA: 0x009452D9 File Offset: 0x009434D9
		public unsafe UStaticMeshComponent blast_front_cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003A40 RID: 14912
		// (get) Token: 0x060214A3 RID: 136355 RVA: 0x009452EE File Offset: 0x009434EE
		// (set) Token: 0x060214A4 RID: 136356 RVA: 0x00945302 File Offset: 0x00943502
		public unsafe UPhysicsConstraintComponent cons_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003A41 RID: 14913
		// (get) Token: 0x060214A5 RID: 136357 RVA: 0x00945317 File Offset: 0x00943517
		// (set) Token: 0x060214A6 RID: 136358 RVA: 0x0094532B File Offset: 0x0094352B
		public unsafe UPhysicsConstraintComponent cons_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003A42 RID: 14914
		// (get) Token: 0x060214A7 RID: 136359 RVA: 0x00945340 File Offset: 0x00943540
		// (set) Token: 0x060214A8 RID: 136360 RVA: 0x00945354 File Offset: 0x00943554
		public unsafe UPhysicsConstraintComponent cons_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003A43 RID: 14915
		// (get) Token: 0x060214A9 RID: 136361 RVA: 0x00945369 File Offset: 0x00943569
		// (set) Token: 0x060214AA RID: 136362 RVA: 0x0094537D File Offset: 0x0094357D
		public unsafe UStaticMeshComponent blast3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003A44 RID: 14916
		// (get) Token: 0x060214AB RID: 136363 RVA: 0x00945392 File Offset: 0x00943592
		// (set) Token: 0x060214AC RID: 136364 RVA: 0x009453A6 File Offset: 0x009435A6
		public unsafe UStaticMeshComponent blast2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003A45 RID: 14917
		// (get) Token: 0x060214AD RID: 136365 RVA: 0x009453BB File Offset: 0x009435BB
		// (set) Token: 0x060214AE RID: 136366 RVA: 0x009453CF File Offset: 0x009435CF
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003A46 RID: 14918
		// (get) Token: 0x060214AF RID: 136367 RVA: 0x009453E4 File Offset: 0x009435E4
		// (set) Token: 0x060214B0 RID: 136368 RVA: 0x009453F8 File Offset: 0x009435F8
		public unsafe UStaticMeshComponent SM_vehicleDamage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003A47 RID: 14919
		// (get) Token: 0x060214B1 RID: 136369 RVA: 0x0094540D File Offset: 0x0094360D
		// (set) Token: 0x060214B2 RID: 136370 RVA: 0x00945421 File Offset: 0x00943621
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003A48 RID: 14920
		// (get) Token: 0x060214B3 RID: 136371 RVA: 0x00945436 File Offset: 0x00943636
		// (set) Token: 0x060214B4 RID: 136372 RVA: 0x00945446 File Offset: 0x00943646
		public unsafe float Timeline_7_NewTrack_0_20B7364843DE02C9143D21AE9B98F04E
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17003A49 RID: 14921
		// (get) Token: 0x060214B5 RID: 136373 RVA: 0x00945457 File Offset: 0x00943657
		// (set) Token: 0x060214B6 RID: 136374 RVA: 0x0094546B File Offset: 0x0094366B
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_7__Direction_20B7364843DE02C9143D21AE9B98F04E
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_38);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003A4A RID: 14922
		// (get) Token: 0x060214B7 RID: 136375 RVA: 0x00945480 File Offset: 0x00943680
		// (set) Token: 0x060214B8 RID: 136376 RVA: 0x00945494 File Offset: 0x00943694
		public unsafe UTimelineComponent Timeline_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17003A4B RID: 14923
		// (get) Token: 0x060214B9 RID: 136377 RVA: 0x009454A9 File Offset: 0x009436A9
		// (set) Token: 0x060214BA RID: 136378 RVA: 0x009454B9 File Offset: 0x009436B9
		public unsafe float Timeline_6_NewTrack_0_269262EA4D691CA41AC69CB2C90247D5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003A4C RID: 14924
		// (get) Token: 0x060214BB RID: 136379 RVA: 0x009454CA File Offset: 0x009436CA
		// (set) Token: 0x060214BC RID: 136380 RVA: 0x009454DE File Offset: 0x009436DE
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_6__Direction_269262EA4D691CA41AC69CB2C90247D5
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_41);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17003A4D RID: 14925
		// (get) Token: 0x060214BD RID: 136381 RVA: 0x009454F3 File Offset: 0x009436F3
		// (set) Token: 0x060214BE RID: 136382 RVA: 0x00945507 File Offset: 0x00943707
		public unsafe UTimelineComponent Timeline_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17003A4E RID: 14926
		// (get) Token: 0x060214BF RID: 136383 RVA: 0x0094551C File Offset: 0x0094371C
		// (set) Token: 0x060214C0 RID: 136384 RVA: 0x0094552C File Offset: 0x0094372C
		public unsafe float Timeline_5_NewTrack_0_5E7D7C604D7803FE2AE69AA32AAE2AD4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003A4F RID: 14927
		// (get) Token: 0x060214C1 RID: 136385 RVA: 0x0094553D File Offset: 0x0094373D
		// (set) Token: 0x060214C2 RID: 136386 RVA: 0x00945551 File Offset: 0x00943751
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_5__Direction_5E7D7C604D7803FE2AE69AA32AAE2AD4
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_44);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17003A50 RID: 14928
		// (get) Token: 0x060214C3 RID: 136387 RVA: 0x00945566 File Offset: 0x00943766
		// (set) Token: 0x060214C4 RID: 136388 RVA: 0x0094557A File Offset: 0x0094377A
		public unsafe UTimelineComponent Timeline_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17003A51 RID: 14929
		// (get) Token: 0x060214C5 RID: 136389 RVA: 0x0094558F File Offset: 0x0094378F
		// (set) Token: 0x060214C6 RID: 136390 RVA: 0x0094559F File Offset: 0x0094379F
		public unsafe float Timeline_4_NewTrack_0_C0C241994F3B4E0ABC1475881C5BDE8A
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17003A52 RID: 14930
		// (get) Token: 0x060214C7 RID: 136391 RVA: 0x009455B0 File Offset: 0x009437B0
		// (set) Token: 0x060214C8 RID: 136392 RVA: 0x009455C4 File Offset: 0x009437C4
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_4__Direction_C0C241994F3B4E0ABC1475881C5BDE8A
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_47);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17003A53 RID: 14931
		// (get) Token: 0x060214C9 RID: 136393 RVA: 0x009455D9 File Offset: 0x009437D9
		// (set) Token: 0x060214CA RID: 136394 RVA: 0x009455ED File Offset: 0x009437ED
		public unsafe UTimelineComponent Timeline_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17003A54 RID: 14932
		// (get) Token: 0x060214CB RID: 136395 RVA: 0x00945602 File Offset: 0x00943802
		// (set) Token: 0x060214CC RID: 136396 RVA: 0x00945612 File Offset: 0x00943812
		public unsafe float Timeline_3_NewTrack_0_F9C424B041207DB9B7E9B1AA643B4E65
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17003A55 RID: 14933
		// (get) Token: 0x060214CD RID: 136397 RVA: 0x00945623 File Offset: 0x00943823
		// (set) Token: 0x060214CE RID: 136398 RVA: 0x00945637 File Offset: 0x00943837
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_3__Direction_F9C424B041207DB9B7E9B1AA643B4E65
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_50);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17003A56 RID: 14934
		// (get) Token: 0x060214CF RID: 136399 RVA: 0x0094564C File Offset: 0x0094384C
		// (set) Token: 0x060214D0 RID: 136400 RVA: 0x00945660 File Offset: 0x00943860
		public unsafe UTimelineComponent Timeline_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_51);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x17003A57 RID: 14935
		// (get) Token: 0x060214D1 RID: 136401 RVA: 0x00945675 File Offset: 0x00943875
		// (set) Token: 0x060214D2 RID: 136402 RVA: 0x00945685 File Offset: 0x00943885
		public unsafe float Timeline_2_NewTrack_0_B4CA38084A2C6D24440532854FD80F14
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17003A58 RID: 14936
		// (get) Token: 0x060214D3 RID: 136403 RVA: 0x00945696 File Offset: 0x00943896
		// (set) Token: 0x060214D4 RID: 136404 RVA: 0x009456AA File Offset: 0x009438AA
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_2__Direction_B4CA38084A2C6D24440532854FD80F14
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_53);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17003A59 RID: 14937
		// (get) Token: 0x060214D5 RID: 136405 RVA: 0x009456BF File Offset: 0x009438BF
		// (set) Token: 0x060214D6 RID: 136406 RVA: 0x009456D3 File Offset: 0x009438D3
		public unsafe UTimelineComponent Timeline_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17003A5A RID: 14938
		// (get) Token: 0x060214D7 RID: 136407 RVA: 0x009456E8 File Offset: 0x009438E8
		// (set) Token: 0x060214D8 RID: 136408 RVA: 0x009456F8 File Offset: 0x009438F8
		public unsafe float Timeline_1_NewTrack_0_6FE613B84448D861330C6F8ADEF1D7E2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17003A5B RID: 14939
		// (get) Token: 0x060214D9 RID: 136409 RVA: 0x00945709 File Offset: 0x00943909
		// (set) Token: 0x060214DA RID: 136410 RVA: 0x0094571D File Offset: 0x0094391D
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_1__Direction_6FE613B84448D861330C6F8ADEF1D7E2
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_56);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17003A5C RID: 14940
		// (get) Token: 0x060214DB RID: 136411 RVA: 0x00945732 File Offset: 0x00943932
		// (set) Token: 0x060214DC RID: 136412 RVA: 0x00945746 File Offset: 0x00943946
		public unsafe UTimelineComponent Timeline_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17003A5D RID: 14941
		// (get) Token: 0x060214DD RID: 136413 RVA: 0x0094575B File Offset: 0x0094395B
		// (set) Token: 0x060214DE RID: 136414 RVA: 0x0094576B File Offset: 0x0094396B
		public unsafe float Timeline_0_NewTrack_0_EA0C57A7433067A8F9D5B5834E432087
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17003A5E RID: 14942
		// (get) Token: 0x060214DF RID: 136415 RVA: 0x0094577C File Offset: 0x0094397C
		// (set) Token: 0x060214E0 RID: 136416 RVA: 0x00945790 File Offset: 0x00943990
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_EA0C57A7433067A8F9D5B5834E432087
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_59);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x17003A5F RID: 14943
		// (get) Token: 0x060214E1 RID: 136417 RVA: 0x009457A5 File Offset: 0x009439A5
		// (set) Token: 0x060214E2 RID: 136418 RVA: 0x009457B9 File Offset: 0x009439B9
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x17003A60 RID: 14944
		// (get) Token: 0x060214E3 RID: 136419 RVA: 0x009457CE File Offset: 0x009439CE
		// (set) Token: 0x060214E4 RID: 136420 RVA: 0x009457E2 File Offset: 0x009439E2
		public unsafe UMaterialInstanceDynamic StampMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x17003A61 RID: 14945
		// (get) Token: 0x060214E5 RID: 136421 RVA: 0x009457F8 File Offset: 0x009439F8
		// (set) Token: 0x060214E6 RID: 136422 RVA: 0x00945831 File Offset: 0x00943A31
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
					result = (this._CarAllMats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_62, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CarAllMats.CopyAssign(value);
			}
		}

		// Token: 0x17003A62 RID: 14946
		// (get) Token: 0x060214E7 RID: 136423 RVA: 0x0094583F File Offset: 0x00943A3F
		// (set) Token: 0x060214E8 RID: 136424 RVA: 0x00945853 File Offset: 0x00943A53
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17003A63 RID: 14947
		// (get) Token: 0x060214E9 RID: 136425 RVA: 0x00945868 File Offset: 0x00943A68
		// (set) Token: 0x060214EA RID: 136426 RVA: 0x00945878 File Offset: 0x00943A78
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17003A64 RID: 14948
		// (get) Token: 0x060214EB RID: 136427 RVA: 0x00945889 File Offset: 0x00943A89
		// (set) Token: 0x060214EC RID: 136428 RVA: 0x00945899 File Offset: 0x00943A99
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17003A65 RID: 14949
		// (get) Token: 0x060214ED RID: 136429 RVA: 0x009458AA File Offset: 0x00943AAA
		// (set) Token: 0x060214EE RID: 136430 RVA: 0x009458BE File Offset: 0x00943ABE
		public unsafe FVector CurWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17003A66 RID: 14950
		// (get) Token: 0x060214EF RID: 136431 RVA: 0x009458D3 File Offset: 0x00943AD3
		// (set) Token: 0x060214F0 RID: 136432 RVA: 0x009458E7 File Offset: 0x00943AE7
		public unsafe FVector hittingPoint_world_position_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17003A67 RID: 14951
		// (get) Token: 0x060214F1 RID: 136433 RVA: 0x009458FC File Offset: 0x00943AFC
		// (set) Token: 0x060214F2 RID: 136434 RVA: 0x00945910 File Offset: 0x00943B10
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17003A68 RID: 14952
		// (get) Token: 0x060214F3 RID: 136435 RVA: 0x00945925 File Offset: 0x00943B25
		// (set) Token: 0x060214F4 RID: 136436 RVA: 0x00945939 File Offset: 0x00943B39
		public unsafe UTextureRenderTarget2D SkinMaskRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_69);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_69, value);
			}
		}

		// Token: 0x17003A69 RID: 14953
		// (get) Token: 0x060214F5 RID: 136437 RVA: 0x0094594E File Offset: 0x00943B4E
		// (set) Token: 0x060214F6 RID: 136438 RVA: 0x00945962 File Offset: 0x00943B62
		public unsafe UTexture2D TreePosTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_70);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_70, value);
			}
		}

		// Token: 0x17003A6A RID: 14954
		// (get) Token: 0x060214F7 RID: 136439 RVA: 0x00945977 File Offset: 0x00943B77
		// (set) Token: 0x060214F8 RID: 136440 RVA: 0x0094598B File Offset: 0x00943B8B
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17003A6B RID: 14955
		// (get) Token: 0x060214F9 RID: 136441 RVA: 0x009459A0 File Offset: 0x00943BA0
		// (set) Token: 0x060214FA RID: 136442 RVA: 0x009459B0 File Offset: 0x00943BB0
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_72) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_72) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A6C RID: 14956
		// (get) Token: 0x060214FB RID: 136443 RVA: 0x009459C1 File Offset: 0x00943BC1
		// (set) Token: 0x060214FC RID: 136444 RVA: 0x009459D1 File Offset: 0x00943BD1
		public unsafe bool debugWeapon_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_73) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_73) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A6D RID: 14957
		// (get) Token: 0x060214FD RID: 136445 RVA: 0x009459E2 File Offset: 0x00943BE2
		// (set) Token: 0x060214FE RID: 136446 RVA: 0x009459F2 File Offset: 0x00943BF2
		public unsafe bool debugDamage_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_74) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_74) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A6E RID: 14958
		// (get) Token: 0x060214FF RID: 136447 RVA: 0x00945A04 File Offset: 0x00943C04
		// (set) Token: 0x06021500 RID: 136448 RVA: 0x00945A3D File Offset: 0x00943C3D
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
					result = (this._SMComponents = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_75, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMComponents.CopyAssign(value);
			}
		}

		// Token: 0x17003A6F RID: 14959
		// (get) Token: 0x06021501 RID: 136449 RVA: 0x00945A4C File Offset: 0x00943C4C
		// (set) Token: 0x06021502 RID: 136450 RVA: 0x00945A85 File Offset: 0x00943C85
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
					result = (this._SMHealth = new TArray<float>(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_76, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMHealth.CopyAssign(value);
			}
		}

		// Token: 0x17003A70 RID: 14960
		// (get) Token: 0x06021503 RID: 136451 RVA: 0x00945A94 File Offset: 0x00943C94
		// (set) Token: 0x06021504 RID: 136452 RVA: 0x00945ACD File Offset: 0x00943CCD
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
					result = (this._ConsArr = new TArray<UPhysicsConstraintComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_77, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ConsArr.CopyAssign(value);
			}
		}

		// Token: 0x17003A71 RID: 14961
		// (get) Token: 0x06021505 RID: 136453 RVA: 0x00945ADC File Offset: 0x00943CDC
		// (set) Token: 0x06021506 RID: 136454 RVA: 0x00945B15 File Offset: 0x00943D15
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
					result = (this._ForceArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_78, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ForceArr.CopyAssign(value);
			}
		}

		// Token: 0x17003A72 RID: 14962
		// (get) Token: 0x06021507 RID: 136455 RVA: 0x00945B23 File Offset: 0x00943D23
		// (set) Token: 0x06021508 RID: 136456 RVA: 0x00945B33 File Offset: 0x00943D33
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_79) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_79) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A73 RID: 14963
		// (get) Token: 0x06021509 RID: 136457 RVA: 0x00945B44 File Offset: 0x00943D44
		// (set) Token: 0x0602150A RID: 136458 RVA: 0x00945B58 File Offset: 0x00943D58
		public unsafe FVector LastHitPositon
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_80);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_80) = value;
			}
		}

		// Token: 0x17003A74 RID: 14964
		// (get) Token: 0x0602150B RID: 136459 RVA: 0x00945B70 File Offset: 0x00943D70
		// (set) Token: 0x0602150C RID: 136460 RVA: 0x00945BA9 File Offset: 0x00943DA9
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
					result = (this._Wheels = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_81, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Wheels.CopyAssign(value);
			}
		}

		// Token: 0x17003A75 RID: 14965
		// (get) Token: 0x0602150D RID: 136461 RVA: 0x00945BB7 File Offset: 0x00943DB7
		// (set) Token: 0x0602150E RID: 136462 RVA: 0x00945BCB File Offset: 0x00943DCB
		public unsafe UNiagaraSystem NS_Bloom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_82);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_82, value);
			}
		}

		// Token: 0x17003A76 RID: 14966
		// (get) Token: 0x0602150F RID: 136463 RVA: 0x00945BE0 File Offset: 0x00943DE0
		// (set) Token: 0x06021510 RID: 136464 RVA: 0x00945BF4 File Offset: 0x00943DF4
		public unsafe UNiagaraSystem NS_Attack
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_83);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17003A77 RID: 14967
		// (get) Token: 0x06021511 RID: 136465 RVA: 0x00945C09 File Offset: 0x00943E09
		// (set) Token: 0x06021512 RID: 136466 RVA: 0x00945C19 File Offset: 0x00943E19
		public unsafe bool EngineAlreadyBreak
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_84) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_84) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A78 RID: 14968
		// (get) Token: 0x06021513 RID: 136467 RVA: 0x00945C2A File Offset: 0x00943E2A
		// (set) Token: 0x06021514 RID: 136468 RVA: 0x00945C3A File Offset: 0x00943E3A
		public unsafe bool EngineBreakOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_85) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_85) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A79 RID: 14969
		// (get) Token: 0x06021515 RID: 136469 RVA: 0x00945C4B File Offset: 0x00943E4B
		// (set) Token: 0x06021516 RID: 136470 RVA: 0x00945C5B File Offset: 0x00943E5B
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_86) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_86) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A7A RID: 14970
		// (get) Token: 0x06021517 RID: 136471 RVA: 0x00945C6C File Offset: 0x00943E6C
		// (set) Token: 0x06021518 RID: 136472 RVA: 0x00945C80 File Offset: 0x00943E80
		public unsafe UNiagaraSystem NS_CarFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_87);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_87, value);
			}
		}

		// Token: 0x17003A7B RID: 14971
		// (get) Token: 0x06021519 RID: 136473 RVA: 0x00945C95 File Offset: 0x00943E95
		// (set) Token: 0x0602151A RID: 136474 RVA: 0x00945CA9 File Offset: 0x00943EA9
		public unsafe UNiagaraSystem NS_EngineFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_88);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_88, value);
			}
		}

		// Token: 0x17003A7C RID: 14972
		// (get) Token: 0x0602151B RID: 136475 RVA: 0x00945CBE File Offset: 0x00943EBE
		// (set) Token: 0x0602151C RID: 136476 RVA: 0x00945CCE File Offset: 0x00943ECE
		public unsafe bool bDebug_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_89) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_89) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A7D RID: 14973
		// (get) Token: 0x0602151D RID: 136477 RVA: 0x00945CDF File Offset: 0x00943EDF
		// (set) Token: 0x0602151E RID: 136478 RVA: 0x00945CF3 File Offset: 0x00943EF3
		public unsafe UNiagaraSystem NS_TireBroken
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_90);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_90, value);
			}
		}

		// Token: 0x17003A7E RID: 14974
		// (get) Token: 0x0602151F RID: 136479 RVA: 0x00945D08 File Offset: 0x00943F08
		// (set) Token: 0x06021520 RID: 136480 RVA: 0x00945D18 File Offset: 0x00943F18
		public unsafe bool bIsOpen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_91) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_91) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A7F RID: 14975
		// (get) Token: 0x06021521 RID: 136481 RVA: 0x00945D29 File Offset: 0x00943F29
		// (set) Token: 0x06021522 RID: 136482 RVA: 0x00945D39 File Offset: 0x00943F39
		public unsafe bool bIsTrans
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_92) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_92) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A80 RID: 14976
		// (get) Token: 0x06021523 RID: 136483 RVA: 0x00945D4A File Offset: 0x00943F4A
		// (set) Token: 0x06021524 RID: 136484 RVA: 0x00945D5E File Offset: 0x00943F5E
		public unsafe FTransform LeftTrans1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x17003A81 RID: 14977
		// (get) Token: 0x06021525 RID: 136485 RVA: 0x00945D73 File Offset: 0x00943F73
		// (set) Token: 0x06021526 RID: 136486 RVA: 0x00945D87 File Offset: 0x00943F87
		public unsafe FTransform LeftTrans2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17003A82 RID: 14978
		// (get) Token: 0x06021527 RID: 136487 RVA: 0x00945D9C File Offset: 0x00943F9C
		// (set) Token: 0x06021528 RID: 136488 RVA: 0x00945DB0 File Offset: 0x00943FB0
		public unsafe FTransform LeftTrans3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x17003A83 RID: 14979
		// (get) Token: 0x06021529 RID: 136489 RVA: 0x00945DC5 File Offset: 0x00943FC5
		// (set) Token: 0x0602152A RID: 136490 RVA: 0x00945DD9 File Offset: 0x00943FD9
		public unsafe FTransform RightTrans1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17003A84 RID: 14980
		// (get) Token: 0x0602152B RID: 136491 RVA: 0x00945DEE File Offset: 0x00943FEE
		// (set) Token: 0x0602152C RID: 136492 RVA: 0x00945E02 File Offset: 0x00944002
		public unsafe FTransform RightTrans2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x17003A85 RID: 14981
		// (get) Token: 0x0602152D RID: 136493 RVA: 0x00945E17 File Offset: 0x00944017
		// (set) Token: 0x0602152E RID: 136494 RVA: 0x00945E2B File Offset: 0x0094402B
		public unsafe FTransform RightTrans3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_98);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_98) = value;
			}
		}

		// Token: 0x17003A86 RID: 14982
		// (get) Token: 0x0602152F RID: 136495 RVA: 0x00945E40 File Offset: 0x00944040
		// (set) Token: 0x06021530 RID: 136496 RVA: 0x00945E54 File Offset: 0x00944054
		public unsafe UAkAudioEvent CloseDoorSound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_99);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_99, value);
			}
		}

		// Token: 0x17003A87 RID: 14983
		// (get) Token: 0x06021531 RID: 136497 RVA: 0x00945E69 File Offset: 0x00944069
		// (set) Token: 0x06021532 RID: 136498 RVA: 0x00945E7D File Offset: 0x0094407D
		public unsafe UAkAudioEvent OpenDoorSound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_100);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_DoorOpen_C.__PropertyOffset_100, value);
			}
		}

		// Token: 0x17003A88 RID: 14984
		// (get) Token: 0x06021533 RID: 136499 RVA: 0x00945E92 File Offset: 0x00944092
		// (set) Token: 0x06021534 RID: 136500 RVA: 0x00945EA2 File Offset: 0x009440A2
		public unsafe float dtForNiagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17003A89 RID: 14985
		// (get) Token: 0x06021535 RID: 136501 RVA: 0x00945EB3 File Offset: 0x009440B3
		// (set) Token: 0x06021536 RID: 136502 RVA: 0x00945EC3 File Offset: 0x009440C3
		public unsafe int thisFrameWeaponID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17003A8A RID: 14986
		// (get) Token: 0x06021537 RID: 136503 RVA: 0x00945ED4 File Offset: 0x009440D4
		// (set) Token: 0x06021538 RID: 136504 RVA: 0x00945EE4 File Offset: 0x009440E4
		public unsafe int lastFrameWeaponID_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_DoorOpen_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x06021539 RID: 136505 RVA: 0x00945EF8 File Offset: 0x009440F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreateDM(UStaticMeshComponent Component)
		{
			BP_VehicleDamage_DoorOpen_C.__CreateDM_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__CreateDM_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__CreateDM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__CreateDM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Component = ((Component != null) ? Component.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__CreateDM_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602153A RID: 136506 RVA: 0x00945F4D File Offset: 0x0094414D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602153B RID: 136507 RVA: 0x00945F61 File Offset: 0x00944161
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602153C RID: 136508 RVA: 0x00945F76 File Offset: 0x00944176
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602153D RID: 136509 RVA: 0x00945F8A File Offset: 0x0094418A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602153E RID: 136510 RVA: 0x00945F9E File Offset: 0x0094419E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_1__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_1__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602153F RID: 136511 RVA: 0x00945FB2 File Offset: 0x009441B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_1__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_1__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021540 RID: 136512 RVA: 0x00945FC6 File Offset: 0x009441C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_2__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_2__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021541 RID: 136513 RVA: 0x00945FDA File Offset: 0x009441DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_2__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_2__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021542 RID: 136514 RVA: 0x00945FEE File Offset: 0x009441EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_3__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_3__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021543 RID: 136515 RVA: 0x00946002 File Offset: 0x00944202
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_3__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_3__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021544 RID: 136516 RVA: 0x00946016 File Offset: 0x00944216
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_4__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_4__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021545 RID: 136517 RVA: 0x0094602A File Offset: 0x0094422A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_4__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_4__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021546 RID: 136518 RVA: 0x0094603E File Offset: 0x0094423E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_5__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_5__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021547 RID: 136519 RVA: 0x00946052 File Offset: 0x00944252
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_5__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_5__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021548 RID: 136520 RVA: 0x00946066 File Offset: 0x00944266
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_6__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_6__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06021549 RID: 136521 RVA: 0x0094607A File Offset: 0x0094427A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_6__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_6__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602154A RID: 136522 RVA: 0x0094608E File Offset: 0x0094428E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_7__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_7__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602154B RID: 136523 RVA: 0x009460A2 File Offset: 0x009442A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_7__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Timeline_7__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602154C RID: 136524 RVA: 0x009460B8 File Offset: 0x009442B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_40EBA32A4F2AE716AE3B93815F1DEEE3(int PlayingID)
		{
			BP_VehicleDamage_DoorOpen_C.__Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602154D RID: 136525 RVA: 0x00946100 File Offset: 0x00944300
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_64E97B4B44529050B8596992FBAF5F9B(int PlayingID)
		{
			BP_VehicleDamage_DoorOpen_C.__Completed_64E97B4B44529050B8596992FBAF5F9B_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__Completed_64E97B4B44529050B8596992FBAF5F9B_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__Completed_64E97B4B44529050B8596992FBAF5F9B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__Completed_64E97B4B44529050B8596992FBAF5F9B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Completed_64E97B4B44529050B8596992FBAF5F9B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602154E RID: 136526 RVA: 0x00946148 File Offset: 0x00944348
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_79CF6ACA42AAF8B84E41119679134833(int PlayingID)
		{
			BP_VehicleDamage_DoorOpen_C.__Completed_79CF6ACA42AAF8B84E41119679134833_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__Completed_79CF6ACA42AAF8B84E41119679134833_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__Completed_79CF6ACA42AAF8B84E41119679134833_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__Completed_79CF6ACA42AAF8B84E41119679134833_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Completed_79CF6ACA42AAF8B84E41119679134833_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602154F RID: 136527 RVA: 0x00946190 File Offset: 0x00944390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_6B35900D4459C9E45C6E11A80F474F74(int PlayingID)
		{
			BP_VehicleDamage_DoorOpen_C.__Completed_6B35900D4459C9E45C6E11A80F474F74_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__Completed_6B35900D4459C9E45C6E11A80F474F74_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__Completed_6B35900D4459C9E45C6E11A80F474F74_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__Completed_6B35900D4459C9E45C6E11A80F474F74_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Completed_6B35900D4459C9E45C6E11A80F474F74_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021550 RID: 136528 RVA: 0x009461D8 File Offset: 0x009443D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_37097A5140DB97D8CA4BC6A54466E558(int PlayingID)
		{
			BP_VehicleDamage_DoorOpen_C.__Completed_37097A5140DB97D8CA4BC6A54466E558_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__Completed_37097A5140DB97D8CA4BC6A54466E558_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__Completed_37097A5140DB97D8CA4BC6A54466E558_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__Completed_37097A5140DB97D8CA4BC6A54466E558_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__Completed_37097A5140DB97D8CA4BC6A54466E558_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021551 RID: 136529 RVA: 0x0094621E File Offset: 0x0094441E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x06021552 RID: 136530 RVA: 0x00946232 File Offset: 0x00944432
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__CustomEvent_NativeFunctionPtr, null);
		}

		// Token: 0x06021553 RID: 136531 RVA: 0x00946248 File Offset: 0x00944448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_VehicleDamage_DoorOpen_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021554 RID: 136532 RVA: 0x009462AC File Offset: 0x009444AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VehicleDamage_DoorOpen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021555 RID: 136533 RVA: 0x009462F4 File Offset: 0x009444F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VehicleDamage_DoorOpen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021556 RID: 136534 RVA: 0x0094633B File Offset: 0x0094453B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021557 RID: 136535 RVA: 0x0094634F File Offset: 0x0094454F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021558 RID: 136536 RVA: 0x00946364 File Offset: 0x00944564
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021559 RID: 136537 RVA: 0x00946378 File Offset: 0x00944578
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__test_NativeFunctionPtr, null);
		}

		// Token: 0x0602155A RID: 136538 RVA: 0x0094638C File Offset: 0x0094458C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnVehiclePartBroken_Event_0(int PartIndex, string PartName)
		{
			BP_VehicleDamage_DoorOpen_C.__OnVehiclePartBroken_Event_0_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__OnVehiclePartBroken_Event_0_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__OnVehiclePartBroken_Event_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PartIndex = PartIndex;
			FString.CopyFrom((void*)(&ptr->PartName), PartName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_VehicleDamage_DoorOpen_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602155B RID: 136539 RVA: 0x009463F0 File Offset: 0x009445F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602155C RID: 136540 RVA: 0x009464AC File Offset: 0x009446AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602155D RID: 136541 RVA: 0x00946538 File Offset: 0x00944738
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VehicleDamage_DoorOpen(int EntryPoint)
		{
			BP_VehicleDamage_DoorOpen_C.__ExecuteUbergraph_BP_VehicleDamage_DoorOpen_FunctionParams* ptr = stackalloc BP_VehicleDamage_DoorOpen_C.__ExecuteUbergraph_BP_VehicleDamage_DoorOpen_FunctionParams[(UIntPtr)5359] + 15L / (long)sizeof(BP_VehicleDamage_DoorOpen_C.__ExecuteUbergraph_BP_VehicleDamage_DoorOpen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_DoorOpen_C.__ExecuteUbergraph_BP_VehicleDamage_DoorOpen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_DoorOpen_C.__ExecuteUbergraph_BP_VehicleDamage_DoorOpen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602155E RID: 136542 RVA: 0x00946582 File Offset: 0x00944782
		protected BP_VehicleDamage_DoorOpen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010BD2 RID: 68562
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage_DoorOpen.BP_VehicleDamage_DoorOpen_C";

		// Token: 0x04010BD3 RID: 68563
		private static IntPtr _ClassPtr;

		// Token: 0x04010BD4 RID: 68564
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010BD5 RID: 68565
		internal static int __PropertyOffset_0;

		// Token: 0x04010BD6 RID: 68566
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010BD7 RID: 68567
		internal static int __PropertyOffset_1;

		// Token: 0x04010BD8 RID: 68568
		internal static int __PropertyOffset_2;

		// Token: 0x04010BD9 RID: 68569
		internal static int __PropertyOffset_3;

		// Token: 0x04010BDA RID: 68570
		internal static int __PropertyOffset_4;

		// Token: 0x04010BDB RID: 68571
		internal static int __PropertyOffset_5;

		// Token: 0x04010BDC RID: 68572
		internal static int __PropertyOffset_6;

		// Token: 0x04010BDD RID: 68573
		internal static int __PropertyOffset_7;

		// Token: 0x04010BDE RID: 68574
		internal static int __PropertyOffset_8;

		// Token: 0x04010BDF RID: 68575
		internal static int __PropertyOffset_9;

		// Token: 0x04010BE0 RID: 68576
		internal static int __PropertyOffset_10;

		// Token: 0x04010BE1 RID: 68577
		internal static int __PropertyOffset_11;

		// Token: 0x04010BE2 RID: 68578
		internal static int __PropertyOffset_12;

		// Token: 0x04010BE3 RID: 68579
		internal static int __PropertyOffset_13;

		// Token: 0x04010BE4 RID: 68580
		internal static int __PropertyOffset_14;

		// Token: 0x04010BE5 RID: 68581
		internal static int __PropertyOffset_15;

		// Token: 0x04010BE6 RID: 68582
		internal static int __PropertyOffset_16;

		// Token: 0x04010BE7 RID: 68583
		internal static int __PropertyOffset_17;

		// Token: 0x04010BE8 RID: 68584
		internal static int __PropertyOffset_18;

		// Token: 0x04010BE9 RID: 68585
		internal static int __PropertyOffset_19;

		// Token: 0x04010BEA RID: 68586
		internal static int __PropertyOffset_20;

		// Token: 0x04010BEB RID: 68587
		internal static int __PropertyOffset_21;

		// Token: 0x04010BEC RID: 68588
		internal static int __PropertyOffset_22;

		// Token: 0x04010BED RID: 68589
		internal static int __PropertyOffset_23;

		// Token: 0x04010BEE RID: 68590
		internal static int __PropertyOffset_24;

		// Token: 0x04010BEF RID: 68591
		internal static int __PropertyOffset_25;

		// Token: 0x04010BF0 RID: 68592
		internal static int __PropertyOffset_26;

		// Token: 0x04010BF1 RID: 68593
		internal static int __PropertyOffset_27;

		// Token: 0x04010BF2 RID: 68594
		internal static int __PropertyOffset_28;

		// Token: 0x04010BF3 RID: 68595
		internal static int __PropertyOffset_29;

		// Token: 0x04010BF4 RID: 68596
		internal static int __PropertyOffset_30;

		// Token: 0x04010BF5 RID: 68597
		internal static int __PropertyOffset_31;

		// Token: 0x04010BF6 RID: 68598
		internal static int __PropertyOffset_32;

		// Token: 0x04010BF7 RID: 68599
		internal static int __PropertyOffset_33;

		// Token: 0x04010BF8 RID: 68600
		internal static int __PropertyOffset_34;

		// Token: 0x04010BF9 RID: 68601
		internal static int __PropertyOffset_35;

		// Token: 0x04010BFA RID: 68602
		internal static int __PropertyOffset_36;

		// Token: 0x04010BFB RID: 68603
		internal static int __PropertyOffset_37;

		// Token: 0x04010BFC RID: 68604
		internal static int __PropertyOffset_38;

		// Token: 0x04010BFD RID: 68605
		internal static int __PropertyOffset_39;

		// Token: 0x04010BFE RID: 68606
		internal static int __PropertyOffset_40;

		// Token: 0x04010BFF RID: 68607
		internal static int __PropertyOffset_41;

		// Token: 0x04010C00 RID: 68608
		internal static int __PropertyOffset_42;

		// Token: 0x04010C01 RID: 68609
		internal static int __PropertyOffset_43;

		// Token: 0x04010C02 RID: 68610
		internal static int __PropertyOffset_44;

		// Token: 0x04010C03 RID: 68611
		internal static int __PropertyOffset_45;

		// Token: 0x04010C04 RID: 68612
		internal static int __PropertyOffset_46;

		// Token: 0x04010C05 RID: 68613
		internal static int __PropertyOffset_47;

		// Token: 0x04010C06 RID: 68614
		internal static int __PropertyOffset_48;

		// Token: 0x04010C07 RID: 68615
		internal static int __PropertyOffset_49;

		// Token: 0x04010C08 RID: 68616
		internal static int __PropertyOffset_50;

		// Token: 0x04010C09 RID: 68617
		internal static int __PropertyOffset_51;

		// Token: 0x04010C0A RID: 68618
		internal static int __PropertyOffset_52;

		// Token: 0x04010C0B RID: 68619
		internal static int __PropertyOffset_53;

		// Token: 0x04010C0C RID: 68620
		internal static int __PropertyOffset_54;

		// Token: 0x04010C0D RID: 68621
		internal static int __PropertyOffset_55;

		// Token: 0x04010C0E RID: 68622
		internal static int __PropertyOffset_56;

		// Token: 0x04010C0F RID: 68623
		internal static int __PropertyOffset_57;

		// Token: 0x04010C10 RID: 68624
		internal static int __PropertyOffset_58;

		// Token: 0x04010C11 RID: 68625
		internal static int __PropertyOffset_59;

		// Token: 0x04010C12 RID: 68626
		internal static int __PropertyOffset_60;

		// Token: 0x04010C13 RID: 68627
		internal static int __PropertyOffset_61;

		// Token: 0x04010C14 RID: 68628
		internal static int __PropertyOffset_62;

		// Token: 0x04010C15 RID: 68629
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CarAllMats;

		// Token: 0x04010C16 RID: 68630
		internal static int __PropertyOffset_63;

		// Token: 0x04010C17 RID: 68631
		internal static int __PropertyOffset_64;

		// Token: 0x04010C18 RID: 68632
		internal static int __PropertyOffset_65;

		// Token: 0x04010C19 RID: 68633
		internal static int __PropertyOffset_66;

		// Token: 0x04010C1A RID: 68634
		internal static int __PropertyOffset_67;

		// Token: 0x04010C1B RID: 68635
		internal static int __PropertyOffset_68;

		// Token: 0x04010C1C RID: 68636
		internal static int __PropertyOffset_69;

		// Token: 0x04010C1D RID: 68637
		internal static int __PropertyOffset_70;

		// Token: 0x04010C1E RID: 68638
		internal static int __PropertyOffset_71;

		// Token: 0x04010C1F RID: 68639
		internal static int __PropertyOffset_72;

		// Token: 0x04010C20 RID: 68640
		internal static int __PropertyOffset_73;

		// Token: 0x04010C21 RID: 68641
		internal static int __PropertyOffset_74;

		// Token: 0x04010C22 RID: 68642
		internal static int __PropertyOffset_75;

		// Token: 0x04010C23 RID: 68643
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMComponents;

		// Token: 0x04010C24 RID: 68644
		internal static int __PropertyOffset_76;

		// Token: 0x04010C25 RID: 68645
		private TArray<float> _SMHealth;

		// Token: 0x04010C26 RID: 68646
		internal static int __PropertyOffset_77;

		// Token: 0x04010C27 RID: 68647
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UPhysicsConstraintComponent> _ConsArr;

		// Token: 0x04010C28 RID: 68648
		internal static int __PropertyOffset_78;

		// Token: 0x04010C29 RID: 68649
		private TArray<FVector> _ForceArr;

		// Token: 0x04010C2A RID: 68650
		internal static int __PropertyOffset_79;

		// Token: 0x04010C2B RID: 68651
		internal static int __PropertyOffset_80;

		// Token: 0x04010C2C RID: 68652
		internal static int __PropertyOffset_81;

		// Token: 0x04010C2D RID: 68653
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _Wheels;

		// Token: 0x04010C2E RID: 68654
		internal static int __PropertyOffset_82;

		// Token: 0x04010C2F RID: 68655
		internal static int __PropertyOffset_83;

		// Token: 0x04010C30 RID: 68656
		internal static int __PropertyOffset_84;

		// Token: 0x04010C31 RID: 68657
		internal static int __PropertyOffset_85;

		// Token: 0x04010C32 RID: 68658
		internal static int __PropertyOffset_86;

		// Token: 0x04010C33 RID: 68659
		internal static int __PropertyOffset_87;

		// Token: 0x04010C34 RID: 68660
		internal static int __PropertyOffset_88;

		// Token: 0x04010C35 RID: 68661
		internal static int __PropertyOffset_89;

		// Token: 0x04010C36 RID: 68662
		internal static int __PropertyOffset_90;

		// Token: 0x04010C37 RID: 68663
		internal static int __PropertyOffset_91;

		// Token: 0x04010C38 RID: 68664
		internal static int __PropertyOffset_92;

		// Token: 0x04010C39 RID: 68665
		internal static int __PropertyOffset_93;

		// Token: 0x04010C3A RID: 68666
		internal static int __PropertyOffset_94;

		// Token: 0x04010C3B RID: 68667
		internal static int __PropertyOffset_95;

		// Token: 0x04010C3C RID: 68668
		internal static int __PropertyOffset_96;

		// Token: 0x04010C3D RID: 68669
		internal static int __PropertyOffset_97;

		// Token: 0x04010C3E RID: 68670
		internal static int __PropertyOffset_98;

		// Token: 0x04010C3F RID: 68671
		internal static int __PropertyOffset_99;

		// Token: 0x04010C40 RID: 68672
		internal static int __PropertyOffset_100;

		// Token: 0x04010C41 RID: 68673
		internal static int __PropertyOffset_101;

		// Token: 0x04010C42 RID: 68674
		internal static int __PropertyOffset_102;

		// Token: 0x04010C43 RID: 68675
		internal static int __PropertyOffset_103;

		// Token: 0x04010C44 RID: 68676
		private static IntPtr __CreateDM_NativeFunctionPtr;

		// Token: 0x04010C45 RID: 68677
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010C46 RID: 68678
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C47 RID: 68679
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C48 RID: 68680
		private static IntPtr __Timeline_1__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C49 RID: 68681
		private static IntPtr __Timeline_1__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C4A RID: 68682
		private static IntPtr __Timeline_2__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C4B RID: 68683
		private static IntPtr __Timeline_2__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C4C RID: 68684
		private static IntPtr __Timeline_3__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C4D RID: 68685
		private static IntPtr __Timeline_3__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C4E RID: 68686
		private static IntPtr __Timeline_4__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C4F RID: 68687
		private static IntPtr __Timeline_4__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C50 RID: 68688
		private static IntPtr __Timeline_5__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C51 RID: 68689
		private static IntPtr __Timeline_5__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C52 RID: 68690
		private static IntPtr __Timeline_6__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C53 RID: 68691
		private static IntPtr __Timeline_6__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C54 RID: 68692
		private static IntPtr __Timeline_7__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04010C55 RID: 68693
		private static IntPtr __Timeline_7__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04010C56 RID: 68694
		private static IntPtr __Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_NativeFunctionPtr;

		// Token: 0x04010C57 RID: 68695
		private static IntPtr __Completed_64E97B4B44529050B8596992FBAF5F9B_NativeFunctionPtr;

		// Token: 0x04010C58 RID: 68696
		private static IntPtr __Completed_79CF6ACA42AAF8B84E41119679134833_NativeFunctionPtr;

		// Token: 0x04010C59 RID: 68697
		private static IntPtr __Completed_6B35900D4459C9E45C6E11A80F474F74_NativeFunctionPtr;

		// Token: 0x04010C5A RID: 68698
		private static IntPtr __Completed_37097A5140DB97D8CA4BC6A54466E558_NativeFunctionPtr;

		// Token: 0x04010C5B RID: 68699
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010C5C RID: 68700
		private static IntPtr __CustomEvent_NativeFunctionPtr;

		// Token: 0x04010C5D RID: 68701
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04010C5E RID: 68702
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010C5F RID: 68703
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010C60 RID: 68704
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010C61 RID: 68705
		private static IntPtr __test_NativeFunctionPtr;

		// Token: 0x04010C62 RID: 68706
		private static IntPtr __OnVehiclePartBroken_Event_0_NativeFunctionPtr;

		// Token: 0x04010C63 RID: 68707
		private static IntPtr __BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010C64 RID: 68708
		private static IntPtr __BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010C65 RID: 68709
		private static IntPtr __ExecuteUbergraph_BP_VehicleDamage_DoorOpen_NativeFunctionPtr;

		// Token: 0x02009AAD RID: 39597
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __CreateDM_FunctionParams
		{
			// Token: 0x04032215 RID: 205333
			[FieldOffset(0)]
			public IntPtr Component;
		}

		// Token: 0x02009AAE RID: 39598
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_40EBA32A4F2AE716AE3B93815F1DEEE3_FunctionParams
		{
			// Token: 0x04032216 RID: 205334
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AAF RID: 39599
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_64E97B4B44529050B8596992FBAF5F9B_FunctionParams
		{
			// Token: 0x04032217 RID: 205335
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AB0 RID: 39600
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_79CF6ACA42AAF8B84E41119679134833_FunctionParams
		{
			// Token: 0x04032218 RID: 205336
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AB1 RID: 39601
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_6B35900D4459C9E45C6E11A80F474F74_FunctionParams
		{
			// Token: 0x04032219 RID: 205337
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AB2 RID: 39602
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_37097A5140DB97D8CA4BC6A54466E558_FunctionParams
		{
			// Token: 0x0403221A RID: 205338
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AB3 RID: 39603
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x0403221B RID: 205339
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x0403221C RID: 205340
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x0403221D RID: 205341
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009AB4 RID: 39604
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403221E RID: 205342
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AB5 RID: 39605
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnVehiclePartBroken_Event_0_FunctionParams
		{
			// Token: 0x0403221F RID: 205343
			[FieldOffset(0)]
			public int PartIndex;

			// Token: 0x04032220 RID: 205344
			[FieldOffset(8)]
			public FString PartName;
		}

		// Token: 0x02009AB6 RID: 39606
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032221 RID: 205345
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032222 RID: 205346
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032223 RID: 205347
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032224 RID: 205348
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032225 RID: 205349
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032226 RID: 205350
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009AB7 RID: 39607
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032227 RID: 205351
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032228 RID: 205352
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032229 RID: 205353
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403222A RID: 205354
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009AB8 RID: 39608
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5344)]
		protected ref struct __ExecuteUbergraph_BP_VehicleDamage_DoorOpen_FunctionParams
		{
			// Token: 0x0403222B RID: 205355
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
