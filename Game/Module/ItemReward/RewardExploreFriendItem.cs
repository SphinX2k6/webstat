using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B52 RID: 23378
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RewardExploreFriendItem : GridProxyAbstract<IRewardExploreFriendData>
	{
		// Token: 0x0603B25C RID: 242268 RVA: 0x00EF72BC File Offset: 0x00EF54BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickAddButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B25D RID: 242269 RVA: 0x00EF7407 File Offset: 0x00EF5607
		protected override void OnAfterShow()
		{
			base.OnAfterShow();
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ApplicationSent, new Action<int>(this.ApplicationSent));
		}

		// Token: 0x0603B25E RID: 242270 RVA: 0x00EF742B File Offset: 0x00EF562B
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			Singleton<EventSystem>.Instance.Remove(EEventName.ApplicationSent, new Action<int>(this.ApplicationSent));
		}

		// Token: 0x0603B25F RID: 242271 RVA: 0x00EF7450 File Offset: 0x00EF5650
		[NullableContext(1)]
		public override void Refresh(IRewardExploreFriendData data, bool isSelected, int gridIndex)
		{
			this.DataCache = data;
			bool isMyFriend = data.IsMyFriend;
			base.GetSprite(5).SetUIActive(isMyFriend);
			base.GetTexture(6).SetUIActive(isMyFriend);
			base.SetButtonUiActive(4, !isMyFriend);
			base.SetTextureByPath(data.PlayerIconPath, base.GetTexture(0), null, null);
			base.SetTextureByPath(data.PlayerIndexPath, base.GetTexture(1), null, null);
			base.GetText(2).SetText(data.PlayerName, true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "TowerDefence_Rolename", new <>z__ReadOnlySingleElementList<object>(data.PlayerLevel));
		}

		// Token: 0x0603B260 RID: 242272 RVA: 0x00EF7504 File Offset: 0x00EF5704
		private void OnClickAddButton()
		{
			int playerId = this.DataCache.PlayerId;
			base.GetSprite(5).SetUIActive(true);
			base.GetTexture(6).SetUIActive(true);
			base.SetButtonUiActive(4, false);
			if (!this.DataCache.IsMyFriend)
			{
				this.DataCache.OnClickCallback(playerId);
			}
		}

		// Token: 0x0603B261 RID: 242273 RVA: 0x00EF755D File Offset: 0x00EF575D
		private void ApplicationSent(int playerId)
		{
			if (playerId == this.DataCache.PlayerId)
			{
				base.SetButtonUiActive(4, false);
			}
		}

		// Token: 0x04021581 RID: 136577
		[Nullable(2)]
		private IRewardExploreFriendData DataCache;

		// Token: 0x0200BB53 RID: 47955
		private class EComponent
		{
			// Token: 0x04039CEB RID: 236779
			public const int PlayerIconTexture = 0;

			// Token: 0x04039CEC RID: 236780
			public const int PlayerIndexTexture = 1;

			// Token: 0x04039CED RID: 236781
			public const int PlayerNameText = 2;

			// Token: 0x04039CEE RID: 236782
			public const int PlayerDescText = 3;

			// Token: 0x04039CEF RID: 236783
			public const int AddButton = 4;

			// Token: 0x04039CF0 RID: 236784
			public const int DoneSprite = 5;

			// Token: 0x04039CF1 RID: 236785
			public const int DoneMaskTexture = 6;
		}
	}
}
