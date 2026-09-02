using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.MultiEffect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE2 RID: 15842
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelMultiEffect.BP_EffectModelMultiEffect_C")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 133)]
	public class BP_EffectModelMultiEffect_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026DE5 RID: 159205 RVA: 0x009E3E89 File Offset: 0x009E2089
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelMultiEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelMultiEffect.BP_EffectModelMultiEffect_C");
			}
			return BP_EffectModelMultiEffect_C._ClassPtr;
		}

		// Token: 0x06026DE6 RID: 159206 RVA: 0x009E3EB0 File Offset: 0x009E20B0
		public BP_EffectModelMultiEffect_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelMultiEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026DE7 RID: 159207 RVA: 0x009E3ED8 File Offset: 0x009E20D8
		[NullableContext(1)]
		public BP_EffectModelMultiEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelMultiEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170059A7 RID: 22951
		// (get) Token: 0x06026DE8 RID: 159208 RVA: 0x009E3F0B File Offset: 0x009E210B
		// (set) Token: 0x06026DE9 RID: 159209 RVA: 0x009E3F1F File Offset: 0x009E211F
		[Nullable(2)]
		public unsafe UObject EffectData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelMultiEffect_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelMultiEffect_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170059A8 RID: 22952
		// (get) Token: 0x06026DEA RID: 159210 RVA: 0x009E3F34 File Offset: 0x009E2134
		// (set) Token: 0x06026DEB RID: 159211 RVA: 0x009E3F44 File Offset: 0x009E2144
		public unsafe int BaseNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170059A9 RID: 22953
		// (get) Token: 0x06026DEC RID: 159212 RVA: 0x009E3F55 File Offset: 0x009E2155
		// (set) Token: 0x06026DED RID: 159213 RVA: 0x009E3F65 File Offset: 0x009E2165
		public unsafe float SpinSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170059AA RID: 22954
		// (get) Token: 0x06026DEE RID: 159214 RVA: 0x009E3F76 File Offset: 0x009E2176
		// (set) Token: 0x06026DEF RID: 159215 RVA: 0x009E3F86 File Offset: 0x009E2186
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170059AB RID: 22955
		// (get) Token: 0x06026DF0 RID: 159216 RVA: 0x009E3F97 File Offset: 0x009E2197
		// (set) Token: 0x06026DF1 RID: 159217 RVA: 0x009E3FAB File Offset: 0x009E21AB
		public unsafe TEnumAsByte<AkiClient.Game.Aki.Render.RuntimeBP.Effect.MultiEffect.EMultiEffectType> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelMultiEffect_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x06026DF2 RID: 159218 RVA: 0x009E3FC0 File Offset: 0x009E21C0
		protected BP_EffectModelMultiEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014470 RID: 83056
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelMultiEffect.BP_EffectModelMultiEffect_C";

		// Token: 0x04014471 RID: 83057
		private static IntPtr _ClassPtr;

		// Token: 0x04014472 RID: 83058
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014473 RID: 83059
		internal new static int __PropertyOffset_0;

		// Token: 0x04014474 RID: 83060
		internal new static int __PropertyOffset_1;

		// Token: 0x04014475 RID: 83061
		internal new static int __PropertyOffset_2;

		// Token: 0x04014476 RID: 83062
		internal new static int __PropertyOffset_3;

		// Token: 0x04014477 RID: 83063
		internal new static int __PropertyOffset_4;
	}
}
