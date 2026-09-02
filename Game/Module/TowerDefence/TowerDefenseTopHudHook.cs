using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE6 RID: 20198
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseTopHudHook : IBattleTopPanelHook
	{
		// Token: 0x060342A7 RID: 213671 RVA: 0x00D0B600 File Offset: 0x00D09800
		public UniTask OnInitAsync(TopPanel topPanel)
		{
			TowerDefenseTopHudHook.<OnInitAsync>d__1 <OnInitAsync>d__;
			<OnInitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnInitAsync>d__.<>4__this = this;
			<OnInitAsync>d__.<>1__state = -1;
			<OnInitAsync>d__.<>t__builder.Start<TowerDefenseTopHudHook.<OnInitAsync>d__1>(ref <OnInitAsync>d__);
			return <OnInitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060342A8 RID: 213672 RVA: 0x00D0B643 File Offset: 0x00D09843
		public void OnShow(TopPanel topPanel)
		{
			this.ApplyHide(true);
		}

		// Token: 0x060342A9 RID: 213673 RVA: 0x00D0B64C File Offset: 0x00D0984C
		public void OnHide(TopPanel topPanel)
		{
		}

		// Token: 0x060342AA RID: 213674 RVA: 0x00D0B64E File Offset: 0x00D0984E
		public void OnAddEventListener(TopPanel topPanel)
		{
		}

		// Token: 0x060342AB RID: 213675 RVA: 0x00D0B650 File Offset: 0x00D09850
		public void OnRemoveEventListener(TopPanel topPanel)
		{
		}

		// Token: 0x060342AC RID: 213676 RVA: 0x00D0B652 File Offset: 0x00D09852
		public void OnRefresh(TopPanel topPanel)
		{
			this.ApplyHide(true);
		}

		// Token: 0x060342AD RID: 213677 RVA: 0x00D0B65B File Offset: 0x00D0985B
		public void OnReset(TopPanel topPanel)
		{
			this.ApplyHide(false);
		}

		// Token: 0x060342AE RID: 213678 RVA: 0x00D0B664 File Offset: 0x00D09864
		private void ApplyHide(bool hide)
		{
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData == null)
			{
				return;
			}
			foreach (EBattleUiChild childType in this.HideChildren)
			{
				childViewData.SetChildVisible(EBattleUiVisibleReason.Custom, childType, !hide, true, 0);
			}
		}

		// Token: 0x0401E1D6 RID: 123350
		private readonly EBattleUiChild[] HideChildren = new EBattleUiChild[]
		{
			EBattleUiChild.TopButton,
			EBattleUiChild.HomeButton
		};
	}
}
