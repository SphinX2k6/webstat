using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA054
{
	// Token: 0x02004132 RID: 16690
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA054/ABP_NA054.ABP_NA054_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA054_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5D4 RID: 181716 RVA: 0x00A9EDA4 File Offset: 0x00A9CFA4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA054_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA054/ABP_NA054.ABP_NA054_C");
			}
			return ABP_NA054_C._ClassPtr;
		}

		// Token: 0x0602C5D5 RID: 181717 RVA: 0x00A9EDC8 File Offset: 0x00A9CFC8
		public ABP_NA054_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA054_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5D6 RID: 181718 RVA: 0x00A9EDF0 File Offset: 0x00A9CFF0
		[NullableContext(1)]
		public ABP_NA054_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA054_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5D7 RID: 181719 RVA: 0x00A9EE23 File Offset: 0x00A9D023
		protected ABP_NA054_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189FA RID: 100858
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA054/ABP_NA054.ABP_NA054_C";

		// Token: 0x040189FB RID: 100859
		private static IntPtr _ClassPtr;

		// Token: 0x040189FC RID: 100860
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
