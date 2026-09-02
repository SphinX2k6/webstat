using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction
{
	// Token: 0x02003D23 RID: 15651
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectItem.SWaterEffectItem")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 104)]
	public class SWaterEffectItem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025D8E RID: 155022 RVA: 0x009C6D33 File Offset: 0x009C4F33
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWaterEffectItem._ScriptStructPtr != 0) ? SWaterEffectItem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectItem.SWaterEffectItem", ref SWaterEffectItem._ScriptStructPtr);
		}

		// Token: 0x1700540A RID: 21514
		// (get) Token: 0x06025D8F RID: 155023 RVA: 0x009C6D57 File Offset: 0x009C4F57
		// (set) Token: 0x06025D90 RID: 155024 RVA: 0x009C6D67 File Offset: 0x009C4F67
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectItem.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectItem.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700540B RID: 21515
		// (get) Token: 0x06025D91 RID: 155025 RVA: 0x009C6D78 File Offset: 0x009C4F78
		// (set) Token: 0x06025D92 RID: 155026 RVA: 0x009C6D97 File Offset: 0x009C4F97
		public TSoftObjectPtr<UEffectModelBase> EffectDataRef
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SWaterEffectItem.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SWaterEffectItem.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700540C RID: 21516
		// (get) Token: 0x06025D93 RID: 155027 RVA: 0x009C6DBC File Offset: 0x009C4FBC
		// (set) Token: 0x06025D94 RID: 155028 RVA: 0x009C6DDB File Offset: 0x009C4FDB
		public TSoftObjectPtr<UEffectModelBase> AudioEffectDataRef
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SWaterEffectItem.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SWaterEffectItem.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06025D95 RID: 155029 RVA: 0x009C6E00 File Offset: 0x009C5000
		public SWaterEffectItem()
		{
		}

		// Token: 0x06025D96 RID: 155030 RVA: 0x009C6E08 File Offset: 0x009C5008
		public SWaterEffectItem(float Speed, TSoftObjectPtr<UEffectModelBase> EffectDataRef, TSoftObjectPtr<UEffectModelBase> AudioEffectDataRef)
		{
			this.Speed = Speed;
			this.EffectDataRef = EffectDataRef;
			this.AudioEffectDataRef = AudioEffectDataRef;
		}

		// Token: 0x06025D97 RID: 155031 RVA: 0x009C6E25 File Offset: 0x009C5025
		protected override IntPtr GetUStructPtr()
		{
			return SWaterEffectItem.StaticStruct();
		}

		// Token: 0x06025D98 RID: 155032 RVA: 0x009C6E31 File Offset: 0x009C5031
		[NullableContext(2)]
		public SWaterEffectItem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025D99 RID: 155033 RVA: 0x009C6E3B File Offset: 0x009C503B
		public SWaterEffectItem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025D9A RID: 155034 RVA: 0x009C6E46 File Offset: 0x009C5046
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWaterEffectItem(Pointer, false, true);
		}

		// Token: 0x06025D9B RID: 155035 RVA: 0x009C6E50 File Offset: 0x009C5050
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWaterEffectItem(Pointer, MemoryOwner);
		}

		// Token: 0x040138FC RID: 80124
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectItem.SWaterEffectItem";

		// Token: 0x040138FD RID: 80125
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040138FE RID: 80126
		internal static int __PropertyOffset_0;

		// Token: 0x040138FF RID: 80127
		internal static int __PropertyOffset_1;

		// Token: 0x04013900 RID: 80128
		internal static int __PropertyOffset_2;
	}
}
