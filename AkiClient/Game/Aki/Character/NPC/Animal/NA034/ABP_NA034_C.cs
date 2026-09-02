using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA034
{
	// Token: 0x0200415D RID: 16733
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA034/ABP_NA034.ABP_NA034_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA034_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C69D RID: 181917 RVA: 0x00AA0904 File Offset: 0x00A9EB04
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA034_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA034/ABP_NA034.ABP_NA034_C");
			}
			return ABP_NA034_C._ClassPtr;
		}

		// Token: 0x0602C69E RID: 181918 RVA: 0x00AA0928 File Offset: 0x00A9EB28
		public ABP_NA034_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA034_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C69F RID: 181919 RVA: 0x00AA0950 File Offset: 0x00A9EB50
		[NullableContext(1)]
		public ABP_NA034_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA034_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6A0 RID: 181920 RVA: 0x00AA0983 File Offset: 0x00A9EB83
		protected ABP_NA034_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A91 RID: 101009
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA034/ABP_NA034.ABP_NA034_C";

		// Token: 0x04018A92 RID: 101010
		private static IntPtr _ClassPtr;

		// Token: 0x04018A93 RID: 101011
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
