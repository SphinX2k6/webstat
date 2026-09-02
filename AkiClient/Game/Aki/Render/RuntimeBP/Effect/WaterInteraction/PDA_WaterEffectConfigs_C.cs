using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction
{
	// Token: 0x02003D21 RID: 15649
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/PDA_WaterEffectConfigs.PDA_WaterEffectConfigs_C")]
	[UnrealStructLayout(408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 408)]
	public class PDA_WaterEffectConfigs_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025D70 RID: 154992 RVA: 0x009C6A2C File Offset: 0x009C4C2C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_WaterEffectConfigs_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/PDA_WaterEffectConfigs.PDA_WaterEffectConfigs_C");
			}
			return PDA_WaterEffectConfigs_C._ClassPtr;
		}

		// Token: 0x06025D71 RID: 154993 RVA: 0x009C6A50 File Offset: 0x009C4C50
		public PDA_WaterEffectConfigs_C() : this(BuiltinUtils.AllocNativeUObject(PDA_WaterEffectConfigs_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025D72 RID: 154994 RVA: 0x009C6A78 File Offset: 0x009C4C78
		public PDA_WaterEffectConfigs_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_WaterEffectConfigs_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005401 RID: 21505
		// (get) Token: 0x06025D73 RID: 154995 RVA: 0x009C6AAB File Offset: 0x009C4CAB
		// (set) Token: 0x06025D74 RID: 154996 RVA: 0x009C6ABB File Offset: 0x009C4CBB
		public unsafe float TimeExistAfterDead
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005402 RID: 21506
		// (get) Token: 0x06025D75 RID: 154997 RVA: 0x009C6ACC File Offset: 0x009C4CCC
		// (set) Token: 0x06025D76 RID: 154998 RVA: 0x009C6ADC File Offset: 0x009C4CDC
		public unsafe float FallJumpPositionFix
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005403 RID: 21507
		// (get) Token: 0x06025D77 RID: 154999 RVA: 0x009C6AF0 File Offset: 0x009C4CF0
		// (set) Token: 0x06025D78 RID: 155000 RVA: 0x009C6B29 File Offset: 0x009C4D29
		public SWaterEffectSubConfig WaterEffectConfig
		{
			get
			{
				base.FastCheckIsValid();
				SWaterEffectSubConfig result;
				if ((result = this._WaterEffectConfig) == null)
				{
					result = (this._WaterEffectConfig = new SWaterEffectSubConfig(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWaterEffectSubConfig.StaticStruct(), base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005404 RID: 21508
		// (get) Token: 0x06025D79 RID: 155001 RVA: 0x009C6B4A File Offset: 0x009C4D4A
		// (set) Token: 0x06025D7A RID: 155002 RVA: 0x009C6B5F File Offset: 0x009C4D5F
		public TSoftObjectPtr<UEffectModelBase> SwimIdleEffectRef
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_3, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005405 RID: 21509
		// (get) Token: 0x06025D7B RID: 155003 RVA: 0x009C6B84 File Offset: 0x009C4D84
		// (set) Token: 0x06025D7C RID: 155004 RVA: 0x009C6B99 File Offset: 0x009C4D99
		public TSoftObjectPtr<UEffectModelBase> SwimNormalEffectRef
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_4, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005406 RID: 21510
		// (get) Token: 0x06025D7D RID: 155005 RVA: 0x009C6BBE File Offset: 0x009C4DBE
		// (set) Token: 0x06025D7E RID: 155006 RVA: 0x009C6BD3 File Offset: 0x009C4DD3
		public TSoftObjectPtr<UEffectModelBase> SwimFastEffectRef
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_5, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005407 RID: 21511
		// (get) Token: 0x06025D7F RID: 155007 RVA: 0x009C6BF8 File Offset: 0x009C4DF8
		// (set) Token: 0x06025D80 RID: 155008 RVA: 0x009C6C31 File Offset: 0x009C4E31
		public TMap<UPhysicalMaterial, SWaterEffectSubConfig> MaterialEffectConfig
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UPhysicalMaterial, SWaterEffectSubConfig> result;
				if ((result = this._MaterialEffectConfig) == null)
				{
					result = (this._MaterialEffectConfig = new TMap<UPhysicalMaterial, SWaterEffectSubConfig>(base.NativePtr + (IntPtr)PDA_WaterEffectConfigs_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.MaterialEffectConfig.CopyAssign(value);
			}
		}

		// Token: 0x06025D81 RID: 155009 RVA: 0x009C6C3F File Offset: 0x009C4E3F
		protected PDA_WaterEffectConfigs_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040138EB RID: 80107
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/PDA_WaterEffectConfigs.PDA_WaterEffectConfigs_C";

		// Token: 0x040138EC RID: 80108
		private static IntPtr _ClassPtr;

		// Token: 0x040138ED RID: 80109
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040138EE RID: 80110
		internal static int __PropertyOffset_0;

		// Token: 0x040138EF RID: 80111
		internal static int __PropertyOffset_1;

		// Token: 0x040138F0 RID: 80112
		internal static int __PropertyOffset_2;

		// Token: 0x040138F1 RID: 80113
		[Nullable(2)]
		private SWaterEffectSubConfig _WaterEffectConfig;

		// Token: 0x040138F2 RID: 80114
		internal static int __PropertyOffset_3;

		// Token: 0x040138F3 RID: 80115
		internal static int __PropertyOffset_4;

		// Token: 0x040138F4 RID: 80116
		internal static int __PropertyOffset_5;

		// Token: 0x040138F5 RID: 80117
		internal static int __PropertyOffset_6;

		// Token: 0x040138F6 RID: 80118
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<UPhysicalMaterial, SWaterEffectSubConfig> _MaterialEffectConfig;
	}
}
