using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FeedbackReward
{
	// Token: 0x02005D88 RID: 23944
	public class RewardPanel : UiPanelBase
	{
		// Token: 0x0603C4B0 RID: 246960 RVA: 0x00F4CFAC File Offset: 0x00F4B1AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C4B1 RID: 246961 RVA: 0x00F4D018 File Offset: 0x00F4B218
		protected override UniTask OnBeforeStartAsync()
		{
			RewardPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C4B2 RID: 246962 RVA: 0x00F4D05C File Offset: 0x00F4B25C
		[NullableContext(2)]
		public void RefreshItem(string texturePath, int? playerTitleId)
		{
			UUITexture texture = base.GetTexture(0);
			if (!string.IsNullOrEmpty(texturePath))
			{
				PlayerTitleItem playerTitleItem = this.PlayerTitleItem;
				if (playerTitleItem != null)
				{
					playerTitleItem.SetUiActive(false);
				}
				texture.SetUIActive(true);
				base.SetTextureByPath(texturePath, texture, null, null);
				return;
			}
			PlayerTitleItem playerTitleItem2 = this.PlayerTitleItem;
			if (playerTitleItem2 != null)
			{
				playerTitleItem2.SetUiActive(true);
			}
			texture.SetUIActive(false);
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			PlayerTitleItem playerTitleItem3 = this.PlayerTitleItem;
			if (playerTitleItem3 == null)
			{
				return;
			}
			playerTitleItem3.Refresh(playerTitleId, null, new int?((int)playerGender));
		}

		// Token: 0x04021E88 RID: 138888
		[Nullable(2)]
		private PlayerTitleItem PlayerTitleItem;

		// Token: 0x0200BDB9 RID: 48569
		private enum ERewardPanel
		{
			// Token: 0x0403A6DC RID: 239324
			Texture,
			// Token: 0x0403A6DD RID: 239325
			PlayerTitleItem
		}
	}
}
