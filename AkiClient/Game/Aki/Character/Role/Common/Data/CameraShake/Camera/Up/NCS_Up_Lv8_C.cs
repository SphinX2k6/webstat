using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x0200402A RID: 16426
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv8.NCS_Up_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Up_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA0D RID: 174605 RVA: 0x00A5E850 File Offset: 0x00A5CA50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv8.NCS_Up_Lv8_C");
			}
			return NCS_Up_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AA0E RID: 174606 RVA: 0x00A5E874 File Offset: 0x00A5CA74
		public NCS_Up_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA0F RID: 174607 RVA: 0x00A5E89C File Offset: 0x00A5CA9C
		[NullableContext(1)]
		public NCS_Up_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA10 RID: 174608 RVA: 0x00A5E8CF File Offset: 0x00A5CACF
		protected NCS_Up_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401731F RID: 95007
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv8.NCS_Up_Lv8_C";

		// Token: 0x04017320 RID: 95008
		private static IntPtr _ClassPtr;

		// Token: 0x04017321 RID: 95009
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
