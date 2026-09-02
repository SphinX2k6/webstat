using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using CSharpScript.Game.Module.Map.Marks.SubPanel;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200587C RID: 22652
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaNpcMarkItemView : ConfigMarkItemView
	{
		// Token: 0x06039996 RID: 235926 RVA: 0x00E9C9CD File Offset: 0x00E9ABCD
		public PhantomArenaNpcMarkItemView(PhantomArenaNpcMarkItem markItem) : base(markItem)
		{
		}

		// Token: 0x06039997 RID: 235927 RVA: 0x00E9C9D8 File Offset: 0x00E9ABD8
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaNpcMarkItemView.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaNpcMarkItemView.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039998 RID: 235928 RVA: 0x00E9CA1C File Offset: 0x00E9AC1C
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			if (ModelBase<MapModel>.Instance.IsExtraUiMarkType(this.Holder.MapType, this.Holder.MarkType))
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				PhantomArenaMapNpcUi phantomArenaMapNpcUi = this.PhantomArenaMapNpcUi;
				if (phantomArenaMapNpcUi != null)
				{
					phantomArenaMapNpcUi.SetData(this.Holder.MarkId);
				}
				PhantomArenaMapNpcUi phantomArenaMapNpcUi2 = this.PhantomArenaMapNpcUi;
				if (phantomArenaMapNpcUi2 == null)
				{
					return;
				}
				phantomArenaMapNpcUi2.SetActive(true);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(0);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				PhantomArenaMapNpcUi phantomArenaMapNpcUi3 = this.PhantomArenaMapNpcUi;
				if (phantomArenaMapNpcUi3 == null)
				{
					return;
				}
				phantomArenaMapNpcUi3.SetActive(false);
				return;
			}
		}

		// Token: 0x06039999 RID: 235929 RVA: 0x00E9CAB0 File Offset: 0x00E9ACB0
		[PreserveBaseOverrides]
		protected new virtual MarkItemSelectHandle CreateSelectHandle(IMarkItemComponentContext markComponentContext)
		{
			return new PhantomArenaNpcMarkItemSelectHandle(markComponentContext);
		}

		// Token: 0x0603999A RID: 235930 RVA: 0x00E9CAB8 File Offset: 0x00E9ACB8
		[NullableContext(2)]
		public override UUIItem GetIconItem()
		{
			PhantomArenaMapNpcUi phantomArenaMapNpcUi = this.PhantomArenaMapNpcUi;
			if (phantomArenaMapNpcUi == null)
			{
				return null;
			}
			return phantomArenaMapNpcUi.GetRootItem();
		}

		// Token: 0x04020AD4 RID: 133844
		[Nullable(2)]
		private PhantomArenaMapNpcUi PhantomArenaMapNpcUi;
	}
}
