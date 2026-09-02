using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E65 RID: 20069
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseGoldCostItem : CommonCurrencyItem
	{
		// Token: 0x06033DED RID: 212461 RVA: 0x00CFA0FC File Offset: 0x00CF82FC
		public UniTask Init(UUIItem item)
		{
			TrapDefenseGoldCostItem.<Init>d__0 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseGoldCostItem.<Init>d__0>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033DEE RID: 212462 RVA: 0x00CFA147 File Offset: 0x00CF8347
		public override void AddEventListener()
		{
			ModelBase<TrapDefenseModel>.Instance.BattleData.AddTreeVarUpdateDelegate(ETrapDefenseSystemVarType.Gold, new TTreeVarUpdateDelegate(this.OnCurrentGoldUpdate));
		}

		// Token: 0x06033DEF RID: 212463 RVA: 0x00CFA165 File Offset: 0x00CF8365
		public override void RemoveEventListener()
		{
			ModelBase<TrapDefenseModel>.Instance.BattleData.RemoveTreeVarUpdateDelegate(ETrapDefenseSystemVarType.Gold, new TTreeVarUpdateDelegate(this.OnCurrentGoldUpdate));
		}

		// Token: 0x06033DF0 RID: 212464 RVA: 0x00CFA184 File Offset: 0x00CF8384
		public void OnCurrentGoldUpdate(VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
		{
			long num = Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
			base.SetCount((int)num);
		}

		// Token: 0x06033DF1 RID: 212465 RVA: 0x00CFA1AA File Offset: 0x00CF83AA
		public void UpdateGoldCostNum()
		{
			base.SetCount((int)ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum());
		}
	}
}
