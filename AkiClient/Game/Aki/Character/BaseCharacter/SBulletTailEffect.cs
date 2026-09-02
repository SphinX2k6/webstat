using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004248 RID: 16968
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletTailEffect.SBulletTailEffect")]
	[UnrealStructLayout(64, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 52)]
	public class SBulletTailEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CEB9 RID: 183993 RVA: 0x00AB334E File Offset: 0x00AB154E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletTailEffect._ScriptStructPtr != 0) ? SBulletTailEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletTailEffect.SBulletTailEffect", ref SBulletTailEffect._ScriptStructPtr);
		}

		// Token: 0x170079B1 RID: 31153
		// (get) Token: 0x0602CEBA RID: 183994 RVA: 0x00AB3372 File Offset: 0x00AB1572
		// (set) Token: 0x0602CEBB RID: 183995 RVA: 0x00AB3386 File Offset: 0x00AB1586
		public unsafe FTransform 子弹拖尾特效位置相对偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletTailEffect.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletTailEffect.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170079B2 RID: 31154
		// (get) Token: 0x0602CEBC RID: 183996 RVA: 0x00AB339B File Offset: 0x00AB159B
		// (set) Token: 0x0602CEBD RID: 183997 RVA: 0x00AB33AB File Offset: 0x00AB15AB
		public unsafe float 子弹拖尾特效相对击中或发出时延迟销毁时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletTailEffect.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletTailEffect.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602CEBE RID: 183998 RVA: 0x00AB33BC File Offset: 0x00AB15BC
		public SBulletTailEffect()
		{
		}

		// Token: 0x0602CEBF RID: 183999 RVA: 0x00AB33C4 File Offset: 0x00AB15C4
		public SBulletTailEffect(FTransform 子弹拖尾特效位置相对偏移, float 子弹拖尾特效相对击中或发出时延迟销毁时间)
		{
			this.子弹拖尾特效位置相对偏移 = 子弹拖尾特效位置相对偏移;
			this.子弹拖尾特效相对击中或发出时延迟销毁时间 = 子弹拖尾特效相对击中或发出时延迟销毁时间;
		}

		// Token: 0x0602CEC0 RID: 184000 RVA: 0x00AB33DA File Offset: 0x00AB15DA
		protected override IntPtr GetUStructPtr()
		{
			return SBulletTailEffect.StaticStruct();
		}

		// Token: 0x0602CEC1 RID: 184001 RVA: 0x00AB33E6 File Offset: 0x00AB15E6
		[NullableContext(2)]
		public SBulletTailEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CEC2 RID: 184002 RVA: 0x00AB33F0 File Offset: 0x00AB15F0
		public SBulletTailEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CEC3 RID: 184003 RVA: 0x00AB33FB File Offset: 0x00AB15FB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletTailEffect(Pointer, false, true);
		}

		// Token: 0x0602CEC4 RID: 184004 RVA: 0x00AB3405 File Offset: 0x00AB1605
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletTailEffect(Pointer, MemoryOwner);
		}

		// Token: 0x04019331 RID: 103217
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletTailEffect.SBulletTailEffect";

		// Token: 0x04019332 RID: 103218
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019333 RID: 103219
		internal static int __PropertyOffset_0;

		// Token: 0x04019334 RID: 103220
		internal static int __PropertyOffset_1;
	}
}
