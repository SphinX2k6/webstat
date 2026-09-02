using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C5 RID: 16837
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_BasePlatform.BP_BasePlatform_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_BasePlatform_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CC22 RID: 183330 RVA: 0x00AAE98A File Offset: 0x00AACB8A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BasePlatform_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_BasePlatform.BP_BasePlatform_C");
			}
			return BP_BasePlatform_C._ClassPtr;
		}

		// Token: 0x0602CC23 RID: 183331 RVA: 0x00AAE9B0 File Offset: 0x00AACBB0
		public BP_BasePlatform_C() : this(BuiltinUtils.AllocNativeUObject(BP_BasePlatform_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CC24 RID: 183332 RVA: 0x00AAE9D8 File Offset: 0x00AACBD8
		[NullableContext(1)]
		public BP_BasePlatform_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BasePlatform_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078E0 RID: 30944
		// (get) Token: 0x0602CC25 RID: 183333 RVA: 0x00AAEA0B File Offset: 0x00AACC0B
		// (set) Token: 0x0602CC26 RID: 183334 RVA: 0x00AAEA1F File Offset: 0x00AACC1F
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePlatform_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePlatform_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170078E1 RID: 30945
		// (get) Token: 0x0602CC27 RID: 183335 RVA: 0x00AAEA34 File Offset: 0x00AACC34
		// (set) Token: 0x0602CC28 RID: 183336 RVA: 0x00AAEA44 File Offset: 0x00AACC44
		public unsafe float LeaveSphereRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BasePlatform_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BasePlatform_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170078E2 RID: 30946
		// (get) Token: 0x0602CC29 RID: 183337 RVA: 0x00AAEA55 File Offset: 0x00AACC55
		// (set) Token: 0x0602CC2A RID: 183338 RVA: 0x00AAEA69 File Offset: 0x00AACC69
		public unsafe FVector LeaveSphereCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BasePlatform_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BasePlatform_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602CC2B RID: 183339 RVA: 0x00AAEA7E File Offset: 0x00AACC7E
		protected BP_BasePlatform_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F06 RID: 102150
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_BasePlatform.BP_BasePlatform_C";

		// Token: 0x04018F07 RID: 102151
		private static IntPtr _ClassPtr;

		// Token: 0x04018F08 RID: 102152
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F09 RID: 102153
		internal static int __PropertyOffset_0;

		// Token: 0x04018F0A RID: 102154
		internal static int __PropertyOffset_1;

		// Token: 0x04018F0B RID: 102155
		internal static int __PropertyOffset_2;
	}
}
