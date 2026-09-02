using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x02004037 RID: 16439
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv10_Long.NCS_Random_Lv10_Long_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Random_Lv10_Long_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA41 RID: 174657 RVA: 0x00A5EF38 File Offset: 0x00A5D138
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv10_Long_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv10_Long.NCS_Random_Lv10_Long_C");
			}
			return NCS_Random_Lv10_Long_C._ClassPtr;
		}

		// Token: 0x0602AA42 RID: 174658 RVA: 0x00A5EF5C File Offset: 0x00A5D15C
		public NCS_Random_Lv10_Long_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv10_Long_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA43 RID: 174659 RVA: 0x00A5EF84 File Offset: 0x00A5D184
		[NullableContext(1)]
		public NCS_Random_Lv10_Long_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv10_Long_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA44 RID: 174660 RVA: 0x00A5EFB7 File Offset: 0x00A5D1B7
		protected NCS_Random_Lv10_Long_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017346 RID: 95046
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv10_Long.NCS_Random_Lv10_Long_C";

		// Token: 0x04017347 RID: 95047
		private static IntPtr _ClassPtr;

		// Token: 0x04017348 RID: 95048
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
