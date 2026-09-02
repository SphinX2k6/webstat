using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004172 RID: 16754
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015.ABP_NA015_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA015_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6FF RID: 182015 RVA: 0x00AA1594 File Offset: 0x00A9F794
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA015_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015.ABP_NA015_C");
			}
			return ABP_NA015_C._ClassPtr;
		}

		// Token: 0x0602C700 RID: 182016 RVA: 0x00AA15B8 File Offset: 0x00A9F7B8
		public ABP_NA015_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C701 RID: 182017 RVA: 0x00AA15E0 File Offset: 0x00A9F7E0
		[NullableContext(1)]
		public ABP_NA015_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C702 RID: 182018 RVA: 0x00AA1613 File Offset: 0x00A9F813
		protected ABP_NA015_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AD9 RID: 101081
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015.ABP_NA015_C";

		// Token: 0x04018ADA RID: 101082
		private static IntPtr _ClassPtr;

		// Token: 0x04018ADB RID: 101083
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
