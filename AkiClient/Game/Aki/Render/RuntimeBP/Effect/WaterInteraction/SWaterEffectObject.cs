using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction
{
	// Token: 0x02003D24 RID: 15652
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectObject.SWaterEffectObject")]
	[UnrealStructLayout(176, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 172)]
	public class SWaterEffectObject : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025D9C RID: 155036 RVA: 0x009C6E59 File Offset: 0x009C5059
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWaterEffectObject._ScriptStructPtr != 0) ? SWaterEffectObject._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectObject.SWaterEffectObject", ref SWaterEffectObject._ScriptStructPtr);
		}

		// Token: 0x1700540D RID: 21517
		// (get) Token: 0x06025D9D RID: 155037 RVA: 0x009C6E7D File Offset: 0x009C507D
		// (set) Token: 0x06025D9E RID: 155038 RVA: 0x009C6E8D File Offset: 0x009C508D
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700540E RID: 21518
		// (get) Token: 0x06025D9F RID: 155039 RVA: 0x009C6E9E File Offset: 0x009C509E
		// (set) Token: 0x06025DA0 RID: 155040 RVA: 0x009C6EB2 File Offset: 0x009C50B2
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700540F RID: 21519
		// (get) Token: 0x06025DA1 RID: 155041 RVA: 0x009C6EC7 File Offset: 0x009C50C7
		// (set) Token: 0x06025DA2 RID: 155042 RVA: 0x009C6EE6 File Offset: 0x009C50E6
		public TSoftObjectPtr<UEffectModelBase> Effect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005410 RID: 21520
		// (get) Token: 0x06025DA3 RID: 155043 RVA: 0x009C6F0B File Offset: 0x009C510B
		// (set) Token: 0x06025DA4 RID: 155044 RVA: 0x009C6F1B File Offset: 0x009C511B
		public unsafe bool TriggerOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005411 RID: 21521
		// (get) Token: 0x06025DA5 RID: 155045 RVA: 0x009C6F2C File Offset: 0x009C512C
		// (set) Token: 0x06025DA6 RID: 155046 RVA: 0x009C6F3C File Offset: 0x009C513C
		public unsafe bool EnableSurfaceEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005412 RID: 21522
		// (get) Token: 0x06025DA7 RID: 155047 RVA: 0x009C6F4D File Offset: 0x009C514D
		// (set) Token: 0x06025DA8 RID: 155048 RVA: 0x009C6F6C File Offset: 0x009C516C
		public TSoftObjectPtr<UEffectModelBase> WaterSurfaceEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005413 RID: 21523
		// (get) Token: 0x06025DA9 RID: 155049 RVA: 0x009C6F91 File Offset: 0x009C5191
		// (set) Token: 0x06025DAA RID: 155050 RVA: 0x009C6FA1 File Offset: 0x009C51A1
		public unsafe float TimeAfterSurfaceEffectStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectObject.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06025DAB RID: 155051 RVA: 0x009C6FB2 File Offset: 0x009C51B2
		public SWaterEffectObject()
		{
		}

		// Token: 0x06025DAC RID: 155052 RVA: 0x009C6FBA File Offset: 0x009C51BA
		public SWaterEffectObject(float Radius, FTransform Transform, TSoftObjectPtr<UEffectModelBase> Effect, bool TriggerOnce, bool EnableSurfaceEffect, TSoftObjectPtr<UEffectModelBase> WaterSurfaceEffect, float TimeAfterSurfaceEffectStop)
		{
			this.Radius = Radius;
			this.Transform = Transform;
			this.Effect = Effect;
			this.TriggerOnce = TriggerOnce;
			this.EnableSurfaceEffect = EnableSurfaceEffect;
			this.WaterSurfaceEffect = WaterSurfaceEffect;
			this.TimeAfterSurfaceEffectStop = TimeAfterSurfaceEffectStop;
		}

		// Token: 0x06025DAD RID: 155053 RVA: 0x009C6FF7 File Offset: 0x009C51F7
		protected override IntPtr GetUStructPtr()
		{
			return SWaterEffectObject.StaticStruct();
		}

		// Token: 0x06025DAE RID: 155054 RVA: 0x009C7003 File Offset: 0x009C5203
		[NullableContext(2)]
		public SWaterEffectObject(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025DAF RID: 155055 RVA: 0x009C700D File Offset: 0x009C520D
		public SWaterEffectObject(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025DB0 RID: 155056 RVA: 0x009C7018 File Offset: 0x009C5218
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWaterEffectObject(Pointer, false, true);
		}

		// Token: 0x06025DB1 RID: 155057 RVA: 0x009C7022 File Offset: 0x009C5222
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWaterEffectObject(Pointer, MemoryOwner);
		}

		// Token: 0x04013901 RID: 80129
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectObject.SWaterEffectObject";

		// Token: 0x04013902 RID: 80130
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013903 RID: 80131
		internal static int __PropertyOffset_0;

		// Token: 0x04013904 RID: 80132
		internal static int __PropertyOffset_1;

		// Token: 0x04013905 RID: 80133
		internal static int __PropertyOffset_2;

		// Token: 0x04013906 RID: 80134
		internal static int __PropertyOffset_3;

		// Token: 0x04013907 RID: 80135
		internal static int __PropertyOffset_4;

		// Token: 0x04013908 RID: 80136
		internal static int __PropertyOffset_5;

		// Token: 0x04013909 RID: 80137
		internal static int __PropertyOffset_6;
	}
}
