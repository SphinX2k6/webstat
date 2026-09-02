using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA007
{
	// Token: 0x02004182 RID: 16770
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA007/ABP_NA007_NPC.ABP_NA007_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA007_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C74F RID: 182095 RVA: 0x00AA20F8 File Offset: 0x00AA02F8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA007_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA007/ABP_NA007_NPC.ABP_NA007_NPC_C");
			}
			return ABP_NA007_NPC_C._ClassPtr;
		}

		// Token: 0x0602C750 RID: 182096 RVA: 0x00AA211C File Offset: 0x00AA031C
		public ABP_NA007_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA007_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C751 RID: 182097 RVA: 0x00AA2144 File Offset: 0x00AA0344
		[NullableContext(1)]
		public ABP_NA007_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA007_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C752 RID: 182098 RVA: 0x00AA2177 File Offset: 0x00AA0377
		protected ABP_NA007_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B14 RID: 101140
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA007/ABP_NA007_NPC.ABP_NA007_NPC_C";

		// Token: 0x04018B15 RID: 101141
		private static IntPtr _ClassPtr;

		// Token: 0x04018B16 RID: 101142
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
