using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004251 RID: 16977
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCounterAttackCamera.SCounterAttackCamera")]
	[UnrealStructLayout(408, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 408)]
	public class SCounterAttackCamera : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CF6E RID: 184174 RVA: 0x00AB44FC File Offset: 0x00AB26FC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCounterAttackCamera._ScriptStructPtr != 0) ? SCounterAttackCamera._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCounterAttackCamera.SCounterAttackCamera", ref SCounterAttackCamera._ScriptStructPtr);
		}

		// Token: 0x170079E9 RID: 31209
		// (get) Token: 0x0602CF6F RID: 184175 RVA: 0x00AB4520 File Offset: 0x00AB2720
		// (set) Token: 0x0602CF70 RID: 184176 RVA: 0x00AB4534 File Offset: 0x00AB2734
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170079EA RID: 31210
		// (get) Token: 0x0602CF71 RID: 184177 RVA: 0x00AB4549 File Offset: 0x00AB2749
		// (set) Token: 0x0602CF72 RID: 184178 RVA: 0x00AB4559 File Offset: 0x00AB2759
		public unsafe float 持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170079EB RID: 31211
		// (get) Token: 0x0602CF73 RID: 184179 RVA: 0x00AB456A File Offset: 0x00AB276A
		// (set) Token: 0x0602CF74 RID: 184180 RVA: 0x00AB457A File Offset: 0x00AB277A
		public unsafe float 淡入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170079EC RID: 31212
		// (get) Token: 0x0602CF75 RID: 184181 RVA: 0x00AB458B File Offset: 0x00AB278B
		// (set) Token: 0x0602CF76 RID: 184182 RVA: 0x00AB459B File Offset: 0x00AB279B
		public unsafe float 淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170079ED RID: 31213
		// (get) Token: 0x0602CF77 RID: 184183 RVA: 0x00AB45AC File Offset: 0x00AB27AC
		// (set) Token: 0x0602CF78 RID: 184184 RVA: 0x00AB45BC File Offset: 0x00AB27BC
		public unsafe float 打断淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170079EE RID: 31214
		// (get) Token: 0x0602CF79 RID: 184185 RVA: 0x00AB45CD File Offset: 0x00AB27CD
		// (set) Token: 0x0602CF7A RID: 184186 RVA: 0x00AB45E1 File Offset: 0x00AB27E1
		public unsafe string CameraAttachSocket
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCounterAttackCamera.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCounterAttackCamera.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x170079EF RID: 31215
		// (get) Token: 0x0602CF7B RID: 184187 RVA: 0x00AB45F8 File Offset: 0x00AB27F8
		// (set) Token: 0x0602CF7C RID: 184188 RVA: 0x00AB463B File Offset: 0x00AB283B
		public SCameraModifier_Settings 摄像机配置
		{
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._摄像机配置) == null)
				{
					result = (this._摄像机配置 = new SCameraModifier_Settings(base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttackCamera.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CF7D RID: 184189 RVA: 0x00AB465C File Offset: 0x00AB285C
		public SCounterAttackCamera()
		{
		}

		// Token: 0x0602CF7E RID: 184190 RVA: 0x00AB4664 File Offset: 0x00AB2864
		public SCounterAttackCamera(FGameplayTag Tag, float 持续时间, float 淡入时间, float 淡出时间, float 打断淡出时间, string CameraAttachSocket, SCameraModifier_Settings 摄像机配置)
		{
			this.Tag = Tag;
			this.持续时间 = 持续时间;
			this.淡入时间 = 淡入时间;
			this.淡出时间 = 淡出时间;
			this.打断淡出时间 = 打断淡出时间;
			this.CameraAttachSocket = CameraAttachSocket;
			this.摄像机配置 = 摄像机配置;
		}

		// Token: 0x0602CF7F RID: 184191 RVA: 0x00AB46A1 File Offset: 0x00AB28A1
		protected override IntPtr GetUStructPtr()
		{
			return SCounterAttackCamera.StaticStruct();
		}

		// Token: 0x0602CF80 RID: 184192 RVA: 0x00AB46AD File Offset: 0x00AB28AD
		[NullableContext(2)]
		public SCounterAttackCamera(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CF81 RID: 184193 RVA: 0x00AB46B7 File Offset: 0x00AB28B7
		public SCounterAttackCamera(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CF82 RID: 184194 RVA: 0x00AB46C2 File Offset: 0x00AB28C2
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCounterAttackCamera(Pointer, false, true);
		}

		// Token: 0x0602CF83 RID: 184195 RVA: 0x00AB46CC File Offset: 0x00AB28CC
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCounterAttackCamera(Pointer, MemoryOwner);
		}

		// Token: 0x04019393 RID: 103315
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCounterAttackCamera.SCounterAttackCamera";

		// Token: 0x04019394 RID: 103316
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019395 RID: 103317
		internal static int __PropertyOffset_0;

		// Token: 0x04019396 RID: 103318
		internal static int __PropertyOffset_1;

		// Token: 0x04019397 RID: 103319
		internal static int __PropertyOffset_2;

		// Token: 0x04019398 RID: 103320
		internal static int __PropertyOffset_3;

		// Token: 0x04019399 RID: 103321
		internal static int __PropertyOffset_4;

		// Token: 0x0401939A RID: 103322
		internal static int __PropertyOffset_5;

		// Token: 0x0401939B RID: 103323
		internal static int __PropertyOffset_6;

		// Token: 0x0401939C RID: 103324
		[Nullable(2)]
		private SCameraModifier_Settings _摄像机配置;
	}
}
