using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004068 RID: 16488
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv5.NCS_Down_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Down_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB05 RID: 174853 RVA: 0x00A60940 File Offset: 0x00A5EB40
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv5.NCS_Down_Lv5_C");
			}
			return NCS_Down_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AB06 RID: 174854 RVA: 0x00A60964 File Offset: 0x00A5EB64
		public NCS_Down_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB07 RID: 174855 RVA: 0x00A6098C File Offset: 0x00A5EB8C
		[NullableContext(1)]
		public NCS_Down_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB08 RID: 174856 RVA: 0x00A609BF File Offset: 0x00A5EBBF
		protected NCS_Down_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173D9 RID: 95193
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv5.NCS_Down_Lv5_C";

		// Token: 0x040173DA RID: 95194
		private static IntPtr _ClassPtr;

		// Token: 0x040173DB RID: 95195
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
