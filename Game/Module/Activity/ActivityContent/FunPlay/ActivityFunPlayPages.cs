using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006775 RID: 26485
	[NullableContext(1)]
	[Nullable(0)]
	internal class ActivityFunPlayPages : UiPanelBase
	{
		// Token: 0x0604204B RID: 270411 RVA: 0x010F012C File Offset: 0x010EE32C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.MoveToLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.MoveToRight));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604204C RID: 270412 RVA: 0x010F03CB File Offset: 0x010EE5CB
		protected override void OnStart()
		{
			this.InitPageDot();
		}

		// Token: 0x0604204D RID: 270413 RVA: 0x010F03D3 File Offset: 0x010EE5D3
		private void InitPageDot()
		{
			this.PageDotLayout = new GenericLayout<ActivityFunPlayPage, FunPlaySharpComment>(base.GetHorizontalLayout(11), new Func<ActivityFunPlayPage>(this.CreatePageDot), null, false, true);
		}

		// Token: 0x0604204E RID: 270414 RVA: 0x010F03F7 File Offset: 0x010EE5F7
		private ActivityFunPlayPage CreatePageDot()
		{
			return new ActivityFunPlayPage();
		}

		// Token: 0x0604204F RID: 270415 RVA: 0x010F0400 File Offset: 0x010EE600
		private void MoveToLeft()
		{
			if (this.CurrentCommentIndex - 1 < 0)
			{
				return;
			}
			this.CurrentCommentIndex--;
			this.PlaySwitchAnimation();
			this.OnSelectedComment(this.CurrentCommentIndex);
			GenericLayout<ActivityFunPlayPage, FunPlaySharpComment> pageDotLayout = this.PageDotLayout;
			if (pageDotLayout == null)
			{
				return;
			}
			pageDotLayout.SelectGridProxy(this.CurrentCommentIndex, true);
		}

		// Token: 0x06042050 RID: 270416 RVA: 0x010F0450 File Offset: 0x010EE650
		private void MoveToRight()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			List<FunPlaySharpComment> sharpComments = currentChallengeData.GetSharpComments();
			if (this.CurrentCommentIndex + 1 > sharpComments.Count - 1)
			{
				return;
			}
			this.CurrentCommentIndex++;
			this.PlaySwitchAnimation();
			this.OnSelectedComment(this.CurrentCommentIndex);
			GenericLayout<ActivityFunPlayPage, FunPlaySharpComment> pageDotLayout = this.PageDotLayout;
			if (pageDotLayout == null)
			{
				return;
			}
			pageDotLayout.SelectGridProxy(this.CurrentCommentIndex, true);
		}

		// Token: 0x06042051 RID: 270417 RVA: 0x010F04C0 File Offset: 0x010EE6C0
		public void Refresh(bool reset)
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			bool flag = currentChallengeData.GetSharpComments().Count <= 0;
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(5).SetUIActive(flag);
			base.GetItem(6).SetUIActive(!flag);
			base.GetText(10).SetUIActive(!flag);
			base.GetItem(13).SetUIActive(flag);
			this.RefreshVarStatePanel(null);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), EFunPlayTextKey.NoComment.ToString(), Array.Empty<object>());
				return;
			}
			List<FunPlaySharpComment> sharpComments = currentChallengeData.GetSharpComments();
			this.CurrentCommentIndex = (reset ? 0 : sharpComments.FindIndex((FunPlaySharpComment item) => item.CommentId == this.CurrentCommentId));
			if (this.CurrentCommentIndex == -1)
			{
				this.CurrentCommentIndex = 0;
			}
			this.OnSelectedComment(this.CurrentCommentIndex);
			this.RefreshPageDotLayout(sharpComments);
		}

		// Token: 0x06042052 RID: 270418 RVA: 0x010F05C4 File Offset: 0x010EE7C4
		public void RefreshPageDotLayout(List<FunPlaySharpComment> list)
		{
			base.GetHorizontalLayout(11).RootUIComp.Get().SetUIActive(list.Count > 1);
			if (list.Count > 1)
			{
				GenericLayout<ActivityFunPlayPage, FunPlaySharpComment> pageDotLayout = this.PageDotLayout;
				if (pageDotLayout == null)
				{
					return;
				}
				pageDotLayout.RefreshByData(list, delegate
				{
					GenericLayout<ActivityFunPlayPage, FunPlaySharpComment> pageDotLayout2 = this.PageDotLayout;
					if (pageDotLayout2 == null)
					{
						return;
					}
					pageDotLayout2.SelectGridProxy(this.CurrentCommentIndex, true);
				}, false);
			}
		}

		// Token: 0x06042053 RID: 270419 RVA: 0x010F061C File Offset: 0x010EE81C
		private void OnSelectedComment(int index)
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			List<FunPlaySharpComment> sharpComments = currentChallengeData.GetSharpComments();
			this.RefreshArrowBtn(index, sharpComments.Count);
			FunPlaySharpComment value = sharpComments[index];
			this.CurrentCommentId = value.CommentId;
			base.SetTextureByPath(value.RoleHeadPath, base.GetTexture(7), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), value.RoleName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), value.Comment, Array.Empty<object>());
			ValueTuple<int, int> finishMonthAndDay = currentChallengeData.GetFinishMonthAndDay();
			int item = finishMonthAndDay.Item1;
			int item2 = finishMonthAndDay.Item2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), value.TimeTxt, new <>z__ReadOnlyArray<object>(new object[]
			{
				item,
				item2
			}));
			base.SetTextureByPath(value.PhotoPath, base.GetTexture(12), null, null);
			this.RefreshVarStatePanel(new FunPlaySharpComment?(value));
		}

		// Token: 0x06042054 RID: 270420 RVA: 0x010F0734 File Offset: 0x010EE934
		private void RefreshVarStatePanel(FunPlaySharpComment? data)
		{
			int? num = (data != null) ? new int?(data.GetValueOrDefault().VarState) : null;
			bool uiactive = num.GetValueOrDefault() == 1;
			bool flag;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 2;
				flag = (num2.GetValueOrDefault() >= num3 & num2 != null);
			}
			else
			{
				flag = false;
			}
			bool uiactive2 = flag;
			base.GetItem(14).SetUIActive(uiactive2);
			base.GetItem(15).SetUIActive(uiactive);
		}

		// Token: 0x06042055 RID: 270421 RVA: 0x010F07BC File Offset: 0x010EE9BC
		private void RefreshArrowBtn(int index, int length)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(index > 0);
			base.GetButton(4).RootUIComp.Get().SetUIActive(index < length - 1);
		}

		// Token: 0x06042056 RID: 270422 RVA: 0x010F0805 File Offset: 0x010EEA05
		public void SetParentSequence(UiBehaviorLevelSequence sequence)
		{
			this.ParentUiViewSequence = sequence;
		}

		// Token: 0x06042057 RID: 270423 RVA: 0x010F0810 File Offset: 0x010EEA10
		private void PlaySwitchAnimation()
		{
			if (this.ParentUiViewSequence != null && this.ParentUiViewSequence.HasSequenceNameInPlaying("Switch1"))
			{
				this.ParentUiViewSequence.StopSequenceByKey("Switch1", false, true);
			}
			UiBehaviorLevelSequence parentUiViewSequence = this.ParentUiViewSequence;
			if (parentUiViewSequence == null)
			{
				return;
			}
			parentUiViewSequence.PlaySequence("Switch1", false, null);
		}

		// Token: 0x04024D0D RID: 150797
		private GenericLayout<ActivityFunPlayPage, FunPlaySharpComment> PageDotLayout;

		// Token: 0x04024D0E RID: 150798
		private int CurrentCommentIndex;

		// Token: 0x04024D0F RID: 150799
		private int CurrentCommentId;

		// Token: 0x04024D10 RID: 150800
		private UiBehaviorLevelSequence ParentUiViewSequence;

		// Token: 0x0200C791 RID: 51089
		[NullableContext(0)]
		private class EPageComponent
		{
			// Token: 0x0403D700 RID: 251648
			public const int Draggable = 0;

			// Token: 0x0403D701 RID: 251649
			public const int TextureContent = 1;

			// Token: 0x0403D702 RID: 251650
			public const int TextureItem = 2;

			// Token: 0x0403D703 RID: 251651
			public const int BtnLeft = 3;

			// Token: 0x0403D704 RID: 251652
			public const int BtnRight = 4;

			// Token: 0x0403D705 RID: 251653
			public const int RoleNone = 5;

			// Token: 0x0403D706 RID: 251654
			public const int Role = 6;

			// Token: 0x0403D707 RID: 251655
			public const int RoleHeadIcon = 7;

			// Token: 0x0403D708 RID: 251656
			public const int RoleName = 8;

			// Token: 0x0403D709 RID: 251657
			public const int RoleComment = 9;

			// Token: 0x0403D70A RID: 251658
			public const int TimeTxt = 10;

			// Token: 0x0403D70B RID: 251659
			public const int PageDotRoot = 11;

			// Token: 0x0403D70C RID: 251660
			public const int PhotoTexture = 12;

			// Token: 0x0403D70D RID: 251661
			public const int QuestionMark = 13;

			// Token: 0x0403D70E RID: 251662
			public const int PnlRed = 14;

			// Token: 0x0403D70F RID: 251663
			public const int PnlGreen = 15;
		}
	}
}
