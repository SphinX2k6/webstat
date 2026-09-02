using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game.Input.BattleInputData;
using CSharpScript.Game.Utils;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FD3 RID: 28627
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class InputModel : ModelBase<InputModel>
	{
		// Token: 0x06045435 RID: 283701 RVA: 0x01217BFC File Offset: 0x01215DFC
		protected override bool OnInit()
		{
			this.InputDataMap[EInputDataType.NormalWorld] = new NormalWorldInputData();
			this.InputDataMap[EInputDataType.TrapDefense] = new TrapDefenseInputData();
			this.InputDataMap[EInputDataType.SurvivorsRogue] = new SurvivorsRogueInputData();
			this.InputDataMap[EInputDataType.NormalWorldMotor] = new NormalWorldMotorInputData();
			this.InputDataMap[EInputDataType.SpringManor] = new SpringManorInputData();
			this.InputDataMap[EInputDataType.PinballBattle] = new PinballBattleInputData();
			return true;
		}

		// Token: 0x06045436 RID: 283702 RVA: 0x01217C70 File Offset: 0x01215E70
		public void SetCurrentInputDataType(EInputDataType dataType)
		{
			this.CurrentInputDataType = dataType;
		}

		// Token: 0x06045437 RID: 283703 RVA: 0x01217C79 File Offset: 0x01215E79
		public EInputDataType GetCurrentInputDataType()
		{
			return this.CurrentInputDataType;
		}

		// Token: 0x06045438 RID: 283704 RVA: 0x01217C84 File Offset: 0x01215E84
		[NullableContext(2)]
		public BattleInputData GetCurrentInputData()
		{
			BattleInputData result;
			if (this.InputDataMap.TryGetValue(this.CurrentInputDataType, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06045439 RID: 283705 RVA: 0x01217CAC File Offset: 0x01215EAC
		public BattleInputData GetInputData(EInputDataType dataType)
		{
			BattleInputData result;
			if (this.InputDataMap.TryGetValue(dataType, out result))
			{
				return result;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("InputData not found for type: ");
			defaultInterpolatedStringHandler.AppendFormatted<EInputDataType>(dataType);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0604543A RID: 283706 RVA: 0x01217CF5 File Offset: 0x01215EF5
		public List<IInputHandler> GetHandlers()
		{
			return this.InputHandlers;
		}

		// Token: 0x0604543B RID: 283707 RVA: 0x01217CFD File Offset: 0x01215EFD
		public Dictionary<EInputAction, float> GetPressTimes()
		{
			return this.PressTimes;
		}

		// Token: 0x0604543C RID: 283708 RVA: 0x01217D05 File Offset: 0x01215F05
		public Dictionary<EInputAction, float> GetHoldTimes()
		{
			return this.HoldTimes;
		}

		// Token: 0x0604543D RID: 283709 RVA: 0x01217D10 File Offset: 0x01215F10
		public float? GetHoldTime(EInputAction action)
		{
			if (!this.HoldTimes.ContainsKey(action))
			{
				return null;
			}
			return new float?(this.HoldTimes[action]);
		}

		// Token: 0x0604543E RID: 283710 RVA: 0x01217D48 File Offset: 0x01215F48
		public void SetHoldTime(EInputAction action, float? value = null)
		{
			float valueOrDefault = value.GetValueOrDefault();
			this.HoldTimes[action] = valueOrDefault;
		}

		// Token: 0x0604543F RID: 283711 RVA: 0x01217D6A File Offset: 0x01215F6A
		public Dictionary<EInputAxis, float> GetAxisValues()
		{
			return this.AxisValues;
		}

		// Token: 0x1700A4BB RID: 42171
		// (get) Token: 0x06045440 RID: 283712 RVA: 0x01217D72 File Offset: 0x01215F72
		public bool LastClearAxisValue
		{
			get
			{
				return this.LastTemporaryClearAxisValue;
			}
		}

		// Token: 0x06045441 RID: 283713 RVA: 0x01217D7A File Offset: 0x01215F7A
		public void ResetLastTemporaryClearAxisValues()
		{
			this.LastTemporaryClearAxisValue = false;
		}

		// Token: 0x06045442 RID: 283714 RVA: 0x01217D83 File Offset: 0x01215F83
		public void TemporaryClearAxisValues()
		{
			this.LastTemporaryClearAxisValue = true;
			this.AxisValues.Clear();
		}

		// Token: 0x06045443 RID: 283715 RVA: 0x01217D97 File Offset: 0x01215F97
		public void NextFrameRefreshAxisValues()
		{
			this.LastTemporaryClearAxisValue = true;
		}

		// Token: 0x06045444 RID: 283716 RVA: 0x01217DA0 File Offset: 0x01215FA0
		public int? QueryCommandPriority(ECommandType commandType)
		{
			int value;
			if (this.CommandPriorities.TryGetValue(commandType, out value))
			{
				return new int?(value);
			}
			return null;
		}

		// Token: 0x06045445 RID: 283717 RVA: 0x01217DD0 File Offset: 0x01215FD0
		public void AddInputHandler(IInputHandler handler)
		{
			if (this.InputHandlers.Contains(handler))
			{
				return;
			}
			this.InputHandlers.Add(handler);
			this.InputHandlers.Sort((IInputHandler a, IInputHandler b) => b.GetPriority() - a.GetPriority());
		}

		// Token: 0x06045446 RID: 283718 RVA: 0x01217E24 File Offset: 0x01216024
		public bool IsAxisBlock(EInputAxis axis)
		{
			for (int i = 0; i < this.InputHandlers.Count; i++)
			{
				if (this.InputHandlers[i].GetInputFilter().BlockAxis(axis))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06045447 RID: 283719 RVA: 0x01217E64 File Offset: 0x01216064
		public void RemoveInputHandler(IInputHandler handler)
		{
			int num = this.InputHandlers.IndexOf(handler);
			if (num == -1)
			{
				return;
			}
			this.InputHandlers.RemoveAt(num);
		}

		// Token: 0x06045448 RID: 283720 RVA: 0x01217E90 File Offset: 0x01216090
		protected override bool OnClear()
		{
			this.InputHandlers.Clear();
			this.PressTimes.Clear();
			this.HoldTimes.Clear();
			this.AxisValues.Clear();
			foreach (InputLayerUnit inputLayerUnit in this.InputLayers.Values)
			{
				inputLayerUnit.Clear();
			}
			this.InputLayers.Clear();
			return true;
		}

		// Token: 0x06045449 RID: 283721 RVA: 0x01217F20 File Offset: 0x01216120
		public void AddInputLayer(int unitId, InputLayer layer)
		{
			InputLayerUnit inputLayerUnit;
			if (!this.InputLayers.TryGetValue(unitId, out inputLayerUnit))
			{
				inputLayerUnit = new InputLayerUnit();
				this.InputLayers[unitId] = inputLayerUnit;
			}
			inputLayerUnit.Add(layer);
		}

		// Token: 0x0604544A RID: 283722 RVA: 0x01217F58 File Offset: 0x01216158
		public void RemoveInputLayer(InputLayer layer)
		{
			InputLayerUnit inputLayerUnit;
			if (this.InputLayers.TryGetValue(layer.UnitId, out inputLayerUnit))
			{
				inputLayerUnit.Remove(layer);
				if (inputLayerUnit.LayerMap.Count == 0)
				{
					this.InputLayers.Remove(layer.UnitId);
				}
			}
		}

		// Token: 0x0604544B RID: 283723 RVA: 0x01217FA0 File Offset: 0x012161A0
		[NullableContext(2)]
		public InputLayer GetInputLayer(int unitId, EInputLayer layerType)
		{
			InputLayerUnit inputLayerUnit;
			if (!this.InputLayers.TryGetValue(unitId, out inputLayerUnit))
			{
				return null;
			}
			InputLayer result;
			if (!inputLayerUnit.LayerMap.TryGetValue(layerType, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0604544C RID: 283724 RVA: 0x01217FD4 File Offset: 0x012161D4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<InputLayer> GetInputLayers(int unitId)
		{
			InputLayerUnit inputLayerUnit;
			if (!this.InputLayers.TryGetValue(unitId, out inputLayerUnit))
			{
				return null;
			}
			return inputLayerUnit.GetLayerList();
		}

		// Token: 0x0604544D RID: 283725 RVA: 0x01217FFC File Offset: 0x012161FC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public SInputCommandTransform[] GetInputCommandTransformData(EInputAction action, EInputState state)
		{
			if (!this.IsInitTransformMap)
			{
				this.InitInputCommandTransformMap();
			}
			if (this.InputCommandTransformMap == null)
			{
				return null;
			}
			Dictionary<EInputState, SInputCommandTransform[]> dictionary;
			if (!this.InputCommandTransformMap.TryGetValue(action, out dictionary))
			{
				return null;
			}
			SInputCommandTransform[] result;
			if (!dictionary.TryGetValue(state, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0604544E RID: 283726 RVA: 0x01218044 File Offset: 0x01216244
		public void InitInputCommandTransformMap()
		{
			if (this.IsInitTransformMap)
			{
				return;
			}
			this.IsInitTransformMap = true;
			Dictionary<EInputAction, Dictionary<EInputState, SInputCommandTransform[]>> dictionary = new Dictionary<EInputAction, Dictionary<EInputState, SInputCommandTransform[]>>();
			List<SInputCommandTransform> dataTableAllRow = DataTableUtil.GetDataTableAllRow<SInputCommandTransform>(EDataTable.InputCommandTransform);
			for (int i = 0; i < dataTableAllRow.Count; i++)
			{
				SInputCommandTransform sinputCommandTransform = dataTableAllRow[i];
				if (!(sinputCommandTransform.Action == EInputAction.None) && !(sinputCommandTransform.State == EInputState.None) && !(sinputCommandTransform.Tag.TagName == "None"))
				{
					if (!dictionary.ContainsKey(sinputCommandTransform.Action))
					{
						dictionary[sinputCommandTransform.Action] = new Dictionary<EInputState, SInputCommandTransform[]>();
					}
					Dictionary<EInputState, SInputCommandTransform[]> dictionary2 = dictionary[sinputCommandTransform.Action];
					if (!dictionary2.ContainsKey(sinputCommandTransform.State))
					{
						dictionary2[sinputCommandTransform.State] = new SInputCommandTransform[]
						{
							sinputCommandTransform
						};
					}
					else
					{
						SInputCommandTransform[] array = dictionary2[sinputCommandTransform.State];
						SInputCommandTransform[] array2 = new SInputCommandTransform[array.Length + 1];
						for (int j = 0; j < array.Length; j++)
						{
							array2[j] = array[j];
						}
						array2[array.Length] = sinputCommandTransform;
						dictionary2[sinputCommandTransform.State] = array2;
					}
				}
			}
			this.InputCommandTransformMap = dictionary;
		}

		// Token: 0x0604544F RID: 283727 RVA: 0x012181A8 File Offset: 0x012163A8
		public InputModel()
		{
			Dictionary<ECommandType, int> dictionary = new Dictionary<ECommandType, int>();
			dictionary[ECommandType.Jump] = 0;
			dictionary[ECommandType.Climb] = 0;
			dictionary[ECommandType.Sprint] = 0;
			dictionary[ECommandType.FastSwim] = 0;
			dictionary[ECommandType.FastClimb] = 0;
			dictionary[ECommandType.SwitchCharacter] = 0;
			dictionary[ECommandType.SwitchWalk] = 0;
			dictionary[ECommandType.SendGameplayEvent] = 0;
			dictionary[ECommandType.XaBoost] = 0;
			dictionary[ECommandType.Drop] = 0;
			this.CommandPriorities = dictionary;
			this.InputHandlers = new List<IInputHandler>();
			this.PressTimes = new Dictionary<EInputAction, float>();
			this.HoldTimes = new Dictionary<EInputAction, float>();
			this.AxisValues = new Dictionary<EInputAxis, float>();
			this.InputLayers = new Dictionary<int, InputLayerUnit>();
			this.OnlyMoveForward = new Switcher(false, null);
			this.InputDataMap = new Dictionary<EInputDataType, BattleInputData>();
			base..ctor();
		}

		// Token: 0x04026A72 RID: 158322
		public const string INPUT_COMMAND_TRANSFORM_DT_PATH = "/Game/Aki/Data/Fight/DT_InputCommandTransform.DT_InputCommandTransform";

		// Token: 0x04026A73 RID: 158323
		private readonly Dictionary<ECommandType, int> CommandPriorities;

		// Token: 0x04026A74 RID: 158324
		private readonly List<IInputHandler> InputHandlers;

		// Token: 0x04026A75 RID: 158325
		private readonly Dictionary<EInputAction, float> PressTimes;

		// Token: 0x04026A76 RID: 158326
		private readonly Dictionary<EInputAction, float> HoldTimes;

		// Token: 0x04026A77 RID: 158327
		private readonly Dictionary<EInputAxis, float> AxisValues;

		// Token: 0x04026A78 RID: 158328
		private readonly Dictionary<int, InputLayerUnit> InputLayers;

		// Token: 0x04026A79 RID: 158329
		public Switcher OnlyMoveForward;

		// Token: 0x04026A7A RID: 158330
		public bool IsOpenInputAxisLog;

		// Token: 0x04026A7B RID: 158331
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Dictionary<EInputAction, Dictionary<EInputState, SInputCommandTransform[]>> InputCommandTransformMap;

		// Token: 0x04026A7C RID: 158332
		private bool IsInitTransformMap;

		// Token: 0x04026A7D RID: 158333
		private readonly Dictionary<EInputDataType, BattleInputData> InputDataMap;

		// Token: 0x04026A7E RID: 158334
		private EInputDataType CurrentInputDataType;

		// Token: 0x04026A7F RID: 158335
		private bool LastTemporaryClearAxisValue;
	}
}
