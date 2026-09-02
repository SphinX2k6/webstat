using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x0200404F RID: 16463
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv1.NCS_Left_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Left_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAA1 RID: 174753 RVA: 0x00A5FBF8 File Offset: 0x00A5DDF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv1.NCS_Left_Lv1_C");
			}
			return NCS_Left_Lv1_C._ClassPtr;
		}

		// Token: 0x0602AAA2 RID: 174754 RVA: 0x00A5FC1C File Offset: 0x00A5DE1C
		public NCS_Left_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAA3 RID: 174755 RVA: 0x00A5FC44 File Offset: 0x00A5DE44
		[NullableContext(1)]
		public NCS_Left_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAA4 RID: 174756 RVA: 0x00A5FC77 File Offset: 0x00A5DE77
		protected NCS_Left_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401738E RID: 95118
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv1.NCS_Left_Lv1_C";

		// Token: 0x0401738F RID: 95119
		private static IntPtr _ClassPtr;

		// Token: 0x04017390 RID: 95120
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
