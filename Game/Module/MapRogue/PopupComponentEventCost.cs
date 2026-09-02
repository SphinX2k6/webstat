using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005988 RID: 22920
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentEventCost : UiPanelBase
	{
		// Token: 0x0603A0EA RID: 237802 RVA: 0x00EB1CEC File Offset: 0x00EAFEEC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603A0EB RID: 237803 RVA: 0x00EB1D28 File Offset: 0x00EAFF28
		protected override UniTask OnBeforeStartAsync()
		{
			PopupComponentEventCost.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PopupComponentEventCost.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0EC RID: 237804 RVA: 0x00EB1D6C File Offset: 0x00EAFF6C
		public void Refresh(MapGridData gridData)
		{
			bool isExplore = gridData.IsExplore;
			int eventCost = gridData.EventCost;
			if (isExplore || eventCost == 0)
			{
				this.SetActive(false);
				return;
			}
			int moodItemId = ModelBase<MapRogueModel>.Instance.GameInfo.MoodItemId;
			string valueTxt = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RogueResEventMoodCost_2", null), new string[]
			{
				gridData.EventCost.ToString()
			});
			this.InfoItem.Refresh("RogueResEventMoodCost_1", moodItemId, valueTxt);
			this.SetActive(true);
		}

		// Token: 0x0603A0ED RID: 237805 RVA: 0x00EB1DE4 File Offset: 0x00EAFFE4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			PopupComponentInfoItem infoItem = this.InfoItem;
			UUIItem uuiitem = (infoItem != null) ? infoItem.GetRootItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04020EE9 RID: 134889
		[Nullable(2)]
		protected PopupComponentInfoItem InfoItem;
	}
}
