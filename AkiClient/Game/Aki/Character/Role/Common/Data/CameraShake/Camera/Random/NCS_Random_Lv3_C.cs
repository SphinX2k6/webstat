using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x0200403A RID: 16442
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv3.NCS_Random_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Random_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA4D RID: 174669 RVA: 0x00A5F0D0 File Offset: 0x00A5D2D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv3.NCS_Random_Lv3_C");
			}
			return NCS_Random_Lv3_C._ClassPtr;
		}

		// Token: 0x0602AA4E RID: 174670 RVA: 0x00A5F0F4 File Offset: 0x00A5D2F4
		public NCS_Random_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA4F RID: 174671 RVA: 0x00A5F11C File Offset: 0x00A5D31C
		[NullableContext(1)]
		public NCS_Random_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA50 RID: 174672 RVA: 0x00A5F14F File Offset: 0x00A5D34F
		protected NCS_Random_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401734F RID: 95055
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv3.NCS_Random_Lv3_C";

		// Token: 0x04017350 RID: 95056
		private static IntPtr _ClassPtr;

		// Token: 0x04017351 RID: 95057
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
