using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.GameMainView.PinballBattle
{
	// Token: 0x02005D15 RID: 23829
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleMainViewProxy : GameMainViewProxy
	{
		// Token: 0x17009866 RID: 39014
		// (get) Token: 0x0603C0F8 RID: 246008 RVA: 0x00F3C2C8 File Offset: 0x00F3A4C8
		protected override EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0603C0F9 RID: 246009 RVA: 0x00F3C2DE File Offset: 0x00F3A4DE
		protected override bool ShouldCreateJoystickPanel()
		{
			return false;
		}

		// Token: 0x0603C0FA RID: 246010 RVA: 0x00F3C2E1 File Offset: 0x00F3A4E1
		protected override void OnAfterShow()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Default, PinballBattleMainViewProxy.pinballChildren, true, true, 0);
		}

		// Token: 0x0603C0FB RID: 246011 RVA: 0x00F3C2FB File Offset: 0x00F3A4FB
		protected override void OnAfterHide()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Default, PinballBattleMainViewProxy.pinballChildren, false, true, 0);
		}

		// Token: 0x0603C0FC RID: 246012 RVA: 0x00F3C318 File Offset: 0x00F3A518
		protected override UniTask OnBeforeStartAsync()
		{
			PinballBattleMainViewProxy.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballBattleMainViewProxy.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0FD RID: 246013 RVA: 0x00F3C35B File Offset: 0x00F3A55B
		protected override void OnStart()
		{
			UUIItem originalItem = this.BattlePanel.GetOriginalItem();
			if (originalItem == null)
			{
				return;
			}
			originalItem.SetAsFirstHierarchy();
		}

		// Token: 0x0603C0FE RID: 246014 RVA: 0x00F3C374 File Offset: 0x00F3A574
		private UniTask CreateBattlePanel()
		{
			PinballBattleMainViewProxy.<CreateBattlePanel>d__9 <CreateBattlePanel>d__;
			<CreateBattlePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBattlePanel>d__.<>4__this = this;
			<CreateBattlePanel>d__.<>1__state = -1;
			<CreateBattlePanel>d__.<>t__builder.Start<PinballBattleMainViewProxy.<CreateBattlePanel>d__9>(ref <CreateBattlePanel>d__);
			return <CreateBattlePanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0FF RID: 246015 RVA: 0x00F3C3B8 File Offset: 0x00F3A5B8
		protected override UniTask OnPlayingHideSequenceAsync()
		{
			PinballBattleMainViewProxy.<OnPlayingHideSequenceAsync>d__10 <OnPlayingHideSequenceAsync>d__;
			<OnPlayingHideSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingHideSequenceAsync>d__.<>4__this = this;
			<OnPlayingHideSequenceAsync>d__.<>1__state = -1;
			<OnPlayingHideSequenceAsync>d__.<>t__builder.Start<PinballBattleMainViewProxy.<OnPlayingHideSequenceAsync>d__10>(ref <OnPlayingHideSequenceAsync>d__);
			return <OnPlayingHideSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04021BC7 RID: 138183
		[StaticVariableRuleIgnore]
		private static readonly EBattleUiChild[] pinballChildren = new EBattleUiChild[]
		{
			EBattleUiChild.Common,
			EBattleUiChild.DamageView,
			EBattleUiChild.PositionOfficial
		};

		// Token: 0x04021BC8 RID: 138184
		public PinballBattleMainBattlePanel BattlePanel;
	}
}
