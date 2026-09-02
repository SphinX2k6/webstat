using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Battle
{
	// Token: 0x02003DA2 RID: 15778
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleIdleData.PDA_WuYinQuBattleIdleData_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class PDA_WuYinQuBattleIdleData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060269E7 RID: 158183 RVA: 0x009DD669 File Offset: 0x009DB869
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_WuYinQuBattleIdleData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleIdleData.PDA_WuYinQuBattleIdleData_C");
			}
			return PDA_WuYinQuBattleIdleData_C._ClassPtr;
		}

		// Token: 0x060269E8 RID: 158184 RVA: 0x009DD690 File Offset: 0x009DB890
		public PDA_WuYinQuBattleIdleData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_WuYinQuBattleIdleData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060269E9 RID: 158185 RVA: 0x009DD6B8 File Offset: 0x009DB8B8
		[NullableContext(1)]
		public PDA_WuYinQuBattleIdleData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_WuYinQuBattleIdleData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700585E RID: 22622
		// (get) Token: 0x060269EA RID: 158186 RVA: 0x009DD6EB File Offset: 0x009DB8EB
		// (set) Token: 0x060269EB RID: 158187 RVA: 0x009DD6FF File Offset: 0x009DB8FF
		public unsafe UKuroWeatherDataAsset AtmosInnerData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleIdleData_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleIdleData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700585F RID: 22623
		// (get) Token: 0x060269EC RID: 158188 RVA: 0x009DD714 File Offset: 0x009DB914
		// (set) Token: 0x060269ED RID: 158189 RVA: 0x009DD728 File Offset: 0x009DB928
		public unsafe UKuroWeatherDataAsset AtmosOuterData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleIdleData_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleIdleData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060269EE RID: 158190 RVA: 0x009DD73D File Offset: 0x009DB93D
		protected PDA_WuYinQuBattleIdleData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014171 RID: 82289
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleIdleData.PDA_WuYinQuBattleIdleData_C";

		// Token: 0x04014172 RID: 82290
		private static IntPtr _ClassPtr;

		// Token: 0x04014173 RID: 82291
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014174 RID: 82292
		internal static int __PropertyOffset_0;

		// Token: 0x04014175 RID: 82293
		internal static int __PropertyOffset_1;
	}
}
