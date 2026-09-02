using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BDC RID: 15324
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Effect.PCG_LightPrefab_Effect")]
	[UnrealStructLayout(544, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 544)]
	public class PCG_LightPrefab_Effect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022655 RID: 140885 RVA: 0x009646DB File Offset: 0x009628DB
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PCG_LightPrefab_Effect._ScriptStructPtr != 0) ? PCG_LightPrefab_Effect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Effect.PCG_LightPrefab_Effect", ref PCG_LightPrefab_Effect._ScriptStructPtr);
		}

		// Token: 0x1700408B RID: 16523
		// (get) Token: 0x06022656 RID: 140886 RVA: 0x00964700 File Offset: 0x00962900
		// (set) Token: 0x06022657 RID: 140887 RVA: 0x00964743 File Offset: 0x00962943
		public FKuroCurveLinearColor 特效颜色
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._特效颜色) == null)
				{
					result = (this._特效颜色 = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PCG_LightPrefab_Effect.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Effect.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06022658 RID: 140888 RVA: 0x00964764 File Offset: 0x00962964
		public PCG_LightPrefab_Effect()
		{
		}

		// Token: 0x06022659 RID: 140889 RVA: 0x0096476C File Offset: 0x0096296C
		public PCG_LightPrefab_Effect(FKuroCurveLinearColor 特效颜色)
		{
			this.特效颜色 = 特效颜色;
		}

		// Token: 0x0602265A RID: 140890 RVA: 0x0096477B File Offset: 0x0096297B
		protected override IntPtr GetUStructPtr()
		{
			return PCG_LightPrefab_Effect.StaticStruct();
		}

		// Token: 0x0602265B RID: 140891 RVA: 0x00964787 File Offset: 0x00962987
		[NullableContext(2)]
		public PCG_LightPrefab_Effect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602265C RID: 140892 RVA: 0x00964791 File Offset: 0x00962991
		public PCG_LightPrefab_Effect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602265D RID: 140893 RVA: 0x0096479C File Offset: 0x0096299C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PCG_LightPrefab_Effect(Pointer, false, true);
		}

		// Token: 0x0602265E RID: 140894 RVA: 0x009647A6 File Offset: 0x009629A6
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PCG_LightPrefab_Effect(Pointer, MemoryOwner);
		}

		// Token: 0x04011692 RID: 71314
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Effect.PCG_LightPrefab_Effect";

		// Token: 0x04011693 RID: 71315
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011694 RID: 71316
		internal static int __PropertyOffset_0;

		// Token: 0x04011695 RID: 71317
		[Nullable(2)]
		private FKuroCurveLinearColor _特效颜色;
	}
}
