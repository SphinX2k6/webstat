using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA039
{
	// Token: 0x02004151 RID: 16721
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA039/ABP_na039.ABP_NA039_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA039_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C665 RID: 181861 RVA: 0x00AA0200 File Offset: 0x00A9E400
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA039_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA039/ABP_na039.ABP_NA039_C");
			}
			return ABP_NA039_C._ClassPtr;
		}

		// Token: 0x0602C666 RID: 181862 RVA: 0x00AA0224 File Offset: 0x00A9E424
		public ABP_NA039_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA039_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C667 RID: 181863 RVA: 0x00AA024C File Offset: 0x00A9E44C
		[NullableContext(1)]
		public ABP_NA039_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA039_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C668 RID: 181864 RVA: 0x00AA027F File Offset: 0x00A9E47F
		protected ABP_NA039_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A69 RID: 100969
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA039/ABP_na039.ABP_NA039_C";

		// Token: 0x04018A6A RID: 100970
		private static IntPtr _ClassPtr;

		// Token: 0x04018A6B RID: 100971
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
