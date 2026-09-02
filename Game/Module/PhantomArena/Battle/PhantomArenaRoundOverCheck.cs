using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x020055A5 RID: 21925
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoundOverCheck
	{
		// Token: 0x17008FCF RID: 36815
		// (get) Token: 0x06037CDA RID: 228570 RVA: 0x00E236DE File Offset: 0x00E218DE
		public bool HasAnyOperation
		{
			get
			{
				return this.HasAnyOperationInternal;
			}
		}

		// Token: 0x06037CDB RID: 228571 RVA: 0x00E236E8 File Offset: 0x00E218E8
		public PhantomArenaRoundOverCheck(PhantomArenaBattleProxy proxy)
		{
			this.Proxy = proxy;
			int phantomArenaRoundOverCheck = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaRoundOverCheck();
			this.DelayTime = phantomArenaRoundOverCheck * 1000;
		}

		// Token: 0x17008FD0 RID: 36816
		// (get) Token: 0x06037CDC RID: 228572 RVA: 0x00E23721 File Offset: 0x00E21921
		// (set) Token: 0x06037CDD RID: 228573 RVA: 0x00E23729 File Offset: 0x00E21929
		private protected PhantomArenaBattleProxy Proxy { protected get; private set; }

		// Token: 0x06037CDE RID: 228574 RVA: 0x00E23732 File Offset: 0x00E21932
		private void RemoveTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06037CDF RID: 228575 RVA: 0x00E23754 File Offset: 0x00E21954
		private void AddTimer()
		{
			this.HasAnyOperationInternal = true;
			this.Proxy.HideRoundOverEffect();
			if (this.Proxy.CheckRepeatCondition())
			{
				Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "PhantomArenaRoundOverCheck检测无操作条件满足", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.HasAnyOperationInternal = false;
					this.Proxy.PlayRoundOverEffect();
					this.TimerHandle = null;
				}, (float)this.DelayTime, null, null, true, 1f);
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.PhantomArena, ELogAuthor.XXJ, "PhantomArenaRoundOverCheck检测无操作条件不满足", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06037CE0 RID: 228576 RVA: 0x00E237EA File Offset: 0x00E219EA
		public void StartCheck()
		{
			this.AddTimer();
		}

		// Token: 0x06037CE1 RID: 228577 RVA: 0x00E237F2 File Offset: 0x00E219F2
		public void RepeatCheck()
		{
			this.RemoveTimer();
			this.AddTimer();
		}

		// Token: 0x06037CE2 RID: 228578 RVA: 0x00E23800 File Offset: 0x00E21A00
		public void Clear()
		{
			this.HasAnyOperationInternal = false;
			this.RemoveTimer();
		}

		// Token: 0x0401FF48 RID: 130888
		protected bool HasAnyOperationInternal = true;

		// Token: 0x0401FF49 RID: 130889
		protected int DelayTime;

		// Token: 0x0401FF4A RID: 130890
		protected TimerHandle TimerHandle;
	}
}
