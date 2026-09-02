using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004022 RID: 16418
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv10.NCS_Up_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Up_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9ED RID: 174573 RVA: 0x00A5E410 File Offset: 0x00A5C610
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv10.NCS_Up_Lv10_C");
			}
			return NCS_Up_Lv10_C._ClassPtr;
		}

		// Token: 0x0602A9EE RID: 174574 RVA: 0x00A5E434 File Offset: 0x00A5C634
		public NCS_Up_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9EF RID: 174575 RVA: 0x00A5E45C File Offset: 0x00A5C65C
		[NullableContext(1)]
		public NCS_Up_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9F0 RID: 174576 RVA: 0x00A5E48F File Offset: 0x00A5C68F
		protected NCS_Up_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017307 RID: 94983
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv10.NCS_Up_Lv10_C";

		// Token: 0x04017308 RID: 94984
		private static IntPtr _ClassPtr;

		// Token: 0x04017309 RID: 94985
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
