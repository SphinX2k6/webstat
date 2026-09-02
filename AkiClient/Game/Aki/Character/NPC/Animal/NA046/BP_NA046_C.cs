using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA046
{
	// Token: 0x02004140 RID: 16704
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA046/BP_NA046.BP_NA046_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA046_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C60C RID: 181772 RVA: 0x00A9F514 File Offset: 0x00A9D714
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA046_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA046/BP_NA046.BP_NA046_C");
			}
			return BP_NA046_C._ClassPtr;
		}

		// Token: 0x0602C60D RID: 181773 RVA: 0x00A9F538 File Offset: 0x00A9D738
		public BP_NA046_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA046_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C60E RID: 181774 RVA: 0x00A9F560 File Offset: 0x00A9D760
		[NullableContext(1)]
		public BP_NA046_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA046_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C60F RID: 181775 RVA: 0x00A9F593 File Offset: 0x00A9D793
		protected BP_NA046_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A24 RID: 100900
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA046/BP_NA046.BP_NA046_C";

		// Token: 0x04018A25 RID: 100901
		private static IntPtr _ClassPtr;

		// Token: 0x04018A26 RID: 100902
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
