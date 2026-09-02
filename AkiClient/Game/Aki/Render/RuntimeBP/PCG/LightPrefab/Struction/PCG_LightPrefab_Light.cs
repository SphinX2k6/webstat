using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BDE RID: 15326
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Light.PCG_LightPrefab_Light")]
	[UnrealStructLayout(688, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 688)]
	public class PCG_LightPrefab_Light : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022669 RID: 140905 RVA: 0x00964883 File Offset: 0x00962A83
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PCG_LightPrefab_Light._ScriptStructPtr != 0) ? PCG_LightPrefab_Light._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Light.PCG_LightPrefab_Light", ref PCG_LightPrefab_Light._ScriptStructPtr);
		}

		// Token: 0x1700408D RID: 16525
		// (get) Token: 0x0602266A RID: 140906 RVA: 0x009648A8 File Offset: 0x00962AA8
		// (set) Token: 0x0602266B RID: 140907 RVA: 0x009648EB File Offset: 0x00962AEB
		public FKuroCurveFloat 灯光强度
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._灯光强度) == null)
				{
					result = (this._灯光强度 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PCG_LightPrefab_Light.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Light.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700408E RID: 16526
		// (get) Token: 0x0602266C RID: 140908 RVA: 0x0096490C File Offset: 0x00962B0C
		// (set) Token: 0x0602266D RID: 140909 RVA: 0x0096494F File Offset: 0x00962B4F
		public FKuroCurveLinearColor 灯光颜色
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._灯光颜色) == null)
				{
					result = (this._灯光颜色 = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PCG_LightPrefab_Light.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Light.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602266E RID: 140910 RVA: 0x00964970 File Offset: 0x00962B70
		public PCG_LightPrefab_Light()
		{
		}

		// Token: 0x0602266F RID: 140911 RVA: 0x00964978 File Offset: 0x00962B78
		public PCG_LightPrefab_Light(FKuroCurveFloat 灯光强度, FKuroCurveLinearColor 灯光颜色)
		{
			this.灯光强度 = 灯光强度;
			this.灯光颜色 = 灯光颜色;
		}

		// Token: 0x06022670 RID: 140912 RVA: 0x0096498E File Offset: 0x00962B8E
		protected override IntPtr GetUStructPtr()
		{
			return PCG_LightPrefab_Light.StaticStruct();
		}

		// Token: 0x06022671 RID: 140913 RVA: 0x0096499A File Offset: 0x00962B9A
		[NullableContext(2)]
		public PCG_LightPrefab_Light(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022672 RID: 140914 RVA: 0x009649A4 File Offset: 0x00962BA4
		public PCG_LightPrefab_Light(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022673 RID: 140915 RVA: 0x009649AF File Offset: 0x00962BAF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PCG_LightPrefab_Light(Pointer, false, true);
		}

		// Token: 0x06022674 RID: 140916 RVA: 0x009649B9 File Offset: 0x00962BB9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PCG_LightPrefab_Light(Pointer, MemoryOwner);
		}

		// Token: 0x0401169A RID: 71322
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Light.PCG_LightPrefab_Light";

		// Token: 0x0401169B RID: 71323
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401169C RID: 71324
		internal static int __PropertyOffset_0;

		// Token: 0x0401169D RID: 71325
		[Nullable(2)]
		private FKuroCurveFloat _灯光强度;

		// Token: 0x0401169E RID: 71326
		internal static int __PropertyOffset_1;

		// Token: 0x0401169F RID: 71327
		[Nullable(2)]
		private FKuroCurveLinearColor _灯光颜色;
	}
}
