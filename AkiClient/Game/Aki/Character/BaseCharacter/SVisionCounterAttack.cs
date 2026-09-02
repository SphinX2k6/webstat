using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004286 RID: 17030
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SVisionCounterAttack.SVisionCounterAttack")]
	[UnrealStructLayout(552, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 552)]
	public class SVisionCounterAttack : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D3D6 RID: 185302 RVA: 0x00ABAD30 File Offset: 0x00AB8F30
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SVisionCounterAttack._ScriptStructPtr != 0) ? SVisionCounterAttack._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SVisionCounterAttack.SVisionCounterAttack", ref SVisionCounterAttack._ScriptStructPtr);
		}

		// Token: 0x17007B4D RID: 31565
		// (get) Token: 0x0602D3D7 RID: 185303 RVA: 0x00ABAD54 File Offset: 0x00AB8F54
		// (set) Token: 0x0602D3D8 RID: 185304 RVA: 0x00ABAD97 File Offset: 0x00AB8F97
		public SCounterAttackEffect 对策动作效果
		{
			get
			{
				base.FastCheckIsValid();
				SCounterAttackEffect result;
				if ((result = this._对策动作效果) == null)
				{
					result = (this._对策动作效果 = new SCounterAttackEffect(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCounterAttackEffect.StaticStruct(), base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007B4E RID: 31566
		// (get) Token: 0x0602D3D9 RID: 185305 RVA: 0x00ABADB8 File Offset: 0x00AB8FB8
		// (set) Token: 0x0602D3DA RID: 185306 RVA: 0x00ABADC8 File Offset: 0x00AB8FC8
		public unsafe long 被对策者应用BuffID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B4F RID: 31567
		// (get) Token: 0x0602D3DB RID: 185307 RVA: 0x00ABADD9 File Offset: 0x00AB8FD9
		// (set) Token: 0x0602D3DC RID: 185308 RVA: 0x00ABADE9 File Offset: 0x00AB8FE9
		public unsafe long 攻击者应用BuffID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007B50 RID: 31568
		// (get) Token: 0x0602D3DD RID: 185309 RVA: 0x00ABADFA File Offset: 0x00AB8FFA
		// (set) Token: 0x0602D3DE RID: 185310 RVA: 0x00ABAE0A File Offset: 0x00AB900A
		public unsafe bool 广播对策事件
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B51 RID: 31569
		// (get) Token: 0x0602D3DF RID: 185311 RVA: 0x00ABAE1B File Offset: 0x00AB901B
		// (set) Token: 0x0602D3E0 RID: 185312 RVA: 0x00ABAE2B File Offset: 0x00AB902B
		public unsafe int 对策事件ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVisionCounterAttack.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602D3E1 RID: 185313 RVA: 0x00ABAE3C File Offset: 0x00AB903C
		public SVisionCounterAttack()
		{
		}

		// Token: 0x0602D3E2 RID: 185314 RVA: 0x00ABAE44 File Offset: 0x00AB9044
		public SVisionCounterAttack(SCounterAttackEffect 对策动作效果, long 被对策者应用BuffID, long 攻击者应用BuffID, bool 广播对策事件, int 对策事件ID)
		{
			this.对策动作效果 = 对策动作效果;
			this.被对策者应用BuffID = 被对策者应用BuffID;
			this.攻击者应用BuffID = 攻击者应用BuffID;
			this.广播对策事件 = 广播对策事件;
			this.对策事件ID = 对策事件ID;
		}

		// Token: 0x0602D3E3 RID: 185315 RVA: 0x00ABAE71 File Offset: 0x00AB9071
		protected override IntPtr GetUStructPtr()
		{
			return SVisionCounterAttack.StaticStruct();
		}

		// Token: 0x0602D3E4 RID: 185316 RVA: 0x00ABAE7D File Offset: 0x00AB907D
		[NullableContext(2)]
		public SVisionCounterAttack(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D3E5 RID: 185317 RVA: 0x00ABAE87 File Offset: 0x00AB9087
		public SVisionCounterAttack(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D3E6 RID: 185318 RVA: 0x00ABAE92 File Offset: 0x00AB9092
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SVisionCounterAttack(Pointer, false, true);
		}

		// Token: 0x0602D3E7 RID: 185319 RVA: 0x00ABAE9C File Offset: 0x00AB909C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SVisionCounterAttack(Pointer, MemoryOwner);
		}

		// Token: 0x040195C5 RID: 103877
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SVisionCounterAttack.SVisionCounterAttack";

		// Token: 0x040195C6 RID: 103878
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195C7 RID: 103879
		internal static int __PropertyOffset_0;

		// Token: 0x040195C8 RID: 103880
		[Nullable(2)]
		private SCounterAttackEffect _对策动作效果;

		// Token: 0x040195C9 RID: 103881
		internal static int __PropertyOffset_1;

		// Token: 0x040195CA RID: 103882
		internal static int __PropertyOffset_2;

		// Token: 0x040195CB RID: 103883
		internal static int __PropertyOffset_3;

		// Token: 0x040195CC RID: 103884
		internal static int __PropertyOffset_4;
	}
}
