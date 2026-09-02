using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction
{
	// Token: 0x02003D22 RID: 15650
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectGroup.SWaterEffectGroup")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SWaterEffectGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025D82 RID: 155010 RVA: 0x009C6C48 File Offset: 0x009C4E48
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWaterEffectGroup._ScriptStructPtr != 0) ? SWaterEffectGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectGroup.SWaterEffectGroup", ref SWaterEffectGroup._ScriptStructPtr);
		}

		// Token: 0x17005408 RID: 21512
		// (get) Token: 0x06025D83 RID: 155011 RVA: 0x009C6C6C File Offset: 0x009C4E6C
		// (set) Token: 0x06025D84 RID: 155012 RVA: 0x009C6C7C File Offset: 0x009C4E7C
		public unsafe float WaterDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectGroup.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectGroup.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005409 RID: 21513
		// (get) Token: 0x06025D85 RID: 155013 RVA: 0x009C6C90 File Offset: 0x009C4E90
		// (set) Token: 0x06025D86 RID: 155014 RVA: 0x009C6CD3 File Offset: 0x009C4ED3
		public TArray<SWaterEffectItem> EffectConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWaterEffectItem> result;
				if ((result = this._EffectConfig) == null)
				{
					result = (this._EffectConfig = new TArray<SWaterEffectItem>(base.NativePtr + (IntPtr)SWaterEffectGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EffectConfig.CopyAssign(value);
			}
		}

		// Token: 0x06025D87 RID: 155015 RVA: 0x009C6CE1 File Offset: 0x009C4EE1
		public SWaterEffectGroup()
		{
		}

		// Token: 0x06025D88 RID: 155016 RVA: 0x009C6CE9 File Offset: 0x009C4EE9
		public SWaterEffectGroup(float WaterDepth, TArray<SWaterEffectItem> EffectConfig)
		{
			this.WaterDepth = WaterDepth;
			this.EffectConfig = EffectConfig;
		}

		// Token: 0x06025D89 RID: 155017 RVA: 0x009C6CFF File Offset: 0x009C4EFF
		protected override IntPtr GetUStructPtr()
		{
			return SWaterEffectGroup.StaticStruct();
		}

		// Token: 0x06025D8A RID: 155018 RVA: 0x009C6D0B File Offset: 0x009C4F0B
		[NullableContext(2)]
		public SWaterEffectGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025D8B RID: 155019 RVA: 0x009C6D15 File Offset: 0x009C4F15
		public SWaterEffectGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025D8C RID: 155020 RVA: 0x009C6D20 File Offset: 0x009C4F20
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWaterEffectGroup(Pointer, false, true);
		}

		// Token: 0x06025D8D RID: 155021 RVA: 0x009C6D2A File Offset: 0x009C4F2A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWaterEffectGroup(Pointer, MemoryOwner);
		}

		// Token: 0x040138F7 RID: 80119
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectGroup.SWaterEffectGroup";

		// Token: 0x040138F8 RID: 80120
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040138F9 RID: 80121
		internal static int __PropertyOffset_0;

		// Token: 0x040138FA RID: 80122
		internal static int __PropertyOffset_1;

		// Token: 0x040138FB RID: 80123
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWaterEffectItem> _EffectConfig;
	}
}
