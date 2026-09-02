using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA034
{
	// Token: 0x0200415E RID: 16734
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA034/BP_NA034.BP_NA034_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA034_C : BP_CommonBigAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6A1 RID: 181921 RVA: 0x00AA098C File Offset: 0x00A9EB8C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA034_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA034/BP_NA034.BP_NA034_C");
			}
			return BP_NA034_C._ClassPtr;
		}

		// Token: 0x0602C6A2 RID: 181922 RVA: 0x00AA09B0 File Offset: 0x00A9EBB0
		public BP_NA034_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA034_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6A3 RID: 181923 RVA: 0x00AA09D8 File Offset: 0x00A9EBD8
		[NullableContext(1)]
		public BP_NA034_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA034_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007770 RID: 30576
		// (get) Token: 0x0602C6A4 RID: 181924 RVA: 0x00AA0A0B File Offset: 0x00A9EC0B
		// (set) Token: 0x0602C6A5 RID: 181925 RVA: 0x00AA0A1F File Offset: 0x00A9EC1F
		[Nullable(2)]
		public unsafe UCapsuleComponent Bip001Head
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA034_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA034_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C6A6 RID: 181926 RVA: 0x00AA0A34 File Offset: 0x00A9EC34
		protected BP_NA034_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A94 RID: 101012
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA034/BP_NA034.BP_NA034_C";

		// Token: 0x04018A95 RID: 101013
		private static IntPtr _ClassPtr;

		// Token: 0x04018A96 RID: 101014
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018A97 RID: 101015
		internal new static int __PropertyOffset_0;
	}
}
