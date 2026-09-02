using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200653A RID: 25914
	public class LevelItemGrid : GridProxyAbstract<int>
	{
		// Token: 0x06040CA3 RID: 265379 RVA: 0x0109CEDC File Offset: 0x0109B0DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIArtText))
			};
		}

		// Token: 0x06040CA4 RID: 265380 RVA: 0x0109CF4C File Offset: 0x0109B14C
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06040CA5 RID: 265381 RVA: 0x0109CF5F File Offset: 0x0109B15F
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			UUIArtText artText = base.GetArtText(1);
			if (artText != null)
			{
				artText.SetText(data.ToString());
			}
			UUIArtText artText2 = base.GetArtText(3);
			if (artText2 != null)
			{
				artText2.SetText(data.ToString());
			}
			this.SetIsCurrentLevelItem(isSelected);
		}

		// Token: 0x06040CA6 RID: 265382 RVA: 0x0109CF9A File Offset: 0x0109B19A
		public void SetIsCurrentLevelItem(bool isActive)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(isActive);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!isActive);
		}

		// Token: 0x06040CA7 RID: 265383 RVA: 0x0109CFC4 File Offset: 0x0109B1C4
		public override void OnSelected(bool fireEvent)
		{
			this.SetIsCurrentLevelItem(true);
		}

		// Token: 0x06040CA8 RID: 265384 RVA: 0x0109CFD0 File Offset: 0x0109B1D0
		public void PlayLevelUpAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("LevelUp", false, null, false);
		}

		// Token: 0x06040CA9 RID: 265385 RVA: 0x0109D000 File Offset: 0x0109B200
		public void PlayBigAnim()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("TtoA", false, null, false);
		}

		// Token: 0x06040CAA RID: 265386 RVA: 0x0109D054 File Offset: 0x0109B254
		public void PlaySmallAnim()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("AtoT", false, null, false);
		}

		// Token: 0x04024569 RID: 148841
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
