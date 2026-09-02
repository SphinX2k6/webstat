using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Phantom.Vision.View
{
	// Token: 0x02004A6B RID: 19051
	[NullableContext(2)]
	[Nullable(0)]
	public class VisionDetailDescComponent : UiPanelBase
	{
		// Token: 0x06031BD7 RID: 203735 RVA: 0x00C7453A File Offset: 0x00C7273A
		[NullableContext(1)]
		public VisionDetailDescComponent(UUIItem actor)
		{
			this.SourceItem = actor;
		}

		// Token: 0x06031BD8 RID: 203736 RVA: 0x00C7454C File Offset: 0x00C7274C
		public UniTask Init()
		{
			VisionDetailDescComponent.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<VisionDetailDescComponent.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06031BD9 RID: 203737 RVA: 0x00C74590 File Offset: 0x00C72790
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06031BDA RID: 203738 RVA: 0x00C7463C File Offset: 0x00C7283C
		protected override UniTask OnBeforeStartAsync()
		{
			VisionDetailDescComponent.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VisionDetailDescComponent.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031BDB RID: 203739 RVA: 0x00C7467F File Offset: 0x00C7287F
		[NullableContext(1)]
		private void OnLayoutRebuild(UUILayoutBase _)
		{
			if (this.FocusVision)
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
				if (scrollViewWithScrollbar == null)
				{
					return;
				}
				scrollViewWithScrollbar.ScrollTo(base.GetItem(2), false);
			}
		}

		// Token: 0x06031BDC RID: 203740 RVA: 0x00C746A2 File Offset: 0x00C728A2
		protected override void OnStart()
		{
			this.AddEvent();
		}

		// Token: 0x06031BDD RID: 203741 RVA: 0x00C746AA File Offset: 0x00C728AA
		public UUIItem GetTxtItemByIndex(int index)
		{
			if (index == 0)
			{
				return base.GetItem(1);
			}
			if (index == 1)
			{
				this.FocusVision = true;
				return base.GetItem(2);
			}
			return null;
		}

		// Token: 0x06031BDE RID: 203742 RVA: 0x00C746CB File Offset: 0x00C728CB
		private void AddEvent()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeVisionSimplyState, new Action(this.OnChangeVisionSimplyState));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideDone));
		}

		// Token: 0x06031BDF RID: 203743 RVA: 0x00C74705 File Offset: 0x00C72905
		private void RemoveEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeVisionSimplyState, new Action(this.OnChangeVisionSimplyState));
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideDone));
		}

		// Token: 0x06031BE0 RID: 203744 RVA: 0x00C74740 File Offset: 0x00C72940
		private void OnChangeVisionSimplyState()
		{
			if (this.CurrentData != null)
			{
				foreach (VisionDetailDesc visionDetailDesc in this.CurrentData)
				{
					visionDetailDesc.NeedSimplyStateChangeAnimation = true;
				}
				this.Refresh(this.CurrentData, true);
			}
		}

		// Token: 0x06031BE1 RID: 203745 RVA: 0x00C747A8 File Offset: 0x00C729A8
		private void OnGuideDone(int groupId)
		{
			this.FocusVision = false;
		}

		// Token: 0x06031BE2 RID: 203746 RVA: 0x00C747B4 File Offset: 0x00C729B4
		[NullableContext(1)]
		public void Refresh(List<VisionDetailDesc> data, bool fromSimplyStateChange = false)
		{
			this.CurrentData = data;
			List<VisionDetailDesc> list = new List<VisionDetailDesc>();
			List<VisionDetailDesc> list2 = new List<VisionDetailDesc>();
			foreach (VisionDetailDesc visionDetailDesc in data)
			{
				if (visionDetailDesc.SkillConfig != null || (visionDetailDesc.TitleItemShowState && visionDetailDesc.TitleType == 0))
				{
					list.Add(visionDetailDesc);
				}
				if (visionDetailDesc.FetterId > 0 || (visionDetailDesc.TitleItemShowState && visionDetailDesc.TitleType == 1) || visionDetailDesc.GetNeedWarn())
				{
					list2.Add(visionDetailDesc);
				}
			}
			VisionDetailDescItem skillDesc = this.SkillDesc;
			if (skillDesc != null)
			{
				skillDesc.Update(list);
			}
			VisionDetailDescItem visionDesc = this.VisionDesc;
			if (visionDesc != null)
			{
				visionDesc.Update(list2);
			}
			foreach (VisionDetailDesc visionDetailDesc2 in data)
			{
				visionDetailDesc2.NeedSimplyStateChangeAnimation = false;
			}
		}

		// Token: 0x06031BE3 RID: 203747 RVA: 0x00C748BC File Offset: 0x00C72ABC
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvent();
		}

		// Token: 0x0401D1F0 RID: 119280
		private readonly UUIItem SourceItem;

		// Token: 0x0401D1F1 RID: 119281
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<VisionDetailDesc> CurrentData;

		// Token: 0x0401D1F2 RID: 119282
		private VisionDetailDescItem SkillDesc;

		// Token: 0x0401D1F3 RID: 119283
		private VisionDetailDescItem VisionDesc;

		// Token: 0x0401D1F4 RID: 119284
		private bool FocusVision;

		// Token: 0x0200AAEA RID: 43754
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403532E RID: 217902
			AttributeLayout,
			// Token: 0x0403532F RID: 217903
			DescItem1,
			// Token: 0x04035330 RID: 217904
			DescItem2,
			// Token: 0x04035331 RID: 217905
			Layout
		}
	}
}
