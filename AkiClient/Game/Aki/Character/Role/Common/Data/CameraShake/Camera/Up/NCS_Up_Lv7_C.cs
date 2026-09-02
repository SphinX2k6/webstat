using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004029 RID: 16425
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv7.NCS_Up_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Up_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA09 RID: 174601 RVA: 0x00A5E7C8 File Offset: 0x00A5C9C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv7.NCS_Up_Lv7_C");
			}
			return NCS_Up_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AA0A RID: 174602 RVA: 0x00A5E7EC File Offset: 0x00A5C9EC
		public NCS_Up_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA0B RID: 174603 RVA: 0x00A5E814 File Offset: 0x00A5CA14
		[NullableContext(1)]
		public NCS_Up_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA0C RID: 174604 RVA: 0x00A5E847 File Offset: 0x00A5CA47
		protected NCS_Up_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401731C RID: 95004
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv7.NCS_Up_Lv7_C";

		// Token: 0x0401731D RID: 95005
		private static IntPtr _ClassPtr;

		// Token: 0x0401731E RID: 95006
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
