using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B66 RID: 11110
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCurrencyItem : CommonCurrencyItem
{
	// Token: 0x06016242 RID: 90690 RVA: 0x006250DC File Offset: 0x006232DC
	public UniTask Init(UUIItem item)
	{
		SurvivorsRogueCurrencyItem.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<SurvivorsRogueCurrencyItem.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06016243 RID: 90691 RVA: 0x00625127 File Offset: 0x00623327
	public override void AddEventListener()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
	}

	// Token: 0x06016244 RID: 90692 RVA: 0x0062514F File Offset: 0x0062334F
	public override void RemoveEventListener()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
	}

	// Token: 0x06016245 RID: 90693 RVA: 0x00625178 File Offset: 0x00623378
	private void OnSurvivorsCurrencyUpdate(VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		long num = Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		base.SetCount((int)num);
	}
}
