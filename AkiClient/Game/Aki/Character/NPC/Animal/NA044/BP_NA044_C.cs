using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA044
{
	// Token: 0x02004145 RID: 16709
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA044/BP_NA044.BP_NA044_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA044_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C620 RID: 181792 RVA: 0x00A9F7BC File Offset: 0x00A9D9BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA044_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA044/BP_NA044.BP_NA044_C");
			}
			return BP_NA044_C._ClassPtr;
		}

		// Token: 0x0602C621 RID: 181793 RVA: 0x00A9F7E0 File Offset: 0x00A9D9E0
		public BP_NA044_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA044_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C622 RID: 181794 RVA: 0x00A9F808 File Offset: 0x00A9DA08
		[NullableContext(1)]
		public BP_NA044_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA044_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C623 RID: 181795 RVA: 0x00A9F83B File Offset: 0x00A9DA3B
		protected BP_NA044_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A33 RID: 100915
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA044/BP_NA044.BP_NA044_C";

		// Token: 0x04018A34 RID: 100916
		private static IntPtr _ClassPtr;

		// Token: 0x04018A35 RID: 100917
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
