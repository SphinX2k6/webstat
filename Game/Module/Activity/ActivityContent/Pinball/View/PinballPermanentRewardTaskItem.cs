using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006598 RID: 26008
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballPermanentRewardTaskItem : GridProxyAbstract<PinballTaskData>
	{
		// Token: 0x06040FD1 RID: 266193 RVA: 0x010ACED4 File Offset: 0x010AB0D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnRewardBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040FD2 RID: 266194 RVA: 0x010AD062 File Offset: 0x010AB262
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(3), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		}

		// Token: 0x06040FD3 RID: 266195 RVA: 0x010AD088 File Offset: 0x010AB288
		public override void Refresh(PinballTaskData data, bool isSelected, int gridIndex)
		{
			this.TaskData = data;
			this.RewardScroll.RefreshByData(data.RewardList, null, false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(data.IsUnclaimed);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(data.IsFinished);
			base.GetText(5).SetUIActive(data.IsDoing);
			UUIText text = base.GetText(1);
			if (data.QuestNameTextKey != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.QuestNameTextKey, Array.Empty<object>());
			}
			else
			{
				text.SetText(data.QuestName, true);
			}
			base.GetText(2).SetUIActive(data.Target != 0);
			UUIText text2 = base.GetText(2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06040FD4 RID: 266196 RVA: 0x010AD18C File Offset: 0x010AB38C
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06040FD5 RID: 266197 RVA: 0x010AD194 File Offset: 0x010AB394
		private UniTask OnRewardBtnClickAsync()
		{
			PinballPermanentRewardTaskItem.<OnRewardBtnClickAsync>d__7 <OnRewardBtnClickAsync>d__;
			<OnRewardBtnClickAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRewardBtnClickAsync>d__.<>4__this = this;
			<OnRewardBtnClickAsync>d__.<>1__state = -1;
			<OnRewardBtnClickAsync>d__.<>t__builder.Start<PinballPermanentRewardTaskItem.<OnRewardBtnClickAsync>d__7>(ref <OnRewardBtnClickAsync>d__);
			return <OnRewardBtnClickAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040FD6 RID: 266198 RVA: 0x010AD1D7 File Offset: 0x010AB3D7
		private void OnRewardBtnClick()
		{
			this.OnRewardBtnClickAsync().Forget();
		}

		// Token: 0x04024718 RID: 149272
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x04024719 RID: 149273
		[Nullable(2)]
		private PinballTaskData TaskData;

		// Token: 0x0402471A RID: 149274
		[Nullable(2)]
		public Func<int, UniTask> OnTaskRewardClick;

		// Token: 0x0200C58D RID: 50573
		[NullableContext(0)]
		private enum ETaskComponents
		{
			// Token: 0x0403CCCA RID: 249034
			ScriptBtn,
			// Token: 0x0403CCCB RID: 249035
			TxtName,
			// Token: 0x0403CCCC RID: 249036
			TxtNum,
			// Token: 0x0403CCCD RID: 249037
			ItemLayout,
			// Token: 0x0403CCCE RID: 249038
			ItemBaseB,
			// Token: 0x0403CCCF RID: 249039
			TxtDoing,
			// Token: 0x0403CCD0 RID: 249040
			BtnConfirmBaseA,
			// Token: 0x0403CCD1 RID: 249041
			RedPoint,
			// Token: 0x0403CCD2 RID: 249042
			PanelDone
		}
	}
}
