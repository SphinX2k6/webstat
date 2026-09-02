using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x020056FE RID: 22270
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaInfoMapPanel : UiPanelBase
	{
		// Token: 0x06038ABA RID: 232122 RVA: 0x00E59AF8 File Offset: 0x00E57CF8
		public UniTask Init(MoraleAreaData areaData, UUIItem parentItem)
		{
			MoraleAreaInfoMapPanel.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.areaData = areaData;
			<Init>d__.parentItem = parentItem;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleAreaInfoMapPanel.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038ABB RID: 232123 RVA: 0x00E59B4C File Offset: 0x00E57D4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038ABC RID: 232124 RVA: 0x00E59BD8 File Offset: 0x00E57DD8
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleAreaInfoMapPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleAreaInfoMapPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038ABD RID: 232125 RVA: 0x00E59C1B File Offset: 0x00E57E1B
		public void UpdateData()
		{
			this.PlotPanel.UpdateData();
			this.UpdateFlagData();
		}

		// Token: 0x06038ABE RID: 232126 RVA: 0x00E59C30 File Offset: 0x00E57E30
		public void UpdateFlagState()
		{
			foreach (MoraleAreaInfoFlagItem moraleAreaInfoFlagItem in this.FlagItemList)
			{
				moraleAreaInfoFlagItem.UpdateSelectState();
			}
		}

		// Token: 0x06038ABF RID: 232127 RVA: 0x00E59C80 File Offset: 0x00E57E80
		private void UpdateFlagData()
		{
			foreach (MoraleAreaInfoFlagItem moraleAreaInfoFlagItem in this.FlagItemList)
			{
				moraleAreaInfoFlagItem.UpdateData();
				MoraleAreaPlotItem moraleAreaPlotItem;
				if (this.PlotPanel.PlotMap.TryGetValue(moraleAreaInfoFlagItem.FlagData.Config.FlagPosPlotId, out moraleAreaPlotItem))
				{
					moraleAreaInfoFlagItem.UpdatePosition(moraleAreaPlotItem.GetRootItem());
				}
			}
		}

		// Token: 0x06038AC0 RID: 232128 RVA: 0x00E59D04 File Offset: 0x00E57F04
		private void OnClickFlagItem(MoraleAreaFlagData flagData)
		{
			Action<MoraleAreaFlagData> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(flagData);
		}

		// Token: 0x06038AC1 RID: 232129 RVA: 0x00E59D18 File Offset: 0x00E57F18
		public void PlayStartSequence()
		{
			foreach (MoraleAreaInfoFlagItem moraleAreaInfoFlagItem in this.FlagItemList)
			{
				moraleAreaInfoFlagItem.PlayStartSequence();
			}
		}

		// Token: 0x06038AC2 RID: 232130 RVA: 0x00E59D68 File Offset: 0x00E57F68
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx([Nullable(new byte[]
		{
			2,
			1
		})] string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "BossFlag")
			{
				foreach (MoraleAreaInfoFlagItem moraleAreaInfoFlagItem in this.FlagItemList)
				{
					if (moraleAreaInfoFlagItem.FlagData.IsHighDifficultyChallenge())
					{
						UUIItem rootItem = moraleAreaInfoFlagItem.GetRootItem();
						UUIItem[] result;
						if (rootItem == null)
						{
							result = null;
						}
						else
						{
							UUIItem[] array = new UUIItem[2];
							array[0] = rootItem;
							result = array;
							array[1] = rootItem;
						}
						return result;
					}
				}
			}
			return null;
		}

		// Token: 0x040204FA RID: 132346
		public MoraleAreaPlotPanel PlotPanel;

		// Token: 0x040204FB RID: 132347
		public List<MoraleAreaInfoFlagItem> FlagItemList = new List<MoraleAreaInfoFlagItem>();

		// Token: 0x040204FC RID: 132348
		public Dictionary<int, MoraleAreaInfoFlagItem> FlagItemMap = new Dictionary<int, MoraleAreaInfoFlagItem>();

		// Token: 0x040204FD RID: 132349
		public MoraleAreaData AreaData;

		// Token: 0x040204FE RID: 132350
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MoraleAreaFlagData> ClickCallback;

		// Token: 0x0200B772 RID: 46962
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04038BD0 RID: 232400
			ItemBg,
			// Token: 0x04038BD1 RID: 232401
			ItemAreaPlotPanel,
			// Token: 0x04038BD2 RID: 232402
			ItemFlagRoot
		}
	}
}
