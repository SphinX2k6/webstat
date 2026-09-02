using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004041 RID: 16449
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Location.NCS_Out_Location_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Location_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA69 RID: 174697 RVA: 0x00A5F488 File Offset: 0x00A5D688
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Location_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Location.NCS_Out_Location_C");
			}
			return NCS_Out_Location_C._ClassPtr;
		}

		// Token: 0x0602AA6A RID: 174698 RVA: 0x00A5F4AC File Offset: 0x00A5D6AC
		public NCS_Out_Location_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Location_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA6B RID: 174699 RVA: 0x00A5F4D4 File Offset: 0x00A5D6D4
		[NullableContext(1)]
		public NCS_Out_Location_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Location_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA6C RID: 174700 RVA: 0x00A5F507 File Offset: 0x00A5D707
		protected NCS_Out_Location_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017364 RID: 95076
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Location.NCS_Out_Location_C";

		// Token: 0x04017365 RID: 95077
		private static IntPtr _ClassPtr;

		// Token: 0x04017366 RID: 95078
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
