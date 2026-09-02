using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051C5 RID: 20933
	public class RogueBattleBuyRoleStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06035D04 RID: 220420 RVA: 0x00D89D44 File Offset: 0x00D87F44
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06035D05 RID: 220421 RVA: 0x00D89DCA File Offset: 0x00D87FCA
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06035D06 RID: 220422 RVA: 0x00D89DDD File Offset: 0x00D87FDD
		public override void Refresh(bool isOn, bool isSelected, int gridIndex)
		{
			base.GetSprite(0).SetUIActive(true);
			base.GetSprite(1).SetUIActive(isOn);
			this.SetPreviewAnimOn(false);
		}

		// Token: 0x06035D07 RID: 220423 RVA: 0x00D89E00 File Offset: 0x00D88000
		public void SetPreviewAnimOn(bool bOn)
		{
			base.GetSprite(2).SetUIActive(bOn);
			base.GetItem(3).SetUIActive(bOn);
			base.GetItem(4).SetUIActive(bOn);
			if (bOn)
			{
				if (this.LevelSequencePlayer.GetCurrentSequence() == "Light")
				{
					this.LevelSequencePlayer.ReplaySequenceByKey("Light");
					return;
				}
				this.LevelSequencePlayer.StopPlayingSequence(false, true);
				this.LevelSequencePlayer.PlayLevelSequenceByName("Light", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.StopSequenceByKey("Light", false, false);
				return;
			}
		}

		// Token: 0x0401EDF3 RID: 126451
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
