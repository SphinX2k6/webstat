using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Camera
{
	// Token: 0x02004011 RID: 16401
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Camera/CS_Block_Nomal.CS_Block_Nomal_C")]
	[UnrealStructLayout(416, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 416)]
	public class CS_Block_Nomal_C : UMatineeCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9A9 RID: 174505 RVA: 0x00A5DB05 File Offset: 0x00A5BD05
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CS_Block_Nomal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Camera/CS_Block_Nomal.CS_Block_Nomal_C");
			}
			return CS_Block_Nomal_C._ClassPtr;
		}

		// Token: 0x0602A9AA RID: 174506 RVA: 0x00A5DB2C File Offset: 0x00A5BD2C
		public CS_Block_Nomal_C() : this(BuiltinUtils.AllocNativeUObject(CS_Block_Nomal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9AB RID: 174507 RVA: 0x00A5DB54 File Offset: 0x00A5BD54
		[NullableContext(1)]
		public CS_Block_Nomal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CS_Block_Nomal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9AC RID: 174508 RVA: 0x00A5DB87 File Offset: 0x00A5BD87
		protected CS_Block_Nomal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172D4 RID: 94932
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Camera/CS_Block_Nomal.CS_Block_Nomal_C";

		// Token: 0x040172D5 RID: 94933
		private static IntPtr _ClassPtr;

		// Token: 0x040172D6 RID: 94934
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
