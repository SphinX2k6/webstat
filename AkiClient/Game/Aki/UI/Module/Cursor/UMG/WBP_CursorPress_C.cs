using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.Cursor.UMG
{
	// Token: 0x02003983 RID: 14723
	[UnrealObjectPath("/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorPress.WBP_CursorPress_C")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1168)]
	public class WBP_CursorPress_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DAA9 RID: 121513 RVA: 0x008DCB75 File Offset: 0x008DAD75
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_CursorPress_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorPress.WBP_CursorPress_C");
			}
			return WBP_CursorPress_C._ClassPtr;
		}

		// Token: 0x0601DAAA RID: 121514 RVA: 0x008DCB9C File Offset: 0x008DAD9C
		public WBP_CursorPress_C() : this(BuiltinUtils.AllocNativeUObject(WBP_CursorPress_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DAAB RID: 121515 RVA: 0x008DCBC4 File Offset: 0x008DADC4
		[NullableContext(1)]
		public WBP_CursorPress_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_CursorPress_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700271A RID: 10010
		// (get) Token: 0x0601DAAC RID: 121516 RVA: 0x008DCBF7 File Offset: 0x008DADF7
		// (set) Token: 0x0601DAAD RID: 121517 RVA: 0x008DCC0B File Offset: 0x008DAE0B
		[Nullable(2)]
		public unsafe UImage Image_35
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_CursorPress_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_CursorPress_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601DAAE RID: 121518 RVA: 0x008DCC20 File Offset: 0x008DAE20
		protected WBP_CursorPress_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E867 RID: 59495
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/Cursor/UMG/WBP_CursorPress.WBP_CursorPress_C";

		// Token: 0x0400E868 RID: 59496
		private static IntPtr _ClassPtr;

		// Token: 0x0400E869 RID: 59497
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E86A RID: 59498
		internal static int __PropertyOffset_0;
	}
}
