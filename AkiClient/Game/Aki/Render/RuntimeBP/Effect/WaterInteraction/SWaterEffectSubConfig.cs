using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction
{
	// Token: 0x02003D25 RID: 15653
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectSubConfig.SWaterEffectSubConfig")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SWaterEffectSubConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025DB2 RID: 155058 RVA: 0x009C702B File Offset: 0x009C522B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWaterEffectSubConfig._ScriptStructPtr != 0) ? SWaterEffectSubConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectSubConfig.SWaterEffectSubConfig", ref SWaterEffectSubConfig._ScriptStructPtr);
		}

		// Token: 0x17005414 RID: 21524
		// (get) Token: 0x06025DB3 RID: 155059 RVA: 0x009C7050 File Offset: 0x009C5250
		// (set) Token: 0x06025DB4 RID: 155060 RVA: 0x009C7093 File Offset: 0x009C5293
		public TArray<SWaterEffectGroup> MoveEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWaterEffectGroup> result;
				if ((result = this._MoveEffects) == null)
				{
					result = (this._MoveEffects = new TArray<SWaterEffectGroup>(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MoveEffects.CopyAssign(value);
			}
		}

		// Token: 0x17005415 RID: 21525
		// (get) Token: 0x06025DB5 RID: 155061 RVA: 0x009C70A4 File Offset: 0x009C52A4
		// (set) Token: 0x06025DB6 RID: 155062 RVA: 0x009C70E7 File Offset: 0x009C52E7
		public TArray<SWaterEffectGroup> ShallowMoveEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWaterEffectGroup> result;
				if ((result = this._ShallowMoveEffects) == null)
				{
					result = (this._ShallowMoveEffects = new TArray<SWaterEffectGroup>(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ShallowMoveEffects.CopyAssign(value);
			}
		}

		// Token: 0x17005416 RID: 21526
		// (get) Token: 0x06025DB7 RID: 155063 RVA: 0x009C70F8 File Offset: 0x009C52F8
		// (set) Token: 0x06025DB8 RID: 155064 RVA: 0x009C713B File Offset: 0x009C533B
		public TArray<SWaterEffectItem> FallEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWaterEffectItem> result;
				if ((result = this._FallEffects) == null)
				{
					result = (this._FallEffects = new TArray<SWaterEffectItem>(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FallEffects.CopyAssign(value);
			}
		}

		// Token: 0x17005417 RID: 21527
		// (get) Token: 0x06025DB9 RID: 155065 RVA: 0x009C714C File Offset: 0x009C534C
		// (set) Token: 0x06025DBA RID: 155066 RVA: 0x009C718F File Offset: 0x009C538F
		public TArray<SWaterEffectItem> JumpEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWaterEffectItem> result;
				if ((result = this._JumpEffects) == null)
				{
					result = (this._JumpEffects = new TArray<SWaterEffectItem>(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.JumpEffects.CopyAssign(value);
			}
		}

		// Token: 0x17005418 RID: 21528
		// (get) Token: 0x06025DBB RID: 155067 RVA: 0x009C71A0 File Offset: 0x009C53A0
		// (set) Token: 0x06025DBC RID: 155068 RVA: 0x009C71E3 File Offset: 0x009C53E3
		public TArray<SWaterEffectItem> FlyEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SWaterEffectItem> result;
				if ((result = this._FlyEffects) == null)
				{
					result = (this._FlyEffects = new TArray<SWaterEffectItem>(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FlyEffects.CopyAssign(value);
			}
		}

		// Token: 0x17005419 RID: 21529
		// (get) Token: 0x06025DBD RID: 155069 RVA: 0x009C71F1 File Offset: 0x009C53F1
		// (set) Token: 0x06025DBE RID: 155070 RVA: 0x009C7201 File Offset: 0x009C5401
		public unsafe float FallJumpDepthThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700541A RID: 21530
		// (get) Token: 0x06025DBF RID: 155071 RVA: 0x009C7212 File Offset: 0x009C5412
		// (set) Token: 0x06025DC0 RID: 155072 RVA: 0x009C7222 File Offset: 0x009C5422
		public unsafe bool TriggerInGrass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700541B RID: 21531
		// (get) Token: 0x06025DC1 RID: 155073 RVA: 0x009C7233 File Offset: 0x009C5433
		// (set) Token: 0x06025DC2 RID: 155074 RVA: 0x009C7243 File Offset: 0x009C5443
		public unsafe float FlyEffectTriggerHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700541C RID: 21532
		// (get) Token: 0x06025DC3 RID: 155075 RVA: 0x009C7254 File Offset: 0x009C5454
		// (set) Token: 0x06025DC4 RID: 155076 RVA: 0x009C7264 File Offset: 0x009C5464
		public unsafe float ShallowMoveDepthThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWaterEffectSubConfig.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x06025DC5 RID: 155077 RVA: 0x009C7275 File Offset: 0x009C5475
		public SWaterEffectSubConfig()
		{
		}

		// Token: 0x06025DC6 RID: 155078 RVA: 0x009C7280 File Offset: 0x009C5480
		public SWaterEffectSubConfig(TArray<SWaterEffectGroup> MoveEffects, TArray<SWaterEffectGroup> ShallowMoveEffects, TArray<SWaterEffectItem> FallEffects, TArray<SWaterEffectItem> JumpEffects, TArray<SWaterEffectItem> FlyEffects, float FallJumpDepthThreshold, bool TriggerInGrass, float FlyEffectTriggerHeight, float ShallowMoveDepthThreshold)
		{
			this.MoveEffects = MoveEffects;
			this.ShallowMoveEffects = ShallowMoveEffects;
			this.FallEffects = FallEffects;
			this.JumpEffects = JumpEffects;
			this.FlyEffects = FlyEffects;
			this.FallJumpDepthThreshold = FallJumpDepthThreshold;
			this.TriggerInGrass = TriggerInGrass;
			this.FlyEffectTriggerHeight = FlyEffectTriggerHeight;
			this.ShallowMoveDepthThreshold = ShallowMoveDepthThreshold;
		}

		// Token: 0x06025DC7 RID: 155079 RVA: 0x009C72D8 File Offset: 0x009C54D8
		protected override IntPtr GetUStructPtr()
		{
			return SWaterEffectSubConfig.StaticStruct();
		}

		// Token: 0x06025DC8 RID: 155080 RVA: 0x009C72E4 File Offset: 0x009C54E4
		[NullableContext(2)]
		public SWaterEffectSubConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025DC9 RID: 155081 RVA: 0x009C72EE File Offset: 0x009C54EE
		public SWaterEffectSubConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025DCA RID: 155082 RVA: 0x009C72F9 File Offset: 0x009C54F9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWaterEffectSubConfig(Pointer, false, true);
		}

		// Token: 0x06025DCB RID: 155083 RVA: 0x009C7303 File Offset: 0x009C5503
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWaterEffectSubConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401390A RID: 80138
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/WaterInteraction/SWaterEffectSubConfig.SWaterEffectSubConfig";

		// Token: 0x0401390B RID: 80139
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401390C RID: 80140
		internal static int __PropertyOffset_0;

		// Token: 0x0401390D RID: 80141
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWaterEffectGroup> _MoveEffects;

		// Token: 0x0401390E RID: 80142
		internal static int __PropertyOffset_1;

		// Token: 0x0401390F RID: 80143
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWaterEffectGroup> _ShallowMoveEffects;

		// Token: 0x04013910 RID: 80144
		internal static int __PropertyOffset_2;

		// Token: 0x04013911 RID: 80145
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWaterEffectItem> _FallEffects;

		// Token: 0x04013912 RID: 80146
		internal static int __PropertyOffset_3;

		// Token: 0x04013913 RID: 80147
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWaterEffectItem> _JumpEffects;

		// Token: 0x04013914 RID: 80148
		internal static int __PropertyOffset_4;

		// Token: 0x04013915 RID: 80149
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SWaterEffectItem> _FlyEffects;

		// Token: 0x04013916 RID: 80150
		internal static int __PropertyOffset_5;

		// Token: 0x04013917 RID: 80151
		internal static int __PropertyOffset_6;

		// Token: 0x04013918 RID: 80152
		internal static int __PropertyOffset_7;

		// Token: 0x04013919 RID: 80153
		internal static int __PropertyOffset_8;
	}
}
