using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004254 RID: 16980
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCustomValueFormula.SCustomValueFormula")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 33)]
	public class SCustomValueFormula : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CFB0 RID: 184240 RVA: 0x00AB4B7D File Offset: 0x00AB2D7D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCustomValueFormula._ScriptStructPtr != 0) ? SCustomValueFormula._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCustomValueFormula.SCustomValueFormula", ref SCustomValueFormula._ScriptStructPtr);
		}

		// Token: 0x170079FE RID: 31230
		// (get) Token: 0x0602CFB1 RID: 184241 RVA: 0x00AB4BA1 File Offset: 0x00AB2DA1
		// (set) Token: 0x0602CFB2 RID: 184242 RVA: 0x00AB4BB5 File Offset: 0x00AB2DB5
		public unsafe string Condition
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCustomValueFormula.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCustomValueFormula.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170079FF RID: 31231
		// (get) Token: 0x0602CFB3 RID: 184243 RVA: 0x00AB4BCA File Offset: 0x00AB2DCA
		// (set) Token: 0x0602CFB4 RID: 184244 RVA: 0x00AB4BDE File Offset: 0x00AB2DDE
		public unsafe string Value
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCustomValueFormula.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCustomValueFormula.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007A00 RID: 31232
		// (get) Token: 0x0602CFB5 RID: 184245 RVA: 0x00AB4BF3 File Offset: 0x00AB2DF3
		// (set) Token: 0x0602CFB6 RID: 184246 RVA: 0x00AB4C03 File Offset: 0x00AB2E03
		public unsafe bool IsContinueFormula
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCustomValueFormula.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCustomValueFormula.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CFB7 RID: 184247 RVA: 0x00AB4C14 File Offset: 0x00AB2E14
		public SCustomValueFormula()
		{
		}

		// Token: 0x0602CFB8 RID: 184248 RVA: 0x00AB4C1C File Offset: 0x00AB2E1C
		public SCustomValueFormula(string Condition, string Value, bool IsContinueFormula)
		{
			this.Condition = Condition;
			this.Value = Value;
			this.IsContinueFormula = IsContinueFormula;
		}

		// Token: 0x0602CFB9 RID: 184249 RVA: 0x00AB4C39 File Offset: 0x00AB2E39
		protected override IntPtr GetUStructPtr()
		{
			return SCustomValueFormula.StaticStruct();
		}

		// Token: 0x0602CFBA RID: 184250 RVA: 0x00AB4C45 File Offset: 0x00AB2E45
		[NullableContext(2)]
		public SCustomValueFormula(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CFBB RID: 184251 RVA: 0x00AB4C4F File Offset: 0x00AB2E4F
		public SCustomValueFormula(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CFBC RID: 184252 RVA: 0x00AB4C5A File Offset: 0x00AB2E5A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCustomValueFormula(Pointer, false, true);
		}

		// Token: 0x0602CFBD RID: 184253 RVA: 0x00AB4C64 File Offset: 0x00AB2E64
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCustomValueFormula(Pointer, MemoryOwner);
		}

		// Token: 0x040193B4 RID: 103348
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCustomValueFormula.SCustomValueFormula";

		// Token: 0x040193B5 RID: 103349
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193B6 RID: 103350
		internal static int __PropertyOffset_0;

		// Token: 0x040193B7 RID: 103351
		internal static int __PropertyOffset_1;

		// Token: 0x040193B8 RID: 103352
		internal static int __PropertyOffset_2;
	}
}
