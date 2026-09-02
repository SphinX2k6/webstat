using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006414 RID: 25620
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTopHudHook : IBattleTopPanelHook
	{
		// Token: 0x06040524 RID: 263460 RVA: 0x0107CFC4 File Offset: 0x0107B1C4
		public UniTask OnInitAsync(TopPanel topPanel)
		{
			RoverlikeTopHudHook.<OnInitAsync>d__2 <OnInitAsync>d__;
			<OnInitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnInitAsync>d__.<>4__this = this;
			<OnInitAsync>d__.topPanel = topPanel;
			<OnInitAsync>d__.<>1__state = -1;
			<OnInitAsync>d__.<>t__builder.Start<RoverlikeTopHudHook.<OnInitAsync>d__2>(ref <OnInitAsync>d__);
			return <OnInitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040525 RID: 263461 RVA: 0x0107D00F File Offset: 0x0107B20F
		public void OnShow(TopPanel topPanel)
		{
			if (this.HudPanel == null)
			{
				return;
			}
			this.ApplyHide(true);
			this.HudPanel.StartShow();
		}

		// Token: 0x06040526 RID: 263462 RVA: 0x0107D02C File Offset: 0x0107B22C
		public void OnHide(TopPanel topPanel)
		{
			RoverlikeBattleTopPanel hudPanel = this.HudPanel;
			if (hudPanel == null)
			{
				return;
			}
			hudPanel.EndShow();
		}

		// Token: 0x06040527 RID: 263463 RVA: 0x0107D03E File Offset: 0x0107B23E
		public void OnAddEventListener(TopPanel topPanel)
		{
		}

		// Token: 0x06040528 RID: 263464 RVA: 0x0107D040 File Offset: 0x0107B240
		public void OnRemoveEventListener(TopPanel topPanel)
		{
		}

		// Token: 0x06040529 RID: 263465 RVA: 0x0107D042 File Offset: 0x0107B242
		public void OnRefresh(TopPanel topPanel)
		{
			this.ApplyHide(true);
		}

		// Token: 0x0604052A RID: 263466 RVA: 0x0107D04B File Offset: 0x0107B24B
		public void OnReset(TopPanel topPanel)
		{
			this.ApplyHide(false);
			this.HudPanel = null;
		}

		// Token: 0x0604052B RID: 263467 RVA: 0x0107D05C File Offset: 0x0107B25C
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

		// Token: 0x0604052C RID: 263468 RVA: 0x0107D0C8 File Offset: 0x0107B2C8
		public unsafe RoverlikeTopHudHook()
		{
			int num = 7;
			List<EBattleUiChild> list = new List<EBattleUiChild>(num);
			CollectionsMarshal.SetCount<EBattleUiChild>(list, num);
			Span<EBattleUiChild> span = CollectionsMarshal.AsSpan<EBattleUiChild>(list);
			int num2 = 0;
			*span[num2] = EBattleUiChild.MiniMap;
			num2++;
			*span[num2] = EBattleUiChild.TopButton;
			num2++;
			*span[num2] = EBattleUiChild.HomeButton;
			num2++;
			*span[num2] = EBattleUiChild.ExitButton;
			num2++;
			*span[num2] = EBattleUiChild.Formation;
			num2++;
			*span[num2] = EBattleUiChild.GamepadFormation;
			num2++;
			*span[num2] = EBattleUiChild.Chat;
			this.HideChildren = list;
			base..ctor();
		}

		// Token: 0x040240C3 RID: 147651
		[Nullable(2)]
		private RoverlikeBattleTopPanel HudPanel;

		// Token: 0x040240C4 RID: 147652
		private readonly List<EBattleUiChild> HideChildren;
	}
}
