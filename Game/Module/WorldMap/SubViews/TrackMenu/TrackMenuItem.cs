using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu
{
	// Token: 0x02004B82 RID: 19330
	public class TrackMenuItem : UiPanelBase
	{
		// Token: 0x060327C9 RID: 206793 RVA: 0x00CA16A0 File Offset: 0x00C9F8A0
		[NullableContext(1)]
		public UniTask Init(UUIItem uiItem, ITrackMenuItemData trackData)
		{
			TrackMenuItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.uiItem = uiItem;
			<Init>d__.trackData = trackData;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrackMenuItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060327CA RID: 206794 RVA: 0x00CA16F4 File Offset: 0x00C9F8F4
		protected override void OnStart()
		{
			UUIItem uiitem = (base.GetExtendToggle(0).GetOwner() as AUIBaseActor).GetUIItem();
			this.LevelSequencePlayer = new LevelSequencePlayer(uiitem);
		}

		// Token: 0x060327CB RID: 206795 RVA: 0x00CA1724 File Offset: 0x00C9F924
		protected override void OnBeforeShow()
		{
			this.PlayAppearSequence();
		}

		// Token: 0x060327CC RID: 206796 RVA: 0x00CA172C File Offset: 0x00C9F92C
		protected override void OnAfterShow()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			FOnToggleStateChange onStateChange = extendToggle.OnStateChange;
			if (onStateChange == null)
			{
				return;
			}
			onStateChange.Add(new Action<EToggleState>(this.OnClick));
		}

		// Token: 0x060327CD RID: 206797 RVA: 0x00CA1758 File Offset: 0x00C9F958
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060327CE RID: 206798 RVA: 0x00CA17E2 File Offset: 0x00C9F9E2
		public void OnClick(EToggleState state)
		{
			if (EToggleState.ETT_Checked == state)
			{
				this.PlayReleaseSequence().ContinueWith(delegate()
				{
					EventSystem instance = Singleton<EventSystem>.Instance;
					if (instance == null)
					{
						return;
					}
					instance.Emit<ITrackMenuItemData>(EEventName.TrackMenuClickItem, this.TrackData);
				});
			}
		}

		// Token: 0x060327CF RID: 206799 RVA: 0x00CA1800 File Offset: 0x00C9FA00
		private void SetUp()
		{
			this.SetSpriteByPath(this.TrackData.Icon, base.GetSprite(1), false, null, null);
			if (this.TrackData.MarkItem != null)
			{
				this.TrackData.MarkItem.SetTitleText(base.GetText(2));
				return;
			}
			if (this.TrackData.Title != null)
			{
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.SetText(this.TrackData.Title, true);
			}
		}

		// Token: 0x060327D0 RID: 206800 RVA: 0x00CA1880 File Offset: 0x00C9FA80
		protected override UniTask OnBeforeHideAsync()
		{
			TrackMenuItem.<OnBeforeHideAsync>d__10 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<TrackMenuItem.<OnBeforeHideAsync>d__10>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060327D1 RID: 206801 RVA: 0x00CA18C3 File Offset: 0x00C9FAC3
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				FOnToggleStateChange onStateChange = extendToggle.OnStateChange;
				if (onStateChange != null)
				{
					onStateChange.Clear();
				}
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x060327D2 RID: 206802 RVA: 0x00CA18FC File Offset: 0x00C9FAFC
		public UniTask PlayReleaseSequence()
		{
			TrackMenuItem.<PlayReleaseSequence>d__12 <PlayReleaseSequence>d__;
			<PlayReleaseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayReleaseSequence>d__.<>4__this = this;
			<PlayReleaseSequence>d__.<>1__state = -1;
			<PlayReleaseSequence>d__.<>t__builder.Start<TrackMenuItem.<PlayReleaseSequence>d__12>(ref <PlayReleaseSequence>d__);
			return <PlayReleaseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060327D3 RID: 206803 RVA: 0x00CA1940 File Offset: 0x00C9FB40
		public void PlayAppearSequence()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x060327D4 RID: 206804 RVA: 0x00CA1970 File Offset: 0x00C9FB70
		public UniTask PlayDisappearSequence()
		{
			TrackMenuItem.<PlayDisappearSequence>d__14 <PlayDisappearSequence>d__;
			<PlayDisappearSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDisappearSequence>d__.<>4__this = this;
			<PlayDisappearSequence>d__.<>1__state = -1;
			<PlayDisappearSequence>d__.<>t__builder.Start<TrackMenuItem.<PlayDisappearSequence>d__14>(ref <PlayDisappearSequence>d__);
			return <PlayDisappearSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0401D738 RID: 120632
		[Nullable(2)]
		private ITrackMenuItemData TrackData;

		// Token: 0x0401D739 RID: 120633
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AC4E RID: 44110
		public static class EComponents
		{
			// Token: 0x04035947 RID: 219463
			public const int Toggle = 0;

			// Token: 0x04035948 RID: 219464
			public const int Icon = 1;

			// Token: 0x04035949 RID: 219465
			public const int Info = 2;
		}
	}
}
