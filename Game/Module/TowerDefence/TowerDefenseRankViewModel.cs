using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA3 RID: 20131
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankViewModel
	{
		// Token: 0x06034037 RID: 213047 RVA: 0x00D02FF4 File Offset: 0x00D011F4
		public void RegisterView(TowerDefenseRankView view)
		{
			this.View = view;
		}

		// Token: 0x06034038 RID: 213048 RVA: 0x00D03000 File Offset: 0x00D01200
		public UniTask RequestRankData()
		{
			TowerDefenseRankViewModel.<RequestRankData>d__4 <RequestRankData>d__;
			<RequestRankData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRankData>d__.<>4__this = this;
			<RequestRankData>d__.<>1__state = -1;
			<RequestRankData>d__.<>t__builder.Start<TowerDefenseRankViewModel.<RequestRankData>d__4>(ref <RequestRankData>d__);
			return <RequestRankData>d__.<>t__builder.Task;
		}

		// Token: 0x06034039 RID: 213049 RVA: 0x00D03044 File Offset: 0x00D01244
		public void ToggleAnonymousClick(EToggleState state)
		{
			bool isOpenAnonymousName = state == EToggleState.ETT_Checked;
			ControllerBase<TowerDefenseController>.Instance.RequestRankShowName(!isOpenAnonymousName, delegate
			{
				ModelBase<TowerDefenseModel>.Instance.RankData.SetIsOpenAnonymousName(isOpenAnonymousName);
				ModelBase<TowerDefenseModel>.Instance.RankData.RefreshSelfRankItemDataName(this.InstanceId);
				this.View.RefreshContentShowName();
			});
		}

		// Token: 0x0603403A RID: 213050 RVA: 0x00D03088 File Offset: 0x00D01288
		public void TabItemToggle(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenceDefine.ETabType? currentType = this.CurrentType;
			this.CurrentType = new TowerDefenceDefine.ETabType?(tabType);
			if (currentType != null)
			{
				this.View.ResetLastTabItemSelected(currentType.Value);
			}
			this.View.RefreshContent(this.CurrentType.Value);
		}

		// Token: 0x0603403B RID: 213051 RVA: 0x00D030DC File Offset: 0x00D012DC
		public bool TabItemCanExecuteChange(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenceDefine.ETabType? currentType = this.CurrentType;
			return !(currentType.GetValueOrDefault() == tabType & currentType != null);
		}

		// Token: 0x0401E0FC RID: 123132
		private TowerDefenceDefine.ETabType? CurrentType;

		// Token: 0x0401E0FD RID: 123133
		public int InstanceId;

		// Token: 0x0401E0FE RID: 123134
		private TowerDefenseRankView View;
	}
}
