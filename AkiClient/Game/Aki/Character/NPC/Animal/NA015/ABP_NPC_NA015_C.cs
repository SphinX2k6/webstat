using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004174 RID: 16756
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/ABP_NPC_NA015.ABP_NPC_NA015_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NPC_NA015_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C707 RID: 182023 RVA: 0x00AA16A4 File Offset: 0x00A9F8A4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NPC_NA015_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/ABP_NPC_NA015.ABP_NPC_NA015_C");
			}
			return ABP_NPC_NA015_C._ClassPtr;
		}

		// Token: 0x0602C708 RID: 182024 RVA: 0x00AA16C8 File Offset: 0x00A9F8C8
		public ABP_NPC_NA015_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NPC_NA015_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C709 RID: 182025 RVA: 0x00AA16F0 File Offset: 0x00A9F8F0
		[NullableContext(1)]
		public ABP_NPC_NA015_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NPC_NA015_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C70A RID: 182026 RVA: 0x00AA1723 File Offset: 0x00A9F923
		protected ABP_NPC_NA015_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ADF RID: 101087
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/ABP_NPC_NA015.ABP_NPC_NA015_C";

		// Token: 0x04018AE0 RID: 101088
		private static IntPtr _ClassPtr;

		// Token: 0x04018AE1 RID: 101089
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
