using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004024 RID: 16420
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv2.NCS_Up_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Up_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9F5 RID: 174581 RVA: 0x00A5E520 File Offset: 0x00A5C720
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv2.NCS_Up_Lv2_C");
			}
			return NCS_Up_Lv2_C._ClassPtr;
		}

		// Token: 0x0602A9F6 RID: 174582 RVA: 0x00A5E544 File Offset: 0x00A5C744
		public NCS_Up_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9F7 RID: 174583 RVA: 0x00A5E56C File Offset: 0x00A5C76C
		[NullableContext(1)]
		public NCS_Up_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9F8 RID: 174584 RVA: 0x00A5E59F File Offset: 0x00A5C79F
		protected NCS_Up_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401730D RID: 94989
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv2.NCS_Up_Lv2_C";

		// Token: 0x0401730E RID: 94990
		private static IntPtr _ClassPtr;

		// Token: 0x0401730F RID: 94991
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
