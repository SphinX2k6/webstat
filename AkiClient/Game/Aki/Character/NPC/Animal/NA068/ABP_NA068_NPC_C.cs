using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA068
{
	// Token: 0x02004105 RID: 16645
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA068/ABP_NA068_NPC.ABP_NA068_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA068_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4A0 RID: 181408 RVA: 0x00A9C644 File Offset: 0x00A9A844
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA068_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA068/ABP_NA068_NPC.ABP_NA068_NPC_C");
			}
			return ABP_NA068_NPC_C._ClassPtr;
		}

		// Token: 0x0602C4A1 RID: 181409 RVA: 0x00A9C668 File Offset: 0x00A9A868
		public ABP_NA068_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA068_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4A2 RID: 181410 RVA: 0x00A9C690 File Offset: 0x00A9A890
		[NullableContext(1)]
		public ABP_NA068_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA068_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4A3 RID: 181411 RVA: 0x00A9C6C3 File Offset: 0x00A9A8C3
		protected ABP_NA068_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401891D RID: 100637
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA068/ABP_NA068_NPC.ABP_NA068_NPC_C";

		// Token: 0x0401891E RID: 100638
		private static IntPtr _ClassPtr;

		// Token: 0x0401891F RID: 100639
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
