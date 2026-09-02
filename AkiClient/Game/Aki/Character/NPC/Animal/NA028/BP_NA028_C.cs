using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA028
{
	// Token: 0x02004163 RID: 16739
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA028/BP_NA028.BP_NA028_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA028_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6B7 RID: 181943 RVA: 0x00AA0C60 File Offset: 0x00A9EE60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA028_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA028/BP_NA028.BP_NA028_C");
			}
			return BP_NA028_C._ClassPtr;
		}

		// Token: 0x0602C6B8 RID: 181944 RVA: 0x00AA0C84 File Offset: 0x00A9EE84
		public BP_NA028_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA028_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6B9 RID: 181945 RVA: 0x00AA0CAC File Offset: 0x00A9EEAC
		[NullableContext(1)]
		public BP_NA028_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA028_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6BA RID: 181946 RVA: 0x00AA0CDF File Offset: 0x00A9EEDF
		protected BP_NA028_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AA4 RID: 101028
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA028/BP_NA028.BP_NA028_C";

		// Token: 0x04018AA5 RID: 101029
		private static IntPtr _ClassPtr;

		// Token: 0x04018AA6 RID: 101030
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
