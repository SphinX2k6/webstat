using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x0200404C RID: 16460
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv9test.NCS_Out_Lv9test_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Lv9test_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA95 RID: 174741 RVA: 0x00A5FA60 File Offset: 0x00A5DC60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv9test_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv9test.NCS_Out_Lv9test_C");
			}
			return NCS_Out_Lv9test_C._ClassPtr;
		}

		// Token: 0x0602AA96 RID: 174742 RVA: 0x00A5FA84 File Offset: 0x00A5DC84
		public NCS_Out_Lv9test_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv9test_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA97 RID: 174743 RVA: 0x00A5FAAC File Offset: 0x00A5DCAC
		[NullableContext(1)]
		public NCS_Out_Lv9test_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv9test_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA98 RID: 174744 RVA: 0x00A5FADF File Offset: 0x00A5DCDF
		protected NCS_Out_Lv9test_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017385 RID: 95109
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv9test.NCS_Out_Lv9test_C";

		// Token: 0x04017386 RID: 95110
		private static IntPtr _ClassPtr;

		// Token: 0x04017387 RID: 95111
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
