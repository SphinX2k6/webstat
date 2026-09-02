using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight.Manager
{
	// Token: 0x02003F7A RID: 16250
	[UnrealObjectPath("/Game/Aki/Core/Fight/Manager/BP_ActorManager.BP_ActorManager_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_ActorManager_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028A13 RID: 166419 RVA: 0x00A10C70 File Offset: 0x00A0EE70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ActorManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/Manager/BP_ActorManager.BP_ActorManager_C");
			}
			return BP_ActorManager_C._ClassPtr;
		}

		// Token: 0x06028A14 RID: 166420 RVA: 0x00A10C94 File Offset: 0x00A0EE94
		public BP_ActorManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_ActorManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028A15 RID: 166421 RVA: 0x00A10CBC File Offset: 0x00A0EEBC
		[NullableContext(1)]
		public BP_ActorManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ActorManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028A16 RID: 166422 RVA: 0x00A10CEF File Offset: 0x00A0EEEF
		protected BP_ActorManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040156D7 RID: 87767
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/Manager/BP_ActorManager.BP_ActorManager_C";

		// Token: 0x040156D8 RID: 87768
		private static IntPtr _ClassPtr;

		// Token: 0x040156D9 RID: 87769
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
