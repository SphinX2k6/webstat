using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x0200624B RID: 25163
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonConditionView : UiViewBase
	{
		// Token: 0x0603F6F2 RID: 259826 RVA: 0x01042E34 File Offset: 0x01041034
		public CommonConditionView(UiViewInfo info) : base(info)
		{
			this.TextIdMap.Add("FinishAllConditionOpen", "TaskNotOpen_Tips01");
			this.TextIdMap.Add("FinishAnyConditionOpen", "TaskNotOpen_Tips02");
			this.TextIdMap.Add("FinishAllConditionPreOpen", "TaskNotPreOpen_Tips01");
			this.TextIdMap.Add("FinishAnyConditionPreOpen", "TaskNotPreOpen_Tips02");
		}

		// Token: 0x0603F6F3 RID: 259827 RVA: 0x01042EA8 File Offset: 0x010410A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F6F4 RID: 259828 RVA: 0x01042F53 File Offset: 0x01041153
		protected override void OnStart()
		{
			this.ConditionGroupData = (this.OpenParam as ConditionGroupData);
			this.CreateConditionLayout();
		}

		// Token: 0x0603F6F5 RID: 259829 RVA: 0x01042F6C File Offset: 0x0104116C
		protected override void OnBeforeShow()
		{
			if (this.ConditionGroupData == null)
			{
				return;
			}
			List<IActivityConditionData> dataList = this.ConditionGroupData.DataList;
			LoopScrollView<ActivityConditionItem, IActivityConditionData> conditionLayout = this.ConditionLayout;
			if (conditionLayout != null)
			{
				conditionLayout.RefreshByData(dataList, false, null, false);
			}
			this.SetDescription();
		}

		// Token: 0x0603F6F6 RID: 259830 RVA: 0x01042FAC File Offset: 0x010411AC
		protected void CreateConditionLayout()
		{
			UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(2);
			UUIItem item = base.GetItem(3);
			this.ConditionLayout = new LoopScrollView<ActivityConditionItem, IActivityConditionData>(loopScrollViewComponent, item.GetOwner() as AUIBaseActor, new Func<ActivityConditionItem>(this.CreateConditionItem), false);
		}

		// Token: 0x0603F6F7 RID: 259831 RVA: 0x01042FF0 File Offset: 0x010411F0
		private void SetDescription()
		{
			ConditionGroupData conditionGroupData = this.ConditionGroupData;
			if (conditionGroupData == null)
			{
				return;
			}
			ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(conditionGroupData.ConditionGroupId);
			string textStringId = string.Empty;
			if (!conditionGroupData.IsPreOpen)
			{
				textStringId = ((conditionGroupConfig == null || conditionGroupConfig.GetValueOrDefault().Relation != 0) ? this.TextIdMap["FinishAnyConditionOpen"] : this.TextIdMap["FinishAllConditionOpen"]);
			}
			else
			{
				textStringId = ((conditionGroupConfig == null || conditionGroupConfig.GetValueOrDefault().Relation != 0) ? this.TextIdMap["FinishAnyConditionPreOpen"] : this.TextIdMap["FinishAllConditionPreOpen"]);
			}
			string item = StringUtils.IsEmpty(conditionGroupData.TitleId) ? string.Empty : ConfigMultiTextLang.GetLocalTextNew(conditionGroupData.TitleId, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlySingleElementList<object>(item));
		}

		// Token: 0x0603F6F8 RID: 259832 RVA: 0x010430EA File Offset: 0x010412EA
		private ActivityConditionItem CreateConditionItem()
		{
			return new ActivityConditionItem();
		}

		// Token: 0x040239A1 RID: 145825
		[Nullable(2)]
		protected ConditionGroupData ConditionGroupData;

		// Token: 0x040239A2 RID: 145826
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ActivityConditionItem, IActivityConditionData> ConditionLayout;

		// Token: 0x040239A3 RID: 145827
		protected Dictionary<string, string> TextIdMap = new Dictionary<string, string>();

		// Token: 0x0200C350 RID: 50000
		[NullableContext(0)]
		internal class EComponents
		{
			// Token: 0x0403C317 RID: 246551
			public const int Title = 0;

			// Token: 0x0403C318 RID: 246552
			public const int TxtTips = 1;

			// Token: 0x0403C319 RID: 246553
			public const int ConditionLayout = 2;

			// Token: 0x0403C31A RID: 246554
			public const int ConditionItem = 3;
		}
	}
}
