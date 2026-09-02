using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200638E RID: 25486
	internal class AbyssDangoLikeItem : UiPanelBase
	{
		// Token: 0x0603FFFC RID: 262140 RVA: 0x01067234 File Offset: 0x01065434
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickLikeBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FFFD RID: 262141 RVA: 0x010672FC File Offset: 0x010654FC
		protected override UniTask OnBeforeStartAsync()
		{
			AbyssDangoLikeItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AbyssDangoLikeItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FFFE RID: 262142 RVA: 0x0106733F File Offset: 0x0106553F
		private void OnClickLikeBtn()
		{
			ControllerBase<DangoAbyssController>.Instance.AbyssLikePlayer(this.CurrentPlayerId.Value);
		}

		// Token: 0x0603FFFF RID: 262143 RVA: 0x01067358 File Offset: 0x01065558
		public void Refresh(int data, int playerId, bool afterLike = false)
		{
			this.CurrentPlayerId = new int?(playerId);
			this.AbyssDangoLikeCountItem.Refresh(data);
			this.AbyssDangoLikeCountItem.SetActive(afterLike);
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(!afterLike);
		}

		// Token: 0x06040000 RID: 262144 RVA: 0x010673AB File Offset: 0x010655AB
		public void RefreshLineState(bool isShow)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isShow);
		}

		// Token: 0x04023EFC RID: 147196
		[Nullable(1)]
		private AbyssDangoLikeCountItem AbyssDangoLikeCountItem;

		// Token: 0x04023EFD RID: 147197
		private int? CurrentPlayerId;

		// Token: 0x0200C3E5 RID: 50149
		private enum ELikeItem
		{
			// Token: 0x0403C571 RID: 247153
			LikeBtn,
			// Token: 0x0403C572 RID: 247154
			LikeCountItem,
			// Token: 0x0403C573 RID: 247155
			LikeLine
		}
	}
}
