using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x0200551A RID: 21786
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class RewardPanelItem : GridProxyAbstract<RewardTuple>
	{
		// Token: 0x0603792A RID: 227626 RVA: 0x00E191AF File Offset: 0x00E173AF
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x0603792B RID: 227627 RVA: 0x00E191D4 File Offset: 0x00E173D4
		protected override void OnStart()
		{
			AActor owner = base.GetItem(0).GetOwner();
			this.Grid = new CommonItemSmallItemGrid();
			this.Grid.Initialize(owner);
		}

		// Token: 0x0603792C RID: 227628 RVA: 0x00E19208 File Offset: 0x00E17408
		public override void Refresh(RewardTuple data, bool isSelected, int gridIndex)
		{
			this.RewardData = data;
			this.Grid.RefreshByConfigId(this.RewardData.Id, new int?(this.RewardData.Num), null, false, false);
			this.Grid.SetReceivedVisible(this.RewardData.Taken);
		}

		// Token: 0x0603792D RID: 227629 RVA: 0x00E1925B File Offset: 0x00E1745B
		protected override void OnBeforeDestroy()
		{
			this.RewardData = null;
		}

		// Token: 0x0401FDDD RID: 130525
		private RewardTuple RewardData;

		// Token: 0x0401FDDE RID: 130526
		private CommonItemSmallItemGrid Grid;

		// Token: 0x0200B4AB RID: 46251
		[NullableContext(0)]
		private static class EItemComponents
		{
			// Token: 0x04037ED5 RID: 229077
			public const int ButtonItem = 0;
		}
	}
}
