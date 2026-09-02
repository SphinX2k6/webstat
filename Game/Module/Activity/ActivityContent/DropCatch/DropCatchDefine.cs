using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068A8 RID: 26792
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropCatchDefine : Singleton<DropCatchDefine>
	{
		// Token: 0x06042B1A RID: 273178 RVA: 0x0111DBC8 File Offset: 0x0111BDC8
		public DropCatchDefine()
		{
			EDropCatchGameplayInputSource[] array = new EDropCatchGameplayInputSource[2];
			array[0] = EDropCatchGameplayInputSource.Command;
			this.InputPriority = array;
			base..ctor();
		}

		// Token: 0x04025230 RID: 152112
		public readonly Dictionary<string, IDropCatchCommand> CommandClass = new Dictionary<string, IDropCatchCommand>
		{
			{
				EDropCatchCommandName.SpawnDropItem.ToEnumString(),
				new SpawnDropItemCommand()
			},
			{
				EDropCatchCommandName.AddEnergy.ToEnumString(),
				new AddEnergyCommand()
			},
			{
				EDropCatchCommandName.FullEnergy.ToEnumString(),
				new FullEnergyCommand()
			},
			{
				EDropCatchCommandName.AddScore.ToEnumString(),
				new AddScoreCommand()
			},
			{
				EDropCatchCommandName.AddTime.ToEnumString(),
				new AddTimeCommand()
			},
			{
				EDropCatchCommandName.AddShield.ToEnumString(),
				new AddShieldCommand()
			},
			{
				EDropCatchCommandName.MoveRole.ToEnumString(),
				new MoveRoleCommand()
			},
			{
				EDropCatchCommandName.CrazyMode.ToEnumString(),
				new CrazyModeCommand()
			},
			{
				EDropCatchCommandName.ConvertDropItem.ToEnumString(),
				new ConvertDropItemCommand()
			},
			{
				EDropCatchCommandName.ModifyRoleSpeed.ToEnumString(),
				new ModifyRoleSpeedCommand()
			},
			{
				EDropCatchCommandName.ModifyDropPoolTimeInterval.ToEnumString(),
				new ModifyDropPoolTimeIntervalCommand()
			},
			{
				EDropCatchCommandName.ModifyAddScoreRate.ToEnumString(),
				new ModifyAddScoreRateCommand()
			},
			{
				EDropCatchCommandName.ModifyEnergyGetRate.ToEnumString(),
				new ModifyEnergyGetRateCommand()
			},
			{
				EDropCatchCommandName.ShowLeftMsg.ToEnumString(),
				new ShowLeftMsgCommand()
			},
			{
				EDropCatchCommandName.ShowFloatEff.ToEnumString(),
				new ShowFloatEffCommand()
			},
			{
				EDropCatchCommandName.ChangeRoleColor.ToEnumString(),
				new ChangeRoleColorCommand()
			},
			{
				EDropCatchCommandName.PostAudioEvent.ToEnumString(),
				new PostAudioEventCommand()
			},
			{
				EDropCatchCommandName.PlayFlow.ToEnumString(),
				new PlayFlowCommand()
			},
			{
				EDropCatchCommandName.SetInputEnabled.ToEnumString(),
				new SetInputEnabledCommand()
			}
		};

		// Token: 0x04025231 RID: 152113
		public readonly Dictionary<EDropCatchCommandName, Type> CommandParamsTypeMap = new Dictionary<EDropCatchCommandName, Type>
		{
			{
				EDropCatchCommandName.SpawnDropItem,
				typeof(ISpawnDropItemCommandParams)
			},
			{
				EDropCatchCommandName.AddEnergy,
				typeof(IAddEnergyCommandParams)
			},
			{
				EDropCatchCommandName.AddScore,
				typeof(IAddScoreCommandParams)
			},
			{
				EDropCatchCommandName.AddTime,
				typeof(IAddTimeCommandParams)
			},
			{
				EDropCatchCommandName.AddShield,
				typeof(IAddShieldCommandParams)
			},
			{
				EDropCatchCommandName.ConvertDropItem,
				typeof(IConvertDropItemCommandParams)
			},
			{
				EDropCatchCommandName.MoveRole,
				typeof(IMoveRoleCommandParams)
			},
			{
				EDropCatchCommandName.ModifyRoleSpeed,
				typeof(IModifyRoleSpeedCommandParams)
			},
			{
				EDropCatchCommandName.ModifyDropPoolTimeInterval,
				typeof(IModifyDropPoolTimeIntervalCommandParams)
			},
			{
				EDropCatchCommandName.ModifyAddScoreRate,
				typeof(IModifyAddScoreRateCommandParams)
			},
			{
				EDropCatchCommandName.ModifyEnergyGetRate,
				typeof(IModifyEnergyGetRateCommandParams)
			},
			{
				EDropCatchCommandName.ShowLeftMsg,
				typeof(IShowLeftMsgCommandParams)
			},
			{
				EDropCatchCommandName.ShowFloatEff,
				typeof(IShowFloatEffCommandParams)
			},
			{
				EDropCatchCommandName.ChangeRoleColor,
				typeof(IChangeRoleColorCommandParams)
			},
			{
				EDropCatchCommandName.PostAudioEvent,
				typeof(IPostAudioEventCommandParams)
			},
			{
				EDropCatchCommandName.PlayFlow,
				typeof(IPlayFlowCommandParams)
			},
			{
				EDropCatchCommandName.SetInputEnabled,
				typeof(ISetInputEnabledCommandParams)
			}
		};

		// Token: 0x04025232 RID: 152114
		public readonly EDropCatchGameplayInputSource[] InputPriority;
	}
}
