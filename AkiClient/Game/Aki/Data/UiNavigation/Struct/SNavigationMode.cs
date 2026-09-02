using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.UiNavigation.Struct
{
	// Token: 0x02003DF8 RID: 15864
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/UiNavigation/Struct/SNavigationMode.SNavigationMode")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SNavigationMode : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602708B RID: 159883 RVA: 0x009E8750 File Offset: 0x009E6950
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNavigationMode._ScriptStructPtr != 0) ? SNavigationMode._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiNavigation/Struct/SNavigationMode.SNavigationMode", ref SNavigationMode._ScriptStructPtr);
		}

		// Token: 0x17005AA1 RID: 23201
		// (get) Token: 0x0602708C RID: 159884 RVA: 0x009E8774 File Offset: 0x009E6974
		// (set) Token: 0x0602708D RID: 159885 RVA: 0x009E8784 File Offset: 0x009E6984
		public unsafe EUISelectableNavigationMode TopMode
		{
			get
			{
				return (EUISelectableNavigationMode)(*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_0));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_0) = (byte)value;
			}
		}

		// Token: 0x17005AA2 RID: 23202
		// (get) Token: 0x0602708E RID: 159886 RVA: 0x009E8795 File Offset: 0x009E6995
		// (set) Token: 0x0602708F RID: 159887 RVA: 0x009E87A9 File Offset: 0x009E69A9
		public unsafe AActor TopActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005AA3 RID: 23203
		// (get) Token: 0x06027090 RID: 159888 RVA: 0x009E87BE File Offset: 0x009E69BE
		// (set) Token: 0x06027091 RID: 159889 RVA: 0x009E87CE File Offset: 0x009E69CE
		public unsafe EUISelectableNavigationMode DownMode
		{
			get
			{
				return (EUISelectableNavigationMode)(*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_2));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_2) = (byte)value;
			}
		}

		// Token: 0x17005AA4 RID: 23204
		// (get) Token: 0x06027092 RID: 159890 RVA: 0x009E87DF File Offset: 0x009E69DF
		// (set) Token: 0x06027093 RID: 159891 RVA: 0x009E87F3 File Offset: 0x009E69F3
		public unsafe AActor DownActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005AA5 RID: 23205
		// (get) Token: 0x06027094 RID: 159892 RVA: 0x009E8808 File Offset: 0x009E6A08
		// (set) Token: 0x06027095 RID: 159893 RVA: 0x009E8818 File Offset: 0x009E6A18
		public unsafe EUISelectableNavigationMode LeftMode
		{
			get
			{
				return (EUISelectableNavigationMode)(*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_4));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_4) = (byte)value;
			}
		}

		// Token: 0x17005AA6 RID: 23206
		// (get) Token: 0x06027096 RID: 159894 RVA: 0x009E8829 File Offset: 0x009E6A29
		// (set) Token: 0x06027097 RID: 159895 RVA: 0x009E883D File Offset: 0x009E6A3D
		public unsafe AActor LeftActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005AA7 RID: 23207
		// (get) Token: 0x06027098 RID: 159896 RVA: 0x009E8852 File Offset: 0x009E6A52
		// (set) Token: 0x06027099 RID: 159897 RVA: 0x009E8862 File Offset: 0x009E6A62
		public unsafe EUISelectableNavigationMode RightMode
		{
			get
			{
				return (EUISelectableNavigationMode)(*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_6));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationMode.__PropertyOffset_6) = (byte)value;
			}
		}

		// Token: 0x17005AA8 RID: 23208
		// (get) Token: 0x0602709A RID: 159898 RVA: 0x009E8873 File Offset: 0x009E6A73
		// (set) Token: 0x0602709B RID: 159899 RVA: 0x009E8887 File Offset: 0x009E6A87
		public unsafe AActor RightActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationMode.__PropertyOffset_7, value);
			}
		}

		// Token: 0x0602709C RID: 159900 RVA: 0x009E889C File Offset: 0x009E6A9C
		public SNavigationMode()
		{
		}

		// Token: 0x0602709D RID: 159901 RVA: 0x009E88A4 File Offset: 0x009E6AA4
		[NullableContext(1)]
		public SNavigationMode(EUISelectableNavigationMode TopMode, AActor TopActor, EUISelectableNavigationMode DownMode, AActor DownActor, EUISelectableNavigationMode LeftMode, AActor LeftActor, EUISelectableNavigationMode RightMode, AActor RightActor)
		{
			this.TopMode = TopMode;
			this.TopActor = TopActor;
			this.DownMode = DownMode;
			this.DownActor = DownActor;
			this.LeftMode = LeftMode;
			this.LeftActor = LeftActor;
			this.RightMode = RightMode;
			this.RightActor = RightActor;
		}

		// Token: 0x0602709E RID: 159902 RVA: 0x009E88F4 File Offset: 0x009E6AF4
		protected override IntPtr GetUStructPtr()
		{
			return SNavigationMode.StaticStruct();
		}

		// Token: 0x0602709F RID: 159903 RVA: 0x009E8900 File Offset: 0x009E6B00
		public SNavigationMode(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060270A0 RID: 159904 RVA: 0x009E890A File Offset: 0x009E6B0A
		public SNavigationMode(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060270A1 RID: 159905 RVA: 0x009E8915 File Offset: 0x009E6B15
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNavigationMode(Pointer, false, true);
		}

		// Token: 0x060270A2 RID: 159906 RVA: 0x009E891F File Offset: 0x009E6B1F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNavigationMode(Pointer, MemoryOwner);
		}

		// Token: 0x04014637 RID: 83511
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/UiNavigation/Struct/SNavigationMode.SNavigationMode";

		// Token: 0x04014638 RID: 83512
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014639 RID: 83513
		internal static int __PropertyOffset_0;

		// Token: 0x0401463A RID: 83514
		internal static int __PropertyOffset_1;

		// Token: 0x0401463B RID: 83515
		internal static int __PropertyOffset_2;

		// Token: 0x0401463C RID: 83516
		internal static int __PropertyOffset_3;

		// Token: 0x0401463D RID: 83517
		internal static int __PropertyOffset_4;

		// Token: 0x0401463E RID: 83518
		internal static int __PropertyOffset_5;

		// Token: 0x0401463F RID: 83519
		internal static int __PropertyOffset_6;

		// Token: 0x04014640 RID: 83520
		internal static int __PropertyOffset_7;
	}
}
