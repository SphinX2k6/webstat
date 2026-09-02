using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiModel.Struct
{
	// Token: 0x02003DFB RID: 15867
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/UiModel/Struct/SUiModelRotateSetting.SUiModelRotateSetting")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 60)]
	public class SUiModelRotateSetting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060270A3 RID: 159907 RVA: 0x009E8928 File Offset: 0x009E6B28
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiModelRotateSetting._ScriptStructPtr != 0) ? SUiModelRotateSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiModel/Struct/SUiModelRotateSetting.SUiModelRotateSetting", ref SUiModelRotateSetting._ScriptStructPtr);
		}

		// Token: 0x17005AA9 RID: 23209
		// (get) Token: 0x060270A4 RID: 159908 RVA: 0x009E894C File Offset: 0x009E6B4C
		// (set) Token: 0x060270A5 RID: 159909 RVA: 0x009E8960 File Offset: 0x009E6B60
		public unsafe string 旋转中轴
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiModelRotateSetting.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiModelRotateSetting.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005AAA RID: 23210
		// (get) Token: 0x060270A6 RID: 159910 RVA: 0x009E8975 File Offset: 0x009E6B75
		// (set) Token: 0x060270A7 RID: 159911 RVA: 0x009E8985 File Offset: 0x009E6B85
		public unsafe float 旋转偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005AAB RID: 23211
		// (get) Token: 0x060270A8 RID: 159912 RVA: 0x009E8996 File Offset: 0x009E6B96
		// (set) Token: 0x060270A9 RID: 159913 RVA: 0x009E89A6 File Offset: 0x009E6BA6
		public unsafe float 模型Yaw灵敏度系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005AAC RID: 23212
		// (get) Token: 0x060270AA RID: 159914 RVA: 0x009E89B7 File Offset: 0x009E6BB7
		// (set) Token: 0x060270AB RID: 159915 RVA: 0x009E89C7 File Offset: 0x009E6BC7
		public unsafe float 模型Pitch灵敏度系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005AAD RID: 23213
		// (get) Token: 0x060270AC RID: 159916 RVA: 0x009E89D8 File Offset: 0x009E6BD8
		// (set) Token: 0x060270AD RID: 159917 RVA: 0x009E89E8 File Offset: 0x009E6BE8
		public unsafe float Yaw限制Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005AAE RID: 23214
		// (get) Token: 0x060270AE RID: 159918 RVA: 0x009E89F9 File Offset: 0x009E6BF9
		// (set) Token: 0x060270AF RID: 159919 RVA: 0x009E8A09 File Offset: 0x009E6C09
		public unsafe float Yaw限制Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005AAF RID: 23215
		// (get) Token: 0x060270B0 RID: 159920 RVA: 0x009E8A1A File Offset: 0x009E6C1A
		// (set) Token: 0x060270B1 RID: 159921 RVA: 0x009E8A2A File Offset: 0x009E6C2A
		public unsafe float Pitch限制Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005AB0 RID: 23216
		// (get) Token: 0x060270B2 RID: 159922 RVA: 0x009E8A3B File Offset: 0x009E6C3B
		// (set) Token: 0x060270B3 RID: 159923 RVA: 0x009E8A4B File Offset: 0x009E6C4B
		public unsafe float Pitch限制Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005AB1 RID: 23217
		// (get) Token: 0x060270B4 RID: 159924 RVA: 0x009E8A5C File Offset: 0x009E6C5C
		// (set) Token: 0x060270B5 RID: 159925 RVA: 0x009E8A6C File Offset: 0x009E6C6C
		public unsafe float 最小臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005AB2 RID: 23218
		// (get) Token: 0x060270B6 RID: 159926 RVA: 0x009E8A7D File Offset: 0x009E6C7D
		// (set) Token: 0x060270B7 RID: 159927 RVA: 0x009E8A8D File Offset: 0x009E6C8D
		public unsafe float 最大臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005AB3 RID: 23219
		// (get) Token: 0x060270B8 RID: 159928 RVA: 0x009E8A9E File Offset: 0x009E6C9E
		// (set) Token: 0x060270B9 RID: 159929 RVA: 0x009E8AAE File Offset: 0x009E6CAE
		public unsafe float 倍化手柄输入倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005AB4 RID: 23220
		// (get) Token: 0x060270BA RID: 159930 RVA: 0x009E8ABF File Offset: 0x009E6CBF
		// (set) Token: 0x060270BB RID: 159931 RVA: 0x009E8ACF File Offset: 0x009E6CCF
		public unsafe float 移动端旋转输入倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiModelRotateSetting.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x060270BC RID: 159932 RVA: 0x009E8AE0 File Offset: 0x009E6CE0
		public SUiModelRotateSetting()
		{
		}

		// Token: 0x060270BD RID: 159933 RVA: 0x009E8AE8 File Offset: 0x009E6CE8
		public SUiModelRotateSetting(string 旋转中轴, float 旋转偏移, float 模型Yaw灵敏度系数, float 模型Pitch灵敏度系数, float Yaw限制Min, float Yaw限制Max, float Pitch限制Min, float Pitch限制Max, float 最小臂长, float 最大臂长, float 倍化手柄输入倍率, float 移动端旋转输入倍率)
		{
			this.旋转中轴 = 旋转中轴;
			this.旋转偏移 = 旋转偏移;
			this.模型Yaw灵敏度系数 = 模型Yaw灵敏度系数;
			this.模型Pitch灵敏度系数 = 模型Pitch灵敏度系数;
			this.Yaw限制Min = Yaw限制Min;
			this.Yaw限制Max = Yaw限制Max;
			this.Pitch限制Min = Pitch限制Min;
			this.Pitch限制Max = Pitch限制Max;
			this.最小臂长 = 最小臂长;
			this.最大臂长 = 最大臂长;
			this.倍化手柄输入倍率 = 倍化手柄输入倍率;
			this.移动端旋转输入倍率 = 移动端旋转输入倍率;
		}

		// Token: 0x060270BE RID: 159934 RVA: 0x009E8B58 File Offset: 0x009E6D58
		protected override IntPtr GetUStructPtr()
		{
			return SUiModelRotateSetting.StaticStruct();
		}

		// Token: 0x060270BF RID: 159935 RVA: 0x009E8B64 File Offset: 0x009E6D64
		[NullableContext(2)]
		public SUiModelRotateSetting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060270C0 RID: 159936 RVA: 0x009E8B6E File Offset: 0x009E6D6E
		public SUiModelRotateSetting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060270C1 RID: 159937 RVA: 0x009E8B79 File Offset: 0x009E6D79
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiModelRotateSetting(Pointer, false, true);
		}

		// Token: 0x060270C2 RID: 159938 RVA: 0x009E8B83 File Offset: 0x009E6D83
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiModelRotateSetting(Pointer, MemoryOwner);
		}

		// Token: 0x0401464C RID: 83532
		public const string __ObjectPath = "/Game/Aki/Data/UiModel/Struct/SUiModelRotateSetting.SUiModelRotateSetting";

		// Token: 0x0401464D RID: 83533
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401464E RID: 83534
		internal static int __PropertyOffset_0;

		// Token: 0x0401464F RID: 83535
		internal static int __PropertyOffset_1;

		// Token: 0x04014650 RID: 83536
		internal static int __PropertyOffset_2;

		// Token: 0x04014651 RID: 83537
		internal static int __PropertyOffset_3;

		// Token: 0x04014652 RID: 83538
		internal static int __PropertyOffset_4;

		// Token: 0x04014653 RID: 83539
		internal static int __PropertyOffset_5;

		// Token: 0x04014654 RID: 83540
		internal static int __PropertyOffset_6;

		// Token: 0x04014655 RID: 83541
		internal static int __PropertyOffset_7;

		// Token: 0x04014656 RID: 83542
		internal static int __PropertyOffset_8;

		// Token: 0x04014657 RID: 83543
		internal static int __PropertyOffset_9;

		// Token: 0x04014658 RID: 83544
		internal static int __PropertyOffset_10;

		// Token: 0x04014659 RID: 83545
		internal static int __PropertyOffset_11;
	}
}
