using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004069 RID: 16489
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv6.NCS_Down_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Down_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB09 RID: 174857 RVA: 0x00A609C8 File Offset: 0x00A5EBC8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv6.NCS_Down_Lv6_C");
			}
			return NCS_Down_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AB0A RID: 174858 RVA: 0x00A609EC File Offset: 0x00A5EBEC
		public NCS_Down_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB0B RID: 174859 RVA: 0x00A60A14 File Offset: 0x00A5EC14
		[NullableContext(1)]
		public NCS_Down_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB0C RID: 174860 RVA: 0x00A60A47 File Offset: 0x00A5EC47
		protected NCS_Down_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173DC RID: 95196
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv6.NCS_Down_Lv6_C";

		// Token: 0x040173DD RID: 95197
		private static IntPtr _ClassPtr;

		// Token: 0x040173DE RID: 95198
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
