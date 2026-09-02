using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200431A RID: 17178
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SFreeCamera.SFreeCamera")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 120)]
	public class SFreeCamera : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D8FD RID: 186621 RVA: 0x00AC37D4 File Offset: 0x00AC19D4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFreeCamera._ScriptStructPtr != 0) ? SFreeCamera._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SFreeCamera.SFreeCamera", ref SFreeCamera._ScriptStructPtr);
		}

		// Token: 0x17007CCC RID: 31948
		// (get) Token: 0x0602D8FE RID: 186622 RVA: 0x00AC37F8 File Offset: 0x00AC19F8
		// (set) Token: 0x0602D8FF RID: 186623 RVA: 0x00AC3808 File Offset: 0x00AC1A08
		public unsafe bool PC生效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CCD RID: 31949
		// (get) Token: 0x0602D900 RID: 186624 RVA: 0x00AC3819 File Offset: 0x00AC1A19
		// (set) Token: 0x0602D901 RID: 186625 RVA: 0x00AC3829 File Offset: 0x00AC1A29
		public unsafe bool 手机生效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007CCE RID: 31950
		// (get) Token: 0x0602D902 RID: 186626 RVA: 0x00AC383A File Offset: 0x00AC1A3A
		// (set) Token: 0x0602D903 RID: 186627 RVA: 0x00AC384E File Offset: 0x00AC1A4E
		public unsafe FVector 初始位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007CCF RID: 31951
		// (get) Token: 0x0602D904 RID: 186628 RVA: 0x00AC3863 File Offset: 0x00AC1A63
		// (set) Token: 0x0602D905 RID: 186629 RVA: 0x00AC3877 File Offset: 0x00AC1A77
		public unsafe FRotator 初始旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007CD0 RID: 31952
		// (get) Token: 0x0602D906 RID: 186630 RVA: 0x00AC388C File Offset: 0x00AC1A8C
		// (set) Token: 0x0602D907 RID: 186631 RVA: 0x00AC389C File Offset: 0x00AC1A9C
		public unsafe float 初始FOV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007CD1 RID: 31953
		// (get) Token: 0x0602D908 RID: 186632 RVA: 0x00AC38AD File Offset: 0x00AC1AAD
		// (set) Token: 0x0602D909 RID: 186633 RVA: 0x00AC38C1 File Offset: 0x00AC1AC1
		public unsafe TEnumAsByte<EFreeCameraInputMode> 初始输入模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007CD2 RID: 31954
		// (get) Token: 0x0602D90A RID: 186634 RVA: 0x00AC38D6 File Offset: 0x00AC1AD6
		// (set) Token: 0x0602D90B RID: 186635 RVA: 0x00AC38EA File Offset: 0x00AC1AEA
		public unsafe SFreeCameraDragInput 拖动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007CD3 RID: 31955
		// (get) Token: 0x0602D90C RID: 186636 RVA: 0x00AC3900 File Offset: 0x00AC1B00
		// (set) Token: 0x0602D90D RID: 186637 RVA: 0x00AC3943 File Offset: 0x00AC1B43
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EFreeCameraLimit>, float> 限制
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EFreeCameraLimit>, float> result;
				if ((result = this._限制) == null)
				{
					result = (this._限制 = new TMap<TEnumAsByte<EFreeCameraLimit>, float>(base.NativePtr + (IntPtr)SFreeCamera.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.限制.CopyAssign(value);
			}
		}

		// Token: 0x0602D90E RID: 186638 RVA: 0x00AC3951 File Offset: 0x00AC1B51
		public SFreeCamera()
		{
		}

		// Token: 0x0602D90F RID: 186639 RVA: 0x00AC395C File Offset: 0x00AC1B5C
		public SFreeCamera(bool PC生效, bool 手机生效, FVector 初始位置, FRotator 初始旋转, float 初始FOV, TEnumAsByte<EFreeCameraInputMode> 初始输入模式, SFreeCameraDragInput 拖动输入, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EFreeCameraLimit>, float> 限制)
		{
			this.PC生效 = PC生效;
			this.手机生效 = 手机生效;
			this.初始位置 = 初始位置;
			this.初始旋转 = 初始旋转;
			this.初始FOV = 初始FOV;
			this.初始输入模式 = 初始输入模式;
			this.拖动输入 = 拖动输入;
			this.限制 = 限制;
		}

		// Token: 0x0602D910 RID: 186640 RVA: 0x00AC39AC File Offset: 0x00AC1BAC
		protected override IntPtr GetUStructPtr()
		{
			return SFreeCamera.StaticStruct();
		}

		// Token: 0x0602D911 RID: 186641 RVA: 0x00AC39B8 File Offset: 0x00AC1BB8
		[NullableContext(2)]
		public SFreeCamera(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D912 RID: 186642 RVA: 0x00AC39C2 File Offset: 0x00AC1BC2
		public SFreeCamera(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D913 RID: 186643 RVA: 0x00AC39CD File Offset: 0x00AC1BCD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFreeCamera(Pointer, false, true);
		}

		// Token: 0x0602D914 RID: 186644 RVA: 0x00AC39D7 File Offset: 0x00AC1BD7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFreeCamera(Pointer, MemoryOwner);
		}

		// Token: 0x04019B01 RID: 105217
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SFreeCamera.SFreeCamera";

		// Token: 0x04019B02 RID: 105218
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B03 RID: 105219
		internal static int __PropertyOffset_0;

		// Token: 0x04019B04 RID: 105220
		internal static int __PropertyOffset_1;

		// Token: 0x04019B05 RID: 105221
		internal static int __PropertyOffset_2;

		// Token: 0x04019B06 RID: 105222
		internal static int __PropertyOffset_3;

		// Token: 0x04019B07 RID: 105223
		internal static int __PropertyOffset_4;

		// Token: 0x04019B08 RID: 105224
		internal static int __PropertyOffset_5;

		// Token: 0x04019B09 RID: 105225
		internal static int __PropertyOffset_6;

		// Token: 0x04019B0A RID: 105226
		internal static int __PropertyOffset_7;

		// Token: 0x04019B0B RID: 105227
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EFreeCameraLimit>, float> _限制;
	}
}
