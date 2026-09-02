using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB6 RID: 24502
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleDungeonGuideButton : BattleEntranceButton
	{
		// Token: 0x0603D9C0 RID: 252352 RVA: 0x00FB227E File Offset: 0x00FB047E
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			if (param == null)
			{
				return;
			}
			this.AddEvents();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603D9C1 RID: 252353 RVA: 0x00FB22A2 File Offset: 0x00FB04A2
		public override void Reset()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603D9C2 RID: 252354 RVA: 0x00FB22C8 File Offset: 0x00FB04C8
		protected void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoleIntroductionViewHide, new Action(this.OnRoleIntroductionViewHide));
		}

		// Token: 0x0603D9C3 RID: 252355 RVA: 0x00FB22E6 File Offset: 0x00FB04E6
		protected void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleIntroductionViewHide, new Action(this.OnRoleIntroductionViewHide));
		}

		// Token: 0x0603D9C4 RID: 252356 RVA: 0x00FB2304 File Offset: 0x00FB0504
		private void OnRoleIntroductionViewHide()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Shouqi", false, null, false);
		}

		// Token: 0x0402295F RID: 141663
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
