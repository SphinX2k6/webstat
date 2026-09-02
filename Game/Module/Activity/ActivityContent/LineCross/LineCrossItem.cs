using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x0200676B RID: 26475
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LineCrossItem : GridProxyAbstract<ItemData>
	{
		// Token: 0x06041FEC RID: 270316 RVA: 0x010EEAB4 File Offset: 0x010ECCB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041FED RID: 270317 RVA: 0x010EEC64 File Offset: 0x010ECE64
		protected override UniTask OnBeforeStartAsync()
		{
			LineCrossItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LineCrossItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041FEE RID: 270318 RVA: 0x010EECA8 File Offset: 0x010ECEA8
		private void OnClickBtn()
		{
			int id = this.CurrentData.Data.Id;
			int groupId = this.CurrentData.GroupId;
			if (!ModelBase<LineCrossModel>.Instance.GetGroupUnlockState(id, groupId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("LineCross_Challenge_LockTime", Array.Empty<object>());
				return;
			}
			LineCrossDetailViewModel lineCrossDetailViewModel = new LineCrossDetailViewModel();
			lineCrossDetailViewModel.GroupId = groupId;
			lineCrossDetailViewModel.LineCrossActivityData = this.CurrentData.Data;
			lineCrossDetailViewModel.GridIndex = base.GridIndex;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LineCrossDetailView, lineCrossDetailViewModel, null);
		}

		// Token: 0x06041FEF RID: 270319 RVA: 0x010EED30 File Offset: 0x010ECF30
		public override void Refresh(ItemData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			ELineCrossGroupState groupState = ModelBase<LineCrossModel>.Instance.GetGroupState(data.Data.Id, data.GroupId);
			bool ifHiddenGroup = ModelBase<LineCrossModel>.Instance.GetIfHiddenGroup(data.Data.Id, data.GroupId);
			switch (groupState)
			{
			case ELineCrossGroupState.Normal:
				this.RefreshNormal();
				break;
			case ELineCrossGroupState.Passed:
				this.RefreshClear();
				break;
			case ELineCrossGroupState.Lock:
				this.RefreshLock();
				break;
			default:
				this.RefreshNormal();
				break;
			}
			this.RefreshNameText(data.GroupId);
			this.RefreshProgressText(groupState, data);
			this.RefreshLevelIndexText(gridIndex);
			this.RefreshLockSprite(groupState == ELineCrossGroupState.Lock);
			this.RefreshRedDot(data.GroupId);
			this.RefreshClawItem(ifHiddenGroup, groupState);
		}

		// Token: 0x06041FF0 RID: 270320 RVA: 0x010EEDE7 File Offset: 0x010ECFE7
		private void RefreshClawItem(bool ifHidden, ELineCrossGroupState state)
		{
			LineCrossClawItem clawItem = this.ClawItem;
			if (clawItem == null)
			{
				return;
			}
			clawItem.Refresh(ifHidden, state);
		}

		// Token: 0x06041FF1 RID: 270321 RVA: 0x010EEDFB File Offset: 0x010ECFFB
		private void RefreshRedDot(int groupId)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.LineCrossGroupRedDot, base.GetItem(9), groupId);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.LineCrossGroupRedDot, base.GetItem(9), null, groupId);
		}

		// Token: 0x06041FF2 RID: 270322 RVA: 0x010EEE30 File Offset: 0x010ED030
		private void RefreshLevelIndexText(int gridIndex)
		{
			base.GetText(6).SetText((gridIndex + 1).ToString(), true);
		}

		// Token: 0x06041FF3 RID: 270323 RVA: 0x010EEE55 File Offset: 0x010ED055
		private void RefreshLockSprite(bool isLock)
		{
			base.GetSprite(7).SetUIActive(isLock);
		}

		// Token: 0x06041FF4 RID: 270324 RVA: 0x010EEE64 File Offset: 0x010ED064
		private void RefreshProgressText(ELineCrossGroupState state, ItemData data)
		{
			string newText;
			switch (state)
			{
			case ELineCrossGroupState.Normal:
				newText = ModelBase<LineCrossModel>.Instance.GetGroupRewardProgress(data.Data.Id, data.GroupId);
				break;
			case ELineCrossGroupState.Passed:
				newText = (ConfigMultiTextLang.GetLocalTextNew("LineCrossPass", null) ?? "");
				break;
			case ELineCrossGroupState.Lock:
				newText = ModelBase<LineCrossModel>.Instance.GetLockDescription(data.Data.Id, data.GroupId);
				break;
			default:
				newText = (ConfigMultiTextLang.GetLocalTextNew("LineCrossPass", null) ?? "");
				break;
			}
			base.GetText(5).SetText(newText, true);
		}

		// Token: 0x06041FF5 RID: 270325 RVA: 0x010EEF04 File Offset: 0x010ED104
		private void RefreshNameText(int groupId)
		{
			string name = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value.Name;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), name, Array.Empty<object>());
		}

		// Token: 0x06041FF6 RID: 270326 RVA: 0x010EEF44 File Offset: 0x010ED144
		private void RefreshNormal()
		{
			base.GetTexture(1).SetColor(FColor.FromHex("3c187d"));
			base.GetSprite(3).SetColor(FColor.FromHex("a591b7"));
			base.GetText(5).SetColor(FColor.FromHex("ffffff"));
			base.GetSprite(8).SetColor(FColor.FromHex("ffffff"));
		}

		// Token: 0x06041FF7 RID: 270327 RVA: 0x010EEFAC File Offset: 0x010ED1AC
		private void RefreshClear()
		{
			base.GetTexture(1).SetColor(FColor.FromHex("1a5e45"));
			base.GetSprite(3).SetColor(FColor.FromHex("84c991"));
			base.GetText(5).SetColor(FColor.FromHex("93de9e"));
			base.GetSprite(8).SetColor(FColor.FromHex("00ffc4"));
		}

		// Token: 0x06041FF8 RID: 270328 RVA: 0x010EF014 File Offset: 0x010ED214
		private void RefreshLock()
		{
			base.GetTexture(1).SetColor(FColor.FromHex("881e32"));
			base.GetSprite(3).SetColor(FColor.FromHex("5c4949"));
			base.GetText(5).SetColor(FColor.FromHex("ff4141"));
			base.GetSprite(8).SetColor(FColor.FromHex("ff4e4e"));
		}

		// Token: 0x04024CF6 RID: 150774
		[Nullable(2)]
		protected ItemData CurrentData;

		// Token: 0x04024CF7 RID: 150775
		[Nullable(2)]
		private LineCrossClawItem ClawItem;

		// Token: 0x0200C789 RID: 51081
		[NullableContext(0)]
		private class EItemComponent
		{
			// Token: 0x0403D6E0 RID: 251616
			public const int Button = 0;

			// Token: 0x0403D6E1 RID: 251617
			public const int CircleTexture = 1;

			// Token: 0x0403D6E2 RID: 251618
			public const int ClawItem = 2;

			// Token: 0x0403D6E3 RID: 251619
			public const int SpriteLevelDesc = 3;

			// Token: 0x0403D6E4 RID: 251620
			public const int NameText = 4;

			// Token: 0x0403D6E5 RID: 251621
			public const int ProgressText = 5;

			// Token: 0x0403D6E6 RID: 251622
			public const int LevelIndexText = 6;

			// Token: 0x0403D6E7 RID: 251623
			public const int LockSprite = 7;

			// Token: 0x0403D6E8 RID: 251624
			public const int ProgressDescSprite = 8;

			// Token: 0x0403D6E9 RID: 251625
			public const int RedDot = 9;
		}
	}
}
