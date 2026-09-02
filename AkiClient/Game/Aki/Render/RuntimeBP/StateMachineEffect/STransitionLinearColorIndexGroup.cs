using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A4F RID: 14927
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/STransitionLinearColorIndexGroup.STransitionLinearColorIndexGroup")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class STransitionLinearColorIndexGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EEF1 RID: 126705 RVA: 0x00902900 File Offset: 0x00900B00
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (STransitionLinearColorIndexGroup._ScriptStructPtr != 0) ? STransitionLinearColorIndexGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/STransitionLinearColorIndexGroup.STransitionLinearColorIndexGroup", ref STransitionLinearColorIndexGroup._ScriptStructPtr);
		}

		// Token: 0x17002D36 RID: 11574
		// (get) Token: 0x0601EEF2 RID: 126706 RVA: 0x00902924 File Offset: 0x00900B24
		// (set) Token: 0x0601EEF3 RID: 126707 RVA: 0x00902967 File Offset: 0x00900B67
		public TMap<FName, FLinearColor> LinearColorValues
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._LinearColorValues) == null)
				{
					result = (this._LinearColorValues = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)STransitionLinearColorIndexGroup.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.LinearColorValues.CopyAssign(value);
			}
		}

		// Token: 0x0601EEF4 RID: 126708 RVA: 0x00902975 File Offset: 0x00900B75
		public STransitionLinearColorIndexGroup()
		{
		}

		// Token: 0x0601EEF5 RID: 126709 RVA: 0x0090297D File Offset: 0x00900B7D
		public STransitionLinearColorIndexGroup(TMap<FName, FLinearColor> LinearColorValues)
		{
			this.LinearColorValues = LinearColorValues;
		}

		// Token: 0x0601EEF6 RID: 126710 RVA: 0x0090298C File Offset: 0x00900B8C
		protected override IntPtr GetUStructPtr()
		{
			return STransitionLinearColorIndexGroup.StaticStruct();
		}

		// Token: 0x0601EEF7 RID: 126711 RVA: 0x00902998 File Offset: 0x00900B98
		[NullableContext(2)]
		public STransitionLinearColorIndexGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EEF8 RID: 126712 RVA: 0x009029A2 File Offset: 0x00900BA2
		public STransitionLinearColorIndexGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EEF9 RID: 126713 RVA: 0x009029AD File Offset: 0x00900BAD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new STransitionLinearColorIndexGroup(Pointer, false, true);
		}

		// Token: 0x0601EEFA RID: 126714 RVA: 0x009029B7 File Offset: 0x00900BB7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new STransitionLinearColorIndexGroup(Pointer, MemoryOwner);
		}

		// Token: 0x0400F4B4 RID: 62644
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/STransitionLinearColorIndexGroup.STransitionLinearColorIndexGroup";

		// Token: 0x0400F4B5 RID: 62645
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F4B6 RID: 62646
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4B7 RID: 62647
		[Nullable(2)]
		private TMap<FName, FLinearColor> _LinearColorValues;
	}
}
