using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Config;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006932 RID: 26930
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayCommandMgr : DropCatchGameplayBaseMgr, ICommandContext
	{
		// Token: 0x06042D5B RID: 273755 RVA: 0x011275BA File Offset: 0x011257BA
		public DropCatchGameplayCommandMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042D5C RID: 273756 RVA: 0x011275FA File Offset: 0x011257FA
		public IGameplayLogicContext GetLogicContext()
		{
			return this.Context;
		}

		// Token: 0x06042D5D RID: 273757 RVA: 0x01127602 File Offset: 0x01125802
		public override void Init()
		{
			this.GameplayTimeCommands.Clear();
			this.RemainingTimeCommands.Clear();
			this.SkillCommands.Clear();
			this.DropItemEffectCommands.Clear();
			this.TmpArray.Clear();
			this.InitCommands();
		}

		// Token: 0x06042D5E RID: 273758 RVA: 0x01127644 File Offset: 0x01125844
		private void InitCommands()
		{
			DropCatchGameplay? gameplayConfig = this.Context.GetProxy().GetGameplayConfig();
			if (gameplayConfig == null)
			{
				return;
			}
			this.LoadTimeCommands(gameplayConfig.Value.GameplayTimeCommands, delegate(TimeCommands timeCommands)
			{
				float key = timeCommands.Time * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
				List<CommandData> list;
				if (!this.GameplayTimeCommands.TryGetValue(key, out list))
				{
					list = new List<CommandData>();
					this.GameplayTimeCommands.Add(key, list);
				}
				list.AddRange(timeCommands.Commands);
			});
			this.LoadTimeCommands(gameplayConfig.Value.RemainingTimeCommands, delegate(TimeCommands timeCommands)
			{
				float key = timeCommands.Time * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
				List<CommandData> list;
				if (!this.RemainingTimeCommands.TryGetValue(key, out list))
				{
					list = new List<CommandData>();
					this.RemainingTimeCommands.Add(key, list);
				}
				list.AddRange(timeCommands.Commands);
			});
			this.LoadCommands(gameplayConfig.Value.SkillCommands, delegate(CommandData cmd)
			{
				this.SkillCommands.Add(cmd);
			});
			IReadOnlyList<DropCatchDropItem> allDropItemConfig = ConfigBase<DropCatchConfig>.Instance.GetAllDropItemConfig();
			if (allDropItemConfig != null)
			{
				using (IEnumerator<DropCatchDropItem> enumerator = allDropItemConfig.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DropCatchDropItem dropItemConfig = enumerator.Current;
						this.LoadCommands(dropItemConfig.EffectCommands, delegate(CommandData cmd)
						{
							List<CommandData> list;
							if (!this.DropItemEffectCommands.TryGetValue(dropItemConfig.Id, out list))
							{
								list = new List<CommandData>();
								this.DropItemEffectCommands.Add(dropItemConfig.Id, list);
							}
							list.Add(cmd);
						});
					}
				}
			}
		}

		// Token: 0x06042D5F RID: 273759 RVA: 0x01127748 File Offset: 0x01125948
		public override void OnTick(float deltaTime)
		{
			this.ProcessTimedCommands();
		}

		// Token: 0x06042D60 RID: 273760 RVA: 0x01127750 File Offset: 0x01125950
		private void LoadCommands(string serializedValue, Action<CommandData> addFn)
		{
			if (StringUtils.IsEmpty(serializedValue))
			{
				return;
			}
			List<CommandData> list = Json.Parse<List<CommandData>>(serializedValue, null);
			if (list != null)
			{
				foreach (CommandData obj in list)
				{
					addFn(obj);
				}
			}
		}

		// Token: 0x06042D61 RID: 273761 RVA: 0x011277B4 File Offset: 0x011259B4
		private void LoadTimeCommands(string serializedValue, Action<TimeCommands> addFn)
		{
			if (StringUtils.IsEmpty(serializedValue))
			{
				return;
			}
			List<TimeCommands> list = Json.Parse<List<TimeCommands>>(serializedValue, null);
			if (list != null)
			{
				foreach (TimeCommands obj in list)
				{
					addFn(obj);
				}
			}
		}

		// Token: 0x06042D62 RID: 273762 RVA: 0x01127818 File Offset: 0x01125A18
		[NullableContext(2)]
		public unsafe void ExecuteCommand(EDropCatchCommandName commandName, object @params)
		{
			IDropCatchCommand dropCatchCommand;
			if (!Singleton<DropCatchDefine>.Instance.CommandClass.TryGetValue(commandName.ToEnumString(), out dropCatchCommand))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "ExecuteCommand failed";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CommandName", commandName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			@params = DropCatchGameplayCommandMgr.DeserializeParams(commandName, @params);
			dropCatchCommand.Execute(this, @params);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.DropCatch;
			ELogAuthor author2 = ELogAuthor.CB;
			string message2 = "ExecuteCommand success";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CommandName", commandName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Params", @params);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06042D63 RID: 273763 RVA: 0x011278DC File Offset: 0x01125ADC
		public void ExecuteDropItemEffectCommand(int itemId)
		{
			List<CommandData> list;
			if (!this.DropItemEffectCommands.TryGetValue(itemId, out list))
			{
				return;
			}
			foreach (CommandData commandData in list)
			{
				this.ExecuteCommand(commandData.CommandName, commandData.Params);
			}
		}

		// Token: 0x06042D64 RID: 273764 RVA: 0x01127948 File Offset: 0x01125B48
		public void ExecuteSkillCommand()
		{
			foreach (CommandData commandData in this.SkillCommands)
			{
				this.ExecuteCommand(commandData.CommandName, commandData.Params);
			}
		}

		// Token: 0x06042D65 RID: 273765 RVA: 0x011279A8 File Offset: 0x01125BA8
		private void ProcessTimedCommands()
		{
			float time = this.Context.GetGameplayTimeMgr().GetTime();
			this.TmpArray.Clear();
			foreach (KeyValuePair<float, List<CommandData>> keyValuePair in this.GameplayTimeCommands)
			{
				float key = keyValuePair.Key;
				List<CommandData> value = keyValuePair.Value;
				if (time >= key)
				{
					foreach (CommandData commandData in value)
					{
						this.ExecuteCommand(commandData.CommandName, commandData.Params);
					}
					this.TmpArray.Add(key);
				}
			}
			foreach (float key2 in this.TmpArray)
			{
				this.GameplayTimeCommands.Remove(key2);
			}
			float remainingTime = this.Context.GetGameplayTimeMgr().GetRemainingTime();
			this.TmpArray.Clear();
			foreach (KeyValuePair<float, List<CommandData>> keyValuePair2 in this.RemainingTimeCommands)
			{
				float key3 = keyValuePair2.Key;
				List<CommandData> value2 = keyValuePair2.Value;
				if (remainingTime <= key3)
				{
					foreach (CommandData commandData2 in value2)
					{
						this.ExecuteCommand(commandData2.CommandName, commandData2.Params);
					}
					this.TmpArray.Add(key3);
				}
			}
			foreach (float key4 in this.TmpArray)
			{
				this.RemainingTimeCommands.Remove(key4);
			}
		}

		// Token: 0x06042D66 RID: 273766 RVA: 0x01127BE0 File Offset: 0x01125DE0
		[NullableContext(2)]
		private static object DeserializeParams(EDropCatchCommandName commandName, object @params)
		{
			if (!(@params is JsonElement))
			{
				return @params;
			}
			JsonElement element = (JsonElement)@params;
			Type returnType;
			if (!Singleton<DropCatchDefine>.Instance.CommandParamsTypeMap.TryGetValue(commandName, out returnType))
			{
				return @params;
			}
			return element.Deserialize(returnType, JsonSettings.DecodeOptions);
		}

		// Token: 0x040253DE RID: 152542
		private readonly Dictionary<float, List<CommandData>> GameplayTimeCommands = new Dictionary<float, List<CommandData>>();

		// Token: 0x040253DF RID: 152543
		private readonly Dictionary<float, List<CommandData>> RemainingTimeCommands = new Dictionary<float, List<CommandData>>();

		// Token: 0x040253E0 RID: 152544
		private readonly List<CommandData> SkillCommands = new List<CommandData>();

		// Token: 0x040253E1 RID: 152545
		private readonly Dictionary<int, List<CommandData>> DropItemEffectCommands = new Dictionary<int, List<CommandData>>();

		// Token: 0x040253E2 RID: 152546
		private readonly List<float> TmpArray = new List<float>();
	}
}
