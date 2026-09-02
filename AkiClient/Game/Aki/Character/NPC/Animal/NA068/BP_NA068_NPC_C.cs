using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA068
{
	// Token: 0x02004107 RID: 16647
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA068/BP_NA068_NPC.BP_NA068_NPC_C")]
	[UnrealStructLayout(2336, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2336)]
	public class BP_NA068_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4B3 RID: 181427 RVA: 0x00A9C89C File Offset: 0x00A9AA9C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA068_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA068/BP_NA068_NPC.BP_NA068_NPC_C");
			}
			return BP_NA068_NPC_C._ClassPtr;
		}

		// Token: 0x0602C4B4 RID: 181428 RVA: 0x00A9C8C0 File Offset: 0x00A9AAC0
		public BP_NA068_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA068_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4B5 RID: 181429 RVA: 0x00A9C8E8 File Offset: 0x00A9AAE8
		[NullableContext(1)]
		public BP_NA068_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA068_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007740 RID: 30528
		// (get) Token: 0x0602C4B6 RID: 181430 RVA: 0x00A9C91B File Offset: 0x00A9AB1B
		// (set) Token: 0x0602C4B7 RID: 181431 RVA: 0x00A9C92F File Offset: 0x00A9AB2F
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_NPC_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_NPC_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007741 RID: 30529
		// (get) Token: 0x0602C4B8 RID: 181432 RVA: 0x00A9C944 File Offset: 0x00A9AB44
		// (set) Token: 0x0602C4B9 RID: 181433 RVA: 0x00A9C958 File Offset: 0x00A9AB58
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_NPC_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_NPC_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C4BA RID: 181434 RVA: 0x00A9C96D File Offset: 0x00A9AB6D
		protected BP_NA068_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401892A RID: 100650
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA068/BP_NA068_NPC.BP_NA068_NPC_C";

		// Token: 0x0401892B RID: 100651
		private static IntPtr _ClassPtr;

		// Token: 0x0401892C RID: 100652
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401892D RID: 100653
		internal new static int __PropertyOffset_0;

		// Token: 0x0401892E RID: 100654
		internal new static int __PropertyOffset_1;
	}
}
