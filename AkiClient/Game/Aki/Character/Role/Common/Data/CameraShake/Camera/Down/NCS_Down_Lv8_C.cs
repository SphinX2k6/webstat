using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x0200406B RID: 16491
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv8.NCS_Down_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Down_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB11 RID: 174865 RVA: 0x00A60AD8 File Offset: 0x00A5ECD8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv8.NCS_Down_Lv8_C");
			}
			return NCS_Down_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AB12 RID: 174866 RVA: 0x00A60AFC File Offset: 0x00A5ECFC
		public NCS_Down_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB13 RID: 174867 RVA: 0x00A60B24 File Offset: 0x00A5ED24
		[NullableContext(1)]
		public NCS_Down_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB14 RID: 174868 RVA: 0x00A60B57 File Offset: 0x00A5ED57
		protected NCS_Down_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173E2 RID: 95202
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv8.NCS_Down_Lv8_C";

		// Token: 0x040173E3 RID: 95203
		private static IntPtr _ClassPtr;

		// Token: 0x040173E4 RID: 95204
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
