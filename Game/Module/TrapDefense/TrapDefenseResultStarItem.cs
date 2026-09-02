using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E23 RID: 20003
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class TrapDefenseResultStarItem : GridProxyAbstract<ITrapDefenseStarInfo>
	{
		// Token: 0x06033B73 RID: 211827 RVA: 0x00CECF64 File Offset: 0x00CEB164
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B74 RID: 211828 RVA: 0x00CECFAC File Offset: 0x00CEB1AC
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnAnimEnd), false);
		}

		// Token: 0x06033B75 RID: 211829 RVA: 0x00CECFD7 File Offset: 0x00CEB1D7
		public override void Refresh(ITrapDefenseStarInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data.IsAchieve && (!data.IsNew || data.HasPlayed));
		}

		// Token: 0x06033B76 RID: 211830 RVA: 0x00CED010 File Offset: 0x00CEB210
		public void PlayAnim()
		{
			if (this.Data.IsNew && !this.Data.HasPlayed)
			{
				if (this.Data.PlayDelay <= 0)
				{
					UUIItem item = base.GetItem(0);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer == null)
					{
						return;
					}
					levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
					return;
				}
				else
				{
					TimerSystem.Instance.Delay(delegate(float _)
					{
						UUIItem item2 = base.GetItem(0);
						if (item2 != null)
						{
							item2.SetUIActive(true);
						}
						LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
						if (levelSequencePlayer2 == null)
						{
							return;
						}
						levelSequencePlayer2.PlayOrReplaySequenceByName("Start", false, null);
					}, (float)this.Data.PlayDelay, null, null, true, 1f);
				}
			}
		}

		// Token: 0x06033B77 RID: 211831 RVA: 0x00CED0A3 File Offset: 0x00CEB2A3
		private void OnAnimEnd(string name)
		{
			this.Data.HasPlayed = true;
		}

		// Token: 0x0401DF15 RID: 122645
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401DF16 RID: 122646
		private ITrapDefenseStarInfo Data;
	}
}
