using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004051 RID: 16465
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv3.NCS_Left_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Left_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAA9 RID: 174761 RVA: 0x00A5FD08 File Offset: 0x00A5DF08
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv3.NCS_Left_Lv3_C");
			}
			return NCS_Left_Lv3_C._ClassPtr;
		}

		// Token: 0x0602AAAA RID: 174762 RVA: 0x00A5FD2C File Offset: 0x00A5DF2C
		public NCS_Left_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAAB RID: 174763 RVA: 0x00A5FD54 File Offset: 0x00A5DF54
		[NullableContext(1)]
		public NCS_Left_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAAC RID: 174764 RVA: 0x00A5FD87 File Offset: 0x00A5DF87
		protected NCS_Left_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017394 RID: 95124
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv3.NCS_Left_Lv3_C";

		// Token: 0x04017395 RID: 95125
		private static IntPtr _ClassPtr;

		// Token: 0x04017396 RID: 95126
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
