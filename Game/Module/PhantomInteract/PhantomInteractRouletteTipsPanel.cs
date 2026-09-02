using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomInteract
{
	// Token: 0x02005462 RID: 21602
	public class PhantomInteractRouletteTipsPanel : UiPanelBase
	{
		// Token: 0x0603705F RID: 225375 RVA: 0x00DF7698 File Offset: 0x00DF5898
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06037060 RID: 225376 RVA: 0x00DF76F4 File Offset: 0x00DF58F4
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomInteractRouletteTipsPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomInteractRouletteTipsPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037061 RID: 225377 RVA: 0x00DF7738 File Offset: 0x00DF5938
		public void Refresh()
		{
			PhantomInteractModel instance = ModelBase<PhantomInteractModel>.Instance;
			for (int i = 0; i < this.GridItems.Count; i++)
			{
				PhantomGridItem phantomGridItem = this.GridItems[i];
				PhantomInteractItemData phantomInteractItemData = instance.InteractInfoData.EquippedVisionData[i];
				IPhantomInteractGridData phantomInteractGridData = null;
				PhantomInteractGridData phantomInteractGridData2;
				if (instance.InteractInfoData.GridItemDataMap.TryGetValue(phantomInteractItemData.MonsterId, out phantomInteractGridData2))
				{
					phantomInteractGridData = phantomInteractGridData2;
				}
				phantomGridItem.SetIcon((phantomInteractGridData != null) ? phantomInteractGridData.IconPath : null);
			}
		}

		// Token: 0x0401FA7E RID: 129662
		private const int GRID_COUNT = 8;

		// Token: 0x0401FA7F RID: 129663
		[Nullable(1)]
		private readonly List<PhantomGridItem> GridItems = new List<PhantomGridItem>();

		// Token: 0x0200B3C4 RID: 46020
		private enum EComponent
		{
			// Token: 0x04037AB7 RID: 228023
			ItemContent,
			// Token: 0x04037AB8 RID: 228024
			ItemGrid,
			// Token: 0x04037AB9 RID: 228025
			TxtPath
		}
	}
}
