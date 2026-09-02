using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x0200402B RID: 16427
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv9.NCS_Up_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Up_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA11 RID: 174609 RVA: 0x00A5E8D8 File Offset: 0x00A5CAD8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv9.NCS_Up_Lv9_C");
			}
			return NCS_Up_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AA12 RID: 174610 RVA: 0x00A5E8FC File Offset: 0x00A5CAFC
		public NCS_Up_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA13 RID: 174611 RVA: 0x00A5E924 File Offset: 0x00A5CB24
		[NullableContext(1)]
		public NCS_Up_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA14 RID: 174612 RVA: 0x00A5E957 File Offset: 0x00A5CB57
		protected NCS_Up_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017322 RID: 95010
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv9.NCS_Up_Lv9_C";

		// Token: 0x04017323 RID: 95011
		private static IntPtr _ClassPtr;

		// Token: 0x04017324 RID: 95012
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
