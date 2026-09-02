using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F25 RID: 16165
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionByTime.SAiRaceStrategyCorrectionByTime")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SAiRaceStrategyCorrectionByTime : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028581 RID: 165249 RVA: 0x00A082B2 File Offset: 0x00A064B2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiRaceStrategyCorrectionByTime._ScriptStructPtr != 0) ? SAiRaceStrategyCorrectionByTime._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionByTime.SAiRaceStrategyCorrectionByTime", ref SAiRaceStrategyCorrectionByTime._ScriptStructPtr);
		}

		// Token: 0x170061E7 RID: 25063
		// (get) Token: 0x06028582 RID: 165250 RVA: 0x00A082D6 File Offset: 0x00A064D6
		// (set) Token: 0x06028583 RID: 165251 RVA: 0x00A082E6 File Offset: 0x00A064E6
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionByTime.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionByTime.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061E8 RID: 25064
		// (get) Token: 0x06028584 RID: 165252 RVA: 0x00A082F8 File Offset: 0x00A064F8
		// (set) Token: 0x06028585 RID: 165253 RVA: 0x00A0833B File Offset: 0x00A0653B
		public TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByRunningTimeConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAiRaceStrategyOneParamFunction> result;
				if ((result = this._CalcTargetSpeedByRunningTimeConfig) == null)
				{
					result = (this._CalcTargetSpeedByRunningTimeConfig = new TArray<SAiRaceStrategyOneParamFunction>(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionByTime.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CalcTargetSpeedByRunningTimeConfig.CopyAssign(value);
			}
		}

		// Token: 0x06028586 RID: 165254 RVA: 0x00A08349 File Offset: 0x00A06549
		public SAiRaceStrategyCorrectionByTime()
		{
		}

		// Token: 0x06028587 RID: 165255 RVA: 0x00A08351 File Offset: 0x00A06551
		public SAiRaceStrategyCorrectionByTime(bool Enable, TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByRunningTimeConfig)
		{
			this.Enable = Enable;
			this.CalcTargetSpeedByRunningTimeConfig = CalcTargetSpeedByRunningTimeConfig;
		}

		// Token: 0x06028588 RID: 165256 RVA: 0x00A08367 File Offset: 0x00A06567
		protected override IntPtr GetUStructPtr()
		{
			return SAiRaceStrategyCorrectionByTime.StaticStruct();
		}

		// Token: 0x06028589 RID: 165257 RVA: 0x00A08373 File Offset: 0x00A06573
		[NullableContext(2)]
		public SAiRaceStrategyCorrectionByTime(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602858A RID: 165258 RVA: 0x00A0837D File Offset: 0x00A0657D
		public SAiRaceStrategyCorrectionByTime(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602858B RID: 165259 RVA: 0x00A08388 File Offset: 0x00A06588
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiRaceStrategyCorrectionByTime(Pointer, false, true);
		}

		// Token: 0x0602858C RID: 165260 RVA: 0x00A08392 File Offset: 0x00A06592
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiRaceStrategyCorrectionByTime(Pointer, MemoryOwner);
		}

		// Token: 0x04015388 RID: 86920
		public const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionByTime.SAiRaceStrategyCorrectionByTime";

		// Token: 0x04015389 RID: 86921
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401538A RID: 86922
		internal static int __PropertyOffset_0;

		// Token: 0x0401538B RID: 86923
		internal static int __PropertyOffset_1;

		// Token: 0x0401538C RID: 86924
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SAiRaceStrategyOneParamFunction> _CalcTargetSpeedByRunningTimeConfig;
	}
}
