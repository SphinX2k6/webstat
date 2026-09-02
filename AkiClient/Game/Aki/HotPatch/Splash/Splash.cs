using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch.Splash
{
	// Token: 0x02003DC1 RID: 15809
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/HotPatch/Splash/Splash.Splash")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class Splash : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026B7B RID: 158587 RVA: 0x009E0367 File Offset: 0x009DE567
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Splash._ScriptStructPtr != 0) ? Splash._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/HotPatch/Splash/Splash.Splash", ref Splash._ScriptStructPtr);
		}

		// Token: 0x170058C4 RID: 22724
		// (get) Token: 0x06026B7C RID: 158588 RVA: 0x009E038B File Offset: 0x009DE58B
		// (set) Token: 0x06026B7D RID: 158589 RVA: 0x009E039F File Offset: 0x009DE59F
		[Nullable(2)]
		public unsafe UTexture2D value
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Splash.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Splash.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058C5 RID: 22725
		// (get) Token: 0x06026B7E RID: 158590 RVA: 0x009E03B4 File Offset: 0x009DE5B4
		// (set) Token: 0x06026B7F RID: 158591 RVA: 0x009E03C8 File Offset: 0x009DE5C8
		public unsafe string path
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Splash.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Splash.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x06026B80 RID: 158592 RVA: 0x009E03DD File Offset: 0x009DE5DD
		public Splash()
		{
		}

		// Token: 0x06026B81 RID: 158593 RVA: 0x009E03E5 File Offset: 0x009DE5E5
		public Splash(UTexture2D value, string path)
		{
			this.value = value;
			this.path = path;
		}

		// Token: 0x06026B82 RID: 158594 RVA: 0x009E03FB File Offset: 0x009DE5FB
		protected override IntPtr GetUStructPtr()
		{
			return Splash.StaticStruct();
		}

		// Token: 0x06026B83 RID: 158595 RVA: 0x009E0407 File Offset: 0x009DE607
		[NullableContext(2)]
		public Splash(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B84 RID: 158596 RVA: 0x009E0411 File Offset: 0x009DE611
		public Splash(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B85 RID: 158597 RVA: 0x009E041C File Offset: 0x009DE61C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Splash(Pointer, false, true);
		}

		// Token: 0x06026B86 RID: 158598 RVA: 0x009E0426 File Offset: 0x009DE626
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Splash(Pointer, MemoryOwner);
		}

		// Token: 0x040142F3 RID: 82675
		public const string __ObjectPath = "/Game/Aki/HotPatch/Splash/Splash.Splash";

		// Token: 0x040142F4 RID: 82676
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040142F5 RID: 82677
		internal static int __PropertyOffset_0;

		// Token: 0x040142F6 RID: 82678
		internal static int __PropertyOffset_1;
	}
}
