using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA048
{
	// Token: 0x0200413B RID: 16699
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA048/ABP_NPC_NA048.ABP_NPC_NA048_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NPC_NA048_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5F8 RID: 181752 RVA: 0x00A9F26C File Offset: 0x00A9D46C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NPC_NA048_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA048/ABP_NPC_NA048.ABP_NPC_NA048_C");
			}
			return ABP_NPC_NA048_C._ClassPtr;
		}

		// Token: 0x0602C5F9 RID: 181753 RVA: 0x00A9F290 File Offset: 0x00A9D490
		public ABP_NPC_NA048_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NPC_NA048_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5FA RID: 181754 RVA: 0x00A9F2B8 File Offset: 0x00A9D4B8
		[NullableContext(1)]
		public ABP_NPC_NA048_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NPC_NA048_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5FB RID: 181755 RVA: 0x00A9F2EB File Offset: 0x00A9D4EB
		protected ABP_NPC_NA048_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A15 RID: 100885
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA048/ABP_NPC_NA048.ABP_NPC_NA048_C";

		// Token: 0x04018A16 RID: 100886
		private static IntPtr _ClassPtr;

		// Token: 0x04018A17 RID: 100887
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
