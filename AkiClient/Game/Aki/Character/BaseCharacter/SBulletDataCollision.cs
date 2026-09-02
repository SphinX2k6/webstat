using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004240 RID: 16960
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataCollision.SBulletDataCollision")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 14)]
	public class SBulletDataCollision : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE17 RID: 183831 RVA: 0x00AB238E File Offset: 0x00AB058E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataCollision._ScriptStructPtr != 0) ? SBulletDataCollision._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataCollision.SBulletDataCollision", ref SBulletDataCollision._ScriptStructPtr);
		}

		// Token: 0x17007980 RID: 31104
		// (get) Token: 0x0602CE18 RID: 183832 RVA: 0x00AB23B2 File Offset: 0x00AB05B2
		// (set) Token: 0x0602CE19 RID: 183833 RVA: 0x00AB23C6 File Offset: 0x00AB05C6
		public unsafe FName 子弹碰撞预设
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataCollision.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataCollision.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007981 RID: 31105
		// (get) Token: 0x0602CE1A RID: 183834 RVA: 0x00AB23DB File Offset: 0x00AB05DB
		// (set) Token: 0x0602CE1B RID: 183835 RVA: 0x00AB23EB File Offset: 0x00AB05EB
		public unsafe bool 子弹碰撞障碍销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataCollision.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataCollision.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007982 RID: 31106
		// (get) Token: 0x0602CE1C RID: 183836 RVA: 0x00AB23FC File Offset: 0x00AB05FC
		// (set) Token: 0x0602CE1D RID: 183837 RVA: 0x00AB240C File Offset: 0x00AB060C
		public unsafe bool 子弹碰撞单位销毁
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataCollision.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataCollision.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CE1E RID: 183838 RVA: 0x00AB241D File Offset: 0x00AB061D
		public SBulletDataCollision()
		{
		}

		// Token: 0x0602CE1F RID: 183839 RVA: 0x00AB2425 File Offset: 0x00AB0625
		public SBulletDataCollision(FName 子弹碰撞预设, bool 子弹碰撞障碍销毁, bool 子弹碰撞单位销毁)
		{
			this.子弹碰撞预设 = 子弹碰撞预设;
			this.子弹碰撞障碍销毁 = 子弹碰撞障碍销毁;
			this.子弹碰撞单位销毁 = 子弹碰撞单位销毁;
		}

		// Token: 0x0602CE20 RID: 183840 RVA: 0x00AB2442 File Offset: 0x00AB0642
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataCollision.StaticStruct();
		}

		// Token: 0x0602CE21 RID: 183841 RVA: 0x00AB244E File Offset: 0x00AB064E
		[NullableContext(2)]
		public SBulletDataCollision(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE22 RID: 183842 RVA: 0x00AB2458 File Offset: 0x00AB0658
		public SBulletDataCollision(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE23 RID: 183843 RVA: 0x00AB2463 File Offset: 0x00AB0663
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataCollision(Pointer, false, true);
		}

		// Token: 0x0602CE24 RID: 183844 RVA: 0x00AB246D File Offset: 0x00AB066D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataCollision(Pointer, MemoryOwner);
		}

		// Token: 0x040192E1 RID: 103137
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataCollision.SBulletDataCollision";

		// Token: 0x040192E2 RID: 103138
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192E3 RID: 103139
		internal static int __PropertyOffset_0;

		// Token: 0x040192E4 RID: 103140
		internal static int __PropertyOffset_1;

		// Token: 0x040192E5 RID: 103141
		internal static int __PropertyOffset_2;
	}
}
