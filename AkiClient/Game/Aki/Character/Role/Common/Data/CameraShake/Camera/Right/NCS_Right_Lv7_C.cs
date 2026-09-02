using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x02004033 RID: 16435
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv7.NCS_Right_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Right_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA31 RID: 174641 RVA: 0x00A5ED18 File Offset: 0x00A5CF18
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv7.NCS_Right_Lv7_C");
			}
			return NCS_Right_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AA32 RID: 174642 RVA: 0x00A5ED3C File Offset: 0x00A5CF3C
		public NCS_Right_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA33 RID: 174643 RVA: 0x00A5ED64 File Offset: 0x00A5CF64
		[NullableContext(1)]
		public NCS_Right_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA34 RID: 174644 RVA: 0x00A5ED97 File Offset: 0x00A5CF97
		protected NCS_Right_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401733A RID: 95034
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv7.NCS_Right_Lv7_C";

		// Token: 0x0401733B RID: 95035
		private static IntPtr _ClassPtr;

		// Token: 0x0401733C RID: 95036
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
