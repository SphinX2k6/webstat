using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A80 RID: 27264
	public class TuningStandGridLine : UiPanelBase
	{
		// Token: 0x06043700 RID: 276224 RVA: 0x0115FB8D File Offset: 0x0115DD8D
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06043701 RID: 276225 RVA: 0x0115FBC6 File Offset: 0x0115DDC6
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06043702 RID: 276226 RVA: 0x0115FBFE File Offset: 0x0115DDFE
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06043703 RID: 276227 RVA: 0x0115FC08 File Offset: 0x0115DE08
		public void Refresh(bool isVisible, EGridBelongType type = EGridBelongType.Empty)
		{
			if (isVisible)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(type == EGridBelongType.Type1);
				}
				UUIItem item2 = base.GetItem(0);
				if (item2 != null)
				{
					item2.SetUIActive(type == EGridBelongType.Type2);
				}
			}
			if (!isVisible || this.CurVisible)
			{
				if (!isVisible && this.CurVisible)
				{
					this.CurVisible = false;
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.StopCurrentSequence(false, false);
					}
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 == null)
					{
						return;
					}
					levelSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
				}
				return;
			}
			this.CurVisible = true;
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
			if (levelSequencePlayer4 == null)
			{
				return;
			}
			levelSequencePlayer4.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06043704 RID: 276228 RVA: 0x0115FCCF File Offset: 0x0115DECF
		public void HideLine()
		{
			this.CurVisible = false;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x04025A8B RID: 154251
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04025A8C RID: 154252
		protected bool CurVisible;
	}
}
