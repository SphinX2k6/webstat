using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonPet
{
	// Token: 0x02004193 RID: 16787
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonPet/BP_CommonPet.BP_CommonPet_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_CommonPet_C : BP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C7F4 RID: 182260 RVA: 0x00AA3A6C File Offset: 0x00AA1C6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CommonPet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonPet/BP_CommonPet.BP_CommonPet_C");
			}
			return BP_CommonPet_C._ClassPtr;
		}

		// Token: 0x0602C7F5 RID: 182261 RVA: 0x00AA3A90 File Offset: 0x00AA1C90
		public BP_CommonPet_C() : this(BuiltinUtils.AllocNativeUObject(BP_CommonPet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C7F6 RID: 182262 RVA: 0x00AA3AB8 File Offset: 0x00AA1CB8
		[NullableContext(1)]
		public BP_CommonPet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CommonPet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170077A4 RID: 30628
		// (get) Token: 0x0602C7F7 RID: 182263 RVA: 0x00AA3AEB File Offset: 0x00AA1CEB
		// (set) Token: 0x0602C7F8 RID: 182264 RVA: 0x00AA3AFF File Offset: 0x00AA1CFF
		[Nullable(2)]
		public unsafe UBoxComponent BlurCollision
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonPet_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CommonPet_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C7F9 RID: 182265 RVA: 0x00AA3B14 File Offset: 0x00AA1D14
		protected BP_CommonPet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B99 RID: 101273
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonPet/BP_CommonPet.BP_CommonPet_C";

		// Token: 0x04018B9A RID: 101274
		private static IntPtr _ClassPtr;

		// Token: 0x04018B9B RID: 101275
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B9C RID: 101276
		internal new static int __PropertyOffset_0;
	}
}
