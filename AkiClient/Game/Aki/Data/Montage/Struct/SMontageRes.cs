using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Montage.Struct
{
	// Token: 0x02003E62 RID: 15970
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Montage/Struct/SMontageRes.SMontageRes")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SMontageRes : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060276C9 RID: 161481 RVA: 0x009F18D8 File Offset: 0x009EFAD8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMontageRes._ScriptStructPtr != 0) ? SMontageRes._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Montage/Struct/SMontageRes.SMontageRes", ref SMontageRes._ScriptStructPtr);
		}

		// Token: 0x17005CAF RID: 23727
		// (get) Token: 0x060276CA RID: 161482 RVA: 0x009F18FC File Offset: 0x009EFAFC
		// (set) Token: 0x060276CB RID: 161483 RVA: 0x009F1910 File Offset: 0x009EFB10
		[Nullable(2)]
		public unsafe UAnimMontage Montage
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + SMontageRes.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMontageRes.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005CB0 RID: 23728
		// (get) Token: 0x060276CC RID: 161484 RVA: 0x009F1925 File Offset: 0x009EFB25
		// (set) Token: 0x060276CD RID: 161485 RVA: 0x009F1939 File Offset: 0x009EFB39
		public unsafe string Des
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SMontageRes.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SMontageRes.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x060276CE RID: 161486 RVA: 0x009F194E File Offset: 0x009EFB4E
		public SMontageRes()
		{
		}

		// Token: 0x060276CF RID: 161487 RVA: 0x009F1956 File Offset: 0x009EFB56
		public SMontageRes(UAnimMontage Montage, string Des)
		{
			this.Montage = Montage;
			this.Des = Des;
		}

		// Token: 0x060276D0 RID: 161488 RVA: 0x009F196C File Offset: 0x009EFB6C
		protected override IntPtr GetUStructPtr()
		{
			return SMontageRes.StaticStruct();
		}

		// Token: 0x060276D1 RID: 161489 RVA: 0x009F1978 File Offset: 0x009EFB78
		[NullableContext(2)]
		public SMontageRes(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060276D2 RID: 161490 RVA: 0x009F1982 File Offset: 0x009EFB82
		public SMontageRes(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060276D3 RID: 161491 RVA: 0x009F198D File Offset: 0x009EFB8D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMontageRes(Pointer, false, true);
		}

		// Token: 0x060276D4 RID: 161492 RVA: 0x009F1997 File Offset: 0x009EFB97
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMontageRes(Pointer, MemoryOwner);
		}

		// Token: 0x04014A5F RID: 84575
		public const string __ObjectPath = "/Game/Aki/Data/Montage/Struct/SMontageRes.SMontageRes";

		// Token: 0x04014A60 RID: 84576
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A61 RID: 84577
		internal static int __PropertyOffset_0;

		// Token: 0x04014A62 RID: 84578
		internal static int __PropertyOffset_1;
	}
}
