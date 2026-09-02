using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x02004392 RID: 17298
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WandersData.KFCS_WandersData")]
	[UnrealStructLayout(112, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 112)]
	public class KFCS_WandersData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DDB8 RID: 187832 RVA: 0x00ACE5EE File Offset: 0x00ACC7EE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (KFCS_WandersData._ScriptStructPtr != 0) ? KFCS_WandersData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WandersData.KFCS_WandersData", ref KFCS_WandersData._ScriptStructPtr);
		}

		// Token: 0x17007DC3 RID: 32195
		// (get) Token: 0x0602DDB9 RID: 187833 RVA: 0x00ACE612 File Offset: 0x00ACC812
		// (set) Token: 0x0602DDBA RID: 187834 RVA: 0x00ACE626 File Offset: 0x00ACC826
		public unsafe KFCS_WanderDistance 距离设置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WandersData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WandersData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007DC4 RID: 32196
		// (get) Token: 0x0602DDBB RID: 187835 RVA: 0x00ACE63C File Offset: 0x00ACC83C
		// (set) Token: 0x0602DDBC RID: 187836 RVA: 0x00ACE67F File Offset: 0x00ACC87F
		public KFCS_WanderDirectionProbability 概率设置
		{
			get
			{
				base.FastCheckIsValid();
				KFCS_WanderDirectionProbability result;
				if ((result = this._概率设置) == null)
				{
					result = (this._概率设置 = new KFCS_WanderDirectionProbability(base.NativePtr + (IntPtr)KFCS_WandersData.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(KFCS_WanderDirectionProbability.StaticStruct(), base.NativePtr + (IntPtr)KFCS_WandersData.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DC5 RID: 32197
		// (get) Token: 0x0602DDBD RID: 187837 RVA: 0x00ACE6A0 File Offset: 0x00ACC8A0
		// (set) Token: 0x0602DDBE RID: 187838 RVA: 0x00ACE6B4 File Offset: 0x00ACC8B4
		public unsafe KFCS_DirectionData 转向速度设置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WandersData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WandersData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602DDBF RID: 187839 RVA: 0x00ACE6C9 File Offset: 0x00ACC8C9
		public KFCS_WandersData()
		{
		}

		// Token: 0x0602DDC0 RID: 187840 RVA: 0x00ACE6D1 File Offset: 0x00ACC8D1
		public KFCS_WandersData(KFCS_WanderDistance 距离设置, KFCS_WanderDirectionProbability 概率设置, KFCS_DirectionData 转向速度设置)
		{
			this.距离设置 = 距离设置;
			this.概率设置 = 概率设置;
			this.转向速度设置 = 转向速度设置;
		}

		// Token: 0x0602DDC1 RID: 187841 RVA: 0x00ACE6EE File Offset: 0x00ACC8EE
		protected override IntPtr GetUStructPtr()
		{
			return KFCS_WandersData.StaticStruct();
		}

		// Token: 0x0602DDC2 RID: 187842 RVA: 0x00ACE6FA File Offset: 0x00ACC8FA
		[NullableContext(2)]
		public KFCS_WandersData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DDC3 RID: 187843 RVA: 0x00ACE704 File Offset: 0x00ACC904
		public KFCS_WandersData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DDC4 RID: 187844 RVA: 0x00ACE70F File Offset: 0x00ACC90F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new KFCS_WandersData(Pointer, false, true);
		}

		// Token: 0x0602DDC5 RID: 187845 RVA: 0x00ACE719 File Offset: 0x00ACC919
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new KFCS_WandersData(Pointer, MemoryOwner);
		}

		// Token: 0x04019E91 RID: 106129
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WandersData.KFCS_WandersData";

		// Token: 0x04019E92 RID: 106130
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019E93 RID: 106131
		internal static int __PropertyOffset_0;

		// Token: 0x04019E94 RID: 106132
		internal static int __PropertyOffset_1;

		// Token: 0x04019E95 RID: 106133
		[Nullable(2)]
		private KFCS_WanderDirectionProbability _概率设置;

		// Token: 0x04019E96 RID: 106134
		internal static int __PropertyOffset_2;
	}
}
