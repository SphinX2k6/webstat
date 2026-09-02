using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004257 RID: 16983
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SDangoPerformData.SDangoPerformData")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SDangoPerformData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CFDF RID: 184287 RVA: 0x00AB4FEC File Offset: 0x00AB31EC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDangoPerformData._ScriptStructPtr != 0) ? SDangoPerformData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SDangoPerformData.SDangoPerformData", ref SDangoPerformData._ScriptStructPtr);
		}

		// Token: 0x17007A0A RID: 31242
		// (get) Token: 0x0602CFE0 RID: 184288 RVA: 0x00AB5010 File Offset: 0x00AB3210
		// (set) Token: 0x0602CFE1 RID: 184289 RVA: 0x00AB5024 File Offset: 0x00AB3224
		public unsafe TEnumAsByte<EDangoActionPerformType> 动画类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A0B RID: 31243
		// (get) Token: 0x0602CFE2 RID: 184290 RVA: 0x00AB5039 File Offset: 0x00AB3239
		// (set) Token: 0x0602CFE3 RID: 184291 RVA: 0x00AB504D File Offset: 0x00AB324D
		public unsafe TEnumAsByte<EDangoActionTargetType> 动画目标类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A0C RID: 31244
		// (get) Token: 0x0602CFE4 RID: 184292 RVA: 0x00AB5062 File Offset: 0x00AB3262
		// (set) Token: 0x0602CFE5 RID: 184293 RVA: 0x00AB5076 File Offset: 0x00AB3276
		public unsafe TEnumAsByte<EDangoActionPerformType> 堆叠上方团子动画类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A0D RID: 31245
		// (get) Token: 0x0602CFE6 RID: 184294 RVA: 0x00AB508B File Offset: 0x00AB328B
		// (set) Token: 0x0602CFE7 RID: 184295 RVA: 0x00AB509B File Offset: 0x00AB329B
		public unsafe int 持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A0E RID: 31246
		// (get) Token: 0x0602CFE8 RID: 184296 RVA: 0x00AB50AC File Offset: 0x00AB32AC
		// (set) Token: 0x0602CFE9 RID: 184297 RVA: 0x00AB50EF File Offset: 0x00AB32EF
		[Nullable(1)]
		public TArray<SDangoPerformEffectData> 特效列表
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SDangoPerformEffectData> result;
				if ((result = this._特效列表) == null)
				{
					result = (this._特效列表 = new TArray<SDangoPerformEffectData>(base.NativePtr + (IntPtr)SDangoPerformData.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.特效列表.CopyAssign(value);
			}
		}

		// Token: 0x0602CFEA RID: 184298 RVA: 0x00AB50FD File Offset: 0x00AB32FD
		public SDangoPerformData()
		{
		}

		// Token: 0x0602CFEB RID: 184299 RVA: 0x00AB5105 File Offset: 0x00AB3305
		public SDangoPerformData(TEnumAsByte<EDangoActionPerformType> 动画类型, TEnumAsByte<EDangoActionTargetType> 动画目标类型, TEnumAsByte<EDangoActionPerformType> 堆叠上方团子动画类型, int 持续时间, [Nullable(1)] TArray<SDangoPerformEffectData> 特效列表)
		{
			this.动画类型 = 动画类型;
			this.动画目标类型 = 动画目标类型;
			this.堆叠上方团子动画类型 = 堆叠上方团子动画类型;
			this.持续时间 = 持续时间;
			this.特效列表 = 特效列表;
		}

		// Token: 0x0602CFEC RID: 184300 RVA: 0x00AB5132 File Offset: 0x00AB3332
		protected override IntPtr GetUStructPtr()
		{
			return SDangoPerformData.StaticStruct();
		}

		// Token: 0x0602CFED RID: 184301 RVA: 0x00AB513E File Offset: 0x00AB333E
		[NullableContext(2)]
		public SDangoPerformData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CFEE RID: 184302 RVA: 0x00AB5148 File Offset: 0x00AB3348
		public SDangoPerformData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CFEF RID: 184303 RVA: 0x00AB5153 File Offset: 0x00AB3353
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDangoPerformData(Pointer, false, true);
		}

		// Token: 0x0602CFF0 RID: 184304 RVA: 0x00AB515D File Offset: 0x00AB335D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDangoPerformData(Pointer, MemoryOwner);
		}

		// Token: 0x040193CC RID: 103372
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SDangoPerformData.SDangoPerformData";

		// Token: 0x040193CD RID: 103373
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193CE RID: 103374
		internal static int __PropertyOffset_0;

		// Token: 0x040193CF RID: 103375
		internal static int __PropertyOffset_1;

		// Token: 0x040193D0 RID: 103376
		internal static int __PropertyOffset_2;

		// Token: 0x040193D1 RID: 103377
		internal static int __PropertyOffset_3;

		// Token: 0x040193D2 RID: 103378
		internal static int __PropertyOffset_4;

		// Token: 0x040193D3 RID: 103379
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SDangoPerformEffectData> _特效列表;
	}
}
