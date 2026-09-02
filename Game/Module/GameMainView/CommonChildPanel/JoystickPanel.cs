using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.CommonChildPanel
{
	// Token: 0x02005D17 RID: 23831
	[NullableContext(2)]
	[Nullable(0)]
	public class JoystickPanel : BattleChildViewPanel
	{
		// Token: 0x0603C14B RID: 246091 RVA: 0x00F3C67C File Offset: 0x00F3A87C
		public override void InitializeTemp()
		{
			this.CurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		}

		// Token: 0x0603C14C RID: 246092 RVA: 0x00F3C690 File Offset: 0x00F3A890
		public override UniTask InitializeAsync()
		{
			JoystickPanel.<InitializeAsync>d__5 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<JoystickPanel.<InitializeAsync>d__5>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C14D RID: 246093 RVA: 0x00F3C6D3 File Offset: 0x00F3A8D3
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			Joystick joystick = this.Joystick;
			if (joystick == null)
			{
				return;
			}
			joystick.ShowBattleVisibleChildView();
		}

		// Token: 0x0603C14E RID: 246094 RVA: 0x00F3C6E5 File Offset: 0x00F3A8E5
		protected override void OnHideBattleChildViewPanel()
		{
			Joystick joystick = this.Joystick;
			if (joystick == null)
			{
				return;
			}
			joystick.HideBattleVisibleChildView();
		}

		// Token: 0x0603C14F RID: 246095 RVA: 0x00F3C6F7 File Offset: 0x00F3A8F7
		public override void OnTickBattleChildViewPanel(float delta)
		{
			Joystick joystick = this.Joystick;
			if (joystick == null)
			{
				return;
			}
			joystick.Tick(delta);
		}

		// Token: 0x0603C150 RID: 246096 RVA: 0x00F3C70A File Offset: 0x00F3A90A
		public override void Reset()
		{
			this.Joystick = null;
		}

		// Token: 0x0603C151 RID: 246097 RVA: 0x00F3C713 File Offset: 0x00F3A913
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRoleCompleted));
		}

		// Token: 0x0603C152 RID: 246098 RVA: 0x00F3C731 File Offset: 0x00F3A931
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRoleCompleted));
		}

		// Token: 0x0603C153 RID: 246099 RVA: 0x00F3C750 File Offset: 0x00F3A950
		private UniTask NewJoystickItem()
		{
			JoystickPanel.<NewJoystickItem>d__12 <NewJoystickItem>d__;
			<NewJoystickItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewJoystickItem>d__.<>4__this = this;
			<NewJoystickItem>d__.<>1__state = -1;
			<NewJoystickItem>d__.<>t__builder.Start<JoystickPanel.<NewJoystickItem>d__12>(ref <NewJoystickItem>d__);
			return <NewJoystickItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603C154 RID: 246100 RVA: 0x00F3C794 File Offset: 0x00F3A994
		private void RefreshJoystick()
		{
			if (this.Joystick != null && this.CurrentEntity != null)
			{
				base.ClearAllTagSignificantChangedCallback();
				base.ListenForTagSignificantChanged(this.CurrentEntity, JoystickPanel.ForbidMoveTagId, delegate(int _, bool tagExists)
				{
					this.Joystick.SetForbidMove(tagExists);
				});
				this.Joystick.SetForbidMove(base.ContainsTag(this.CurrentEntity, JoystickPanel.ForbidMoveTagId));
			}
		}

		// Token: 0x0603C155 RID: 246101 RVA: 0x00F3C7F0 File Offset: 0x00F3A9F0
		private void OnChangeRoleCompleted(int newEntityId, int oldEntityId)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			this.CurrentEntity = curRoleData.EntityHandle;
			this.RefreshJoystick();
		}

		// Token: 0x04021BDE RID: 138206
		[StaticVariableRuleIgnore]
		private static readonly int ForbidMoveTagId = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"];

		// Token: 0x04021BDF RID: 138207
		private Joystick Joystick;

		// Token: 0x04021BE0 RID: 138208
		private EntityHandle CurrentEntity;

		// Token: 0x04021BE1 RID: 138209
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat JoystickPanelTickStats = Stat.Create("JoystickPanelTickStats", "", "");
	}
}
