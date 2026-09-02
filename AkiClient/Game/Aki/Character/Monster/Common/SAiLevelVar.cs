using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Monster.Common
{
	// Token: 0x0200419F RID: 16799
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/Monster/Common/SAiLevelVar.SAiLevelVar")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class SAiLevelVar : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602C963 RID: 182627 RVA: 0x00AA733F File Offset: 0x00AA553F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiLevelVar._ScriptStructPtr != 0) ? SAiLevelVar._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Monster/Common/SAiLevelVar.SAiLevelVar", ref SAiLevelVar._ScriptStructPtr);
		}

		// Token: 0x1700782D RID: 30765
		// (get) Token: 0x0602C964 RID: 182628 RVA: 0x00AA7363 File Offset: 0x00AA5563
		// (set) Token: 0x0602C965 RID: 182629 RVA: 0x00AA7377 File Offset: 0x00AA5577
		public unsafe TEnumAsByte<EAiLevelVarSource> VarSource
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiLevelVar.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiLevelVar.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700782E RID: 30766
		// (get) Token: 0x0602C966 RID: 182630 RVA: 0x00AA738C File Offset: 0x00AA558C
		// (set) Token: 0x0602C967 RID: 182631 RVA: 0x00AA73A0 File Offset: 0x00AA55A0
		[Nullable(1)]
		public unsafe string VarName
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAiLevelVar.__PropertyOffset_1)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAiLevelVar.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x1700782F RID: 30767
		// (get) Token: 0x0602C968 RID: 182632 RVA: 0x00AA73B5 File Offset: 0x00AA55B5
		// (set) Token: 0x0602C969 RID: 182633 RVA: 0x00AA73C5 File Offset: 0x00AA55C5
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiLevelVar.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiLevelVar.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602C96A RID: 182634 RVA: 0x00AA73D6 File Offset: 0x00AA55D6
		public SAiLevelVar()
		{
		}

		// Token: 0x0602C96B RID: 182635 RVA: 0x00AA73DE File Offset: 0x00AA55DE
		public SAiLevelVar(TEnumAsByte<EAiLevelVarSource> VarSource, [Nullable(1)] string VarName, int Id)
		{
			this.VarSource = VarSource;
			this.VarName = VarName;
			this.Id = Id;
		}

		// Token: 0x0602C96C RID: 182636 RVA: 0x00AA73FB File Offset: 0x00AA55FB
		protected override IntPtr GetUStructPtr()
		{
			return SAiLevelVar.StaticStruct();
		}

		// Token: 0x0602C96D RID: 182637 RVA: 0x00AA7407 File Offset: 0x00AA5607
		[NullableContext(2)]
		public SAiLevelVar(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602C96E RID: 182638 RVA: 0x00AA7411 File Offset: 0x00AA5611
		public SAiLevelVar(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602C96F RID: 182639 RVA: 0x00AA741C File Offset: 0x00AA561C
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiLevelVar(Pointer, false, true);
		}

		// Token: 0x0602C970 RID: 182640 RVA: 0x00AA7426 File Offset: 0x00AA5626
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiLevelVar(Pointer, MemoryOwner);
		}

		// Token: 0x04018CE9 RID: 101609
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Monster/Common/SAiLevelVar.SAiLevelVar";

		// Token: 0x04018CEA RID: 101610
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04018CEB RID: 101611
		internal static int __PropertyOffset_0;

		// Token: 0x04018CEC RID: 101612
		internal static int __PropertyOffset_1;

		// Token: 0x04018CED RID: 101613
		internal static int __PropertyOffset_2;
	}
}
