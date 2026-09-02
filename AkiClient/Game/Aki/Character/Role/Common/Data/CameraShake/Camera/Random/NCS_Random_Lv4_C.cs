using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x0200403B RID: 16443
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv4.NCS_Random_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Random_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA51 RID: 174673 RVA: 0x00A5F158 File Offset: 0x00A5D358
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv4.NCS_Random_Lv4_C");
			}
			return NCS_Random_Lv4_C._ClassPtr;
		}

		// Token: 0x0602AA52 RID: 174674 RVA: 0x00A5F17C File Offset: 0x00A5D37C
		public NCS_Random_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA53 RID: 174675 RVA: 0x00A5F1A4 File Offset: 0x00A5D3A4
		[NullableContext(1)]
		public NCS_Random_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA54 RID: 174676 RVA: 0x00A5F1D7 File Offset: 0x00A5D3D7
		protected NCS_Random_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017352 RID: 95058
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv4.NCS_Random_Lv4_C";

		// Token: 0x04017353 RID: 95059
		private static IntPtr _ClassPtr;

		// Token: 0x04017354 RID: 95060
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
