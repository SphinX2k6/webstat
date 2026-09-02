using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA050
{
	// Token: 0x02004138 RID: 16696
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA050/ABP_NA050_NPC.ABP_NA050_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA050_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5EC RID: 181740 RVA: 0x00A9F0D4 File Offset: 0x00A9D2D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA050_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA050/ABP_NA050_NPC.ABP_NA050_NPC_C");
			}
			return ABP_NA050_NPC_C._ClassPtr;
		}

		// Token: 0x0602C5ED RID: 181741 RVA: 0x00A9F0F8 File Offset: 0x00A9D2F8
		public ABP_NA050_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA050_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5EE RID: 181742 RVA: 0x00A9F120 File Offset: 0x00A9D320
		[NullableContext(1)]
		public ABP_NA050_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA050_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5EF RID: 181743 RVA: 0x00A9F153 File Offset: 0x00A9D353
		protected ABP_NA050_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A0C RID: 100876
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA050/ABP_NA050_NPC.ABP_NA050_NPC_C";

		// Token: 0x04018A0D RID: 100877
		private static IntPtr _ClassPtr;

		// Token: 0x04018A0E RID: 100878
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
