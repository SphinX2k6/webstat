using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062DB RID: 25307
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TetrisSelectLevelItemGrid : GridProxyAbstract<ITetrisSelectGroupData>
	{
		// Token: 0x0603FA76 RID: 260726 RVA: 0x01051D7C File Offset: 0x0104FF7C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603FA77 RID: 260727 RVA: 0x01051DD8 File Offset: 0x0104FFD8
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisSelectLevelItemGrid.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisSelectLevelItemGrid.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FA78 RID: 260728 RVA: 0x01051E1C File Offset: 0x0105001C
		public override void Refresh(ITetrisSelectGroupData data, bool isSelected, int gridIndex)
		{
			this.LevelData = data;
			int num = data.ChallengeIds[0];
			Tetris levelConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(num);
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (!TetrisUtils.IsEggLevel(levelConfig) || tetrisData == null || tetrisData.CheckPreChallengeComplete(num))
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem != null)
				{
					rootItem.SetUIActive(true);
				}
				this.RefreshPanel();
				this.ItemDetailPanel.Refresh(data);
				return;
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetUIActive(false);
		}

		// Token: 0x0603FA79 RID: 260729 RVA: 0x01051E9C File Offset: 0x0105009C
		private void RefreshPanel()
		{
			if (this.LevelData.GroupId % 2 == 0)
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem item3 = base.GetItem(2);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(1);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603FA7A RID: 260730 RVA: 0x01051F03 File Offset: 0x01050103
		public void PlayAnim(string sequenceName)
		{
			this.ItemDetailPanel.PlayAnim(sequenceName);
		}

		// Token: 0x0603FA7B RID: 260731 RVA: 0x01051F11 File Offset: 0x01050111
		public UUIItem GetGridItem()
		{
			return base.GetItem(0);
		}

		// Token: 0x04023BDE RID: 146398
		[Nullable(2)]
		private ITetrisSelectGroupData LevelData;

		// Token: 0x04023BDF RID: 146399
		[Nullable(2)]
		private TetrisSelectLevelItemDetailPanel ItemDetailPanel;
	}
}
