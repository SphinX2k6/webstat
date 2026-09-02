using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA061
{
	// Token: 0x0200411E RID: 16670
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA061/ABP_NA061.ABP_NA061_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA061_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C53D RID: 181565 RVA: 0x00A9DA24 File Offset: 0x00A9BC24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA061_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA061/ABP_NA061.ABP_NA061_C");
			}
			return ABP_NA061_C._ClassPtr;
		}

		// Token: 0x0602C53E RID: 181566 RVA: 0x00A9DA48 File Offset: 0x00A9BC48
		public ABP_NA061_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA061_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C53F RID: 181567 RVA: 0x00A9DA70 File Offset: 0x00A9BC70
		[NullableContext(1)]
		public ABP_NA061_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA061_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C540 RID: 181568 RVA: 0x00A9DAA3 File Offset: 0x00A9BCA3
		protected ABP_NA061_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401898C RID: 100748
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA061/ABP_NA061.ABP_NA061_C";

		// Token: 0x0401898D RID: 100749
		private static IntPtr _ClassPtr;

		// Token: 0x0401898E RID: 100750
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
