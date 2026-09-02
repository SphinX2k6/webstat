using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA035
{
	// Token: 0x0200415B RID: 16731
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA035/BP_NA035.BP_NA035_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA035_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C695 RID: 181909 RVA: 0x00AA07F4 File Offset: 0x00A9E9F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA035_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA035/BP_NA035.BP_NA035_C");
			}
			return BP_NA035_C._ClassPtr;
		}

		// Token: 0x0602C696 RID: 181910 RVA: 0x00AA0818 File Offset: 0x00A9EA18
		public BP_NA035_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA035_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C697 RID: 181911 RVA: 0x00AA0840 File Offset: 0x00A9EA40
		[NullableContext(1)]
		public BP_NA035_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA035_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C698 RID: 181912 RVA: 0x00AA0873 File Offset: 0x00A9EA73
		protected BP_NA035_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A8B RID: 101003
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA035/BP_NA035.BP_NA035_C";

		// Token: 0x04018A8C RID: 101004
		private static IntPtr _ClassPtr;

		// Token: 0x04018A8D RID: 101005
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
