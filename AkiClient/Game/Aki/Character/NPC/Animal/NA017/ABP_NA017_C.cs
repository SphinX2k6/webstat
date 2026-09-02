using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA017
{
	// Token: 0x0200416E RID: 16750
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA017/ABP_NA017.ABP_NA017_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA017_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6EF RID: 181999 RVA: 0x00AA1374 File Offset: 0x00A9F574
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA017_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA017/ABP_NA017.ABP_NA017_C");
			}
			return ABP_NA017_C._ClassPtr;
		}

		// Token: 0x0602C6F0 RID: 182000 RVA: 0x00AA1398 File Offset: 0x00A9F598
		public ABP_NA017_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA017_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6F1 RID: 182001 RVA: 0x00AA13C0 File Offset: 0x00A9F5C0
		[NullableContext(1)]
		public ABP_NA017_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA017_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6F2 RID: 182002 RVA: 0x00AA13F3 File Offset: 0x00A9F5F3
		protected ABP_NA017_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ACD RID: 101069
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA017/ABP_NA017.ABP_NA017_C";

		// Token: 0x04018ACE RID: 101070
		private static IntPtr _ClassPtr;

		// Token: 0x04018ACF RID: 101071
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
