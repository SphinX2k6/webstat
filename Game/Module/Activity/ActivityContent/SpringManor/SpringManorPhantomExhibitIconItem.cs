using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006311 RID: 25361
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpringManorPhantomExhibitIconItem : LoopScrollSmallItemGrid<SpringManorPhantomDisplayItem>
	{
		// Token: 0x0603FBE6 RID: 261094 RVA: 0x0105776A File Offset: 0x0105596A
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603FBE7 RID: 261095 RVA: 0x01057774 File Offset: 0x01055974
		protected override void OnRefresh(SpringManorPhantomDisplayItem data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x0603FBE8 RID: 261096 RVA: 0x01057780 File Offset: 0x01055980
		public void Refresh(SpringManorPhantomDisplayItem data)
		{
			this.PhantomId = data.PhantomId;
			PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.PhantomId);
			if (phantomItemById == null)
			{
				return;
			}
			if (ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(phantomItemById.Value.MonsterId) == null)
			{
				return;
			}
			PhantomSmallItemGrid parameters = new PhantomSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.PhantomId),
				IsQualityHidden = new bool?(true)
			};
			base.Apply<PhantomSmallItemGrid>(parameters);
		}

		// Token: 0x04023C77 RID: 146551
		private int PhantomId;
	}
}
