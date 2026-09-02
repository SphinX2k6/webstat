using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.ClusteredStuff
{
	// Token: 0x02003D48 RID: 15688
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/PDA_FoliageClusteredEffectConfig.PDA_FoliageClusteredEffectConfig_C")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 108)]
	public class PDA_FoliageClusteredEffectConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602611F RID: 155935 RVA: 0x009CD238 File Offset: 0x009CB438
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_FoliageClusteredEffectConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/PDA_FoliageClusteredEffectConfig.PDA_FoliageClusteredEffectConfig_C");
			}
			return PDA_FoliageClusteredEffectConfig_C._ClassPtr;
		}

		// Token: 0x06026120 RID: 155936 RVA: 0x009CD25C File Offset: 0x009CB45C
		public PDA_FoliageClusteredEffectConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_FoliageClusteredEffectConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026121 RID: 155937 RVA: 0x009CD284 File Offset: 0x009CB484
		public PDA_FoliageClusteredEffectConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_FoliageClusteredEffectConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700554F RID: 21839
		// (get) Token: 0x06026122 RID: 155938 RVA: 0x009CD2B8 File Offset: 0x009CB4B8
		// (set) Token: 0x06026123 RID: 155939 RVA: 0x009CD2F1 File Offset: 0x009CB4F1
		public TArray<SFoliageClusteredEffectEntry> SettingsData
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFoliageClusteredEffectEntry> result;
				if ((result = this._SettingsData) == null)
				{
					result = (this._SettingsData = new TArray<SFoliageClusteredEffectEntry>(base.NativePtr + (IntPtr)PDA_FoliageClusteredEffectConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SettingsData.CopyAssign(value);
			}
		}

		// Token: 0x17005550 RID: 21840
		// (get) Token: 0x06026124 RID: 155940 RVA: 0x009CD2FF File Offset: 0x009CB4FF
		// (set) Token: 0x06026125 RID: 155941 RVA: 0x009CD313 File Offset: 0x009CB513
		public unsafe FVector BoxExtend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_FoliageClusteredEffectConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_FoliageClusteredEffectConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x06026126 RID: 155942 RVA: 0x009CD328 File Offset: 0x009CB528
		protected PDA_FoliageClusteredEffectConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B65 RID: 80741
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/PDA_FoliageClusteredEffectConfig.PDA_FoliageClusteredEffectConfig_C";

		// Token: 0x04013B66 RID: 80742
		private static IntPtr _ClassPtr;

		// Token: 0x04013B67 RID: 80743
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B68 RID: 80744
		internal static int __PropertyOffset_0;

		// Token: 0x04013B69 RID: 80745
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFoliageClusteredEffectEntry> _SettingsData;

		// Token: 0x04013B6A RID: 80746
		internal static int __PropertyOffset_1;
	}
}
