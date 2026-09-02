using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools
{
	// Token: 0x02004293 RID: 17043
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/ST_EdReplaceTag.ST_EdReplaceTag")]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class ST_EdReplaceTag : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D435 RID: 185397 RVA: 0x00ABB694 File Offset: 0x00AB9894
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ST_EdReplaceTag._ScriptStructPtr != 0) ? ST_EdReplaceTag._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/ST_EdReplaceTag.ST_EdReplaceTag", ref ST_EdReplaceTag._ScriptStructPtr);
		}

		// Token: 0x17007B5D RID: 31581
		// (get) Token: 0x0602D436 RID: 185398 RVA: 0x00ABB6B8 File Offset: 0x00AB98B8
		// (set) Token: 0x0602D437 RID: 185399 RVA: 0x00ABB6CC File Offset: 0x00AB98CC
		public unsafe FGameplayTag OldTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ST_EdReplaceTag.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ST_EdReplaceTag.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B5E RID: 31582
		// (get) Token: 0x0602D438 RID: 185400 RVA: 0x00ABB6E1 File Offset: 0x00AB98E1
		// (set) Token: 0x0602D439 RID: 185401 RVA: 0x00ABB6F5 File Offset: 0x00AB98F5
		public unsafe FGameplayTag NewTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ST_EdReplaceTag.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ST_EdReplaceTag.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602D43A RID: 185402 RVA: 0x00ABB70A File Offset: 0x00AB990A
		public ST_EdReplaceTag()
		{
		}

		// Token: 0x0602D43B RID: 185403 RVA: 0x00ABB712 File Offset: 0x00AB9912
		public ST_EdReplaceTag(FGameplayTag OldTag, FGameplayTag NewTag)
		{
			this.OldTag = OldTag;
			this.NewTag = NewTag;
		}

		// Token: 0x0602D43C RID: 185404 RVA: 0x00ABB728 File Offset: 0x00AB9928
		protected override IntPtr GetUStructPtr()
		{
			return ST_EdReplaceTag.StaticStruct();
		}

		// Token: 0x0602D43D RID: 185405 RVA: 0x00ABB734 File Offset: 0x00AB9934
		[NullableContext(2)]
		public ST_EdReplaceTag(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D43E RID: 185406 RVA: 0x00ABB73E File Offset: 0x00AB993E
		public ST_EdReplaceTag(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D43F RID: 185407 RVA: 0x00ABB749 File Offset: 0x00AB9949
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ST_EdReplaceTag(Pointer, false, true);
		}

		// Token: 0x0602D440 RID: 185408 RVA: 0x00ABB753 File Offset: 0x00AB9953
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ST_EdReplaceTag(Pointer, MemoryOwner);
		}

		// Token: 0x04019603 RID: 103939
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/ST_EdReplaceTag.ST_EdReplaceTag";

		// Token: 0x04019604 RID: 103940
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019605 RID: 103941
		internal static int __PropertyOffset_0;

		// Token: 0x04019606 RID: 103942
		internal static int __PropertyOffset_1;
	}
}
