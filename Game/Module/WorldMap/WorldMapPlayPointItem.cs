using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B46 RID: 19270
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapPlayPointItem : UiPanelBase
	{
		// Token: 0x17008649 RID: 34377
		// (get) Token: 0x06032461 RID: 205921 RVA: 0x00C91727 File Offset: 0x00C8F927
		// (set) Token: 0x06032462 RID: 205922 RVA: 0x00C9172F File Offset: 0x00C8F92F
		[Nullable(2)]
		public ExploreAreaItemData ExploreData { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x06032463 RID: 205923 RVA: 0x00C91738 File Offset: 0x00C8F938
		public UniTask Init(UUIItem item, ExploreAreaItemData data)
		{
			WorldMapPlayPointItem.<Init>d__8 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.data = data;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<WorldMapPlayPointItem.<Init>d__8>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06032464 RID: 205924 RVA: 0x00C9178B File Offset: 0x00C8F98B
		protected override void OnBeforeCreate()
		{
			this.Sequence = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence == null)
			{
				return;
			}
			sequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceCloseEvent), false);
		}

		// Token: 0x06032465 RID: 205925 RVA: 0x00C917BC File Offset: 0x00C8F9BC
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapPlayPointItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapPlayPointItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032466 RID: 205926 RVA: 0x00C91800 File Offset: 0x00C8FA00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032467 RID: 205927 RVA: 0x00C918E8 File Offset: 0x00C8FAE8
		protected override void OnBeforeShow()
		{
			this.UpdateData(this.ExploreData);
		}

		// Token: 0x06032468 RID: 205928 RVA: 0x00C918F6 File Offset: 0x00C8FAF6
		public void UpdateAreaItemData(ExploreAreaItemData data)
		{
			if (base.IsShow)
			{
				base.SetUiActive(true);
				this.UpdateData(data);
				return;
			}
			this.ExploreData = data;
		}

		// Token: 0x06032469 RID: 205929 RVA: 0x00C91916 File Offset: 0x00C8FB16
		private void UpdateData(ExploreAreaItemData data)
		{
			this.OnlyUpdateData(data);
			this.PlayStartToPause();
		}

		// Token: 0x0603246A RID: 205930 RVA: 0x00C91928 File Offset: 0x00C8FB28
		private void OnlyUpdateData(ExploreAreaItemData data)
		{
			this.ExploreData = data;
			this.PlayProgressPanel.UpdateData(data.GetPlayProgressDataIgnoreHiddenList(), null);
			string nameId = data.GetNameId();
			base.GetText(1).ShowTextNew(nameId);
			UUISprite sprite = base.GetSprite(2);
			this.SetSpriteByPath(data.Icon, sprite, false, null, null);
			if (this.SequencePromise.IsFulfilled)
			{
				this.SequencePromise = new CustomPromise();
			}
		}

		// Token: 0x0603246B RID: 205931 RVA: 0x00C9199A File Offset: 0x00C8FB9A
		private void OnClick()
		{
			if (this.ExploreData == null)
			{
				return;
			}
			this.ExploreData.TrackPoint();
		}

		// Token: 0x0603246C RID: 205932 RVA: 0x00C919B0 File Offset: 0x00C8FBB0
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence != null)
			{
				sequence.Clear();
			}
			this.Sequence = null;
		}

		// Token: 0x0603246D RID: 205933 RVA: 0x00C919CC File Offset: 0x00C8FBCC
		public void PlayStartToPause()
		{
			if (this.ExploreData == null || !this.ExploreData.IsNewRecommendPlay)
			{
				return;
			}
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence != null)
			{
				sequence.PlayLevelSequenceByName("Start", false, null, false);
			}
			LevelSequencePlayer sequence2 = this.Sequence;
			if (sequence2 != null)
			{
				sequence2.PauseSequence();
			}
			base.SetUiActive(false);
		}

		// Token: 0x0603246E RID: 205934 RVA: 0x00C91A28 File Offset: 0x00C8FC28
		public UniTask ResumeSequence(int addIndex)
		{
			WorldMapPlayPointItem.<ResumeSequence>d__19 <ResumeSequence>d__;
			<ResumeSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResumeSequence>d__.<>4__this = this;
			<ResumeSequence>d__.addIndex = addIndex;
			<ResumeSequence>d__.<>1__state = -1;
			<ResumeSequence>d__.<>t__builder.Start<WorldMapPlayPointItem.<ResumeSequence>d__19>(ref <ResumeSequence>d__);
			return <ResumeSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603246F RID: 205935 RVA: 0x00C91A74 File Offset: 0x00C8FC74
		public UniTask CheckFinish()
		{
			WorldMapPlayPointItem.<CheckFinish>d__20 <CheckFinish>d__;
			<CheckFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckFinish>d__.<>4__this = this;
			<CheckFinish>d__.<>1__state = -1;
			<CheckFinish>d__.<>t__builder.Start<WorldMapPlayPointItem.<CheckFinish>d__20>(ref <CheckFinish>d__);
			return <CheckFinish>d__.<>t__builder.Task;
		}

		// Token: 0x06032470 RID: 205936 RVA: 0x00C91AB7 File Offset: 0x00C8FCB7
		public void CheckPlayPointStateSequence()
		{
			this.PlayProgressPanel.CheckPlayStateChanged();
		}

		// Token: 0x06032471 RID: 205937 RVA: 0x00C91AC4 File Offset: 0x00C8FCC4
		private void SequenceCloseEvent(string sequenceName)
		{
			if (sequenceName == "Close".ToString())
			{
				ExploreAreaItemData exploreData = this.ExploreData;
				if (((exploreData != null) ? exploreData.SequenceData : null) != null)
				{
					ExploreAreaItemData sequenceData = this.ExploreData.SequenceData;
					this.ExploreData.SetSequenceData(null);
					this.OnlyUpdateData(sequenceData);
				}
				else
				{
					base.SetUiActive(false);
					LevelSequencePlayer sequence = this.Sequence;
					if (sequence != null)
					{
						sequence.PlayLevelSequenceByName("Refresh", false, null, false);
					}
				}
				this.SequencePromise.SetResult();
			}
		}

		// Token: 0x06032472 RID: 205938 RVA: 0x00C91B4B File Offset: 0x00C8FD4B
		public void HideMe()
		{
			base.SetUiActive(false);
			ExploreAreaItemData exploreData = this.ExploreData;
			if (exploreData != null)
			{
				exploreData.SetSequenceData(null);
			}
			this.ExploreData = null;
			this.SequencePromise.SetResult();
		}

		// Token: 0x0401D636 RID: 120374
		[Nullable(2)]
		private MapExplorePlayProgressPanel PlayProgressPanel;

		// Token: 0x0401D638 RID: 120376
		[Nullable(2)]
		private LevelSequencePlayer Sequence;

		// Token: 0x0401D639 RID: 120377
		private CustomPromise SequencePromise = new CustomPromise();

		// Token: 0x0200ABEB RID: 44011
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04035794 RID: 219028
			BtnRoot,
			// Token: 0x04035795 RID: 219029
			TxtName,
			// Token: 0x04035796 RID: 219030
			SpriteIcon,
			// Token: 0x04035797 RID: 219031
			HorizontalLayout
		}
	}
}
