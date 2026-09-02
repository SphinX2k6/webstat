using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x0200417A RID: 16762
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012.ABP_NA012_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA012_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C726 RID: 182054 RVA: 0x00AA1B30 File Offset: 0x00A9FD30
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA012_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012.ABP_NA012_C");
			}
			return ABP_NA012_C._ClassPtr;
		}

		// Token: 0x0602C727 RID: 182055 RVA: 0x00AA1B54 File Offset: 0x00A9FD54
		public ABP_NA012_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA012_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C728 RID: 182056 RVA: 0x00AA1B7C File Offset: 0x00A9FD7C
		[NullableContext(1)]
		public ABP_NA012_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA012_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C729 RID: 182057 RVA: 0x00AA1BAF File Offset: 0x00A9FDAF
		protected ABP_NA012_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AF6 RID: 101110
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012.ABP_NA012_C";

		// Token: 0x04018AF7 RID: 101111
		private static IntPtr _ClassPtr;

		// Token: 0x04018AF8 RID: 101112
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
