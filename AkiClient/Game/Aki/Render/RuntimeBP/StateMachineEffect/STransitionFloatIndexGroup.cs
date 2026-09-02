using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A4E RID: 14926
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/STransitionFloatIndexGroup.STransitionFloatIndexGroup")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class STransitionFloatIndexGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EEE7 RID: 126695 RVA: 0x0090283F File Offset: 0x00900A3F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (STransitionFloatIndexGroup._ScriptStructPtr != 0) ? STransitionFloatIndexGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/STransitionFloatIndexGroup.STransitionFloatIndexGroup", ref STransitionFloatIndexGroup._ScriptStructPtr);
		}

		// Token: 0x17002D35 RID: 11573
		// (get) Token: 0x0601EEE8 RID: 126696 RVA: 0x00902864 File Offset: 0x00900A64
		// (set) Token: 0x0601EEE9 RID: 126697 RVA: 0x009028A7 File Offset: 0x00900AA7
		public TMap<FName, float> FloatValues
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._FloatValues) == null)
				{
					result = (this._FloatValues = new TMap<FName, float>(base.NativePtr + (IntPtr)STransitionFloatIndexGroup.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatValues.CopyAssign(value);
			}
		}

		// Token: 0x0601EEEA RID: 126698 RVA: 0x009028B5 File Offset: 0x00900AB5
		public STransitionFloatIndexGroup()
		{
		}

		// Token: 0x0601EEEB RID: 126699 RVA: 0x009028BD File Offset: 0x00900ABD
		public STransitionFloatIndexGroup(TMap<FName, float> FloatValues)
		{
			this.FloatValues = FloatValues;
		}

		// Token: 0x0601EEEC RID: 126700 RVA: 0x009028CC File Offset: 0x00900ACC
		protected override IntPtr GetUStructPtr()
		{
			return STransitionFloatIndexGroup.StaticStruct();
		}

		// Token: 0x0601EEED RID: 126701 RVA: 0x009028D8 File Offset: 0x00900AD8
		[NullableContext(2)]
		public STransitionFloatIndexGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EEEE RID: 126702 RVA: 0x009028E2 File Offset: 0x00900AE2
		public STransitionFloatIndexGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EEEF RID: 126703 RVA: 0x009028ED File Offset: 0x00900AED
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new STransitionFloatIndexGroup(Pointer, false, true);
		}

		// Token: 0x0601EEF0 RID: 126704 RVA: 0x009028F7 File Offset: 0x00900AF7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new STransitionFloatIndexGroup(Pointer, MemoryOwner);
		}

		// Token: 0x0400F4B0 RID: 62640
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/STransitionFloatIndexGroup.STransitionFloatIndexGroup";

		// Token: 0x0400F4B1 RID: 62641
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F4B2 RID: 62642
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4B3 RID: 62643
		[Nullable(2)]
		private TMap<FName, float> _FloatValues;
	}
}
