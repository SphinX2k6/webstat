using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA062
{
	// Token: 0x0200411A RID: 16666
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA062/ABP_NA062_NPC.ABP_NA062_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA062_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C524 RID: 181540 RVA: 0x00A9D6E4 File Offset: 0x00A9B8E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA062_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA062/ABP_NA062_NPC.ABP_NA062_NPC_C");
			}
			return ABP_NA062_NPC_C._ClassPtr;
		}

		// Token: 0x0602C525 RID: 181541 RVA: 0x00A9D708 File Offset: 0x00A9B908
		public ABP_NA062_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA062_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C526 RID: 181542 RVA: 0x00A9D730 File Offset: 0x00A9B930
		[NullableContext(1)]
		public ABP_NA062_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA062_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C527 RID: 181543 RVA: 0x00A9D763 File Offset: 0x00A9B963
		protected ABP_NA062_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401897A RID: 100730
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA062/ABP_NA062_NPC.ABP_NA062_NPC_C";

		// Token: 0x0401897B RID: 100731
		private static IntPtr _ClassPtr;

		// Token: 0x0401897C RID: 100732
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
