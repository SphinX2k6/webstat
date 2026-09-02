using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.GamePlay.Cipher
{
	// Token: 0x02003DDA RID: 15834
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/GamePlay/Cipher/SCipherGameplay.SCipherGameplay")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SCipherGameplay : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026D33 RID: 159027 RVA: 0x009E2CF3 File Offset: 0x009E0EF3
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCipherGameplay._ScriptStructPtr != 0) ? SCipherGameplay._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/Cipher/SCipherGameplay.SCipherGameplay", ref SCipherGameplay._ScriptStructPtr);
		}

		// Token: 0x17005960 RID: 22880
		// (get) Token: 0x06026D34 RID: 159028 RVA: 0x009E2D17 File Offset: 0x009E0F17
		// (set) Token: 0x06026D35 RID: 159029 RVA: 0x009E2D2B File Offset: 0x009E0F2B
		public unsafe FName ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005961 RID: 22881
		// (get) Token: 0x06026D36 RID: 159030 RVA: 0x009E2D40 File Offset: 0x009E0F40
		// (set) Token: 0x06026D37 RID: 159031 RVA: 0x009E2D54 File Offset: 0x009E0F54
		[Nullable(0)]
		public unsafe TEnumAsByte<ECipherGameplayType> 解密类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005962 RID: 22882
		// (get) Token: 0x06026D38 RID: 159032 RVA: 0x009E2D69 File Offset: 0x009E0F69
		// (set) Token: 0x06026D39 RID: 159033 RVA: 0x009E2D7D File Offset: 0x009E0F7D
		public unsafe string 正确密码
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCipherGameplay.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCipherGameplay.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17005963 RID: 22883
		// (get) Token: 0x06026D3A RID: 159034 RVA: 0x009E2D92 File Offset: 0x009E0F92
		// (set) Token: 0x06026D3B RID: 159035 RVA: 0x009E2DA6 File Offset: 0x009E0FA6
		public unsafe string 扰乱密码
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCipherGameplay.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCipherGameplay.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005964 RID: 22884
		// (get) Token: 0x06026D3C RID: 159036 RVA: 0x009E2DBB File Offset: 0x009E0FBB
		// (set) Token: 0x06026D3D RID: 159037 RVA: 0x009E2DCF File Offset: 0x009E0FCF
		public unsafe FName 解密成功交互ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005965 RID: 22885
		// (get) Token: 0x06026D3E RID: 159038 RVA: 0x009E2DE4 File Offset: 0x009E0FE4
		// (set) Token: 0x06026D3F RID: 159039 RVA: 0x009E2DF8 File Offset: 0x009E0FF8
		public unsafe FName 解密失败交互ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCipherGameplay.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005966 RID: 22886
		// (get) Token: 0x06026D40 RID: 159040 RVA: 0x009E2E0D File Offset: 0x009E100D
		// (set) Token: 0x06026D41 RID: 159041 RVA: 0x009E2E21 File Offset: 0x009E1021
		public unsafe string Tips
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCipherGameplay.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCipherGameplay.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x06026D42 RID: 159042 RVA: 0x009E2E36 File Offset: 0x009E1036
		public SCipherGameplay()
		{
		}

		// Token: 0x06026D43 RID: 159043 RVA: 0x009E2E3E File Offset: 0x009E103E
		public SCipherGameplay(FName ID, [Nullable(0)] TEnumAsByte<ECipherGameplayType> 解密类型, string 正确密码, string 扰乱密码, FName 解密成功交互ID, FName 解密失败交互ID, string Tips)
		{
			this.ID = ID;
			this.解密类型 = 解密类型;
			this.正确密码 = 正确密码;
			this.扰乱密码 = 扰乱密码;
			this.解密成功交互ID = 解密成功交互ID;
			this.解密失败交互ID = 解密失败交互ID;
			this.Tips = Tips;
		}

		// Token: 0x06026D44 RID: 159044 RVA: 0x009E2E7B File Offset: 0x009E107B
		protected override IntPtr GetUStructPtr()
		{
			return SCipherGameplay.StaticStruct();
		}

		// Token: 0x06026D45 RID: 159045 RVA: 0x009E2E87 File Offset: 0x009E1087
		[NullableContext(2)]
		public SCipherGameplay(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026D46 RID: 159046 RVA: 0x009E2E91 File Offset: 0x009E1091
		public SCipherGameplay(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026D47 RID: 159047 RVA: 0x009E2E9C File Offset: 0x009E109C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCipherGameplay(Pointer, false, true);
		}

		// Token: 0x06026D48 RID: 159048 RVA: 0x009E2EA6 File Offset: 0x009E10A6
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCipherGameplay(Pointer, MemoryOwner);
		}

		// Token: 0x04014401 RID: 82945
		public const string __ObjectPath = "/Game/Aki/GamePlay/Cipher/SCipherGameplay.SCipherGameplay";

		// Token: 0x04014402 RID: 82946
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014403 RID: 82947
		internal static int __PropertyOffset_0;

		// Token: 0x04014404 RID: 82948
		internal static int __PropertyOffset_1;

		// Token: 0x04014405 RID: 82949
		internal static int __PropertyOffset_2;

		// Token: 0x04014406 RID: 82950
		internal static int __PropertyOffset_3;

		// Token: 0x04014407 RID: 82951
		internal static int __PropertyOffset_4;

		// Token: 0x04014408 RID: 82952
		internal static int __PropertyOffset_5;

		// Token: 0x04014409 RID: 82953
		internal static int __PropertyOffset_6;
	}
}
