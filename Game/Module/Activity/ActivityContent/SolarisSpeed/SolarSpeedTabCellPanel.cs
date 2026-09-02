using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006394 RID: 25492
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SolarSpeedTabCellPanel : GridProxyAbstract<ISolarSpeedTabCellPanelData>
	{
		// Token: 0x06040036 RID: 262198 RVA: 0x010682C4 File Offset: 0x010664C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.HandleOnClickTab));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040037 RID: 262199 RVA: 0x010683AC File Offset: 0x010665AC
		protected override UniTask OnBeforeStartAsync()
		{
			SolarSpeedTabCellPanel.<OnBeforeStartAsync>d__1 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SolarSpeedTabCellPanel.<OnBeforeStartAsync>d__1>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040038 RID: 262200 RVA: 0x010683EF File Offset: 0x010665EF
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.CanExecuteChange.Unbind();
		}

		// Token: 0x06040039 RID: 262201 RVA: 0x01068407 File Offset: 0x01066607
		public override void Refresh(ISolarSpeedTabCellPanelData data, bool isSelected, int gridIndex)
		{
			this.OpenParam = data;
			this.RefreshByOpenParam(data);
		}

		// Token: 0x0604003A RID: 262202 RVA: 0x01068418 File Offset: 0x01066618
		private void RefreshByOpenParam(ISolarSpeedTabCellPanelData data)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			base.TrySetTextureByPath(data.RomeNumberPath, base.GetTexture(2), null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), data.TitleTextId, Array.Empty<object>());
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data.IsRedDot);
		}

		// Token: 0x0604003B RID: 262203 RVA: 0x01068498 File Offset: 0x01066698
		private void HandleOnClickTab(EToggleState toggleState)
		{
			ISolarSpeedTabCellPanelData solarSpeedTabCellPanelData = this.OpenParam as ISolarSpeedTabCellPanelData;
			ControllerBase<ActivitySolarSpeedController>.Instance.SyncCurrentChosenLevelId(solarSpeedTabCellPanelData.LevelId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SolarSpeedClickRewardTab, solarSpeedTabCellPanelData.LevelId);
		}

		// Token: 0x0604003C RID: 262204 RVA: 0x010684D7 File Offset: 0x010666D7
		private bool HandleCanExecuteChange()
		{
			return !(this.OpenParam as ISolarSpeedTabCellPanelData).IsChosen;
		}

		// Token: 0x0200C3F2 RID: 50162
		[NullableContext(0)]
		private class ETabCellComponent
		{
			// Token: 0x0403C5A6 RID: 247206
			public const int RootToggle = 0;

			// Token: 0x0403C5A7 RID: 247207
			public const int NameText = 1;

			// Token: 0x0403C5A8 RID: 247208
			public const int NumberTexture = 2;

			// Token: 0x0403C5A9 RID: 247209
			public const int RedDotItem = 3;
		}
	}
}
