using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004052 RID: 16466
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv4.NCS_Left_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Left_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAAD RID: 174765 RVA: 0x00A5FD90 File Offset: 0x00A5DF90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv4.NCS_Left_Lv4_C");
			}
			return NCS_Left_Lv4_C._ClassPtr;
		}

		// Token: 0x0602AAAE RID: 174766 RVA: 0x00A5FDB4 File Offset: 0x00A5DFB4
		public NCS_Left_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAAF RID: 174767 RVA: 0x00A5FDDC File Offset: 0x00A5DFDC
		[NullableContext(1)]
		public NCS_Left_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAB0 RID: 174768 RVA: 0x00A5FE0F File Offset: 0x00A5E00F
		protected NCS_Left_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017397 RID: 95127
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv4.NCS_Left_Lv4_C";

		// Token: 0x04017398 RID: 95128
		private static IntPtr _ClassPtr;

		// Token: 0x04017399 RID: 95129
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
