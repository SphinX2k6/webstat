using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004057 RID: 16471
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv9.NCS_Left_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Left_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAC1 RID: 174785 RVA: 0x00A60038 File Offset: 0x00A5E238
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv9.NCS_Left_Lv9_C");
			}
			return NCS_Left_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AAC2 RID: 174786 RVA: 0x00A6005C File Offset: 0x00A5E25C
		public NCS_Left_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAC3 RID: 174787 RVA: 0x00A60084 File Offset: 0x00A5E284
		[NullableContext(1)]
		public NCS_Left_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAC4 RID: 174788 RVA: 0x00A600B7 File Offset: 0x00A5E2B7
		protected NCS_Left_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173A6 RID: 95142
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv9.NCS_Left_Lv9_C";

		// Token: 0x040173A7 RID: 95143
		private static IntPtr _ClassPtr;

		// Token: 0x040173A8 RID: 95144
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
