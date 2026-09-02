using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004243 RID: 16963
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataMain.SBulletDataMain")]
	[UnrealStructLayout(704, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 704)]
	public class SBulletDataMain : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE47 RID: 183879 RVA: 0x00AB27E2 File Offset: 0x00AB09E2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataMain._ScriptStructPtr != 0) ? SBulletDataMain._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataMain.SBulletDataMain", ref SBulletDataMain._ScriptStructPtr);
		}

		// Token: 0x1700798C RID: 31116
		// (get) Token: 0x0602CE48 RID: 183880 RVA: 0x00AB2806 File Offset: 0x00AB0A06
		// (set) Token: 0x0602CE49 RID: 183881 RVA: 0x00AB281A File Offset: 0x00AB0A1A
		public unsafe FName 子弹名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700798D RID: 31117
		// (get) Token: 0x0602CE4A RID: 183882 RVA: 0x00AB2830 File Offset: 0x00AB0A30
		// (set) Token: 0x0602CE4B RID: 183883 RVA: 0x00AB2873 File Offset: 0x00AB0A73
		public SBulletDataBase 基础设置
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataBase result;
				if ((result = this._基础设置) == null)
				{
					result = (this._基础设置 = new SBulletDataBase(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataBase.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700798E RID: 31118
		// (get) Token: 0x0602CE4C RID: 183884 RVA: 0x00AB2894 File Offset: 0x00AB0A94
		// (set) Token: 0x0602CE4D RID: 183885 RVA: 0x00AB28D7 File Offset: 0x00AB0AD7
		public SBulletDataMove 移动设置
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataMove result;
				if ((result = this._移动设置) == null)
				{
					result = (this._移动设置 = new SBulletDataMove(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataMove.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700798F RID: 31119
		// (get) Token: 0x0602CE4E RID: 183886 RVA: 0x00AB28F8 File Offset: 0x00AB0AF8
		// (set) Token: 0x0602CE4F RID: 183887 RVA: 0x00AB293B File Offset: 0x00AB0B3B
		public SBulletDataEffect 效果设置
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataEffect result;
				if ((result = this._效果设置) == null)
				{
					result = (this._效果设置 = new SBulletDataEffect(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataEffect.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007990 RID: 31120
		// (get) Token: 0x0602CE50 RID: 183888 RVA: 0x00AB295C File Offset: 0x00AB0B5C
		// (set) Token: 0x0602CE51 RID: 183889 RVA: 0x00AB299F File Offset: 0x00AB0B9F
		public SBulletDataTime 时间膨胀
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataTime result;
				if ((result = this._时间膨胀) == null)
				{
					result = (this._时间膨胀 = new SBulletDataTime(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataTime.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007991 RID: 31121
		// (get) Token: 0x0602CE52 RID: 183890 RVA: 0x00AB29C0 File Offset: 0x00AB0BC0
		// (set) Token: 0x0602CE53 RID: 183891 RVA: 0x00AB2A03 File Offset: 0x00AB0C03
		public SBulletDataCollision 碰撞设置
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataCollision result;
				if ((result = this._碰撞设置) == null)
				{
					result = (this._碰撞设置 = new SBulletDataCollision(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataCollision.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007992 RID: 31122
		// (get) Token: 0x0602CE54 RID: 183892 RVA: 0x00AB2A24 File Offset: 0x00AB0C24
		// (set) Token: 0x0602CE55 RID: 183893 RVA: 0x00AB2A67 File Offset: 0x00AB0C67
		public SBulletDataExe 执行逻辑
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataExe result;
				if ((result = this._执行逻辑) == null)
				{
					result = (this._执行逻辑 = new SBulletDataExe(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataExe.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007993 RID: 31123
		// (get) Token: 0x0602CE56 RID: 183894 RVA: 0x00AB2A88 File Offset: 0x00AB0C88
		// (set) Token: 0x0602CE57 RID: 183895 RVA: 0x00AB2ACB File Offset: 0x00AB0CCB
		public SBulletDataScale 缩放设置
		{
			get
			{
				base.FastCheckIsValid();
				SBulletDataScale result;
				if ((result = this._缩放设置) == null)
				{
					result = (this._缩放设置 = new SBulletDataScale(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataScale.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007994 RID: 31124
		// (get) Token: 0x0602CE58 RID: 183896 RVA: 0x00AB2AEC File Offset: 0x00AB0CEC
		// (set) Token: 0x0602CE59 RID: 183897 RVA: 0x00AB2B2F File Offset: 0x00AB0D2F
		public TArray<SBulletDataChild> 子子弹
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBulletDataChild> result;
				if ((result = this._子子弹) == null)
				{
					result = (this._子子弹 = new TArray<SBulletDataChild>(base.NativePtr + (IntPtr)SBulletDataMain.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.子子弹.CopyAssign(value);
			}
		}

		// Token: 0x0602CE5A RID: 183898 RVA: 0x00AB2B3D File Offset: 0x00AB0D3D
		public SBulletDataMain()
		{
		}

		// Token: 0x0602CE5B RID: 183899 RVA: 0x00AB2B48 File Offset: 0x00AB0D48
		public SBulletDataMain(FName 子弹名称, SBulletDataBase 基础设置, SBulletDataMove 移动设置, SBulletDataEffect 效果设置, SBulletDataTime 时间膨胀, SBulletDataCollision 碰撞设置, SBulletDataExe 执行逻辑, SBulletDataScale 缩放设置, TArray<SBulletDataChild> 子子弹)
		{
			this.子弹名称 = 子弹名称;
			this.基础设置 = 基础设置;
			this.移动设置 = 移动设置;
			this.效果设置 = 效果设置;
			this.时间膨胀 = 时间膨胀;
			this.碰撞设置 = 碰撞设置;
			this.执行逻辑 = 执行逻辑;
			this.缩放设置 = 缩放设置;
			this.子子弹 = 子子弹;
		}

		// Token: 0x0602CE5C RID: 183900 RVA: 0x00AB2BA0 File Offset: 0x00AB0DA0
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataMain.StaticStruct();
		}

		// Token: 0x0602CE5D RID: 183901 RVA: 0x00AB2BAC File Offset: 0x00AB0DAC
		[NullableContext(2)]
		public SBulletDataMain(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE5E RID: 183902 RVA: 0x00AB2BB6 File Offset: 0x00AB0DB6
		public SBulletDataMain(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE5F RID: 183903 RVA: 0x00AB2BC1 File Offset: 0x00AB0DC1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataMain(Pointer, false, true);
		}

		// Token: 0x0602CE60 RID: 183904 RVA: 0x00AB2BCB File Offset: 0x00AB0DCB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataMain(Pointer, MemoryOwner);
		}

		// Token: 0x040192F7 RID: 103159
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataMain.SBulletDataMain";

		// Token: 0x040192F8 RID: 103160
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192F9 RID: 103161
		internal static int __PropertyOffset_0;

		// Token: 0x040192FA RID: 103162
		internal static int __PropertyOffset_1;

		// Token: 0x040192FB RID: 103163
		[Nullable(2)]
		private SBulletDataBase _基础设置;

		// Token: 0x040192FC RID: 103164
		internal static int __PropertyOffset_2;

		// Token: 0x040192FD RID: 103165
		[Nullable(2)]
		private SBulletDataMove _移动设置;

		// Token: 0x040192FE RID: 103166
		internal static int __PropertyOffset_3;

		// Token: 0x040192FF RID: 103167
		[Nullable(2)]
		private SBulletDataEffect _效果设置;

		// Token: 0x04019300 RID: 103168
		internal static int __PropertyOffset_4;

		// Token: 0x04019301 RID: 103169
		[Nullable(2)]
		private SBulletDataTime _时间膨胀;

		// Token: 0x04019302 RID: 103170
		internal static int __PropertyOffset_5;

		// Token: 0x04019303 RID: 103171
		[Nullable(2)]
		private SBulletDataCollision _碰撞设置;

		// Token: 0x04019304 RID: 103172
		internal static int __PropertyOffset_6;

		// Token: 0x04019305 RID: 103173
		[Nullable(2)]
		private SBulletDataExe _执行逻辑;

		// Token: 0x04019306 RID: 103174
		internal static int __PropertyOffset_7;

		// Token: 0x04019307 RID: 103175
		[Nullable(2)]
		private SBulletDataScale _缩放设置;

		// Token: 0x04019308 RID: 103176
		internal static int __PropertyOffset_8;

		// Token: 0x04019309 RID: 103177
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBulletDataChild> _子子弹;
	}
}
