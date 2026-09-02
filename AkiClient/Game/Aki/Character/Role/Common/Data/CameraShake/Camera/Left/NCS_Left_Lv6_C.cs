using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004054 RID: 16468
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv6.NCS_Left_Lv6_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Left_Lv6_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAB5 RID: 174773 RVA: 0x00A5FEA0 File Offset: 0x00A5E0A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv6.NCS_Left_Lv6_C");
			}
			return NCS_Left_Lv6_C._ClassPtr;
		}

		// Token: 0x0602AAB6 RID: 174774 RVA: 0x00A5FEC4 File Offset: 0x00A5E0C4
		public NCS_Left_Lv6_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAB7 RID: 174775 RVA: 0x00A5FEEC File Offset: 0x00A5E0EC
		[NullableContext(1)]
		public NCS_Left_Lv6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAB8 RID: 174776 RVA: 0x00A5FF1F File Offset: 0x00A5E11F
		protected NCS_Left_Lv6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401739D RID: 95133
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv6.NCS_Left_Lv6_C";

		// Token: 0x0401739E RID: 95134
		private static IntPtr _ClassPtr;

		// Token: 0x0401739F RID: 95135
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
