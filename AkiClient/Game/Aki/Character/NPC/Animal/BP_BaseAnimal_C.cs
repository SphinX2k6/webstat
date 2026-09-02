using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal
{
	// Token: 0x020040F3 RID: 16627
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/BP_BaseAnimal.BP_BaseAnimal_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_BaseAnimal_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C453 RID: 181331 RVA: 0x00A9BC4B File Offset: 0x00A99E4B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/BP_BaseAnimal.BP_BaseAnimal_C");
			}
			return BP_BaseAnimal_C._ClassPtr;
		}

		// Token: 0x0602C454 RID: 181332 RVA: 0x00A9BC70 File Offset: 0x00A99E70
		public BP_BaseAnimal_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C455 RID: 181333 RVA: 0x00A9BC98 File Offset: 0x00A99E98
		[NullableContext(1)]
		public BP_BaseAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007737 RID: 30519
		// (get) Token: 0x0602C456 RID: 181334 RVA: 0x00A9BCCB File Offset: 0x00A99ECB
		// (set) Token: 0x0602C457 RID: 181335 RVA: 0x00A9BCDF File Offset: 0x00A99EDF
		[Nullable(2)]
		public unsafe UCurveFloat TurnSpeedCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseAnimal_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseAnimal_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C458 RID: 181336 RVA: 0x00A9BCF4 File Offset: 0x00A99EF4
		protected BP_BaseAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188CB RID: 100555
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/BP_BaseAnimal.BP_BaseAnimal_C";

		// Token: 0x040188CC RID: 100556
		private static IntPtr _ClassPtr;

		// Token: 0x040188CD RID: 100557
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040188CE RID: 100558
		internal static int __PropertyOffset_0;
	}
}
