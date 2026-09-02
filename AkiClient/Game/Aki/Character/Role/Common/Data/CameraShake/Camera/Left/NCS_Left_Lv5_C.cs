using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004053 RID: 16467
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv5.NCS_Left_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Left_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAB1 RID: 174769 RVA: 0x00A5FE18 File Offset: 0x00A5E018
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv5.NCS_Left_Lv5_C");
			}
			return NCS_Left_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AAB2 RID: 174770 RVA: 0x00A5FE3C File Offset: 0x00A5E03C
		public NCS_Left_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAB3 RID: 174771 RVA: 0x00A5FE64 File Offset: 0x00A5E064
		[NullableContext(1)]
		public NCS_Left_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAB4 RID: 174772 RVA: 0x00A5FE97 File Offset: 0x00A5E097
		protected NCS_Left_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401739A RID: 95130
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv5.NCS_Left_Lv5_C";

		// Token: 0x0401739B RID: 95131
		private static IntPtr _ClassPtr;

		// Token: 0x0401739C RID: 95132
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
