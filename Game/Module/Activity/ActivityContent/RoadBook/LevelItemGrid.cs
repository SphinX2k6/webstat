using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006497 RID: 25751
	public class LevelItemGrid : GridProxyAbstract<int>
	{
		// Token: 0x0604094B RID: 264523 RVA: 0x0108D9E4 File Offset: 0x0108BBE4
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

		// Token: 0x0604094C RID: 264524 RVA: 0x0108DA54 File Offset: 0x0108BC54
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0604094D RID: 264525 RVA: 0x0108DA67 File Offset: 0x0108BC67
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

		// Token: 0x0604094E RID: 264526 RVA: 0x0108DAA2 File Offset: 0x0108BCA2
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

		// Token: 0x0604094F RID: 264527 RVA: 0x0108DACC File Offset: 0x0108BCCC
		public override void OnSelected(bool fireEvent)
		{
			this.SetIsCurrentLevelItem(true);
		}

		// Token: 0x06040950 RID: 264528 RVA: 0x0108DAD8 File Offset: 0x0108BCD8
		public void PlayLevelUpAnim()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("LevelUp", false, null, false);
		}

		// Token: 0x06040951 RID: 264529 RVA: 0x0108DB08 File Offset: 0x0108BD08
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

		// Token: 0x06040952 RID: 264530 RVA: 0x0108DB5C File Offset: 0x0108BD5C
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

		// Token: 0x0402425F RID: 148063
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
