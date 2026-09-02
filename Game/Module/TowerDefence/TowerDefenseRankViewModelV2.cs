using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA4 RID: 20132
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankViewModelV2
	{
		// Token: 0x0603403D RID: 213053 RVA: 0x00D03111 File Offset: 0x00D01311
		public void RegisterView(TowerDefenseRankViewV2 view)
		{
			this.View = view;
		}

		// Token: 0x0603403E RID: 213054 RVA: 0x00D0311C File Offset: 0x00D0131C
		public UniTask RequestRankData()
		{
			TowerDefenseRankViewModelV2.<RequestRankData>d__4 <RequestRankData>d__;
			<RequestRankData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRankData>d__.<>4__this = this;
			<RequestRankData>d__.<>1__state = -1;
			<RequestRankData>d__.<>t__builder.Start<TowerDefenseRankViewModelV2.<RequestRankData>d__4>(ref <RequestRankData>d__);
			return <RequestRankData>d__.<>t__builder.Task;
		}

		// Token: 0x0603403F RID: 213055 RVA: 0x00D03160 File Offset: 0x00D01360
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

		// Token: 0x06034040 RID: 213056 RVA: 0x00D031A4 File Offset: 0x00D013A4
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

		// Token: 0x06034041 RID: 213057 RVA: 0x00D031F8 File Offset: 0x00D013F8
		public bool TabItemCanExecuteChange(TowerDefenceDefine.ETabType tabType)
		{
			TowerDefenceDefine.ETabType? currentType = this.CurrentType;
			return !(currentType.GetValueOrDefault() == tabType & currentType != null);
		}

		// Token: 0x0401E0FF RID: 123135
		public int InstanceId;

		// Token: 0x0401E100 RID: 123136
		private TowerDefenseRankViewV2 View;

		// Token: 0x0401E101 RID: 123137
		private TowerDefenceDefine.ETabType? CurrentType;
	}
}
