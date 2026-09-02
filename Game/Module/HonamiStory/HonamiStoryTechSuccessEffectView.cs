using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C99 RID: 23705
	public class HonamiStoryTechSuccessEffectView : UiViewBase
	{
		// Token: 0x0603BD97 RID: 245143 RVA: 0x00F2B4EE File Offset: 0x00F296EE
		[NullableContext(1)]
		public HonamiStoryTechSuccessEffectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BD98 RID: 245144 RVA: 0x00F2B4F8 File Offset: 0x00F296F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickCloseBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BD99 RID: 245145 RVA: 0x00F2B648 File Offset: 0x00F29848
		protected override UniTask OnBeforeStartAsync()
		{
			HonamiStoryTechSuccessEffectView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryTechSuccessEffectView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD9A RID: 245146 RVA: 0x00F2B68C File Offset: 0x00F2988C
		protected override void OnBeforeShow()
		{
			this.Data = new HonamiStoryTalent?((HonamiStoryTalent)this.OpenParam);
			if (this.Data != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.Data.Value.SuccessTitle, Array.Empty<object>());
				this.TextItem.SetDescriptionText(this.Data.Value.SuccessDesc, this.Data.Value.SuccessDescParams());
				base.GetText(3).ShowTextNew("Text_BackToView_Text");
			}
		}

		// Token: 0x0603BD9B RID: 245147 RVA: 0x00F2B727 File Offset: 0x00F29927
		private void OnClickCloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603BD9C RID: 245148 RVA: 0x00F2B730 File Offset: 0x00F29930
		protected override void OnAfterDestroy()
		{
			HonamiStoryModel instance = ModelBase<HonamiStoryModel>.Instance;
			bool flag;
			if (this.Data == null)
			{
				flag = false;
			}
			else
			{
				int type = this.Data.GetValueOrDefault().Type;
				flag = true;
			}
			if (flag && (this.Data.Value.Type == 1 || this.Data.Value.Type == 2))
			{
				string flowListName = instance.CurrentSelectNode.GetConfig.FlowListName;
				int flowId = instance.CurrentSelectNode.GetConfig.FlowId;
				int stateId = instance.CurrentSelectNode.GetConfig.StateId;
				if (!string.IsNullOrEmpty(flowListName) && flowId != 0 && stateId != 0)
				{
					ControllerBase<FlowController>.Instance.StartFlow(flowListName, flowId, stateId, null, 0L, false, false, false, null);
				}
			}
		}

		// Token: 0x04021A59 RID: 137817
		[Nullable(2)]
		private SuccessDescriptionItem TextItem;

		// Token: 0x04021A5A RID: 137818
		private HonamiStoryTalent? Data;

		// Token: 0x0200BD3B RID: 48443
		private enum EComponent
		{
			// Token: 0x0403A504 RID: 238852
			TextScrollLayout,
			// Token: 0x0403A505 RID: 238853
			TextItem,
			// Token: 0x0403A506 RID: 238854
			Title,
			// Token: 0x0403A507 RID: 238855
			TipsText,
			// Token: 0x0403A508 RID: 238856
			TipsButton,
			// Token: 0x0403A509 RID: 238857
			TipsButton2
		}
	}
}
