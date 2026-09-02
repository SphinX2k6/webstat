using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Process
{
	// Token: 0x020055F0 RID: 22000
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaProcessManager
	{
		// Token: 0x17008FF9 RID: 36857
		// (get) Token: 0x060380A0 RID: 229536 RVA: 0x00E326E5 File Offset: 0x00E308E5
		public EPlayingCardProcessState State
		{
			get
			{
				return this.StateInternal;
			}
		}

		// Token: 0x17008FFA RID: 36858
		// (get) Token: 0x060380A1 RID: 229537 RVA: 0x00E326ED File Offset: 0x00E308ED
		public bool IsInOwnPlaying
		{
			get
			{
				return this.StateInternal == EPlayingCardProcessState.OwnPlaying;
			}
		}

		// Token: 0x17008FFB RID: 36859
		// (get) Token: 0x060380A2 RID: 229538 RVA: 0x00E326F9 File Offset: 0x00E308F9
		public bool IsNotInOwnPlaying
		{
			get
			{
				return this.StateInternal < EPlayingCardProcessState.OwnPlaying;
			}
		}

		// Token: 0x060380A3 RID: 229539 RVA: 0x00E32708 File Offset: 0x00E30908
		public PhantomArenaProcessManager(PhantomArenaBattleProxy proxy)
		{
			Dictionary<EPlayingCardProcessState, List<EPlayingCardProcessState>> dictionary = new Dictionary<EPlayingCardProcessState, List<EPlayingCardProcessState>>();
			dictionary[EPlayingCardProcessState.OwnChangeCard] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.TimeStart
			};
			dictionary[EPlayingCardProcessState.BothDrawCard] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OwnChangeCard,
				EPlayingCardProcessState.TimeStart
			};
			dictionary[EPlayingCardProcessState.OpponentTimeStart] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.BothDrawCard
			};
			dictionary[EPlayingCardProcessState.OpponentPlaying] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OpponentTimeStart
			};
			dictionary[EPlayingCardProcessState.GameOverByOpponent] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OpponentPlaying
			};
			dictionary[EPlayingCardProcessState.OwnTimeStart] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OpponentPlaying,
				EPlayingCardProcessState.GameOverByOpponent
			};
			dictionary[EPlayingCardProcessState.ShowOwnCoreCard] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OwnTimeStart
			};
			dictionary[EPlayingCardProcessState.OwnPlaying] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OwnTimeStart,
				EPlayingCardProcessState.ShowOwnCoreCard
			};
			dictionary[EPlayingCardProcessState.TimeEnd] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.OwnPlaying
			};
			dictionary[EPlayingCardProcessState.JumpLoading] = new List<EPlayingCardProcessState>
			{
				EPlayingCardProcessState.TimeEnd
			};
			this.StateParentMap = dictionary;
			base..ctor();
			this.Proxy = proxy;
		}

		// Token: 0x060380A4 RID: 229540 RVA: 0x00E3281C File Offset: 0x00E30A1C
		public void InitStateMap()
		{
			this.StateMap[EPlayingCardProcessState.TimeStart] = delegate()
			{
				this.Proxy.ShowTimeStart();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.OwnChangeCard] = delegate()
			{
				this.Proxy.ShowOwnChangeCard();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.BothDrawCard] = (() => this.Proxy.ShowBothDrawCard());
			this.StateMap[EPlayingCardProcessState.OpponentTimeStart] = delegate()
			{
				this.Proxy.ShowOpponentStartPanel();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.OpponentPlaying] = (() => this.Proxy.StartAiOperation());
			this.StateMap[EPlayingCardProcessState.GameOverByOpponent] = delegate()
			{
				this.Proxy.ShowGameOver();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.OwnTimeStart] = delegate()
			{
				this.Proxy.ShowOwnStartPanel();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.ShowOwnCoreCard] = delegate()
			{
				this.Proxy.ShowOwnCoreCard();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.OwnPlaying] = delegate()
			{
				this.Proxy.ShowOwnPlaying();
				return UniTask.CompletedTask;
			};
			this.StateMap[EPlayingCardProcessState.TimeEnd] = (() => this.Proxy.RoundOver());
			this.StateMap[EPlayingCardProcessState.JumpLoading] = delegate()
			{
				this.Proxy.JumpLoading();
				return UniTask.CompletedTask;
			};
		}

		// Token: 0x060380A5 RID: 229541 RVA: 0x00E32934 File Offset: 0x00E30B34
		private UniTask SetStateAsync(EPlayingCardProcessState state)
		{
			PhantomArenaProcessManager.<SetStateAsync>d__15 <SetStateAsync>d__;
			<SetStateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetStateAsync>d__.<>4__this = this;
			<SetStateAsync>d__.state = state;
			<SetStateAsync>d__.<>1__state = -1;
			<SetStateAsync>d__.<>t__builder.Start<PhantomArenaProcessManager.<SetStateAsync>d__15>(ref <SetStateAsync>d__);
			return <SetStateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060380A6 RID: 229542 RVA: 0x00E32980 File Offset: 0x00E30B80
		private UniTask HandleStateList()
		{
			PhantomArenaProcessManager.<HandleStateList>d__16 <HandleStateList>d__;
			<HandleStateList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleStateList>d__.<>4__this = this;
			<HandleStateList>d__.<>1__state = -1;
			<HandleStateList>d__.<>t__builder.Start<PhantomArenaProcessManager.<HandleStateList>d__16>(ref <HandleStateList>d__);
			return <HandleStateList>d__.<>t__builder.Task;
		}

		// Token: 0x060380A7 RID: 229543 RVA: 0x00E329C3 File Offset: 0x00E30BC3
		public void SetState(EPlayingCardProcessState state)
		{
			this.SetStateAsync(state).Forget();
		}

		// Token: 0x060380A8 RID: 229544 RVA: 0x00E329D1 File Offset: 0x00E30BD1
		public void Clear()
		{
			this.PendingList.Clear();
			this.StateMap.Clear();
			this.IsClear = true;
		}

		// Token: 0x040200BD RID: 131261
		private readonly Dictionary<EPlayingCardProcessState, Func<UniTask>> StateMap = new Dictionary<EPlayingCardProcessState, Func<UniTask>>();

		// Token: 0x040200BE RID: 131262
		private readonly List<EPlayingCardProcessState> PendingList = new List<EPlayingCardProcessState>();

		// Token: 0x040200BF RID: 131263
		private bool IsInPending;

		// Token: 0x040200C0 RID: 131264
		private bool IsClear;

		// Token: 0x040200C1 RID: 131265
		private readonly Dictionary<EPlayingCardProcessState, List<EPlayingCardProcessState>> StateParentMap;

		// Token: 0x040200C2 RID: 131266
		private EPlayingCardProcessState StateInternal;

		// Token: 0x040200C3 RID: 131267
		protected PhantomArenaBattleProxy Proxy;
	}
}
