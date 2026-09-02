using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004173 RID: 16755
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_Swim.ABP_NA015_Swim_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA015_Swim_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C703 RID: 182019 RVA: 0x00AA161C File Offset: 0x00A9F81C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA015_Swim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_Swim.ABP_NA015_Swim_C");
			}
			return ABP_NA015_Swim_C._ClassPtr;
		}

		// Token: 0x0602C704 RID: 182020 RVA: 0x00AA1640 File Offset: 0x00A9F840
		public ABP_NA015_Swim_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_Swim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C705 RID: 182021 RVA: 0x00AA1668 File Offset: 0x00A9F868
		[NullableContext(1)]
		public ABP_NA015_Swim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA015_Swim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C706 RID: 182022 RVA: 0x00AA169B File Offset: 0x00A9F89B
		protected ABP_NA015_Swim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ADC RID: 101084
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/ABP_NA015_Swim.ABP_NA015_Swim_C";

		// Token: 0x04018ADD RID: 101085
		private static IntPtr _ClassPtr;

		// Token: 0x04018ADE RID: 101086
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
