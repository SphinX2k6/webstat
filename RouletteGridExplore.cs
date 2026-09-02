using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002936 RID: 10550
public class RouletteGridExplore : RouletteGridBase
{
	// Token: 0x06014F1C RID: 85788 RVA: 0x005CBCA8 File Offset: 0x005C9EA8
	protected override UniTask Init()
	{
		RouletteGridExplore.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<RouletteGridExplore.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06014F1D RID: 85789 RVA: 0x005CBCEC File Offset: 0x005C9EEC
	protected override void OnSelect(bool bSelect)
	{
		if (!bSelect)
		{
			return;
		}
		if (!base.IsDataValid() || this.Data == null)
		{
			return;
		}
		if (this.Data.State == EGridBehavior.Forbidden)
		{
			RouletteGridForbiddenSettings.TipsForbiddenState(this.Data.GridType, this.Data.Id);
			return;
		}
		if (this.Data.State == EGridBehavior.Lock)
		{
			RouletteGridForbiddenSettings.TipsLockState(this.Data.GridType, this.Data.Id);
			return;
		}
		EGridUseType useType = this.Data.UseType;
		if (useType == EGridUseType.SwitchOnly)
		{
			int id = this.Data.Id;
			ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(id, EExploreSkillLayer.Roulette, "RouletteGridExplore.OnSelect");
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(id, delegate(bool success)
			{
				if (success)
				{
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_spl_roulette_new_equip");
				}
			}, false);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ChangeVisionSkillByTab, this.Data.Id);
			return;
		}
		if (useType != EGridUseType.FunctionOnly)
		{
			return;
		}
		ControllerBase<RouletteExploreSkillController>.Instance.UseRouletteExploreId((ERouletteExploreId)this.Data.Id);
	}
}
