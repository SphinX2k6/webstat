using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA018
{
	// Token: 0x0200416A RID: 16746
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018_NPC.ABP_NA018_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA018_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6D7 RID: 181975 RVA: 0x00AA1070 File Offset: 0x00A9F270
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA018_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018_NPC.ABP_NA018_NPC_C");
			}
			return ABP_NA018_NPC_C._ClassPtr;
		}

		// Token: 0x0602C6D8 RID: 181976 RVA: 0x00AA1094 File Offset: 0x00A9F294
		public ABP_NA018_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA018_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6D9 RID: 181977 RVA: 0x00AA10BC File Offset: 0x00A9F2BC
		[NullableContext(1)]
		public ABP_NA018_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA018_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6DA RID: 181978 RVA: 0x00AA10EF File Offset: 0x00A9F2EF
		protected ABP_NA018_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ABB RID: 101051
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018_NPC.ABP_NA018_NPC_C";

		// Token: 0x04018ABC RID: 101052
		private static IntPtr _ClassPtr;

		// Token: 0x04018ABD RID: 101053
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
