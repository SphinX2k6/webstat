using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006_1
{
	// Token: 0x02004185 RID: 16773
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006_1/ABP_NA006_1_NPC.ABP_NA006_1_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA006_1_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C75B RID: 182107 RVA: 0x00AA2290 File Offset: 0x00AA0490
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA006_1_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006_1/ABP_NA006_1_NPC.ABP_NA006_1_NPC_C");
			}
			return ABP_NA006_1_NPC_C._ClassPtr;
		}

		// Token: 0x0602C75C RID: 182108 RVA: 0x00AA22B4 File Offset: 0x00AA04B4
		public ABP_NA006_1_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA006_1_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C75D RID: 182109 RVA: 0x00AA22DC File Offset: 0x00AA04DC
		[NullableContext(1)]
		public ABP_NA006_1_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA006_1_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C75E RID: 182110 RVA: 0x00AA230F File Offset: 0x00AA050F
		protected ABP_NA006_1_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B1D RID: 101149
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006_1/ABP_NA006_1_NPC.ABP_NA006_1_NPC_C";

		// Token: 0x04018B1E RID: 101150
		private static IntPtr _ClassPtr;

		// Token: 0x04018B1F RID: 101151
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
