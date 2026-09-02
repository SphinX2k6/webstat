using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Camera
{
	// Token: 0x02004012 RID: 16402
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Camera/CS_Block_Perfect.CS_Block_Perfect_C")]
	[UnrealStructLayout(416, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 416)]
	public class CS_Block_Perfect_C : UMatineeCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9AD RID: 174509 RVA: 0x00A5DB90 File Offset: 0x00A5BD90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Block_Perfect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Camera/CS_Block_Perfect.CS_Block_Perfect_C");
			}
			return CS_Block_Perfect_C._ClassPtr;
		}

		// Token: 0x0602A9AE RID: 174510 RVA: 0x00A5DBB4 File Offset: 0x00A5BDB4
		public CS_Block_Perfect_C() : this(BuiltinUtils.AllocNativeUObject(CS_Block_Perfect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9AF RID: 174511 RVA: 0x00A5DBDC File Offset: 0x00A5BDDC
		[NullableContext(1)]
		public CS_Block_Perfect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Block_Perfect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9B0 RID: 174512 RVA: 0x00A5DC0F File Offset: 0x00A5BE0F
		protected CS_Block_Perfect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172D7 RID: 94935
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Camera/CS_Block_Perfect.CS_Block_Perfect_C";

		// Token: 0x040172D8 RID: 94936
		private static IntPtr _ClassPtr;

		// Token: 0x040172D9 RID: 94937
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
