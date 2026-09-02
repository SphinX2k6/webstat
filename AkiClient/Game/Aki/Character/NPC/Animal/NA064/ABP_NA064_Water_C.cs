using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA064
{
	// Token: 0x02004116 RID: 16662
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Water.ABP_NA064_Water_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA064_Water_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C509 RID: 181513 RVA: 0x00A9D37C File Offset: 0x00A9B57C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA064_Water_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Water.ABP_NA064_Water_C");
			}
			return ABP_NA064_Water_C._ClassPtr;
		}

		// Token: 0x0602C50A RID: 181514 RVA: 0x00A9D3A0 File Offset: 0x00A9B5A0
		public ABP_NA064_Water_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA064_Water_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C50B RID: 181515 RVA: 0x00A9D3C8 File Offset: 0x00A9B5C8
		[NullableContext(1)]
		public ABP_NA064_Water_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA064_Water_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C50C RID: 181516 RVA: 0x00A9D3FB File Offset: 0x00A9B5FB
		protected ABP_NA064_Water_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018967 RID: 100711
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Water.ABP_NA064_Water_C";

		// Token: 0x04018968 RID: 100712
		private static IntPtr _ClassPtr;

		// Token: 0x04018969 RID: 100713
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
