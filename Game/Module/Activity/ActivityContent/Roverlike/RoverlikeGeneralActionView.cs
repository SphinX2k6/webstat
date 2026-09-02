using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D0 RID: 25552
	public class RoverlikeGeneralActionView : RoverlikeActionViewBase
	{
		// Token: 0x06040276 RID: 262774 RVA: 0x01070C61 File Offset: 0x0106EE61
		[NullableContext(1)]
		public RoverlikeGeneralActionView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040277 RID: 262775 RVA: 0x01070C6C File Offset: 0x0106EE6C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040278 RID: 262776 RVA: 0x01070CD8 File Offset: 0x0106EED8
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeGeneralActionView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeGeneralActionView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040279 RID: 262777 RVA: 0x01070D1C File Offset: 0x0106EF1C
		protected override void OnStart()
		{
			RoverlikeActionSubViewManager actionSubViewManager = ModelBase<RoverlikeModel>.Instance.ActionSubViewManager;
			if (actionSubViewManager == null)
			{
				return;
			}
			actionSubViewManager.OnAllSubViewsFinished = delegate()
			{
				base.CloseMe(null);
			};
			actionSubViewManager.RegisterHost(base.GetItem(1));
			actionSubViewManager.RegisterTopPanel(this.TopPanel);
		}

		// Token: 0x0604027A RID: 262778 RVA: 0x01070D63 File Offset: 0x0106EF63
		protected override void OnBeforeShow()
		{
			RoverlikeBattleTopPanel topPanel = this.TopPanel;
			if (topPanel == null)
			{
				return;
			}
			topPanel.StartShow();
		}

		// Token: 0x0604027B RID: 262779 RVA: 0x01070D75 File Offset: 0x0106EF75
		protected override void OnBeforeHide()
		{
			RoverlikeBattleTopPanel topPanel = this.TopPanel;
			if (topPanel == null)
			{
				return;
			}
			topPanel.EndShow();
		}

		// Token: 0x0604027C RID: 262780 RVA: 0x01070D88 File Offset: 0x0106EF88
		protected override void OnBeforeDestroy()
		{
			RoverlikeActionSubViewManager actionSubViewManager = ModelBase<RoverlikeModel>.Instance.ActionSubViewManager;
			if (actionSubViewManager != null)
			{
				actionSubViewManager.UnregisterHost();
			}
		}

		// Token: 0x0604027D RID: 262781 RVA: 0x01070DA9 File Offset: 0x0106EFA9
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			RoverlikeActionSubViewManager roverlikeActionSubViewManager = (instance != null) ? instance.ActionSubViewManager : null;
			if (roverlikeActionSubViewManager == null)
			{
				return null;
			}
			RoverlikeActionSubViewBase currentSubView = roverlikeActionSubViewManager.GetCurrentSubView();
			if (currentSubView == null)
			{
				return null;
			}
			return currentSubView.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x04023FF2 RID: 147442
		[Nullable(2)]
		protected RoverlikeBattleTopPanel TopPanel;

		// Token: 0x0200C42B RID: 50219
		private class EComponents
		{
			// Token: 0x0403C64D RID: 247373
			public const int ItemRogueTop = 0;

			// Token: 0x0403C64E RID: 247374
			public const int Content = 1;
		}
	}
}
