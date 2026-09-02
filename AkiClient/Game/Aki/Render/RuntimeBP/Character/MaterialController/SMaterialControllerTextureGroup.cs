using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D85 RID: 15749
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerTextureGroup.SMaterialControllerTextureGroup")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SMaterialControllerTextureGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602671A RID: 157466 RVA: 0x009D7F80 File Offset: 0x009D6180
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerTextureGroup._ScriptStructPtr != 0) ? SMaterialControllerTextureGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerTextureGroup.SMaterialControllerTextureGroup", ref SMaterialControllerTextureGroup._ScriptStructPtr);
		}

		// Token: 0x17005765 RID: 22373
		// (get) Token: 0x0602671B RID: 157467 RVA: 0x009D7FA4 File Offset: 0x009D61A4
		// (set) Token: 0x0602671C RID: 157468 RVA: 0x009D7FB8 File Offset: 0x009D61B8
		public unsafe UTexture2D Start
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialControllerTextureGroup.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialControllerTextureGroup.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005766 RID: 22374
		// (get) Token: 0x0602671D RID: 157469 RVA: 0x009D7FCD File Offset: 0x009D61CD
		// (set) Token: 0x0602671E RID: 157470 RVA: 0x009D7FE1 File Offset: 0x009D61E1
		public unsafe UTexture2D Loop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialControllerTextureGroup.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialControllerTextureGroup.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005767 RID: 22375
		// (get) Token: 0x0602671F RID: 157471 RVA: 0x009D7FF6 File Offset: 0x009D61F6
		// (set) Token: 0x06026720 RID: 157472 RVA: 0x009D800A File Offset: 0x009D620A
		public unsafe UTexture2D End
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialControllerTextureGroup.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialControllerTextureGroup.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06026721 RID: 157473 RVA: 0x009D801F File Offset: 0x009D621F
		public SMaterialControllerTextureGroup()
		{
		}

		// Token: 0x06026722 RID: 157474 RVA: 0x009D8027 File Offset: 0x009D6227
		[NullableContext(1)]
		public SMaterialControllerTextureGroup(UTexture2D Start, UTexture2D Loop, UTexture2D End)
		{
			this.Start = Start;
			this.Loop = Loop;
			this.End = End;
		}

		// Token: 0x06026723 RID: 157475 RVA: 0x009D8044 File Offset: 0x009D6244
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialControllerTextureGroup.StaticStruct();
		}

		// Token: 0x06026724 RID: 157476 RVA: 0x009D8050 File Offset: 0x009D6250
		public SMaterialControllerTextureGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026725 RID: 157477 RVA: 0x009D805A File Offset: 0x009D625A
		public SMaterialControllerTextureGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026726 RID: 157478 RVA: 0x009D8065 File Offset: 0x009D6265
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialControllerTextureGroup(Pointer, false, true);
		}

		// Token: 0x06026727 RID: 157479 RVA: 0x009D806F File Offset: 0x009D626F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialControllerTextureGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04013F74 RID: 81780
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerTextureGroup.SMaterialControllerTextureGroup";

		// Token: 0x04013F75 RID: 81781
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013F76 RID: 81782
		internal static int __PropertyOffset_0;

		// Token: 0x04013F77 RID: 81783
		internal static int __PropertyOffset_1;

		// Token: 0x04013F78 RID: 81784
		internal static int __PropertyOffset_2;
	}
}
