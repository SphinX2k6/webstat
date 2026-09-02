using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Random
{
	// Token: 0x0200403C RID: 16444
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv5.NCS_Random_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Random_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA55 RID: 174677 RVA: 0x00A5F1E0 File Offset: 0x00A5D3E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Random_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv5.NCS_Random_Lv5_C");
			}
			return NCS_Random_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AA56 RID: 174678 RVA: 0x00A5F204 File Offset: 0x00A5D404
		public NCS_Random_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA57 RID: 174679 RVA: 0x00A5F22C File Offset: 0x00A5D42C
		[NullableContext(1)]
		public NCS_Random_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Random_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA58 RID: 174680 RVA: 0x00A5F25F File Offset: 0x00A5D45F
		protected NCS_Random_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017355 RID: 95061
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Random/NCS_Random_Lv5.NCS_Random_Lv5_C";

		// Token: 0x04017356 RID: 95062
		private static IntPtr _ClassPtr;

		// Token: 0x04017357 RID: 95063
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
