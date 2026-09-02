using System;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002935 RID: 10549
public class RouletteGridEquipItem : RouletteGridBase
{
	// Token: 0x06014F19 RID: 85785 RVA: 0x005CBBC8 File Offset: 0x005C9DC8
	protected override UniTask Init()
	{
		RouletteGridEquipItem.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<RouletteGridEquipItem.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06014F1A RID: 85786 RVA: 0x005CBC0C File Offset: 0x005C9E0C
	protected override void OnSelect(bool bSelect)
	{
		if (!bSelect)
		{
			return;
		}
		if (this.Data == null || this.Data.State != EGridBehavior.Normal)
		{
			return;
		}
		if (this.Data.Id == 0)
		{
			ControllerBase<RouletteController>.Instance.OpenEmptyTips();
			return;
		}
		if (base.IsDataValid())
		{
			ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(3001, EExploreSkillLayer.Roulette, "RouletteGridEquipItem.OnSelect");
			ControllerBase<RouletteController>.Instance.EquipItemSetRequest(this.Data.Id, delegate(bool success)
			{
				if (success)
				{
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_spl_roulette_new_equip");
				}
			}, EExploreSkillLayer.Roulette);
		}
	}
}
