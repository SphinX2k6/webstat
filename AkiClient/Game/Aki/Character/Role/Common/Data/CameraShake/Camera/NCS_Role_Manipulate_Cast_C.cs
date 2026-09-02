using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x0200401A RID: 16410
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Cast.NCS_Role_Manipulate_Cast_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Role_Manipulate_Cast_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9CD RID: 174541 RVA: 0x00A5DFD0 File Offset: 0x00A5C1D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Role_Manipulate_Cast_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Cast.NCS_Role_Manipulate_Cast_C");
			}
			return NCS_Role_Manipulate_Cast_C._ClassPtr;
		}

		// Token: 0x0602A9CE RID: 174542 RVA: 0x00A5DFF4 File Offset: 0x00A5C1F4
		public NCS_Role_Manipulate_Cast_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Cast_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9CF RID: 174543 RVA: 0x00A5E01C File Offset: 0x00A5C21C
		[NullableContext(1)]
		public NCS_Role_Manipulate_Cast_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Role_Manipulate_Cast_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9D0 RID: 174544 RVA: 0x00A5E04F File Offset: 0x00A5C24F
		protected NCS_Role_Manipulate_Cast_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172EF RID: 94959
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Role_Manipulate_Cast.NCS_Role_Manipulate_Cast_C";

		// Token: 0x040172F0 RID: 94960
		private static IntPtr _ClassPtr;

		// Token: 0x040172F1 RID: 94961
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
