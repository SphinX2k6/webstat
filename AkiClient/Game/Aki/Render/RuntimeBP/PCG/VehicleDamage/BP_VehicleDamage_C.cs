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
	// Token: 0x02003B5F RID: 15199
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage.BP_VehicleDamage_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_VehicleDamage_C : AKuroVehicleDestructionActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060213C9 RID: 136137 RVA: 0x00943E30 File Offset: 0x00942030
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VehicleDamage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage.BP_VehicleDamage_C");
			}
			return BP_VehicleDamage_C._ClassPtr;
		}

		// Token: 0x060213CA RID: 136138 RVA: 0x00943E54 File Offset: 0x00942054
		public BP_VehicleDamage_C() : this(BuiltinUtils.AllocNativeUObject(BP_VehicleDamage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060213CB RID: 136139 RVA: 0x00943E7C File Offset: 0x0094207C
		[NullableContext(1)]
		public BP_VehicleDamage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VehicleDamage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170039DF RID: 14815
		// (get) Token: 0x060213CC RID: 136140 RVA: 0x00943EB0 File Offset: 0x009420B0
		// (set) Token: 0x060213CD RID: 136141 RVA: 0x00943EE9 File Offset: 0x009420E9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170039E0 RID: 14816
		// (get) Token: 0x060213CE RID: 136142 RVA: 0x00943F0A File Offset: 0x0094210A
		// (set) Token: 0x060213CF RID: 136143 RVA: 0x00943F1E File Offset: 0x0094211E
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170039E1 RID: 14817
		// (get) Token: 0x060213D0 RID: 136144 RVA: 0x00943F33 File Offset: 0x00942133
		// (set) Token: 0x060213D1 RID: 136145 RVA: 0x00943F47 File Offset: 0x00942147
		public unsafe UStaticMeshComponent blast_10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170039E2 RID: 14818
		// (get) Token: 0x060213D2 RID: 136146 RVA: 0x00943F5C File Offset: 0x0094215C
		// (set) Token: 0x060213D3 RID: 136147 RVA: 0x00943F70 File Offset: 0x00942170
		public unsafe UBoxComponent myCustomBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170039E3 RID: 14819
		// (get) Token: 0x060213D4 RID: 136148 RVA: 0x00943F85 File Offset: 0x00942185
		// (set) Token: 0x060213D5 RID: 136149 RVA: 0x00943F99 File Offset: 0x00942199
		public unsafe UNiagaraComponent NS_VehicleFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170039E4 RID: 14820
		// (get) Token: 0x060213D6 RID: 136150 RVA: 0x00943FAE File Offset: 0x009421AE
		// (set) Token: 0x060213D7 RID: 136151 RVA: 0x00943FC2 File Offset: 0x009421C2
		public unsafe UNiagaraComponent NS_VehicleBloom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170039E5 RID: 14821
		// (get) Token: 0x060213D8 RID: 136152 RVA: 0x00943FD7 File Offset: 0x009421D7
		// (set) Token: 0x060213D9 RID: 136153 RVA: 0x00943FEB File Offset: 0x009421EB
		public unsafe UBoxComponent ValidAttackBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170039E6 RID: 14822
		// (get) Token: 0x060213DA RID: 136154 RVA: 0x00944000 File Offset: 0x00942200
		// (set) Token: 0x060213DB RID: 136155 RVA: 0x00944014 File Offset: 0x00942214
		public unsafe UNiagaraComponent NS_engineFly
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170039E7 RID: 14823
		// (get) Token: 0x060213DC RID: 136156 RVA: 0x00944029 File Offset: 0x00942229
		// (set) Token: 0x060213DD RID: 136157 RVA: 0x0094403D File Offset: 0x0094223D
		public unsafe UStaticMeshComponent blast_small14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170039E8 RID: 14824
		// (get) Token: 0x060213DE RID: 136158 RVA: 0x00944052 File Offset: 0x00942252
		// (set) Token: 0x060213DF RID: 136159 RVA: 0x00944066 File Offset: 0x00942266
		public unsafe UStaticMeshComponent blast_small10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170039E9 RID: 14825
		// (get) Token: 0x060213E0 RID: 136160 RVA: 0x0094407B File Offset: 0x0094227B
		// (set) Token: 0x060213E1 RID: 136161 RVA: 0x0094408F File Offset: 0x0094228F
		public unsafe UStaticMeshComponent blast_small13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170039EA RID: 14826
		// (get) Token: 0x060213E2 RID: 136162 RVA: 0x009440A4 File Offset: 0x009422A4
		// (set) Token: 0x060213E3 RID: 136163 RVA: 0x009440B8 File Offset: 0x009422B8
		public unsafe UStaticMeshComponent blast_small12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170039EB RID: 14827
		// (get) Token: 0x060213E4 RID: 136164 RVA: 0x009440CD File Offset: 0x009422CD
		// (set) Token: 0x060213E5 RID: 136165 RVA: 0x009440E1 File Offset: 0x009422E1
		public unsafe UStaticMeshComponent blast_small11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170039EC RID: 14828
		// (get) Token: 0x060213E6 RID: 136166 RVA: 0x009440F6 File Offset: 0x009422F6
		// (set) Token: 0x060213E7 RID: 136167 RVA: 0x0094410A File Offset: 0x0094230A
		public unsafe UStaticMeshComponent blast_small8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170039ED RID: 14829
		// (get) Token: 0x060213E8 RID: 136168 RVA: 0x0094411F File Offset: 0x0094231F
		// (set) Token: 0x060213E9 RID: 136169 RVA: 0x00944133 File Offset: 0x00942333
		public unsafe UStaticMeshComponent blast_small9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170039EE RID: 14830
		// (get) Token: 0x060213EA RID: 136170 RVA: 0x00944148 File Offset: 0x00942348
		// (set) Token: 0x060213EB RID: 136171 RVA: 0x0094415C File Offset: 0x0094235C
		public unsafe UStaticMeshComponent blast_small7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170039EF RID: 14831
		// (get) Token: 0x060213EC RID: 136172 RVA: 0x00944171 File Offset: 0x00942371
		// (set) Token: 0x060213ED RID: 136173 RVA: 0x00944185 File Offset: 0x00942385
		public unsafe UStaticMeshComponent blast_small5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170039F0 RID: 14832
		// (get) Token: 0x060213EE RID: 136174 RVA: 0x0094419A File Offset: 0x0094239A
		// (set) Token: 0x060213EF RID: 136175 RVA: 0x009441AE File Offset: 0x009423AE
		public unsafe UStaticMeshComponent blast_small6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170039F1 RID: 14833
		// (get) Token: 0x060213F0 RID: 136176 RVA: 0x009441C3 File Offset: 0x009423C3
		// (set) Token: 0x060213F1 RID: 136177 RVA: 0x009441D7 File Offset: 0x009423D7
		public unsafe UStaticMeshComponent blast_small2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170039F2 RID: 14834
		// (get) Token: 0x060213F2 RID: 136178 RVA: 0x009441EC File Offset: 0x009423EC
		// (set) Token: 0x060213F3 RID: 136179 RVA: 0x00944200 File Offset: 0x00942400
		public unsafe UStaticMeshComponent blast_small3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170039F3 RID: 14835
		// (get) Token: 0x060213F4 RID: 136180 RVA: 0x00944215 File Offset: 0x00942415
		// (set) Token: 0x060213F5 RID: 136181 RVA: 0x00944229 File Offset: 0x00942429
		public unsafe UStaticMeshComponent blast_small1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170039F4 RID: 14836
		// (get) Token: 0x060213F6 RID: 136182 RVA: 0x0094423E File Offset: 0x0094243E
		// (set) Token: 0x060213F7 RID: 136183 RVA: 0x00944252 File Offset: 0x00942452
		public unsafe UPhysicsConstraintComponent cons_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170039F5 RID: 14837
		// (get) Token: 0x060213F8 RID: 136184 RVA: 0x00944267 File Offset: 0x00942467
		// (set) Token: 0x060213F9 RID: 136185 RVA: 0x0094427B File Offset: 0x0094247B
		public unsafe UStaticMeshComponent blast_back_cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170039F6 RID: 14838
		// (get) Token: 0x060213FA RID: 136186 RVA: 0x00944290 File Offset: 0x00942490
		// (set) Token: 0x060213FB RID: 136187 RVA: 0x009442A4 File Offset: 0x009424A4
		public unsafe UStaticMeshComponent blast_wheel3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170039F7 RID: 14839
		// (get) Token: 0x060213FC RID: 136188 RVA: 0x009442B9 File Offset: 0x009424B9
		// (set) Token: 0x060213FD RID: 136189 RVA: 0x009442CD File Offset: 0x009424CD
		public unsafe UStaticMeshComponent blast_wheel2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170039F8 RID: 14840
		// (get) Token: 0x060213FE RID: 136190 RVA: 0x009442E2 File Offset: 0x009424E2
		// (set) Token: 0x060213FF RID: 136191 RVA: 0x009442F6 File Offset: 0x009424F6
		public unsafe UStaticMeshComponent blast_wheel1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170039F9 RID: 14841
		// (get) Token: 0x06021400 RID: 136192 RVA: 0x0094430B File Offset: 0x0094250B
		// (set) Token: 0x06021401 RID: 136193 RVA: 0x0094431F File Offset: 0x0094251F
		public unsafe UStaticMeshComponent blast_wheel4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x170039FA RID: 14842
		// (get) Token: 0x06021402 RID: 136194 RVA: 0x00944334 File Offset: 0x00942534
		// (set) Token: 0x06021403 RID: 136195 RVA: 0x00944348 File Offset: 0x00942548
		public unsafe UStaticMeshComponent blast_front_cover
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170039FB RID: 14843
		// (get) Token: 0x06021404 RID: 136196 RVA: 0x0094435D File Offset: 0x0094255D
		// (set) Token: 0x06021405 RID: 136197 RVA: 0x00944371 File Offset: 0x00942571
		public unsafe UPhysicsConstraintComponent cons_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170039FC RID: 14844
		// (get) Token: 0x06021406 RID: 136198 RVA: 0x00944386 File Offset: 0x00942586
		// (set) Token: 0x06021407 RID: 136199 RVA: 0x0094439A File Offset: 0x0094259A
		public unsafe UPhysicsConstraintComponent cons_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x170039FD RID: 14845
		// (get) Token: 0x06021408 RID: 136200 RVA: 0x009443AF File Offset: 0x009425AF
		// (set) Token: 0x06021409 RID: 136201 RVA: 0x009443C3 File Offset: 0x009425C3
		public unsafe UPhysicsConstraintComponent cons_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x170039FE RID: 14846
		// (get) Token: 0x0602140A RID: 136202 RVA: 0x009443D8 File Offset: 0x009425D8
		// (set) Token: 0x0602140B RID: 136203 RVA: 0x009443EC File Offset: 0x009425EC
		public unsafe UStaticMeshComponent blast3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x170039FF RID: 14847
		// (get) Token: 0x0602140C RID: 136204 RVA: 0x00944401 File Offset: 0x00942601
		// (set) Token: 0x0602140D RID: 136205 RVA: 0x00944415 File Offset: 0x00942615
		public unsafe UStaticMeshComponent blast2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003A00 RID: 14848
		// (get) Token: 0x0602140E RID: 136206 RVA: 0x0094442A File Offset: 0x0094262A
		// (set) Token: 0x0602140F RID: 136207 RVA: 0x0094443E File Offset: 0x0094263E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003A01 RID: 14849
		// (get) Token: 0x06021410 RID: 136208 RVA: 0x00944453 File Offset: 0x00942653
		// (set) Token: 0x06021411 RID: 136209 RVA: 0x00944467 File Offset: 0x00942667
		public unsafe UStaticMeshComponent SM_vehicleDamage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003A02 RID: 14850
		// (get) Token: 0x06021412 RID: 136210 RVA: 0x0094447C File Offset: 0x0094267C
		// (set) Token: 0x06021413 RID: 136211 RVA: 0x00944490 File Offset: 0x00942690
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003A03 RID: 14851
		// (get) Token: 0x06021414 RID: 136212 RVA: 0x009444A5 File Offset: 0x009426A5
		// (set) Token: 0x06021415 RID: 136213 RVA: 0x009444B9 File Offset: 0x009426B9
		public unsafe UMaterialInstanceDynamic StampMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003A04 RID: 14852
		// (get) Token: 0x06021416 RID: 136214 RVA: 0x009444D0 File Offset: 0x009426D0
		// (set) Token: 0x06021417 RID: 136215 RVA: 0x00944509 File Offset: 0x00942709
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
					result = (this._CarAllMats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CarAllMats.CopyAssign(value);
			}
		}

		// Token: 0x17003A05 RID: 14853
		// (get) Token: 0x06021418 RID: 136216 RVA: 0x00944517 File Offset: 0x00942717
		// (set) Token: 0x06021419 RID: 136217 RVA: 0x0094452B File Offset: 0x0094272B
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003A06 RID: 14854
		// (get) Token: 0x0602141A RID: 136218 RVA: 0x00944540 File Offset: 0x00942740
		// (set) Token: 0x0602141B RID: 136219 RVA: 0x00944550 File Offset: 0x00942750
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003A07 RID: 14855
		// (get) Token: 0x0602141C RID: 136220 RVA: 0x00944561 File Offset: 0x00942761
		// (set) Token: 0x0602141D RID: 136221 RVA: 0x00944571 File Offset: 0x00942771
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003A08 RID: 14856
		// (get) Token: 0x0602141E RID: 136222 RVA: 0x00944582 File Offset: 0x00942782
		// (set) Token: 0x0602141F RID: 136223 RVA: 0x00944596 File Offset: 0x00942796
		public unsafe FVector CurWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17003A09 RID: 14857
		// (get) Token: 0x06021420 RID: 136224 RVA: 0x009445AB File Offset: 0x009427AB
		// (set) Token: 0x06021421 RID: 136225 RVA: 0x009445BF File Offset: 0x009427BF
		public unsafe FVector hittingPoint_world_position_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17003A0A RID: 14858
		// (get) Token: 0x06021422 RID: 136226 RVA: 0x009445D4 File Offset: 0x009427D4
		// (set) Token: 0x06021423 RID: 136227 RVA: 0x009445E8 File Offset: 0x009427E8
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003A0B RID: 14859
		// (get) Token: 0x06021424 RID: 136228 RVA: 0x009445FD File Offset: 0x009427FD
		// (set) Token: 0x06021425 RID: 136229 RVA: 0x00944611 File Offset: 0x00942811
		public unsafe UTextureRenderTarget2D SkinMaskRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003A0C RID: 14860
		// (get) Token: 0x06021426 RID: 136230 RVA: 0x00944626 File Offset: 0x00942826
		// (set) Token: 0x06021427 RID: 136231 RVA: 0x0094463A File Offset: 0x0094283A
		public unsafe UTexture2D TreePosTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17003A0D RID: 14861
		// (get) Token: 0x06021428 RID: 136232 RVA: 0x0094464F File Offset: 0x0094284F
		// (set) Token: 0x06021429 RID: 136233 RVA: 0x00944663 File Offset: 0x00942863
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17003A0E RID: 14862
		// (get) Token: 0x0602142A RID: 136234 RVA: 0x00944678 File Offset: 0x00942878
		// (set) Token: 0x0602142B RID: 136235 RVA: 0x00944688 File Offset: 0x00942888
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A0F RID: 14863
		// (get) Token: 0x0602142C RID: 136236 RVA: 0x00944699 File Offset: 0x00942899
		// (set) Token: 0x0602142D RID: 136237 RVA: 0x009446A9 File Offset: 0x009428A9
		public unsafe bool debugWeapon_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A10 RID: 14864
		// (get) Token: 0x0602142E RID: 136238 RVA: 0x009446BA File Offset: 0x009428BA
		// (set) Token: 0x0602142F RID: 136239 RVA: 0x009446CA File Offset: 0x009428CA
		public unsafe bool debugDamage_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A11 RID: 14865
		// (get) Token: 0x06021430 RID: 136240 RVA: 0x009446DC File Offset: 0x009428DC
		// (set) Token: 0x06021431 RID: 136241 RVA: 0x00944715 File Offset: 0x00942915
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
					result = (this._SMComponents = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_50, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMComponents.CopyAssign(value);
			}
		}

		// Token: 0x17003A12 RID: 14866
		// (get) Token: 0x06021432 RID: 136242 RVA: 0x00944724 File Offset: 0x00942924
		// (set) Token: 0x06021433 RID: 136243 RVA: 0x0094475D File Offset: 0x0094295D
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
					result = (this._SMHealth = new TArray<float>(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_51, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMHealth.CopyAssign(value);
			}
		}

		// Token: 0x17003A13 RID: 14867
		// (get) Token: 0x06021434 RID: 136244 RVA: 0x0094476C File Offset: 0x0094296C
		// (set) Token: 0x06021435 RID: 136245 RVA: 0x009447A5 File Offset: 0x009429A5
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
					result = (this._ConsArr = new TArray<UPhysicsConstraintComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_52, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ConsArr.CopyAssign(value);
			}
		}

		// Token: 0x17003A14 RID: 14868
		// (get) Token: 0x06021436 RID: 136246 RVA: 0x009447B4 File Offset: 0x009429B4
		// (set) Token: 0x06021437 RID: 136247 RVA: 0x009447ED File Offset: 0x009429ED
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
					result = (this._ForceArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_53, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ForceArr.CopyAssign(value);
			}
		}

		// Token: 0x17003A15 RID: 14869
		// (get) Token: 0x06021438 RID: 136248 RVA: 0x009447FB File Offset: 0x009429FB
		// (set) Token: 0x06021439 RID: 136249 RVA: 0x0094480B File Offset: 0x00942A0B
		public unsafe bool NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A16 RID: 14870
		// (get) Token: 0x0602143A RID: 136250 RVA: 0x0094481C File Offset: 0x00942A1C
		// (set) Token: 0x0602143B RID: 136251 RVA: 0x00944830 File Offset: 0x00942A30
		public unsafe FVector LastHitPositon
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17003A17 RID: 14871
		// (get) Token: 0x0602143C RID: 136252 RVA: 0x00944848 File Offset: 0x00942A48
		// (set) Token: 0x0602143D RID: 136253 RVA: 0x00944881 File Offset: 0x00942A81
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
					result = (this._Wheels = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_56, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Wheels.CopyAssign(value);
			}
		}

		// Token: 0x17003A18 RID: 14872
		// (get) Token: 0x0602143E RID: 136254 RVA: 0x0094488F File Offset: 0x00942A8F
		// (set) Token: 0x0602143F RID: 136255 RVA: 0x009448A3 File Offset: 0x00942AA3
		public unsafe UNiagaraSystem NS_Bloom
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17003A19 RID: 14873
		// (get) Token: 0x06021440 RID: 136256 RVA: 0x009448B8 File Offset: 0x00942AB8
		// (set) Token: 0x06021441 RID: 136257 RVA: 0x009448CC File Offset: 0x00942ACC
		public unsafe UNiagaraSystem NS_Attack
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x17003A1A RID: 14874
		// (get) Token: 0x06021442 RID: 136258 RVA: 0x009448E1 File Offset: 0x00942AE1
		// (set) Token: 0x06021443 RID: 136259 RVA: 0x009448F1 File Offset: 0x00942AF1
		public unsafe bool EngineAlreadyBreak
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A1B RID: 14875
		// (get) Token: 0x06021444 RID: 136260 RVA: 0x00944902 File Offset: 0x00942B02
		// (set) Token: 0x06021445 RID: 136261 RVA: 0x00944912 File Offset: 0x00942B12
		public unsafe bool EngineBreakOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_60) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_60) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A1C RID: 14876
		// (get) Token: 0x06021446 RID: 136262 RVA: 0x00944923 File Offset: 0x00942B23
		// (set) Token: 0x06021447 RID: 136263 RVA: 0x00944933 File Offset: 0x00942B33
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_61) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_61) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A1D RID: 14877
		// (get) Token: 0x06021448 RID: 136264 RVA: 0x00944944 File Offset: 0x00942B44
		// (set) Token: 0x06021449 RID: 136265 RVA: 0x00944958 File Offset: 0x00942B58
		public unsafe UNiagaraSystem NS_CarFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17003A1E RID: 14878
		// (get) Token: 0x0602144A RID: 136266 RVA: 0x0094496D File Offset: 0x00942B6D
		// (set) Token: 0x0602144B RID: 136267 RVA: 0x00944981 File Offset: 0x00942B81
		public unsafe UNiagaraSystem NS_EngineFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VehicleDamage_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17003A1F RID: 14879
		// (get) Token: 0x0602144C RID: 136268 RVA: 0x00944996 File Offset: 0x00942B96
		// (set) Token: 0x0602144D RID: 136269 RVA: 0x009449A6 File Offset: 0x00942BA6
		public unsafe bool bDebug_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_64) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_64) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003A20 RID: 14880
		// (get) Token: 0x0602144E RID: 136270 RVA: 0x009449B7 File Offset: 0x00942BB7
		// (set) Token: 0x0602144F RID: 136271 RVA: 0x009449C7 File Offset: 0x00942BC7
		public unsafe float dtForNiagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17003A21 RID: 14881
		// (get) Token: 0x06021450 RID: 136272 RVA: 0x009449D8 File Offset: 0x00942BD8
		// (set) Token: 0x06021451 RID: 136273 RVA: 0x009449E8 File Offset: 0x00942BE8
		public unsafe int thisFrameWeaponID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17003A22 RID: 14882
		// (get) Token: 0x06021452 RID: 136274 RVA: 0x009449F9 File Offset: 0x00942BF9
		// (set) Token: 0x06021453 RID: 136275 RVA: 0x00944A09 File Offset: 0x00942C09
		public unsafe int lastFrameWeaponID_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VehicleDamage_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x06021454 RID: 136276 RVA: 0x00944A1C File Offset: 0x00942C1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreateDM(UStaticMeshComponent Component)
		{
			BP_VehicleDamage_C.__CreateDM_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__CreateDM_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_VehicleDamage_C.__CreateDM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__CreateDM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Component = ((Component != null) ? Component.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__CreateDM_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021455 RID: 136277 RVA: 0x00944A71 File Offset: 0x00942C71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021456 RID: 136278 RVA: 0x00944A85 File Offset: 0x00942C85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021457 RID: 136279 RVA: 0x00944A9C File Offset: 0x00942C9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_0E15804D4F41346343B2EB9AA4C207F8(int PlayingID)
		{
			BP_VehicleDamage_C.__Completed_0E15804D4F41346343B2EB9AA4C207F8_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__Completed_0E15804D4F41346343B2EB9AA4C207F8_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_C.__Completed_0E15804D4F41346343B2EB9AA4C207F8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__Completed_0E15804D4F41346343B2EB9AA4C207F8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__Completed_0E15804D4F41346343B2EB9AA4C207F8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021458 RID: 136280 RVA: 0x00944AE4 File Offset: 0x00942CE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_5D181A7E42F3A6959622B6BE0BBB184B(int PlayingID)
		{
			BP_VehicleDamage_C.__Completed_5D181A7E42F3A6959622B6BE0BBB184B_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__Completed_5D181A7E42F3A6959622B6BE0BBB184B_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_C.__Completed_5D181A7E42F3A6959622B6BE0BBB184B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__Completed_5D181A7E42F3A6959622B6BE0BBB184B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__Completed_5D181A7E42F3A6959622B6BE0BBB184B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021459 RID: 136281 RVA: 0x00944B2C File Offset: 0x00942D2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_0671AEF343B8C7120964849EB085DE4D(int PlayingID)
		{
			BP_VehicleDamage_C.__Completed_0671AEF343B8C7120964849EB085DE4D_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__Completed_0671AEF343B8C7120964849EB085DE4D_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_C.__Completed_0671AEF343B8C7120964849EB085DE4D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__Completed_0671AEF343B8C7120964849EB085DE4D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__Completed_0671AEF343B8C7120964849EB085DE4D_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602145A RID: 136282 RVA: 0x00944B72 File Offset: 0x00942D72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602145B RID: 136283 RVA: 0x00944B86 File Offset: 0x00942D86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602145C RID: 136284 RVA: 0x00944B9C File Offset: 0x00942D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VehicleDamage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602145D RID: 136285 RVA: 0x00944BE4 File Offset: 0x00942DE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VehicleDamage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VehicleDamage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602145E RID: 136286 RVA: 0x00944C2C File Offset: 0x00942E2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_VehicleDamage_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_VehicleDamage_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602145F RID: 136287 RVA: 0x00944C8F File Offset: 0x00942E8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x06021460 RID: 136288 RVA: 0x00944CA3 File Offset: 0x00942EA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__CustomEvent_NativeFunctionPtr, null);
		}

		// Token: 0x06021461 RID: 136289 RVA: 0x00944CB7 File Offset: 0x00942EB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021462 RID: 136290 RVA: 0x00944CCB File Offset: 0x00942ECB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__test_NativeFunctionPtr, null);
		}

		// Token: 0x06021463 RID: 136291 RVA: 0x00944CE0 File Offset: 0x00942EE0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnVehiclePartBroken_Event_0(int PartIndex, string PartName)
		{
			BP_VehicleDamage_C.__OnVehiclePartBroken_Event_0_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__OnVehiclePartBroken_Event_0_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_VehicleDamage_C.__OnVehiclePartBroken_Event_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PartIndex = PartIndex;
			FString.CopyFrom((void*)(&ptr->PartName), PartName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VehicleDamage_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_VehicleDamage_C.__OnVehiclePartBroken_Event_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06021464 RID: 136292 RVA: 0x00944D44 File Offset: 0x00942F44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VehicleDamage(int EntryPoint)
		{
			BP_VehicleDamage_C.__ExecuteUbergraph_BP_VehicleDamage_FunctionParams* ptr = stackalloc BP_VehicleDamage_C.__ExecuteUbergraph_BP_VehicleDamage_FunctionParams[(UIntPtr)3535] + 15L / (long)sizeof(BP_VehicleDamage_C.__ExecuteUbergraph_BP_VehicleDamage_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VehicleDamage_C.__ExecuteUbergraph_BP_VehicleDamage_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VehicleDamage_C.__ExecuteUbergraph_BP_VehicleDamage_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021465 RID: 136293 RVA: 0x00944D8E File Offset: 0x00942F8E
		protected BP_VehicleDamage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010B76 RID: 68470
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VehicleDamage/BP_VehicleDamage.BP_VehicleDamage_C";

		// Token: 0x04010B77 RID: 68471
		private static IntPtr _ClassPtr;

		// Token: 0x04010B78 RID: 68472
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010B79 RID: 68473
		internal static int __PropertyOffset_0;

		// Token: 0x04010B7A RID: 68474
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010B7B RID: 68475
		internal static int __PropertyOffset_1;

		// Token: 0x04010B7C RID: 68476
		internal static int __PropertyOffset_2;

		// Token: 0x04010B7D RID: 68477
		internal static int __PropertyOffset_3;

		// Token: 0x04010B7E RID: 68478
		internal static int __PropertyOffset_4;

		// Token: 0x04010B7F RID: 68479
		internal static int __PropertyOffset_5;

		// Token: 0x04010B80 RID: 68480
		internal static int __PropertyOffset_6;

		// Token: 0x04010B81 RID: 68481
		internal static int __PropertyOffset_7;

		// Token: 0x04010B82 RID: 68482
		internal static int __PropertyOffset_8;

		// Token: 0x04010B83 RID: 68483
		internal static int __PropertyOffset_9;

		// Token: 0x04010B84 RID: 68484
		internal static int __PropertyOffset_10;

		// Token: 0x04010B85 RID: 68485
		internal static int __PropertyOffset_11;

		// Token: 0x04010B86 RID: 68486
		internal static int __PropertyOffset_12;

		// Token: 0x04010B87 RID: 68487
		internal static int __PropertyOffset_13;

		// Token: 0x04010B88 RID: 68488
		internal static int __PropertyOffset_14;

		// Token: 0x04010B89 RID: 68489
		internal static int __PropertyOffset_15;

		// Token: 0x04010B8A RID: 68490
		internal static int __PropertyOffset_16;

		// Token: 0x04010B8B RID: 68491
		internal static int __PropertyOffset_17;

		// Token: 0x04010B8C RID: 68492
		internal static int __PropertyOffset_18;

		// Token: 0x04010B8D RID: 68493
		internal static int __PropertyOffset_19;

		// Token: 0x04010B8E RID: 68494
		internal static int __PropertyOffset_20;

		// Token: 0x04010B8F RID: 68495
		internal static int __PropertyOffset_21;

		// Token: 0x04010B90 RID: 68496
		internal static int __PropertyOffset_22;

		// Token: 0x04010B91 RID: 68497
		internal static int __PropertyOffset_23;

		// Token: 0x04010B92 RID: 68498
		internal static int __PropertyOffset_24;

		// Token: 0x04010B93 RID: 68499
		internal static int __PropertyOffset_25;

		// Token: 0x04010B94 RID: 68500
		internal static int __PropertyOffset_26;

		// Token: 0x04010B95 RID: 68501
		internal static int __PropertyOffset_27;

		// Token: 0x04010B96 RID: 68502
		internal static int __PropertyOffset_28;

		// Token: 0x04010B97 RID: 68503
		internal static int __PropertyOffset_29;

		// Token: 0x04010B98 RID: 68504
		internal static int __PropertyOffset_30;

		// Token: 0x04010B99 RID: 68505
		internal static int __PropertyOffset_31;

		// Token: 0x04010B9A RID: 68506
		internal static int __PropertyOffset_32;

		// Token: 0x04010B9B RID: 68507
		internal static int __PropertyOffset_33;

		// Token: 0x04010B9C RID: 68508
		internal static int __PropertyOffset_34;

		// Token: 0x04010B9D RID: 68509
		internal static int __PropertyOffset_35;

		// Token: 0x04010B9E RID: 68510
		internal static int __PropertyOffset_36;

		// Token: 0x04010B9F RID: 68511
		internal static int __PropertyOffset_37;

		// Token: 0x04010BA0 RID: 68512
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _CarAllMats;

		// Token: 0x04010BA1 RID: 68513
		internal static int __PropertyOffset_38;

		// Token: 0x04010BA2 RID: 68514
		internal static int __PropertyOffset_39;

		// Token: 0x04010BA3 RID: 68515
		internal static int __PropertyOffset_40;

		// Token: 0x04010BA4 RID: 68516
		internal static int __PropertyOffset_41;

		// Token: 0x04010BA5 RID: 68517
		internal static int __PropertyOffset_42;

		// Token: 0x04010BA6 RID: 68518
		internal static int __PropertyOffset_43;

		// Token: 0x04010BA7 RID: 68519
		internal static int __PropertyOffset_44;

		// Token: 0x04010BA8 RID: 68520
		internal static int __PropertyOffset_45;

		// Token: 0x04010BA9 RID: 68521
		internal static int __PropertyOffset_46;

		// Token: 0x04010BAA RID: 68522
		internal static int __PropertyOffset_47;

		// Token: 0x04010BAB RID: 68523
		internal static int __PropertyOffset_48;

		// Token: 0x04010BAC RID: 68524
		internal static int __PropertyOffset_49;

		// Token: 0x04010BAD RID: 68525
		internal static int __PropertyOffset_50;

		// Token: 0x04010BAE RID: 68526
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMComponents;

		// Token: 0x04010BAF RID: 68527
		internal static int __PropertyOffset_51;

		// Token: 0x04010BB0 RID: 68528
		private TArray<float> _SMHealth;

		// Token: 0x04010BB1 RID: 68529
		internal static int __PropertyOffset_52;

		// Token: 0x04010BB2 RID: 68530
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UPhysicsConstraintComponent> _ConsArr;

		// Token: 0x04010BB3 RID: 68531
		internal static int __PropertyOffset_53;

		// Token: 0x04010BB4 RID: 68532
		private TArray<FVector> _ForceArr;

		// Token: 0x04010BB5 RID: 68533
		internal static int __PropertyOffset_54;

		// Token: 0x04010BB6 RID: 68534
		internal static int __PropertyOffset_55;

		// Token: 0x04010BB7 RID: 68535
		internal static int __PropertyOffset_56;

		// Token: 0x04010BB8 RID: 68536
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _Wheels;

		// Token: 0x04010BB9 RID: 68537
		internal static int __PropertyOffset_57;

		// Token: 0x04010BBA RID: 68538
		internal static int __PropertyOffset_58;

		// Token: 0x04010BBB RID: 68539
		internal static int __PropertyOffset_59;

		// Token: 0x04010BBC RID: 68540
		internal static int __PropertyOffset_60;

		// Token: 0x04010BBD RID: 68541
		internal static int __PropertyOffset_61;

		// Token: 0x04010BBE RID: 68542
		internal static int __PropertyOffset_62;

		// Token: 0x04010BBF RID: 68543
		internal static int __PropertyOffset_63;

		// Token: 0x04010BC0 RID: 68544
		internal static int __PropertyOffset_64;

		// Token: 0x04010BC1 RID: 68545
		internal static int __PropertyOffset_65;

		// Token: 0x04010BC2 RID: 68546
		internal static int __PropertyOffset_66;

		// Token: 0x04010BC3 RID: 68547
		internal static int __PropertyOffset_67;

		// Token: 0x04010BC4 RID: 68548
		private static IntPtr __CreateDM_NativeFunctionPtr;

		// Token: 0x04010BC5 RID: 68549
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010BC6 RID: 68550
		private static IntPtr __Completed_0E15804D4F41346343B2EB9AA4C207F8_NativeFunctionPtr;

		// Token: 0x04010BC7 RID: 68551
		private static IntPtr __Completed_5D181A7E42F3A6959622B6BE0BBB184B_NativeFunctionPtr;

		// Token: 0x04010BC8 RID: 68552
		private static IntPtr __Completed_0671AEF343B8C7120964849EB085DE4D_NativeFunctionPtr;

		// Token: 0x04010BC9 RID: 68553
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010BCA RID: 68554
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010BCB RID: 68555
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04010BCC RID: 68556
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010BCD RID: 68557
		private static IntPtr __CustomEvent_NativeFunctionPtr;

		// Token: 0x04010BCE RID: 68558
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010BCF RID: 68559
		private static IntPtr __test_NativeFunctionPtr;

		// Token: 0x04010BD0 RID: 68560
		private static IntPtr __OnVehiclePartBroken_Event_0_NativeFunctionPtr;

		// Token: 0x04010BD1 RID: 68561
		private static IntPtr __ExecuteUbergraph_BP_VehicleDamage_NativeFunctionPtr;

		// Token: 0x02009AA5 RID: 39589
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __CreateDM_FunctionParams
		{
			// Token: 0x0403220A RID: 205322
			[FieldOffset(0)]
			public IntPtr Component;
		}

		// Token: 0x02009AA6 RID: 39590
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_0E15804D4F41346343B2EB9AA4C207F8_FunctionParams
		{
			// Token: 0x0403220B RID: 205323
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AA7 RID: 39591
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_5D181A7E42F3A6959622B6BE0BBB184B_FunctionParams
		{
			// Token: 0x0403220C RID: 205324
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AA8 RID: 39592
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_0671AEF343B8C7120964849EB085DE4D_FunctionParams
		{
			// Token: 0x0403220D RID: 205325
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009AA9 RID: 39593
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403220E RID: 205326
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AAA RID: 39594
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x0403220F RID: 205327
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032210 RID: 205328
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032211 RID: 205329
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009AAB RID: 39595
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnVehiclePartBroken_Event_0_FunctionParams
		{
			// Token: 0x04032212 RID: 205330
			[FieldOffset(0)]
			public int PartIndex;

			// Token: 0x04032213 RID: 205331
			[FieldOffset(8)]
			public FString PartName;
		}

		// Token: 0x02009AAC RID: 39596
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3520)]
		protected ref struct __ExecuteUbergraph_BP_VehicleDamage_FunctionParams
		{
			// Token: 0x04032214 RID: 205332
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
