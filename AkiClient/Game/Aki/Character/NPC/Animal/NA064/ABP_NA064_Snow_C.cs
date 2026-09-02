using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA064
{
	// Token: 0x02004115 RID: 16661
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Snow.ABP_NA064_Snow_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA064_Snow_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C505 RID: 181509 RVA: 0x00A9D2F4 File Offset: 0x00A9B4F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA064_Snow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Snow.ABP_NA064_Snow_C");
			}
			return ABP_NA064_Snow_C._ClassPtr;
		}

		// Token: 0x0602C506 RID: 181510 RVA: 0x00A9D318 File Offset: 0x00A9B518
		public ABP_NA064_Snow_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA064_Snow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C507 RID: 181511 RVA: 0x00A9D340 File Offset: 0x00A9B540
		[NullableContext(1)]
		public ABP_NA064_Snow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA064_Snow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C508 RID: 181512 RVA: 0x00A9D373 File Offset: 0x00A9B573
		protected ABP_NA064_Snow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018964 RID: 100708
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Snow.ABP_NA064_Snow_C";

		// Token: 0x04018965 RID: 100709
		private static IntPtr _ClassPtr;

		// Token: 0x04018966 RID: 100710
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
