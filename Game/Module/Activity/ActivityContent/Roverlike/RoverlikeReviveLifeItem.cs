using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006412 RID: 25618
	public class RoverlikeReviveLifeItem : GridProxyAbstract<bool>
	{
		// Token: 0x06040516 RID: 263446 RVA: 0x0107CC34 File Offset: 0x0107AE34
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

		// Token: 0x06040517 RID: 263447 RVA: 0x0107CC7C File Offset: 0x0107AE7C
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06040518 RID: 263448 RVA: 0x0107CC8F File Offset: 0x0107AE8F
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x06040519 RID: 263449 RVA: 0x0107CCAC File Offset: 0x0107AEAC
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			bool? isAvailable = this.IsAvailable;
			if (isAvailable.GetValueOrDefault() == data & isAvailable != null)
			{
				return;
			}
			this.IsAvailable = new bool?(data);
			this.OnStateChange(data);
		}

		// Token: 0x0604051A RID: 263450 RVA: 0x0107CCEC File Offset: 0x0107AEEC
		private void OnStateChange(bool newState)
		{
			UUIItem item = base.GetItem(0);
			if (!newState)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.StopSequenceByKey("Get", false, true);
				}
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return;
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 == null)
			{
				return;
			}
			sequencePlayer2.PlayLevelSequenceByName("Get", false, null, false);
		}

		// Token: 0x040240BF RID: 147647
		[Nullable(1)]
		private const string NEWLY_ACQUIRED_LIFE_SEQ = "Get";

		// Token: 0x040240C0 RID: 147648
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x040240C1 RID: 147649
		private bool? IsAvailable;

		// Token: 0x0200C480 RID: 50304
		private class EChildType
		{
			// Token: 0x0403C7C7 RID: 247751
			public const int SprLight = 0;
		}
	}
}
