using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004018 RID: 16408
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Frozen.NCS_Frozen_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Frozen_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9C5 RID: 174533 RVA: 0x00A5DEC0 File Offset: 0x00A5C0C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Frozen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Frozen.NCS_Frozen_C");
			}
			return NCS_Frozen_C._ClassPtr;
		}

		// Token: 0x0602A9C6 RID: 174534 RVA: 0x00A5DEE4 File Offset: 0x00A5C0E4
		public NCS_Frozen_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Frozen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9C7 RID: 174535 RVA: 0x00A5DF0C File Offset: 0x00A5C10C
		[NullableContext(1)]
		public NCS_Frozen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Frozen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9C8 RID: 174536 RVA: 0x00A5DF3F File Offset: 0x00A5C13F
		protected NCS_Frozen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172E9 RID: 94953
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Frozen.NCS_Frozen_C";

		// Token: 0x040172EA RID: 94954
		private static IntPtr _ClassPtr;

		// Token: 0x040172EB RID: 94955
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
