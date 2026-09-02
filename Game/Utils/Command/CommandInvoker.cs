using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004724 RID: 18212
	[NullableContext(1)]
	[Nullable(0)]
	public class CommandInvoker
	{
		// Token: 0x0602F4CE RID: 193742 RVA: 0x00B36FA9 File Offset: 0x00B351A9
		public void SubmitCommand<[Nullable(0)] T>(IGameCommand<T> command, bool immediatelyExecuteCommands) where T : ICommandType
		{
			this.CommandQueue.Push(command);
			if (immediatelyExecuteCommands)
			{
				this.ExecuteAllCommand();
			}
		}

		// Token: 0x0602F4CF RID: 193743 RVA: 0x00B36FC0 File Offset: 0x00B351C0
		public void ExecuteAllCommand()
		{
			CommandInvoker.<>c__DisplayClass2_0 CS$<>8__locals1;
			CS$<>8__locals1.notValidCommands = new List<IGameCommandBase>();
			for (int i = 0; i < this.CommandQueue.Size; i++)
			{
				IGameCommandBase gameCommandBase = this.CommandQueue.Get(i);
				if (gameCommandBase != null)
				{
					IGameCommand<ICommandTypeAddFollower> gameCommand = gameCommandBase as IGameCommand<ICommandTypeAddFollower>;
					if (gameCommand == null)
					{
						IGameCommand<ICommandTypeRemoveFollower> gameCommand2 = gameCommandBase as IGameCommand<ICommandTypeRemoveFollower>;
						if (gameCommand2 == null)
						{
							IGameCommand<ICommandTypeFlushFollower> gameCommand3 = gameCommandBase as IGameCommand<ICommandTypeFlushFollower>;
							if (gameCommand3 != null)
							{
								CommandInvoker.<ExecuteAllCommand>g__SingleCommandTask|2_0<ICommandTypeFlushFollower>(gameCommand3, ref CS$<>8__locals1);
							}
						}
						else
						{
							CommandInvoker.<ExecuteAllCommand>g__SingleCommandTask|2_0<ICommandTypeRemoveFollower>(gameCommand2, ref CS$<>8__locals1);
						}
					}
					else
					{
						CommandInvoker.<ExecuteAllCommand>g__SingleCommandTask|2_0<ICommandTypeAddFollower>(gameCommand, ref CS$<>8__locals1);
					}
				}
			}
			this.CommandQueue.Clear();
			foreach (IGameCommandBase element in CS$<>8__locals1.notValidCommands)
			{
				this.CommandQueue.Push(element);
			}
		}

		// Token: 0x0602F4D0 RID: 193744 RVA: 0x00B3709C File Offset: 0x00B3529C
		public void ClearAllCommand()
		{
			this.CommandQueue.Clear();
		}

		// Token: 0x0602F4D1 RID: 193745 RVA: 0x00B370A9 File Offset: 0x00B352A9
		public void Undo()
		{
		}

		// Token: 0x0602F4D3 RID: 193747 RVA: 0x00B370C0 File Offset: 0x00B352C0
		[CompilerGenerated]
		internal static void <ExecuteAllCommand>g__SingleCommandTask|2_0<T>(IGameCommand<T> command, ref CommandInvoker.<>c__DisplayClass2_0 A_1) where T : ICommandType
		{
			bool flag = true;
			GameCommandWithValidators<T> gameCommandWithValidators = command as GameCommandWithValidators<T>;
			if (gameCommandWithValidators != null)
			{
				using (HashSet<IValidator>.Enumerator enumerator = gameCommandWithValidators.Validators.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.Validate())
						{
							A_1.notValidCommands.Add(command);
							flag = false;
							break;
						}
					}
				}
			}
			if (!flag)
			{
				return;
			}
			if (command != null && command.Params != null)
			{
				if (command.Execute != null)
				{
					command.Execute(command.Params);
				}
				IGameCommandWithReceivers<T> gameCommandWithReceivers = command as IGameCommandWithReceivers<T>;
				if (gameCommandWithReceivers != null)
				{
					foreach (IReceiver<T> receiver in gameCommandWithReceivers.Receivers)
					{
						receiver.ReceiveExecute(command.Params);
					}
				}
			}
		}

		// Token: 0x0401AF12 RID: 110354
		private readonly Queue<IGameCommandBase> CommandQueue = new Queue<IGameCommandBase>(4);
	}
}
