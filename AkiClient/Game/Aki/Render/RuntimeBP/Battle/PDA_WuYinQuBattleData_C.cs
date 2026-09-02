using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Battle
{
	// Token: 0x02003DA0 RID: 15776
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleData.PDA_WuYinQuBattleData_C")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 200)]
	public class PDA_WuYinQuBattleData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060269BB RID: 158139 RVA: 0x009DD29B File Offset: 0x009DB49B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_WuYinQuBattleData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleData.PDA_WuYinQuBattleData_C");
			}
			return PDA_WuYinQuBattleData_C._ClassPtr;
		}

		// Token: 0x060269BC RID: 158140 RVA: 0x009DD2C0 File Offset: 0x009DB4C0
		public PDA_WuYinQuBattleData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_WuYinQuBattleData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060269BD RID: 158141 RVA: 0x009DD2E8 File Offset: 0x009DB4E8
		[NullableContext(1)]
		public PDA_WuYinQuBattleData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_WuYinQuBattleData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700584C RID: 22604
		// (get) Token: 0x060269BE RID: 158142 RVA: 0x009DD31B File Offset: 0x009DB51B
		// (set) Token: 0x060269BF RID: 158143 RVA: 0x009DD32B File Offset: 0x009DB52B
		public unsafe float IdleToFightingTransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700584D RID: 22605
		// (get) Token: 0x060269C0 RID: 158144 RVA: 0x009DD33C File Offset: 0x009DB53C
		// (set) Token: 0x060269C1 RID: 158145 RVA: 0x009DD34C File Offset: 0x009DB54C
		public unsafe float FightingTransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700584E RID: 22606
		// (get) Token: 0x060269C2 RID: 158146 RVA: 0x009DD35D File Offset: 0x009DB55D
		// (set) Token: 0x060269C3 RID: 158147 RVA: 0x009DD36D File Offset: 0x009DB56D
		public unsafe float FightingToIdleTransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700584F RID: 22607
		// (get) Token: 0x060269C4 RID: 158148 RVA: 0x009DD37E File Offset: 0x009DB57E
		// (set) Token: 0x060269C5 RID: 158149 RVA: 0x009DD392 File Offset: 0x009DB592
		public unsafe UCurveFloat IdleToFightingCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005850 RID: 22608
		// (get) Token: 0x060269C6 RID: 158150 RVA: 0x009DD3A7 File Offset: 0x009DB5A7
		// (set) Token: 0x060269C7 RID: 158151 RVA: 0x009DD3BB File Offset: 0x009DB5BB
		public unsafe UCurveFloat FightingTransitionCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005851 RID: 22609
		// (get) Token: 0x060269C8 RID: 158152 RVA: 0x009DD3D0 File Offset: 0x009DB5D0
		// (set) Token: 0x060269C9 RID: 158153 RVA: 0x009DD3E4 File Offset: 0x009DB5E4
		public unsafe UCurveFloat FightingToIdleCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005852 RID: 22610
		// (get) Token: 0x060269CA RID: 158154 RVA: 0x009DD3F9 File Offset: 0x009DB5F9
		// (set) Token: 0x060269CB RID: 158155 RVA: 0x009DD40D File Offset: 0x009DB60D
		public unsafe PDA_WuYinQuBattleIdleData_C WuYinQuIdleData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_WuYinQuBattleIdleData_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005853 RID: 22611
		// (get) Token: 0x060269CC RID: 158156 RVA: 0x009DD422 File Offset: 0x009DB622
		// (set) Token: 0x060269CD RID: 158157 RVA: 0x009DD436 File Offset: 0x009DB636
		public unsafe PDA_WuYinQuBattleFightingData_C WuYinQuFightingData1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_WuYinQuBattleFightingData_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005854 RID: 22612
		// (get) Token: 0x060269CE RID: 158158 RVA: 0x009DD44B File Offset: 0x009DB64B
		// (set) Token: 0x060269CF RID: 158159 RVA: 0x009DD45F File Offset: 0x009DB65F
		public unsafe PDA_WuYinQuBattleFightingData_C WuYinQuFightingData2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_WuYinQuBattleFightingData_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005855 RID: 22613
		// (get) Token: 0x060269D0 RID: 158160 RVA: 0x009DD474 File Offset: 0x009DB674
		// (set) Token: 0x060269D1 RID: 158161 RVA: 0x009DD488 File Offset: 0x009DB688
		public unsafe PDA_WuYinQuBattleFightingData_C WuYinQuFightingData3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_WuYinQuBattleFightingData_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005856 RID: 22614
		// (get) Token: 0x060269D2 RID: 158162 RVA: 0x009DD49D File Offset: 0x009DB69D
		// (set) Token: 0x060269D3 RID: 158163 RVA: 0x009DD4B1 File Offset: 0x009DB6B1
		[Nullable(0)]
		public unsafe TEnumAsByte<EWuYinQuState> test
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_10);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005857 RID: 22615
		// (get) Token: 0x060269D4 RID: 158164 RVA: 0x009DD4C6 File Offset: 0x009DB6C6
		// (set) Token: 0x060269D5 RID: 158165 RVA: 0x009DD4DA File Offset: 0x009DB6DA
		public unsafe UMaterialParameterCollection GlobalMPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005858 RID: 22616
		// (get) Token: 0x060269D6 RID: 158166 RVA: 0x009DD4EF File Offset: 0x009DB6EF
		// (set) Token: 0x060269D7 RID: 158167 RVA: 0x009DD503 File Offset: 0x009DB703
		public unsafe UCurveFloat LandscapeShowingRadiusCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17005859 RID: 22617
		// (get) Token: 0x060269D8 RID: 158168 RVA: 0x009DD518 File Offset: 0x009DB718
		// (set) Token: 0x060269D9 RID: 158169 RVA: 0x009DD52C File Offset: 0x009DB72C
		public unsafe UCurveFloat LandscapeFadingRadiusCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700585A RID: 22618
		// (get) Token: 0x060269DA RID: 158170 RVA: 0x009DD541 File Offset: 0x009DB741
		// (set) Token: 0x060269DB RID: 158171 RVA: 0x009DD555 File Offset: 0x009DB755
		public unsafe PDA_InteractionGlobalConfigParameters_C GlobalInteractionParameterOverride
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_InteractionGlobalConfigParameters_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleData_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700585B RID: 22619
		// (get) Token: 0x060269DC RID: 158172 RVA: 0x009DD56A File Offset: 0x009DB76A
		// (set) Token: 0x060269DD RID: 158173 RVA: 0x009DD57A File Offset: 0x009DB77A
		public unsafe float TriggerOuterSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700585C RID: 22620
		// (get) Token: 0x060269DE RID: 158174 RVA: 0x009DD58B File Offset: 0x009DB78B
		// (set) Token: 0x060269DF RID: 158175 RVA: 0x009DD59B File Offset: 0x009DB79B
		public unsafe float TriggerInnerSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WuYinQuBattleData_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x060269E0 RID: 158176 RVA: 0x009DD5AC File Offset: 0x009DB7AC
		protected PDA_WuYinQuBattleData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014159 RID: 82265
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleData.PDA_WuYinQuBattleData_C";

		// Token: 0x0401415A RID: 82266
		private static IntPtr _ClassPtr;

		// Token: 0x0401415B RID: 82267
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401415C RID: 82268
		internal static int __PropertyOffset_0;

		// Token: 0x0401415D RID: 82269
		internal static int __PropertyOffset_1;

		// Token: 0x0401415E RID: 82270
		internal static int __PropertyOffset_2;

		// Token: 0x0401415F RID: 82271
		internal static int __PropertyOffset_3;

		// Token: 0x04014160 RID: 82272
		internal static int __PropertyOffset_4;

		// Token: 0x04014161 RID: 82273
		internal static int __PropertyOffset_5;

		// Token: 0x04014162 RID: 82274
		internal static int __PropertyOffset_6;

		// Token: 0x04014163 RID: 82275
		internal static int __PropertyOffset_7;

		// Token: 0x04014164 RID: 82276
		internal static int __PropertyOffset_8;

		// Token: 0x04014165 RID: 82277
		internal static int __PropertyOffset_9;

		// Token: 0x04014166 RID: 82278
		internal static int __PropertyOffset_10;

		// Token: 0x04014167 RID: 82279
		internal static int __PropertyOffset_11;

		// Token: 0x04014168 RID: 82280
		internal static int __PropertyOffset_12;

		// Token: 0x04014169 RID: 82281
		internal static int __PropertyOffset_13;

		// Token: 0x0401416A RID: 82282
		internal static int __PropertyOffset_14;

		// Token: 0x0401416B RID: 82283
		internal static int __PropertyOffset_15;

		// Token: 0x0401416C RID: 82284
		internal static int __PropertyOffset_16;
	}
}
