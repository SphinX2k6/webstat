using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BE0 RID: 15328
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Property.PCG_LightPrefab_Property_C")]
	[UnrealStructLayout(3504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3504)]
	public class PCG_LightPrefab_Property_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022687 RID: 140935 RVA: 0x00964B83 File Offset: 0x00962D83
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PCG_LightPrefab_Property_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Property.PCG_LightPrefab_Property_C");
			}
			return PCG_LightPrefab_Property_C._ClassPtr;
		}

		// Token: 0x06022688 RID: 140936 RVA: 0x00964BA8 File Offset: 0x00962DA8
		public PCG_LightPrefab_Property_C() : this(BuiltinUtils.AllocNativeUObject(PCG_LightPrefab_Property_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022689 RID: 140937 RVA: 0x00964BD0 File Offset: 0x00962DD0
		public PCG_LightPrefab_Property_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PCG_LightPrefab_Property_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004094 RID: 16532
		// (get) Token: 0x0602268A RID: 140938 RVA: 0x00964C03 File Offset: 0x00962E03
		// (set) Token: 0x0602268B RID: 140939 RVA: 0x00964C13 File Offset: 0x00962E13
		public unsafe bool 工具同步
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004095 RID: 16533
		// (get) Token: 0x0602268C RID: 140940 RVA: 0x00964C24 File Offset: 0x00962E24
		// (set) Token: 0x0602268D RID: 140941 RVA: 0x00964C34 File Offset: 0x00962E34
		public unsafe bool TOD同步
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004096 RID: 16534
		// (get) Token: 0x0602268E RID: 140942 RVA: 0x00964C45 File Offset: 0x00962E45
		// (set) Token: 0x0602268F RID: 140943 RVA: 0x00964C55 File Offset: 0x00962E55
		public unsafe float TOD同步频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004097 RID: 16535
		// (get) Token: 0x06022690 RID: 140944 RVA: 0x00964C68 File Offset: 0x00962E68
		// (set) Token: 0x06022691 RID: 140945 RVA: 0x00964CA1 File Offset: 0x00962EA1
		public PCG_LightPrefab_Light 灯光
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Light result;
				if ((result = this._灯光) == null)
				{
					result = (this._灯光 = new PCG_LightPrefab_Light(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Light.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004098 RID: 16536
		// (get) Token: 0x06022692 RID: 140946 RVA: 0x00964CC4 File Offset: 0x00962EC4
		// (set) Token: 0x06022693 RID: 140947 RVA: 0x00964CFD File Offset: 0x00962EFD
		public PCG_LightPrefab_Mesh 模型
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Mesh result;
				if ((result = this._模型) == null)
				{
					result = (this._模型 = new PCG_LightPrefab_Mesh(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Mesh.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004099 RID: 16537
		// (get) Token: 0x06022694 RID: 140948 RVA: 0x00964D20 File Offset: 0x00962F20
		// (set) Token: 0x06022695 RID: 140949 RVA: 0x00964D59 File Offset: 0x00962F59
		public PCG_LightPrefab_Decal 贴花
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Decal result;
				if ((result = this._贴花) == null)
				{
					result = (this._贴花 = new PCG_LightPrefab_Decal(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Decal.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700409A RID: 16538
		// (get) Token: 0x06022696 RID: 140950 RVA: 0x00964D7C File Offset: 0x00962F7C
		// (set) Token: 0x06022697 RID: 140951 RVA: 0x00964DB5 File Offset: 0x00962FB5
		public PCG_LightPrefab_Fog 雾效
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Fog result;
				if ((result = this._雾效) == null)
				{
					result = (this._雾效 = new PCG_LightPrefab_Fog(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Fog.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700409B RID: 16539
		// (get) Token: 0x06022698 RID: 140952 RVA: 0x00964DD8 File Offset: 0x00962FD8
		// (set) Token: 0x06022699 RID: 140953 RVA: 0x00964E11 File Offset: 0x00963011
		public PCG_LightPrefab_Effect 特效
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Effect result;
				if ((result = this._特效) == null)
				{
					result = (this._特效 = new PCG_LightPrefab_Effect(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Effect.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700409C RID: 16540
		// (get) Token: 0x0602269A RID: 140954 RVA: 0x00964E34 File Offset: 0x00963034
		// (set) Token: 0x0602269B RID: 140955 RVA: 0x00964E6D File Offset: 0x0096306D
		public PCG_LightPrefab_Swing 摆动
		{
			get
			{
				base.FastCheckIsValid();
				PCG_LightPrefab_Swing result;
				if ((result = this._摆动) == null)
				{
					result = (this._摆动 = new PCG_LightPrefab_Swing(base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PCG_LightPrefab_Swing.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Property_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602269C RID: 140956 RVA: 0x00964E8E File Offset: 0x0096308E
		protected PCG_LightPrefab_Property_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040116A9 RID: 71337
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Property.PCG_LightPrefab_Property_C";

		// Token: 0x040116AA RID: 71338
		private static IntPtr _ClassPtr;

		// Token: 0x040116AB RID: 71339
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040116AC RID: 71340
		internal static int __PropertyOffset_0;

		// Token: 0x040116AD RID: 71341
		internal static int __PropertyOffset_1;

		// Token: 0x040116AE RID: 71342
		internal static int __PropertyOffset_2;

		// Token: 0x040116AF RID: 71343
		internal static int __PropertyOffset_3;

		// Token: 0x040116B0 RID: 71344
		[Nullable(2)]
		private PCG_LightPrefab_Light _灯光;

		// Token: 0x040116B1 RID: 71345
		internal static int __PropertyOffset_4;

		// Token: 0x040116B2 RID: 71346
		[Nullable(2)]
		private PCG_LightPrefab_Mesh _模型;

		// Token: 0x040116B3 RID: 71347
		internal static int __PropertyOffset_5;

		// Token: 0x040116B4 RID: 71348
		[Nullable(2)]
		private PCG_LightPrefab_Decal _贴花;

		// Token: 0x040116B5 RID: 71349
		internal static int __PropertyOffset_6;

		// Token: 0x040116B6 RID: 71350
		[Nullable(2)]
		private PCG_LightPrefab_Fog _雾效;

		// Token: 0x040116B7 RID: 71351
		internal static int __PropertyOffset_7;

		// Token: 0x040116B8 RID: 71352
		[Nullable(2)]
		private PCG_LightPrefab_Effect _特效;

		// Token: 0x040116B9 RID: 71353
		internal static int __PropertyOffset_8;

		// Token: 0x040116BA RID: 71354
		[Nullable(2)]
		private PCG_LightPrefab_Swing _摆动;
	}
}
