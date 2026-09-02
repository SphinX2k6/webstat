using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B5A RID: 23386
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreScore : UiPanelBase
	{
		// Token: 0x0603B295 RID: 242325 RVA: 0x00EF84E0 File Offset: 0x00EF66E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B296 RID: 242326 RVA: 0x00EF854C File Offset: 0x00EF674C
		protected override UniTask OnBeforeStartAsync()
		{
			RewardExploreScore.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardExploreScore.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B297 RID: 242327 RVA: 0x00EF8590 File Offset: 0x00EF6790
		protected override void OnStart()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
			this.Scroller = new GenericLayout<RewardExploreScore.ScoreItem, IRewardExploreTargetReached>(scrollViewWithScrollbar.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase, new Func<RewardExploreScore.ScoreItem>(this.CreateTaskItem), null, false, true);
		}

		// Token: 0x0603B298 RID: 242328 RVA: 0x00EF85D9 File Offset: 0x00EF67D9
		private RewardExploreScore.ScoreItem CreateTaskItem()
		{
			return new RewardExploreScore.ScoreItem();
		}

		// Token: 0x0603B299 RID: 242329 RVA: 0x00EF85E0 File Offset: 0x00EF67E0
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603B29A RID: 242330 RVA: 0x00EF85E2 File Offset: 0x00EF67E2
		public void Refresh(ReachTargetData data)
		{
			GenericLayout<RewardExploreScore.ScoreItem, IRewardExploreTargetReached> scroller = this.Scroller;
			if (scroller != null)
			{
				scroller.RefreshByData(data.TargetReached, null, false);
			}
			RewardExploreScore.NewRecordItem newRecordItemInstance = this.NewRecordItemInstance;
			if (newRecordItemInstance == null)
			{
				return;
			}
			newRecordItemInstance.Refresh(data);
		}

		// Token: 0x04021597 RID: 136599
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardExploreScore.ScoreItem, IRewardExploreTargetReached> Scroller;

		// Token: 0x04021598 RID: 136600
		[Nullable(2)]
		private RewardExploreScore.NewRecordItem NewRecordItemInstance;

		// Token: 0x0200BB61 RID: 47969
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D1D RID: 236829
			public const int LayoutItem = 0;

			// Token: 0x04039D1E RID: 236830
			public const int NewRecordItem = 1;
		}

		// Token: 0x0200BB62 RID: 47970
		[Nullable(0)]
		public class ScoreItem : UiPanelBase, IGridProxy<IRewardExploreTargetReached>
		{
			// Token: 0x1700A993 RID: 43411
			// (get) Token: 0x0604D9D4 RID: 317908 RVA: 0x0157094A File Offset: 0x0156EB4A
			// (set) Token: 0x0604D9D5 RID: 317909 RVA: 0x01570952 File Offset: 0x0156EB52
			[Nullable(new byte[]
			{
				2,
				1,
				1,
				1
			})]
			public IScrollViewDelegate<IGridProxy<IRewardExploreTargetReached>, IRewardExploreTargetReached> ScrollViewDelegate { [return: Nullable(new byte[]
			{
				2,
				1,
				1,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1,
				1,
				1
			})] set; }

			// Token: 0x1700A994 RID: 43412
			// (get) Token: 0x0604D9D6 RID: 317910 RVA: 0x0157095B File Offset: 0x0156EB5B
			// (set) Token: 0x0604D9D7 RID: 317911 RVA: 0x01570963 File Offset: 0x0156EB63
			public int GridIndex { get; set; }

			// Token: 0x1700A995 RID: 43413
			// (get) Token: 0x0604D9D8 RID: 317912 RVA: 0x0157096C File Offset: 0x0156EB6C
			// (set) Token: 0x0604D9D9 RID: 317913 RVA: 0x01570974 File Offset: 0x0156EB74
			public int DisplayIndex { get; set; }

			// Token: 0x0604D9DA RID: 317914 RVA: 0x0157097D File Offset: 0x0156EB7D
			public void Clear()
			{
			}

			// Token: 0x0604D9DB RID: 317915 RVA: 0x0157097F File Offset: 0x0156EB7F
			public void OnSelected(bool fireEvent)
			{
			}

			// Token: 0x0604D9DC RID: 317916 RVA: 0x01570981 File Offset: 0x0156EB81
			public void OnDeselected(bool fireEvent)
			{
			}

			// Token: 0x0604D9DD RID: 317917 RVA: 0x01570983 File Offset: 0x0156EB83
			public object GetKey(IRewardExploreTargetReached data, int gridIndex)
			{
				return null;
			}

			// Token: 0x0604D9DE RID: 317918 RVA: 0x01570988 File Offset: 0x0156EB88
			protected unsafe override void OnRegisterComponent()
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
				this.ComponentRegisterInfos = list;
				this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
			}

			// Token: 0x0604D9DF RID: 317919 RVA: 0x01570A1D File Offset: 0x0156EC1D
			public void Refresh(IRewardExploreTargetReached data, bool isSelected, int gridIndex)
			{
				this.RefreshName(data);
				this.RefreshDesc(data);
			}

			// Token: 0x0604D9E0 RID: 317920 RVA: 0x01570A2D File Offset: 0x0156EC2D
			private void RefreshName(IRewardExploreTargetReached data)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.DescriptionTextId, Array.Empty<object>());
			}

			// Token: 0x0604D9E1 RID: 317921 RVA: 0x01570A4B File Offset: 0x0156EC4B
			private void RefreshDesc(IRewardExploreTargetReached data)
			{
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.SetText(data.Target[0], true);
			}

			// Token: 0x0200CF3E RID: 53054
			[NullableContext(0)]
			private class EScoreItemComponent
			{
				// Token: 0x0403FD7C RID: 261500
				public const int SpriteBg = 0;

				// Token: 0x0403FD7D RID: 261501
				public const int NameText = 1;

				// Token: 0x0403FD7E RID: 261502
				public const int DescText = 2;
			}
		}

		// Token: 0x0200BB63 RID: 47971
		[Nullable(0)]
		public class NewRecordItem : UiPanelBase
		{
			// Token: 0x0604D9E3 RID: 317923 RVA: 0x01570A74 File Offset: 0x0156EC74
			protected unsafe override void OnRegisterComponent()
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
			}

			// Token: 0x0604D9E4 RID: 317924 RVA: 0x01570B09 File Offset: 0x0156ED09
			public void Refresh(ReachTargetData data)
			{
				this.RefreshTitle(data);
				this.RefreshRecord(data);
				this.SetNewRecordItemVisible(data.IfNewRecord);
			}

			// Token: 0x0604D9E5 RID: 317925 RVA: 0x01570B25 File Offset: 0x0156ED25
			private void RefreshTitle(ReachTargetData data)
			{
				if (StringUtils.IsEmpty(data.RecordTextId))
				{
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.RecordTextId, Array.Empty<object>());
			}

			// Token: 0x0604D9E6 RID: 317926 RVA: 0x01570B51 File Offset: 0x0156ED51
			private void RefreshRecord(ReachTargetData data)
			{
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				text.SetText(data.FullScore.ToString(), true);
			}

			// Token: 0x0604D9E7 RID: 317927 RVA: 0x01570B70 File Offset: 0x0156ED70
			private void SetNewRecordItemVisible(bool bVisible)
			{
				UUIItem item = base.GetItem(2);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(bVisible);
			}

			// Token: 0x0200CF3F RID: 53055
			[NullableContext(0)]
			private class ENewRecordCompoent
			{
				// Token: 0x0403FD7F RID: 261503
				public const int TitleText = 0;

				// Token: 0x0403FD80 RID: 261504
				public const int RecordText = 1;

				// Token: 0x0403FD81 RID: 261505
				public const int NewRecordItem = 2;
			}
		}
	}
}
