using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BDD RID: 15325
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Fog.PCG_LightPrefab_Fog")]
	[UnrealStructLayout(544, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 544)]
	public class PCG_LightPrefab_Fog : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602265F RID: 140895 RVA: 0x009647AF File Offset: 0x009629AF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PCG_LightPrefab_Fog._ScriptStructPtr != 0) ? PCG_LightPrefab_Fog._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Fog.PCG_LightPrefab_Fog", ref PCG_LightPrefab_Fog._ScriptStructPtr);
		}

		// Token: 0x1700408C RID: 16524
		// (get) Token: 0x06022660 RID: 140896 RVA: 0x009647D4 File Offset: 0x009629D4
		// (set) Token: 0x06022661 RID: 140897 RVA: 0x00964817 File Offset: 0x00962A17
		public FKuroCurveLinearColor 雾效颜色
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._雾效颜色) == null)
				{
					result = (this._雾效颜色 = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PCG_LightPrefab_Fog.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Fog.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06022662 RID: 140898 RVA: 0x00964838 File Offset: 0x00962A38
		public PCG_LightPrefab_Fog()
		{
		}

		// Token: 0x06022663 RID: 140899 RVA: 0x00964840 File Offset: 0x00962A40
		public PCG_LightPrefab_Fog(FKuroCurveLinearColor 雾效颜色)
		{
			this.雾效颜色 = 雾效颜色;
		}

		// Token: 0x06022664 RID: 140900 RVA: 0x0096484F File Offset: 0x00962A4F
		protected override IntPtr GetUStructPtr()
		{
			return PCG_LightPrefab_Fog.StaticStruct();
		}

		// Token: 0x06022665 RID: 140901 RVA: 0x0096485B File Offset: 0x00962A5B
		[NullableContext(2)]
		public PCG_LightPrefab_Fog(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022666 RID: 140902 RVA: 0x00964865 File Offset: 0x00962A65
		public PCG_LightPrefab_Fog(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022667 RID: 140903 RVA: 0x00964870 File Offset: 0x00962A70
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PCG_LightPrefab_Fog(Pointer, false, true);
		}

		// Token: 0x06022668 RID: 140904 RVA: 0x0096487A File Offset: 0x00962A7A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PCG_LightPrefab_Fog(Pointer, MemoryOwner);
		}

		// Token: 0x04011696 RID: 71318
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Fog.PCG_LightPrefab_Fog";

		// Token: 0x04011697 RID: 71319
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011698 RID: 71320
		internal static int __PropertyOffset_0;

		// Token: 0x04011699 RID: 71321
		[Nullable(2)]
		private FKuroCurveLinearColor _雾效颜色;
	}
}
