using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA061
{
	// Token: 0x0200411D RID: 16669
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA061/ABP_NA06102.ABP_NA06102_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA06102_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C539 RID: 181561 RVA: 0x00A9D999 File Offset: 0x00A9BB99
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA06102_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA061/ABP_NA06102.ABP_NA06102_C");
			}
			return ABP_NA06102_C._ClassPtr;
		}

		// Token: 0x0602C53A RID: 181562 RVA: 0x00A9D9C0 File Offset: 0x00A9BBC0
		public ABP_NA06102_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA06102_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C53B RID: 181563 RVA: 0x00A9D9E8 File Offset: 0x00A9BBE8
		[NullableContext(1)]
		public ABP_NA06102_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA06102_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C53C RID: 181564 RVA: 0x00A9DA1B File Offset: 0x00A9BC1B
		protected ABP_NA06102_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018989 RID: 100745
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA061/ABP_NA06102.ABP_NA06102_C";

		// Token: 0x0401898A RID: 100746
		private static IntPtr _ClassPtr;

		// Token: 0x0401898B RID: 100747
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
