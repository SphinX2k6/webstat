using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004282 RID: 17026
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/STimeScale.STimeScale")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class STimeScale : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D399 RID: 185241 RVA: 0x00ABA802 File Offset: 0x00AB8A02
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (STimeScale._ScriptStructPtr != 0) ? STimeScale._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/STimeScale.STimeScale", ref STimeScale._ScriptStructPtr);
		}

		// Token: 0x17007B3E RID: 31550
		// (get) Token: 0x0602D39A RID: 185242 RVA: 0x00ABA826 File Offset: 0x00AB8A26
		// (set) Token: 0x0602D39B RID: 185243 RVA: 0x00ABA83A File Offset: 0x00AB8A3A
		[Nullable(2)]
		public unsafe UCurveFloat 时间膨胀变化曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + STimeScale.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + STimeScale.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007B3F RID: 31551
		// (get) Token: 0x0602D39C RID: 185244 RVA: 0x00ABA84F File Offset: 0x00AB8A4F
		// (set) Token: 0x0602D39D RID: 185245 RVA: 0x00ABA85F File Offset: 0x00AB8A5F
		public unsafe float 时间膨胀时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STimeScale.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STimeScale.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B40 RID: 31552
		// (get) Token: 0x0602D39E RID: 185246 RVA: 0x00ABA870 File Offset: 0x00AB8A70
		// (set) Token: 0x0602D39F RID: 185247 RVA: 0x00ABA880 File Offset: 0x00AB8A80
		public unsafe float 时间膨胀值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STimeScale.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STimeScale.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007B41 RID: 31553
		// (get) Token: 0x0602D3A0 RID: 185248 RVA: 0x00ABA891 File Offset: 0x00AB8A91
		// (set) Token: 0x0602D3A1 RID: 185249 RVA: 0x00ABA8A1 File Offset: 0x00AB8AA1
		public unsafe int 优先级
		{
			get
			{
				return *(base.NativePtr + (IntPtr)STimeScale.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)STimeScale.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602D3A2 RID: 185250 RVA: 0x00ABA8B2 File Offset: 0x00AB8AB2
		public STimeScale()
		{
		}

		// Token: 0x0602D3A3 RID: 185251 RVA: 0x00ABA8BA File Offset: 0x00AB8ABA
		[NullableContext(1)]
		public STimeScale(UCurveFloat 时间膨胀变化曲线, float 时间膨胀时长, float 时间膨胀值, int 优先级)
		{
			this.时间膨胀变化曲线 = 时间膨胀变化曲线;
			this.时间膨胀时长 = 时间膨胀时长;
			this.时间膨胀值 = 时间膨胀值;
			this.优先级 = 优先级;
		}

		// Token: 0x0602D3A4 RID: 185252 RVA: 0x00ABA8DF File Offset: 0x00AB8ADF
		protected override IntPtr GetUStructPtr()
		{
			return STimeScale.StaticStruct();
		}

		// Token: 0x0602D3A5 RID: 185253 RVA: 0x00ABA8EB File Offset: 0x00AB8AEB
		[NullableContext(2)]
		public STimeScale(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D3A6 RID: 185254 RVA: 0x00ABA8F5 File Offset: 0x00AB8AF5
		public STimeScale(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D3A7 RID: 185255 RVA: 0x00ABA900 File Offset: 0x00AB8B00
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new STimeScale(Pointer, false, true);
		}

		// Token: 0x0602D3A8 RID: 185256 RVA: 0x00ABA90A File Offset: 0x00AB8B0A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new STimeScale(Pointer, MemoryOwner);
		}

		// Token: 0x040195A9 RID: 103849
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/STimeScale.STimeScale";

		// Token: 0x040195AA RID: 103850
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195AB RID: 103851
		internal static int __PropertyOffset_0;

		// Token: 0x040195AC RID: 103852
		internal static int __PropertyOffset_1;

		// Token: 0x040195AD RID: 103853
		internal static int __PropertyOffset_2;

		// Token: 0x040195AE RID: 103854
		internal static int __PropertyOffset_3;
	}
}
