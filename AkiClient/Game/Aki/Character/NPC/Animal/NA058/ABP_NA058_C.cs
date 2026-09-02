using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA058
{
	// Token: 0x02004128 RID: 16680
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA058/ABP_NA058.ABP_NA058_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA058_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C594 RID: 181652 RVA: 0x00A9E537 File Offset: 0x00A9C737
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA058_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA058/ABP_NA058.ABP_NA058_C");
			}
			return ABP_NA058_C._ClassPtr;
		}

		// Token: 0x0602C595 RID: 181653 RVA: 0x00A9E55C File Offset: 0x00A9C75C
		public ABP_NA058_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA058_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C596 RID: 181654 RVA: 0x00A9E584 File Offset: 0x00A9C784
		[NullableContext(1)]
		public ABP_NA058_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA058_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C597 RID: 181655 RVA: 0x00A9E5B7 File Offset: 0x00A9C7B7
		protected ABP_NA058_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189C9 RID: 100809
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA058/ABP_NA058.ABP_NA058_C";

		// Token: 0x040189CA RID: 100810
		private static IntPtr _ClassPtr;

		// Token: 0x040189CB RID: 100811
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
