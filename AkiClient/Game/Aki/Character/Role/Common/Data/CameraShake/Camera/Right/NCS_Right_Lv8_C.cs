using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Right
{
	// Token: 0x02004034 RID: 16436
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv8.NCS_Right_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Right_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA35 RID: 174645 RVA: 0x00A5EDA0 File Offset: 0x00A5CFA0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Right_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv8.NCS_Right_Lv8_C");
			}
			return NCS_Right_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AA36 RID: 174646 RVA: 0x00A5EDC4 File Offset: 0x00A5CFC4
		public NCS_Right_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA37 RID: 174647 RVA: 0x00A5EDEC File Offset: 0x00A5CFEC
		[NullableContext(1)]
		public NCS_Right_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Right_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA38 RID: 174648 RVA: 0x00A5EE1F File Offset: 0x00A5D01F
		protected NCS_Right_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401733D RID: 95037
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Right/NCS_Right_Lv8.NCS_Right_Lv8_C";

		// Token: 0x0401733E RID: 95038
		private static IntPtr _ClassPtr;

		// Token: 0x0401733F RID: 95039
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
