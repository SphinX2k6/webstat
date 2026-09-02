using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C8B RID: 15499
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/SKuroInteractionLimbsConfig.SKuroInteractionLimbsConfig")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SKuroInteractionLimbsConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060241BD RID: 147901 RVA: 0x00995019 File Offset: 0x00993219
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SKuroInteractionLimbsConfig._ScriptStructPtr != 0) ? SKuroInteractionLimbsConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Interaction/SKuroInteractionLimbsConfig.SKuroInteractionLimbsConfig", ref SKuroInteractionLimbsConfig._ScriptStructPtr);
		}

		// Token: 0x17004A0D RID: 18957
		// (get) Token: 0x060241BE RID: 147902 RVA: 0x0099503D File Offset: 0x0099323D
		// (set) Token: 0x060241BF RID: 147903 RVA: 0x00995051 File Offset: 0x00993251
		public unsafe FName 插槽名字
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004A0E RID: 18958
		// (get) Token: 0x060241C0 RID: 147904 RVA: 0x00995066 File Offset: 0x00993266
		// (set) Token: 0x060241C1 RID: 147905 RVA: 0x0099507A File Offset: 0x0099327A
		public unsafe FVector 相对位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004A0F RID: 18959
		// (get) Token: 0x060241C2 RID: 147906 RVA: 0x0099508F File Offset: 0x0099328F
		// (set) Token: 0x060241C3 RID: 147907 RVA: 0x0099509F File Offset: 0x0099329F
		public unsafe float 半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004A10 RID: 18960
		// (get) Token: 0x060241C4 RID: 147908 RVA: 0x009950B0 File Offset: 0x009932B0
		// (set) Token: 0x060241C5 RID: 147909 RVA: 0x009950C0 File Offset: 0x009932C0
		public unsafe float 半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004A11 RID: 18961
		// (get) Token: 0x060241C6 RID: 147910 RVA: 0x009950D4 File Offset: 0x009932D4
		// (set) Token: 0x060241C7 RID: 147911 RVA: 0x00995117 File Offset: 0x00993317
		public FSoftObjectPath 交互配置
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._交互配置) == null)
				{
					result = (this._交互配置 = new FSoftObjectPath(base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SKuroInteractionLimbsConfig.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060241C8 RID: 147912 RVA: 0x00995138 File Offset: 0x00993338
		public SKuroInteractionLimbsConfig()
		{
		}

		// Token: 0x060241C9 RID: 147913 RVA: 0x00995140 File Offset: 0x00993340
		public SKuroInteractionLimbsConfig(FName 插槽名字, FVector 相对位置, float 半径, float 半高, FSoftObjectPath 交互配置)
		{
			this.插槽名字 = 插槽名字;
			this.相对位置 = 相对位置;
			this.半径 = 半径;
			this.半高 = 半高;
			this.交互配置 = 交互配置;
		}

		// Token: 0x060241CA RID: 147914 RVA: 0x0099516D File Offset: 0x0099336D
		protected override IntPtr GetUStructPtr()
		{
			return SKuroInteractionLimbsConfig.StaticStruct();
		}

		// Token: 0x060241CB RID: 147915 RVA: 0x00995179 File Offset: 0x00993379
		[NullableContext(2)]
		public SKuroInteractionLimbsConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060241CC RID: 147916 RVA: 0x00995183 File Offset: 0x00993383
		public SKuroInteractionLimbsConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060241CD RID: 147917 RVA: 0x0099518E File Offset: 0x0099338E
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SKuroInteractionLimbsConfig(Pointer, false, true);
		}

		// Token: 0x060241CE RID: 147918 RVA: 0x00995198 File Offset: 0x00993398
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SKuroInteractionLimbsConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401276D RID: 75629
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/SKuroInteractionLimbsConfig.SKuroInteractionLimbsConfig";

		// Token: 0x0401276E RID: 75630
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401276F RID: 75631
		internal static int __PropertyOffset_0;

		// Token: 0x04012770 RID: 75632
		internal static int __PropertyOffset_1;

		// Token: 0x04012771 RID: 75633
		internal static int __PropertyOffset_2;

		// Token: 0x04012772 RID: 75634
		internal static int __PropertyOffset_3;

		// Token: 0x04012773 RID: 75635
		internal static int __PropertyOffset_4;

		// Token: 0x04012774 RID: 75636
		[Nullable(2)]
		private FSoftObjectPath _交互配置;
	}
}
