using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.NPC.SimpleNpcFlow
{
	// Token: 0x02003E5D RID: 15965
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowComponent.SimpleNpcFlowComponent_C")]
	[UnrealStructLayout(248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 248)]
	public class SimpleNpcFlowComponent_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602766F RID: 161391 RVA: 0x009F1158 File Offset: 0x009EF358
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SimpleNpcFlowComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowComponent.SimpleNpcFlowComponent_C");
			}
			return SimpleNpcFlowComponent_C._ClassPtr;
		}

		// Token: 0x06027670 RID: 161392 RVA: 0x009F117C File Offset: 0x009EF37C
		public SimpleNpcFlowComponent_C() : this(BuiltinUtils.AllocNativeUObject(SimpleNpcFlowComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027671 RID: 161393 RVA: 0x009F11A4 File Offset: 0x009EF3A4
		public SimpleNpcFlowComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SimpleNpcFlowComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C94 RID: 23700
		// (get) Token: 0x06027672 RID: 161394 RVA: 0x009F11D8 File Offset: 0x009EF3D8
		// (set) Token: 0x06027673 RID: 161395 RVA: 0x009F1211 File Offset: 0x009EF411
		public TArray<TsSimpleNpc> NpcList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TsSimpleNpc> result;
				if ((result = this._NpcList) == null)
				{
					result = (this._NpcList = new TArray<TsSimpleNpc>(base.NativePtr + (IntPtr)SimpleNpcFlowComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.NpcList.CopyAssign(value);
			}
		}

		// Token: 0x17005C95 RID: 23701
		// (get) Token: 0x06027674 RID: 161396 RVA: 0x009F1220 File Offset: 0x009EF420
		// (set) Token: 0x06027675 RID: 161397 RVA: 0x009F1259 File Offset: 0x009EF459
		public TArray<SimpleNpcFlowData> FlowList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SimpleNpcFlowData> result;
				if ((result = this._FlowList) == null)
				{
					result = (this._FlowList = new TArray<SimpleNpcFlowData>(base.NativePtr + (IntPtr)SimpleNpcFlowComponent_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.FlowList.CopyAssign(value);
			}
		}

		// Token: 0x17005C96 RID: 23702
		// (get) Token: 0x06027676 RID: 161398 RVA: 0x009F1267 File Offset: 0x009EF467
		// (set) Token: 0x06027677 RID: 161399 RVA: 0x009F127B File Offset: 0x009EF47B
		public unsafe FFloatRange CheckRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleNpcFlowComponent_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SimpleNpcFlowComponent_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x06027678 RID: 161400 RVA: 0x009F1290 File Offset: 0x009EF490
		protected SimpleNpcFlowComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014A35 RID: 84533
		public new const string __ObjectPath = "/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowComponent.SimpleNpcFlowComponent_C";

		// Token: 0x04014A36 RID: 84534
		private static IntPtr _ClassPtr;

		// Token: 0x04014A37 RID: 84535
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014A38 RID: 84536
		internal static int __PropertyOffset_0;

		// Token: 0x04014A39 RID: 84537
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<TsSimpleNpc> _NpcList;

		// Token: 0x04014A3A RID: 84538
		internal static int __PropertyOffset_1;

		// Token: 0x04014A3B RID: 84539
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SimpleNpcFlowData> _FlowList;

		// Token: 0x04014A3C RID: 84540
		internal static int __PropertyOffset_2;
	}
}
