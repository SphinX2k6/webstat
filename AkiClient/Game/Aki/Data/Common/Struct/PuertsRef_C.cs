using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Common.Struct
{
	// Token: 0x02003F08 RID: 16136
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Common/Struct/PuertsRef.PuertsRef_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class PuertsRef_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028317 RID: 164631 RVA: 0x00A04E0B File Offset: 0x00A0300B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PuertsRef_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Common/Struct/PuertsRef.PuertsRef_C");
			}
			return PuertsRef_C._ClassPtr;
		}

		// Token: 0x06028318 RID: 164632 RVA: 0x00A04E30 File Offset: 0x00A03030
		public PuertsRef_C() : this(BuiltinUtils.AllocNativeUObject(PuertsRef_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028319 RID: 164633 RVA: 0x00A04E58 File Offset: 0x00A03058
		public PuertsRef_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PuertsRef_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170060FE RID: 24830
		// (get) Token: 0x0602831A RID: 164634 RVA: 0x00A04E8C File Offset: 0x00A0308C
		// (set) Token: 0x0602831B RID: 164635 RVA: 0x00A04EC5 File Offset: 0x00A030C5
		public SCharacterLocationsAndRadius NewVar_0
		{
			get
			{
				base.FastCheckIsValid();
				SCharacterLocationsAndRadius result;
				if ((result = this._NewVar_0) == null)
				{
					result = (this._NewVar_0 = new SCharacterLocationsAndRadius(base.NativePtr + (IntPtr)PuertsRef_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCharacterLocationsAndRadius.StaticStruct(), base.NativePtr + (IntPtr)PuertsRef_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602831C RID: 164636 RVA: 0x00A04EE6 File Offset: 0x00A030E6
		protected PuertsRef_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015214 RID: 86548
		public new const string __ObjectPath = "/Game/Aki/Data/Common/Struct/PuertsRef.PuertsRef_C";

		// Token: 0x04015215 RID: 86549
		private static IntPtr _ClassPtr;

		// Token: 0x04015216 RID: 86550
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015217 RID: 86551
		internal static int __PropertyOffset_0;

		// Token: 0x04015218 RID: 86552
		[Nullable(2)]
		private SCharacterLocationsAndRadius _NewVar_0;
	}
}
