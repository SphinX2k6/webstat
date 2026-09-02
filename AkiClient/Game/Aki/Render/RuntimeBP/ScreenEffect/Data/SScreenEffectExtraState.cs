using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A6C RID: 14956
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/SScreenEffectExtraState.SScreenEffectExtraState")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 160)]
	public class SScreenEffectExtraState : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601F2CF RID: 127695 RVA: 0x0090A127 File Offset: 0x00908327
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SScreenEffectExtraState._ScriptStructPtr != 0) ? SScreenEffectExtraState._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/SScreenEffectExtraState.SScreenEffectExtraState", ref SScreenEffectExtraState._ScriptStructPtr);
		}

		// Token: 0x17002E79 RID: 11897
		// (get) Token: 0x0601F2D0 RID: 127696 RVA: 0x0090A14C File Offset: 0x0090834C
		// (set) Token: 0x0601F2D1 RID: 127697 RVA: 0x0090A18F File Offset: 0x0090838F
		public TMap<FName, float> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, float>(base.NativePtr + (IntPtr)SScreenEffectExtraState.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E7A RID: 11898
		// (get) Token: 0x0601F2D2 RID: 127698 RVA: 0x0090A1A0 File Offset: 0x009083A0
		// (set) Token: 0x0601F2D3 RID: 127699 RVA: 0x0090A1E3 File Offset: 0x009083E3
		public TMap<FName, FLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)SScreenEffectExtraState.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x0601F2D4 RID: 127700 RVA: 0x0090A1F1 File Offset: 0x009083F1
		public SScreenEffectExtraState()
		{
		}

		// Token: 0x0601F2D5 RID: 127701 RVA: 0x0090A1F9 File Offset: 0x009083F9
		public SScreenEffectExtraState(TMap<FName, float> FloatParameters, TMap<FName, FLinearColor> ColorParameters)
		{
			this.FloatParameters = FloatParameters;
			this.ColorParameters = ColorParameters;
		}

		// Token: 0x0601F2D6 RID: 127702 RVA: 0x0090A20F File Offset: 0x0090840F
		protected override IntPtr GetUStructPtr()
		{
			return SScreenEffectExtraState.StaticStruct();
		}

		// Token: 0x0601F2D7 RID: 127703 RVA: 0x0090A21B File Offset: 0x0090841B
		[NullableContext(2)]
		public SScreenEffectExtraState(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601F2D8 RID: 127704 RVA: 0x0090A225 File Offset: 0x00908425
		public SScreenEffectExtraState(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601F2D9 RID: 127705 RVA: 0x0090A230 File Offset: 0x00908430
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SScreenEffectExtraState(Pointer, false, true);
		}

		// Token: 0x0601F2DA RID: 127706 RVA: 0x0090A23A File Offset: 0x0090843A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SScreenEffectExtraState(Pointer, MemoryOwner);
		}

		// Token: 0x0400F73C RID: 63292
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/SScreenEffectExtraState.SScreenEffectExtraState";

		// Token: 0x0400F73D RID: 63293
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F73E RID: 63294
		internal static int __PropertyOffset_0;

		// Token: 0x0400F73F RID: 63295
		[Nullable(2)]
		private TMap<FName, float> _FloatParameters;

		// Token: 0x0400F740 RID: 63296
		internal static int __PropertyOffset_1;

		// Token: 0x0400F741 RID: 63297
		[Nullable(2)]
		private TMap<FName, FLinearColor> _ColorParameters;
	}
}
