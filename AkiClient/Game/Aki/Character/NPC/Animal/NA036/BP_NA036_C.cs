using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA036
{
	// Token: 0x02004158 RID: 16728
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA036/BP_NA036.BP_NA036_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA036_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C681 RID: 181889 RVA: 0x00AA05B8 File Offset: 0x00A9E7B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA036_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA036/BP_NA036.BP_NA036_C");
			}
			return BP_NA036_C._ClassPtr;
		}

		// Token: 0x0602C682 RID: 181890 RVA: 0x00AA05DC File Offset: 0x00A9E7DC
		public BP_NA036_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA036_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C683 RID: 181891 RVA: 0x00AA0604 File Offset: 0x00A9E804
		[NullableContext(1)]
		public BP_NA036_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA036_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C684 RID: 181892 RVA: 0x00AA0637 File Offset: 0x00A9E837
		protected BP_NA036_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A7E RID: 100990
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA036/BP_NA036.BP_NA036_C";

		// Token: 0x04018A7F RID: 100991
		private static IntPtr _ClassPtr;

		// Token: 0x04018A80 RID: 100992
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
