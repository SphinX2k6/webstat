using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F23 RID: 16163
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionByDistance.SAiRaceStrategyCorrectionByDistance")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SAiRaceStrategyCorrectionByDistance : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028567 RID: 165223 RVA: 0x00A08084 File Offset: 0x00A06284
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiRaceStrategyCorrectionByDistance._ScriptStructPtr != 0) ? SAiRaceStrategyCorrectionByDistance._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionByDistance.SAiRaceStrategyCorrectionByDistance", ref SAiRaceStrategyCorrectionByDistance._ScriptStructPtr);
		}

		// Token: 0x170061E2 RID: 25058
		// (get) Token: 0x06028568 RID: 165224 RVA: 0x00A080A8 File Offset: 0x00A062A8
		// (set) Token: 0x06028569 RID: 165225 RVA: 0x00A080B8 File Offset: 0x00A062B8
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionByDistance.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionByDistance.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061E3 RID: 25059
		// (get) Token: 0x0602856A RID: 165226 RVA: 0x00A080CC File Offset: 0x00A062CC
		// (set) Token: 0x0602856B RID: 165227 RVA: 0x00A0810F File Offset: 0x00A0630F
		public TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByDistanceBetweenConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAiRaceStrategyOneParamFunction> result;
				if ((result = this._CalcTargetSpeedByDistanceBetweenConfig) == null)
				{
					result = (this._CalcTargetSpeedByDistanceBetweenConfig = new TArray<SAiRaceStrategyOneParamFunction>(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionByDistance.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CalcTargetSpeedByDistanceBetweenConfig.CopyAssign(value);
			}
		}

		// Token: 0x0602856C RID: 165228 RVA: 0x00A0811D File Offset: 0x00A0631D
		public SAiRaceStrategyCorrectionByDistance()
		{
		}

		// Token: 0x0602856D RID: 165229 RVA: 0x00A08125 File Offset: 0x00A06325
		public SAiRaceStrategyCorrectionByDistance(bool Enable, TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByDistanceBetweenConfig)
		{
			this.Enable = Enable;
			this.CalcTargetSpeedByDistanceBetweenConfig = CalcTargetSpeedByDistanceBetweenConfig;
		}

		// Token: 0x0602856E RID: 165230 RVA: 0x00A0813B File Offset: 0x00A0633B
		protected override IntPtr GetUStructPtr()
		{
			return SAiRaceStrategyCorrectionByDistance.StaticStruct();
		}

		// Token: 0x0602856F RID: 165231 RVA: 0x00A08147 File Offset: 0x00A06347
		[NullableContext(2)]
		public SAiRaceStrategyCorrectionByDistance(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028570 RID: 165232 RVA: 0x00A08151 File Offset: 0x00A06351
		public SAiRaceStrategyCorrectionByDistance(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028571 RID: 165233 RVA: 0x00A0815C File Offset: 0x00A0635C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiRaceStrategyCorrectionByDistance(Pointer, false, true);
		}

		// Token: 0x06028572 RID: 165234 RVA: 0x00A08166 File Offset: 0x00A06366
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiRaceStrategyCorrectionByDistance(Pointer, MemoryOwner);
		}

		// Token: 0x0401537C RID: 86908
		public const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionByDistance.SAiRaceStrategyCorrectionByDistance";

		// Token: 0x0401537D RID: 86909
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401537E RID: 86910
		internal static int __PropertyOffset_0;

		// Token: 0x0401537F RID: 86911
		internal static int __PropertyOffset_1;

		// Token: 0x04015380 RID: 86912
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SAiRaceStrategyOneParamFunction> _CalcTargetSpeedByDistanceBetweenConfig;
	}
}
