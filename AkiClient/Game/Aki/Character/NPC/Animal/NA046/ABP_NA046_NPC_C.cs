using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA046
{
	// Token: 0x0200413F RID: 16703
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA046/ABP_NA046_NPC.ABP_NA046_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA046_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C608 RID: 181768 RVA: 0x00A9F48C File Offset: 0x00A9D68C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA046_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA046/ABP_NA046_NPC.ABP_NA046_NPC_C");
			}
			return ABP_NA046_NPC_C._ClassPtr;
		}

		// Token: 0x0602C609 RID: 181769 RVA: 0x00A9F4B0 File Offset: 0x00A9D6B0
		public ABP_NA046_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA046_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C60A RID: 181770 RVA: 0x00A9F4D8 File Offset: 0x00A9D6D8
		[NullableContext(1)]
		public ABP_NA046_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA046_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C60B RID: 181771 RVA: 0x00A9F50B File Offset: 0x00A9D70B
		protected ABP_NA046_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A21 RID: 100897
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA046/ABP_NA046_NPC.ABP_NA046_NPC_C";

		// Token: 0x04018A22 RID: 100898
		private static IntPtr _ClassPtr;

		// Token: 0x04018A23 RID: 100899
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
