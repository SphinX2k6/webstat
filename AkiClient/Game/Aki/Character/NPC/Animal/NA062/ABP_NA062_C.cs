using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA062
{
	// Token: 0x02004119 RID: 16665
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA062/ABP_NA062.ABP_NA062_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA062_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C520 RID: 181536 RVA: 0x00A9D65C File Offset: 0x00A9B85C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA062_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA062/ABP_NA062.ABP_NA062_C");
			}
			return ABP_NA062_C._ClassPtr;
		}

		// Token: 0x0602C521 RID: 181537 RVA: 0x00A9D680 File Offset: 0x00A9B880
		public ABP_NA062_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA062_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C522 RID: 181538 RVA: 0x00A9D6A8 File Offset: 0x00A9B8A8
		[NullableContext(1)]
		public ABP_NA062_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA062_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C523 RID: 181539 RVA: 0x00A9D6DB File Offset: 0x00A9B8DB
		protected ABP_NA062_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018977 RID: 100727
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA062/ABP_NA062.ABP_NA062_C";

		// Token: 0x04018978 RID: 100728
		private static IntPtr _ClassPtr;

		// Token: 0x04018979 RID: 100729
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
