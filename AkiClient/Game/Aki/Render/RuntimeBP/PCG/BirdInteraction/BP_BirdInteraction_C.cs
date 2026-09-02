using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BirdInteraction
{
	// Token: 0x02003C3F RID: 15423
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BirdInteraction/BP_BirdInteraction.BP_BirdInteraction_C")]
	[UnrealStructLayout(1896, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1896)]
	public class BP_BirdInteraction_C : AKuroBirdInteraction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602374F RID: 145231 RVA: 0x00982C20 File Offset: 0x00980E20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BirdInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BirdInteraction/BP_BirdInteraction.BP_BirdInteraction_C");
			}
			return BP_BirdInteraction_C._ClassPtr;
		}

		// Token: 0x06023750 RID: 145232 RVA: 0x00982C44 File Offset: 0x00980E44
		public BP_BirdInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_BirdInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023751 RID: 145233 RVA: 0x00982C6C File Offset: 0x00980E6C
		[NullableContext(1)]
		public BP_BirdInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BirdInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06023752 RID: 145234 RVA: 0x00982C9F File Offset: 0x00980E9F
		protected BP_BirdInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040120D0 RID: 73936
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BirdInteraction/BP_BirdInteraction.BP_BirdInteraction_C";

		// Token: 0x040120D1 RID: 73937
		private static IntPtr _ClassPtr;

		// Token: 0x040120D2 RID: 73938
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
