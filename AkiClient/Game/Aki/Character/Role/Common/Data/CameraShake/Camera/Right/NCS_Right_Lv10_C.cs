using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x0200402C RID: 16428
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv10.NCS_Right_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Right_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA15 RID: 174613 RVA: 0x00A5E960 File Offset: 0x00A5CB60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv10.NCS_Right_Lv10_C");
			}
			return NCS_Right_Lv10_C._ClassPtr;
		}

		// Token: 0x0602AA16 RID: 174614 RVA: 0x00A5E984 File Offset: 0x00A5CB84
		public NCS_Right_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA17 RID: 174615 RVA: 0x00A5E9AC File Offset: 0x00A5CBAC
		[NullableContext(1)]
		public NCS_Right_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA18 RID: 174616 RVA: 0x00A5E9DF File Offset: 0x00A5CBDF
		protected NCS_Right_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017325 RID: 95013
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv10.NCS_Right_Lv10_C";

		// Token: 0x04017326 RID: 95014
		private static IntPtr _ClassPtr;

		// Token: 0x04017327 RID: 95015
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
