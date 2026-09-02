using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Swing
{
	// Token: 0x02003E6F RID: 15983
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Swing/BP_CharacterSwingConfig.BP_CharacterSwingConfig_C")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 208)]
	public class BP_CharacterSwingConfig_C : BP_BaseSwingConfig_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060277F6 RID: 161782 RVA: 0x009F32A0 File Offset: 0x009F14A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterSwingConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Swing/BP_CharacterSwingConfig.BP_CharacterSwingConfig_C");
			}
			return BP_CharacterSwingConfig_C._ClassPtr;
		}

		// Token: 0x060277F7 RID: 161783 RVA: 0x009F32C4 File Offset: 0x009F14C4
		public BP_CharacterSwingConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterSwingConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060277F8 RID: 161784 RVA: 0x009F32EC File Offset: 0x009F14EC
		public BP_CharacterSwingConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterSwingConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D1F RID: 23839
		// (get) Token: 0x060277F9 RID: 161785 RVA: 0x009F331F File Offset: 0x009F151F
		// (set) Token: 0x060277FA RID: 161786 RVA: 0x009F3334 File Offset: 0x009F1534
		public TSoftObjectPtr<UAnimMontage> SwingAnimation
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_CharacterSwingConfig_C.__PropertyOffset_0, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_CharacterSwingConfig_C.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060277FB RID: 161787 RVA: 0x009F3359 File Offset: 0x009F1559
		protected BP_CharacterSwingConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B09 RID: 84745
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Swing/BP_CharacterSwingConfig.BP_CharacterSwingConfig_C";

		// Token: 0x04014B0A RID: 84746
		private static IntPtr _ClassPtr;

		// Token: 0x04014B0B RID: 84747
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B0C RID: 84748
		internal new static int __PropertyOffset_0;
	}
}
