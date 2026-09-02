using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004241 RID: 16961
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataEffect.SBulletDataEffect")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SBulletDataEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE25 RID: 183845 RVA: 0x00AB2476 File Offset: 0x00AB0676
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataEffect._ScriptStructPtr != 0) ? SBulletDataEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataEffect.SBulletDataEffect", ref SBulletDataEffect._ScriptStructPtr);
		}

		// Token: 0x17007983 RID: 31107
		// (get) Token: 0x0602CE26 RID: 183846 RVA: 0x00AB249A File Offset: 0x00AB069A
		// (set) Token: 0x0602CE27 RID: 183847 RVA: 0x00AB24B9 File Offset: 0x00AB06B9
		public TSoftClassPtr<UMatineeCameraShake> 受击震屏
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007984 RID: 31108
		// (get) Token: 0x0602CE28 RID: 183848 RVA: 0x00AB24DE File Offset: 0x00AB06DE
		// (set) Token: 0x0602CE29 RID: 183849 RVA: 0x00AB24EE File Offset: 0x00AB06EE
		public unsafe int 最大震动次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007985 RID: 31109
		// (get) Token: 0x0602CE2A RID: 183850 RVA: 0x00AB24FF File Offset: 0x00AB06FF
		// (set) Token: 0x0602CE2B RID: 183851 RVA: 0x00AB250F File Offset: 0x00AB070F
		public unsafe float 受击特效生成位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007986 RID: 31110
		// (get) Token: 0x0602CE2C RID: 183852 RVA: 0x00AB2520 File Offset: 0x00AB0720
		// (set) Token: 0x0602CE2D RID: 183853 RVA: 0x00AB2563 File Offset: 0x00AB0763
		public TArray<SBulletTailEffect> 子弹拖尾特效
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBulletTailEffect> result;
				if ((result = this._子弹拖尾特效) == null)
				{
					result = (this._子弹拖尾特效 = new TArray<SBulletTailEffect>(base.NativePtr + (IntPtr)SBulletDataEffect.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.子弹拖尾特效.CopyAssign(value);
			}
		}

		// Token: 0x0602CE2E RID: 183854 RVA: 0x00AB2571 File Offset: 0x00AB0771
		public SBulletDataEffect()
		{
		}

		// Token: 0x0602CE2F RID: 183855 RVA: 0x00AB2579 File Offset: 0x00AB0779
		public SBulletDataEffect(TSoftClassPtr<UMatineeCameraShake> 受击震屏, int 最大震动次数, float 受击特效生成位置偏移, TArray<SBulletTailEffect> 子弹拖尾特效)
		{
			this.受击震屏 = 受击震屏;
			this.最大震动次数 = 最大震动次数;
			this.受击特效生成位置偏移 = 受击特效生成位置偏移;
			this.子弹拖尾特效 = 子弹拖尾特效;
		}

		// Token: 0x0602CE30 RID: 183856 RVA: 0x00AB259E File Offset: 0x00AB079E
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataEffect.StaticStruct();
		}

		// Token: 0x0602CE31 RID: 183857 RVA: 0x00AB25AA File Offset: 0x00AB07AA
		[NullableContext(2)]
		public SBulletDataEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE32 RID: 183858 RVA: 0x00AB25B4 File Offset: 0x00AB07B4
		public SBulletDataEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE33 RID: 183859 RVA: 0x00AB25BF File Offset: 0x00AB07BF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataEffect(Pointer, false, true);
		}

		// Token: 0x0602CE34 RID: 183860 RVA: 0x00AB25C9 File Offset: 0x00AB07C9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataEffect(Pointer, MemoryOwner);
		}

		// Token: 0x040192E6 RID: 103142
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataEffect.SBulletDataEffect";

		// Token: 0x040192E7 RID: 103143
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192E8 RID: 103144
		internal static int __PropertyOffset_0;

		// Token: 0x040192E9 RID: 103145
		internal static int __PropertyOffset_1;

		// Token: 0x040192EA RID: 103146
		internal static int __PropertyOffset_2;

		// Token: 0x040192EB RID: 103147
		internal static int __PropertyOffset_3;

		// Token: 0x040192EC RID: 103148
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBulletTailEffect> _子弹拖尾特效;
	}
}
