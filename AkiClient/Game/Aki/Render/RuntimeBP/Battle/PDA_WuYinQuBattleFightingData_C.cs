using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Battle
{
	// Token: 0x02003DA1 RID: 15777
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleFightingData.PDA_WuYinQuBattleFightingData_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 88)]
	public class PDA_WuYinQuBattleFightingData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060269E1 RID: 158177 RVA: 0x009DD5B5 File Offset: 0x009DB7B5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_WuYinQuBattleFightingData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleFightingData.PDA_WuYinQuBattleFightingData_C");
			}
			return PDA_WuYinQuBattleFightingData_C._ClassPtr;
		}

		// Token: 0x060269E2 RID: 158178 RVA: 0x009DD5DC File Offset: 0x009DB7DC
		public PDA_WuYinQuBattleFightingData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_WuYinQuBattleFightingData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060269E3 RID: 158179 RVA: 0x009DD604 File Offset: 0x009DB804
		[NullableContext(1)]
		public PDA_WuYinQuBattleFightingData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_WuYinQuBattleFightingData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700585D RID: 22621
		// (get) Token: 0x060269E4 RID: 158180 RVA: 0x009DD637 File Offset: 0x009DB837
		// (set) Token: 0x060269E5 RID: 158181 RVA: 0x009DD64B File Offset: 0x009DB84B
		[Nullable(2)]
		public unsafe UKuroWeatherDataAsset AtmosFightingData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleFightingData_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_WuYinQuBattleFightingData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060269E6 RID: 158182 RVA: 0x009DD660 File Offset: 0x009DB860
		protected PDA_WuYinQuBattleFightingData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401416D RID: 82285
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Battle/PDA_WuYinQuBattleFightingData.PDA_WuYinQuBattleFightingData_C";

		// Token: 0x0401416E RID: 82286
		private static IntPtr _ClassPtr;

		// Token: 0x0401416F RID: 82287
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014170 RID: 82288
		internal static int __PropertyOffset_0;
	}
}
