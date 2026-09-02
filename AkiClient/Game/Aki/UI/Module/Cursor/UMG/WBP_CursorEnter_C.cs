using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.Cursor.UMG
{
	// Token: 0x02003982 RID: 14722
	[UnrealObjectPath("/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorEnter.WBP_CursorEnter_C")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1168)]
	public class WBP_CursorEnter_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DAA3 RID: 121507 RVA: 0x008DCAC1 File Offset: 0x008DACC1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_CursorEnter_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorEnter.WBP_CursorEnter_C");
			}
			return WBP_CursorEnter_C._ClassPtr;
		}

		// Token: 0x0601DAA4 RID: 121508 RVA: 0x008DCAE8 File Offset: 0x008DACE8
		public WBP_CursorEnter_C() : this(BuiltinUtils.AllocNativeUObject(WBP_CursorEnter_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DAA5 RID: 121509 RVA: 0x008DCB10 File Offset: 0x008DAD10
		[NullableContext(1)]
		public WBP_CursorEnter_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_CursorEnter_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002719 RID: 10009
		// (get) Token: 0x0601DAA6 RID: 121510 RVA: 0x008DCB43 File Offset: 0x008DAD43
		// (set) Token: 0x0601DAA7 RID: 121511 RVA: 0x008DCB57 File Offset: 0x008DAD57
		[Nullable(2)]
		public unsafe UImage Image_35
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_CursorEnter_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_CursorEnter_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601DAA8 RID: 121512 RVA: 0x008DCB6C File Offset: 0x008DAD6C
		protected WBP_CursorEnter_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E863 RID: 59491
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorEnter.WBP_CursorEnter_C";

		// Token: 0x0400E864 RID: 59492
		private static IntPtr _ClassPtr;

		// Token: 0x0400E865 RID: 59493
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E866 RID: 59494
		internal static int __PropertyOffset_0;
	}
}
