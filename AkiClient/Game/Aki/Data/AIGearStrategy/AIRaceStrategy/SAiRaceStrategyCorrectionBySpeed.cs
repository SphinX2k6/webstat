using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F24 RID: 16164
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionBySpeed.SAiRaceStrategyCorrectionBySpeed")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SAiRaceStrategyCorrectionBySpeed : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028573 RID: 165235 RVA: 0x00A0816F File Offset: 0x00A0636F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiRaceStrategyCorrectionBySpeed._ScriptStructPtr != 0) ? SAiRaceStrategyCorrectionBySpeed._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionBySpeed.SAiRaceStrategyCorrectionBySpeed", ref SAiRaceStrategyCorrectionBySpeed._ScriptStructPtr);
		}

		// Token: 0x170061E4 RID: 25060
		// (get) Token: 0x06028574 RID: 165236 RVA: 0x00A08193 File Offset: 0x00A06393
		// (set) Token: 0x06028575 RID: 165237 RVA: 0x00A081A3 File Offset: 0x00A063A3
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionBySpeed.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionBySpeed.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061E5 RID: 25061
		// (get) Token: 0x06028576 RID: 165238 RVA: 0x00A081B4 File Offset: 0x00A063B4
		// (set) Token: 0x06028577 RID: 165239 RVA: 0x00A081F7 File Offset: 0x00A063F7
		public TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByDeltaAbsSpeedConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAiRaceStrategyOneParamFunction> result;
				if ((result = this._CalcTargetSpeedByDeltaAbsSpeedConfig) == null)
				{
					result = (this._CalcTargetSpeedByDeltaAbsSpeedConfig = new TArray<SAiRaceStrategyOneParamFunction>(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionBySpeed.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CalcTargetSpeedByDeltaAbsSpeedConfig.CopyAssign(value);
			}
		}

		// Token: 0x170061E6 RID: 25062
		// (get) Token: 0x06028578 RID: 165240 RVA: 0x00A08208 File Offset: 0x00A06408
		// (set) Token: 0x06028579 RID: 165241 RVA: 0x00A0824B File Offset: 0x00A0644B
		public TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByRivalAbsSpeedConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAiRaceStrategyOneParamFunction> result;
				if ((result = this._CalcTargetSpeedByRivalAbsSpeedConfig) == null)
				{
					result = (this._CalcTargetSpeedByRivalAbsSpeedConfig = new TArray<SAiRaceStrategyOneParamFunction>(base.NativePtr + (IntPtr)SAiRaceStrategyCorrectionBySpeed.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CalcTargetSpeedByRivalAbsSpeedConfig.CopyAssign(value);
			}
		}

		// Token: 0x0602857A RID: 165242 RVA: 0x00A08259 File Offset: 0x00A06459
		public SAiRaceStrategyCorrectionBySpeed()
		{
		}

		// Token: 0x0602857B RID: 165243 RVA: 0x00A08261 File Offset: 0x00A06461
		public SAiRaceStrategyCorrectionBySpeed(bool Enable, TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByDeltaAbsSpeedConfig, TArray<SAiRaceStrategyOneParamFunction> CalcTargetSpeedByRivalAbsSpeedConfig)
		{
			this.Enable = Enable;
			this.CalcTargetSpeedByDeltaAbsSpeedConfig = CalcTargetSpeedByDeltaAbsSpeedConfig;
			this.CalcTargetSpeedByRivalAbsSpeedConfig = CalcTargetSpeedByRivalAbsSpeedConfig;
		}

		// Token: 0x0602857C RID: 165244 RVA: 0x00A0827E File Offset: 0x00A0647E
		protected override IntPtr GetUStructPtr()
		{
			return SAiRaceStrategyCorrectionBySpeed.StaticStruct();
		}

		// Token: 0x0602857D RID: 165245 RVA: 0x00A0828A File Offset: 0x00A0648A
		[NullableContext(2)]
		public SAiRaceStrategyCorrectionBySpeed(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602857E RID: 165246 RVA: 0x00A08294 File Offset: 0x00A06494
		public SAiRaceStrategyCorrectionBySpeed(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602857F RID: 165247 RVA: 0x00A0829F File Offset: 0x00A0649F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiRaceStrategyCorrectionBySpeed(Pointer, false, true);
		}

		// Token: 0x06028580 RID: 165248 RVA: 0x00A082A9 File Offset: 0x00A064A9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiRaceStrategyCorrectionBySpeed(Pointer, MemoryOwner);
		}

		// Token: 0x04015381 RID: 86913
		public const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyCorrectionBySpeed.SAiRaceStrategyCorrectionBySpeed";

		// Token: 0x04015382 RID: 86914
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015383 RID: 86915
		internal static int __PropertyOffset_0;

		// Token: 0x04015384 RID: 86916
		internal static int __PropertyOffset_1;

		// Token: 0x04015385 RID: 86917
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SAiRaceStrategyOneParamFunction> _CalcTargetSpeedByDeltaAbsSpeedConfig;

		// Token: 0x04015386 RID: 86918
		internal static int __PropertyOffset_2;

		// Token: 0x04015387 RID: 86919
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SAiRaceStrategyOneParamFunction> _CalcTargetSpeedByRivalAbsSpeedConfig;
	}
}
