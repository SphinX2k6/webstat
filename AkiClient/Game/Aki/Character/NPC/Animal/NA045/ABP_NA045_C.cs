using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA045
{
	// Token: 0x02004142 RID: 16706
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA045/ABP_NA045.ABP_NA045_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA045_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C614 RID: 181780 RVA: 0x00A9F624 File Offset: 0x00A9D824
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA045_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA045/ABP_NA045.ABP_NA045_C");
			}
			return ABP_NA045_C._ClassPtr;
		}

		// Token: 0x0602C615 RID: 181781 RVA: 0x00A9F648 File Offset: 0x00A9D848
		public ABP_NA045_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA045_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C616 RID: 181782 RVA: 0x00A9F670 File Offset: 0x00A9D870
		[NullableContext(1)]
		public ABP_NA045_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA045_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C617 RID: 181783 RVA: 0x00A9F6A3 File Offset: 0x00A9D8A3
		protected ABP_NA045_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A2A RID: 100906
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA045/ABP_NA045.ABP_NA045_C";

		// Token: 0x04018A2B RID: 100907
		private static IntPtr _ClassPtr;

		// Token: 0x04018A2C RID: 100908
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
