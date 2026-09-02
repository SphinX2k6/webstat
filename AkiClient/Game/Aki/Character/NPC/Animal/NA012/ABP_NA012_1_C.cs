using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x02004178 RID: 16760
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012_1.ABP_NA012_1_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA012_1_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C71E RID: 182046 RVA: 0x00AA1A20 File Offset: 0x00A9FC20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA012_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012_1.ABP_NA012_1_C");
			}
			return ABP_NA012_1_C._ClassPtr;
		}

		// Token: 0x0602C71F RID: 182047 RVA: 0x00AA1A44 File Offset: 0x00A9FC44
		public ABP_NA012_1_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA012_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C720 RID: 182048 RVA: 0x00AA1A6C File Offset: 0x00A9FC6C
		[NullableContext(1)]
		public ABP_NA012_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA012_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C721 RID: 182049 RVA: 0x00AA1A9F File Offset: 0x00A9FC9F
		protected ABP_NA012_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AF0 RID: 101104
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012_1.ABP_NA012_1_C";

		// Token: 0x04018AF1 RID: 101105
		private static IntPtr _ClassPtr;

		// Token: 0x04018AF2 RID: 101106
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
