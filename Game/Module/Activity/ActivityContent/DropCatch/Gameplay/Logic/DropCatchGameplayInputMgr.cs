using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200693B RID: 26939
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayInputMgr : DropCatchGameplayBaseMgr
	{
		// Token: 0x06042D9B RID: 273819 RVA: 0x01128F9D File Offset: 0x0112719D
		public DropCatchGameplayInputMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042D9C RID: 273820 RVA: 0x01128FB1 File Offset: 0x011271B1
		public override void Init()
		{
			this.Reset();
			this.RegisterAllChannels();
		}

		// Token: 0x06042D9D RID: 273821 RVA: 0x01128FBF File Offset: 0x011271BF
		public void Reset()
		{
			this.UnregisterAllChannels();
		}

		// Token: 0x06042D9E RID: 273822 RVA: 0x01128FC8 File Offset: 0x011271C8
		public void Set(EDropCatchGameplayInputChannel channel, EDropCatchGameplayInputSource source, EDropCatchRoleDirection value)
		{
			DropCatchGameplayInput<EDropCatchRoleDirection> dropCatchGameplayInput;
			if (!this.Channels.TryGetValue(channel, out dropCatchGameplayInput))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "InputChannel未注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("channel:", channel);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			dropCatchGameplayInput.Set(source, value);
		}

		// Token: 0x06042D9F RID: 273823 RVA: 0x01129020 File Offset: 0x01127220
		public EDropCatchRoleDirection Get(EDropCatchGameplayInputChannel channel, EDropCatchRoleDirection fallback)
		{
			DropCatchGameplayInput<EDropCatchRoleDirection> dropCatchGameplayInput;
			if (!this.Channels.TryGetValue(channel, out dropCatchGameplayInput))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "InputChannel未注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("channel:", channel);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return fallback;
			}
			return dropCatchGameplayInput.Get(fallback);
		}

		// Token: 0x06042DA0 RID: 273824 RVA: 0x01129078 File Offset: 0x01127278
		public void Delete(EDropCatchGameplayInputChannel channel, EDropCatchGameplayInputSource source)
		{
			DropCatchGameplayInput<EDropCatchRoleDirection> dropCatchGameplayInput;
			if (!this.Channels.TryGetValue(channel, out dropCatchGameplayInput))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "InputChannel未注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("channel:", channel);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			dropCatchGameplayInput.Delete(source);
		}

		// Token: 0x06042DA1 RID: 273825 RVA: 0x011290CC File Offset: 0x011272CC
		public override void Destroy()
		{
			this.UnregisterAllChannels();
		}

		// Token: 0x06042DA2 RID: 273826 RVA: 0x011290D4 File Offset: 0x011272D4
		private void RegisterAllChannels()
		{
			this.RegisterChannel(EDropCatchGameplayInputChannel.MoveDirection);
		}

		// Token: 0x06042DA3 RID: 273827 RVA: 0x011290DD File Offset: 0x011272DD
		private void UnregisterAllChannels()
		{
			this.UnregisterChannel(EDropCatchGameplayInputChannel.MoveDirection);
		}

		// Token: 0x06042DA4 RID: 273828 RVA: 0x011290E8 File Offset: 0x011272E8
		private void RegisterChannel(EDropCatchGameplayInputChannel channel)
		{
			DropCatchGameplayInput<EDropCatchRoleDirection> input = new DropCatchGameplayInput<EDropCatchRoleDirection>();
			input.Init(delegate(EDropCatchGameplayInputSource? source)
			{
				if (source != null)
				{
					if (source.GetValueOrDefault() == EDropCatchGameplayInputSource.Command)
					{
						DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
						if (gameplayView == null)
						{
							return;
						}
						DropCatchGameplayJoystickView joystickView = gameplayView.GetJoystickView();
						if (joystickView == null)
						{
							return;
						}
						joystickView.SetHandleByDirection(input.Get(EDropCatchRoleDirection.None));
					}
					return;
				}
				DropCatchGameplayView gameplayView2 = this.Context.GetProxy().GetGameplayView();
				if (gameplayView2 == null)
				{
					return;
				}
				DropCatchGameplayJoystickView joystickView2 = gameplayView2.GetJoystickView();
				if (joystickView2 == null)
				{
					return;
				}
				joystickView2.SetHandleByDirection(EDropCatchRoleDirection.None);
			});
			if (this.Channels.ContainsKey(channel))
			{
				this.Channels[channel] = input;
				return;
			}
			this.Channels.Add(channel, input);
		}

		// Token: 0x06042DA5 RID: 273829 RVA: 0x01129157 File Offset: 0x01127357
		private void UnregisterChannel(EDropCatchGameplayInputChannel channel)
		{
			this.Channels.Remove(channel);
		}

		// Token: 0x06042DA6 RID: 273830 RVA: 0x01129168 File Offset: 0x01127368
		public override void OnReadyTick(float deltaTime)
		{
			DropCatchGameplayInput<EDropCatchRoleDirection> dropCatchGameplayInput;
			if (this.Channels.TryGetValue(EDropCatchGameplayInputChannel.MoveDirection, out dropCatchGameplayInput))
			{
				dropCatchGameplayInput.OnTick();
			}
		}

		// Token: 0x06042DA7 RID: 273831 RVA: 0x0112918C File Offset: 0x0112738C
		public override void OnTick(float deltaTime)
		{
			foreach (DropCatchGameplayInput<EDropCatchRoleDirection> dropCatchGameplayInput in this.Channels.Values)
			{
				dropCatchGameplayInput.OnTick();
			}
			if (this.CommandMoveRemainingTime > 0f)
			{
				this.CommandMoveRemainingTime -= deltaTime;
				if (this.CommandMoveRemainingTime <= 0f)
				{
					this.ClearCommandMoveDirection();
				}
			}
		}

		// Token: 0x06042DA8 RID: 273832 RVA: 0x01129210 File Offset: 0x01127410
		public void SetMoveDirectionCommand(EDropCatchRoleDirection direction, float duration)
		{
			this.CommandMoveRemainingTime = duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.Set(EDropCatchGameplayInputChannel.MoveDirection, EDropCatchGameplayInputSource.Command, direction);
		}

		// Token: 0x06042DA9 RID: 273833 RVA: 0x0112922E File Offset: 0x0112742E
		private void ClearCommandMoveDirection()
		{
			this.CommandMoveRemainingTime = 0f;
			this.Delete(EDropCatchGameplayInputChannel.MoveDirection, EDropCatchGameplayInputSource.Command);
		}

		// Token: 0x0402540A RID: 152586
		private readonly Dictionary<EDropCatchGameplayInputChannel, DropCatchGameplayInput<EDropCatchRoleDirection>> Channels = new Dictionary<EDropCatchGameplayInputChannel, DropCatchGameplayInput<EDropCatchRoleDirection>>();

		// Token: 0x0402540B RID: 152587
		private float CommandMoveRemainingTime;
	}
}
