using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E21 RID: 15905
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaPrompt.SQtaPrompt")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 264)]
	public class SQtaPrompt : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027332 RID: 160562 RVA: 0x009EC262 File Offset: 0x009EA462
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaPrompt._ScriptStructPtr != 0) ? SQtaPrompt._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaPrompt.SQtaPrompt", ref SQtaPrompt._ScriptStructPtr);
		}

		// Token: 0x17005B97 RID: 23447
		// (get) Token: 0x06027333 RID: 160563 RVA: 0x009EC286 File Offset: 0x009EA486
		// (set) Token: 0x06027334 RID: 160564 RVA: 0x009EC29A File Offset: 0x009EA49A
		public unsafe TEnumAsByte<EQtaPromptType> PromptType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaPrompt.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaPrompt.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B98 RID: 23448
		// (get) Token: 0x06027335 RID: 160565 RVA: 0x009EC2B0 File Offset: 0x009EA4B0
		// (set) Token: 0x06027336 RID: 160566 RVA: 0x009EC2F3 File Offset: 0x009EA4F3
		[Nullable(1)]
		public SQtaPrompt_Content PromptContent
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SQtaPrompt_Content result;
				if ((result = this._PromptContent) == null)
				{
					result = (this._PromptContent = new SQtaPrompt_Content(base.NativePtr + (IntPtr)SQtaPrompt.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaPrompt_Content.StaticStruct(), base.NativePtr + (IntPtr)SQtaPrompt.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027337 RID: 160567 RVA: 0x009EC314 File Offset: 0x009EA514
		public SQtaPrompt()
		{
		}

		// Token: 0x06027338 RID: 160568 RVA: 0x009EC31C File Offset: 0x009EA51C
		public SQtaPrompt(TEnumAsByte<EQtaPromptType> PromptType, [Nullable(1)] SQtaPrompt_Content PromptContent)
		{
			this.PromptType = PromptType;
			this.PromptContent = PromptContent;
		}

		// Token: 0x06027339 RID: 160569 RVA: 0x009EC332 File Offset: 0x009EA532
		protected override IntPtr GetUStructPtr()
		{
			return SQtaPrompt.StaticStruct();
		}

		// Token: 0x0602733A RID: 160570 RVA: 0x009EC33E File Offset: 0x009EA53E
		[NullableContext(2)]
		public SQtaPrompt(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602733B RID: 160571 RVA: 0x009EC348 File Offset: 0x009EA548
		public SQtaPrompt(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602733C RID: 160572 RVA: 0x009EC353 File Offset: 0x009EA553
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaPrompt(Pointer, false, true);
		}

		// Token: 0x0602733D RID: 160573 RVA: 0x009EC35D File Offset: 0x009EA55D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaPrompt(Pointer, MemoryOwner);
		}

		// Token: 0x040147EA RID: 83946
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaPrompt.SQtaPrompt";

		// Token: 0x040147EB RID: 83947
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147EC RID: 83948
		internal static int __PropertyOffset_0;

		// Token: 0x040147ED RID: 83949
		internal static int __PropertyOffset_1;

		// Token: 0x040147EE RID: 83950
		[Nullable(2)]
		private SQtaPrompt_Content _PromptContent;
	}
}
