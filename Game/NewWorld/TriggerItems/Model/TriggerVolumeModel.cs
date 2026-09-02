using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.TriggerItems.Model
{
	// Token: 0x020047D8 RID: 18392
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TriggerVolumeModel : ModelBase<TriggerVolumeModel>
	{
		// Token: 0x0602FB55 RID: 195413 RVA: 0x00B6A92D File Offset: 0x00B68B2D
		protected override bool OnInit()
		{
			this.TriggerVolumeCache = new Dictionary<int, Dictionary<int, TsTriggerVolume>>();
			return true;
		}

		// Token: 0x0602FB56 RID: 195414 RVA: 0x00B6A93C File Offset: 0x00B68B3C
		public void AddTriggerVolume(int groupId, int index, TsTriggerVolume tsTriggerVolume)
		{
			Dictionary<int, TsTriggerVolume> dictionary;
			if (!this.TriggerVolumeCache.TryGetValue(groupId, out dictionary))
			{
				dictionary = new Dictionary<int, TsTriggerVolume>();
				this.TriggerVolumeCache[groupId] = dictionary;
			}
			dictionary[index] = tsTriggerVolume;
		}

		// Token: 0x0602FB57 RID: 195415 RVA: 0x00B6A974 File Offset: 0x00B68B74
		public void RemoveTriggerVolume(int groupId, int index)
		{
			Dictionary<int, TsTriggerVolume> dictionary;
			if (!this.TriggerVolumeCache.TryGetValue(groupId, out dictionary))
			{
				return;
			}
			dictionary.Remove(index);
		}

		// Token: 0x0602FB58 RID: 195416 RVA: 0x00B6A99C File Offset: 0x00B68B9C
		[NullableContext(2)]
		public TsTriggerVolume GetTriggerVolume(int groupId, int index)
		{
			Dictionary<int, TsTriggerVolume> dictionary;
			if (!this.TriggerVolumeCache.TryGetValue(groupId, out dictionary))
			{
				return null;
			}
			TsTriggerVolume result;
			if (!dictionary.TryGetValue(index, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602FB59 RID: 195417 RVA: 0x00B6A9C9 File Offset: 0x00B68BC9
		protected override bool OnClear()
		{
			this.TriggerVolumeCache = null;
			return true;
		}

		// Token: 0x0401B553 RID: 111955
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, Dictionary<int, TsTriggerVolume>> TriggerVolumeCache;
	}
}
