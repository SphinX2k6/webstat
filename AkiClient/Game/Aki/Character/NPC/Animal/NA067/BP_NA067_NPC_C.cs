using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA067
{
	// Token: 0x0200410B RID: 16651
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA067/BP_NA067_NPC.BP_NA067_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA067_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4C7 RID: 181447 RVA: 0x00A9CB10 File Offset: 0x00A9AD10
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA067_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA067/BP_NA067_NPC.BP_NA067_NPC_C");
			}
			return BP_NA067_NPC_C._ClassPtr;
		}

		// Token: 0x0602C4C8 RID: 181448 RVA: 0x00A9CB34 File Offset: 0x00A9AD34
		public BP_NA067_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA067_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4C9 RID: 181449 RVA: 0x00A9CB5C File Offset: 0x00A9AD5C
		[NullableContext(1)]
		public BP_NA067_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA067_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4CA RID: 181450 RVA: 0x00A9CB8F File Offset: 0x00A9AD8F
		protected BP_NA067_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018938 RID: 100664
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA067/BP_NA067_NPC.BP_NA067_NPC_C";

		// Token: 0x04018939 RID: 100665
		private static IntPtr _ClassPtr;

		// Token: 0x0401893A RID: 100666
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
