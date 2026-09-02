using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle
{
	// Token: 0x02003F8F RID: 16271
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/BP_BaseVehicle.BP_BaseVehicle_C")]
	[UnrealStructLayout(2128, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2120)]
	public class BP_BaseVehicle_C : __TsBaseVehicle_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028B5A RID: 166746 RVA: 0x00A137B4 File Offset: 0x00A119B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseVehicle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/BP_BaseVehicle.BP_BaseVehicle_C");
			}
			return BP_BaseVehicle_C._ClassPtr;
		}

		// Token: 0x06028B5B RID: 166747 RVA: 0x00A137D8 File Offset: 0x00A119D8
		public BP_BaseVehicle_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseVehicle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028B5C RID: 166748 RVA: 0x00A13800 File Offset: 0x00A11A00
		[NullableContext(1)]
		public BP_BaseVehicle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseVehicle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028B5D RID: 166749 RVA: 0x00A13833 File Offset: 0x00A11A33
		protected BP_BaseVehicle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040157D2 RID: 88018
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/BP_BaseVehicle.BP_BaseVehicle_C";

		// Token: 0x040157D3 RID: 88019
		private static IntPtr _ClassPtr;

		// Token: 0x040157D4 RID: 88020
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
