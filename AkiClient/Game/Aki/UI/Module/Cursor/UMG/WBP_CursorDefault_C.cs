using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.Cursor.UMG
{
	// Token: 0x02003981 RID: 14721
	[UnrealObjectPath("/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorDefault.WBP_CursorDefault_C")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1168)]
	public class WBP_CursorDefault_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DA9D RID: 121501 RVA: 0x008DCA10 File Offset: 0x008DAC10
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_CursorDefault_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorDefault.WBP_CursorDefault_C");
			}
			return WBP_CursorDefault_C._ClassPtr;
		}

		// Token: 0x0601DA9E RID: 121502 RVA: 0x008DCA34 File Offset: 0x008DAC34
		public WBP_CursorDefault_C() : this(BuiltinUtils.AllocNativeUObject(WBP_CursorDefault_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DA9F RID: 121503 RVA: 0x008DCA5C File Offset: 0x008DAC5C
		[NullableContext(1)]
		public WBP_CursorDefault_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_CursorDefault_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002718 RID: 10008
		// (get) Token: 0x0601DAA0 RID: 121504 RVA: 0x008DCA8F File Offset: 0x008DAC8F
		// (set) Token: 0x0601DAA1 RID: 121505 RVA: 0x008DCAA3 File Offset: 0x008DACA3
		[Nullable(2)]
		public unsafe UImage Image_20
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_CursorDefault_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_CursorDefault_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601DAA2 RID: 121506 RVA: 0x008DCAB8 File Offset: 0x008DACB8
		protected WBP_CursorDefault_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E85F RID: 59487
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorDefault.WBP_CursorDefault_C";

		// Token: 0x0400E860 RID: 59488
		private static IntPtr _ClassPtr;

		// Token: 0x0400E861 RID: 59489
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E862 RID: 59490
		internal static int __PropertyOffset_0;
	}
}
