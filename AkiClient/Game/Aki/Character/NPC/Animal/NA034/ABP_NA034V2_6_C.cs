using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA034
{
	// Token: 0x0200415C RID: 16732
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA034/ABP_NA034V2_6.ABP_NA034V2_6_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA034V2_6_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C699 RID: 181913 RVA: 0x00AA087C File Offset: 0x00A9EA7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA034V2_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA034/ABP_NA034V2_6.ABP_NA034V2_6_C");
			}
			return ABP_NA034V2_6_C._ClassPtr;
		}

		// Token: 0x0602C69A RID: 181914 RVA: 0x00AA08A0 File Offset: 0x00A9EAA0
		public ABP_NA034V2_6_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA034V2_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C69B RID: 181915 RVA: 0x00AA08C8 File Offset: 0x00A9EAC8
		[NullableContext(1)]
		public ABP_NA034V2_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA034V2_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C69C RID: 181916 RVA: 0x00AA08FB File Offset: 0x00A9EAFB
		protected ABP_NA034V2_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A8E RID: 101006
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA034/ABP_NA034V2_6.ABP_NA034V2_6_C";

		// Token: 0x04018A8F RID: 101007
		private static IntPtr _ClassPtr;

		// Token: 0x04018A90 RID: 101008
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
