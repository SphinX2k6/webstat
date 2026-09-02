using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x02004039 RID: 16441
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv2.NCS_Random_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Random_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA49 RID: 174665 RVA: 0x00A5F048 File Offset: 0x00A5D248
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv2.NCS_Random_Lv2_C");
			}
			return NCS_Random_Lv2_C._ClassPtr;
		}

		// Token: 0x0602AA4A RID: 174666 RVA: 0x00A5F06C File Offset: 0x00A5D26C
		public NCS_Random_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA4B RID: 174667 RVA: 0x00A5F094 File Offset: 0x00A5D294
		[NullableContext(1)]
		public NCS_Random_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA4C RID: 174668 RVA: 0x00A5F0C7 File Offset: 0x00A5D2C7
		protected NCS_Random_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401734C RID: 95052
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv2.NCS_Random_Lv2_C";

		// Token: 0x0401734D RID: 95053
		private static IntPtr _ClassPtr;

		// Token: 0x0401734E RID: 95054
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
