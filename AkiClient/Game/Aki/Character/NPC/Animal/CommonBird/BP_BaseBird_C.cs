using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonBird
{
	// Token: 0x02004195 RID: 16789
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonBird/BP_BaseBird.BP_BaseBird_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_BaseBird_C : BP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C817 RID: 182295 RVA: 0x00AA40F4 File Offset: 0x00AA22F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseBird_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonBird/BP_BaseBird.BP_BaseBird_C");
			}
			return BP_BaseBird_C._ClassPtr;
		}

		// Token: 0x0602C818 RID: 182296 RVA: 0x00AA4118 File Offset: 0x00AA2318
		public BP_BaseBird_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseBird_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C819 RID: 182297 RVA: 0x00AA4140 File Offset: 0x00AA2340
		[NullableContext(1)]
		public BP_BaseBird_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseBird_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C81A RID: 182298 RVA: 0x00AA4173 File Offset: 0x00AA2373
		protected BP_BaseBird_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018BB9 RID: 101305
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonBird/BP_BaseBird.BP_BaseBird_C";

		// Token: 0x04018BBA RID: 101306
		private static IntPtr _ClassPtr;

		// Token: 0x04018BBB RID: 101307
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
