using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA070
{
	// Token: 0x020040FD RID: 16637
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA070/ABP_NA070.ABP_NA070_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA070_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C475 RID: 181365 RVA: 0x00A9C0B8 File Offset: 0x00A9A2B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA070_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA070/ABP_NA070.ABP_NA070_C");
			}
			return ABP_NA070_C._ClassPtr;
		}

		// Token: 0x0602C476 RID: 181366 RVA: 0x00A9C0DC File Offset: 0x00A9A2DC
		public ABP_NA070_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA070_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C477 RID: 181367 RVA: 0x00A9C104 File Offset: 0x00A9A304
		[NullableContext(1)]
		public ABP_NA070_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA070_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C478 RID: 181368 RVA: 0x00A9C137 File Offset: 0x00A9A337
		protected ABP_NA070_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188FE RID: 100606
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA070/ABP_NA070.ABP_NA070_C";

		// Token: 0x040188FF RID: 100607
		private static IntPtr _ClassPtr;

		// Token: 0x04018900 RID: 100608
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
