using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068C1 RID: 26817
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchDropItemDetailView : UiViewBase
	{
		// Token: 0x06042B27 RID: 273191 RVA: 0x0111DED9 File Offset: 0x0111C0D9
		public DropCatchDropItemDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042B28 RID: 273192 RVA: 0x0111DEE4 File Offset: 0x0111C0E4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x06042B29 RID: 273193 RVA: 0x0111DF6A File Offset: 0x0111C16A
		protected override void OnBeforeCreate()
		{
			this.Proxy = (this.OpenParam as DropCatchGameplayProxy);
			DropCatchGameplayProxy proxy = this.Proxy;
			if (proxy == null)
			{
				return;
			}
			proxy.PauseGameplay("DropItemDetail");
		}

		// Token: 0x06042B2A RID: 273194 RVA: 0x0111DF94 File Offset: 0x0111C194
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				this.CaptionItem = new PopupCaptionItem(item);
				this.CaptionItem.SetCloseCallBack(delegate
				{
					DropCatchGameplayProxy proxy = this.Proxy;
					if (proxy != null)
					{
						proxy.ResumeGameplay("DropItemDetail");
					}
					base.CloseMe(null);
				});
			}
			this.ItemLayout = new GenericLayout<CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item.DropCatchDropItem, int>(base.GetVerticalLayout(1), new Func<CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item.DropCatchDropItem>(this.InitItem), null, false, true);
		}

		// Token: 0x06042B2B RID: 273195 RVA: 0x0111DFF0 File Offset: 0x0111C1F0
		protected override void OnBeforeShow()
		{
			this.Proxy = (this.OpenParam as DropCatchGameplayProxy);
			DropCatchGameplayProxy proxy = this.Proxy;
			this.CurOpenLevelId = ((proxy != null) ? proxy.GetCurGameplayId() : 0);
			this.RefreshPreviewContent();
			this.SwitchContent();
			USpineSkeletonAnimationComponent spine = base.GetSpine(4);
			if (spine == null)
			{
				return;
			}
			spine.SetAnimation(0, EDropCatchRobotAnimState.IdleRight.ToEnumString(), true);
		}

		// Token: 0x06042B2C RID: 273196 RVA: 0x0111E04C File Offset: 0x0111C24C
		private CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item.DropCatchDropItem InitItem()
		{
			return new CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item.DropCatchDropItem();
		}

		// Token: 0x06042B2D RID: 273197 RVA: 0x0111E054 File Offset: 0x0111C254
		private void RefreshPreviewContent()
		{
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(this.CurOpenLevelId);
			if (dropCatchGameplayById == null)
			{
				return;
			}
			GenericLayout<CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item.DropCatchDropItem, int> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.RefreshByData(dropCatchGameplayById.Value.DropItemList().ToList<int>(), null, false);
		}

		// Token: 0x06042B2E RID: 273198 RVA: 0x0111E0A4 File Offset: 0x0111C2A4
		private void SwitchContent()
		{
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(this.CurOpenLevelId);
			if (dropCatchGameplayById == null)
			{
				return;
			}
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(dropCatchGameplayById.Value.Desc);
		}

		// Token: 0x04025287 RID: 152199
		[Nullable(2)]
		private DropCatchGameplayProxy Proxy;

		// Token: 0x04025288 RID: 152200
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025289 RID: 152201
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item.DropCatchDropItem, int> ItemLayout;

		// Token: 0x0402528A RID: 152202
		private int CurOpenLevelId;
	}
}
