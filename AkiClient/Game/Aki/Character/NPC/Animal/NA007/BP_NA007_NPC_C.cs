using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA007
{
	// Token: 0x02004184 RID: 16772
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA007/BP_NA007_NPC.BP_NA007_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA007_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C757 RID: 182103 RVA: 0x00AA2208 File Offset: 0x00AA0408
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA007_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA007/BP_NA007_NPC.BP_NA007_NPC_C");
			}
			return BP_NA007_NPC_C._ClassPtr;
		}

		// Token: 0x0602C758 RID: 182104 RVA: 0x00AA222C File Offset: 0x00AA042C
		public BP_NA007_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA007_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C759 RID: 182105 RVA: 0x00AA2254 File Offset: 0x00AA0454
		[NullableContext(1)]
		public BP_NA007_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA007_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C75A RID: 182106 RVA: 0x00AA2287 File Offset: 0x00AA0487
		protected BP_NA007_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B1A RID: 101146
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA007/BP_NA007_NPC.BP_NA007_NPC_C";

		// Token: 0x04018B1B RID: 101147
		private static IntPtr _ClassPtr;

		// Token: 0x04018B1C RID: 101148
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
