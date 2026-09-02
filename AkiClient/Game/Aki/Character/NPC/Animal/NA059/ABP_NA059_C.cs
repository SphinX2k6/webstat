using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA059
{
	// Token: 0x02004123 RID: 16675
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA059/ABP_NA059.ABP_NA059_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA059_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C568 RID: 181608 RVA: 0x00A9DFD4 File Offset: 0x00A9C1D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA059_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA059/ABP_NA059.ABP_NA059_C");
			}
			return ABP_NA059_C._ClassPtr;
		}

		// Token: 0x0602C569 RID: 181609 RVA: 0x00A9DFF8 File Offset: 0x00A9C1F8
		public ABP_NA059_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA059_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C56A RID: 181610 RVA: 0x00A9E020 File Offset: 0x00A9C220
		[NullableContext(1)]
		public ABP_NA059_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA059_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C56B RID: 181611 RVA: 0x00A9E053 File Offset: 0x00A9C253
		protected ABP_NA059_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189AB RID: 100779
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA059/ABP_NA059.ABP_NA059_C";

		// Token: 0x040189AC RID: 100780
		private static IntPtr _ClassPtr;

		// Token: 0x040189AD RID: 100781
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
