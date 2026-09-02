using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200516A RID: 20842
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomSelectResultView : RogueSelectResultBaseView
	{
		// Token: 0x06035A27 RID: 219687 RVA: 0x00D78D5B File Offset: 0x00D76F5B
		public PhantomSelectResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035A28 RID: 219688 RVA: 0x00D78D64 File Offset: 0x00D76F64
		protected override UniTask OnCreateAsync()
		{
			PhantomSelectResultView.<OnCreateAsync>d__4 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<PhantomSelectResultView.<OnCreateAsync>d__4>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035A29 RID: 219689 RVA: 0x00D78DA8 File Offset: 0x00D76FA8
		protected override void OnStart()
		{
			base.OnStart();
			this.RogueSelectResult = (this.OpenParam as RogueSelectResult);
			this.UiPoolActorPrivate.UiItem.SetUIParent(base.GetHorizontalLayout(3).GetRootComponent(), false);
			this.PhantomSelectItemLayout = new GenericLayout<PhantomSelectItem, IPhantomSelectItemContextData>(base.GetHorizontalLayout(3), new Func<PhantomSelectItem>(this.CreatePhantomSelectItem), null, false, true);
		}

		// Token: 0x06035A2A RID: 219690 RVA: 0x00D78E0A File Offset: 0x00D7700A
		private PhantomSelectItem CreatePhantomSelectItem()
		{
			return new PhantomSelectItem(false);
		}

		// Token: 0x06035A2B RID: 219691 RVA: 0x00D78E12 File Offset: 0x00D77012
		protected override void OnBeforeDestroy()
		{
			if (this.UiPoolActorPrivate != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.UiPoolActorPrivate, "UiItem_PhantomSelectItem_Prefab");
			}
		}

		// Token: 0x06035A2C RID: 219692 RVA: 0x00D78E31 File Offset: 0x00D77031
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06035A2D RID: 219693 RVA: 0x00D78E39 File Offset: 0x00D77039
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x06035A2E RID: 219694 RVA: 0x00D78E41 File Offset: 0x00D77041
		protected override void Refresh()
		{
			this.RefreshPhantomSelectItemList();
			this.RefreshTitleText();
		}

		// Token: 0x06035A2F RID: 219695 RVA: 0x00D78E50 File Offset: 0x00D77050
		private unsafe void RefreshPhantomSelectItemList()
		{
			PhantomSelectItemContextData phantomSelectItemContextData = new PhantomSelectItemContextData
			{
				RogueGainEntry = this.RogueSelectResult.NewRogueGainEntry,
				RoguelikeInfo = ModelBase<RoguelikeModel>.Instance.RogueInfo
			};
			int num = 1;
			List<IPhantomSelectItemContextData> list = new List<IPhantomSelectItemContextData>(num);
			CollectionsMarshal.SetCount<IPhantomSelectItemContextData>(list, num);
			Span<IPhantomSelectItemContextData> span = CollectionsMarshal.AsSpan<IPhantomSelectItemContextData>(list);
			int index = 0;
			*span[index] = phantomSelectItemContextData;
			List<IPhantomSelectItemContextData> data = list;
			this.PhantomSelectItemLayout.RefreshByData(data, null, false);
		}

		// Token: 0x06035A30 RID: 219696 RVA: 0x00D78EB7 File Offset: 0x00D770B7
		protected void RefreshTitleText()
		{
			if (this.RogueSelectResult.OldRogueGainEntry == null)
			{
				base.GetText(4).ShowTextNew("RoguelikeView_25_Text");
				return;
			}
			base.GetText(4).ShowTextNew("RoguelikeView_19_Text");
		}

		// Token: 0x0401ECC8 RID: 126152
		[Nullable(2)]
		private RogueSelectResult RogueSelectResult;

		// Token: 0x0401ECC9 RID: 126153
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PhantomSelectItem, IPhantomSelectItemContextData> PhantomSelectItemLayout;

		// Token: 0x0401ECCA RID: 126154
		[Nullable(2)]
		private UiPoolActor UiPoolActorPrivate;
	}
}
