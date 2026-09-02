using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA071
{
	// Token: 0x020040F9 RID: 16633
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA071/ABP_NA071.ABP_NA071_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA071_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C465 RID: 181349 RVA: 0x00A9BE98 File Offset: 0x00A9A098
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA071_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA071/ABP_NA071.ABP_NA071_C");
			}
			return ABP_NA071_C._ClassPtr;
		}

		// Token: 0x0602C466 RID: 181350 RVA: 0x00A9BEBC File Offset: 0x00A9A0BC
		public ABP_NA071_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA071_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C467 RID: 181351 RVA: 0x00A9BEE4 File Offset: 0x00A9A0E4
		[NullableContext(1)]
		public ABP_NA071_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA071_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C468 RID: 181352 RVA: 0x00A9BF17 File Offset: 0x00A9A117
		protected ABP_NA071_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188F2 RID: 100594
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA071/ABP_NA071.ABP_NA071_C";

		// Token: 0x040188F3 RID: 100595
		private static IntPtr _ClassPtr;

		// Token: 0x040188F4 RID: 100596
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
