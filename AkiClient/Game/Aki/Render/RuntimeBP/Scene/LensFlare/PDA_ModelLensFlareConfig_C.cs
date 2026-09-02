using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.LensFlare
{
	// Token: 0x02003AB3 RID: 15027
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/LensFlare/PDA_ModelLensFlareConfig.PDA_ModelLensFlareConfig_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 128)]
	public class PDA_ModelLensFlareConfig_C : USunLensFlareConfig, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060200D4 RID: 131284 RVA: 0x00920E6C File Offset: 0x0091F06C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_ModelLensFlareConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/LensFlare/PDA_ModelLensFlareConfig.PDA_ModelLensFlareConfig_C");
			}
			return PDA_ModelLensFlareConfig_C._ClassPtr;
		}

		// Token: 0x060200D5 RID: 131285 RVA: 0x00920E90 File Offset: 0x0091F090
		public PDA_ModelLensFlareConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_ModelLensFlareConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060200D6 RID: 131286 RVA: 0x00920EB8 File Offset: 0x0091F0B8
		[NullableContext(1)]
		public PDA_ModelLensFlareConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_ModelLensFlareConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060200D7 RID: 131287 RVA: 0x00920EEB File Offset: 0x0091F0EB
		protected PDA_ModelLensFlareConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF72 RID: 65394
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/LensFlare/PDA_ModelLensFlareConfig.PDA_ModelLensFlareConfig_C";

		// Token: 0x0400FF73 RID: 65395
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF74 RID: 65396
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
