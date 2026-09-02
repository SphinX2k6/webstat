using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069B9 RID: 27065
	[NullableContext(2)]
	[Nullable(0)]
	public class BossRushBuffSelectInGameView : UiViewBase
	{
		// Token: 0x060431B7 RID: 274871 RVA: 0x0113C772 File Offset: 0x0113A972
		[NullableContext(1)]
		public BossRushBuffSelectInGameView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060431B8 RID: 274872 RVA: 0x0113C788 File Offset: 0x0113A988
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickConfirmButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060431B9 RID: 274873 RVA: 0x0113C850 File Offset: 0x0113AA50
		protected override UniTask OnBeforeStartAsync()
		{
			BossRushBuffSelectInGameView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossRushBuffSelectInGameView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060431BA RID: 274874 RVA: 0x0113C894 File Offset: 0x0113AA94
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			List<int> choseBuffInGameHandleList = ModelBase<BossRushModel>.Instance.ChoseBuffInGameHandleList;
			int count = ModelBase<BossRushModel>.Instance.ChoseBuffInGameHandleList.Count;
			for (int i = 0; i < count; i++)
			{
				int buffId = choseBuffInGameHandleList[i];
				this.BuffItemList[i].RefreshItem(buffId);
			}
			UUIInturnAnimController animationController = this.AnimationController;
			if (animationController != null)
			{
				animationController.Play("", -1, false);
			}
			this.RefreshConfirmButton();
		}

		// Token: 0x060431BB RID: 274875 RVA: 0x0113C914 File Offset: 0x0113AB14
		private void OnClickConfirmButton()
		{
			if (this.CurrentSelectBuff == null)
			{
				return;
			}
			int index = this.BuffItemList.IndexOf(this.CurrentSelectBuff);
			ControllerBase<BossRushController>.Instance.RequestBossRushChooseBuffInGame(index);
			this.CloseMeAsync();
		}

		// Token: 0x060431BC RID: 274876 RVA: 0x0113C94F File Offset: 0x0113AB4F
		private void OnClickBuffItem(BossRushBuffSelectInGameItem selectItem)
		{
			BossRushBuffSelectInGameItem currentSelectBuff = this.CurrentSelectBuff;
			if (currentSelectBuff != null)
			{
				currentSelectBuff.SetToggleUnCheck();
			}
			this.CurrentSelectBuff = selectItem;
			this.RefreshConfirmButton();
		}

		// Token: 0x060431BD RID: 274877 RVA: 0x0113C96F File Offset: 0x0113AB6F
		private void RefreshConfirmButton()
		{
			base.GetButton(1).SetSelfInteractive(this.CurrentSelectBuff != null);
		}

		// Token: 0x04025654 RID: 153172
		[Nullable(1)]
		private readonly List<BossRushBuffSelectInGameItem> BuffItemList = new List<BossRushBuffSelectInGameItem>();

		// Token: 0x04025655 RID: 153173
		private BossRushBuffSelectInGameItem CurrentSelectBuff;

		// Token: 0x04025656 RID: 153174
		private UUIInturnAnimController AnimationController;

		// Token: 0x0200C941 RID: 51521
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403DE62 RID: 253538
			public const int BuffRootItem = 0;

			// Token: 0x0403DE63 RID: 253539
			public const int ConfirmButton = 1;

			// Token: 0x0403DE64 RID: 253540
			public const int ToggleItem = 2;
		}
	}
}
