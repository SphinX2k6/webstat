using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA018
{
	// Token: 0x02004169 RID: 16745
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018.ABP_NA018_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA018_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6D3 RID: 181971 RVA: 0x00AA0FE8 File Offset: 0x00A9F1E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA018_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018.ABP_NA018_C");
			}
			return ABP_NA018_C._ClassPtr;
		}

		// Token: 0x0602C6D4 RID: 181972 RVA: 0x00AA100C File Offset: 0x00A9F20C
		public ABP_NA018_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA018_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6D5 RID: 181973 RVA: 0x00AA1034 File Offset: 0x00A9F234
		[NullableContext(1)]
		public ABP_NA018_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA018_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6D6 RID: 181974 RVA: 0x00AA1067 File Offset: 0x00A9F267
		protected ABP_NA018_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AB8 RID: 101048
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018.ABP_NA018_C";

		// Token: 0x04018AB9 RID: 101049
		private static IntPtr _ClassPtr;

		// Token: 0x04018ABA RID: 101050
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
