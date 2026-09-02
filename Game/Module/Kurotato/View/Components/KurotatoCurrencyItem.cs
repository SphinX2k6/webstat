using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Components
{
	// Token: 0x02005AC4 RID: 23236
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoCurrencyItem : CommonCurrencyItem
	{
		// Token: 0x0603ABFC RID: 240636 RVA: 0x00EE51C0 File Offset: 0x00EE33C0
		public UniTask Init(UUIItem item, EKurotatoSystemVarType currencyType)
		{
			KurotatoCurrencyItem.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.currencyType = currencyType;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<KurotatoCurrencyItem.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603ABFD RID: 240637 RVA: 0x00EE5213 File Offset: 0x00EE3413
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
			base.OnStart();
		}

		// Token: 0x0603ABFE RID: 240638 RVA: 0x00EE522C File Offset: 0x00EE342C
		public override void AddEventListener()
		{
			ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(this.CurrencyType.Value.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
		}

		// Token: 0x0603ABFF RID: 240639 RVA: 0x00EE525E File Offset: 0x00EE345E
		public override void RemoveEventListener()
		{
			ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(this.CurrencyType.Value.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
		}

		// Token: 0x0603AC00 RID: 240640 RVA: 0x00EE5290 File Offset: 0x00EE3490
		public void OnSurvivorsCurrencyUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
		{
			int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
			base.SetCount(num);
			if (lastVarDefine == null)
			{
				return;
			}
			int num2 = (int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int);
			if (num > num2)
			{
				this.SeqPlayer.PlayOrReplaySequenceByName("Acquire", false, null);
				return;
			}
			if (num < num2)
			{
				this.SeqPlayer.PlayOrReplaySequenceByName("Lose", false, null);
			}
		}

		// Token: 0x04021378 RID: 136056
		private EKurotatoSystemVarType? CurrencyType;

		// Token: 0x04021379 RID: 136057
		private LevelSequencePlayer SeqPlayer;
	}
}
